using UnityEngine;
using System.Collections;

public abstract class UIActionBaseInfo : MonoBehaviour
{
    public enum UIActionLoopType
    {
        UIActionLoop_Once = 0,
        UIActionLoop_Looping,
        UIActionLoop_Pingpong,
    };
    public enum UIActionEaseType
    {
        UIActionEase_Lerp = 0,

        UIActionEase_InQuad,
        UIActionEase_OutQuad,
        UIActionEase_InOutQuad,

        UIActionEase_InCubic,
        UIActionEase_OutCubic,
        UIActionEase_InOutCubic,

        UIActionEase_InQuart,
        UIActionEase_OutQuart,
        UIActionEase_InOutQuart,

        UIActionEase_InQuint,
        UIActionEase_OutQuint,
        UIActionEase_InOutQuint,

        UIActionEase_InSine,
        UIActionEase_OutSine,
        UIActionEase_InOutSine,

        UIActionEase_InExpo,
        UIActionEase_OutExpo,
        UIActionEase_InOutExpo,

        UIActionEase_InCirc,
        UIActionEase_OutCirc,
        UIActionEase_InOutCirc,

        UIActionEase_InBounce,
        UIActionEase_OutBounce,
        UIActionEase_InOutBounce,

        UIActionEase_InBack,
        UIActionEase_OutBack,
        UIActionEase_InOutBack,
    }

    public bool IsForward { get { return bForward; } }
    public bool IsDone { get { return bDone; } }
    public bool IsStart { get { return bStart; } set { bStart = value; } }

    public UIActionLoopType LoopType = UIActionLoopType.UIActionLoop_Once;
    public UIActionEaseType EaseType = UIActionEaseType.UIActionEase_Lerp;
    
    [Range(-1, 1000)]
    [Tooltip("-1 : loop count infinity")]
    public int MaxLoop = -1; //-1 : infinity
    [Range(0.0f,60.0f)]
    public float Delay = 0.0f;
    [Range(0.001f, 60.0f)]
    public float During = 0.001f;
    
    public UnityEngine.Events.UnityEvent actBefore = new UnityEngine.Events.UnityEvent();
    public UnityEngine.Events.UnityEvent actAfter = new UnityEngine.Events.UnityEvent();

    protected bool bForward = true;
    protected bool bDone = false;
    protected bool bStart = false;

    protected int nMaxLoop = -1;
    protected float fDelay = 0.0f;
    protected float fDuring = 0.001f;

    protected GameObject Owner = null;
    protected Coroutine procAct = null;
    protected WaitForSeconds waitDelay = null;

    protected EaseActions<Vector3>.EaseFunc funcEase_Vector3 = EaseActions<Vector3>.EaseLerp;
    protected EaseActions<Quaternion>.EaseFunc funcEase_Quaternion = EaseActions<Quaternion>.EaseSLerp;
    protected EaseActions<Color>.EaseFunc funcEase_Color = EaseActions<Color>.EaseLerp;

