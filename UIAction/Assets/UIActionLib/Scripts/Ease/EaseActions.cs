using UnityEngine;
using System.Collections;

public partial class EaseActions<T>
{
    public delegate T EaseFunc(T _start, T _end,float _t);
}
