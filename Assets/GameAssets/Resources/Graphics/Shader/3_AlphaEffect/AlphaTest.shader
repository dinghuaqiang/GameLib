/*
    Alpha Test
**/

Shader "GameLib/Tex/SingleTex"
{
    Properties
    {
        
    }

    SubShader
    {
        Pass
        {
            Tags { "LightModel"="ForwardBase" }
            ZWrite off

            CGPROGRAM

            //引用Unity光照相关的内置变量，比如_LightColor0
            #include "Lighting.cginc"
            // Use shader model 3.0 target, to get nicer looking lighting
            #pragma target 3.0

            #pragma vertex vert
            #pragma fragment frag

            //顶点着色器的输入输出结构体(也是片元着色器的输入结构体)
			struct a2v
			{
				float4 vertex  : POSITION;
				float3 normal  : NORMAL;
				float4 texcood : TEXCOORD0;  //填充uv0的数据到texcood变量中去【第一套UV坐标值】
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
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag(v2f f) : SV_TARGET
            {
                return fixed4(0,0,0,0);
            }

            ENDCG
        }
    }

    FallBack "Specular"
}