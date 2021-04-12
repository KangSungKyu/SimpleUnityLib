using System;

public class EventableType<TValueType> //call OnChanged when variable's value changed
{
    public event Action<TValueType> OnChangedBefore = null;
    public event Action<TValueType> OnChangedAfter = null;

    public EventableType() => originValue = default;
    public EventableType(TValueType v) => originValue = v;
    //eventable<T> e = t;
    public static implicit operator EventableType<TValueType>(TValueType v)
    {
        return new EventableType<TValueType>(v);
    }
    //T t = e;
    public static implicit operator TValueType(EventableType<TValueType> e)
    {
        return e.originValue;
    }

    public override string ToString()
    {
        return originValue.ToString();
    }

    public void AddChangedBeforeEvent(Action<TValueType> before)
    {
        Delegate[] invocationList = null;
        
        bool isContain = false;

        if (OnChangedBefore != null)
        {
            invocationList = OnChangedBefore.GetInvocationList();

            foreach (var invocation in invocationList)
            {
                if (invocation.Equals(before) == true)
                {
                    isContain = true;
                    Debug.LogError("dont add contained event dispatcher");
                    break;
                }
            }
        }

        if(isContain == false)
            OnChangedBefore += before;
    }

    public void AddChangedAfterEvent(Action<TValueType> after)
    {
        Delegate[] invocationList = null;

        bool isContain = false;

        if (OnChangedAfter != null)
        {
            invocationList = OnChangedAfter.GetInvocationList();

            foreach (var invocation in invocationList)
            {
                if (invocation.Equals(after) == true)
                {
                    isContain = true;
                    Debug.LogError("dont add contained event dispatcher");
                    break;
                }
            }
        }

        if (isContain == false)
            OnChangedAfter += after;
    }

    public void Dirty(TValueType value)
    {
        oldValue = originValue;
        OnChangedBefore?.Invoke(oldValue);
        originValue = value;
        OnChangedAfter?.Invoke(originValue);
    }


    private TValueType originValue = default;
    private TValueType oldValue = default;
}
