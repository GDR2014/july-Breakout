Shader "Custom/SolidColor" 
{
	Properties {
        _MainTex ("Alpha (A)", 2D) = "white" {}
        _Color ("Color", Color) = (1.0, 1.0, 1.0, 1.0)
    }
    SubShader {
        Pass {
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

			uniform sampler2D _MainTex;
			float4 _Color;

            struct vertOut {
                float4 pos : SV_POSITION;
                float4 texcoord0 : TEXCOORD0;
            };

            vertOut vert(appdata_base v) {
                vertOut o;
                o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
                o.texcoord0 = v.texcoord;
                return o;
            }


            fixed4 frag(vertOut i) : COLOR {
                return float4(_Color.rgb, tex2D(_MainTex, i.texcoord0).a);
            }

            ENDCG
        }
    }
}