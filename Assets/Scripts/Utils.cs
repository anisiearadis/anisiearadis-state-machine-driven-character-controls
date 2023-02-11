public class Utils
{
    public static float EulerAngleNegative(float angle)
    {
        if (angle > 180f) angle -= 360;
        return angle;
    }
}