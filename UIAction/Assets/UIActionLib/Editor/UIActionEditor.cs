using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//시퀸스 관리
public class UIActionEditor : EditorWindow {

    private bool bPreview = false;
    private bool bPlay = false;

    private float fMinTimePos = 0.0f;
    private float fMaxTimePos = 10.0f;
    private float fCurrentTimePos = 0.0f;

    private Vector2 vScrollPos = Vector2.zero;
    private Vector2 vTimeLineScrollPos = Vector2.zero;

    private Color colOriBG = Color.gray;

    private GameObject CurrentSelected = null;
    private Coroutine procPlaySeq = null;

    private TimeControl ctrlTime = new TimeControl();

    [MenuItem("Editor/UIAction")]
    static void Open()
    {
        GetWindow<UIActionEditor>(typeof(SceneView));
    }
    private void Update()
    {
        if (bPlay)
        {
            fCurrentTimePos += Time.fixedDeltaTime;

            if(fCurrentTimePos >= fMaxTimePos)
            {
                fCurrentTimePos = 0.0f;
                bPlay = false;

                UIActionSequence current_seq = CurrentSelected.GetComponent<UIActionSequence>();

                if (current_seq != null)
                    current_seq.ReSet();
            }

            GUI.changed = true;
            Repaint();
        }
    }
    private void OnGUI()
    {
        CurrentSelected = Selection.activeGameObject;

        if (CurrentSelected == null)
        {
            EditorGUILayout.LabelField("Please Select Sequence Object!");
            return;
        }

        UIActionSequence current_seq = CurrentSelected.GetComponent<UIActionSequence>();

        if (current_seq == null)
            return;
        
        GUILayout.BeginHorizontal();

        fCurrentTimePos = EditorGUILayout.FloatField(fCurrentTimePos, GUILayout.Width(30), GUILayout.Height(20));

        if (bPreview)
        {
            ctrlTime.Speed = 1.0f;
            ctrlTime.Play();

            using (new BackgroundColorScope(Color.red))
                bPreview = GUILayout.Toggle(bPreview, bPreview ? "PreView" : "None", "button", GUILayout.Width(60), GUILayout.Height(20));
        }
        else
        {
            ctrlTime.Speed = 0.0f;
            ctrlTime.Stop();
            bPreview = GUILayout.Toggle(bPreview, bPreview ? "PreView" : "None", "button", GUILayout.Width(60), GUILayout.Height(20));
        }

        if (bPlay)
        {
            ctrlTime.Speed = 1.0f;
            ctrlTime.Play();

            using (new BackgroundColorScope(Color.red))
                bPlay = GUILayout.Toggle(bPlay, bPlay ? "Playing" : "Stop", "button", GUILayout.Width(60), GUILayout.Height(20));
        }
        else
        {
            ctrlTime.Speed = 0.0f;
            ctrlTime.Stop();

            bPlay = GUILayout.Toggle(bPlay, bPlay ? "Playing" : "Stop", "button", GUILayout.Width(60), GUILayout.Height(20));
        }

        GUILayout.EndHorizontal();

        //선택된 시퀸스 오브젝트의 계층정보 보는곳
        EditorGUILayout.BeginHorizontal();
        vScrollPos = EditorGUILayout.BeginScrollView(vScrollPos,false,true, GUILayout.Width(200));
        
        for (int i = 0; i < current_seq.Actions.Count; ++i)
        {
            var act = current_seq.Actions[i];
            EditorGUILayout.SelectableLabel(act.gameObject.name,GUILayout.Height(20));

            var have = act.gameObject.GetComponents<UIActionBaseInfo>();
            EditorGUI.indentLevel++;
            for(int j = 0; j < have.Length; ++j)
            {
                var child = have[j];
                EditorGUILayout.SelectableLabel(child.GetType().ToString(), GUILayout.Height(20));
            }
            EditorGUI.indentLevel--;
        }

        EditorGUILayout.EndScrollView();

        vTimeLineScrollPos = EditorGUILayout.BeginScrollView(vTimeLineScrollPos, true, true);
        EditorGUILayout.BeginVertical();
        GUILayout.Space(10.0f);

        fCurrentTimePos = GUILayout.HorizontalSlider(fCurrentTimePos, fMinTimePos, fMaxTimePos,"box","box",GUILayout.Height(2000),GUILayout.ExpandWidth(true));

        ctrlTime.SetMinMaxTime(fMinTimePos, fMaxTimePos);

        var timeLen = ctrlTime.MaxTime - ctrlTime.MinTime;
        var gridline = timeLen * 10.0f; 
        var sliderRect = new Rect(0.0f, 10.0f, 1400.0f - 200.0f, 2000.0f);

        for(int i = 0; i < gridline+1; ++i)
        {
            float cur = (timeLen / gridline * i);
            var x = GetXFromIdx(i, sliderRect.width, gridline);

            if(i < gridline)
                Handles.DrawLine(new Vector2(sliderRect.x + x, sliderRect.y), new Vector2(sliderRect.x + x, sliderRect.y + sliderRect.height));
            
            if(cur % 1.0f == 0 && i != 0)
                Handles.Label(new Vector2(sliderRect.x + x-5.0f, sliderRect.y - 10.0f),cur.ToString("0"));
        }

        for (int i = 0; i < current_seq.Actions.Count; ++i)
        {
            var act = current_seq.Actions[i];
            var have = act.gameObject.GetComponents<UIActionBaseInfo>();
            float sizey = (20.0f * have.Length)+30.0f;

            for (int j = 0; j < have.Length; ++j)
            {
                var child = have[j];
                //딜레이부터 총 길이만큼 그려줘야함
                float x = GetXFromTime(child.Delay, sliderRect.width, gridline);
                float y = 20.0f + 20.0f * j+ sizey * i;
                float w = GetXFromTime(child.During, sliderRect.width, gridline);
                Rect area = new Rect(new Vector2(sliderRect.x + x, sliderRect.y + y), new Vector2(w-5.0f, 5.0f));

                Handles.DrawLine(new Vector2(sliderRect.x + x, sliderRect.y + y), new Vector2(sliderRect.x + x + w, sliderRect.y + y));
                //재생 방식과 반복 횟수에 따라 사각형 길이가 달라짐.
                //기본은 한블럭
                //반복 재생은 횟수만큼 추가로 더 그려준다. (-1 : 무한대)의 경우 그냥 길게 쭉 그려주면됨
                //기본을 제외하고 나머지는 during*2만큼 길어진게 한블럭
                Color colSolid = new Color(0.5f, 0.5f, 0.5f);
                Color colOutLine = Color.red;
                int loop = child.MaxLoop == -1 ? 99999 : child.MaxLoop;

                switch (child.LoopType)
                {
                    case UIActionBaseInfo.UIActionLoopType.UIActionLoop_Looping:
                        colOutLine = Color.green;
                        area.width = w * loop;
                        break;
                    case UIActionBaseInfo.UIActionLoopType.UIActionLoop_Pingpong:
                        colOutLine = Color.blue;
                        area.width = (w * 2.0f) * loop; 
                        break;
                }

                Handles.DrawSolidRectangleWithOutline(area, colSolid, colOutLine);

                if (bPreview || bPlay)
                {
                    child.IsStart = true;
                    float real_start = fCurrentTimePos - child.Delay;

                    if (real_start >= 0.0f)
                    {
                        child.SetCurrentTimePosition(real_start);
                    }
                }
                else
                {
                    child.ReSet();
                }
            }
        }

        EditorGUILayout.EndVertical();

        EditorGUILayout.EndScrollView();

        EditorGUILayout.EndHorizontal();
    }

    public float GetXFromIdx(int _idx, float _w, float _grid) // _t : 0.1단위
    {
        float x = (_w / _grid) * _idx;
        x += 4.0f - 1.5f * (_idx - 1);

        return x;
    }

    public float GetXFromTime(float _t,float _w,float _grid) // _t : 0.1단위
    {
        int idx = (int)(_t*10.0f);
        float x = (_w / _grid) * idx;
        x += 4.0f - 1.5f * (idx - 1);

        return x;
    }
}
