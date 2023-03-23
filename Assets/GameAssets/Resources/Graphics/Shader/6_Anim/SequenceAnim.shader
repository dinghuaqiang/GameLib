/**
    序列帧动画
*/
Shader "GameLib/Anim/SequenceAnim"
{
    Properties
    {
        _Color ("Color", Color) = (1, 1, 1, 1)
        //关键帧纹理
        _MainTex ("MainTex", 2D) = "white" {}
        //水平方向关键帧图像的个数
        _HorizontalAmount ("Horizontal Amount", Float) = 4
        //垂直方向关键帧图像的个数
        _VerticalAmount ("Vertical Amount", Float) = 4
        //动画播放速度
        _Speed ("Speed", Range(0, 100)) = 30
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

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            fixed4 _Color;
			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _HorizontalAmount;
			float _VerticalAmount;
			float _Speed;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                //_Time.y是自该场景加载后所经过额度时间。把它和速度相乘来得到模拟的时间然后进行取整。
                float time = floor(_Time.y * _Speed);
                //当前行的索引
                float row = floor(time / _HorizontalAmount);
                //余数作为列的索引
                float column = time - row * _VerticalAmount;

                /**
                    这里使用行列索引得到真正的采样坐标。
                    因为包含了很多关键帧图形，意味着采样坐标需要映射到每个关键帧图形的坐标范围内。
                    把原纹理坐标i.uv按行数和列数进行等分，得到每个子图像的纹理坐标。
                    注意：
                    垂直方向的坐标便宜需要使用减法，因为在Unity中纹理坐标垂直方向的顺序(从下到上逐渐增大)和序列帧中的顺序(播放顺序从上到下)是相反的。
                */
                // half2 uv = float2(i.uv.x / _HorizontalAmount, i.uv.y / _VerticalAmount);
                // uv.x += column / _HorizontalAmount;
                // uv.y += row / _VerticalAmount;
                half2 uv = i.uv + half2(column, -row);
                uv.x /= _HorizontalAmount;
                uv.y /= _VerticalAmount;
                //根据小图的纹理坐标进行采样混合颜色
                fixed4 col = tex2D(_MainTex, uv);
                col.rgb *= _Color;
                return col;
            }
            ENDCG
        }
    }
    Fallback "Transparent/VertexLit"
}
