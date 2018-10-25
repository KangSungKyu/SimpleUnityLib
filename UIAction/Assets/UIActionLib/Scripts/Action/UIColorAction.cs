using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIColorAction : UIColorActionBase
{
    protected override void ResetUI()
    {
        if (Owner != null)
        {
            Image img = Owner.GetComponent<Image>();

            if(img)
            {
                img.color = bForward == true ? Start : End;
            }
        }
    }
    protected override void SetCurrentTimePos(float _time)
    {
        if (bStart == false)
            return;
        
        Owner = this.gameObject;
        Image img = Owner.GetComponent<Image>();

        switch (LoopType)
        {
            case UIActionLoopType.UIActionLoop_Once:
                img.color = funcEase_Color(Start, End, Mathf.Clamp01(_time/During));
                break;
            case UIActionLoopType.UIActionLoop_Looping:
                img.color = funcEase_Color(Start, End, Mathf.Clamp01((_time % During) / During));
                break;
            case UIActionLoopType.UIActionLoop_Pingpong:
                float w = During * 2.0f;
                if ((_time % w)/w <= 0.5f)
                    img.color = funcEase_Color(Start, End, Mathf.Clamp01((_time % During) / During));
                else
                    img.color = funcEase_Color(End, Start, Mathf.Clamp01((_time % During) / During));
                break;
        }
    }
    protected override IEnumerator Action_Once(float _during)
    {
        actBefore.Invoke();

        float timer = 0.0f;

        Color start = Start;
        Color end = End;

        if (bForward == false)
        {
            start = End;
            end = Start;
        }

        Owner = this.gameObject;
        Image img = Owner.GetComponent<Image>();

        if (img == null)
        {
            procAct = null;
            yield break;
        }

        yield return waitDelay;

        bStart = true;
        
        img.color = start;

        while (timer < _during)
        {
            img.color = funcEase_Color(start, end, timer / _during);

            yield return null;
            timer += Time.deltaTime;
        }

        img.color = end;
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

            Color start = Start;
            Color end = End;

            if (bForward == false)
            {
                start = End;
                end = Start;
            }

            Owner = this.gameObject;
            Image img = Owner.GetComponent<Image>();

            if (img == null)
            {
                procAct = null;
                break;
            }

            img.color = start;

            while (timer < _during)
            {
                img.color = funcEase_Color(start, end, timer / _during);

                yield return null;
                timer += Time.deltaTime;
            }

            img.color = end;
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

            Color start = Start;
            Color end = End;

            if (bForward == false)
            {
                start = End;
                end = Start;
            }

            Owner = this.gameObject;
            Image img = Owner.GetComponent<Image>();

            if (img == null)
            {
                procAct = null;
                break;
            }

            img.color = start;

            while (timer < _during)
            {
                img.color = funcEase_Color(start, end, timer / _during);

                yield return null;
                timer += Time.deltaTime;
            }

            img.color = end;

            timer = 0.0f;

            while (timer < _during)
            {
                img.color = funcEase_Color(end, start, timer / _during);

                yield return null;
                timer += Time.deltaTime;
            }

            img.color = start;
            bDone = true;

            actAfter.Invoke();

            if(nMaxLoop != -1)
                ++loop;
        }

        procAct = null;
    }
}
