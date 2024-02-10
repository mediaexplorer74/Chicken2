sampler s0;
float NoiseSize;
float Time;


float hash(float n)
{
    return frac(sin(n) * 43758.5453);
}

// Noise algorith from https://stackoverflow.com/a/18424432
float pNoise(float3 x)
{
    // The noise function returns a value in the range -1.0f -> 1.0f

    float3 p = floor(x);
    float3 f = frac(x);

    f = f * f * (3.0 - 2.0 * f);
    float n = p.x + p.y * 57.0 + 113.0 * p.z;

    return lerp(lerp(lerp(hash(n + 0.0), hash(n + 1.0), f.x),
                   lerp(hash(n + 57.0), hash(n + 58.0), f.x), f.y),
               lerp(lerp(hash(n + 113.0), hash(n + 114.0), f.x),
                   lerp(hash(n + 170.0), hash(n + 171.0), f.x), f.y), f.z);
}

// main
float4 PixelShaderFunction(float2 coords : TEXCOORD0, float2 pos : VPOS) : COLOR0
{
    float3 noise = pNoise(float3(coords.x * NoiseSize, coords.y * NoiseSize, 0));
    float4 color = tex2D(s0, coords);
    
    return float4(noise.r, noise.g, noise.g, color.a);
}

// Sends out the shader info to the engine
technique Technique1
{
    pass Pass1
    {
        PixelShader = compile ps_3_0 PixelShaderFunction();
    }
}