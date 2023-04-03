/**
    光照探针的使用测试
    https://www.bilibili.com/read/cv17365012
    https://www.cnblogs.com/jietian331/p/17027019.html
*/
Shader "GameLib/ReflectionProbe"
{
    Properties
    {
        _CubeMap("Reflection Cubemap", Cube) = "" {}
        _Rotation("Rotation", Range(0, 360)) = 0
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 worldPos : TEXCOORD1;
                float3 worldNormal : TEXCOORD2;
            };

            samplerCUBE _CubeMap;
            float4 _CubeMap_HDR;
            float _Rotation;

            float3 RotateAroundY(float3 v, float angle)
            {
                angle = radians(angle);
                float2x2 m = float2x2(cos(angle), -sin(angle), sin(angle), cos(angle));
                float2 rotated = mul(m, v.xz);
                return float3(rotated.x, v.y, rotated.y);
            }

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float3 viewDir = normalize(_WorldSpaceCameraPos - i.worldPos);
                float3 reflectDir = reflect(-viewDir, i.worldNormal);
                float3 rotatedReflectDir = RotateAroundY(reflectDir, _Rotation);

                fixed4 cube = texCUBE(_CubeMap, rotatedReflectDir);

                return cube;
            }

            ENDCG
        }
    }

    FallBack "Diffuse"
}