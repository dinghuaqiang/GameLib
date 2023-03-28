/**
    卡通渲染风格
	素描效果
*/
Shader "GameLib/Cartoon/Sketch"
{
    Properties {
		//纹理的平铺系数，值越大，模型上的素描线条越密
		_TileFactor ("Tile Factor", Float) = 1
		//控制模型的颜色
		_Color ("Color Tint", Color) = (1, 1, 1, 1)
		//控制轮廓线宽度
		_Outline ("Outline", Range(0, 1)) = 0.1
		//渲染时使用的素描纹理
		_Hatch0 ("Hatch 0", 2D) = "white" {}
		_Hatch1 ("Hatch 1", 2D) = "white" {}
		_Hatch2 ("Hatch 2", 2D) = "white" {}
		_Hatch3 ("Hatch 3", 2D) = "white" {}
		_Hatch4 ("Hatch 4", 2D) = "white" {}
		_Hatch5 ("Hatch 5", 2D) = "white" {}
	}

	SubShader 
	{
		Tags { "RenderType"="Opaque" "Queue"="Geometry"}

		//调用其他Shader的渲染轮廓线的Pass
		UsePass "GameLib/Cartoon/ToonShading/OUTLINE"

		//渲染正面，光照模型所在的Pass
		Pass {
			Tags { "LightMode"="ForwardBase" }

			CGPROGRAM
			
			#pragma vertex vert
			#pragma fragment frag 
			#pragma multi_compile_fwdbase
			
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "AutoLight.cginc"
			#include "UnityShaderVariables.cginc"
			
			fixed4 _Color;
			float _TileFactor;
			sampler2D _Hatch0;
			sampler2D _Hatch1;
			sampler2D _Hatch2;
			sampler2D _Hatch3;
			sampler2D _Hatch4;
			sampler2D _Hatch5;
			
			struct a2v 
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL; 
				float2 texcoord : TEXCOORD0; 
			};
			
			struct v2f 
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
				//把6个混合权重存储在两个fixed3类型的变量中
				fixed3 hatchWeights0 : TEXCOORD1;
				fixed3 hatchWeights1 : TEXCOORD2;
				//添加阴影效果会用到
				float3 worldPos : TEXCOORD3;
				//声明阴影纹理的采样坐标
				SHADOW_COORDS(4)
			};
			
			v2f vert(a2v v) 
			{
				v2f o;
				//对顶点进行基本的坐标变换。
				o.pos = UnityObjectToClipPos(v.vertex);
				//得到纹理的采样坐标
				o.uv = v.texcoord.xy * _TileFactor;
				//计算逐顶点光照，使用世界空间下的光照方向和法线方向求点积，得到漫反射系数diff
				fixed3 worldLightDir = normalize(WorldSpaceLightDir(v.vertex));
				fixed3 worldNormal = UnityObjectToWorldNormal(v.normal);
				fixed diff = max(0, dot(worldLightDir, worldNormal));
				
				//初始化6张图的权重
				o.hatchWeights0 = fixed3(0, 0, 0);
				o.hatchWeights1 = fixed3(0, 0, 0);

				//把漫反射系数缩放到0-7的范围
				float hatchFactor = diff * 7.0;
				
				//划分为7个子区间，判断hatchFactor所在区间来计算对应的纹理混合权重
				if (hatchFactor > 6.0) {
					// Pure white, do nothing
				} else if (hatchFactor > 5.0) {
					o.hatchWeights0.x = hatchFactor - 5.0;
				} else if (hatchFactor > 4.0) {
					o.hatchWeights0.x = hatchFactor - 4.0;
					o.hatchWeights0.y = 1.0 - o.hatchWeights0.x;
				} else if (hatchFactor > 3.0) {
					o.hatchWeights0.y = hatchFactor - 3.0;
					o.hatchWeights0.z = 1.0 - o.hatchWeights0.y;
				} else if (hatchFactor > 2.0) {
					o.hatchWeights0.z = hatchFactor - 2.0;
					o.hatchWeights1.x = 1.0 - o.hatchWeights0.z;
				} else if (hatchFactor > 1.0) {
					o.hatchWeights1.x = hatchFactor - 1.0;
					o.hatchWeights1.y = 1.0 - o.hatchWeights1.x;
				} else {
					o.hatchWeights1.y = hatchFactor;
					o.hatchWeights1.z = 1.0 - o.hatchWeights1.y;
				}
				//计算顶点的世界坐标
				o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				//计算阴影纹理的采样坐标
				TRANSFER_SHADOW(o);
				
				return o; 
			}
			
			fixed4 frag(v2f i) : SV_Target 
			{			
				//对6张纹理进行采样，并和它们对应的权重值相乘得到每张纹理的采样颜色。
				fixed4 hatchTex0 = tex2D(_Hatch0, i.uv) * i.hatchWeights0.x;
				fixed4 hatchTex1 = tex2D(_Hatch1, i.uv) * i.hatchWeights0.y;
				fixed4 hatchTex2 = tex2D(_Hatch2, i.uv) * i.hatchWeights0.z;
				fixed4 hatchTex3 = tex2D(_Hatch3, i.uv) * i.hatchWeights1.x;
				fixed4 hatchTex4 = tex2D(_Hatch4, i.uv) * i.hatchWeights1.y;
				fixed4 hatchTex5 = tex2D(_Hatch5, i.uv) * i.hatchWeights1.z;
				//计算纯白色在渲染中的贡献度，通过1-所有6张纹理的权重来得到。
				fixed4 whiteColor = fixed4(1, 1, 1, 1) * (1 - i.hatchWeights0.x - i.hatchWeights0.y - i.hatchWeights0.z -  i.hatchWeights1.x - i.hatchWeights1.y - i.hatchWeights1.z);
				//混合各个颜色值，然后和阴影值atteny，模型颜色相乘得到最终的结果
				fixed4 hatchColor = hatchTex0 + hatchTex1 + hatchTex2 + hatchTex3 + hatchTex4 + hatchTex5 + whiteColor;
				UNITY_LIGHT_ATTENUATION(atten, i, i.worldPos);
				return fixed4(hatchColor.rgb * _Color.rgb * atten, 1.0);
			}
			
			ENDCG
		}
	} 
	FallBack "Diffuse"
}
