//------------------------------------------------
//    逐顶点光照案例，实现逐顶点的漫反射光照
//------------------------------------------------
Shader "GameLib/Light/DiffuseVertexLevel"
{
    Properties
    {
        //材质的漫反射颜色
        _Diffuse ("Diffuse", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Pass
        {
            //指定光照的渲染模式，这里是为了得到Unity的内置光照变量
            Tags { "LightModel"="ForwardBase" }

            //开始CG的代码片段  和 ENDCG对应
            CGPROGRAM

            //指定顶点和片元函数，相当于是告诉Unity，哪个函数执行顶点着色，哪个函数执行片元着色
            #pragma vertex vert
            #pragma fragment frag

            //引入Unity内置的光照函数模块，会用到里面的一些变量
            #include "Lighting.cginc"
            //为了使用上门定义的变量，定义一个和Properties输入变量同名的变量
            fixed4 _Diffuse;


            //------------------------
            //POSITION NORMAL COLOR这些东西从哪来的呢？
            //是由该材质的MeshRender组件提供的，在每帧调用DrawCall的时候，MeshRender把模型数据发送给Shader
            //------------------------

            //------------------------
            //a2v是什么意思？
            //a是application v是顶点着色器(vertex shader), a2v就是把数据从应用阶段传递到顶点着色器里面
            //------------------------

            //定义顶点着色器的输入和输出结构体（输出结构也是片元着色器的输入结构体）
            struct a2v
            {
                // 把顶点数据填充到vertex字段
                float4 vertex : POSITION;
                // 通过使用NORMAL语义来告诉Unity要把模型顶点的法线信息存储到normal变量中
                float3 normal : NORMAL;
            };

            //为了把顶点着色器计算的光照颜色传递给片元着色器,定义color变量
            //v2f vertex 2 frag 就是顶点到片元的数据传递
            struct v2f
            {
                float4 pos : SV_POSITION;
                //这里也可以使用TEXCOORD0  fixed3 color : TEXCOORD0;
                fixed3 color : COLOR;
            };

            //顶点着色器，最基本的任务就是把顶点位置从模型空间转换到裁剪空间
            //返回值是一个v2f结构体，输入的数据是MeshRender提供的，这里只取了顶点和法线数据
            v2f vert(a2v v)
            {
                v2f o;
                // 把顶点坐标从模型空间转换到裁剪空间(投影空间)
                o.pos = UnityObjectToClipPos(v.vertex);
                // 得到环境光
                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz;
                // 把法线从模型空间转换到世界空间，主要是后面进行点积的时候需要是同坐标系，
                //UnityObjectToWorldNormal(v.normal)代替mul(v.normal, (float3x3)unity_WorldToObject)
                fixed3 worldNormal = normalize(UnityObjectToWorldNormal(v.normal));
                //根据_WorldSpaceLightPos0归一化来获取世界空间中光源的方向
                fixed3 worldLight = normalize(_WorldSpaceLightPos0.xyz);
                //通过计算得到漫反射光
                //根据_LightColor0内置变量来访问该Pass处理的光源的颜色和强度信息
                //saturate函数的作用是把参数截取到[0,1]的范围内，在计算点积时需要两者都处于同一坐标空间下，这里选择的是世界坐标系，这里相当于是对法线和光源进行归一化操作，并且保证结果不为负值
                fixed3 diffuse = _LightColor0.rgb * _Diffuse.rgb * saturate(dot(worldNormal, worldLight));
                //把环境光和漫反射光相加得到光照
                o.color = ambient + diffuse;
                //返回给片元着色器处理
                return o;
            }

            // 片元着色器, SV_TARGET描述片元着色器的输出颜色，它等同于告诉渲染器，把用户的输出颜色存储到一个渲染目标(render target),framebuffer rendertexture
            fixed3 frag(v2f i) : SV_TARGET
            {
                //输出顶点着色器计算出的颜色
                return fixed4(i.color, 1.0); 
            }
            
            ENDCG
        }
    }
    Fallback "Diffuse"
}
