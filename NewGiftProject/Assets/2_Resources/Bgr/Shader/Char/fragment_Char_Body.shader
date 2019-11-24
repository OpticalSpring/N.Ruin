// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/fragmentShader/Char/Body"
{
	Properties
	{
		//texture
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Main Texture", 2D) = "white" {}
		_MainTex2("Main Texture", 2D) = "white" {}

		//outline
		_OutlineColor("아웃라인 컬러", Range(0,1)) = 0
		_Outline("아웃라인 두께", Range(.001, 0.1)) = .005
		
		//ambient
		[HDR] _AmbientColor("Ambient Color", Color) = (1,1,1,1)

		//ndotl
		_ToonLine ("ToonLine", Range(0, 1)) = 0.01

		//rim
		_RimColor("Rim Color", Color) = (1,1,1,1)
		_RimAmount("Rim Amount", Range(0, 1)) = 0.5
		_RimPow("Rim Pow", Range(0, 1)) = 0.1

		//피격 상태
		_SickColor ("피격상태 컬러", Color) = (0.65,0.65,0.65,1)
		[Toggle]_SickButton("피격 상태",Range(0,1)) = 0
	}

	SubShader
	{
		Pass /// 1st pass outline/////
		{

		Tags
		{
			"Queue" = "Opaque"
		}
			cull front

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float3 normal:NORMAL;
			};

			struct v2f
			{
				float4 color : COLOR;
				float4 vertex:SV_POSITION;
				float3 normal:NORMAL;
			};

			sampler2D _MainTex;
			fixed4 _MainTex_ST;
			uniform float _Outline;
			uniform float4 _OutlineColor;
			fixed4 _SickColor; half _SickButton;

			v2f vert(appdata_full v)
			{
				v2f o;
				//float4 clipPosition = UnityObjectToClipPos(position);
				//float3 clipNormal = mul((float3x3) UNITY_MATRIX_VP, mul((float3x3) UNITY_MATRIX_M, normal));
				//clipPosition.xyz += normalize(clipNormal) * _OutlineWidth;
				//return clipPosition;

				o.vertex = UnityObjectToClipPos(v.vertex);
				float3 norm = mul((float3x3) UNITY_MATRIX_MVP, v.normal).xyz;
				float2 offset = normalize(norm.xy) * _Outline * o.vertex.w;
				o.vertex.xy += offset;
				return o;
			}

			//pixel shader
			half4 frag(v2f i) :COLOR
			{
				float alpha;
				//final
				float4 final;
				final.rgb = float3(0,0,0);
				final.a = 1;
				return final;
			}
			ENDCG
	}


		Pass   ////////////////////2nd pass /////////////////////
		{
			Tags
			{
				"LightMode" = "ForwardBase"
				"PassFlags" = "OnlyDirectional"
			}
			cull back

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fwdbase
			
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "AutoLight.cginc"

			struct appdata
			{
				float4 vertex : POSITION;				
				float4 uv : TEXCOORD0;
				
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;

				float3 worldNormal : NORMAL;
				float3 viewDir : TEXCOORD1;	

				SHADOW_COORDS(2)
			};


			sampler2D _MainTex, _MainTex2;
			float4 _MainTex_ST, _MainTex2_ST;

			fixed4 _Color, _SickColor;
			fixed4 _AmbientColor;

			fixed4 _RimColor;
			half _RimAmount, _RimPow;

			half _ToonLine;
			
			half _SickButton;

			v2f vert (appdata v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);

				o.worldNormal = UnityObjectToWorldNormal(v.normal);
				o.viewDir = WorldSpaceViewDir(v.vertex);
	
				TRANSFER_SHADOW(o)
				return o;
			}
			
			float4 frag (v2f i) : SV_Target
			{
				float3 normal = normalize(i.worldNormal);
				float3 viewDir = normalize(i.viewDir);
				float4 col = tex2D(_MainTex, i.uv)* _Color;
				float4 mask = tex2D(_MainTex2, i.uv);
				float alpha;


				//ndotl
				float ndotl = dot(viewDir, normal);
				ndotl *= mask.a;

				float shadow = SHADOW_ATTENUATION(i);

				float lightIntensity = smoothstep(0, _ToonLine, ndotl * shadow);
				float4 light = lightIntensity * _LightColor0;
				
				//rim
				float rim = 1 - dot(viewDir, normal);
				float rimIntensity = rim * pow(ndotl, _RimPow);
				rimIntensity = smoothstep(_RimAmount - 0.01, _RimAmount + 0.01, rimIntensity);
				float4 rimColor = rimIntensity * _RimColor;
				
				//sick
				float3 sickColor;
				float sick = saturate(dot(normal, viewDir));
				sickColor.rgb = _SickColor;

				//final
				float4 final;
				final.rgb =saturate((light +  _AmbientColor + rimColor) * col + (sickColor*_SickButton));
				final.a =1;

				return final;
			}
			ENDCG
		}

        UsePass "Legacy Shaders/VertexLit/SHADOWCASTER"
	}
}