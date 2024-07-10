namespace CircularSlider.Maui;

public static class Utils
{
    private const double InRangeTolerance = 1e-15;

    public static double PointOnCircleToAngle(double cx, double cy, double x, double y)
    {
        var theta = ToDegrees(Math.Atan2(cy - y, cx - x)) % 360.0;
        if (theta < 0)
            theta += 360;
        return theta;
    }

    // Reference: https://math.stackexchange.com/questions/127613/closest-point-on-circle-edge-from-point-outside-inside-the-circle
    public static (double x, double y) PointOnCircle(double circleX, double circleY, double radius, double pointX, double pointY)
    {
        var xDiff = pointX - circleX;
        var yDiff = pointY - circleY;
        var sqrDiff = Math.Sqrt(Math.Pow(xDiff, 2) + Math.Pow(yDiff, 2));
        var cx = circleX + radius * (xDiff / sqrDiff);
        var cy = circleY + radius * (yDiff / sqrDiff);

        return (cx, cy);
    }

    public static double ToDegrees(double radians) => 180 / Math.PI * radians;

    public static double ToRadians(double x) => Math.PI / 180 * x;

    public static bool IsInRange(double from, double to, double angle)
    {
        var normalizedFrom = Modulo(from, 360.0);
        var normalizedTo = Modulo(to, 360.0);
        var normalizedAngle = Modulo(angle, 360.0);
        if (normalizedFrom < 0) normalizedFrom += 360;
        if (normalizedTo < 0) normalizedTo += 360;
        if (normalizedAngle < 0) normalizedAngle += 360;
        if (Math.Abs(normalizedFrom - normalizedTo) < InRangeTolerance)
        {
            if (to > from)
                return true;
            return Math.Abs(normalizedAngle - normalizedFrom) < InRangeTolerance;
        }
        if (normalizedTo < normalizedFrom)
            return normalizedAngle <= normalizedTo || from <= normalizedAngle;
        return normalizedFrom <= normalizedAngle && normalizedAngle <= normalizedTo;
    }

    public static double AbsoluteDiff(double a, double b)
    {
        var difference = b - a;
        while (difference < -180) difference += 360;
        while (difference > 180) difference -= 360;
        return difference;
    }

    public static double Modulo(double a, double b)
    {
        return a - b * Math.Floor(a / b);
    }
}
