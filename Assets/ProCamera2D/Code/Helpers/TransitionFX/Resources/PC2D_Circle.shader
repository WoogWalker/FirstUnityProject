// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "ProCamera2D/TransitionsFX/Circle" 
{
    Properties 
    {
        _MainTex("Base (RGB)", 2D) = "white" {}
        _Step ("Step", Range(0, 1)) = 0
        _BackgroundColor ("Background Color", Color) = (0, 0, 0, 1)
    }

    SubShader 
    {
        ZTest Always Cull Off ZWrite Off Fog{ Mode Off }

        Pass 
        {
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc" 

            uniform sampler2D _MainTex;
            uniform float _Step;
            uniform float4 _BackgroundColor;

            struct v2f 
			{
				float4 pos : POSITION;
				half2 uv : TEXCOORD0;
			};

			v2f vert(appdata_img v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = MultiplyUV(UNITY_MATRIX_TEXTURE0, v.texcoord.xy);
				return o;
			}

            float4 frag(v2f i) : COLOR 
            {
                float4 colour = _BackgroundColor;
                float aspectRatio = _ScreenParams.y / _ScreenParams.x;
                if (sqrt(pow(i.uv.x - 0.5, 2) + pow((i.uv.y - 0.5) * aspectRatio, 2) < 0.5 - (_Step / 2)))
                    colour = tex2D(_MainTex, i.uv);
                
                return colour;
            }

            ENDCG
        }
    }
}