//------------------------------------------------
//    高光反射光照实验
//    逐顶点方式
//    缺点：高光部分不平滑。主要是高光反射部分的计算是非线性的，而在顶点着色器中计算光照再进行插值是线性的，
//破坏了原计算的非线性关系，就会出现较大的视觉问题。
//------------------------------------------------
Shader "GameLib/Light/SpecularGlossVertex"
{
    Properties
    {
        //漫反射光颜色
        _Diffuse ("Diffuse", Color) = (1,1,1,1)
        //材质的高光反射颜色
        _Specular ("Specular", Color) = (1,1,1,1)
        //高光区域的大小
        _GlossArea ("GlossArea", Range(8.0, 256)) = 20
    }

    SubShader
    {
        Pass
        {
            Tags { "LightModel"="ForwardBase" }

            CGPROGRAM

            //引用Unity光照相关的内置变量，比如_LightColor0
            #include "Lighting.cginc"
            // Use shader model 3.0 target, to get nicer looking lighting
            #pragma target 3.0

            #pragma vertex vert
            #pragma fragment frag

            //颜色的范围在0-1之间，用fixed精度变量存储
            fixed4 _Diffuse;
            fixed4 _Specular;
            //光照区域的范围比较大，用float精度存储
            float _GlossArea;
            //顶点着色器的输入输出结构体(也是片元着色器的输入结构体)
            struct a2v
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 position : SV_POSITION;
                float3 color : COLOR;
            };

            v2f vert(a2v renderData)
            {
                v2f o;
                //将顶点从模型空间转换到观察空间 UnityObjectToClipPos代替mul(UNITY_MATRIX_MVP, renderData.vertex)
                o.position = UnityObjectToClipPos(renderData.vertex);
                //拿到环境光
                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz;
                //拿到世界空间的法线
                fixed3 worldNormal = normalize(vertData.worldNormal);
                //根据_WorldSpaceLightPos0归一化来获取世界空间中光源的方向
                fixed3 worldLightDir = normalize(_WorldSpaceLightPos0.xyz);
                //计算漫反射光
                fixed3 diffuse = _LightColor0.rgb * _Diffuse.rgb * saturate(dot(worldNormal, worldLightDir));
                //获取世界空间的反射光方向，reflect(i, n)函数, i是入射光方向，n是法线方向。返回光的反射反向
                //reflect函数的入射方向要求是由光源指向交点处，需要对worldLightDir取反后再传给reflect函数
                fixed3 reflectDir = normalize(reflect(-worldLightDir, worldNormal));
                //获取世界空间的视口方向 _WorldSpaceCameraPos得到摄像机位置，
                //把顶点位置从模型空间变换到世界空间下，再通过和相机位置相减就可得到世界空间下的视角方向
                fixed3 viewDir = normalize(_WorldSpaceCameraPos.xyz - mul(_Object2World, renderData.vertex).xyz);
                //计算高光,把参数代入高光反射公式
                fixed3 specular = _LightColor0.rgb * _Specular.rgb * pow(saturate(dot(reflectDir, viewDir)), _GlossArea);
                //求和，计算最终输出颜色
                0.color = ambient + diffuse + specular;
                return o;
            }

            fixed4 frag(v2f vertData) : SV_TARGET
            {
                return fixed4(vertData.color, 1.0);
            }

            ENDCG
        }
    }
    //设置Unity内置的高光回调
    FallBack "Specular"
}
