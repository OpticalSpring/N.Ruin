Shader "Custom/LEDBoard"
{
	Properties
	{
		_MainTex("TEX", 2D) = "white" {}
		_LEDTex("LEDTile",2D) = "white"{}
		_Tiling("Tiling",float) = 1
		_Brightness("Brightness",range(0,5)) = 1
		_UVX("UV.X",float) = 0
		_UVY("UV.Y",float) = 0
	}
		SubShader
		{
			Tags { "RenderType" = "Opaque" }
			LOD 200
			GrabPass{}

			CGPROGRAM
			#pragma surface surf Standard fullforwardshadows
			#pragma target 3.0

			sampler2D _MainTex, _GrabTexture;
			sampler2D _LEDTex;

			struct Input
			{
				float2 uv_MainTex;
				float2 uv_LEDTex;
				float4 screenPos;
			};

			float _Tiling;
			float _Brightness;
			float _UVX;
			float _UVY;

			void surf(Input IN, inout SurfaceOutputStandard o)
			{

				float4 c = tex2D(_MainTex,float2(_UVX, _UVY) + floor(IN.uv_MainTex*_Tiling) / (_Tiling));
				float4 d = tex2D(_LEDTex, IN.uv_LEDTex * _Tiling);
				o.Emission = c * d*_Brightness;
				o.Alpha = 1;
			}
			ENDCG
		}
			FallBack "Diffuse"
}

