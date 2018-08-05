// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "Custom/Terrain1" {
	Properties {
		_Color ("Main Color", Color) = (1,1,1,1)
		_MainTex ("Main Texture", 2D) = "white" {}
		_SecondColor ("Secondary Color", Color) = (1, 1, 1, 1)
		_SecondTex ("Secondary Texture", 2D) = "white" {}
		_BorderColor ("Border color", Color) = (0, 0, 0, 0)
		_BorderWidth ("Border width", float) = 1
		_MapTex ("Texture map", 2D) = "white" {}
	}

	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		#pragma surface surf Lambert

		fixed4 _Color;
		sampler2D _MainTex;
		fixed4 _SecondColor;
		sampler2D _SecondTex;
		fixed4 _BorderColor;
		float _BorderWidth;
		sampler2D _MapTex;

		struct Input {
			float2 uv_MainTex;
			float2 uv_MapTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			fixed4 c1 = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			fixed4 c2 = tex2D(_SecondTex, IN.uv_MainTex) * _SecondColor;
			o.Albedo = lerp(c1, c2, tex2D(_MapTex, IN.uv_MapTex));
	
			//o.Alpha = c.a;
		}
		ENDCG
	}

	Fallback "Legacy Shaders/VertexLit"
}
