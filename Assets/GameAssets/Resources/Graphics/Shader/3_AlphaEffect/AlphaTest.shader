/*
    Alpha Test：比较粗暴，要么显示，要么不显示。

    渲染队列（RenderQueue）相关：
    索引越小表示越早被渲染。
    Background  1000  通常用来渲染需要绘制在背景上的物体
    Geometry    2000  大多数物体使用的渲染队列。不透明物体使用这个队列。
    AlphaTest   2450  需要透明度测试的物体使用这个渲染队列。是从Geometry分离出来的，先渲染所有的不透明物体之后再渲染半透明的会更高效。
    Transparent 3000  主要用于使用了透明度混合的物体渲染。（例如关闭了深度写入的Shader）
    Overlay     4000  主要用于实现一些叠加效果。任何需要在最后渲染的物体都用这个队列。
**/

Shader "GameLib/Alpha/AlphaTest"
{
    Properties
    {
        _MainTex ("MainTex", 2D)  = "white" {}
        _Color   ("Color", Color) = (1, 1, 1, 1)
        //决定clip函数进行透明度测试时的判断条件。0-1是因为Alpha的透明度值就是0-1
        _CutOff  ("Alpha CutOff", Range(0, 1)) = 0.5
    }

    SubShader
    {
        //使用AlphaTest需要设置的渲染序列，一般使用了AlphaTest的Shader都应该在SubShader设置下面的三个标签。
        Tags 
        { 
            //设置渲染队列在AlphaTest
            "Queue" = "AlphaTest" 
            //设置这个Shader不受投影器（Projectors）的影响
            "IgnoreProjector" = "True"
            //这个RenderType标签通常用于着色器替换功能，RenderType标签可以让Unity把这个Shader归入到提前定义的组（这里就是TransparentCutout组）当中，指明这个Shader是一个使用了透明度测试的Shader。
            "RenderType" = "TransparentCutout"    
        }
        //使用AlphaBlend需要设置的渲染序列
        //Tags { "Queue" = "Transparent" }
        
        //关闭所有的深度写入  写在SubShader就是对所有的Pass生效
        //ZWrite Off

        Pass
        {
            //使用前向渲染
            Tags { "LightModel"="ForwardBase" }
            ZWrite Off

            CGPROGRAM

            //引用Unity光照相关的内置变量，比如_LightColor0
            #include "Lighting.cginc"
            // Use shader model 3.0 target, to get nicer looking lighting
            #pragma target 3.0

            #pragma vertex vert
            #pragma fragment frag

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Color;
            fixed  _CutOff;

            //顶点着色器的输入输出结构体(也是片元着色器的输入结构体)
			struct a2v
			{
				float4 vertex  : POSITION;
				float3 normal  : NORMAL;
				float4 texcoord : TEXCOORD0;  //填充uv0的数据到texcoord变量中去【第一套UV坐标值】
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
                //计算世界空间的法线，顶点，变换后的UV坐标
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                return o;
            }

            fixed4 frag(v2f i) : SV_TARGET
            {
                fixed3 worldNormal   = normalize(i.worldNormal);
                fixed3 worldLightDir = normalize(UnityWorldSpaceLightDir(i.worldPos));

                fixed4 texColor = tex2D(_MainTex, i.uv);
                //使用clip函数做AlphaTest,只要小于0就舍弃掉。  相当于if ((texColor.a - _CutOff) < 0) discard;
                clip(texColor.a - _CutOff);

                //计算环境光
                fixed3 albedo = texColor.rgb * _Color.rgb;
                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz * albedo;
                //计算漫反射光
                fixed3 diffuse = _LightColor0.rgb * albedo * max(0, dot(worldNormal, worldLightDir));

                return fixed4(ambient + diffuse, 1.0);
            }

            ENDCG
        }
    }

    FallBack "Transpanent/Cutout/VertexLit"
}