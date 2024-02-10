sampler s0;
float Power;
float2 Resolution;
float cellSize;

// main
float4 PixelShaderFunction(float2 uv : TEXCOORD0, float2 pos : VPOS) : COLOR0
{
    float2 newUV = floor(uv * Resolution / cellSize) / Resolution * cellSize;
  
    float4 color = tex2D(s0, newUV);
    
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