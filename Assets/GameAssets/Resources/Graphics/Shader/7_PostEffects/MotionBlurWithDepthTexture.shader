/**
    后处理效果
	根据深度图做运动模糊效果
*/
Shader "GameLib/PostEffects/MotionBlurWithDepthTexture"
{
    Properties {
		//输入的RenterTexture
		_MainTex ("Base (RGB)", 2D) = "white" {}
		//模糊图像时的混合系数
		_BlurSize ("Blur Size", Float) = 1.0
	}

	SubShader 
	{
		CGINCLUDE
		
		#include "UnityCG.cginc"
		
		sampler2D _MainTex;
		//主纹理纹素大小，主要是用来对深度纹理的采样坐标进行平台差异化处理
		half4 _MainTex_TexelSize;
		//Unity传递的深度纹理
		sampler2D _CameraDepthTexture;
		//这两个矩阵是后处理脚本传递过来的
		float4x4 _CurViewProjectionInverseMatrix;
		float4x4 _PreviousViewProjectionMatrix;
		half _BlurSize;
		  
		struct v2f {
			float4 pos : SV_POSITION;
			half2 uv: TEXCOORD0;
			//对深度纹理采样的纹理坐标变量
			half2 uv_depth : TEXCOORD1;
		};
		  
		v2f vert(appdata_img v) {
			v2f o;
			o.pos = UnityObjectToClipPos(v.vertex);
			o.uv = v.texcoord;
			o.uv_depth = v.texcoord;

			#if UNITY_UV_STARTS_AT_TOP
			if (_MainTex_TexelSize.y < 0)
				o.uv_depth.y = 1 - o.uv_depth.y;
			#endif

			return o;
		}

		fixed4 frag(v2f i) : SV_Target
		{
			//对深度图采样得到深度值
			float depth = SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, i.uv_depth);
			//depth是NDC下的坐标映射来的，这里把深度值重新映射会NDC坐标，得到像素的NDC坐标H，使用原映射函数的反函数d*2-1进行映射
			float4 H = float4(i.uv.x * 2 - 1, i.uv.y * 2 - 1, depth * 2 - 1, 1);
			//使用当前帧的视角*投影矩阵的逆矩阵进行变换
			float4 D = mul(_CurViewProjectionInverseMatrix, H);
			//把结果值除以它的w分量来得到世界空间下的坐标
			float4 worldPos = D / D.w;

			float4 curPos = H;
			//使用前一帧的视角*投影矩阵对它进行变换，得到前一帧在NDC下的坐标
			float4 prePos = mul(_PreviousViewProjectionMatrix, worldPos);
			prePos /= prePos.w;

			//计算前一帧和当前帧在屏幕空间下的位置差，得到像素的速度
			float2 velocity = (curPos.xy - prePos.xy) / 2.0f;
			//得到像素的速度之后，使用速度值对它的邻域像素进行采样，相加后取平均值得到一个模糊的效果，使用_BlurSize来控制采样距离
			float2 uv = i.uv;
			float4 color = tex2D(_MainTex, uv);
			uv += velocity * _BlurSize;

			for	(int it = 1; it < 3; it++, uv += velocity * _BlurSize)
			{
				float4 curColor = tex2D(_MainTex, uv);
				color += curColor;
			}
			color /= 3;

			return fixed4(color.rgb, 1.0);
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
