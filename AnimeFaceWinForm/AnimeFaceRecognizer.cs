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

        
        private static bool FaceRecognizeAndSaveResultsCommon(string saveDir, string filePahtPrefix, List<Tuple<string, RectangleF>> facesInfo)
        {
            // python実行
            bool result;
            string output = AnimeFaceRecognizer.RunCPython("../python", "detect.py input.png", out result);

            if (false == result)
            {
                return false;
            }

            // 結果をパースして、得られた顔領域で画像をトリミングして保存
            var faces = AnimeFaceRecognizer.ParseFaces(output);

            int faceCnt = 0;
            foreach (var face in faces)
            {
                string savePath = System.IO.Path.Combine(saveDir, filePahtPrefix + (faceCnt++) + ".png");
                facesInfo.Add(new Tuple<string,RectangleF>(savePath, face));
            }

            return true;
        }

        public static bool FaceRecognizeAndSaveResults(Bitmap input, string saveDir, string filePahtPrefix)
        {
            input.Save(System.IO.Path.GetFullPath("../python/input.png"));

            List<Tuple<string, RectangleF>> facesInfo = new List<Tuple<string, RectangleF>>();
            if (false == FaceRecognizeAndSaveResultsCommon(saveDir, filePahtPrefix, facesInfo))
            {
                return false;
            }

            foreach (var info in facesInfo)
            {
                string savePath = info.Item1;
                RectangleF face = info.Item2;
                using (var faceImage = input.Clone(face, input.PixelFormat))
                {
                    faceImage.Save(savePath);
                }
            }

            return true;
        }


        public static bool FaceRecognizeAndSaveResults(OpenCvSharp.IplImage input, string saveDir, string filePahtPrefix)
        {
            input.SaveImage(System.IO.Path.GetFullPath("../python/input.png"));

            List<Tuple<string, RectangleF>> facesInfo = new List<Tuple<string, RectangleF>>();
            if (false == FaceRecognizeAndSaveResultsCommon(saveDir, filePahtPrefix, facesInfo))
            {
                return false;
            }

            foreach (var info in facesInfo)
            {
                string savePath = info.Item1;
                RectangleF face = info.Item2;
                using (var faceImage = input.Clone(new OpenCvSharp.CvRect((int)face.X, (int)face.Y, (int)face.Width, (int)face.Height)))
                {
                    faceImage.SaveImage(savePath);
                }
            }

            return true;
        }
    }
}
