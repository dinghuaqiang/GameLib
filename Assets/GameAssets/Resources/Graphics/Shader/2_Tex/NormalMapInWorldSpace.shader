// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

//------------------------------------------------
//    法线贴图在世界空间的采样测试
//    在世界空间下计算光照模型。我们需要在片元着色器中把法线方向从切线空间变换到世界空间下。
//    这种方法的基本思想是:在顶点着色器中计算从切线空间到世界空间的变换矩阵，并把它传递给片元着色器。
//    变换矩阵的计算可以由顶点的切线、副切线和法线在世界空间下的表示来得到。
//    最后，我们只需要在片元着色器中把法线纹理中的法线方向从切线空间变换到世界空间下即可。
//    尽管这种方法需要更多的计算，但在需要使用Cubemap进行环境映射等情况下，我们就需要使用这种方法。
//------------------------------------------------
Shader "GameLib/Tex/NormalMapInWorldSpace"
{
    Properties
    {
		//贴图
		_MainTex ("MainTex", 2D) = "white" {}
		//法线贴图, bump是Unity内置的法线图，如果没有提供法线图，bump就对应模型自带的法线信息
		_NormalTex ("NormalTex", 2D) = "bump" {}
		//控制凹凸程度，如果为0，不会对光照产生任何影响
		_NormalScale ("Normal Scale", Float) = 1.0
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

			sampler2D _MainTex;
			//纹理的属性，存储纹理缩放和偏移值的变量，[_MainTex_ST.xy缩放 对应Tiling] [_MainTex_ST.zw偏移 对应Offest]
			float4 _MainTex_ST;
			sampler2D _NormalTex;
			//得到法线贴图的缩放和偏移属性
			float4 _NormalTex_ST;
			float _NormalScale;
            fixed4 _Color;
            fixed4 _Specular;
            //光照区域的范围比较大，用float精度存储
            float _GlossArea;

            //顶点着色器的输入输出结构体(也是片元着色器的输入结构体)
			struct appdata
			{
				float4 vertex  : POSITION;
				float3 normal  : NORMAL;
				//把顶点的切线方向填充到tangent变量 这里用float4不用float3是因为后面需要用到tangent.w分量决定切线空间的第三个坐标轴（副切线的方向性）
				float4 tangent : TANGENT;    
				//填充uv0的数据到texcood变量中去【第一套UV坐标值】
				float4 texcood : TEXCOORD0;  
			};

			struct v2f
			{
				float4 pos  : SV_POSITION;
				//这里使用float4，xy存储_MainTex的纹理坐标，zw存储_NormalTex的纹理坐标
				float4 uv   : TEXCOORD0;
                //一个插值寄存器最多只能存float4大小的变量，这里把矩阵拆分成多个变量存储，T2W0,T2W1,T2W2依次存储从切线空间到世界空间的变换矩阵的每一行。
				float4 T2W0 : TEXCOORD1;
				float4 T2W1 : TEXCOORD2;
				float4 T2W2 : TEXCOORD3;
			};

            //在顶点着色器中计算从切线空间到世界空间的变换矩阵
			v2f vert(appdata v)
			{
				v2f o;
				//将顶点从模型空间转换到观察空间 UnityObjectToClipPos代替mul(UNITY_MATRIX_MVP, v.vertex)
				o.pos = UnityObjectToClipPos(v.vertex);
				//下面等价于： o.uv = v.texcood.xy * _MainTex_ST.xy + _MainTex_ST.zw; 这里就是对UV坐标先缩放，再偏移，然后得到最终的UV坐标
				o.uv.xy = TRANSFORM_TEX(v.texcood, _MainTex);
				o.uv.zw = TRANSFORM_TEX(v.texcood, _NormalTex);

                //顶点
                float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                //法线
				float3 worldNormal = UnityObjectToWorldNormal(v.normal);
                //顶点切线
                float3 worldTangent = UnityObjectToWorldDir(v.tangent.xyz);
                //求副法线（副切线）
                float3 worldBinormal = cross(worldNormal, worldTangent) * v.tangent.w;
                //把顶点切线 副切线 法线存在矩阵中，顶点位置的xyz分量存在了矩阵的w分量中，可以充分利用插值寄存器的存储空间
                o.T2W0 = float4(worldTangent.x, worldBinormal.x, worldNormal.x, worldPos.x);
                o.T2W1 = float4(worldTangent.y, worldBinormal.y, worldNormal.y, worldPos.y);
                o.T2W2 = float4(worldTangent.z, worldBinormal.z, worldNormal.z, worldPos.z);
				return o;
			}

			fixed4 frag(v2f f) : SV_TARGET
			{
                //顶点世界坐标
				float3 worldPos = float3(f.T2W0.w, f.T2W1.w, f.T2W2.w);
                //世界坐标灯光方向
                fixed3 lightDir = normalize(UnityWorldSpaceLightDir(worldPos));
                //摄像机方向
                fixed3 viewDir  = normalize(UnityWorldSpaceViewDir(worldPos));

				fixed3 normalTexNormal = UnpackNormal(tex2D(_NormalTex, f.uv.zw));
				//控制凹凸程度
				normalTexNormal.xy *= _NormalScale;
				//法线都是单位矢量，z值可以由xy求得。由于是切线空间下的法线纹理，可以保证法线方向的z分量为正
				//用的是切线空间下的法线纹理，因此法线的z为正数 其实(dot(xy,xy))=x*x+y*y
				//由于偏移后的法线是归一化的，因此满足x2 + y2 + z2 = 1
				//所以z=sqrt(1-(x2+y2))
				//向量点乘自身算出x2+y2，再求出z的值
				normalTexNormal.z = sqrt(1.0 - saturate(dot(normalTexNormal.xy, normalTexNormal.xy)));
				//把法线变换到世界空间下，使用点乘操作实现矩阵的每一行和法线相乘得到
				normalTexNormal = normalize(half3(dot(f.T2W0.xyz, normalTexNormal), dot(f.T2W1.xyz, normalTexNormal), dot(f.T2W2.xyz, normalTexNormal)));

				//材质反射率，使用采样结果和_Color的颜色相乘获取到
				fixed3 albedo = tex2D(_MainTex, f.uv).rgb * _Color.rgb;
				//拿到环境光
				fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz * albedo;
				//计算漫反射光
				fixed3 diffuse = _LightColor0.rgb * albedo * max(0, dot(normalTexNormal, lightDir));
				//half-direction是视线向量和灯光向量的中间向量，通常在blinn-phong镜面模型中使用的。https://blog.csdn.net/v_xchen_v/article/details/79088182
			    //Unity中获取 float3 halfDirection = normalize(viewDirection+lightDirection);
				fixed3 halfDir = normalize(lightDir + viewDir);
				//计算高光,把参数代入高光反射公式
				fixed3 specular = _LightColor0.rgb * _Specular.rgb * pow(max(0, dot(normalTexNormal, halfDir)), _GlossArea);
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
