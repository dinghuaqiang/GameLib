/**
    噪音图应用学习
	水面波动的效果
*/
Shader "GameLib/Noise/WaterWave"
{
    Properties {
		//水面波纹材质纹理
		_MainTex ("Base (RGB)", 2D) = "white" {}
		//控制水面颜色
		_Color ("Water Color", Color) = (0, 0.15, 0.115, 1)
		//噪声图生成的法线纹理
		_WaveMap ("Wave Map", 2D) = "bump" {}
		//模拟反射的立方体纹理
		_CubeMap ("Enviroment CubeMap", Cube) = "_Skybox" {}
		//控制模拟折射时图像的扭曲程度 Distortion扭曲
		_Distortion ("Distortion", Range(0, 100)) = 10
		//控制法线纹理在X和Y方向上的平移速度
		_WaveXSpeed ("Wave Horizontal Speed", Range(-0.1, 0.1)) = 0.01
		_WaveYSpeed ("Wave Vertical Speed", Range(-0.1, 0.1)) = 0.01
	}

	SubShader 
	{
		/**
			https://blog.csdn.net/u013477973/article/details/80607989
			RenderType标签通常被用于着色器替换功能

			Queue渲染队列，用来指定当前shader作用的对象的渲染顺序：
			Unity中的几种内置的渲染队列，按照渲染顺序，从先到后进行排序，队列数越小的，越先渲染，队列数越大的，越后渲染。
			Background（1000） 最早被渲染的物体的队列。
			Geometry （2000） 不透明物体的渲染队列。大多数物体都应该使用该队列进行渲染，也是Unity Shader中默认的渲染队列。
			AlphaTest （2450） 有透明通道，需要进行Alpha Test的物体的队列定义在这个队列，比在Geomerty中更有效。
			Transparent（3000） 半透物体的渲染队列。一般是不写深度的物体，需要Alpha Blend的在该队列渲染。
			Overlay （4000） 最后被渲染的物体的队列，一般是覆盖效果，比如镜头光晕，屏幕贴片之类的
		*/
		//把渲染队列设置为透明队列
		//设置RenderType是为了在使用着色器替换时，该物体可以在需要时被正确渲染。
		Tags { "RenderType"="Opaque" "Queue"="Transparent"}

		//抓取屏幕图像存储在_RefractionTex纹理中
		GrabPass { "_RefractionTex" }

		//水面渲染的Pass
		Pass {
			Tags { "LightMode"="ForwardBase" }

			Cull Off

			CGPROGRAM
			
			#pragma vertex vert
			#pragma fragment frag 
			#pragma multi_compile_fwdbase
			
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "AutoLight.cginc"

			float4 _Color;
			sampler2D _MainTex;
			float4 _MainTex_ST;
			sampler2D _WaveMap;
			float4 _WaveMap_ST;
			samplerCUBE _CubeMap;
			fixed _WaveXSpeed;
			fixed _WaveYSpeed;
			float _Distortion;
			//抓取屏幕获得的图像
			sampler2D _RefractionTex;
			//抓取的图像的纹素(256*512纹理的纹素就是1/256, 1/512),在对屏幕图像坐标采样进行偏移时要用这个变量
			float4 _RefractionTex_TexelSize;
			
			struct a2v {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 tangent : TANGENT;
				float4 texcoord : TEXCOORD0;
			};
			
			struct v2f {
				float4 pos : SV_POSITION;
				float4 srcPos : TEXCOORD0;
				float4 uv : TEXCOORD1;
				float4 T2W0 : TEXCOORD2;
				float4 T2W1 : TEXCOORD3;
				float4 T2W2 : TEXCOORD4;
			};
			
			v2f vert(a2v v) 
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				//获取抓取的屏幕图像的采样坐标
				o.srcPos = ComputeGrabScreenPos(o.pos);
				//对两张图采样，放在两个分量中
				o.uv.xy = TRANSFORM_TEX(v.texcoord, _MainTex);
				o.uv.zw = TRANSFORM_TEX(v.texcoord, _WaveMap);

				//因为需要在片元着色器中把法线方向从切线空间变换到世界空间，然后对Cubmap进行采样，所以这里
				//需要计算顶点从切线空间到世界空间的TBN变换矩阵，这里TBN矩阵的w值被用来存储世界空间下的顶点坐标了。

				//转换顶点和法线到世界空间，后面和切线以及副切线构建TBN矩阵
				float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				fixed3 worldNormal = UnityObjectToWorldDir(v.normal);
				//计算切线，为了构建TBN矩阵
				fixed3 worldTangent = UnityObjectToWorldDir(v.tangent.xyz);
				//计算副切线，为了构建TBN矩阵进行坐标转换
				fixed3 worldBinormal = cross(worldNormal, worldTangent) * v.tangent.w;
				//构建到世界空间的TBN转换矩阵
				o.T2W0 = float4(worldTangent.x, worldBinormal.x, worldNormal.x, worldPos.x);
				o.T2W1 = float4(worldTangent.y, worldBinormal.y, worldNormal.y, worldPos.y);
				o.T2W2 = float4(worldTangent.z, worldBinormal.z, worldNormal.z, worldPos.z);

				return o;
			}
			
			fixed4 frag(v2f i) : SV_Target 
			{			
				//取出从顶点着色器存储的世界空间的顶点坐标
				float3 worldPos = float3(i.T2W0.w, i.T2W1.w, i.T2W2.w);
				//取世界空间的视角方向
				fixed3 viewDir = normalize(UnityWorldSpaceViewDir(worldPos));
				//计算水波的速度,计算法线纹理的当前偏移量
				float2 speed = _Time.y * float2(_WaveXSpeed, _WaveYSpeed);
				
				//采样法线图，得到在切线空间中的法线方向，法线图采样出来的法向方向都是切线空间中
				fixed3 tangentNormal1 = UnpackNormal(tex2D(_WaveMap, i.uv.zw + speed)).rgb;
				fixed3 tangentNormal2 = UnpackNormal(tex2D(_WaveMap, i.uv.zw - speed)).rgb;
				fixed3 tangentNormal = normalize(tangentNormal1 + tangentNormal2);
				/**
					使用法线和扭曲系数以及纹素来对屏幕图像的采样坐标进行偏移来模拟折射效果
					这里用切线空间的法线方向进行偏移，是因为切线空间下的法线可以反映顶点局部空间下的法线方向。
				*/
				float2 offset = tangentNormal.xy * _Distortion * _RefractionTex_TexelSize.xy;
				//这里在计算偏移后的屏幕坐标时，把偏移量和屏幕坐标的z分量相乘是为了模拟深度越大、折射程度越大的效果。
				i.srcPos.xy = offset * i.srcPos.z + i.srcPos.xy;
				//对偏移后的屏幕坐标进行透视除法，然后使用结果对抓取的屏幕图像进行采样，得到模拟的折射颜色。
				fixed3 refrColor = tex2D(_RefractionTex, i.srcPos.xy / i.srcPos.w).rgb;
				//把法线方向从切线空间变换到世界空间下
				fixed3 worldNormal = normalize(half3(dot(i.T2W0.xyz, tangentNormal), dot(i.T2W1.xyz, tangentNormal), dot(i.T2W2.xyz, tangentNormal)));
				//采样主纹理的颜色
				fixed4 texColor = tex2D(_MainTex, i.uv.xy + speed);
				//得到视角方向相对于法线方向的反射方向
				fixed3 reflDir = reflect(-viewDir, worldNormal);
				//使用反射方向对Cubemap进行采样，把结果和主纹理颜色相乘后得到反射颜色
				fixed3 reflCol = texCUBE(_CubeMap, reflDir).rgb * texColor.rgb * _Color.rgb;

				//使用菲涅尔公式计算菲涅尔系数
				fixed fresnel = pow(1 - saturate(dot(viewDir, worldNormal)), 4);
				//使用菲涅尔系数混合折射和反射颜色
				fixed3 finalColor = reflCol * fresnel + refrColor * (1 - fresnel);

				return fixed4(finalColor, 1);
			}
			
			ENDCG
		}
	} 
	FallBack "Diffuse"
}
