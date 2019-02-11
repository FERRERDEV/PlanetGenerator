Shader "Custom/ColorHeight"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _CenterPoint ("Center", Vector) = (0, 0, 0, 0)
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

        float minHeight;
        float maxHeight;
        
        sampler2D _MainTex;
        float4 _CenterPoint;
        
        struct Input
        {
            float3 worldPos;
        };

        float inverseLerp(float a, float b, float value)
        {
            return float((value-a)/(b-a));
        }

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            float distanceT = distance(_CenterPoint, IN.worldPos);
            float heightPercent = inverseLerp(minHeight, maxHeight, abs(distanceT));
            
            float2 pixelPos = float2(heightPercent, 1);
            float4 color = tex2D(_MainTex, pixelPos);
            
            o.Albedo = color;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
