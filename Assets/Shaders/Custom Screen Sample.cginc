#ifndef SAMPLE_AFTER_POSTPROCESS_INCLUDED
#define SAMPLE_AFTER_POSTPROCESS_INCLUDED

void SampleAfterPostProcessTexture_float(float2 UV, out float4 Color)
{
    Color = UNITY_SAMPLE_SCREENSPACE_TEXTURE(_AfterPostProcessTexture, UV);
}

#endif