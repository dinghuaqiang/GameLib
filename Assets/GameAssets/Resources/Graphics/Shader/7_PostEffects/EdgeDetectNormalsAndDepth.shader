/**
    后处理效果
	根据深度纹理和法线图做边缘检测
*/
Shader "GameLib/PostEffects/EdgeDetectNormalsAndDepth"
{
    Properties {
		//输入的RenterTexture
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_EdgeOnly ("Edge Only", Float) = 1.0
		_EdgeColor ("Edge Color", Color) = (1, 1, 1, 1)
		_BackgroundColor  ("Background Color", Color) = (1, 1, 1, 1)
		_SampleDistance ("Sample Distance", Float) = 1.0
		//灵敏度,xy对应法线和深度的检测灵敏度,zw传的0，没什么用
		_Sensitivity ("Sensitivity", Vector) = (1, 1, 1, 1)
	}

	SubShader 
	{
		CGINCLUDE
		
		#include "UnityCG.cginc"
		
		sampler2D _MainTex;
		//主纹理纹素大小，主要是用来对深度纹理的采样坐标进行平台差异化处理
		half4 _MainTex_TexelSize;
		fixed4 _EdgeOnly;
		fixed4 _EdgeColor;
		fixed4 _BackgroundColor;
		float _SampleDistance;
		half4 _Sensitivity;
		//Unity传递的深度+法线纹理
		sampler2D _CameraDepthNormalsTexture;
		  
		struct v2f {
			float4 pos : SV_POSITION;
			half2 uv[5]: TEXCOORD0;
		};
		  
		v2f vert(appdata_img v) {
			v2f o;
			o.pos = UnityObjectToClipPos(v.vertex);
			half2 uv = v.texcoord;
			//存储屏幕颜色图像的采样纹理
			o.uv[0] = uv;
			
			/**
				UNITY_UV_STARTS_AT_TOP 总是用1或0定义；当纹理的V坐标系原点在纹理顶部的平台上值是1。Direct3D类似平台使用1；OpenGL类似平台使用0。
				用来判断我们是否是在 Direct3D 平台下。
				在Direct3D平台下，如果我们开启了抗锯齿，则_MainTex_TexelSize.y 会变成负值，好让我们能够正确的进行采样。
				所以if (_MainTex_TexelSize.y < 0)的作用就是判断我们当前是否开启了抗锯齿。
				https://blog.csdn.net/WPAPA/article/details/72721185
			*/
			#if UNITY_UV_STARTS_AT_TOP
			if (_MainTex_TexelSize.y < 0)
				uv.y = 1 - uv.y;
			#endif
			//存储使用Roberts算子时需要采样的纹理坐标，使用_SampleDistance控制采样距离。
			o.uv[1] = uv + _MainTex_TexelSize.xy * half2(1, 1)   * _SampleDistance;
			o.uv[2] = uv + _MainTex_TexelSize.xy * half2(-1, -1) * _SampleDistance;
			o.uv[3] = uv + _MainTex_TexelSize.xy * half2(-1, 1)  * _SampleDistance;
			o.uv[4] = uv + _MainTex_TexelSize.xy * half2(1, -1)  * _SampleDistance;

			return o;
		}

		half CheckSame(half4 center, half4 sample)
		{
			/**
				得到两个采样点的法线和深度值，这里并没有解码得到真正的法线值，直接使用了xy分量。
				因为这里只需要比较两个采样值之间的差异度，并不需要知道它们真正的法线值。
			*/
			half2 centerNormal = center.xy;
			float centerDepth = DecodeFloatRG(center.zw);
			half2 sampleNormal = sample.xy;
			float sampleDepth = DecodeFloatRG(sample.zw);

			/**
				把两个采样点的值相减并取绝对值，再乘以灵敏度参数，把差异值的每个分量相加再和一个阈值比较
				如果它们的和小于阈值，则返回1，说明差异不明显，不存在一条边界。
				否则返回0
			*/
			half2 diffNormal = abs(centerNormal - sampleNormal) * _Sensitivity.x;
			int isSameNormal = (diffNormal.x + diffNormal.y) < 0.1;

			float diffDepth = abs(centerDepth - sampleDepth) * _Sensitivity.y;
			int isSameDepth = diffDepth < 0.1 * centerDepth;

			return isSameNormal * isSameDepth ? 1.0 : 0.0;
		}

		fixed4 fragRobertsCrossDepthAndNormal(v2f i) : SV_Target
		{
			//使用4个纹理坐标对深度+法线纹理进行采样
			half4 sample1 = tex2D(_CameraDepthNormalsTexture, i.uv[1]);
			half4 sample2 = tex2D(_CameraDepthNormalsTexture, i.uv[2]);
			half4 sample3 = tex2D(_CameraDepthNormalsTexture, i.uv[3]);
			half4 sample4 = tex2D(_CameraDepthNormalsTexture, i.uv[4]);

			//使用CheckSame函数来分别计算对角线上两个纹理值的差值
			half edge = 1.0;
			//CheckSame返回值要么是0要么是1，返回0时代表两点之前存在一条边界，反之则返回1.
			edge *= CheckSame(sample1, sample2);
			edge *= CheckSame(sample3, sample4);

			fixed4 withEdgeColor = lerp(_EdgeColor, tex2D(_MainTex, i.uv[0]), edge);
			fixed4 onlyEdgeColor = lerp(_EdgeColor, _BackgroundColor, edge);

			fixed4 color = lerp(withEdgeColor, onlyEdgeColor, _EdgeOnly);

			return color;
		}
		
		ENDCG
		
		Pass {
			ZTest Always Cull Off ZWrite Off

			CGPROGRAM
			  
			#pragma vertex vert  
			#pragma fragment fragRobertsCrossDepthAndNormal
			  
			ENDCG  
		}
	} 
	FallBack Off
}
