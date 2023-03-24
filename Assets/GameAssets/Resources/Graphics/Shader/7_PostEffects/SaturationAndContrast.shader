/**
    后处理效果，控制亮度 饱和度和对比度
*/
Shader "GameLib/PostEffects/SaturationAndContrast"
{
    Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		//亮度
		_Brightness ("Brightness", Float) = 1
		//饱和度
		_Saturation("Saturation", Float) = 1
		//对比度
		_Contrast("Contrast", Float) = 1
	}
	SubShader {
		
		Pass {
			/**
				屏幕后处理实际上是在场景中绘制了一个与屏幕同宽高的四边形面片，为了防止它对其他物体产生影响，这里设置相关的渲染状态。
				关闭深度写入，防止"挡住"在它后面被渲染的物体。（如果当前的OnRenderImage函数在所有不透明的Pass执行完毕后立即被调用，不关闭深度写入就会影响后面透明Pass的渲染）
				这些状态是屏幕后处理的Shader的标配。
			*/
			ZTest Always Cull Off ZWrite Off
			
			CGPROGRAM  
			#pragma vertex vert 
			#pragma fragment frag
			
			#include "UnityCG.cginc" 
			
			sampler2D _MainTex;
			half _Brightness;
			half _Saturation;
			half _Contrast;
			
			struct v2f {
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
			};
			
			v2f vert(appdata_img v) {
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = v.texcoord;
				return o;
			}
			
			fixed4 frag(v2f i) : SV_Target {
				//获取原屏幕图像的采样结果
				fixed4 renderTex = tex2D(_MainTex, i.uv);
				//调整亮度
				fixed3 finalColor = renderTex.rgb * _Brightness;
				//计算像素对应的亮度值，通过对每个颜色分量乘以一个特定的系数再相加
				fixed luminance = 0.2125 * renderTex.r + 0.7154 * renderTex.g + 0.0721 * renderTex.b;
				//创建一个饱和度为0的颜色值
				fixed3 luminanceColor = fixed3(luminance, luminance, luminance);
				//使用传递进来的值和前面得到的颜色进行插值
				finalColor = lerp(luminanceColor, finalColor, _Saturation);
				//创建一个对比度为0的颜色值（各个分量都是0.5）
				fixed3 avgColor = fixed3(0.5, 0.5, 0.5);
				//使用之前得到的颜色和传进来的值进行插值调色
				finalColor = lerp(avgColor, finalColor, _Contrast);
				return fixed4(finalColor, renderTex.a);  
			} 
			
			ENDCG
		}
	}
	FallBack Off
}
