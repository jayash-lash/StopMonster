Shader "Unlit/TextureScrollY"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _TextureScroll ("Texture Y Scroll", Range(0, 10)) = 5
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
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _TextureScroll;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // apply texture scrolling
                float2 scrolledUV = i.uv;
                float scrollSpeed = _TextureScroll * _Time.y / 10;
                scrolledUV.y += scrollSpeed;

                // Wrap texture coordinates around [0, 1]
                scrolledUV.y = frac(scrolledUV.y);

                // sample the texture
                fixed4 col = tex2D(_MainTex, scrolledUV);

                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
