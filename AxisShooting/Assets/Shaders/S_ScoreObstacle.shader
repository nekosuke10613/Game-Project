Shader "Custom/S_ScoreObstacle" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_AfterTex("Albedo (RGB)", 2D) = "white" {}
		_AfterFlg("AfterFlag(0,1)",Float) = 0
		
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _AfterTex;

		struct Input {
			float2 uv_MainTex;
			float2 uv_AfterTex;
		};

		fixed4 _Color;
		int _AfterFlg;

		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			int flg = lerp(0,1,(step(_AfterFlg, 0.5)));

			fixed4 c = tex2D (lerp( _MainTex,_AfterTex,(step(flg,0.5))),lerp(IN.uv_MainTex, IN.uv_AfterTex, (step(flg, 0.5)))) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			
			o.Alpha = c.a;
		}
		ENDCG
	}
	
}
