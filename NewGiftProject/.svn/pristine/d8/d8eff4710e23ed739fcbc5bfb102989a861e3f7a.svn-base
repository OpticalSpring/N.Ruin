Shader "Custom/TestShader"
{
    Properties
    {
        _MainTex ("Waterrender", 2D) = "white" {}
		_MainTex2("Alpha", 2D) = "white" {}
		_MainTex3("Alpha", 2D) = "white" {}
		_BumpMap("BumpMap", 2D) = "bump"{}
		_Color("Color", Color) = (1,1,1,1)
		_Color2("Color", Color) = (1,1,1,1)
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_AlphaRange("AlphaRange", Range(0,1)) = 0
		//_RimPow("RimPow", Range(0,10)) = 0
		
    }
    SubShader
    {
		Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
		LOD 200

        CGPROGRAM
        #pragma surface surf Standard alpha:fade
        #pragma target 3.0

        sampler2D _MainTex, _MainTex2,_BumpMap,_MainTex3;
		half _Glossiness, _AlphaRange, _RimPow;
		float3 _Color, _Color2;

        struct Input
        {
            float2 uv_MainTex, uv_MainTex2,uv_BumpMap, uv_MainTex3;
			float3 viewDir;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
			fixed4 WaterRender = tex2D(_MainTex, float2(1-IN.uv_MainTex.x, IN.uv_MainTex.y));
			fixed4 WaterAlpha = tex2D(_MainTex2, float2(IN.uv_MainTex2.x, IN.uv_MainTex2.y));
			fixed3 WaterNormal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
			fixed4 Waterfresnel = tex2D(_MainTex3, float2(IN.uv_MainTex3.x, IN.uv_MainTex3.y));
			o.Emission = saturate((WaterRender.rgb-(_Color.rgb*(1-WaterAlpha.a)))+_Color2*WaterAlpha.a);
			o.Smoothness = _Glossiness*(1-WaterAlpha.a);
			o.Normal = WaterNormal.rgb;
		
			//림
			//float rim = dot(o.Normal, IN.viewDir);
			//rim = saturate(pow(1 - rim, _RimPow));
			//o.Alpha = saturate((WaterAlpha.a*rim) - _AlphaRange);
			o.Alpha = saturate(WaterAlpha.a*(1-Waterfresnel.r)- _AlphaRange);
        }
        ENDCG
    }
    FallBack "Diffuse"
}
