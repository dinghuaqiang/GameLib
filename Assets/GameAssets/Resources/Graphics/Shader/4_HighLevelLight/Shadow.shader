// Upgrade NOTE: replaced '_LightMatrix0' with 'unity_WorldToLight'

Shader "GameLib/HighLevelLight/Shadow"
{
    Properties
    {
        _Diffuse ("Diffuse", Color) = (1, 1, 1, 1)
        _Specular ("Specular", Color) = (1, 1, 1, 1)
        _Gloss ("Gloss", Range(8.0, 256)) = 20
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }

        //BasePass 处理环境光和平行光
        Pass
        {
            Tags { "LightMode" = "ForwardBase" }

            CGPROGRAM
            // 保证在使用光照衰减等光照变量可以被正确赋值
            #pragma multi_compile_fwdbase

            #pragma vertex vert
            #pragma fragment frag

            #include "Lighting.cginc"
            #include "AutoLight.cginc"

            fixed4 _Diffuse;
            fixed4 _Specular;
            float _Gloss;

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 worldNormal : TEXCOORD0;
                float3 worldPos : TEXCOORD1;
                //这个宏就是声明一个用于对阴影纹理采样的坐标。参数是下一个可用的插值寄存器的索引值。这个宏就是声明了一个_ShadowCoord的阴影纹理坐标变量。
                SHADOW_COORDS(2)
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                //这个宏用于在顶点着色器中计算声明的阴影纹理坐标传递给片元着色器。可用看下AutoLight.cginc的定义，根据不同的平台会有不同的处理，要注意vertex一定要写对
                TRANSFER_SHADOW(o);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed3 worldNormal = normalize(i.worldNormal);
                fixed3 worldLightDir = UnityWorldSpaceLightDir(i.worldPos);
                fixed3 diffuse = _LightColor0.rgb * _Diffuse.rgb * max(0, dot(worldNormal, worldLightDir));

                fixed3 viewDir = UnityWorldSpaceViewDir(i.worldPos);
                fixed3 halfDir = normalize(worldLightDir + viewDir);
                fixed3 specular = _LightColor0.rgb * _Specular.rgb * pow(max(0, dot(worldNormal, halfDir)), _Gloss);

                //环境光
                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz;
                // float atten = 1.0;
                // //计算光源的阴影
                // fixed shadow = SHADOW_ATTENUATION(i);
                // return fixed4(ambient + (diffuse + specular) * atten * shadow, 1.0);

                //使用UNITY_LIGHT_ATTENUATION宏计算光照衰减和阴影，会将光照衰减和阴影值相乘后的结果存储到第一个参数中。这里可以不用声明第一个参数atten,宏会自己声明这个变量。
                //第二个参数是v2f,这个参数会传递给SHADOW_ATTENUATION宏用来计算阴影值。
                //第三个参数是世界空间的坐标，会用来计算光源空间下的坐标，在对光照衰减纹理采样来得到光照衰减。
                UNITY_LIGHT_ATTENUATION(atten, i, i.worldPos);
                return fixed4(ambient + (diffuse + specular) * atten, 1.0);
            }
            ENDCG
        }

        //Additional Pass 处理其他类型的光源
        Pass
        {
            Tags { "LightMode" = "ForwardAdd" }
            Blend One One

            CGPROGRAM
            #include "Lighting.cginc"
			#include "AutoLight.cginc"

            #pragma vertex vert
			#pragma fragment frag
            #pragma multi_compile_fwdadd

            fixed4 _Diffuse;
            fixed4 _Specular;
            float _Gloss;

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 worldNormal : TEXCOORD0;
                float3 worldPos : TEXCOORD1;
                SHADOW_COORDS(2)
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                TRANSFER_SHADOW(o);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed3 worldNormal = normalize(i.worldNormal);
                fixed3 worldLightDir = UnityWorldSpaceLightDir(i.worldPos);
                fixed3 diffuse = _LightColor0.rgb * _Diffuse.rgb * max(0, dot(worldNormal, worldLightDir));

                fixed3 viewDir = UnityWorldSpaceViewDir(i.worldPos);
                fixed3 halfDir = normalize(worldLightDir + viewDir);
                fixed3 specular = _LightColor0.rgb * _Specular.rgb * pow(max(0, dot(worldNormal, halfDir)), _Gloss);

                /**
                    //利用数学公式来计算衰减值
                    float distance = length(_WorldSpaceLightPos0.xyz - i.worldPosition.xyz);
                    fixed atten = 1.0 / distance;
                    Unity无法在Shader中通过内置变量得到光源的范围。聚光灯的朝向、张开角度等信息，很多效果表现就不尽人意了。
                   （比如不在光照范围内的时候，Unity不会为物体执行AdditionalPass）.虽然可以通过代码设置值给Shader，但是灵活性就很低。
                */

                // //处理不同光源的衰减
				// #ifdef USING_DIRECTIONAL_LIGHT
                //     //如果是平行光，衰减设定为1
				// 	fixed atten = 1.0;
				// #else
				// 	#if defined (POINT)
                //         //https://blog.csdn.net/m0_51007980/article/details/127017235
                //         //_LightTexture0就是光照衰减纹理，通过采样该纹理的光照衰减通道来获取到衰减值
                //         //对于衰减纹理，越靠近（0，0）越亮，越靠近（1，1）越暗，纵轴没有变化，可以在横轴和对角线上进行采样，在对角线上采样会让光照衰减更加平滑。
                //         //通过unity_WorldToLight(_LightMatrix0)变换矩阵得到该点在光源空间中的位置，这个矩阵可以把顶点从世界空间变换到光源空间。
                //         //这里把unity_WorldToLight(_LightMatrix0)和世界空间中的顶点坐标相乘得到光源空间中的相对应的位置
				//         float3 lightCoord = mul(unity_WorldToLight, float4(i.worldPos, 1)).xyz;
                //         //使用这个坐标的模的平方对衰减纹理进行采样，得到衰减值
                //         //这里使用光源空间中顶点距离的平方(dot函数得到)来对纹理采样，然后使用宏UNITY_ATTEN_CHANNEL来得到衰减纹理中衰减值所在的分量，得到最终的衰减值
				//         fixed atten = tex2D(_LightTexture0, dot(lightCoord, lightCoord).rr).UNITY_ATTEN_CHANNEL;
				//     #elif defined (SPOT)
				//         float4 lightCoord = mul(unity_WorldToLight, float4(i.worldPos, 1));
				//         fixed atten = (lightCoord.z > 0) * tex2D(_LightTexture0, lightCoord.xy / lightCoord.w + 0.5).w * tex2D(_LightTextureB0, dot(lightCoord, lightCoord).rr).UNITY_ATTEN_CHANNEL;
				//     #else
				//         fixed atten = 1.0;
				//     #endif
				// #endif
                UNITY_LIGHT_ATTENUATION(atten, i, i.worldPos);
                return fixed4((diffuse + specular) * atten, 1.0);
            }

            ENDCG
        }
    }
    Fallback "Specular"
}
