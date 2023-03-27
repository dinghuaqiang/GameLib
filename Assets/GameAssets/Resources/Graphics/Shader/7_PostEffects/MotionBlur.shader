/**
    后处理效果
	运动模糊
*/
Shader "GameLib/PostEffects/MotionBlur"
{
    Properties {
		//输入的RenterTexture
		_MainTex ("Base (RGB)", 2D) = "white" {}
		//混合图像时的混合系数
		_BlurAmount ("Blur Amount", Float) = 1.0
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
		float _BlurAmount;
		  
		struct v2f {
			float4 pos : SV_POSITION;
			half2 uv: TEXCOORD0;
		};
		  
		v2f vert(appdata_img v) {
			v2f o;
			o.pos = UnityObjectToClipPos(v.vertex);
			o.uv = v.texcoord;
			return o;
		}

		//更新渲染纹理的RGB通道
		fixed4 fragRGB(v2f i) : SV_Target
		{
			//对当前图像采样，把alpha通道的值设为_BlurAmount，后面混合的时候可以使用它的透明通道进行混合。
			return fixed4(tex2D(_MainTex, i.uv).rgb, _BlurAmount);
		}

		//更新渲染纹理的Alpha通道
		fixed4 fragAlpha(v2f i) : SV_Target
		{
			return tex2D(_MainTex, i.uv);
		}
		ENDCG
		
		//定义4个Pass
		ZTest Always Cull Off ZWrite Off
		
		Pass {
			Blend SrcAlpha OneMinusSrcAlpha
			//输出颜色中只有RGB通道会被写入
			ColorMask RGB

			CGPROGRAM
			  
			#pragma vertex vert  
			#pragma fragment fragRGB
			  
			ENDCG  
		}
		
		Pass {
			Blend One Zero
			//输出颜色中只有A通道会被写入
			ColorMask A

			CGPROGRAM  
			
			#pragma vertex vert  
			#pragma fragment fragAlpha
			
			ENDCG
		}
	} 
	FallBack Off
}
