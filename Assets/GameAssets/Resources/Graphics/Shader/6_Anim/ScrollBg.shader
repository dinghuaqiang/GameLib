/**
    滚动背景图
*/
Shader "GameLib/Anim/ScrollBg"
{
    Properties
    {
        //第一层纹理 较远的
        _MainTex ("MainTex", 2D) = "white" {}
        //第二层纹理 较近的
        _DetailTex ("DetailTex", 2D) = "white" {}
        //两张背景图的水平滚动速度
        _ScrollX ("MainTex Scroll Speed", Float) = 1.0
        _Scroll2X ("DetailTex Scroll Speed", Float) = 1.0
        //控制纹理的整体亮度
        _Multiplier ("Layer Multiplier", Float) = 1
    }
    SubShader
    {
        //序列帧图像通常包含透明通道，因此可以当成是一个半透明对象，这里使用半透明的设置来处理
        Tags { "RenderType"="Transparent" "Queue"="Transparent" "IgnoreProjector"="True" }
        LOD 100

        Pass
        {
            Tags { "LightMode" = "ForwardBase" }
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex;
			float4 _MainTex_ST;
            sampler2D _DetailTex;
			float4 _DetailTex_ST;
			float _ScrollX;
			float _Scroll2X;
			float _Multiplier;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float4 uv : TEXCOORD0;
            };

            v2f vert (appdata v)
            {
                v2f o;
                //把顶点变换到裁剪空间
                o.pos = UnityObjectToClipPos(v.vertex);
                /**
                    计算两层背景纹理的纹理坐标，先用TRANSFORM_TEX得到初始纹理坐标，然后利用_Time.y在水平方向上对纹理坐标进行偏移，达到滚动的效果
                    把两张纹理的纹理坐标存储在一个变量o.uv中，以减少占用的插值寄存器空间。
                */
                o.uv.xy = TRANSFORM_TEX(v.uv, _MainTex) + frac(float2(_ScrollX, 0.0) * _Time.y);
                o.uv.zw = TRANSFORM_TEX(v.uv, _DetailTex) + frac(float2(_Scroll2X, 0.0) * _Time.y);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                //对图片进行采样
                fixed4 mainTexLayer = tex2D(_MainTex, i.uv.xy);
                fixed4 detailTexLayer = tex2D(_DetailTex, i.uv.zw);
                //使用第二张图的alpha通道混合两张纹理
                fixed4 color = lerp(mainTexLayer, detailTexLayer, detailTexLayer.a);
                //调整背景亮度
                color.rgb *= _Multiplier;
                return color;
            }
            ENDCG
        }
    }
    Fallback "VertexLit"
}
