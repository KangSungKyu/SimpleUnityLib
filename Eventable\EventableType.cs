using UnityEngine;
using System.Collections;


public class EventableType<TValueType> //call OnChanged when variable's value changed
{
    public event System.Action<TValueType> OnChangedBefore = null;
    public event System.Action<TValueType> OnChangedAfter = null;

    public EventableType() => originValue = default;
    public EventableType(TValueType v) => originValue = v;
    //eventable<T> e = t;
    public static implicit operator EventableType<TValueType>(TValueType v) { return new EventableType<TValueType>(v); }
    //T t = e;
    public static implicit operator TValueType(EventableType<TValueType> e) { return e.originValue; }

    public override string ToString() { return originValue.ToString(); }

    private TValueType originValue
    {
        get { return originValue; }
        set
        {
            oldValue = originValue;
            OnChangedBefore?.Invoke(oldValue);
            originValue = value;
            OnChangedAfter?.Invoke(originValue);
        }
    }
    private TValueType oldValue = default;
}

/*
public class TestClass
{
    EventableType<int> testValue = 0;

    TestClass()
    {
        testValue.OnChangedBefore += (value) => { System.Console.WriteLine("changed before : {0}", value); };
        testValue.OnChangedAfter += (value) => { System.Console.WriteLine("changed after : {0}", value); };
        testValue = 10;

        //in console :
        //changed before : 0
        //changed after : 10
    }
}
//*/
