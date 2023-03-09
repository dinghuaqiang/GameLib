//------------------------------------------------
//    逐像素光照测试，实现逐像素的漫反射光照
//------------------------------------------------
Shader "GameLib/Light/DiffuseFragLevel"
{
    Properties
    {
        _DiffuseColor ("DiffuseColor", Color) = (1,1,1,1)
    }

    SubShader
    {
        Pass
        {
            Tags { "LightModel"="ForwardBase" }

            CGPROGRAM

            #include "Lighting.cginc"
            // Use shader model 3.0 target, to get nicer looking lighting
            #pragma target 3.0

            #pragma vertex vert
            #pragma fragment frag

            fixed4 _DiffuseColor;

            struct a2v
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 position : SV_POSITION;
                float3 worldNormal : TEXCOORD0;
            };

            v2f vert(a2v renderData)
            {
                v2f o;
                //将顶点从模型空间转换到观察空间 UnityObjectToClipPos代替mul(UNITY_MATRIX_MVP, renderData.vertex)
                o.position = UnityObjectToClipPos(renderData.vertex);
                //将法线从模型空间转换到观察空间 UnityObjectToWorldNormal代替mul(renderData.normal, (float3x3)unity_WorldToObject))
                o.worldNormal = mul(renderData.normal, (float3x3)unity_WorldToObject);
                return o;
            }

            fixed4 frag(v2f vertData) : SV_TARGET
            {
                //拿到环境光
                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz;
                //拿到世界空间的法线
                fixed3 worldNormal = normalize(vertData.worldNormal);
                //根据_WorldSpaceLightPos0归一化来获取世界空间中光源的方向
                fixed3 worldLightDir = normalize(_WorldSpaceLightPos0.xyz);
                //计算漫反射的光
                fixed3 diffuse = _LightColor0.rgb * _DiffuseColor.rgb * saturate(dot(worldNormal, worldLightDir));
                //把环境光和漫反射光相加得到光照
                fixed3 color = ambient + diffuse;
                return fixed4(color, 1.0);
            }

            ENDCG
        }
    }

    FallBack "Diffuse"
}
