Shader "Custom/BlockShader" {
	Properties
	{
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
	}
	SubShader
	{
		Pass {
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			struct appdata
			{
				float4 vertex : POSITION;
				fixed4 color : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
			    float4 vertex : SV_POSITION;
				fixed4 color : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			sampler2D _MainTex;
			fixed4 _Color;

			v2f vert(appdata IN)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, IN.vertex);
				o.color = IN.color;
				o.texcoord = IN.texcoord;
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.texcoord);

				if(col.r == 1 && col.g == 1 && col.b == 1)
				{
					col *= _Color;
				}

			    return col;
			}
			ENDCG
		}
	}
}