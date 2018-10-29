using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UITypewritterAction : UITextActionBase
{
    public enum CodeType
    {
        Code_NoneKor = 0,
        Code_Kor,
    };

    public CodeType eCodeType = CodeType.Code_NoneKor;
    public float fInterval = 0.1f;

    private Coroutine procForward = null;
    private Coroutine procBackward = null;

    private void SplitWord_NoneKor(string _text, ref List<List<string>> _splited)
    {
        for (int i = 0; i < _text.Length; ++i)
        {
            string word = _text[i].ToString();
            List<string> jamo = new List<string>();

            jamo.Add(word);

            _splited.Add(jamo);
        }
    }
    private void SplitWord_Kor(string _text,ref List<List<string>> _splited)
    {
        for (int i = 0; i < _text.Length; ++i)
        {
            string word = _text[i].ToString();
            List<string> jamo = new List<string>();
            
            string f = "";
            string m = "";
            string l = "";

            KorWordMaker.SplitKorWord(word, ref f, ref m, ref l);

            if (f.Equals("") == false && m.Equals("") && l.Equals(""))
            {
                jamo.Add(f);
            }
            else
            {
                jamo.Add(f);
                jamo.Add(m);
                jamo.Add(l);
            }

            _splited.Add(jamo);
        }
    }

    private IEnumerator Action_Forward(string _input,List<List<string>> liSplited,Text txt)
    {
        var interval = new WaitForSeconds(fInterval);

        string text = _input;

        //테스트 중입니다
        //""+ㅌ -> ""+테 ->"테"+ㅅ -> "테"+스
        for (int i = 0; i < liSplited.Count; ++i)
        {
            List<string> ss = liSplited[i];
            string cur = "";
            string cur_pos = text;

            for (int j = 0; j < ss.Count; ++j)
            {
                yield return interval;

                if (eCodeType == CodeType.Code_NoneKor) //한글을 제외하고는 그냥 한단어씩 그대로 출력
                {
                    cur = ss[j];
                }
                else //한글은 자모별로 다 따로 액션을 취함
                {
                    string f = j >= 0 ? ss[0] : "";

                    if (ss.Count != 1)
                    {
                        string m = j >= 1 ? ss[1] : "";
                        string l = j >= 2 ? ss[2] : "";

                        cur = KorWordMaker.GetKorWord(f, m, l);
                    }
                    else
                    {
                        cur = f;
                    }
                }

                txt.text = string.Concat(cur_pos, cur);
            }

            text = string.Concat(text, cur);
        }

        procForward = null;
    }
    private IEnumerator Action_Backward(string _input,List<List<string>> liSplited,Text txt)
    {
        var interval = new WaitForSeconds(fInterval);
        string text = _input;

        //테스트 중입니다
        //테스트 중입니다 -> 테스트 중입니ㄷ -> 테스트 중입니
        for (int i = liSplited.Count - 1; i >= 0; --i)
        {
            List<string> ss = liSplited[i];
            string cur = "";
            string cur_pos = text.Remove(text.Length - 1, 1);

            for (int j = ss.Count - 1; j >= 0; --j)
            {
                yield return interval;

                if (eCodeType == CodeType.Code_NoneKor) //한글을 제외하고는 그냥 한단어씩 그대로 출력
                {
                    cur = ss[j];
                }
                else //한글은 자모별로 다 따로 액션을 취함
                {
                    string f = j >= 0 ? ss[0] : "";

                    if (ss.Count != 1)
                    {
                        string m = j >= 1 ? ss[1] : "";
                        string l = j >= 2 ? ss[2] : "";

                        cur = KorWordMaker.GetKorWord(f, m, l);
                    }
                    else
                    {
                        cur = f;
                    }
                }

                txt.text = string.Concat(cur_pos, cur);
            }

            text = cur_pos;
        }

        procBackward = null;
    }

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

        List<List<string>> liSplited = new List<List<string>>();

        if (eCodeType == CodeType.Code_NoneKor)
            SplitWord_NoneKor(bForward ? end : start, ref liSplited);
        else
            SplitWord_Kor(bForward ? end : start, ref liSplited);


        if (bForward)
        {
            if(procForward != null)
            {
                StopCoroutine(procForward);
                procForward = null;
            }
            if (procForward == null)
                procForward = StartCoroutine(Action_Forward(start, liSplited, txt));

            yield return procForward;
        }
        else
        {
            if (procBackward != null)
            {
                StopCoroutine(procBackward);
                procBackward = null;
            }
            if (procBackward == null)
                procBackward = StartCoroutine(Action_Backward(start, liSplited, txt));

            yield return procBackward;
        }

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

        string start = Start;
        string end = End;

        if (bForward == false)
        {
            start = End;
            end = Start;
        }

        List<List<string>> liSplited = new List<List<string>>();

        if (eCodeType == CodeType.Code_NoneKor)
            SplitWord_NoneKor(bForward ? end : start, ref liSplited);
        else
            SplitWord_Kor(bForward ? end : start, ref liSplited);

        while (loop < nMaxLoop)
        {
            actBefore.Invoke();

            bDone = false;

            Owner = this.gameObject;
            Text txt = Owner.GetComponent<Text>();

            if (txt == null)
            {
                procAct = null;
                break;
            }

            txt.text = start;

            if (bForward)
            {
                if (procForward != null)
                {
                    StopCoroutine(procForward);
                    procForward = null;
                }
                if (procForward == null)
                    procForward = StartCoroutine(Action_Forward(start, liSplited, txt));

                yield return procForward;
            }
            else
            {
                if (procBackward != null)
                {
                    StopCoroutine(procBackward);
                    procBackward = null;
                }
                if (procBackward == null)
                    procBackward = StartCoroutine(Action_Backward(start, liSplited, txt));

                yield return procBackward;
            }

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

        string start = Start;
        string end = End;

        if (bForward == false)
        {
            start = End;
            end = Start;
        }

        List<List<string>> liSplited = new List<List<string>>();

        if (eCodeType == CodeType.Code_NoneKor)
            SplitWord_NoneKor(bForward ? end : start, ref liSplited);
        else
            SplitWord_Kor(bForward ? end : start, ref liSplited);

        while (loop < nMaxLoop)
        {
            actBefore.Invoke();

            bDone = false;

            Owner = this.gameObject;
            Text txt = Owner.GetComponent<Text>();

            if (txt == null)
            {
                procAct = null;
                break;
            }

            txt.text = start;

            if (bForward)
            {
                if (procForward != null)
                {
                    StopCoroutine(procForward);
                    procForward = null;
                }
                if (procForward == null)
                    procForward = StartCoroutine(Action_Forward(start, liSplited, txt));

                yield return procForward;
            }
            else
            {
                if (procBackward != null)
                {
                    StopCoroutine(procBackward);
                    procBackward = null;
                }
                if (procBackward == null)
                    procBackward = StartCoroutine(Action_Backward(start, liSplited, txt));

                yield return procBackward;
            }

            txt.text = end;
            
            if (bForward)
            {
                if (procBackward != null)
                {
                    StopCoroutine(procBackward);
                    procBackward = null;
                }
                if (procBackward == null)
                    procBackward = StartCoroutine(Action_Backward(end, liSplited, txt));

                yield return procBackward;
            }
            else
            {
                if (procForward != null)
                {
                    StopCoroutine(procForward);
                    procForward = null;
                }
                if (procForward == null)
                    procForward = StartCoroutine(Action_Forward(end, liSplited, txt));

                yield return procForward;
            }

            txt.text = start;
            bDone = true;

            actAfter.Invoke();

            if(nMaxLoop != -1)
                ++loop;
        }

        procAct = null;
    }
}
