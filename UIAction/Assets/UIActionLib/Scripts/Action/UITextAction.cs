using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UITextAction : UITextActionBase
{
    protected override void ResetUI()
    {
        if (Owner != null)
        {
            Text txt = Owner.GetComponent<Text>();

            if(txt)
            {
                txt.text = bForward == true ? Start : End;
            }
        }
    }
    protected override void SetCurrentTimePos(float _time)
    {
        if (bStart == false)
            return;
        
        Owner = this.gameObject;
        Text txt = Owner.GetComponent<Text>();
        string[] s_e = { Start, End };
        string[] e_s = { End, Start };

        switch (LoopType)
        {
            case UIActionLoopType.UIActionLoop_Once:
                txt.text = s_e[(int)(Mathf.Clamp01(_time/During))] ;
                break;
            case UIActionLoopType.UIActionLoop_Looping:
                txt.text = s_e[(int)(Mathf.Clamp01((_time % During) / During))];
                break;
            case UIActionLoopType.UIActionLoop_Pingpong:
                float w = During * 2.0f;
                if ((_time % w)/w <= 0.5f)
                    txt.text = s_e[(int)(Mathf.Clamp01((_time % During) / During))];
                else
                    txt.text = e_s[(int)(Mathf.Clamp01((_time % During) / During))];
                break;
        }
    }
    protected override IEnumerator Action_Once(float _during)
    {
        actBefore.Invoke();

        float timer = 0.0f;

        string start = Start;
        string end = End;

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

        txt.text = start;

        yield return new WaitForSeconds(_during);

        txt.text = end;
        bDone = true;
        procAct = null;

        actAfter.Invoke();
    }
    protected override IEnumerator Action_Looping(float _during)
    {
        yield return waitDelay;

        var during = new WaitForSeconds(_during);
        int loop = nMaxLoop == -1 ? -2 : 0;

        while (loop < nMaxLoop)
        {
            actBefore.Invoke();

            bDone = false;

            float timer = 0.0f;

            string start = Start;
            string end = End;

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

            txt.text = start;

            yield return during;

            txt.text = end;
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

        var during = new WaitForSeconds(_during);
        int loop = nMaxLoop == -1 ? -2 : 0;

        while (loop < nMaxLoop)
        {
            actBefore.Invoke();

            bDone = false;

            float timer = 0.0f;

            string start = Start;
            string end = End;

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

            txt.text = start;

            yield return during;

            txt.text = end;

            timer = 0.0f;

            yield return during;

            txt.text = start;
            bDone = true;

            actAfter.Invoke();

            if(nMaxLoop != -1)
                ++loop;
        }

        procAct = null;
    }
}
