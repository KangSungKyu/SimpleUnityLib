using UnityEngine;
using System.Collections;
using UnityEditor;

public class TimeControl
{
    public bool IsLoop { get; set; }
    public bool IsPlaying { get; private set; }
    public float Speed { get; set; }
    public float CurrentTime
    {
        get
        {
            if(IsLoop)
                fCurrentTime = Mathf.Repeat(fCurrentTime, MaxTime);

            fCurrentTime = Mathf.Clamp(fCurrentTime, MinTime, MaxTime);

            return fCurrentTime;
        }
        set
        {
            fCurrentTime = value;
        }
    }
    public float MinTime { get; private set; }
    public float MaxTime { get; private set; }

    private float fCurrentTime = 0.0f;
    private double dLastFrameEditorTime = 0.0;

    public TimeControl()
    {
        EditorApplication.update += TimeUpdate;
    }

    public void TimeUpdate()
    {
        if (IsPlaying)
        {
            var timeSinceStartup = EditorApplication.timeSinceStartup;
            var deltaTime = timeSinceStartup - dLastFrameEditorTime;

            dLastFrameEditorTime = timeSinceStartup;

            fCurrentTime += (float)deltaTime*Speed;
        }
    }
    public void Play()
    {
        if (IsPlaying == false)
        {
            IsPlaying = true;
            dLastFrameEditorTime = EditorApplication.timeSinceStartup;
        }
    }
    public void Pause()
    {
        IsPlaying = false;
    }
    public void Stop()
    {
        if (IsPlaying == true)
        {
            IsPlaying = false;
            fCurrentTime = 0.0f;
        }
    }
    public void SetMinMaxTime(float _min,float _max)
    {
        this.MinTime = _min;
        this.MaxTime = _max;
    }
}
