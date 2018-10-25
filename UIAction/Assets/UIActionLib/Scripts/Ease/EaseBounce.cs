using UnityEngine;
using System.Collections;

public partial class EaseActions<T>
{
    #region Bounce
    public static float EaseInBounce(float _start, float _end, float _t)
    {
        _end -= _start;
        float d = 1.0f;

        return _end - EaseOutBounce(0.0f, _end, d - _t) + _start;
    }
    public static float EaseOutBounce(float _start, float _end, float _t)
    {
        _t /= 1.0f;
        _end -= _start;

        if (_t < (1.0f / 2.75f))
        {
            return _end * (7.5625f * _t * _t) + _start;
        }
        else if (_t < (2.0f / 2.75f))
        {
            _t -= (1.5f / 2.75f);
            return _end * (7.5625f * _t * _t + 0.75f) + _start;
        }
        else if(_t <(2.5f/2.75f))
        {
            _t -= (2.25f / 2.75f);
            return _end * (7.5625f * _t * _t + 0.9375f) + _start;
        }
        else
        {
            _t -= (2.625f / 2.75f);
            return _end * (7.5625f * _t * _t + 0.984375f) + _start;
        }
    }
    public static float EaseInOutBounce(float _start, float _end, float _t)
    {
        _end -= _start;
        float d = 1.0f;

        if (_t < d * 0.5f)
            return EaseInBounce(0.0f, _end, _t * 2.0f) * 0.5f + _start;
        else
            return EaseOutBounce(0.0f, _end, _t * 2.0f - d) * 0.5f + _end * 0.5f + _start;
    }
    public static Vector4 EaseInBounce(Vector4 _start, Vector4 _end, float _t)
    {
        Vector4 ret = new Vector4
        {
            x = EaseInBounce(_start.x, _end.x, _t),
            y = EaseInBounce(_start.y, _end.y, _t),
            z = EaseInBounce(_start.z, _end.z, _t),
            w = EaseInBounce(_start.w, _end.w, _t)
        };

        return ret;
    }
    public static Vector3 EaseInBounce(Vector3 _start, Vector3 _end, float _t)
    {
        Vector3 ret = new Vector3
        {
            x = EaseInBounce(_start.x, _end.x, _t),
            y = EaseInBounce(_start.y, _end.y, _t),
            z = EaseInBounce(_start.z, _end.z, _t),
        };

        return ret;
    }
    public static Vector2 EaseInBounce(Vector2 _start, Vector2 _end, float _t)
    {
        Vector2 ret = new Vector2
        {
            x = EaseInBounce(_start.x, _end.x, _t),
            y = EaseInBounce(_start.y, _end.y, _t),
        };

        return ret;
    }
    public static Color EaseInBounce(Color _start, Color _end, float _t)
    {
        Color ret = new Color
        {
            r = EaseInBounce(_start.r, _end.r, _t),
            g = EaseInBounce(_start.g, _end.g, _t),
            b = EaseInBounce(_start.b, _end.b, _t),
            a = EaseInBounce(_start.a, _end.a, _t)
        };

        return ret;
    }
    public static Vector4 EaseOutBounce(Vector4 _start, Vector4 _end, float _t)
    {
        Vector4 ret = new Vector4
        {
            x = EaseOutBounce(_start.x, _end.x, _t),
            y = EaseOutBounce(_start.y, _end.y, _t),
            z = EaseOutBounce(_start.z, _end.z, _t),
            w = EaseOutBounce(_start.w, _end.w, _t)
        };

        return ret;
    }
    public static Vector3 EaseOutBounce(Vector3 _start, Vector3 _end, float _t)
    {
        Vector3 ret = new Vector3
        {
            x = EaseOutBounce(_start.x, _end.x, _t),
            y = EaseOutBounce(_start.y, _end.y, _t),
            z = EaseOutBounce(_start.z, _end.z, _t),
        };

        return ret;
    }
    public static Vector2 EaseOutBounce(Vector2 _start, Vector2 _end, float _t)
    {
        Vector2 ret = new Vector2
        {
            x = EaseOutBounce(_start.x, _end.x, _t),
            y = EaseOutBounce(_start.y, _end.y, _t),
        };

        return ret;
    }
    public static Color EaseOutBounce(Color _start, Color _end, float _t)
    {
        Color ret = new Color
        {
            r = EaseOutBounce(_start.r, _end.r, _t),
            g = EaseOutBounce(_start.g, _end.g, _t),
            b = EaseOutBounce(_start.b, _end.b, _t),
            a = EaseOutBounce(_start.a, _end.a, _t)
        };

        return ret;
    }
    public static Vector4 EaseInOutBounce(Vector4 _start, Vector4 _end, float _t)
    {
        Vector4 ret = new Vector4
        {
            x = EaseInOutBounce(_start.x, _end.x, _t),
            y = EaseInOutBounce(_start.y, _end.y, _t),
            z = EaseInOutBounce(_start.z, _end.z, _t),
            w = EaseInOutBounce(_start.w, _end.w, _t)
        };

        return ret;
    }
    public static Vector3 EaseInOutBounce(Vector3 _start, Vector3 _end, float _t)
    {
        Vector3 ret = new Vector3
        {
            x = EaseInOutBounce(_start.x, _end.x, _t),
            y = EaseInOutBounce(_start.y, _end.y, _t),
            z = EaseInOutBounce(_start.z, _end.z, _t),
        };

        return ret;
    }
    public static Vector2 EaseInOutBounce(Vector2 _start, Vector2 _end, float _t)
    {
        Vector2 ret = new Vector2
        {
            x = EaseInOutBounce(_start.x, _end.x, _t),
            y = EaseInOutBounce(_start.y, _end.y, _t),
        };

        return ret;
    }
    public static Color EaseInOutBounce(Color _start, Color _end, float _t)
    {
        Color ret = new Color
        {
            r = EaseInOutBounce(_start.r, _end.r, _t),
            g = EaseInOutBounce(_start.g, _end.g, _t),
            b = EaseInOutBounce(_start.b, _end.b, _t),
            a = EaseInOutBounce(_start.a, _end.a, _t)
        };

        return ret;
    }
    #endregion Bounce
}
