using UnityEngine;
using System.Collections;

public partial class EaseActions<T>
{
    #region Cubic
    public static float EaseInCubic(float _start, float _end, float _t)
    {
        _end -= _start;

        return _end * _t * _t * _t + _start;
    }
    public static float EaseOutCubic(float _start, float _end, float _t)
    {
        _t -= 1.0f;
        _end -= _start;

        return _end * (_t * _t * _t + 1.0f) + _start;
    }
    public static float EaseInOutCubic(float _start, float _end, float _t)
    {
        _t /= 0.5f;
        _end -= _start;

        if (_t < 1.0f)
            return _end / 2.0f * _t * _t * _t + _start;

        _t -= 2.0f;

        return _end / 2.0f * (_t * _t * _t + 2.0f) + _start;
    }
    public static Vector4 EaseInCubic(Vector4 _start, Vector4 _end, float _t)
    {
        Vector4 ret = new Vector4
        {
            x = EaseInCubic(_start.x, _end.x, _t),
            y = EaseInCubic(_start.y, _end.y, _t),
            z = EaseInCubic(_start.z, _end.z, _t),
            w = EaseInCubic(_start.w, _end.w, _t)
        };

        return ret;
    }
    public static Vector3 EaseInCubic(Vector3 _start, Vector3 _end, float _t)
    {
        Vector3 ret = new Vector3
        {
            x = EaseInCubic(_start.x, _end.x, _t),
            y = EaseInCubic(_start.y, _end.y, _t),
            z = EaseInCubic(_start.z, _end.z, _t),
        };

        return ret;
    }
    public static Vector2 EaseInCubic(Vector2 _start, Vector2 _end, float _t)
    {
        Vector2 ret = new Vector2
        {
            x = EaseInCubic(_start.x, _end.x, _t),
            y = EaseInCubic(_start.y, _end.y, _t),
        };

        return ret;
    }
    public static Color EaseInCubic(Color _start, Color _end, float _t)
    {
        Color ret = new Color
        {
            r = EaseInCubic(_start.r, _end.r, _t),
            g = EaseInCubic(_start.g, _end.g, _t),
            b = EaseInCubic(_start.b, _end.b, _t),
            a = EaseInCubic(_start.a, _end.a, _t)
        };

        return ret;
    }
    public static Vector4 EaseOutCubic(Vector4 _start, Vector4 _end, float _t)
    {
        Vector4 ret = new Vector4
        {
            x = EaseOutCubic(_start.x, _end.x, _t),
            y = EaseOutCubic(_start.y, _end.y, _t),
            z = EaseOutCubic(_start.z, _end.z, _t),
            w = EaseOutCubic(_start.w, _end.w, _t)
        };

        return ret;
    }
    public static Vector3 EaseOutCubic(Vector3 _start, Vector3 _end, float _t)
    {
        Vector3 ret = new Vector3
        {
            x = EaseOutCubic(_start.x, _end.x, _t),
            y = EaseOutCubic(_start.y, _end.y, _t),
            z = EaseOutCubic(_start.z, _end.z, _t),
        };

        return ret;
    }
    public static Vector2 EaseOutCubic(Vector2 _start, Vector2 _end, float _t)
    {
        Vector2 ret = new Vector2
        {
            x = EaseOutCubic(_start.x, _end.x, _t),
            y = EaseOutCubic(_start.y, _end.y, _t),
        };

        return ret;
    }
    public static Color EaseOutCubic(Color _start, Color _end, float _t)
    {
        Color ret = new Color
        {
            r = EaseOutCubic(_start.r, _end.r, _t),
            g = EaseOutCubic(_start.g, _end.g, _t),
            b = EaseOutCubic(_start.b, _end.b, _t),
            a = EaseOutCubic(_start.a, _end.a, _t)
        };

        return ret;
    }
    public static Vector4 EaseInOutCubic(Vector4 _start, Vector4 _end, float _t)
    {
        Vector4 ret = new Vector4
        {
            x = EaseInOutCubic(_start.x, _end.x, _t),
            y = EaseInOutCubic(_start.y, _end.y, _t),
            z = EaseInOutCubic(_start.z, _end.z, _t),
            w = EaseInOutCubic(_start.w, _end.w, _t)
        };

        return ret;
    }
    public static Vector3 EaseInOutCubic(Vector3 _start, Vector3 _end, float _t)
    {
        Vector3 ret = new Vector3
        {
            x = EaseInOutCubic(_start.x, _end.x, _t),
            y = EaseInOutCubic(_start.y, _end.y, _t),
            z = EaseInOutCubic(_start.z, _end.z, _t),
        };

        return ret;
    }
    public static Vector2 EaseInOutCubic(Vector2 _start, Vector2 _end, float _t)
    {
        Vector2 ret = new Vector2
        {
            x = EaseInOutCubic(_start.x, _end.x, _t),
            y = EaseInOutCubic(_start.y, _end.y, _t),
        };

        return ret;
    }
    public static Color EaseInOutCubic(Color _start, Color _end, float _t)
    {
        Color ret = new Color
        {
            r = EaseInOutCubic(_start.r, _end.r, _t),
            g = EaseInOutCubic(_start.g, _end.g, _t),
            b = EaseInOutCubic(_start.b, _end.b, _t),
            a = EaseInOutCubic(_start.a, _end.a, _t)
        };

        return ret;
    }
    #endregion Cubic
}
