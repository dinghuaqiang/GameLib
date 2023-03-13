﻿// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

//------------------------------------------------
//    Blinn-Phong光照模型
//    实际渲染中绝大多数情况下使用的光照模型
//------------------------------------------------
Shader "GameLib/Light/Blinn-Phong"
{
    Properties
    {
        //漫反射光颜色
        _Diffuse ("Diffuse", Color) = (1,1,1,1)
        //材质的高光反射颜色
        _Specular ("Specular", Color) = (1,1,1,1)
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

            //颜色的范围在0-1之间，用fixed精度变量存储
            fixed4 _Diffuse;
            fixed4 _Specular;
            //光照区域的范围比较大，用float精度存储
            float _GlossArea;
            //顶点着色器的输入输出结构体(也是片元着色器的输入结构体)
			struct a2v
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float4 position : SV_POSITION;
				float3 worldNormal : TEXCOORD0;
				float3 worldPos : TEXCOORD1;
			};

			//计算世界空间下的法线方向和顶点坐标，然后扔给片元着色器
			v2f vert(a2v renderData)
			{
				v2f o;
				//将顶点从模型空间转换到观察空间 UnityObjectToClipPos代替mul(UNITY_MATRIX_MVP, renderData.vertex)
				o.position = UnityObjectToClipPos(renderData.vertex);
				//拿到世界空间的法线
				o.worldNormal = normalize(mul(renderData.normal, (float3x3)unity_WorldToObject));
				//把顶点从模型空间转到世界空间
				o.worldPos = mul(unity_ObjectToWorld, renderData.vertex).xyz;
				return o;
			}

			fixed4 frag(v2f vertData) : SV_TARGET
			{
				//拿到环境光
				fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz;
				fixed3 worldNormal = normalize(vertData.worldNormal);
				//根据_WorldSpaceLightPos0归一化来获取世界空间中光源的方向
				fixed3 worldLightDir = normalize(_WorldSpaceLightPos0.xyz);
				//计算漫反射光
				fixed3 diffuse = _LightColor0.rgb * _Diffuse.rgb * saturate(dot(worldNormal, worldLightDir));
				//获取世界空间的视口方向 _WorldSpaceCameraPos得到摄像机位置，
				//把顶点位置从模型空间变换到世界空间下，再通过和相机位置相减就可得到世界空间下的视角方向
				fixed3 viewDir = normalize(_WorldSpaceCameraPos.xyz - vertData.worldPos.xyz);
				fixed3 halfDir = normalize(worldLightDir + viewDir);
				//计算高光,把参数代入高光反射公式
				fixed3 specular = _LightColor0.rgb * _Specular.rgb * pow(max(0, dot(worldNormal, halfDir)), _GlossArea);
				//求和，计算最终输出颜色
				fixed3 color = ambient + diffuse + specular;
				return fixed4(color, 1.0);
			}

            ENDCG
        }
    }
    //设置Unity内置的高光回调
    FallBack "Specular"
}
