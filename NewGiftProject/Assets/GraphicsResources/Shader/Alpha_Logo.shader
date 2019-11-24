Shader "Custom/Alpha_plants"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Emissionrange("Emission", Range(0,2)) = 0.0
		_Alpharange("Alpha", Range(0,1)) = 0.0

    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent"}
        LOD 200

		cull off

        CGPROGRAM
        #pragma surface surf Lambert noshadow noambient nolightmap alpha:fade
        #pragma target 3.0

        sampler2D _MainTex;
	float _Emissionrange, _Alpharange;

        struct Input
        {
            float2 uv_MainTex;
        };

        fixed4 _Color;

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
            o.Emission = c.rgb * _Emissionrange;
            o.Alpha = c.a*_Alpharange;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
