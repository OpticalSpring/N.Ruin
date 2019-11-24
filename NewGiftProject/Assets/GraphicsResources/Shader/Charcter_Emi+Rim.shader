Shader "Custom/ser_2"
{
	Properties
	{
		_MainTex("Albedo (RGB)", 2D) = "black" {}
		_BumpMap("Normal", 2D) = "white"{}
		_MaskMap("MaskMap", 2D) = "black"{}
		_SpecularColor("SpecularColor", color) = (1,1,1,1)
		_SpecularColor2("SpecularColor2", color) = (1,1,1,1)
		_Specular("Spec", float) = 30
		_Specular2("Spec2", float) = 1
		_RimColor("RimColor", color) = (1,1,1,1)
		_RimPower("RimPower", float) = 1
	}
		SubShader
		{
			Tags { "RenderType" = "Opaque" }
			LOD 200
			Cull off

			CGPROGRAM
			#pragma surface surf JE 
			#pragma target 3.0
	

			sampler2D _MainTex, _BumpMap,_MaskMap;

			struct Input
			{
				float2 uv_MainTex, uv_BumpMap, uv_MaskMap;
			};
			float4 _SpecularColor, _SpecularColor2, _RimColor;
			float _Specular, _Specular2, _RimPower;

			void surf(Input IN, inout SurfaceOutput o)
			{
				float4 c = tex2D(_MainTex, IN.uv_MainTex);
				float3 normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
				float4 mask = tex2D(_MaskMap, IN.uv_MaskMap);
				o.Gloss = mask.a;

				o.Albedo = c.rgb;
				o.Alpha = c.a;
				o.Normal = normal;
			}



			float4 LightingJE(SurfaceOutput s, float3 lightDir, float3 viewDir, float atten) {

				//diffuse
				float3 diffC;
				float NdotL = saturate(dot(s.Normal, lightDir));
				diffC = NdotL * s.Albedo * _LightColor0.rgb * atten;


				//rimlight
				float3 rimC;
				float rim = dot(s.Normal, viewDir);
				float rim2 = pow(1 - abs(rim), _RimPower);

				//RIMCARTOON
				if (rim2 > 0.8) { 
					rim2 = 0.6; 
				}
				else if (rim2 > 0.5) { 
					rim2 = 0.3; 
				}
				else { 
					rim2 = 0; 
				}

				//rimfinal
				rimC = rim2 * _RimColor.rgb;

				//final
				float4 finalC;
				finalC.rgb = saturate(diffC + rimC);
				finalC.a = s.Alpha;

				return finalC;
			}





			ENDCG
		}
			FallBack "Diffuse"
}
