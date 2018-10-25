using UnityEngine;
using System.Collections;

public partial class EaseActions<T>
{
    #region Lerp
    public static float EaseLerp(float _start, float _end, float _t)
    {
        return Mathf.LerpUnclamped(_start, _end, _t);
    }
    public static Vector2 EaseLerp(Vector2 _start, Vector2 _end, float _t)
    {
        return Vector2.LerpUnclamped(_start, _end, _t);
    }
    public static Vector3 EaseLerp(Vector3 _start, Vector3 _end, float _t)
    {
        return Vector3.LerpUnclamped(_start, _end, _t);
    }
    public static Vector4 EaseLerp(Vector4 _start, Vector4 _end, float _t)
    {
        return Vector4.LerpUnclamped(_start, _end, _t);
    }
    public static Color EaseLerp(Color _start, Color _end, float _t)
    {
        return Color.LerpUnclamped(_start, _end, _t);
    }
    #endregion Lerp

    #region SLerp
    public static Quaternion EaseSLerp(Quaternion _start, Quaternion _end,float _t)
    {
        return Quaternion.SlerpUnclamped(_start, _end, _t);
    }
    #endregion SLerp
}
