sampler s0;
float Power;
float2 Resolution;
float cellSize;

// main
float4 PixelShaderFunction(float2 coords : TEXCOORD0, float2 pos : VPOS) : COLOR0
{
    float4 color = tex2D(s0, coords);
    
    
    float2 newUV = floor(coords * Resolution / cellSize) / Resolution * cellSize;
    
    float2 vec = float2(newUV.x - 0.5, newUV.y - 0.5);
    float dist = sqrt(pow(vec.x, 2) + pow(vec.y, 2));
    
    color.rgb = color.rgb - dist * Power;
    
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