// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

//------------------------------------------------
//    法线贴图在切线空间的采样测试
//    https://zhuanlan.zhihu.com/p/413508668?utm_id=0
//------------------------------------------------
Shader "GameLib/Tex/NormalMapInTangent"
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
				float4 pos         : SV_POSITION;
				//这里使用float4，xy存储_MainTex的纹理坐标，zw存储_NormalTex的纹理坐标
				float4 uv 		   : TEXCOORD0;
				//存储变换后的光照方向
				float3 lightDir    : TEXCOORD1;
				//存储变换后的视角方向
				float3 viewDir     : TEXCOORD2;
			};

			v2f vert(appdata v)
			{
				v2f o;
				//将顶点从模型空间转换到观察空间 UnityObjectToClipPos代替mul(UNITY_MATRIX_MVP, v.vertex)
				o.pos = UnityObjectToClipPos(v.vertex);
				//下面等价于： o.uv = v.texcood.xy * _MainTex_ST.xy + _MainTex_ST.zw; 这里就是对UV坐标先缩放，再偏移，然后得到最终的UV坐标
				o.uv.xy = TRANSFORM_TEX(v.texcood, _MainTex);
				o.uv.zw = TRANSFORM_TEX(v.texcood, _NormalTex);

				//https://zhuanlan.zhihu.com/p/20933988
				//https://www.zhihu.com/question/23706933/answer/25591714
				//https://learnopengl-cn.github.io/05%20Advanced%20Lighting/04%20Normal%20Mapping/#_1 opengl的关于切线空间的解释
				//求副切线：法线和切线的叉乘得到了副切线方向有两个，用*w分量来选择正面
				//float3 binormal = cross(normalize(v.normal), normalize(v.tangent.xyz)) * v.tangent.w;
				//求切线空间矩阵:
				//这里的切线、副切线、法线相当于xyz 这三个分量的组合就是这个空间的空间矩阵，这里的rotation其实就是TBN矩阵，TBN矩阵这三个字母分别代表tangent、bitangent和normal向量
				//float3x3 rotation = float3x3(v.tangent.xyz, binormal, v.normal);
				//这个内置宏可以代替上面两行
				TANGENT_SPACE_ROTATION;

				//把光照方向从模型空间转换到切线空间,切线空间转换（顶点到灯光的朝向）
				o.lightDir = mul(rotation, ObjSpaceLightDir(v.vertex)).xyz;
				//把视角方向从模型空间转换到切线空间,切线空间转换（顶点到摄像机的朝向）
				o.viewDir = mul(rotation, ObjSpaceViewDir(v.vertex)).xyz;
				return o;
			}

			fixed4 frag(v2f f) : SV_TARGET
			{
				//切线空间下灯光的单位向量
				fixed3 tangentLightDir = normalize(f.lightDir);
				//切线空间下摄像机的单位向量
				fixed3 tangentViewDir = normalize(f.viewDir);

				//对法线贴图采样
				fixed4 packedNormal = tex2D(_NormalTex, f.uv.zw);
				//这里要确保使用的法线贴图是标记了"Normal Map"的
				//法线贴图中存储的是把法线经过映射后得到的像素值，这里反映射回来,转换切线空间贴图法线（-1~1）
				fixed3 tangentNormal = UnpackNormal(packedNormal);
				//控制凹凸程度
				tangentNormal.xy *= _NormalScale;
				//法线都是单位矢量，z值可以由xy求得。由于是切线空间下的法线纹理，可以保证法线方向的z分量为正
				//用的是切线空间下的法线纹理，因此法线的z为正数 其实(dot(xy,xy))=x*x+y*y
				//由于偏移后的法线是归一化的，因此满足x2 + y2 + z2 = 1
				//所以z=sqrt(1-(x2+y2))
				tangentNormal.z = sqrt(1.0 - saturate(dot(tangentNormal.xy, tangentNormal.xy)));

				//材质反射率，使用采样结果和_Color的颜色相乘获取到
				fixed3 albedo = tex2D(_MainTex, f.uv).rgb * _Color.rgb;
				//拿到环境光
				fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz * albedo;
				//计算漫反射光
				fixed3 diffuse = _LightColor0.rgb * albedo * max(0, dot(tangentNormal, tangentLightDir));
				//half-direction是视线向量和灯光向量的中间向量，通常在blinn-phong镜面模型中使用的。https://blog.csdn.net/v_xchen_v/article/details/79088182
			    //Unity中获取 float3 halfDirection = normalize(viewDirection+lightDirection);
				fixed3 halfDir = normalize(tangentLightDir + tangentViewDir);
				//计算高光,把参数代入高光反射公式
				fixed3 specular = _LightColor0.rgb * _Specular.rgb * pow(max(0, dot(tangentNormal, halfDir)), _GlossArea);
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
