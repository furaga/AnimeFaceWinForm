using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimeFaceWinForm
{
    class AnimeFaceRecognizer
    {
        // Pythonスクリプトの実行
        public static string RunCPython(string rootDir, string arguments, out bool result)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo psInfo = new System.Diagnostics.ProcessStartInfo();

                psInfo.FileName = "python.exe"; // 実行するファイル
                psInfo.Arguments = arguments;
                psInfo.CreateNoWindow = true; // コンソール・ウィンドウを開かない
                psInfo.UseShellExecute = false; // シェル機能を使用しない
                psInfo.RedirectStandardOutput = true; // 標準出力をリダイレクト
                psInfo.WorkingDirectory = System.IO.Path.GetFullPath(rootDir);
                System.Diagnostics.Process p = System.Diagnostics.Process.Start(psInfo); // アプリの実行開始
                string output = p.StandardOutput.ReadToEnd(); // 標準出力の読み取り

                result = true;
                return output;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString() + "\n" + ex.StackTrace);
                result = false;
                return "";
            }
        }

        // pythonからの出力をパースして、顔領域を抽出
        public static List<RectangleF> ParseFaces(string output)
        {
            var faces = new List<RectangleF>();

            foreach (var _line in output.Split('\n'))
            {
                var line = _line.Trim().Trim('(', ')').Trim();
                var tkns = line.Split(',')
                    .Where(tkn => false == string.IsNullOrWhiteSpace(tkn))
                    .Select(tkn => tkn.Trim())
                    .ToArray();

                if (tkns.Length != 4)
                {
                    continue;
                }

                float x, y, w, h;
                if (float.TryParse(tkns[0], out x) &&
                    float.TryParse(tkns[1], out y) &&
                    float.TryParse(tkns[2], out w) &&
                    float.TryParse(tkns[3], out h))
                {
                    faces.Add(new RectangleF(x, y, w, h));
                }
            }

            return faces;
        }

    }
}
