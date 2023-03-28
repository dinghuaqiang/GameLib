/**
    卡通渲染风格
	描边
*/
Shader "GameLib/Cartoon/ToonShading"
{
    Properties {
		//输入的RenterTexture
		_MainTex ("Main Tex", 2D) = "white" {}
		_Color ("Color Tint", Color) = (1, 1, 1, 1)
		//控制漫反射色调的渐变纹理
		_RampTex ("Ramp Tex", 2D) = "white" {}
		//控制轮廓线宽度
		_Outline ("Outline", Range(0, 1)) = 0.1
		//轮廓线颜色
		_OutlineColor ("Outline Color", Color) = (0, 0, 0, 1)
		//高光反射颜色
		_Specular ("Specular", Color) = (1, 1, 1, 1)
		//控制计算高光反射时使用的阈值
		_SpecularScale ("SpecularScale", Range(0, 0.1)) = 0.01
	}

	SubShader 
	{
		Tags { "RenderType"="Opaque" "Queue"="Geometry"}

		//渲染轮廓线的Pass
		Pass
		{
			//取个名字，其他地方可能会用到描边的Pass
			NAME "OUTLINE"
			//剔除正面的三角面片，只渲染背面
			Cull Front

			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			float _Outline;
			fixed4 _OutlineColor;

			struct a2v
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float4 pos : SV_POSITION;
			};

			v2f vert(a2v v)
			{
				v2f o;
				//把顶点和法线变换到视角空间下，这是为了让描边可以在观察空间达到最好的效果。
				float4 pos = mul(UNITY_MATRIX_MV, v.vertex);
				float3 normal = mul((float3x3)UNITY_MATRIX_IT_MV, v.normal);
				//设置法线的z值
				normal.z = -0.5;
				//归一化后再将顶点沿其方向扩张，得到扩张后的顶点坐标。对法线的处理是为了尽可能避免背面扩张后的顶点挡住正面的面片。
				pos += float4(normalize(normal), 0) * _Outline;
				//把顶点从视角空间变换到裁剪空间
				o.pos = mul(UNITY_MATRIX_P, pos);

				return o;
			}

			float4 frag(v2f i) : SV_Target
			{
				//用轮廓线颜色渲染整个背面
				return float4(_OutlineColor.rgb, 1);
			}

			ENDCG
		}

		//渲染正面，光照模型所在的Pass
		Pass
		{
			Tags { "LightModel" = "ForwardBase" }
			//剔除背面
			Cull Back

			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fwdbase

			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "AutoLight.cginc"
			#include "UnityShaderVariables.cginc"
			
			fixed4 _Color;
			sampler2D _MainTex;
			float4 _MainTex_ST;
			sampler2D _Ramp;
			fixed4 _Specular;
			fixed _SpecularScale;
			
			struct a2v {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 texcoord : TEXCOORD0;
				//float4 tangent : TANGENT;
			}; 
		
			struct v2f {
				float4 pos : POSITION;
				float2 uv : TEXCOORD0;
				float3 worldNormal : TEXCOORD1;
				float3 worldPos : TEXCOORD2;
				SHADOW_COORDS(3)
			};

			v2f vert(a2v v)
			{
				v2f o;
				//转换顶点 uv 法线 世界坐标
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
				o.worldNormal = mul(v.normal, (float3x3)unity_WorldToObject);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				//处理阴影
				TRANSFER_SHADOW(o);

				return o;
			}

			float4 frag(v2f i) : SV_Target 
			{ 
				//计算光照模型中需要的各个方向矢量，都进行归一化处理
				fixed3 worldNormal   = normalize(i.worldNormal);
				fixed3 worldLightDir = normalize(UnityWorldSpaceLightDir(i.worldPos));
				fixed3 worldViewDir  = normalize(UnityWorldSpaceViewDir(i.worldPos));
				fixed3 worldHalfDir  = normalize(worldLightDir + worldViewDir);
				
				//计算材质反射率
				fixed4 c = tex2D (_MainTex, i.uv);
				fixed3 albedo = c.rgb * _Color.rgb;
				//计算环境光
				fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz * albedo;
				//计算当前世界坐标下的阴影值
				UNITY_LIGHT_ATTENUATION(atten, i, i.worldPos);
				//半兰伯特漫反射系数和阴影值相乘得到最终的漫反射系数
				fixed diff =  dot(worldNormal, worldLightDir);
				diff = (diff * 0.5 + 0.5) * atten;
				//得到漫反射光照
				fixed3 diffuse = _LightColor0.rgb * albedo * tex2D(_Ramp, float2(diff, diff)).rgb;
				//高光反射
				fixed spec = dot(worldNormal, worldHalfDir);
				//获得邻域像素之间的近似导数值,对高光区域的边界进行抗锯齿处理
				fixed w = fwidth(spec) * 2.0;
				//step函数实现和阈值比较，第一个参数是参考值，第二参数是待比较值，如果第二个参数大于等于第一个参数就返回1，否则0
				//smoothstep函数，w是一个很小的值，当spec + _SpecularScale - 1小于-w时返回0，大于w时返回1，否则在0-1之间进行插值。实现抗锯齿的目的
				fixed3 specular = _Specular.rgb * lerp(0, 1, smoothstep(-w, w, spec + _SpecularScale - 1)) * step(0.0001, _SpecularScale);
				
				return fixed4(ambient + diffuse + specular, 1.0);
			}

			ENDCG
		}
	} 
	FallBack "Diffuse"
}
