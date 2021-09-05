Shader "Custom/BuildingShader"
{
    Properties
    {
	_MainTex("Texture", 2D) = "white" {}
	//_BumpMap("Bumpmap", 2D) = "bump" {}
	_Cube ("Cubemap", CUBE) = "" {}
        //_Color ("Color", Color) = (1,1,1,1)
        //_MainTex ("Albedo (RGB)", 2D) = "white" {}
        //_Glossiness ("Smoothness", Range(0,1)) = 0.5
        //_Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        //sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
	    //float2 uv_BumpMap;
	    float3 worldRefl;
	    //INTERNAL_DATA
        };

	sampler2D _MainTex;
	//sampler2D _BumpMap;
	samplerCUBE _Cube;
        //half _Glossiness;
        //half _Metallic;
        //fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
		o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb * 0.9;
		//o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));
		//o.Emission = texCube (_Cube, IN.worldrefl).rgb;
            // Albedo comes from a texture tinted by color
            //fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            //o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            //o.Metallic = _Metallic;
            //o.Smoothness = _Glossiness;
            //o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
