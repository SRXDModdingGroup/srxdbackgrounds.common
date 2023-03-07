#ifndef GET_WAVEFORM_VALUE_INCLUDE
#define GET_WAVEFORM_VALUE_INCLUDE

StructuredBuffer<float2> _WaveformCustom;

void GetWaveformValue_float(const float at, out float2 Out) {
    const float index = 256 * frac(at);
    const float2 first = _WaveformCustom[floor(index) % 256];
    const float2 second = _WaveformCustom[ceil(index) % 256];

    Out = lerp(first, second, frac(at));
}

#endif