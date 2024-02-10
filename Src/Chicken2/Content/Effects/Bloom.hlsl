sampler s0;
float Threshold;
float2 Resolution;

// main
float4 PixelShaderFunction(float2 coords : TEXCOORD0, float2 pos : VPOS) : COLOR0
{
    float2 uv = coords / Resolution;
    float pixelSize = 1 / Resolution;
    
    float4 color = tex2D(s0, coords, 2, 2);
    //float4 highlights = float4(0, 0, 0, color.a);
    
    //if ((color.r + color.g + color.b) / 3 > Threshold)
    //    highlights.rgb = color.rgb;

    return color;
}

// Sends out the shader info to the engine
technique Technique1
{
    pass Pass1
    {
        PixelShader = compile ps_3_0 PixelShaderFunction();
    }
}