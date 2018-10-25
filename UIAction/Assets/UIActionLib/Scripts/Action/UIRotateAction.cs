using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRotateAction : UITransformActionBase
{
    protected override void ResetUI()
    {
        if (Owner != null)
        {
            RectTransform rt = Owner.GetComponent<RectTransform>();

            if (rt)
            {
                rt.rotation = bForward == true ? Quaternion.Euler(Start) : Quaternion.Euler(End);
            }
        }
    }
    protected override void SetCurrentTimePos(float _time)
    {
        if (bStart == false)
            return;

        Owner = this.gameObject;
        RectTransform rtOwner = Owner.GetComponent<RectTransform>();
        Quaternion start = Quaternion.Euler(Start.x, Start.y, Start.z);
        Quaternion end = Quaternion.Euler(End.x, End.y, End.z);
        
        switch (LoopType)
        {
            case UIActionLoopType.UIActionLoop_Once:
                rtOwner.rotation = funcEase_Quaternion(start, end, Mathf.Clamp01(_time /During));
                break;
            case UIActionLoopType.UIActionLoop_Looping:
                rtOwner.rotation = funcEase_Quaternion(start, end, Mathf.Clamp01((_time % During) / During));
                break;
            case UIActionLoopType.UIActionLoop_Pingpong:
                float w = During * 2.0f;
                if ((_time % w) / w <= 0.5f)
                    rtOwner.rotation = funcEase_Quaternion(start, end, Mathf.Clamp01((_time % During) / During));
                else
                    rtOwner.rotation = funcEase_Quaternion(end, start, Mathf.Clamp01((_time % During) / During));
                break;
        }
    }
    protected override IEnumerator Action_Once(float _during)
    {
        actBefore.Invoke();

        float timer = 0.0f;

        Quaternion start = Quaternion.Euler(Start.x, Start.y, Start.z);
        Quaternion end = Quaternion.Euler(End.x, End.y, End.z);

        if (bForward == false)
        {
            start = Quaternion.Euler(End.x, End.y, End.z);
            end = Quaternion.Euler(Start.x, Start.y, Start.z);
        }

        Owner = this.gameObject;
        RectTransform rtOwner = Owner.GetComponent<RectTransform>();

        if (rtOwner == null)
        {
            procAct = null;
            yield break;
        }

        yield return waitDelay;

        rtOwner.rotation = start;

        while (timer < _during)
        {
            rtOwner.rotation = funcEase_Quaternion(start, end, timer / _during);

            yield return null;
            timer += Time.deltaTime;
        }

        rtOwner.rotation = end;
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

            Quaternion start = Quaternion.Euler(Start.x, Start.y, Start.z);
            Quaternion end = Quaternion.Euler(End.x, End.y, End.z);

            if (bForward == false)
            {
                start = Quaternion.Euler(End.x, End.y, End.z);
                end = Quaternion.Euler(Start.x, Start.y, Start.z);
            }

            Owner = this.gameObject;
            RectTransform rtOwner = Owner.GetComponent<RectTransform>();

            if (rtOwner == null)
            {
                procAct = null;
                break;
            }

            rtOwner.rotation = start;

            while (timer < _during)
            {
                rtOwner.rotation = funcEase_Quaternion(start, end, timer / _during);

                yield return null;
                timer += Time.deltaTime;
            }

            rtOwner.rotation = end;
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

            Quaternion start = Quaternion.Euler(Start.x, Start.y, Start.z);
            Quaternion end = Quaternion.Euler(End.x, End.y, End.z);

            if (bForward == false)
            {
                start = Quaternion.Euler(End.x, End.y, End.z);
                end = Quaternion.Euler(Start.x, Start.y, Start.z);
            }

            Owner = this.gameObject;
            RectTransform rtOwner = Owner.GetComponent<RectTransform>();

            if (rtOwner == null)
            {
                procAct = null;
                break;
            }
            
            rtOwner.rotation = start;

            while (timer < _during)
            {
                rtOwner.rotation = funcEase_Quaternion(start, end, timer / _during);

                yield return null;
                timer += Time.deltaTime;
            }

            rtOwner.rotation = end;

            timer = 0.0f;

            while (timer < _during)
            {
                rtOwner.rotation = funcEase_Quaternion(end, start, timer / _during);

                yield return null;
                timer += Time.deltaTime;
            }

            rtOwner.rotation = start;
            bDone = true;

            actAfter.Invoke();

            if (nMaxLoop != -1)
                ++loop;
        }

        procAct = null;
    }
}
