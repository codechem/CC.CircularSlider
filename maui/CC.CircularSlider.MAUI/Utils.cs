using System;

namespace CC;

public static class Utils
{
    public static double PointOnCircleToAngle(double cx, double cy, double x, double y)
    {
        var theta = ToDegrees(Math.Atan2(cy - y, cx - x)) % 360.0;
        if (theta < 0)
            theta += 360;
        return theta;
    }

    // Reference: https://math.stackexchange.com/questions/127613/closest-point-on-circle-edge-from-point-outside-inside-the-circle
    public static (double x, double y) PointOnCircle(double circleX, double circleY, double radius, double pointX,
        double pointY)
    {
        var xDiff = pointX - circleX;
        var yDiff = pointY - circleY;
        var sqrDiff = Math.Sqrt(Math.Pow(xDiff, 2) + Math.Pow(yDiff, 2));
        var cx = circleX + radius * (xDiff / sqrDiff);
        var cy = circleY + radius * (yDiff / sqrDiff);

        return (cx, cy);
    }

    public static double ToDegrees(double radians) => (180 / Math.PI) * radians;

    public static double ToRadians(double x) => (Math.PI / 180) * x;

    public static bool IsInRange(double from, double to, double angle)
    {
        var _from = Modulo(from, 360.0);
        var _to = Modulo(to, 360.0);
        var _angle = Modulo(angle, 360.0);
        if (_from < 0) _from += 360;
        if (_to < 0) _to += 360;
        if (_angle < 0) _angle += 360;
        if (_from == _to)
        {
            if (to > from)
                return true;
            return _angle == _from;
        }

        if (_to < _from)
            return _angle <= _to || from <= _angle;
        return _from <= _angle && _angle <= _to;
    }

    public static double AbsoluteDiff(double a, double b)
    {
        double difference = b - a;
        while (difference < -180) difference += 360;
        while (difference > 180) difference -= 360;
        return difference;
    }

    public static double Modulo(double a, double b)
    {
        return a - b * Math.Floor(a / b);
    }
}