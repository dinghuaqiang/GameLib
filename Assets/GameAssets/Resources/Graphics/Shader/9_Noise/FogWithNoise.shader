/**
    后处理效果
	根据噪声图做雾效
*/
Shader "GameLib/PostEffects/FogWithNoise"
{
    Properties {
		//输入的RenterTexture
		_MainTex ("Base (RGB)", 2D) = "white" {}
		//雾的浓度
		_FogDensity ("Fog Density", Float) = 1.0
		_FogColor ("Fog Color", Color) = (1, 1, 1, 1)
		_FogStart ("Fog Start", Float) = 0.0
		_FogEnd ("Fog End", Float) = 1.0

		_NoiseTex ("Noise Tex", 2D) = "white" {}
		_FogXSpeed ("Fog Horizontal Speed", Float) = 0.1
		_FogYSpeed ("Fog Vertical Speed", Float) = 0.1
		_NoiseAmount ("Noise Amount", Float) = 1
	}

	SubShader 
	{
		CGINCLUDE
		
		#include "UnityCG.cginc"
		
		//近截面
		float4x4 _FrustumCornersRay;
		sampler2D _MainTex;
		//主纹理纹素大小，主要是用来对深度纹理的采样坐标进行平台差异化处理
		half4 _MainTex_TexelSize;
		//Unity传递的深度纹理
		sampler2D _CameraDepthTexture;
		half _FogDensity;
		fixed4 _FogColor;
		float _FogStart;
		float _FogEnd;
		//噪声图相关
		sampler2D _NoiseTex;
		half _FogXSpeed;
		half _FogYSpeed;
		half _NoiseAmount;
		  
		struct v2f {
			float4 pos : SV_POSITION;
			half2 uv: TEXCOORD0;
			//对深度纹理采样的纹理坐标变量
			half2 uv_depth : TEXCOORD1;
			//插值后的像素向量
			float4 interpolatedRay : TEXCOORD2;
		};
		  
		v2f vert(appdata_img v) {
			v2f o;
			o.pos = UnityObjectToClipPos(v.vertex);
			o.uv = v.texcoord;
			o.uv_depth = v.texcoord;
			
			/**
				UNITY_UV_STARTS_AT_TOP 总是用1或0定义；当纹理的V坐标系原点在纹理顶部的平台上值是1。Direct3D类似平台使用1；OpenGL类似平台使用0。
				用来判断我们是否是在 Direct3D 平台下。
				在Direct3D平台下，如果我们开启了抗锯齿，则_MainTex_TexelSize.y 会变成负值，好让我们能够正确的进行采样。
				所以if (_MainTex_TexelSize.y < 0)的作用就是判断我们当前是否开启了抗锯齿。
				https://blog.csdn.net/WPAPA/article/details/72721185
			*/
			#if UNITY_UV_STARTS_AT_TOP
			if (_MainTex_TexelSize.y < 0)
				o.uv_depth.y = 1 - o.uv_depth.y;
			#endif

			//纹理坐标(0,0)对应左下角，(1,1)对应右上角，以此判断顶点对应的索引
			int index = 0;
			if (v.texcoord.x < 0.5 && v.texcoord.y < 0.5)
			{
				index = 0;
			}
			else if (v.texcoord.x > 0.5 && v.texcoord.y < 0.5)
			{
				index = 1;
			}
			else if (v.texcoord.x > 0.5 && v.texcoord.y > 0.5)
			{
				index = 2;
			}
			else
			{
				index = 3;
			}

			#if UNITY_UV_STARTS_AT_TOP
			if (_MainTex_TexelSize.y < 0)
				index = 3 - index;
			#endif
			//取对应的行作为该顶点的interpolatedRay(插值后得到的射线，包含了该像素到摄像机的方向，距离信息)值
			o.interpolatedRay = _FrustumCornersRay[index];

			return o;
		}

		fixed4 frag(v2f i) : SV_Target
		{
			//对深度图采样，然后使用LinearEyeDepth得到视角空间下的线性深度值。
			float linearDepth = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, i.uv_depth));
			//根据公式得到世界空间下的位置(根据深度图重建该像素在世界空间中的位置)
			float3 worldPos = _WorldSpaceCameraPos + linearDepth * i.interpolatedRay.xyz;

			float2 speed = _Time.y * float2(_FogXSpeed, _FogYSpeed);
			//计算当前噪声图的偏移量得到偏移值，减去0.5，再乘以噪声程度，获取最终的噪声值
			float noise = (tex2D(_NoiseTex, i.uv + speed).r - 0.5) * _NoiseAmount;
			//计算像素高度对应的雾效系数
			float fogDensity = (_FogEnd - worldPos.y) / (_FogEnd - _FogStart);
			//截取到0-1范围内，作为最后的雾效系数，这里把噪声值添加到雾效浓度的计算中了。
			fogDensity = saturate(fogDensity * _FogDensity * (1 + noise));
			//将雾的颜色和原始颜色进行混合
			fixed4 finalColor = tex2D(_MainTex, i.uv);
			finalColor.rgb = lerp(finalColor.rgb, _FogColor.rgb, fogDensity);

			return finalColor;
		}

		ENDCG
		
		Pass {
			ZTest Always Cull Off ZWrite Off

			CGPROGRAM
			  
			#pragma vertex vert  
			#pragma fragment frag
			  
			ENDCG  
		}
	} 
	FallBack Off
}
