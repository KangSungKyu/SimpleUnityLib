using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class KorWordMaker
{
    private static List<string> kor_f = new List<string> { "ㄱ", "ㄲ", "ㄴ", "ㄷ", "ㄸ", "ㄹ", "ㅁ", "ㅂ", "ㅃ", "ㅅ", "ㅆ", "ㅇ", "ㅈ", "ㅉ", "ㅊ", "ㅋ", "ㅌ", "ㅍ", "ㅎ" };
    private static List<string> kor_m = new List<string> { "ㅏ", "ㅐ", "ㅑ", "ㅒ", "ㅓ", "ㅔ", "ㅕ", "ㅖ", "ㅗ", "ㅘ", "ㅙ", "ㅚ", "ㅛ", "ㅜ", "ㅝ", "ㅞ", "ㅟ", "ㅠ", "ㅡ", "ㅢ", "ㅣ" };
    private static List<string> kor_l = new List<string> { "", "ㄱ", "ㄲ", "ㄳ", "ㄴ", "ㄵ", "ㄶ", "ㄷ", "ㄹ", "ㄺ", "ㄻ", "ㄼ", "ㄽ", "ㄾ", "ㄿ", "ㅀ", "ㅁ", "ㅂ", "ㅄ", "ㅅ", "ㅆ", "ㅇ", "ㅈ", "ㅊ", "ㅋ", "ㅌ", "ㅍ", "ㅎ" };

    public static string GetKorWord(string _f, string _m, string _l)
    {
        int idx_f = kor_f.IndexOf(_f);
        int idx_m = kor_m.IndexOf(_m);
        int idx_l = kor_l.IndexOf(_l);

        if (idx_f == -1)
            return "";
        if (idx_m == -1)
            return _f;

        uint idx_word = (uint)((idx_f * 588) + (idx_m * 28) + idx_l) + 44032;
        char ch = System.Convert.ToChar(idx_word);

        return ch.ToString();
    }
    public static void SplitKorWord(string _word, ref string _f, ref string _m, ref string _l)
    {
        uint kor_base = 0xAC00;
        uint kor_last = 0xD79F;
        uint kor_code = System.Convert.ToUInt32(_word[0]);

        _f = "";
        _m = "";
        _l = "";

        if (kor_code < kor_base || kor_code > kor_last)
        { 
            _f = _word;
            return;
        }

        uint kor_ucode = kor_code - kor_base;
        uint idx_f = kor_ucode / (21 * 28);
        kor_ucode %= (21 * 28);
        uint idx_m = kor_ucode / 28;
        kor_ucode %= 28;
        uint idx_l = kor_ucode;

        _f = kor_f[(int)idx_f];
        _m = kor_m[(int)idx_m];
        _l = kor_l[(int)idx_l];
    }
}
