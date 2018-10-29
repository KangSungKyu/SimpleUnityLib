using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class Test_KorWord {

	[Test]
	public void Test_KorWordSimplePasses() {
        // Use the Assert class to test conditions.
        string result = KorWordMaker.GetKorWord("ㅌ", "ㅔ", "");

        Assert.AreEqual("테", result);
    }
    [Test]
    public void Test_KorWordSimplePasses2()
    {
        // Use the Assert class to test conditions.
        string word = "강";
        string f = "";
        string m = "";
        string l = "";

        KorWordMaker.SplitKorWord(word, ref f, ref m, ref l);

        string ret = KorWordMaker.GetKorWord(f, m, l);

        Assert.AreEqual("강", ret);
    }
    [Test]
    public void Test_KorWordSimplePasses3()
    {
        // Use the Assert class to test conditions.
        string word = "가";
        string f = "";
        string m = "";
        string l = "";

        KorWordMaker.SplitKorWord(word, ref f, ref m, ref l);

        string ret = KorWordMaker.GetKorWord(f, m, l);

        Assert.AreEqual("가", ret);
    }
    [Test]
    public void Test_KorWordSimplePasses4()
    {
        // Use the Assert class to test conditions.
        string word = "ㄱ";
        string f = "";
        string m = "";
        string l = "";

        KorWordMaker.SplitKorWord(word, ref f, ref m, ref l);

        string ret = KorWordMaker.GetKorWord(f, m, l);

        Assert.AreEqual("ㄱ", ret);
    }
    [Test]
    public void Test_KorWordSimplePasses5()
    {
        // Use the Assert class to test conditions.
        string word = " ";
        string f = "";
        string m = "";
        string l = "";

        KorWordMaker.SplitKorWord(word, ref f, ref m, ref l);

        string ret = KorWordMaker.GetKorWord(f, m, l);

        Assert.AreEqual("", ret);
    }
    [Test]
    public void Test_KorWordSimplePasses6()
    {
        // Use the Assert class to test conditions.
        string word = ".";
        string f = "";
        string m = "";
        string l = "";

        KorWordMaker.SplitKorWord(word, ref f, ref m, ref l);

        string ret = KorWordMaker.GetKorWord(f, m, l);

        Assert.AreEqual(".", f);
    }
}
