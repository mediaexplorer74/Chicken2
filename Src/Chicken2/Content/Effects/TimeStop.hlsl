sampler s0;
float Amount;

// main
float4 PixelShaderFunction(float2 coords : TEXCOORD0, float2 pos : VPOS) : COLOR0
{
    float4 color = tex2D(s0, coords);
    
    float bnwValue = (color.r + color.g + color.b) / 3;
    float3 bnw;
    bnw.rgb = bnwValue;
    
    color.rgb = (color.rgb * Amount) + bnw * (1 - Amount);
    
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