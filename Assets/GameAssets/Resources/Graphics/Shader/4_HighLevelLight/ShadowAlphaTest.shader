/**
    要注意在MeshRender中把Cast Shadows开启Two Sided开启，强制Unity在计算阴影映射纹理时计算所有面的深度信息。
    因为默认情况下把物体渲染到深度图和阴影映射纹理中仅考虑物体的正面，如果一些面完全背对光源，这些面的深度信息就没有加入到阴影映射纹理的计算去。
*/
Shader "GameLib/HighLevelLight/ShadowAlphaTest"
{
    Properties
    {
        _MainTex ("MainTex", 2D)  = "white" {}
        _Color   ("Color", Color) = (1, 1, 1, 1)
        //决定clip函数进行透明度测试时的判断条件。0-1是因为Alpha的透明度值就是0-1
        _Cutoff  ("Alpha CutOff", Range(0, 1)) = 0.5
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

        Pass
        {
            //使用前向渲染
            Tags { "LightModel"="ForwardBase" }
            Cull off

            CGPROGRAM

            //引用Unity光照相关的内置变量，比如_LightColor0
            #include "Lighting.cginc"
            #include "AutoLight.cginc"
            // Use shader model 3.0 target, to get nicer looking lighting
            #pragma target 3.0

            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fwdbase

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Color;
            fixed  _Cutoff;

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
                //由于已经占用了3个插值寄存器（TEXCOORD0，TEXCOORD1，TEXCOORD2），因此这次传入3，意味着阴影纹理坐标将占用第四个插值寄存器TEXCOORD3
                SHADOW_COORDS(3)
			};

            v2f vert(a2v v)
            {
                //计算世界空间的法线，顶点，变换后的UV坐标
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                //计算阴影纹理坐标给片元着色器
                TRANSFER_SHADOW(o);
                return o;
            }

            fixed4 frag(v2f i) : SV_TARGET
            {
                fixed3 worldNormal   = normalize(i.worldNormal);
                fixed3 worldLightDir = normalize(UnityWorldSpaceLightDir(i.worldPos));

                fixed4 texColor = tex2D(_MainTex, i.uv);
                //使用clip函数做AlphaTest,只要小于0就舍弃掉。  相当于if ((texColor.a - _Cutoff) < 0) discard;
                clip(texColor.a - _Cutoff);

                //计算环境光
                fixed3 albedo = texColor.rgb * _Color.rgb;
                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz * albedo;
                //计算漫反射光
                fixed3 diffuse = _LightColor0.rgb * albedo * max(0, dot(worldNormal, worldLightDir));

                //计算光照衰减和阴影 atten不用声明，宏里面会声明
                UNITY_LIGHT_ATTENUATION(atten, i, i.worldPos);

                return fixed4(ambient + diffuse * atten, 1.0);
            }

            ENDCG
        }
    }

    //这个是用ShadowCaster来投射阴影，而这个Pass中并没有进行任何透明度测试的计算，它会把整个物体的深度信息渲染到深度图和阴影映射纹理中。就会导致透明区域不透光。
    //FallBack "VertexLit"
    //这个Pass提供了一个有透明度测试功能的ShadowCaster Pass
    FallBack "Transparent/Cutout/VertexLit"
}