// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

/**
    噪音图应用学习
	消融效果
*/
Shader "GameLib/Noise/Dissolve"
{
    Properties {
		//控制消融程度 值为0时，物体为正常效果，为1时完全消融
		_BurnAmount ("Burn Amount", Range(0, 1)) = 0.0
		//控制模拟烧焦效果时的线宽，值越大，火焰边缘的蔓延范围越广
		_LineWidth ("Burn Line Width", Range(0, 0.2)) = 0.1
		//漫反射纹理
		_MainTex ("Base (RGB)", 2D) = "white" {}
		//法线纹理
		_BumpMap ("Normal Map", 2D) = "bump" {}
		//火焰边缘的两种颜色值
		_BurnFirstColor("Burn First Color", Color) = (1, 0, 0, 1)
		_BurnSecondColor("Burn Second Color", Color) = (1, 0, 0, 1)
		//噪声纹理
		_BurnMap("Burn Map", 2D) = "white"{}
	}

	SubShader 
	{
		Tags { "RenderType"="Opaque" "Queue"="Geometry"}

		//消融的Pass
		Pass {
			Tags { "LightMode"="ForwardBase" }

			//关闭剔除，让两面都渲染，不然消融之后就看到模型内部了
			Cull Off

			CGPROGRAM
			
			#pragma vertex vert
			#pragma fragment frag 
			#pragma multi_compile_fwdbase
			
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "AutoLight.cginc"
			
			fixed _BurnAmount;
			fixed _LineWidth;
			sampler2D _MainTex;
			sampler2D _BumpMap;
			fixed4 _BurnFirstColor;
			fixed4 _BurnSecondColor;
			sampler2D _BurnMap;
			
			float4 _MainTex_ST;
			float4 _BumpMap_ST;
			float4 _BurnMap_ST;
			
			struct a2v {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 tangent : TANGENT;
				float4 texcoord : TEXCOORD0;
			};
			
			struct v2f {
				float4 pos : SV_POSITION;
				float2 uvMainTex : TEXCOORD0;
				float2 uvBumpMap : TEXCOORD1;
				float2 uvBurnMap : TEXCOORD2;
				float3 lightDir : TEXCOORD3;
				float3 worldPos : TEXCOORD4;
				SHADOW_COORDS(5)
			};
			
			v2f vert(a2v v) 
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				//计算三张纹理对应的纹理坐标
				o.uvMainTex = TRANSFORM_TEX(v.texcoord, _MainTex);
				o.uvBumpMap = TRANSFORM_TEX(v.texcoord, _BumpMap);
				o.uvBurnMap = TRANSFORM_TEX(v.texcoord, _BurnMap);
				//把光源方向从模型空间变换到切线空间
				/**
					TANGENT_SPACE_ROTATION 宏 相当于嵌入如下两行代码：
					float3 binormal = cross( v.normal, v.tangent.xyz ) * v.tangent.w;
					float3x3 rotation = float3x3( v.tangent.xyz, binormal, v.normal );
					也就是构造出 tangent space 的坐标系， 定义转换world space的向量到tangent space的rotation 矩阵。
					TANGENT_SPACE_ROTATION这行代码之后，就可以用rotation这个代表从世界坐标到切线空间的矩阵了。
				*/
				TANGENT_SPACE_ROTATION;
  				o.lightDir = mul(rotation, ObjSpaceLightDir(v.vertex)).xyz;
  				//计算世界空间下的顶点位置
  				o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
  				//计算世界空间下阴影纹理的采样坐标
  				TRANSFER_SHADOW(o);
				return o;
			}
			
			fixed4 frag(v2f i) : SV_Target 
			{			
				//对噪声纹理采样，并将采样结果和用于控制消融程度的_BurnAmount属性相减传递给clip函数
				fixed3 burn = tex2D(_BurnMap, i.uvBurnMap).rgb;
				//结果小于0，该像素将被剔除，从而不会显示到屏幕上
				clip(burn.r - _BurnAmount);
				//通过clip测试的就进行正常的光照计算
				float3 tangentLightDir = normalize(i.lightDir);
				fixed3 tangentNormal = UnpackNormal(tex2D(_BumpMap, i.uvBumpMap));
				//材质的反射率
				fixed3 albedo = tex2D(_MainTex, i.uvMainTex).rgb;
				//环境光照
				fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz * albedo;
				//漫反射光照
				fixed3 diffuse = _LightColor0.rgb * albedo * max(0, dot(tangentNormal, tangentLightDir));
				//计算烧焦颜色
				//想要在_LineWidth宽度范围内模拟一个烧焦的颜色变化，这里计算混合系数t,当t为1时，表明该像素位于消融的边界处,t=0，表明该像素为正常的模型颜色，而中间的插值则表示需要模拟一个烧焦效果。
				fixed t = 1 - smoothstep(0.0, _LineWidth, burn.r - _BurnAmount);
				//使用t来混合两种火焰颜色
				fixed3 burnColor = lerp(_BurnFirstColor, _BurnSecondColor, t);
				//使用pow函数让效果更接近烧焦的痕迹
				burnColor = pow(burnColor, 5);
				//处理光照衰减
				UNITY_LIGHT_ATTENUATION(atten, i, i.worldPos);
				//用step函数保证当_BurnAmount为0时不显示任何消融效果
				fixed3 finalColor = lerp(ambient + diffuse * atten, burnColor, t * step(0.0001, _BurnAmount));
				
				return fixed4(finalColor, 1);
			}
			
			ENDCG
		}

		/**
			投射阴影的Pass
			因为消融有用到clip，使用透明度测试的物体阴影需要特别处理。
			这里主要是让消融之后的阴影也跟着模型变化
			可以注释了之后看看效果。
		*/
		Pass 
		{
			Tags { "LightMode" = "ShadowCaster" }
			
			CGPROGRAM
			
			#pragma vertex vert
			#pragma fragment frag
			//使用"LightMode" = "ShadowCaster"需要使用的编译指令
			#pragma multi_compile_shadowcaster
			
			#include "UnityCG.cginc"
			
			fixed _BurnAmount;
			sampler2D _BurnMap;
			float4 _BurnMap_ST;
			
			struct v2f {
				V2F_SHADOW_CASTER;
				float2 uvBurnMap : TEXCOORD1;
			};
			
			v2f vert(appdata_base v) 
			{
				v2f o;
				//https://blog.csdn.net/yanyangxu01/article/details/81987064
				TRANSFER_SHADOW_CASTER_NORMALOFFSET(o)
				//计算噪声纹理的采样坐标
				o.uvBurnMap = TRANSFORM_TEX(v.texcoord, _BurnMap);
				return o;
			}
			
			fixed4 frag(v2f i) : SV_Target 
			{
				fixed3 burn = tex2D(_BurnMap, i.uvBurnMap).rgb;
				clip(burn.r - _BurnAmount);
				SHADOW_CASTER_FRAGMENT(i)
			}
			ENDCG
		}
	} 
	FallBack "Diffuse"
}
