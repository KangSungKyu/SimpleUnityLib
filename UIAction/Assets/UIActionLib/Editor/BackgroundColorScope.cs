using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//시퀸스 관리
public class BackgroundColorScope : GUI.Scope
{
    private readonly Color color;

    public BackgroundColorScope(Color color)
    {
        this.color = GUI.backgroundColor;
        GUI.backgroundColor = color;
    }


    protected override void CloseScope()
    {
        GUI.backgroundColor = color;
    }
}
