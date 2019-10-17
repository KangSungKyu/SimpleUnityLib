using UnityEngine;
using System.Collections;

public class EventableType<TValueType> //call OnChanged when variable's value changed
{
    public event System.Action<TValueType> OnChangedBefore = null;
    public event System.Action<TValueType> OnChangedAfter = null;

    public EventableType() => value = default;
    public EventableType(TValueType v) => value = v;
    //eventable<T> e = t;
    public static implicit operator EventableType<TValueType>(TValueType v) { return new EventableType<TValueType>(v); }
    //T t = e;
    public static implicit operator TValueType(EventableType<TValueType> e) { return e.value; }

    public override string ToString() { return value.ToString(); }

    private TValueType value
    {
        get { return this.value; }
        set
        {
            oldValue = this.value;
            OnChangedBefore?.Invoke(oldValue);
            this.value = value;
            OnChangedAfter?.Invoke(this.value);
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
