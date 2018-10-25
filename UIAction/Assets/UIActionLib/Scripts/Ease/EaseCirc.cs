using UnityEngine;
using System.Collections;

public partial class EaseActions<T>
{
    #region Circ
    public static float EaseInCirc(float _start, float _end, float _t)
    {
        _end -= _start;

        return -_end * (Mathf.Sqrt(1.0f - _t * _t) - 1.0f) + _start;
    }
    public static float EaseOutCirc(float _start, float _end, float _t)
    {
        _t -= 1.0f;
        _end -= _start;

        return _end * Mathf.Sqrt(1.0f - _t * _t) + _start;
    }
    public static float EaseInOutCirc(float _start, float _end, float _t)
    {
        _t /= 0.5f;
        _end -= _start;

        if (_t < 1.0f)
            return --_end / 2.0f * (Mathf.Sqrt(1.0f - _t * _t) - 1.0f) + _start;

        _t -= 2.0f;

        return _end / 2.0f * (Mathf.Sqrt(1.0f - _t * _t) + 1.0f) + _start;
    }
    public static Vector4 EaseInCirc(Vector4 _start, Vector4 _end, float _t)
    {
        Vector4 ret = new Vector4
        {
            x = EaseInCirc(_start.x, _end.x, _t),
            y = EaseInCirc(_start.y, _end.y, _t),
            z = EaseInCirc(_start.z, _end.z, _t),
            w = EaseInCirc(_start.w, _end.w, _t)
        };

        return ret;
    }
    public static Vector3 EaseInCirc(Vector3 _start, Vector3 _end, float _t)
    {
        Vector3 ret = new Vector3
        {
            x = EaseInCirc(_start.x, _end.x, _t),
            y = EaseInCirc(_start.y, _end.y, _t),
            z = EaseInCirc(_start.z, _end.z, _t),
        };

        return ret;
    }
    public static Vector2 EaseInCirc(Vector2 _start, Vector2 _end, float _t)
    {
        Vector2 ret = new Vector2
        {
            x = EaseInCirc(_start.x, _end.x, _t),
            y = EaseInCirc(_start.y, _end.y, _t),
        };

        return ret;
    }
    public static Color EaseInCirc(Color _start, Color _end, float _t)
    {
        Color ret = new Color
        {
            r = EaseInCirc(_start.r, _end.r, _t),
            g = EaseInCirc(_start.g, _end.g, _t),
            b = EaseInCirc(_start.b, _end.b, _t),
            a = EaseInCirc(_start.a, _end.a, _t)
        };

        return ret;
    }
    public static Vector4 EaseOutCirc(Vector4 _start, Vector4 _end, float _t)
    {
        Vector4 ret = new Vector4
        {
            x = EaseOutCirc(_start.x, _end.x, _t),
            y = EaseOutCirc(_start.y, _end.y, _t),
            z = EaseOutCirc(_start.z, _end.z, _t),
            w = EaseOutCirc(_start.w, _end.w, _t)
        };

        return ret;
    }
    public static Vector3 EaseOutCirc(Vector3 _start, Vector3 _end, float _t)
    {
        Vector3 ret = new Vector3
        {
            x = EaseOutCirc(_start.x, _end.x, _t),
            y = EaseOutCirc(_start.y, _end.y, _t),
            z = EaseOutCirc(_start.z, _end.z, _t),
        };

        return ret;
    }
    public static Vector2 EaseOutCirc(Vector2 _start, Vector2 _end, float _t)
    {
        Vector2 ret = new Vector2
        {
            x = EaseOutCirc(_start.x, _end.x, _t),
            y = EaseOutCirc(_start.y, _end.y, _t),
        };

        return ret;
    }
    public static Color EaseOutCirc(Color _start, Color _end, float _t)
    {
        Color ret = new Color
        {
            r = EaseOutCirc(_start.r, _end.r, _t),
            g = EaseOutCirc(_start.g, _end.g, _t),
            b = EaseOutCirc(_start.b, _end.b, _t),
            a = EaseOutCirc(_start.a, _end.a, _t)
        };

        return ret;
    }
    public static Vector4 EaseInOutCirc(Vector4 _start, Vector4 _end, float _t)
    {
        Vector4 ret = new Vector4
        {
            x = EaseInOutCirc(_start.x, _end.x, _t),
            y = EaseInOutCirc(_start.y, _end.y, _t),
            z = EaseInOutCirc(_start.z, _end.z, _t),
            w = EaseInOutCirc(_start.w, _end.w, _t)
        };

        return ret;
    }
    public static Vector3 EaseInOutCirc(Vector3 _start, Vector3 _end, float _t)
    {
        Vector3 ret = new Vector3
        {
            x = EaseInOutCirc(_start.x, _end.x, _t),
            y = EaseInOutCirc(_start.y, _end.y, _t),
            z = EaseInOutCirc(_start.z, _end.z, _t),
        };

        return ret;
    }
    public static Vector2 EaseInOutCirc(Vector2 _start, Vector2 _end, float _t)
    {
        Vector2 ret = new Vector2
        {
            x = EaseInOutCirc(_start.x, _end.x, _t),
            y = EaseInOutCirc(_start.y, _end.y, _t),
        };

        return ret;
    }
    public static Color EaseInOutCirc(Color _start, Color _end, float _t)
    {
        Color ret = new Color
        {
            r = EaseInOutCirc(_start.r, _end.r, _t),
            g = EaseInOutCirc(_start.g, _end.g, _t),
            b = EaseInOutCirc(_start.b, _end.b, _t),
            a = EaseInOutCirc(_start.a, _end.a, _t)
        };

        return ret;
    }
    #endregion Expo
}
