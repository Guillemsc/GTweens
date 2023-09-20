using System.Drawing;

namespace GTweens.Extensions
{
    public static class SystemColorExtensions
    {
        public static Color FromRgba(float r, float g, float b, float a)
        {
            return Color.FromArgb(
                (int)(a * 255f),
                (int)(r * 255f),
                (int)(g * 255f),
                (int)(b * 255f)
            );
        }
        
        // public static Color ChangeAlpha(Color color, float alpha)
        // {
        //     color.A = alpha;
        //
        //     return color;
        // }
        //
        // public static Color ChangeColorKeepingAlpha(Color color, Color alphaToKeep)
        // {
        //     color.A = alphaToKeep.A;
        //
        //     return color;
        // }
    }
}