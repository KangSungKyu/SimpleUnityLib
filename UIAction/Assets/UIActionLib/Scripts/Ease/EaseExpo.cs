using UnityEngine;
using System.Collections;

public partial class EaseActions<T>
{
    #region Expo
    public static float EaseInExpo(float _start, float _end, float _t)
    {
        _end -= _start;

        return _end * Mathf.Pow(2.0f, 10.0f * (_t / 1.0f - 1.0f)) + _start;
    }
    public static float EaseOutExpo(float _start, float _end, float _t)
    {
        _end -= _start;

        return _end * (-Mathf.Pow(2.0f, -10.0f * _t / 1.0f) + 1.0f) + _start;
    }
    public static float EaseInOutExpo(float _start, float _end, float _t)
    {
        _t /= 0.5f;
        _end -= _start;

        if (_t < 1.0f)
            return _end / 2.0f * Mathf.Pow(2.0f, 10.0f * (_t - 1.0f)) + _start;

        _t -= 1.0f;

        return _end / 2.0f * (-Mathf.Pow(2.0f, -10.0f * _t) + 2.0f) + _start;
    }
    public static Vector4 EaseInExpo(Vector4 _start, Vector4 _end, float _t)
    {
        Vector4 ret = new Vector4
        {
            x = EaseInExpo(_start.x, _end.x, _t),
            y = EaseInExpo(_start.y, _end.y, _t),
            z = EaseInExpo(_start.z, _end.z, _t),
            w = EaseInExpo(_start.w, _end.w, _t)
        };

        return ret;
    }
    public static Vector3 EaseInExpo(Vector3 _start, Vector3 _end, float _t)
    {
        Vector3 ret = new Vector3
        {
            x = EaseInExpo(_start.x, _end.x, _t),
            y = EaseInExpo(_start.y, _end.y, _t),
            z = EaseInExpo(_start.z, _end.z, _t),
        };

        return ret;
    }
    public static Vector2 EaseInExpo(Vector2 _start, Vector2 _end, float _t)
    {
        Vector2 ret = new Vector2
        {
            x = EaseInExpo(_start.x, _end.x, _t),
            y = EaseInExpo(_start.y, _end.y, _t),
        };

        return ret;
    }
    public static Color EaseInExpo(Color _start, Color _end, float _t)
    {
        Color ret = new Color
        {
            r = EaseInExpo(_start.r, _end.r, _t),
            g = EaseInExpo(_start.g, _end.g, _t),
            b = EaseInExpo(_start.b, _end.b, _t),
            a = EaseInExpo(_start.a, _end.a, _t)
        };

        return ret;
    }
    public static Vector4 EaseOutExpo(Vector4 _start, Vector4 _end, float _t)
    {
        Vector4 ret = new Vector4
        {
            x = EaseOutExpo(_start.x, _end.x, _t),
            y = EaseOutExpo(_start.y, _end.y, _t),
            z = EaseOutExpo(_start.z, _end.z, _t),
            w = EaseOutExpo(_start.w, _end.w, _t)
        };

        return ret;
    }
    public static Vector3 EaseOutExpo(Vector3 _start, Vector3 _end, float _t)
    {
        Vector3 ret = new Vector3
        {
            x = EaseOutExpo(_start.x, _end.x, _t),
            y = EaseOutExpo(_start.y, _end.y, _t),
            z = EaseOutExpo(_start.z, _end.z, _t),
        };

        return ret;
    }
    public static Vector2 EaseOutExpo(Vector2 _start, Vector2 _end, float _t)
    {
        Vector2 ret = new Vector2
        {
            x = EaseOutExpo(_start.x, _end.x, _t),
            y = EaseOutExpo(_start.y, _end.y, _t),
        };

        return ret;
    }
    public static Color EaseOutExpo(Color _start, Color _end, float _t)
    {
        Color ret = new Color
        {
            r = EaseOutExpo(_start.r, _end.r, _t),
            g = EaseOutExpo(_start.g, _end.g, _t),
            b = EaseOutExpo(_start.b, _end.b, _t),
            a = EaseOutExpo(_start.a, _end.a, _t)
        };

        return ret;
    }
    public static Vector4 EaseInOutExpo(Vector4 _start, Vector4 _end, float _t)
    {
        Vector4 ret = new Vector4
        {
            x = EaseInOutExpo(_start.x, _end.x, _t),
            y = EaseInOutExpo(_start.y, _end.y, _t),
            z = EaseInOutExpo(_start.z, _end.z, _t),
            w = EaseInOutExpo(_start.w, _end.w, _t)
        };

        return ret;
    }
    public static Vector3 EaseInOutExpo(Vector3 _start, Vector3 _end, float _t)
    {
        Vector3 ret = new Vector3
        {
            x = EaseInOutExpo(_start.x, _end.x, _t),
            y = EaseInOutExpo(_start.y, _end.y, _t),
            z = EaseInOutExpo(_start.z, _end.z, _t),
        };

        return ret;
    }
    public static Vector2 EaseInOutExpo(Vector2 _start, Vector2 _end, float _t)
    {
        Vector2 ret = new Vector2
        {
            x = EaseInOutExpo(_start.x, _end.x, _t),
            y = EaseInOutExpo(_start.y, _end.y, _t),
        };

        return ret;
    }
    public static Color EaseInOutExpo(Color _start, Color _end, float _t)
    {
        Color ret = new Color
        {
            r = EaseInOutExpo(_start.r, _end.r, _t),
            g = EaseInOutExpo(_start.g, _end.g, _t),
            b = EaseInOutExpo(_start.b, _end.b, _t),
            a = EaseInOutExpo(_start.a, _end.a, _t)
        };

        return ret;
    }
    #endregion Expo
}
