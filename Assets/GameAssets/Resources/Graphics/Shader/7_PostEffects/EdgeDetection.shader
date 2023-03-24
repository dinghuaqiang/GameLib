/**
    后处理效果
	边缘检测
*/
Shader "GameLib/PostEffects/EdgeDetection"
{
    Properties 
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
		//边缘线强度
		_EdgeOnly ("Edge Only", Float) = 1.0
		//边缘颜色
		_EdgeColor ("Edge Color", Color) = (0, 0, 0, 1)
		//背景颜色
		_BackgroundColor ("Background Color", Color) = (1, 1, 1, 1)
	}

	SubShader 
	{
		
		Pass 
		{
			/**
				屏幕后处理实际上是在场景中绘制了一个与屏幕同宽高的四边形面片，为了防止它对其他物体产生影响，这里设置相关的渲染状态。
				关闭深度写入，防止"挡住"在它后面被渲染的物体。（如果当前的OnRenderImage函数在所有不透明的Pass执行完毕后立即被调用，不关闭深度写入就会影响后面透明Pass的渲染）
				这些状态是屏幕后处理的Shader的标配。
			*/
			ZTest Always Cull Off ZWrite Off
			
			CGPROGRAM  
			#pragma vertex vert 
			#pragma fragment fragSobel
			
			#include "UnityCG.cginc" 
			
			sampler2D _MainTex;  
			/**
				这个变量是Unity提供的访问纹理对应的每个纹素的大小。
				比如，一张512*512大小的图，该值为1/512。
				由于卷积需要对相邻区域内的纹理进行采样，因此需要利用_MainTex_TexelSize来计算各个相邻区域的纹理坐标。
			*/
			uniform half4 _MainTex_TexelSize;
			fixed  _EdgeOnly;
			fixed4 _EdgeColor;
			fixed4 _BackgroundColor;
			
			struct v2f 
			{
				float4 pos   : SV_POSITION;
				float2 uv[9] : TEXCOORD0;
			};
			
			v2f vert(appdata_img v) 
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				half2 uv = v.texcoord;
				/**
					使用Sobel算子采样需要9个相邻域的纹理坐标。
				*/
				o.uv[0] = uv + _MainTex_TexelSize.xy * half2(-1, -1);
				o.uv[1] = uv + _MainTex_TexelSize.xy * half2(0, -1);
				o.uv[2] = uv + _MainTex_TexelSize.xy * half2(1, -1);
				o.uv[3] = uv + _MainTex_TexelSize.xy * half2(-1, 0);
				o.uv[4] = uv + _MainTex_TexelSize.xy * half2(0, 0);
				o.uv[5] = uv + _MainTex_TexelSize.xy * half2(1, 0);
				o.uv[6] = uv + _MainTex_TexelSize.xy * half2(-1, 1);
				o.uv[7] = uv + _MainTex_TexelSize.xy * half2(0, 1);
				o.uv[8] = uv + _MainTex_TexelSize.xy * half2(1, 1);
						 
				return o;
			}

			fixed luminance(fixed4 color) {
				return  0.2125 * color.r + 0.7154 * color.g + 0.0721 * color.b; 
			}
			
			//计算当前像素的梯度值(edge)
			half Sobel(v2f i) {
				//水平方向的卷积核
				const half Gx[9] = {-1,  0,  1,
										-2,  0,  2,
										-1,  0,  1};
				//垂直方向的卷积核
				const half Gy[9] = {-1, -2, -1,
										0,  0,  0,
										1,  2,  1};		
				//一次对9个像素进行采样，计算他们的亮度值，再与卷积核中对应的权重相乘，叠加到各自的梯度值上。
				half texColor;
				//水平方向和垂直方向的梯度值
				half edgeX = 0;
				half edgeY = 0;
				for (int it = 0; it < 9; it++) {
					texColor = luminance(tex2D(_MainTex, i.uv[it]));
					edgeX += texColor * Gx[it];
					edgeY += texColor * Gy[it];
				}
				//用绝对值避免开根号，edge越小，表面该位置越可能是一个边缘点。
				half edge = 1 - abs(edgeX) - abs(edgeY);
				return edge;
			}
			
			fixed4 fragSobel(v2f i) : SV_Target 
			{
				//拿到当前像素的梯度值
				half edge = Sobel(i);
				//进行插值得到最终颜色值
				fixed4 withEdgeColor = lerp(_EdgeColor, tex2D(_MainTex, i.uv[4]), edge);
				fixed4 onlyEdgeColor = lerp(_EdgeColor, _BackgroundColor, edge);
				return lerp(withEdgeColor, onlyEdgeColor, _EdgeOnly);
 			}
			
			ENDCG
		}
	}
	FallBack Off
}
