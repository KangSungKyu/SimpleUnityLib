using UnityEngine;
using System.Collections;

public partial class EaseActions<T>
{
    #region Quad
    public static float EaseInQuad(float _start, float _end, float _t)
    {
        _end -= _start;

        return _end * _t * _t + _start;
    }
    public static float EaseOutQuad(float _start, float _end, float _t)
    {
        _end -= _start;

        return -_end * _t * (_t - 2.0f) + _start;
    }
    public static float EaseInOutQuad(float _start, float _end, float _t)
    {
        _t /= 0.5f;
        _end -= _start;

        if (_t < 1.0f)
            return _end / 2.0f * _t * _t + _start;

        _t -= 1.0f;

        return -_end / 2.0f * (_t * (_t - 2.0f) - 1.0f) + _start;
    }
    public static Vector4 EaseInQuad(Vector4 _start, Vector4 _end, float _t)
    {
        Vector4 ret = new Vector4
        {
            x = EaseInQuad(_start.x, _end.x, _t),
            y = EaseInQuad(_start.y, _end.y, _t),
            z = EaseInQuad(_start.z, _end.z, _t),
            w = EaseInQuad(_start.w, _end.w, _t)
        };

        return ret;
    }
    public static Vector3 EaseInQuad(Vector3 _start, Vector3 _end, float _t)
    {
        Vector3 ret = new Vector3
        {
            x = EaseInQuad(_start.x, _end.x, _t),
            y = EaseInQuad(_start.y, _end.y, _t),
            z = EaseInQuad(_start.z, _end.z, _t),
        };

        return ret;
    }
    public static Vector2 EaseInQuad(Vector2 _start, Vector2 _end, float _t)
    {
        Vector2 ret = new Vector2
        {
            x = EaseInQuad(_start.x, _end.x, _t),
            y = EaseInQuad(_start.y, _end.y, _t),
        };

        return ret;
    }
    public static Color EaseInQuad(Color _start, Color _end, float _t)
    {
        Color ret = new Color
        {
            r = EaseInQuad(_start.r, _end.r, _t),
            g = EaseInQuad(_start.g, _end.g, _t),
            b = EaseInQuad(_start.b, _end.b, _t),
            a = EaseInQuad(_start.a, _end.a, _t)
        };

        return ret;
    }
    public static Vector4 EaseOutQuad(Vector4 _start, Vector4 _end, float _t)
    {
        Vector4 ret = new Vector4
        {
            x = EaseOutQuad(_start.x, _end.x, _t),
            y = EaseOutQuad(_start.y, _end.y, _t),
            z = EaseOutQuad(_start.z, _end.z, _t),
            w = EaseOutQuad(_start.w, _end.w, _t)
        };

        return ret;
    }
    public static Vector3 EaseOutQuad(Vector3 _start, Vector3 _end, float _t)
    {
        Vector3 ret = new Vector3
        {
            x = EaseOutQuad(_start.x, _end.x, _t),
            y = EaseOutQuad(_start.y, _end.y, _t),
            z = EaseOutQuad(_start.z, _end.z, _t),
        };

        return ret;
    }
    public static Vector2 EaseOutQuad(Vector2 _start, Vector2 _end, float _t)
    {
        Vector2 ret = new Vector2
        {
            x = EaseOutQuad(_start.x, _end.x, _t),
            y = EaseOutQuad(_start.y, _end.y, _t),
        };

        return ret;
    }
    public static Color EaseOutQuad(Color _start, Color _end, float _t)
    {
        Color ret = new Color
        {
            r = EaseOutQuad(_start.r, _end.r, _t),
            g = EaseOutQuad(_start.g, _end.g, _t),
            b = EaseOutQuad(_start.b, _end.b, _t),
            a = EaseOutQuad(_start.a, _end.a, _t)
        };

        return ret;
    }
    public static Vector4 EaseInOutQuad(Vector4 _start, Vector4 _end, float _t)
    {
        Vector4 ret = new Vector4
        {
            x = EaseInOutQuad(_start.x, _end.x, _t),
            y = EaseInOutQuad(_start.y, _end.y, _t),
            z = EaseInOutQuad(_start.z, _end.z, _t),
            w = EaseInOutQuad(_start.w, _end.w, _t)
        };

        return ret;
    }
    public static Vector3 EaseInOutQuad(Vector3 _start, Vector3 _end, float _t)
    {
        Vector3 ret = new Vector3
        {
            x = EaseInOutQuad(_start.x, _end.x, _t),
            y = EaseInOutQuad(_start.y, _end.y, _t),
            z = EaseInOutQuad(_start.z, _end.z, _t),
        };

        return ret;
    }
    public static Vector2 EaseInOutQuad(Vector2 _start, Vector2 _end, float _t)
    {
        Vector2 ret = new Vector2
        {
            x = EaseInOutQuad(_start.x, _end.x, _t),
            y = EaseInOutQuad(_start.y, _end.y, _t),
        };

        return ret;
    }
    public static Color EaseInOutQuad(Color _start, Color _end, float _t)
    {
        Color ret = new Color
        {
            r = EaseInOutQuad(_start.r, _end.r, _t),
            g = EaseInOutQuad(_start.g, _end.g, _t),
            b = EaseInOutQuad(_start.b, _end.b, _t),
            a = EaseInOutQuad(_start.a, _end.a, _t)
        };

        return ret;
    }
    #endregion Quad
}
