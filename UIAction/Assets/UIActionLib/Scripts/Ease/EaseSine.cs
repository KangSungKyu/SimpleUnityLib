using UnityEngine;
using System.Collections;

public partial class EaseActions<T>
{
    #region Sine
    public static float EaseInSine(float _start, float _end, float _t)
    {
        _end -= _start;

        return -_end * Mathf.Cos(_t / 1.0f * (Mathf.PI / 2.0f)) + _end + _start;
    }
    public static float EaseOutSine(float _start, float _end, float _t)
    {
        _end -= _start;

        return _end * Mathf.Sin(_t / 1.0f * (Mathf.PI / 2.0f)) + _start;
    }
    public static float EaseInOutSine(float _start, float _end, float _t)
    {
        _end -= _start;

        return -_end / 2.0f * (Mathf.Cos(Mathf.PI * _t / 1.0f) - 1.0f) + _start;
    }
    public static Vector4 EaseInSine(Vector4 _start, Vector4 _end, float _t)
    {
        Vector4 ret = new Vector4
        {
            x = EaseInSine(_start.x, _end.x, _t),
            y = EaseInSine(_start.y, _end.y, _t),
            z = EaseInSine(_start.z, _end.z, _t),
            w = EaseInSine(_start.w, _end.w, _t)
        };

        return ret;
    }
    public static Vector3 EaseInSine(Vector3 _start, Vector3 _end, float _t)
    {
        Vector3 ret = new Vector3
        {
            x = EaseInSine(_start.x, _end.x, _t),
            y = EaseInSine(_start.y, _end.y, _t),
            z = EaseInSine(_start.z, _end.z, _t),
        };

        return ret;
    }
    public static Vector2 EaseInSine(Vector2 _start, Vector2 _end, float _t)
    {
        Vector2 ret = new Vector2
        {
            x = EaseInSine(_start.x, _end.x, _t),
            y = EaseInSine(_start.y, _end.y, _t),
        };

        return ret;
    }
    public static Color EaseInSine(Color _start, Color _end, float _t)
    {
        Color ret = new Color
        {
            r = EaseInSine(_start.r, _end.r, _t),
            g = EaseInSine(_start.g, _end.g, _t),
            b = EaseInSine(_start.b, _end.b, _t),
            a = EaseInSine(_start.a, _end.a, _t)
        };

        return ret;
    }
    public static Vector4 EaseOutSine(Vector4 _start, Vector4 _end, float _t)
    {
        Vector4 ret = new Vector4
        {
            x = EaseOutSine(_start.x, _end.x, _t),
            y = EaseOutSine(_start.y, _end.y, _t),
            z = EaseOutSine(_start.z, _end.z, _t),
            w = EaseOutSine(_start.w, _end.w, _t)
        };

        return ret;
    }
    public static Vector3 EaseOutSine(Vector3 _start, Vector3 _end, float _t)
    {
        Vector3 ret = new Vector3
        {
            x = EaseOutSine(_start.x, _end.x, _t),
            y = EaseOutSine(_start.y, _end.y, _t),
            z = EaseOutSine(_start.z, _end.z, _t),
        };

        return ret;
    }
    public static Vector2 EaseOutSine(Vector2 _start, Vector2 _end, float _t)
    {
        Vector2 ret = new Vector2
        {
            x = EaseOutSine(_start.x, _end.x, _t),
            y = EaseOutSine(_start.y, _end.y, _t),
        };

        return ret;
    }
    public static Color EaseOutSine(Color _start, Color _end, float _t)
    {
        Color ret = new Color
        {
            r = EaseOutSine(_start.r, _end.r, _t),
            g = EaseOutSine(_start.g, _end.g, _t),
            b = EaseOutSine(_start.b, _end.b, _t),
            a = EaseOutSine(_start.a, _end.a, _t)
        };

        return ret;
    }
    public static Vector4 EaseInOutSine(Vector4 _start, Vector4 _end, float _t)
    {
        Vector4 ret = new Vector4
        {
            x = EaseInOutSine(_start.x, _end.x, _t),
            y = EaseInOutSine(_start.y, _end.y, _t),
            z = EaseInOutSine(_start.z, _end.z, _t),
            w = EaseInOutSine(_start.w, _end.w, _t)
        };

        return ret;
    }
    public static Vector3 EaseInOutSine(Vector3 _start, Vector3 _end, float _t)
    {
        Vector3 ret = new Vector3
        {
            x = EaseInOutSine(_start.x, _end.x, _t),
            y = EaseInOutSine(_start.y, _end.y, _t),
            z = EaseInOutSine(_start.z, _end.z, _t),
        };

        return ret;
    }
    public static Vector2 EaseInOutSine(Vector2 _start, Vector2 _end, float _t)
    {
        Vector2 ret = new Vector2
        {
            x = EaseInOutSine(_start.x, _end.x, _t),
            y = EaseInOutSine(_start.y, _end.y, _t),
        };

        return ret;
    }
    public static Color EaseInOutSine(Color _start, Color _end, float _t)
    {
        Color ret = new Color
        {
            r = EaseInOutSine(_start.r, _end.r, _t),
            g = EaseInOutSine(_start.g, _end.g, _t),
            b = EaseInOutSine(_start.b, _end.b, _t),
            a = EaseInOutSine(_start.a, _end.a, _t)
        };

        return ret;
    }
    #endregion Sine
}
