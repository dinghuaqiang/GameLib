/*
    AlphaBlend(透明度混合)：
    使用当前片元的透明度作为混合因子，与已经存储在颜色缓冲中的颜色值进行混合，得到新的颜色。
    透明度混合需要关闭深度写入，需要非常小心物体的渲染顺序。

    主要是使用Unity提供的混合命令----Blend,设置混合模式。
    Blend Off  关闭混合
    Blend SrcFactor DstFactor  开启混合，并且设置混合因子。源颜色（该片元产生的颜色）会乘以SrcFactor,而目标颜色（已经存在于颜色缓存的颜色）会乘以DsrFactor，然后再把两者相加存入颜色缓冲中
    Blend SrcFactor DstFactor, SrcFactorA DstFactorA  和上面命令几乎一样，只是使用不同的因子来混合透明通道
    BlendOp BlendOperation 并非是把源颜色和目标颜色简单的相加后混合，使用BlendOperation对它们进行其他操作

    渲染队列（RenderQueue）相关：
    索引越小表示越早被渲染。
    Background  1000  通常用来渲染需要绘制在背景上的物体
    Geometry    2000  大多数物体使用的渲染队列。不透明物体使用这个队列。
    AlphaTest   2450  需要透明度测试的物体使用这个渲染队列。是从Geometry分离出来的，先渲染所有的不透明物体之后再渲染半透明的会更高效。
    Transparent 3000  主要用于使用了透明度混合的物体渲染。（例如关闭了深度写入的Shader）
    Overlay     4000  主要用于实现一些叠加效果。任何需要在最后渲染的物体都用这个队列。
**/

Shader "GameLib/Alpha/AlphaBlend"
{
    Properties
    {
        _MainTex ("MainTex", 2D)  = "white" {}
        _Color   ("Color", Color) = (1, 1, 1, 1)
        //控制整体的透明度
        _AlphaScale  ("Alpha Scale", Range(0, 1)) = 1
    }

    SubShader
    {
        //使用AlphaBlend需要设置的渲染序列，一般使用了AlphaBlend的Shader都应该在SubShader设置下面的三个标签。
        Tags 
        { 
            //设置渲染队列在AlphaBlend
            "Queue" = "Transparent" 
            //设置这个Shader不受投影器（Projectors）的影响
            "IgnoreProjector" = "True"
            //这个RenderType标签通常用于着色器替换功能，RenderType标签可以让Unity把这个Shader归入到提前定义的组（这里就是Transparent组）当中，指明这个Shader是一个使用了透明度测试的Shader。
            "RenderType" = "Transparent"    
        }
        //关闭所有的深度写入  写在SubShader就是对所有的Pass生效
        //ZWrite Off

        // //把模型的深度值写入到深度缓冲中
        // Pass
        // {
        //     //开启深度写入
        //     ZWrite On
        //     //关闭颜色输出
        //     ColorMask 0 
        // }

        Pass
        {
            //使用前向渲染
            Tags { "LightModel"="ForwardBase" }
            //关闭深度写入 https://github.com/candycat1992/Unity_Shaders_Book/issues/153
            //如果不关闭的话，两个不透明物体重叠的这种，渲染会被直接剔除掉，传统的半透明混合总是会在物体交叉、渲染重叠的情况下，出现错误的混合效果。如果开启深度写入，会令到渲染错误很明显，而关掉的话影响较小一点。
            ZWrite Off
            //设置混合模式，将源颜色（该片元着色器产业的颜色）的混合因子设置为SrcAlpha,把目标颜色(已经存在于颜色缓冲中的颜色)的混合因子设置为OneMinusSrcAlpha，得到合适的半透明效果
            //正常效果，透明度混合
            Blend SrcAlpha OneMinusSrcAlpha
            //BlendOp Add
            //柔和相加
            //Blend OneMinusDstColor One
            //正片叠底
            //Blend DstColor Zero
            //两倍相乘
            //Blend DstColor SrcColor
            //变暗
            // BlendOp Min
            // Blend One One
            //变亮
            // BlendOp Max
            // Blend One One
            //滤色
            //Blend OneMinusDstColor One
            //线性减淡
            //Blend One One
            //混合相关的  https://zhuanlan.zhihu.com/p/522757804

            /** 
                默认情况下，渲染引擎剔除了物体的背面的渲染图元（相对于摄像机的方向），只渲染了物体的正面。如果没有设置双面渲染，就无法观察到模型内部及其背面的形状，导致物体看起来就好像只要半个一个。
                要想得到双面渲染的效果，可以使用Cull指令来控制需要剔除哪个面的渲染图元。
             */
            //1. 背对摄像机的渲染图元就不会被渲染，这也是默认情况下的剔除状态。
            //Cull Back
            //2. 朝向摄像机的渲染图元就不会被渲染，剔除面向摄像机的这一面
            //Cull Front
            //3. 关闭剔除功能，所有的渲染图元都会被渲染，但是会让需要渲染的图元成倍增加，除非是特殊效果，比如需要双面渲染，通常不会关闭剔除功能。
            //Cull Off

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
            fixed  _AlphaScale;

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
                //获取法线和光源方向后面拿来算漫反射光
                fixed3 worldNormal   = normalize(i.worldNormal);
                fixed3 worldLightDir = normalize(UnityWorldSpaceLightDir(i.worldPos));
                //采样图片颜色用来算环境光
                fixed4 texColor = tex2D(_MainTex, i.uv);
                //计算环境光
                fixed3 albedo = texColor.rgb * _Color.rgb;
                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz * albedo;
                //计算漫反射光
                fixed3 diffuse = _LightColor0.rgb * albedo * max(0, dot(worldNormal, worldLightDir));
                //变化纹理的alpha通道值
                fixed alphaColor = texColor.a * _AlphaScale;
                return fixed4(ambient + diffuse, alphaColor);
            }

            ENDCG
        }
    }

    FallBack "Transpanent/VertexLit"
}