/**
    后处理效果
	Bloom效果，边缘提亮
*/
Shader "GameLib/PostEffects/Bloom"
{
    Properties {
		//输入的RenterTexture
		_MainTex ("Base (RGB)", 2D) = "white" {}
		//高斯模糊后的较亮区域
		_Bloom ("Bloom (RGB)", 2D) = "black" {}
		//提取较亮区域使用的阈值
		_LuminanceThreshold ("Luminance Threshold", Float) = 0.5
		//控制不同迭代之间高斯模糊的模糊区域范围
		_BlurSize ("Blur Size", Float) = 1.0
	}
	SubShader {
		/**
			unity会把 CGINCLUDE 和 ENDCG 之间的代码插入到每一个pass中，已达到声明一遍，多次使用的目的。
			（参考）例如，可以在 CGINCLUDE 和 ENDCG 之间 定义多个 顶点和片段方法，在pass里只要写明 #pragma vertex 顶点方法名 #pragma fragment 片段方法名 即可，而不用写具体的函数实现
			链接：https://www.jianshu.com/p/2d4b4ae57c12
			https://www.cnblogs.com/fengxing999/p/10012256.html
		*/
		CGINCLUDE
		
		#include "UnityCG.cginc"
		
		sampler2D _MainTex;  
		//得到相邻像素的纹理坐标偏移量
		half4 _MainTex_TexelSize;
		sampler2D _Bloom;
		float _LuminanceThreshold;
		float _BlurSize;
		  
		struct v2f {
			float4 pos : SV_POSITION;
			half2 uv: TEXCOORD0;
		};
		  
		v2f vertExtractBright(appdata_img v) {
			v2f o;
			o.pos = UnityObjectToClipPos(v.vertex);
			o.uv = v.texcoord;
			return o;
		}

		fixed luminance(fixed4 color)
		{
			return 0.2125 * color.r + 0.7154 * color.g + 0.0721 * color.b;
		}

		fixed4 fragExtractBright(v2f i) : SV_Target
		{
			fixed4 color = tex2D(_MainTex, i.uv);
			//将采样得到的亮度值减去阈值，并把结果接取到0-1范围内
			fixed val = clamp(luminance(color) - _LuminanceThreshold, 0.0, 1.0);
			//得到提取后的亮部区域
			return color * val;
		}
		
		struct v2fBloom
		{
			float4 pos : SV_POSITION;
			half4 uv : TEXCOORD0;
		};

		v2fBloom vertBloom(appdata_img v)
		{
			v2fBloom o;

			o.pos = UnityObjectToClipPos(v.vertex);
			//xy分量对应_MainTex原图像的纹理坐标
			o.uv.xy = v.texcoord;
			//zw分量是Bloom，模糊后的较亮区域的纹理坐标
			o.uv.zw = v.texcoord;

			#if UNITY_UV_STARTS_AT_TOP
			if (_MainTex_TexelSize.y < 0.0)
				o.uv.w = 1.0 - o.uv.w;
			#endif

			return o;
		}

		fixed4 fragBloom(v2fBloom i) : SV_Target
		{
			//把两张纹理采样结果相加进行混合
			return tex2D(_MainTex, i.uv.xy) + tex2D(_Bloom, i.uv.zw);
		}
		    
		ENDCG
		
		//定义4个Pass
		ZTest Always Cull Off ZWrite Off
		
		Pass {
			CGPROGRAM
			  
			#pragma vertex vertExtractBright  
			#pragma fragment fragExtractBright
			  
			ENDCG  
		}

		//使用高斯模糊的Pass，Unity内部会把所有的Pass的Name转换成大写，使用UsePass的时候要注意PassName的书写
		UsePass "GameLib/PostEffects/GaussianBlur/GAUSSIAN_BLUR_VERTICAL"
		
		UsePass "GameLib/PostEffects/GaussianBlur/GAUSSIAN_BLUR_HORIZONTAL"
		
		Pass {
			CGPROGRAM  
			
			#pragma vertex vertBloom  
			#pragma fragment fragBloom
			
			ENDCG
		}
	} 
	FallBack Off
}
