/**
    表面着色器
    最重要的部分是两个结构体以及他们的编译命令。
    两个结构体是表面着色器中不同函数之前信息传递的桥梁。
    编译指令是我们和Unity沟通的重要手段。

    只能用于内置渲染管线，不适用于SRP,URP,HDRP

    Unity关于表面着色器的官方文档：
    https://docs.unity3d.com/cn/current/Manual/SL-SurfaceShaders.html
*/
Shader "GameLib/Surface/Diffuse"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _BumpMap ("Normalmap", 2D) = "bump" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        /**
            https://blog.csdn.net/qq_39574690/article/details/105589669
            控制使用的Shader的等级
            原理：只有Shader的LOD值小于某个设定的值，这个Shader才会被使用，如果使用了超过设定值的Shader就不会被渲染。

            在C#代码中使用如下两个赋值操作来设置允许的最大LOD值。
            FogShader.maximumLOD = 1000;
            Shader.globalMaximumLOD = 1000;

            Unity中的内置着色器通过以下方式设置其LOD：
            VertexLit着色器 = 100
            贴花，反射性顶点光 = 150
            漫射 = 200
            漫反射细节，反射凹凸未照明，反射凹凸VertexLit = 250
            凹凸，镜面反射 = 300
            凹凸镜面反射 = 400
            视差 = 500
            视差镜面反射 = 600
        */
        LOD 300

        CGPROGRAM
        /**
            编译指令最重要的作用是指明该表面着色器使用的 表面函数 和 光照函数并且设置一些可选参数。
            格式一般如下：
            #pragma surface surfaceFunction lightModel [optionalparams]
            说明：
            #pragma surface用于指明该编译指令是用于定义表面着色器的
            surfaceFunction 指明使用的表面函数 
                【基于物理的光照模型函数Standard和StandardSpecular】以及简单的非基于物理的光照模型函数Lambert和BlinnPhong。
                也可以自定义自己的光照函数：
                例如:
                //用于不依赖视角的光照模型，比如漫反射
                half4 Lighting<Name> (SurfaceOutput s, half3 lightDir, half atten);
                表面着色器中的自定义光照模型 
            lightModel 指明使用的光照模型 https://docs.unity3d.com/cn/current/Manual/SL-SurfaceShaderLighting.html
            optionalparams 使用可选参数来控制表面着色器的一些行为
        */
        // Physically based Standard lighting model, and enable shadows on all light types
        //#pragma surface surf Standard fullforwardshadows
        //#pragma surface surf Standard 
        #pragma surface surf Lambert
        //#pragma surface surf BlinnPhong 
        //#pragma surface surf StandardSpecular StandardSpecular

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _BumpMap;
        // 光照强度
        half _Glossiness;
        // 金属度
        half _Metallic;
        fixed4 _Color;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BumpMap;
        };

        //GPU Instance
        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        /**
            表面函数（函数名可以任意取）
            函数格式一般是固定的:
            void surf(Input IN, inout SurfaceOutput o)
            void surf(Input IN, inout SurfaceOutputStandard o)
            void surf(Input IN, inout SurfaceOutputStandardSpecular o)
        */
        // void surf (Input IN, inout SurfaceOutputStandard o)
        // {
        //     // Albedo comes from a texture tinted by color
        //     fixed4 texColor = tex2D (_MainTex, IN.uv_MainTex) * _Color;
        //     o.Albedo = texColor.rgb;
        //     // Metallic and smoothness come from slider variables
        //     o.Metallic = _Metallic;
        //     o.Smoothness = _Glossiness;
        //     o.Alpha = texColor.a * _Color.a;
        //     o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
        // }

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 texColor = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = texColor.rgb;
            o.Alpha = texColor.a * _Color.a;
            o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
        }

        // void surf (Input IN, inout SurfaceOutputStandardSpecular o)
        // {
        //     // Albedo comes from a texture tinted by color
        //     fixed4 texColor = tex2D (_MainTex, IN.uv_MainTex) * _Color;
        //     o.Albedo = texColor.rgb;
        //     // Metallic and smoothness come from slider variables
        //     //o.Metallic = _Metallic;
        //     o.Smoothness = _Glossiness;
        //     o.Alpha = texColor.a * _Color.a;
        //     o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
        // }
        ENDCG
    }
    FallBack "Diffuse"
}
