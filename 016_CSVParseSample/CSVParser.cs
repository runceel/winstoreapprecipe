using System;
using System.Collections.Generic;
using System.Text;

namespace Softbuild.Data.Csv
{
    public class CSVParser
    {
        public static List<List<string>> Parse(string csv)
        {
            var retList = new List<List<string>>();

            var lines = csv.Split(new[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                var temp = CSVParser.ParseLine(line);
                if (temp != null)
                {
                    retList.Add(temp);
                }
            }
            return retList;
        }

        public static List<string> ParseLine(string line)
        {
            List<string> retList = null;

            var array = line.Split(',');
            if (array.Length > 0)
            {
                retList = new List<string>();
                StringBuilder temp = null;

                foreach (var str in array) {
                    if (temp == null && str.StartsWith("\"") && !str.EndsWith("\"")) 
                    {
                        // ダブルクォート開始
                        temp = new StringBuilder();
                        temp.Append(str.Substring(1, str.Length - 1).Replace("\"\"", "\""));
                        temp.Append(",");
                    }
                    else if (temp != null && !str.StartsWith("\"") && str.EndsWith("\"")) 
                    {
                        // ダブルクォート終了
                        temp.Append(str.Substring(0, str.Length - 1).Replace("\"", ""));
                        retList.Add(temp.ToString());
                        temp = null;
                    }
                    else if (temp != null)
                    {
                        // ダブルクォート中
                        temp.Append(str.Replace("\"\"", "\""));
                        temp.Append(",");
                    }
                    else if (temp == null && str.StartsWith("\"") && str.EndsWith("\""))
                    {
                        // ダブルクォート囲ってある
                        retList.Add(str.Substring(1, str.Length - 2).Replace("\"\"", "\""));
                    }
                    else
                    {
                        // そのまま
                        retList.Add(str);
                    }
                }
            }

            return retList;
        }
    }
}
