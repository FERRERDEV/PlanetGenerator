using UnityEngine;

public class TextureUtils
{
    public static Texture2D TextureFromGradient (Gradient gradient, int width = 32, int height = 1) {
        var gradientTexture = new Texture2D(width, height, TextureFormat.ARGB32, false);
        gradientTexture.filterMode = FilterMode.Bilinear;
        float inv = 1f / (width - 1);
        
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                var t = x * inv;
                Color col = gradient.Evaluate(t);
                gradientTexture.SetPixel(x, y, col);
            }
        }
        gradientTexture.Apply();
        return gradientTexture;
    }
}
