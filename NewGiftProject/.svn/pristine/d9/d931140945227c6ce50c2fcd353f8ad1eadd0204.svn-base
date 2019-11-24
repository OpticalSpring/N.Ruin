Shader "Custom/Glass_Emission"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
        //_Alpha ("Alpha", Range(0,1)) = 0.0
		_Glossiness("Gloss", Range(0,1)) = 0.0
		_RimPow ("Rimpow", Range(0,10)) = 0
    }
    SubShader
    {
        Tags {"RenderType" = "Opaque"}
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard noshadow noambient nolightmap
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
			float3 worldRefl;
			float3 worldNormal, viewDir;
			INTERNAL_DATA
        };

        float _Glossiness;
        float _Metallic;
		float _RimPow, _Alpha;
        float4 _Color;

        UNITY_INSTANCING_BUFFER_START(Props)
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            //텍스쳐
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			
			o.Smoothness = _Glossiness;

			//림
			//o.Normal = n;
			float rim = dot(IN.worldNormal, IN.viewDir);
			rim = 1 - rim;
			rim = pow(rim, _RimPow);
			float3 finalRim = rim;
			o.Emission = _Color*rim;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
