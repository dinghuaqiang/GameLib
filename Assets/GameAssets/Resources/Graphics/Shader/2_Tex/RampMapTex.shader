// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

//------------------------------------------------
//    渐变纹理控制漫反射光照
//------------------------------------------------
Shader "GameLib/Tex/RampMapTex"
{
    Properties
    {
		//渐变纹理贴图
		_RampTex ("RampTex", 2D) = "white" {}
		//控制物体的整体色调
        _Color ("Color", Color) = (1, 1, 1, 1)
        //材质的高光反射颜色
        _Specular ("Specular", Color) = (1, 1, 1, 1)
        //高光区域的大小
        _GlossArea ("GlossArea", Range(8.0, 256)) = 20
    }

    SubShader
    {
        Pass
        {
            Tags { "LightModel"="ForwardBase" }

            CGPROGRAM

            //引用Unity光照相关的内置变量，比如_LightColor0
            #include "Lighting.cginc"
            // Use shader model 3.0 target, to get nicer looking lighting
            #pragma target 3.0

            #pragma vertex vert
            #pragma fragment frag

			sampler2D _RampTex;
			//纹理的缩放和偏移量
			float4 _RampTex_ST;
            fixed4 _Color;
            fixed4 _Specular;
            //光照区域的范围比较大，用float精度存储
            float _GlossArea;

            //顶点着色器的输入输出结构体(也是片元着色器的输入结构体)
			struct appdata
			{
				//顶点
				float4 vertex  : POSITION;
				//法线
				float3 normal  : NORMAL;
				//填充uv0的数据到texcood变量中去【第一套UV坐标值】,模型顶点的UV数据
				float4 texcood : TEXCOORD0;  
			};

			struct v2f
			{
				float4 pos         : SV_POSITION;
				float3 worldNormal : TEXCOORD0;
				float3 worldPos    : TEXCOORD1;
				float2 uv 		   : TEXCOORD2;
			};

			v2f vert(appdata v)
			{
				v2f o;
				//将顶点从模型空间转换到观察空间 UnityObjectToClipPos代替mul(UNITY_MATRIX_MVP, v.vertex)
				o.pos = UnityObjectToClipPos(v.vertex);
				o.worldNormal = UnityObjectToWorldNormal(v.normal);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				//将模型顶点的uv和Tiling、Offset两个变量进行运算，计算出实际显示用的顶点uv，相当于就是把偏移和缩放一起计算了
				o.uv = TRANSFORM_TEX(v.texcood, _RampTex);
				return o;
			}

			fixed4 frag(v2f f) : SV_TARGET
			{
				fixed3 worldNormal = normalize(f.worldNormal);
				fixed3 worldLightDir = normalize(UnityWorldSpaceLightDir(f.worldPos));
				//拿到环境光
				fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz;

				// C(diffuse) = C(light) * M(diffuse)max(0,n*I)
				// C(light)：入射光的颜色和强度  _LightColor0.rgb
				// M(diffuse)：材质的漫反射系数  采样贴图获取颜色,混合调整的颜色
				// n：世界坐标系下的表面法线
				// I：世界坐标系下的光源方向（反射点指向光源的矢量）
				// max函数：，将结果截取到0，防止法线与光源方向的点乘为负值，被背后的光源照亮的错误效果
				// 比较通用的一个半兰伯特公式：
				// C(diffuse) = (C(light) * M(diffuse))(0.5(n*l)+0.5)
				fixed halfLambert = 0.5 * dot(worldLightDir, worldNormal) + 0.5;
				//材质的漫反射系数
				fixed3 mDiffuse = tex2D(_RampTex, fixed2(halfLambert, halfLambert)).rgb * _Color.rgb;
				//入射光的颜色和强度 * 材质的漫反射系数
				fixed3 cDiffuse = _LightColor0.rgb * mDiffuse;

				fixed3 viewDir = UnityWorldSpaceViewDir(f.worldPos);
				fixed3 halfDir = normalize(worldLightDir + viewDir);
				//Blinn-Phong高光反射 入射光线的颜色和强度 * 材质的高光反射系数 * pow（max（0，dot（法线方向 ，h矢量方向）），gloss高光区域大小）
				fixed3 specular =  _LightColor0.rgb * _Specular.rgb * pow(max(0, dot(worldNormal, halfDir)), _GlossArea);

				//求和，计算最终输出颜色
				fixed3 color = ambient + cDiffuse + specular;
				return fixed4(color, 1.0);
			}

            ENDCG
        }
    }
    //设置Unity内置的高光回调
    FallBack "Specular"
}
