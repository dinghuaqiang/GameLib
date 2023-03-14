// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

//------------------------------------------------
//    贴图采样测试
//------------------------------------------------
Shader "GameLib/Tex/SingleTex"
{
    Properties
    {
		//贴图
		_MainTex ("MainTex", 2D) = "white" {}
        //控制物体的整体色调
        _Color ("Color", Color) = (1,1,1,1)
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

			sampler2D _MainTex;
			//纹理的属性，存储纹理缩放和偏移值的变量，[_MainTex_ST.xy缩放 对应Tiling] [_MainTex_ST.zw偏移 对应Offest]
			float4 _MainTex_ST;
            fixed4 _Color;
            fixed4 _Specular;
            //光照区域的范围比较大，用float精度存储
            float _GlossArea;

            //顶点着色器的输入输出结构体(也是片元着色器的输入结构体)
			struct a2v
			{
				float4 vertex  : POSITION;
				float3 normal  : NORMAL;
				float4 texcood : TEXCOORD0;  //填充uv0的数据到texcood变量中去【第一套UV坐标值】
			};

			struct v2f
			{
				float4 pos         : SV_POSITION;
				float3 worldNormal : TEXCOORD0;
				float3 worldPos    : TEXCOORD1;
				float2 uv          : TEXCOORD2;  //存储UV坐标，在片元着色器中用这个进行纹理采样
			};

			v2f vert(a2v v)
			{
				v2f o;
				//将顶点从模型空间转换到观察空间 UnityObjectToClipPos代替mul(UNITY_MATRIX_MVP, v.vertex)
				o.pos = UnityObjectToClipPos(v.vertex);
				//拿到世界空间的法线
				o.worldNormal = UnityObjectToWorldNormal(v.normal);
				//把顶点从模型空间转到世界空间
				o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				//下面等价于： o.uv = v.texcood.xy * _MainTex_ST.xy + _MainTex_ST.zw; 这里就是对UV坐标先缩放，再偏移，然后得到最终的UV坐标
				o.uv = TRANSFORM_TEX(v.texcood, _MainTex);
				return o;
			}

			fixed4 frag(v2f f) : SV_TARGET
			{
				fixed3 worldNormal = normalize(f.worldNormal);
				//获取世界空间下的光照方向
				fixed3 worldLightDir = normalize(UnityWorldSpaceLightDir(f.worldPos));
				//材质反射率，使用采样结果和_Color的颜色相乘获取到
				fixed3 albedo = tex2D(_MainTex, f.uv).rgb * _Color.rgb;
				//拿到环境光
				fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz * albedo;
				//计算漫反射光
				fixed3 diffuse = _LightColor0.rgb * albedo * max(0, dot(worldNormal, worldLightDir));
				//获取世界空间下的观察方向
				fixed3 viewDir = normalize(UnityWorldSpaceViewDir(f.worldPos));
				//half-direction是视线向量和灯光向量的中间向量，通常在blinn-phong镜面模型中使用的。https://blog.csdn.net/v_xchen_v/article/details/79088182
			    //Unity中获取 float3 halfDirection = normalize(viewDirection+lightDirection);
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
