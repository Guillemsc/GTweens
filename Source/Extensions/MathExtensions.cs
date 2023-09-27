namespace GTweens.Extensions;

public static class MathExtensions
{
    public static float SafeDivide(float v1, float v2)
    {
        if (v2 == 0f)
        {
            return 0f;
        }

        return v1 / v2;
    }
}