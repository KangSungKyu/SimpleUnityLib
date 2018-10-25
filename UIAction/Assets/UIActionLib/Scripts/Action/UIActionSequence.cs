using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class UIActionSequence : UIActionBaseInfo
{
    public List<GameObject> Actions = new List<GameObject>(); 

    private List<GameObject> liActs = new List<GameObject>();

    public void Clear()
    {
        AllStopReSet();
        liActs.Clear();
    }
    public void Add(GameObject _act)
    {
        liActs.Add(_act);
    }
    public void RemoveAt(int _idx)
    {
        StopReSet(_idx);

        liActs.RemoveAt(_idx);
    }
    public void Insert(int _idx, GameObject _act)
    {
        liActs.Insert(_idx, _act);
    }

    public override void Play(bool _forward = true)
    {
        bForward = _forward;
        bDone = false;
        bStart = false;

        AllStopReSet();

        if (procAct != null)
            StopCoroutine(procAct);

        if (Actions.Count > 0)
        {
            liActs = Actions;
        }

        waitDelay = new WaitForSeconds(Delay);

        LoopType = UIActionLoopType.UIActionLoop_Once;

        switch(LoopType)
        {
            case UIActionLoopType.UIActionLoop_Once:
                procAct = StartCoroutine(Action_Once(0.0f));
                break;
        }
    }
    public void Stop(int _idx)
    {
        if (0 <= _idx && _idx < liActs.Count)
        {
            var obj = liActs[_idx];

            var acts = obj.GetComponents<UIActionBaseInfo>();

            for(int i = 0; i < acts.Length; ++i)
            {
                if (acts[i] != null)
                    acts[i].Stop();
            }
        }
    }
    public void ReSet(int _idx)
    {
        if (0 <= _idx && _idx < liActs.Count)
        {
            var obj = liActs[_idx];

            var acts = obj.GetComponents<UIActionBaseInfo>();

            for (int i = 0; i < acts.Length; ++i)
            {
                if (acts[i] != null)
                    acts[i].ReSet();
            }
        }
    }
    public void StopReSet(int _idx)
    {
        if (0 <= _idx && _idx < liActs.Count)
        {
            var obj = liActs[_idx];

            var acts = obj.GetComponents<UIActionBaseInfo>();

            for (int i = 0; i < acts.Length; ++i)
            {
                if (acts[i] != null)
                {
                    acts[i].Stop();
                    acts[i].ReSet();
                }
            }
        }
    }
    public void AllStop()
    {
        if (liActs.Count > 0)
        {
            liActs.ForEach(
                (obj) =>
                {
                    var acts = obj.GetComponents<UIActionBaseInfo>();

                    for (int i = 0; i < acts.Length; ++i)
                    {
                        if (acts[i] != null)
                        {
                            acts[i].Stop();
                        }
                    }
                });
        }
    }
    public void AllReSet()
    {
        if (liActs.Count > 0)
        {
            liActs.ForEach(
                (obj) =>
                {
                    var acts = obj.GetComponents<UIActionBaseInfo>();

                    for (int i = 0; i < acts.Length; ++i)
                    {
                        if (acts[i] != null)
                        {
                            acts[i].ReSet();
                        }
                    }
                });
        }
    }
    public void AllStopReSet()
    {
        if (liActs.Count > 0)
        {
            liActs.ForEach(
                (obj) =>
                {
                    var acts = obj.GetComponents<UIActionBaseInfo>();

                    for (int i = 0; i < acts.Length; ++i)
                    {
                        if (acts[i] != null)
                        {
                            acts[i].Stop();
                            acts[i].ReSet();
                        }
                    }
                });
        }
    }
    
    protected override void ResetUI()
    {
        AllStopReSet();
    }
    protected override void SetCurrentTimePos(float _time)
    {
        if (bStart == false)
            return;
    }
    protected override IEnumerator Action_Once(float _during)
    {
        if (liActs.Count <= 0)
        {
            procAct = null;
            yield break;
        }

        yield return waitDelay;

        for (int i = 0; i < liActs.Count; ++i)
        {
            var obj = liActs[i];

            if (obj == null)
                yield return null;

            var acts = obj.GetComponents<UIActionBaseInfo>();

            for (int j = 0; j < acts.Length; ++j)
            {
                var act = acts[j];

                yield return new WaitForSeconds(act.Delay);

                act.Play();
            }
        }

        procAct = null;
        bDone = true;
    }
    protected override IEnumerator Action_Looping(float _during)
    {
        if (liActs.Count <= 0)
        {
            procAct = null;
            yield break;
        }

        yield return waitDelay;

        bStart = true;

        int loop = nMaxLoop == -1 ? -2 : 0;

        while (loop < nMaxLoop)
        {
            bDone = false;

            for (int i = 0; i < liActs.Count; ++i)
            {
                var obj = liActs[i];

                if (obj == null)
                    yield return null;

                var acts = obj.GetComponents<UIActionBaseInfo>();

                for (int j = 0; j < acts.Length; ++j)
                {
                    var act = acts[j];

                    if (act.LoopType == UIActionLoopType.UIActionLoop_Once)
                    {
                        yield return new WaitForSeconds(act.Delay);

                        act.Play();
                    }
                }
            }

            bDone = true;

            if (nMaxLoop != -1)
                ++loop;
        }

        procAct = null;
    }
    protected override IEnumerator Action_Pingpong(float _during)
    {
        if (liActs.Count <= 0)
        {
            procAct = null;
            yield break;
        }

        yield return waitDelay;

        bStart = true;

        int loop = nMaxLoop == -1 ? -2 : 0;

        while (loop < nMaxLoop)
        {
            bDone = false;

            float long_during = liActs.Max((obj) =>
            {
                return obj.GetComponents<UIActionBaseInfo>().Max((act) =>
                {
                    return act.During;
                });
            });

            for (int i = 0; i < liActs.Count; ++i)
            {
                var obj = liActs[i];

                if (obj == null)
                    yield return null;

                var acts = obj.GetComponents<UIActionBaseInfo>();

                for (int j = 0; j < acts.Length; ++j)
                {
                    var act = acts[j];

                    if (act.LoopType == UIActionLoopType.UIActionLoop_Once)
                    {
                        yield return new WaitForSeconds(act.Delay);

                        act.Play();
                    }
                }
            }

            yield return new WaitForSeconds(long_during);

            for (int i = liActs.Count-1; i >= 0; --i)
            {
                var obj = liActs[i];

                if (obj == null)
                    yield return null;

                var acts = obj.GetComponents<UIActionBaseInfo>();

                for (int j = 0; j < acts.Length; ++j)
                {
                    var act = acts[j];

                    if (act.LoopType == UIActionLoopType.UIActionLoop_Once)
                    {
                        yield return new WaitForSeconds(act.Delay);

                        act.Play();
                    }
                }
            }

            bDone = true;

            if (nMaxLoop != -1)
                ++loop;
        }

        procAct = null;
    }
}
