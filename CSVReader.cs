using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStruct
{
    public class CSVReader
    {
        private bool isfirstLineToColumn = true;
        private bool isLoaded = false;

        private string lineToken = "\n"; //전체를 줄단위로 자를때
        private string stringToken = ","; //한줄을 자를때

        private string textAsset = "";

        private List<string> columnsData = new List<string>();
        private Dictionary<string, List<string>> csvData = new Dictionary<string, List<string>>();

        public CSVReader(string asset, bool firstLineToColume = true, string lineTok = "\n", string stringTok = ",")
        {
            isLoaded = Load(asset, firstLineToColume, lineTok, stringTok);
        }

        public bool Load(string asset, bool firstLineToColume = true, string lineTok = "\n", string stringTok = ",")
        {
            bool ret = false;

            if (string.IsNullOrEmpty(asset) == true)
                return ret;

            textAsset = asset;
            isfirstLineToColumn = firstLineToColume;
            lineToken = lineTok;
            stringToken = stringTok;

            string [] lines = asset.Split(new string[] { lineToken, }, StringSplitOptions.None);

            if (isfirstLineToColumn == true && lines.Length <= 1)
                return ret;

            csvData.Clear();
            columnsData.Clear();

            int lineIdx = 0;
            int colIdx = 0;
            string[] columns = lines[0].Split(new string[] { stringToken, }, StringSplitOptions.None);

            for (colIdx = 0; colIdx < columns.Length; ++colIdx)
            {
                string column = isfirstLineToColumn == true ? columns[colIdx].ToLower() : $"{colIdx}";

                if (csvData.ContainsKey(column) == false)
                {
                    column = RemoveString(column, "\r");

                    columnsData.Add(column);
                    csvData.Add(column, new List<string>());
                }
            }

            for (lineIdx = 1; lineIdx < lines.Length; ++lineIdx)
            {
                if (string.IsNullOrEmpty(lines[lineIdx]) == false)
                {
                    columns = lines[lineIdx].Split(new string[] { stringToken, }, StringSplitOptions.None);
                    
                    for (colIdx = 0; colIdx < columns.Length; ++colIdx)
                    {
                        string column = columnsData[colIdx];
                        string text = columns[colIdx];

                        if (text.ToLower().Equals("true") == true)
                            text = "1";

                        text = RemoveString(text, "\r");
                        text = RemoveString(text, "#N/A");

                        csvData[column].Add(text);
                    }
                }
            }

            ret = true;
            isLoaded = ret;

            return ret;
        }

        public string GetText(int row, string column)
        {
            if (isLoaded == false)
                return string.Empty;

            if (csvData.ContainsKey(column) == false)
                return string.Empty;

            if (0 > row || row > csvData[column].Count)
                return string.Empty;

            return csvData[column][row];
        }

        public int GetRowCount()
        {
            if (isLoaded == false)
                return 0;

            if (csvData.Count == 0)
                return 0;

            return csvData.First().Value.Count;
        }

        public int GetColumnCount()
        {
            if (isLoaded == false)
                return 0;
            
            return csvData.Count;
        }

        public List<string> GetLine(int row)
        {
            if (isLoaded == false)
                return null;

            if (0 > row || row > GetRowCount())
                return null;

            List<string> ret = new List<string>();

            int cols = GetColumnCount();
            for (int i = 0; i < cols; ++i)
                ret.Add(GetText(row, columnsData[i]));

            return ret;
        }

        private string RemoveString(string str, string remove)
        {
            int rIdx = str.IndexOf(remove);
            if (rIdx > -1)
                str = str.Remove(rIdx, 1);

            return str;
        }
    }
}
