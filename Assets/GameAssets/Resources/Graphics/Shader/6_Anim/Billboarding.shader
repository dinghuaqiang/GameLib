// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

/**
    广告牌效果
	需要三个基向量，通常就是 表面法线，指向上的方向，指向右的方向。
	还需要指定一个锚点，这个锚点在旋转过程中是固定不变的，用来确定多边形在空间中的位置。
	
	假设法线方向是固定的，根据初始的表面法线和向上的方向来计算出目标方向的右方向(叉积操作)
		right = up * normal
	对其归一化后，再由法线方向和向右的方向计算出正交的向上方向。
		up = normal * right
*/
Shader "GameLib/Anim/Billboarding"
{
    Properties {
		//广告牌显示的透明纹理
		_MainTex ("Main Tex", 2D) = "white" {}
		//控制整体的颜色
		_Color ("Color Tint", Color) = (1, 1, 1, 1)
		//用于调整是固定法线还是固定指向向上的方向，约束垂直方向的程度。
		_VerticalBillboarding ("Vertical Restraints", Range(0, 1)) = 1
	}
	SubShader {
		// Need to disable batching because of the vertex animation
		Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "DisableBatching"="True"}
		
		Pass {
			Tags { "LightMode"="ForwardBase" }
			
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			Cull Off
			
			CGPROGRAM  
			#pragma vertex vert 
			#pragma fragment frag
			
			#include "UnityCG.cginc" 
			
			sampler2D _MainTex;
			float4 _MainTex_ST;
			fixed4 _Color;
			float _VerticalBillboarding;
			
			struct a2v {
				float4 vertex : POSITION;
				float4 texcoord : TEXCOORD0;
			};
			
			struct v2f {
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
			};
			
			v2f vert(a2v v) {
				v2f o;
				//使用模型空间的原点作为广告牌的锚点
				float3 center = float3(0, 0, 0);
				//利用内置变量获取模型空间下的视角位置
				float3 viewer = mul(unity_WorldToObject, float4(_WorldSpaceCameraPos, 1));
				//计算三个正交矢量
				float3 normalDir = viewer - center;
				/**
					当_VerticalBillboarding为1时，意味着法线方向固定为视角方向。
					当_VerticalBillboarding为0时，意味着向上方向固定为(0,1,0)
					最后对计算得到的法线方向进行归一化得到单位矢量
				*/
				normalDir.y = normalDir.y * _VerticalBillboarding;
				normalDir = normalize(normalDir);

				//得到粗略的向上的方向。为了防止法线方向和向上方向平行（如果平行，那么叉积得到的结果会是错误的）
				float3 upDir = abs(normalDir.y) > 0.999 ? float3(0, 0, 1) : float3(0, 1, 0);
				//根据法线方向和粗略的向上方向得到向右的方向，并对结果归一化
				float3 rightDir = normalize(cross(upDir, normalDir));
				//上门得到的向上的方向还是不准确的，这里再根据准确的法线方向和向右的方向得到最后的向上方向
				upDir = normalize(cross(normalDir, rightDir));
				
				//根据原始的位置相对锚点的偏移量以及3个正交基矢量，计算得到新的顶点位置
				float3 centerOffs = v.vertex.xyz - center;
				float3 localPos = center + rightDir * centerOffs.x + upDir * centerOffs.y + normalDir.z * centerOffs.z;
				//把模型空间的顶点位置变换到裁剪空间中去
				o.pos = UnityObjectToClipPos(float4(localPos, 1));
				o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
				return o;
			}
			
			fixed4 frag(v2f i) : SV_Target {
				fixed4 c = tex2D(_MainTex, i.uv);
				c.rgb *= _Color.rgb;
				
				return c;
			} 
			
			ENDCG
		}
	}
	FallBack "Transparent/VertexLit"
}
