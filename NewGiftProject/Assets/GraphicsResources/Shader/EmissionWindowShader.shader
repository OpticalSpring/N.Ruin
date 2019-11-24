Shader "Custom/EmissionWindowShader"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_Emission("Emission", Range(0,2)) = 0.0
	}
		SubShader
	{
		Tags { "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows
		#pragma target 3.0

		struct Input
		{
			float2 uv_MainTex;
		};
		float _Emission;
		fixed4 _Color;

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			o.Emission = _Color * _Emission;
		}
		ENDCG
	}
		FallBack "Diffuse"
}
