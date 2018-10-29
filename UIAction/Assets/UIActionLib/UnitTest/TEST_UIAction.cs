using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.UI;

public class TEST_UIAction {

    private GameObject Canvas = null;
    private GameObject Actor = null;
    private RectTransform rtActor = null;
    private UIPositionAction actPosition = null;
    private UIScaleAction actScale = null;
    private UIRotateAction actRotation = null;
    private UIColorAction actColor = null;
    private UITextAction actText = null;
    private Image imgActor = null;
    private Text txtActor = null;
    
	public void UIAction_Create() {
        // Use the Assert class to test conditions.

        if (Canvas == null)
            Canvas = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Canvas"));
        if(Actor == null)
        {
            Actor = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Actor"));
            rtActor = Actor.AddComponent<RectTransform>();

            rtActor.SetParent(Canvas.transform);

            actPosition = Actor.AddComponent<UIPositionAction>();
            actScale = Actor.AddComponent<UIScaleAction>();
            actRotation = Actor.AddComponent<UIRotateAction>();
            actColor = Actor.AddComponent<UIColorAction>();
            actText = Actor.AddComponent<UITextAction>();
        }
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator TEST_UIAction_Position_Once_Lerp() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        UIAction_Create();

        yield return null;

        actPosition.Start = Vector3.zero;
        actPosition.End = new Vector3(0.0f, 100.0f, 0.0f);
        actPosition.LoopType = UIActionBaseInfo.UIActionLoopType.UIActionLoop_Once;
        actPosition.EaseType = UIActionBaseInfo.UIActionEaseType.UIActionEase_Lerp;
        actPosition.Delay = 0.0f;
        actPosition.During = 1.0f;

        actPosition.IsStart = true;
        actPosition.SetCurrentTimePosition(0.0f);
        yield return null;
        Assert.AreEqual(Vector2.zero, rtActor.anchoredPosition);
        actPosition.SetCurrentTimePosition(0.5f);
        yield return null;
        Assert.AreEqual(new Vector2(0.0f,50.0f), rtActor.anchoredPosition);
        actPosition.SetCurrentTimePosition(actPosition.During);
        yield return null;
        Assert.AreEqual(new Vector2(0.0f, 100.0f), rtActor.anchoredPosition);
    }
    [UnityTest]
    public IEnumerator TEST_UIAction_Scale_Once_Lerp()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        UIAction_Create();

        yield return null;

        actScale.Start = Vector3.one;
        actScale.End = Vector3.one * 2.0f;
        actScale.LoopType = UIActionBaseInfo.UIActionLoopType.UIActionLoop_Once;
        actScale.EaseType = UIActionBaseInfo.UIActionEaseType.UIActionEase_Lerp;
        actScale.Delay = 0.0f;
        actScale.During = 1.0f;

        actScale.IsStart = true;
        actScale.SetCurrentTimePosition(0.0f);
        yield return null;
        Assert.AreEqual(Vector3.one, rtActor.localScale);
        actScale.SetCurrentTimePosition(0.5f);
        yield return null;
        Assert.AreEqual(new Vector3(1.5f, 1.5f,1.5f), rtActor.localScale);
        actScale.SetCurrentTimePosition(actScale.During);
        yield return null;
        Assert.AreEqual(Vector3.one*2.0f, rtActor.localScale);
    }
    [UnityTest]
    public IEnumerator TEST_UIAction_Rotation_Once_Lerp()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        UIAction_Create();

        yield return null;

        actRotation.Start = new Vector3(0.0f,0.0f,0.0f);
        actRotation.End = new Vector3(0.0f, 0.0f, 90.0f);
        actRotation.LoopType = UIActionBaseInfo.UIActionLoopType.UIActionLoop_Once;
        actRotation.EaseType = UIActionBaseInfo.UIActionEaseType.UIActionEase_Lerp;
        actRotation.Delay = 0.0f;
        actRotation.During = 1.0f;

        actRotation.IsStart = true;
        actRotation.SetCurrentTimePosition(0.0f);
        yield return null;
        Assert.AreEqual(Quaternion.Euler(0.0f,0.0f,0.0f), rtActor.rotation);
        actRotation.SetCurrentTimePosition(0.5f);
        yield return null;
        Assert.AreEqual(Quaternion.SlerpUnclamped(Quaternion.Euler(0.0f, 0.0f, 0.0f),Quaternion.Euler(0.0f,0.0f,90.0f),0.5f), rtActor.rotation);
        actRotation.SetCurrentTimePosition(actRotation.During);
        yield return null;
        Assert.AreEqual(Quaternion.Euler(0.0f, 0.0f, 90.0f), rtActor.rotation);
    }
    [UnityTest]
    public IEnumerator TEST_UIAction_Color_Once_Lerp()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        UIAction_Create();

        if (txtActor != null)
            Component.Destroy(txtActor);

        yield return null;

        if (imgActor == null)
            imgActor = Actor.AddComponent<Image>();

        yield return null;

        actColor.Start = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        actColor.End = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        actColor.LoopType = UIActionBaseInfo.UIActionLoopType.UIActionLoop_Once;
        actColor.EaseType = UIActionBaseInfo.UIActionEaseType.UIActionEase_Lerp;
        actColor.Delay = 0.0f;
        actColor.During = 1.0f;

        actColor.IsStart = true;
        actColor.SetCurrentTimePosition(0.0f);
        yield return null;
        Assert.AreEqual(new Color(1.0f,0.0f,0.0f,1.0f), imgActor.color);
        actColor.SetCurrentTimePosition(0.5f);
        yield return null;
        Assert.AreEqual(new Color(1.0f,0.5f,0.5f,1.0f), imgActor.color);
        actColor.SetCurrentTimePosition(actColor.During);
        yield return null;
        Assert.AreEqual(new Color(1.0f, 1.0f, 1.0f, 1.0f), imgActor.color);
    }
    [UnityTest]
    public IEnumerator TEST_UIAction_Text_Once_Lerp()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        UIAction_Create();

        if (imgActor != null)
            Component.Destroy(imgActor);

        yield return null;

        if (txtActor == null)
            txtActor = Actor.AddComponent<Text>();

        yield return null;

        actText.Start = "test";
        actText.End = "change text!";
        actText.LoopType = UIActionBaseInfo.UIActionLoopType.UIActionLoop_Once;
        actText.EaseType = UIActionBaseInfo.UIActionEaseType.UIActionEase_Lerp;
        actText.Delay = 0.0f;
        actText.During = 1.0f;

        actText.IsStart = true;
        actText.SetCurrentTimePosition(0.0f);
        yield return null;
        Assert.AreEqual("test", txtActor.text);
        actText.SetCurrentTimePosition(actText.During);
        yield return null;
        Assert.AreEqual("change text!", txtActor.text);
    }
}
