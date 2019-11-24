Shader "Custom/NolightBlack"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert
        #pragma target 3.0

        struct Input
        {
            float3 color:COLOR;
        };

		fixed4 _Color;

        void surf (Input IN, inout SurfaceOutput o)
        {

            o.Emission = _Color.rgb;
         
        }
        ENDCG
    }
    FallBack "Diffuse"
}