    public virtual void Play(bool _forward = true)
    {
        bForward = _forward;
        bDone = false;
        bStart = false;

        nMaxLoop = MaxLoop;
        fDelay = Delay;
        fDuring = During;

        Stop();

        waitDelay = new WaitForSeconds(fDelay);

        funcEase_Quaternion = EaseActions<Quaternion>.EaseSLerp;

        switch (EaseType)
        {
            case UIActionEaseType.UIActionEase_Lerp:
                funcEase_Vector3 = EaseActions<Vector3>.EaseLerp;
                funcEase_Color = EaseActions<Color>.EaseLerp;
                break;
            case UIActionEaseType.UIActionEase_InQuad:
                funcEase_Vector3 = EaseActions<Vector3>.EaseInQuad;
                funcEase_Color = EaseActions<Color>.EaseInQuad;
                break;
            case UIActionEaseType.UIActionEase_OutQuad:
                funcEase_Vector3 = EaseActions<Vector3>.EaseOutQuad;
                funcEase_Color = EaseActions<Color>.EaseOutQuad;
                break;
            case UIActionEaseType.UIActionEase_InOutQuad:
                funcEase_Vector3 = EaseActions<Vector3>.EaseInOutQuad;
                funcEase_Color = EaseActions<Color>.EaseInOutQuad;
                break;
            case UIActionEaseType.UIActionEase_InCubic:
                funcEase_Vector3 = EaseActions<Vector3>.EaseInCubic;
                funcEase_Color = EaseActions<Color>.EaseInCubic;
                break;
            case UIActionEaseType.UIActionEase_OutCubic:
                funcEase_Vector3 = EaseActions<Vector3>.EaseOutCubic;
                funcEase_Color = EaseActions<Color>.EaseOutCubic;
                break;
            case UIActionEaseType.UIActionEase_InOutCubic:
                funcEase_Vector3 = EaseActions<Vector3>.EaseInOutCubic;
                funcEase_Color = EaseActions<Color>.EaseInOutCubic;
                break;
            case UIActionEaseType.UIActionEase_InQuart:
                funcEase_Vector3 = EaseActions<Vector3>.EaseInQuart;
                funcEase_Color = EaseActions<Color>.EaseInQuart;
                break;
            case UIActionEaseType.UIActionEase_OutQuart:
                funcEase_Vector3 = EaseActions<Vector3>.EaseOutQuart;
                funcEase_Color = EaseActions<Color>.EaseOutQuart;
                break;
            case UIActionEaseType.UIActionEase_InOutQuart:
                funcEase_Vector3 = EaseActions<Vector3>.EaseInOutQuart;
                funcEase_Color = EaseActions<Color>.EaseInOutQuart;
                break;
            case UIActionEaseType.UIActionEase_InQuint:
                funcEase_Vector3 = EaseActions<Vector3>.EaseInQuint;
                funcEase_Color = EaseActions<Color>.EaseInQuint;
                break;
            case UIActionEaseType.UIActionEase_OutQuint:
                funcEase_Vector3 = EaseActions<Vector3>.EaseOutQuint;
                funcEase_Color = EaseActions<Color>.EaseOutQuint;
                break;
            case UIActionEaseType.UIActionEase_InOutQuint:
                funcEase_Vector3 = EaseActions<Vector3>.EaseInOutQuint;
                funcEase_Color = EaseActions<Color>.EaseInOutQuint;
                break;
            case UIActionEaseType.UIActionEase_InSine:
                funcEase_Vector3 = EaseActions<Vector3>.EaseInSine;
                funcEase_Color = EaseActions<Color>.EaseInSine;
                break;
            case UIActionEaseType.UIActionEase_OutSine:
                funcEase_Vector3 = EaseActions<Vector3>.EaseOutSine;
                funcEase_Color = EaseActions<Color>.EaseOutSine;
                break;
            case UIActionEaseType.UIActionEase_InOutSine:
                funcEase_Vector3 = EaseActions<Vector3>.EaseInOutSine;
                funcEase_Color = EaseActions<Color>.EaseInOutSine;
                break;
            case UIActionEaseType.UIActionEase_InExpo:
                funcEase_Vector3 = EaseActions<Vector3>.EaseInExpo;
                funcEase_Color = EaseActions<Color>.EaseInExpo;
                break;
            case UIActionEaseType.UIActionEase_OutExpo:
                funcEase_Vector3 = EaseActions<Vector3>.EaseOutExpo;
                funcEase_Color = EaseActions<Color>.EaseOutExpo;
                break;
            case UIActionEaseType.UIActionEase_InOutExpo:
                funcEase_Vector3 = EaseActions<Vector3>.EaseInOutExpo;
                funcEase_Color = EaseActions<Color>.EaseInOutExpo;
                break;
            case UIActionEaseType.UIActionEase_InCirc:
                funcEase_Vector3 = EaseActions<Vector3>.EaseInCirc;
                funcEase_Color = EaseActions<Color>.EaseInCirc;
                break;
            case UIActionEaseType.UIActionEase_OutCirc:
                funcEase_Vector3 = EaseActions<Vector3>.EaseOutCirc;
                funcEase_Color = EaseActions<Color>.EaseOutCirc;
                break;
            case UIActionEaseType.UIActionEase_InOutCirc:
                funcEase_Vector3 = EaseActions<Vector3>.EaseInOutCirc;
                funcEase_Color = EaseActions<Color>.EaseInOutCirc;
                break;
            case UIActionEaseType.UIActionEase_InBounce:
                funcEase_Vector3 = EaseActions<Vector3>.EaseInBounce;
                funcEase_Color = EaseActions<Color>.EaseInBounce;
                break;
            case UIActionEaseType.UIActionEase_OutBounce:
                funcEase_Vector3 = EaseActions<Vector3>.EaseOutBounce;
                funcEase_Color = EaseActions<Color>.EaseOutBounce;
                break;
            case UIActionEaseType.UIActionEase_InOutBounce:
                funcEase_Vector3 = EaseActions<Vector3>.EaseInOutBounce;
                funcEase_Color = EaseActions<Color>.EaseInOutBounce;
                break;
            case UIActionEaseType.UIActionEase_InBack:
                funcEase_Vector3 = EaseActions<Vector3>.EaseInBack;
                funcEase_Color = EaseActions<Color>.EaseInBack;
                break;
            case UIActionEaseType.UIActionEase_OutBack:
                funcEase_Vector3 = EaseActions<Vector3>.EaseOutBack;
                funcEase_Color = EaseActions<Color>.EaseOutBack;
                break;
            case UIActionEaseType.UIActionEase_InOutBack:
                funcEase_Vector3 = EaseActions<Vector3>.EaseInOutBack;
                funcEase_Color = EaseActions<Color>.EaseInOutBack;
                break;
        }

        switch (LoopType)
        {
            case UIActionLoopType.UIActionLoop_Once:
                procAct = StartCoroutine(Action_Once(fDuring));
                break;
            case UIActionLoopType.UIActionLoop_Looping:
                procAct = StartCoroutine(Action_Looping(fDuring));
                break;
            case UIActionLoopType.UIActionLoop_Pingpong:
                procAct = StartCoroutine(Action_Pingpong(fDuring));
                break;
        }
    }
    public virtual void Stop()
    {
        if (procAct != null)
            StopCoroutine(procAct);
    }
    public virtual void ReSet()
    {
        ResetUI();
    }
    public virtual void SetCurrentTimePosition(float _time)
    {
        SetCurrentTimePos(_time);
    }

    protected abstract void ResetUI();
    protected abstract void SetCurrentTimePos(float _time);
    protected abstract IEnumerator Action_Once(float _during);
    protected abstract IEnumerator Action_Looping(float _during);
    protected abstract IEnumerator Action_Pingpong(float _during);
}
