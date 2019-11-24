Shader "Custom/Glass_transparent_emi_rim"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_BumpMap("Normal", 2D) = "Bump"{}
        _Alpha ("Alpha", Range(0,1)) = 0.0
		_Glossiness("Gloss", Range(0,1)) = 0.0
		_RimPow ("Rimpow", Range(0,10)) = 0
		_Emission("Emission", Range(0,10)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue" = "Transparent"}
        LOD 200
		GrabPass{}

        CGPROGRAM
        #pragma surface surf Standard noshadow noambient nolightmap alpha:fade
        #pragma target 3.0

        sampler2D _MainTex, _BumpMap;

        struct Input
        {
            float2 uv_BumpMap, uv_MainTex;
			float3 worldRefl;
			float3 worldNormal, viewDir;
			float4 screenPos;
			INTERNAL_DATA
        };

        float _Glossiness;
        float _Metallic;
		float _RimPow, _Alpha, _Emission;
        float4 _Color;

        UNITY_INSTANCING_BUFFER_START(Props)
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            //텍스쳐
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			float3 n = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));


			//림
			//o.Normal = n;
			float rim = dot(IN.worldNormal, IN.viewDir);
			rim = 1 - rim;
			rim = pow(rim, _RimPow);
			float3 finalRim = rim;

			//o.Albedo = c.rgb;
			//o.Smoothness = _Glossiness;
			//o.Emission = UNITY_SAMPLE_TEXCUBE(unity_SpecCube0, WorldReflectionVector(IN, o.Normal))*unity_SpecCube0_HDR.r;
            //o.Metallic = _Metallic;
			o.Emission = rim*_Color*_Emission;
            o.Alpha = rim;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
