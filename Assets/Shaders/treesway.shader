Shader "Custom/Tree Sway"
{
	Properties {
		_Color ("Main Color", Color) = (0.5,0.5,0.5,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Speed ("MoveSpeed", Range(20,50)) = 25 // speed of the swaying
		_Rigidness("Rigidness", Range(1,50)) = 25 // lower makes it look more "liquid" higher makes it look rigid
		_SwayMax("Sway Max", Range(0, 0.1)) = .005 // how far the swaying goes
		_YOffset("Y offset", float) = 0.5// y offset, above this is no animation
			
	}

	SubShader {
		Tags { "RenderType"="Opaque" "DisableBatching" = "True" }// disable batching lets us keep object space
		LOD 200

		
	CGPROGRAM
	#pragma surface surf BlinnPhong vertex:vert addshadow// addshadow applies shadow after vertex animation


	sampler2D _MainTex;
	float4 _Color;

	float _Speed;
	float _SwayMax;
	float _YOffset;
	float _Rigidness;


	struct Input {
		float2 uv_MainTex : TEXCOORD0;
	};
	void vert(inout appdata_full v)// 
	{
		float3 wpos = mul(unity_ObjectToWorld, v.vertex).xyz;// world position
		float x = sin(wpos.x / _Rigidness + (_Time.x * _Speed)) *(v.vertex.y - _YOffset) * 5;// x axis movements
		float z = sin(wpos.z / _Rigidness + (_Time.x * _Speed)) *(v.vertex.y - _YOffset) * 5;// z axis movements
		v.vertex.x += step(v.vertex.y - _YOffset, 0) * x * _SwayMax;// apply the movement if the vertex's y above the YOffset
		v.vertex.z += step(v.vertex.y - _YOffset, 0) * z * _SwayMax;
	}

	void surf (Input IN, inout SurfaceOutput o) {
		half4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
		o.Albedo = c.rgb;
		o.Alpha = c.a;
	}
	ENDCG

	}

	Fallback "Diffuse"
}