using UnityEngine;
using System.Collections;

public partial class EaseActions<T>
{
    #region Back
    public static float EaseInBack(float _start, float _end, float _t)
    {
        _end -= _start;
        _t /= 1.0f;
        float s = 1.70158f;

        return _end * _t * _t * ((s + 1.0f) * _t - s) + _start;
    }
    public static float EaseOutBack(float _start, float _end, float _t)
    {
        _end -= _start;
        _t = _t - 1.0f;
        float s = 1.70158f;

        return _end * (_t * _t * ((s + 1.0f) * _t + s) + 1.0f) + _start;
    }
    public static float EaseInOutBack(float _start, float _end, float _t)
    {
        _end -= _start;
        _t /= 0.5f;
        float s = 1.70158f;

        if(_t < 1.0f)
        {
            s *= (1.525f);
            return _end * 0.5f * (_t * _t * ((s + 1.0f) * _t - s)) + _start;
        }

        _t -= 2.0f;
        s *= (1.525f);

        return _end * 0.5f * (_t * _t * ((s + 1.0f) * _t + s) + 2.0f) + _start;
    }
    public static Vector4 EaseInBack(Vector4 _start, Vector4 _end, float _t)
    {
        Vector4 ret = new Vector4
        {
            x = EaseInBack(_start.x, _end.x, _t),
            y = EaseInBack(_start.y, _end.y, _t),
            z = EaseInBack(_start.z, _end.z, _t),
            w = EaseInBack(_start.w, _end.w, _t)
        };

        return ret;
    }
    public static Vector3 EaseInBack(Vector3 _start, Vector3 _end, float _t)
    {
        Vector3 ret = new Vector3
        {
            x = EaseInBack(_start.x, _end.x, _t),
            y = EaseInBack(_start.y, _end.y, _t),
            z = EaseInBack(_start.z, _end.z, _t),
        };

        return ret;
    }
    public static Vector2 EaseInBack(Vector2 _start, Vector2 _end, float _t)
    {
        Vector2 ret = new Vector2
        {
            x = EaseInBack(_start.x, _end.x, _t),
            y = EaseInBack(_start.y, _end.y, _t),
        };

        return ret;
    }
    public static Color EaseInBack(Color _start, Color _end, float _t)
    {
        Color ret = new Color
        {
            r = EaseInBack(_start.r, _end.r, _t),
            g = EaseInBack(_start.g, _end.g, _t),
            b = EaseInBack(_start.b, _end.b, _t),
            a = EaseInBack(_start.a, _end.a, _t)
        };

        return ret;
    }
    public static Vector4 EaseOutBack(Vector4 _start, Vector4 _end, float _t)
    {
        Vector4 ret = new Vector4
        {
            x = EaseOutBack(_start.x, _end.x, _t),
            y = EaseOutBack(_start.y, _end.y, _t),
            z = EaseOutBack(_start.z, _end.z, _t),
            w = EaseOutBack(_start.w, _end.w, _t)
        };

        return ret;
    }
    public static Vector3 EaseOutBack(Vector3 _start, Vector3 _end, float _t)
    {
        Vector3 ret = new Vector3
        {
            x = EaseOutBack(_start.x, _end.x, _t),
            y = EaseOutBack(_start.y, _end.y, _t),
            z = EaseOutBack(_start.z, _end.z, _t),
        };

        return ret;
    }
    public static Vector2 EaseOutBack(Vector2 _start, Vector2 _end, float _t)
    {
        Vector2 ret = new Vector2
        {
            x = EaseOutBack(_start.x, _end.x, _t),
            y = EaseOutBack(_start.y, _end.y, _t),
        };

        return ret;
    }
    public static Color EaseOutBack(Color _start, Color _end, float _t)
    {
        Color ret = new Color
        {
            r = EaseOutBack(_start.r, _end.r, _t),
            g = EaseOutBack(_start.g, _end.g, _t),
            b = EaseOutBack(_start.b, _end.b, _t),
            a = EaseOutBack(_start.a, _end.a, _t)
        };

        return ret;
    }
    public static Vector4 EaseInOutBack(Vector4 _start, Vector4 _end, float _t)
    {
        Vector4 ret = new Vector4
        {
            x = EaseInOutBack(_start.x, _end.x, _t),
            y = EaseInOutBack(_start.y, _end.y, _t),
            z = EaseInOutBack(_start.z, _end.z, _t),
            w = EaseInOutBack(_start.w, _end.w, _t)
        };

        return ret;
    }
    public static Vector3 EaseInOutBack(Vector3 _start, Vector3 _end, float _t)
    {
        Vector3 ret = new Vector3
        {
            x = EaseInOutBack(_start.x, _end.x, _t),
            y = EaseInOutBack(_start.y, _end.y, _t),
            z = EaseInOutBack(_start.z, _end.z, _t),
        };

        return ret;
    }
    public static Vector2 EaseInOutBack(Vector2 _start, Vector2 _end, float _t)
    {
        Vector2 ret = new Vector2
        {
            x = EaseInOutBack(_start.x, _end.x, _t),
            y = EaseInOutBack(_start.y, _end.y, _t),
        };

        return ret;
    }
    public static Color EaseInOutBack(Color _start, Color _end, float _t)
    {
        Color ret = new Color
        {
            r = EaseInOutBack(_start.r, _end.r, _t),
            g = EaseInOutBack(_start.g, _end.g, _t),
            b = EaseInOutBack(_start.b, _end.b, _t),
            a = EaseInOutBack(_start.a, _end.a, _t)
        };

        return ret;
    }
    #endregion Back
}
