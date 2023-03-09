Shader "GameLib/Properties"
{
    Properties
    {
		//1. 数字和滑动条相关
		//测试Float类型
		//_MulScale ("MulScale", Float) = 0.2
		//测试Int类型
		//_OffsetNum ("OffsetNum", Int) = 2
		//测试区间选值
		_Range ("Range", Range(0.0, 5.0)) = 3.0

		//2. 贴图类型相关
		//2D贴图
		//_2D("Type2D", 2D) = "" {}
		//2D贴图
		//_3D ("Type3D", 3D) = "black" {}

		//3. 向量和颜色相关
		//Vector x y z w四个分量
		//_Vector ("Vector", Vector) = (2, 1, 1, 3)
		//颜色
        //_Color ("Color", Color) = (1,1,1,1)

		//tiling：重复次数（图片纹理的密集程度）offset：偏移量（一张图片纹理可以拖动，选择使用图片的某一部分）
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
		//平滑度（最小是磨砂质感，最大是光滑）
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
		//金属度
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

		//这里设置GUPInstance
        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
			//基础纹理贴图颜色，_Color调整色相
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
