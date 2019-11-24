Shader "CameraShader/PostProcessShader"
{
	Properties
	{
		_MainTex("Main", 2D) = "white" {}
		_MainTex2("Hatch2", 2D) = "white" {}
		_MainTex3("Hatch3", 2D) = "white" {}
		_MainTex4("Hatch4", 2D) = "white" {}
		_MainTex5("Hatch5", 2D) = "white" {}
		_MainTex6("GlitchTex", 2D) = "white" {}
		_WhiteLevel("WhiteLevel_1", float) = 0
		_WhiteLevel2("WhiteLevel_2", float) = 0
		_ShadowThreshold("Shadow Threshold", float) = 0
		_ShadowThreshold2("Shadow Threshold", float) = 0
		_ShadowThreshold3("Shadow Threshold", float) = 0
		_ShadowThreshold4("Shadow Threshold", float) = 0
		//_DepthMul("Depth_Outline_Multiplier", float) = 0
		//_DepthPow("Depth_Outline_Bias", float) = 0
		//_NormalMul("Normal_Outline_Multiplier", float) = 0
		//_NormalPow("Normal_Outline_Bias", float) = 0
		//_OutlineWide("Outline Wide", float) = 0
		_Redch("GlitchRed", float) = 0
		_Greench("GlitchGreen", float) = 0
		_Bluech("GlitchBlue", float) = 0
		_zero("zero", float) = 0
		_outlineonoff("outline onoff", float) = 0
		_glipower("glitch power", float) = 0
		_glitchuv("glitch uv", float) = 0
		_GlitchflowSpeed("glitch flowspeed", float) = 0
	}
		SubShader
		{
			Cull Off ZWrite Off ZTest Always

			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag

				#include "UnityCG.cginc"

				struct appdata
				{
					float4 vertex : POSITION;
					float2 uv : TEXCOORD0;
				};

				struct v2f
				{
					float2 uv : TEXCOORD0;
					float4 vertex : SV_POSITION;
				};

				v2f vert(appdata v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = v.uv;
					return o;
				}

				sampler2D _MainTex, _MainTex2, _MainTex3, _MainTex4, _MainTex5, _CameraDepthNormalsTexture, _MainTex6;
				float _ShadowThreshold, _ShadowThreshold2, _ShadowThreshold3, _ShadowThreshold4, _WhiteLevel, _WhiteLevel2;
				//float _DepthMul, _DepthPow, _NormalMul, _NormalPow, _OutlineWide;
				float _Redch, _Greench, _Bluech, _zero, _glipower, _outlineonoff, _GlitchflowSpeed, _glitchuv;
				float4 _CameraDepthNormalsTexture_TexelSize;

				//void Compare(inout float depthOutline, inout float normalOutline, float baseDepth, float baseNormal, float2 uv, float2 offset)
				//{
				//	//neighborpixel
				//	float4 neighborDepthNormal = tex2D(_CameraDepthNormalsTexture, uv + _CameraDepthNormalsTexture_TexelSize.xy*offset);
				//	float3 neighborNormal;
				//	float neighborDepth;
				//	DecodeDepthNormal(neighborDepthNormal, neighborDepth, neighborNormal);
				//	neighborDepth = neighborDepth * _ProjectionParams.z;

				//	depthOutline += baseDepth - neighborDepth;

				//	float3 normalDifference = baseNormal - neighborNormal;
				//	normalOutline += normalDifference.r + normalDifference.g + normalDifference.b;

				//}


				fixed4 frag(v2f i) : SV_Target
				{
					//글리치
					fixed4 col = tex2D(_MainTex, i.uv);
					float2 newUV = i.uv + float2(0, -_Time.x * _GlitchflowSpeed);
					newUV.x *= _glitchuv;
					newUV.y *= _glitchuv;
					fixed4 GlitchTex = tex2D(_MainTex6, newUV);
					fixed4 colR = tex2D(_MainTex, i.uv + (GlitchTex.rgb * sin(_Time.y * 25 * _zero)) / (_Redch*_glipower)* _zero);
					fixed4 colG = tex2D(_MainTex, i.uv + (GlitchTex.rgb * cos(_Time.y * 25*_zero)) / (_Greench*_glipower)* _zero);
					fixed4 colB = tex2D(_MainTex, i.uv + (GlitchTex.rgb * tan(_Time.y * 25*_zero)) / (_Bluech*_glipower)* _zero);
					float3 Red = colR.rgb * float3(1, 0, 0);
					float3 Green = colG.rgb * float3(0, 1, 0);
					float3 Blue = colB.rgb * float3(0, 0, 1);
					

					//아웃라인//비활성화 시켰음

					//float4 depthNormal = tex2D(_CameraDepthNormalsTexture, i.uv);
					//float3 normal;
					//float depth;
					//DecodeDepthNormal(depthNormal, depth, normal);
					//depth = depth * _ProjectionParams.z;

					//float depthDifference = 0;
					//float normalDifference = 0;

					//8방향 확장
				
					//Compare(depthDifference, normalDifference, depth, normal, i.uv, float2(_OutlineWide, 0));
					//Compare(depthDifference, normalDifference, depth, normal, i.uv, float2(0, _OutlineWide));
					//Compare(depthDifference, normalDifference, depth, normal, i.uv, float2(-_OutlineWide, 0));
					//Compare(depthDifference, normalDifference, depth, normal, i.uv, float2(0, -_OutlineWide));
					//Compare(depthDifference, normalDifference, depth, normal, i.uv, float2(_OutlineWide / 1.414f, _OutlineWide / 1.414f));
					//Compare(depthDifference, normalDifference, depth, normal, i.uv, float2(-_OutlineWide / 1.414f, _OutlineWide / 1.414f));
					//Compare(depthDifference, normalDifference, depth, normal, i.uv, float2(_OutlineWide / 1.414f, -_OutlineWide / 1.414f));
					//Compare(depthDifference, normalDifference, depth, normal, i.uv, float2(-_OutlineWide / 1.414f, -_OutlineWide / 1.414f));

					//depthDifference = depthDifference * _DepthMul;
					//depthDifference = saturate(depthDifference);
					//depthDifference = pow(depthDifference, _DepthPow);

					//normalDifference = normalDifference * _NormalMul;
					//normalDifference = saturate(normalDifference);
					//normalDifference = pow(normalDifference, _NormalPow);
					//float outlineFinal = saturate(depthDifference + normalDifference);
					//outlineFinal = saturate(ceil(1 - outlineFinal)+_outlineonoff);
				


					//해칭 텍스쳐
					fixed4 Hatch1 = tex2D(_MainTex2, i.uv);
					fixed4 Hatch2 = tex2D(_MainTex3, i.uv);
					fixed4 Hatch3 = tex2D(_MainTex4, i.uv);
					fixed4 Hatch4 = tex2D(_MainTex5, i.uv);
					float4 tex = float4((Red + Green + Blue),1);
					//float4 tex2 = float4((Red + Green + Blue), 1);
					//float4 cell = ceil(tex2 * 5) / 5.0f;
					float4 texmain = float4((Red + Green + Blue), 1);
					float luminance = (tex.r * 0.29 + tex *0.59 + tex *0.12);


					//해칭 범위
					if (luminance > _ShadowThreshold) { tex.rgb = saturate(Hatch1.rgb + _WhiteLevel); }
					else if (luminance > _ShadowThreshold2) { tex.rgb = saturate(Hatch1.rgb + _WhiteLevel2); }
					else if (luminance > _ShadowThreshold3) { tex.rgb = saturate(Hatch2.rgb + _WhiteLevel2); }
					else if (luminance > _ShadowThreshold4) { tex.rgb = saturate(Hatch3.rgb + _WhiteLevel2); }
					else { tex.rgb = saturate(Hatch4.rgb + _WhiteLevel2); }
					tex.rgb = tex.rgb*texmain.rgb;


					//return tex*outlineFinal;
					return tex;

			}
			ENDCG
		}
		}
}
