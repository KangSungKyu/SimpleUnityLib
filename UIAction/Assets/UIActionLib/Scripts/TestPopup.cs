using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPopup : BasePopup {

    public override void ShowContent()
    {
    }

    public void Test()
    {
        if (IsEnable)
            Close();
        else
            Show();
    }
}
