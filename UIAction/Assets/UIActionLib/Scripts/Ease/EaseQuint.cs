using UnityEngine;
using System.Collections;

public partial class EaseActions<T>
{
    #region Quint
    public static float EaseInQuint(float _start, float _end, float _t)
    {
        _end -= _start;

        return _end * _t * _t * _t * _t * _t + _start;
    }
    public static float EaseOutQuint(float _start, float _end, float _t)
    {
        _t -= 1.0f;
        _end -= _start;

        return _end * (_t * _t * _t * _t * _t + 1.0f) + _start;
    }
    public static float EaseInOutQuint(float _start, float _end, float _t)
    {
        _t /= 0.5f;
        _end -= _start;

        if (_t < 1.0f)
            return _end / 2.0f * _t * _t * _t * _t * _t + _start;

        _t -= 2.0f;

        return _end / 2.0f * (_t * _t * _t * _t * _t + 2.0f) + _start;
    }
    public static Vector4 EaseInQuint(Vector4 _start, Vector4 _end, float _t)
    {
        Vector4 ret = new Vector4
        {
            x = EaseInQuint(_start.x, _end.x, _t),
            y = EaseInQuint(_start.y, _end.y, _t),
            z = EaseInQuint(_start.z, _end.z, _t),
            w = EaseInQuint(_start.w, _end.w, _t)
        };

        return ret;
    }
    public static Vector3 EaseInQuint(Vector3 _start, Vector3 _end, float _t)
    {
        Vector3 ret = new Vector3
        {
            x = EaseInQuint(_start.x, _end.x, _t),
            y = EaseInQuint(_start.y, _end.y, _t),
            z = EaseInQuint(_start.z, _end.z, _t),
        };

        return ret;
    }
    public static Vector2 EaseInQuint(Vector2 _start, Vector2 _end, float _t)
    {
        Vector2 ret = new Vector2
        {
            x = EaseInQuint(_start.x, _end.x, _t),
            y = EaseInQuint(_start.y, _end.y, _t),
        };

        return ret;
    }
    public static Color EaseInQuint(Color _start, Color _end, float _t)
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
    public static Vector4 EaseOutQuint(Vector4 _start, Vector4 _end, float _t)
    {
        Vector4 ret = new Vector4
        {
            x = EaseOutQuint(_start.x, _end.x, _t),
            y = EaseOutQuint(_start.y, _end.y, _t),
            z = EaseOutQuint(_start.z, _end.z, _t),
            w = EaseOutQuint(_start.w, _end.w, _t)
        };

        return ret;
    }
    public static Vector3 EaseOutQuint(Vector3 _start, Vector3 _end, float _t)
    {
        Vector3 ret = new Vector3
        {
            x = EaseOutQuint(_start.x, _end.x, _t),
            y = EaseOutQuint(_start.y, _end.y, _t),
            z = EaseOutQuint(_start.z, _end.z, _t),
        };

        return ret;
    }
    public static Vector2 EaseOutQuint(Vector2 _start, Vector2 _end, float _t)
    {
        Vector2 ret = new Vector2
        {
            x = EaseOutQuint(_start.x, _end.x, _t),
            y = EaseOutQuint(_start.y, _end.y, _t),
        };

        return ret;
    }
    public static Color EaseOutQuint(Color _start, Color _end, float _t)
    {
        Color ret = new Color
        {
            r = EaseOutQuint(_start.r, _end.r, _t),
            g = EaseOutQuint(_start.g, _end.g, _t),
            b = EaseOutQuint(_start.b, _end.b, _t),
            a = EaseOutQuint(_start.a, _end.a, _t)
        };

        return ret;
    }
    public static Vector4 EaseInOutQuint(Vector4 _start, Vector4 _end, float _t)
    {
        Vector4 ret = new Vector4
        {
            x = EaseInOutQuint(_start.x, _end.x, _t),
            y = EaseInOutQuint(_start.y, _end.y, _t),
            z = EaseInOutQuint(_start.z, _end.z, _t),
            w = EaseInOutQuint(_start.w, _end.w, _t)
        };

        return ret;
    }
    public static Vector3 EaseInOutQuint(Vector3 _start, Vector3 _end, float _t)
    {
        Vector3 ret = new Vector3
        {
            x = EaseInOutQuint(_start.x, _end.x, _t),
            y = EaseInOutQuint(_start.y, _end.y, _t),
            z = EaseInOutQuint(_start.z, _end.z, _t),
        };

        return ret;
    }
    public static Vector2 EaseInOutQuint(Vector2 _start, Vector2 _end, float _t)
    {
        Vector2 ret = new Vector2
        {
            x = EaseInOutQuint(_start.x, _end.x, _t),
            y = EaseInOutQuint(_start.y, _end.y, _t),
        };

        return ret;
    }
    public static Color EaseInOutQuint(Color _start, Color _end, float _t)
    {
        Color ret = new Color
        {
            r = EaseInOutQuint(_start.r, _end.r, _t),
            g = EaseInOutQuint(_start.g, _end.g, _t),
            b = EaseInOutQuint(_start.b, _end.b, _t),
            a = EaseInOutQuint(_start.a, _end.a, _t)
        };

        return ret;
    }
    #endregion Quint
}
