// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

//------------------------------------------------
//    遮罩纹理(mask texture)允许我们可以保护某些区域，使它们免于某些修改。
// 例如，在之前的实现中，我们都是把高光反射应用到模型表面的所有地方，即所有的像素都使用同样大小的高光强度和高光指数。
// 但有时，我们希望模型表面某些区域的反光强烈一些，而某些区域弱一些。为了得到更加细腻的效果，我们就可以使用一张遮罩纹理来控制光照。
// 另一种常见的应用是在制作地形材质时需要混合多张图片，例如表现草地的纹理、表现石子的纹理、表现裸露土地的纹理等，使用遮罩纹理可以控制如何混合这些纹理。

// 使用遮罩纹理的流程一般是:
// 通过采样得到遮罩纹理的纹素值，然后使用其中某个(或某几个)通道的值(例如 texelr)来与某种表面属性进行相乘，这样，当该通道的值为0时，可以保护表面不受该属性的影响。
// 总而言之，使用遮罩纹理可以让美术人员更加精准(像素级别)地控制模型表面的各种性质。
//------------------------------------------------
Shader "GameLib/Tex/MaskTex"
{
    Properties
    {
		//遮罩贴图
		_MainTex ("MainTex", 2D) = "white" {}
        //法线贴图
        _BumpMapTex ("NormalMapTex", 2D) = "bump" {}
        _BumpScale ("Bump Scale", Float) = 1.0
        //高光反射纹理遮罩
        _SpecularMaskTex ("Specular Mask", 2D) = "white" {}
        //遮罩影响度的系数
        _SpecularScale ("Specular Scale", Float) = 1.0
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
			sampler2D _BumpMapTex;
			sampler2D _SpecularMaskTex;
			//纹理的缩放和偏移量(三个纹理通用，节省插值寄存器的内存值)
			float4 _MainTex_ST;
            float _BumpScale;
            float _SpecularScale;
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
                //切线
                float4 tangent : TANGENT;
				//填充uv0的数据到texcood变量中去【第一套UV坐标值】,模型顶点的UV数据
				float4 texcood : TEXCOORD0;  
			};

			struct v2f
			{
				float4 pos      : SV_POSITION;
				float2 uv 		: TEXCOORD0;
                float3 lightDir : TEXCOORD1;
                float3 viewDir  : TEXCOORD2;
			};

            //在顶点着色器中对光照和视角方向从模型空间变换到切线空间，后面在片元着色器中进行光照运算
			v2f vert(appdata v)
			{
				v2f o;
				//将顶点从模型空间转换到观察空间 UnityObjectToClipPos代替mul(UNITY_MATRIX_MVP, v.vertex)
				o.pos = UnityObjectToClipPos(v.vertex);
                //将模型顶点的uv和Tiling、Offset两个变量进行运算，计算出实际显示用的顶点uv，相当于就是把偏移和缩放一起计算了
				o.uv = TRANSFORM_TEX(v.texcood, _MainTex);
                //构造出 tangent space 的坐标系， 定义转换world space的向量到tangent space的rotation 矩阵。
                //TANGENT_SPACE_ROTATION这行代码之后，就可以用rotation这个代表从世界坐标到切线空间的矩阵了。
                //副法线方向 = corss(法线，切线)   x:切线方向   y:顶点法线方向  z:副法线
				//与W相乘是因为与xy垂直的方向有两个  w决定哪个方向
                //float3 binormal = cross( v.normal, v.tangent.xyz ) * v.tangent.w;
                //float3x3 rotation = float3x3( v.tangent.xyz, binormal, v.normal );
                //相当于下面的宏
				TANGENT_SPACE_ROTATION;
                //把灯光和视口方向转到切线空间
				o.lightDir = mul(rotation, ObjSpaceLightDir(v.vertex).xyz);
				o.viewDir = mul(rotation, ObjSpaceViewDir(v.vertex).xyz);
				return o;
			}

			fixed4 frag(v2f f) : SV_TARGET
			{
				fixed3 tangentLightDir = normalize(f.lightDir);
				fixed3 tangentViewDir  = normalize(f.viewDir);

                //算法线
                fixed3 tangentNormal = UnpackNormal(tex2D(_BumpMapTex, f.uv));
                tangentNormal.xy *= _BumpScale;
                tangentNormal.z = sqrt(1 - saturate(dot(tangentNormal.xy, tangentNormal.xy)));

                //材质反射率，使用采样结果和_Color的颜色相乘获取到
                fixed3 albedo = tex2D(_MainTex, f.uv).rgb * _Color.rgb;
				//拿到环境光
				fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz * albedo;
                //Lambert漫反射 入射光线的颜色和强度 * 材质的漫反射系数 * max（0，dot（法线方向，光照方向））
                fixed3 lambertDiffuse = _LightColor0.rgb * albedo * max(0, dot(tangentNormal, tangentLightDir));

                fixed3 halfDir = normalize(tangentLightDir + tangentViewDir);
                //获取遮罩值
                fixed3 specularMask = tex2D(_SpecularMaskTex, f.uv).r * _SpecularScale;
				//Blinn-Phong高光反射 入射光线的颜色和强度 * 材质的高光反射系数 * pow（max（0，dot（法线方向 ，h矢量方向）），gloss高光区域大小）
				fixed3 specular =  _LightColor0.rgb * _Specular.rgb * pow(max(0, dot(tangentNormal, halfDir)), _GlossArea) * specularMask;

				//求和，计算最终输出颜色
				fixed3 color = ambient + lambertDiffuse + specular;
				return fixed4(color, 1.0);
			}

            ENDCG
        }
    }
    //设置Unity内置的高光回调
    FallBack "Specular"
}
