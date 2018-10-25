using UnityEngine;
using System.Collections;

[RequireComponent(typeof(RectTransform),typeof(UIScaleAction))]
public abstract class BasePopup : MonoBehaviour
{
    public bool IsEnable { get { return bEnable; } }

    protected bool bEnable = false;
    protected UIScaleAction Poping = null;

    private void Awake()
    {
        this.GetComponent<RectTransform>().anchoredPosition3D = Vector3.zero;

        Poping = this.gameObject.GetComponent<UIScaleAction>();

        Hide();
    }

    public virtual void Show()
    {
        this.gameObject.SetActive(true);
        bEnable = true;

        if(Poping)
        {
            Poping.Start = Vector3.one;
            Poping.End = Vector3.one * 1.5f;
            Poping.During = 0.125f;
            Poping.LoopType = UIActionBaseInfo.UIActionLoopType.UIActionLoop_Pingpong;
            Poping.MaxLoop = 1;
            Poping.actAfter.RemoveAllListeners();
            Poping.actAfter.AddListener(ShowContent);
            Poping.Play();
        }
        else
            ShowContent();
    }
    public virtual void Hide()
    {
        bEnable = false;
        this.gameObject.SetActive(false);
    }
    public virtual void Close()
    {
        if (Poping)
        {
            Poping.Start = Vector3.one;
            Poping.End = Vector3.one * 1.5f;
            Poping.During = 0.125f;
            Poping.LoopType = UIActionBaseInfo.UIActionLoopType.UIActionLoop_Pingpong;
            Poping.MaxLoop = 1;
            Poping.actAfter.RemoveAllListeners();
            Poping.actAfter.AddListener(Hide);
            Poping.Play();
        }
        else
            Hide();
    }

    public abstract void ShowContent();
}
