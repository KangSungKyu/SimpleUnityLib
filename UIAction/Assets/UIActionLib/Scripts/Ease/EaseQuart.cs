using UnityEngine;
using System.Collections;

public partial class EaseActions<T>
{
    #region Quart
    public static float EaseInQuart(float _start, float _end, float _t)
    {
        _end -= _start;

        return _end * _t * _t * _t * _t + _start;
    }
    public static float EaseOutQuart(float _start, float _end, float _t)
    {
        _t -= 1.0f;
        _end -= _start;

        return -_end * (_t * _t * _t * _t - 1.0f) + _start;
    }
    public static float EaseInOutQuart(float _start, float _end, float _t)
    {
        _t /= 0.5f;
        _end -= _start;

        if (_t < 1.0f)
            return _end / 2.0f * _t * _t * _t * _t + _start;

        _t -= 2.0f;

        return -_end / 2.0f * (_t * _t * _t * _t - 2.0f) + _start;

    }
    public static Vector4 EaseInQuart(Vector4 _start, Vector4 _end, float _t)
    {
        Vector4 ret = new Vector4
        {
            x = EaseInQuart(_start.x, _end.x, _t),
            y = EaseInQuart(_start.y, _end.y, _t),
            z = EaseInQuart(_start.z, _end.z, _t),
            w = EaseInQuart(_start.w, _end.w, _t)
        };

        return ret;
    }
    public static Vector3 EaseInQuart(Vector3 _start, Vector3 _end, float _t)
    {
        Vector3 ret = new Vector3
        {
            x = EaseInQuart(_start.x, _end.x, _t),
            y = EaseInQuart(_start.y, _end.y, _t),
            z = EaseInQuart(_start.z, _end.z, _t),
        };

        return ret;
    }
    public static Vector2 EaseInQuart(Vector2 _start, Vector2 _end, float _t)
    {
        Vector2 ret = new Vector2
        {
            x = EaseInQuart(_start.x, _end.x, _t),
            y = EaseInQuart(_start.y, _end.y, _t),
        };

        return ret;
    }
    public static Color EaseInQuart(Color _start, Color _end, float _t)
    {
        Color ret = new Color
        {
            r = EaseInQuart(_start.r, _end.r, _t),
            g = EaseInQuart(_start.g, _end.g, _t),
            b = EaseInQuart(_start.b, _end.b, _t),
            a = EaseInQuart(_start.a, _end.a, _t)
        };

        return ret;
    }
    public static Vector4 EaseOutQuart(Vector4 _start, Vector4 _end, float _t)
    {
        Vector4 ret = new Vector4
        {
            x = EaseOutQuart(_start.x, _end.x, _t),
            y = EaseOutQuart(_start.y, _end.y, _t),
            z = EaseOutQuart(_start.z, _end.z, _t),
            w = EaseOutQuart(_start.w, _end.w, _t)
        };

        return ret;
    }
    public static Vector3 EaseOutQuart(Vector3 _start, Vector3 _end, float _t)
    {
        Vector3 ret = new Vector3
        {
            x = EaseOutQuart(_start.x, _end.x, _t),
            y = EaseOutQuart(_start.y, _end.y, _t),
            z = EaseOutQuart(_start.z, _end.z, _t),
        };

        return ret;
    }
    public static Vector2 EaseOutQuart(Vector2 _start, Vector2 _end, float _t)
    {
        Vector2 ret = new Vector2
        {
            x = EaseOutQuart(_start.x, _end.x, _t),
            y = EaseOutQuart(_start.y, _end.y, _t),
        };

        return ret;
    }
    public static Color EaseOutQuart(Color _start, Color _end, float _t)
    {
        Color ret = new Color
        {
            r = EaseOutQuart(_start.r, _end.r, _t),
            g = EaseOutQuart(_start.g, _end.g, _t),
            b = EaseOutQuart(_start.b, _end.b, _t),
            a = EaseOutQuart(_start.a, _end.a, _t)
        };

        return ret;
    }
    public static Vector4 EaseInOutQuart(Vector4 _start, Vector4 _end, float _t)
    {
        Vector4 ret = new Vector4
        {
            x = EaseInOutQuart(_start.x, _end.x, _t),
            y = EaseInOutQuart(_start.y, _end.y, _t),
            z = EaseInOutQuart(_start.z, _end.z, _t),
            w = EaseInOutQuart(_start.w, _end.w, _t)
        };

        return ret;
    }
    public static Vector3 EaseInOutQuart(Vector3 _start, Vector3 _end, float _t)
    {
        Vector3 ret = new Vector3
        {
            x = EaseInOutQuart(_start.x, _end.x, _t),
            y = EaseInOutQuart(_start.y, _end.y, _t),
            z = EaseInOutQuart(_start.z, _end.z, _t),
        };

        return ret;
    }
    public static Vector2 EaseInOutQuart(Vector2 _start, Vector2 _end, float _t)
    {
        Vector2 ret = new Vector2
        {
            x = EaseInOutQuart(_start.x, _end.x, _t),
            y = EaseInOutQuart(_start.y, _end.y, _t),
        };

        return ret;
    }
    public static Color EaseInOutQuart(Color _start, Color _end, float _t)
    {
        Color ret = new Color
        {
            r = EaseInOutQuart(_start.r, _end.r, _t),
            g = EaseInOutQuart(_start.g, _end.g, _t),
            b = EaseInOutQuart(_start.b, _end.b, _t),
            a = EaseInOutQuart(_start.a, _end.a, _t)
        };

        return ret;
    }
    #endregion Quart
}
