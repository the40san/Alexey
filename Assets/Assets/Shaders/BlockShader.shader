Shader "Custom/BlockShader" {
	Properties
	{
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
	}
	SubShader
	{
			CGPROGRAM
			#pragma surface surf Lambert vertex:vert
			#include "UnityCG.cginc"

			struct Input
			{
				float2 uv_MainTex;
				fixed4 color;
			};


			sampler2D _MainTex;
			fixed4 _Color;

			void vert (inout appdata_full v, out Input o)
			{
				UNITY_INITIALIZE_OUTPUT(Input, o);
				o.color = v.color * _Color;
			}


			void surf (Input IN, inout SurfaceOutput o)
			{
				fixed4 col = tex2D(_MainTex, IN.uv_MainTex);

				if(col.r == 1 && col.g == 1 && col.b == 1)
				{
					col *= _Color;
				}

				o.Albedo = col.rgb * col.a;
				o.Alpha = col.a;
			}

			ENDCG
	}
}