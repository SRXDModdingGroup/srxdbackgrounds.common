#ifndef GET_SPECTRUM_VALUE_INCLUDE
#define GET_SPECTRUM_VALUE_INCLUDE

StructuredBuffer<float2> _SpectrumBandsCustom;

void GetSpectrumValue_float(const float at, out float2 Out) {
    const float index = 256 * frac(at);
    const float2 first = _SpectrumBandsCustom[floor(index) % 256];
    const float2 second = _SpectrumBandsCustom[ceil(index) % 256];

    Out = lerp(first, second, frac(index));
}

#endif