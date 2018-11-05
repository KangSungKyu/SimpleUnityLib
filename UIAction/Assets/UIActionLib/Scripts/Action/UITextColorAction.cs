using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UITextColorAction : UIColorActionBase
{
    protected override void ResetUI()
    {
        if (Owner != null)
        {
            Text txt = Owner.GetComponent<Text>();

            if(txt)
            {
                txt.color = bForward == true ? Start : End;
            }
        }
    }
    protected override void SetCurrentTimePos(float _time)
    {
        if (bStart == false)
            return;
        
        Owner = this.gameObject;
        Text txt = Owner.GetComponent<Text>();

        switch (LoopType)
        {
            case UIActionLoopType.UIActionLoop_Once:
                txt.color = funcEase_Color(Start, End, Mathf.Clamp01(_time/During));
                break;
            case UIActionLoopType.UIActionLoop_Looping:
                txt.color = funcEase_Color(Start, End, Mathf.Clamp01((_time % During) / During));
                break;
            case UIActionLoopType.UIActionLoop_Pingpong:
                float w = During * 2.0f;
                if ((_time % w)/w <= 0.5f)
                    txt.color = funcEase_Color(Start, End, Mathf.Clamp01((_time % During) / During));
                else
                    txt.color = funcEase_Color(End, Start, Mathf.Clamp01((_time % During) / During));
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
        Text txt = Owner.GetComponent<Text>();

        if (txt == null)
        {
            procAct = null;
            yield break;
        }

        yield return waitDelay;

        bStart = true;
        
        txt.color = start;

        while (timer < _during)
        {
            txt.color = funcEase_Color(start, end, timer / _during);

            yield return null;
            timer += Time.deltaTime;
        }

        txt.color = end;
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
            Text txt = Owner.GetComponent<Text>();

            if (txt == null)
            {
                procAct = null;
                break;
            }

            txt.color = start;

            while (timer < _during)
            {
                txt.color = funcEase_Color(start, end, timer / _during);

                yield return null;
                timer += Time.deltaTime;
            }

            txt.color = end;
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
            Text txt = Owner.GetComponent<Text>();

            if (txt == null)
            {
                procAct = null;
                break;
            }

            txt.color = start;

            while (timer < _during)
            {
                txt.color = funcEase_Color(start, end, timer / _during);

                yield return null;
                timer += Time.deltaTime;
            }

            txt.color = end;

            timer = 0.0f;

            while (timer < _during)
            {
                txt.color = funcEase_Color(end, start, timer / _during);

                yield return null;
                timer += Time.deltaTime;
            }

            txt.color = start;
            bDone = true;

            actAfter.Invoke();

            if(nMaxLoop != -1)
                ++loop;
        }

        procAct = null;
    }
}
