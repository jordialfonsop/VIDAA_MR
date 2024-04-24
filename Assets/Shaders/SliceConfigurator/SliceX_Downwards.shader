Shader "Slices/X_Downwards" {
    Properties{
      _Color("Color", Color) = (1.0,1.0,1.0)
      _MainTex("Texture", 2D) = "white" {}
      _BumpMap("Bumpmap", 2D) = "bump" {}
      _Offset("Extrusion Amount", Range(97,202)) = 0
    }
        SubShader{
          Tags { "RenderType" = "Transparent" }
          Cull Off
          CGPROGRAM
          #pragma surface surf Lambert vertex:vert
          struct Input {
              float2 uv_MainTex;
              float2 uv_BumpMap;
              float3 worldPos;
              float3 objPos;
          };
          sampler2D _MainTex;
          sampler2D _BumpMap;
          float _Frequency;
          float _Offset;

          void vert(inout appdata_full v, out Input o) {
              UNITY_INITIALIZE_OUTPUT(Input, o);
              o.objPos = v.vertex;
          }

          void surf(Input IN, inout SurfaceOutput o) {
              clip(frac((IN.objPos.x + _Offset) * 0.001) - 0.15);
              o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
              o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
          }
          ENDCG
    }
        Fallback "Diffuse"
}
