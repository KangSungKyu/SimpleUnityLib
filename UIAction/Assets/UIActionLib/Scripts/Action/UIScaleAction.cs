﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScaleAction : UITransformActionBase
{
    protected override void ResetUI()
    {
        if (Owner != null)
        {
            RectTransform rt = Owner.GetComponent<RectTransform>();

            if (rt)
            {
                rt.localScale = bForward == true ? Start : End;
            }
        }
    }
    protected override void SetCurrentTimePos(float _time)
    {
        if (bStart == false)
            return;

        Owner = this.gameObject;
        RectTransform rtOwner = Owner.GetComponent<RectTransform>();

        switch (LoopType)
        {
            case UIActionLoopType.UIActionLoop_Once:
                rtOwner.localScale = funcEase_Vector3(Start, End, Mathf.Clamp01(_time / During));
                break;
            case UIActionLoopType.UIActionLoop_Looping:
                rtOwner.localScale = funcEase_Vector3(Start, End, Mathf.Clamp01((_time%During) / During));
                break;
            case UIActionLoopType.UIActionLoop_Pingpong:
                float w = During * 2.0f;
                if ((_time % w) / w <= 0.5f)
                    rtOwner.localScale = funcEase_Vector3(Start, End, Mathf.Clamp01((_time % During) / During));
                else
                    rtOwner.localScale = funcEase_Vector3(End, Start, Mathf.Clamp01((_time % During) / During));
                break;
        }
    }
    protected override IEnumerator Action_Once(float _during)
    {
        actBefore.Invoke();

        float timer = 0.0f;

        Vector3 start = Start;
        Vector3 end = End;

        if (bForward == false)
        {
            start = End;
            end = Start;
        }

        Owner = this.gameObject;
        RectTransform rtOwner = Owner.GetComponent<RectTransform>();

        if (rtOwner == null)
        {
            procAct = null;
            yield break;
        }

        yield return waitDelay;
        
        rtOwner.localScale = start;

        while (timer < _during)
        {
            rtOwner.localScale = funcEase_Vector3(start, end, timer / _during);

            yield return null;
            timer += Time.deltaTime;
        }

        rtOwner.localScale = end;
        bDone = true;
        procAct = null;

        actAfter.Invoke();
    }
    protected override IEnumerator Action_Looping(float _during)
    {
        yield return waitDelay;

        int loop = nMaxLoop == -1 ? -2 : 0;

        while (loop < nMaxLoop)
        {
            actBefore.Invoke();

            bDone = false;

            float timer = 0.0f;

            Vector3 start = Start;
            Vector3 end = End;

            if (bForward == false)
            {
                start = End;
                end = Start;
            }

            Owner = this.gameObject;
            RectTransform rtOwner = Owner.GetComponent<RectTransform>();

            if (rtOwner == null)
            {
                procAct = null;
                break;
            }
            
            rtOwner.localScale = start;

            while (timer < _during)
            {
                rtOwner.localScale = funcEase_Vector3(start, end, timer / _during);

                yield return null;
                timer += Time.deltaTime;
            }

            rtOwner.localScale = end;
            bDone = true;

            actAfter.Invoke();

            if (nMaxLoop != -1)
                ++loop;
        }

        procAct = null;
    }
    protected override IEnumerator Action_Pingpong(float _during)
    {
        yield return waitDelay;

        int loop = nMaxLoop == -1 ? -2 : 0;

        while (loop < nMaxLoop)
        {
            actBefore.Invoke();

            bDone = false;

            float timer = 0.0f;

            Vector3 start = Start;
            Vector3 end = End;

            if (bForward == false)
            {
                start = End;
                end = Start;
            }

            Owner = this.gameObject;
            RectTransform rtOwner = Owner.GetComponent<RectTransform>();

            if (rtOwner == null)
            {
                procAct = null;
                break;
            }
            
            rtOwner.localScale = start;

            while (timer < _during)
            {
                rtOwner.localScale = funcEase_Vector3(start, end, timer / _during);

                yield return null;
                timer += Time.deltaTime;
            }

            rtOwner.localScale = end;

            timer = 0.0f;

            while(timer < _during)
            {
                rtOwner.localScale = funcEase_Vector3(end, start, timer / _during);

                yield return null;
                timer += Time.deltaTime;
            }

            rtOwner.localScale = start;
            bDone = true;

            actAfter.Invoke();

            if (nMaxLoop != -1)
                ++loop;
        }

        procAct = null;
    }
}
