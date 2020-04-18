using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace HudLibFontGen
{
    public partial class FontData
    {
        public readonly int styleId;
        public BmGenData BmData { get; private set; }
        public string ConsoleOutput { get; private set; }

        private readonly FontGenForm form;
        private readonly Vector2 padding;
        private readonly string xmlPath;

        public FontData(FontGenForm form, Vector2 padding, int styleId)
        {
            this.form = form;
            this.padding = padding;
            this.styleId = styleId;
            xmlPath = $"{form.CustomFontName}\\{form.CustomFontName}-{styleId}.xml";

            GetFontStyle();
            BmData = GetFontData();
        }

        private void GetFontStyle()
        {
            Process bmProc = new Process();

            bmProc.StartInfo.CreateNoWindow = true;
            bmProc.StartInfo.UseShellExecute = false;
            bmProc.StartInfo.RedirectStandardOutput = true;
            bmProc.StartInfo.RedirectStandardError = true;
            bmProc.StartInfo.FileName = $"{form.BmGenDir}\\bmfontgen.exe";
            bmProc.StartInfo.Arguments = GetFontGenArgs();
            bmProc.Start();

            ConsoleOutput = bmProc.StandardOutput.ReadToEnd() + bmProc.StandardError.ReadToEnd();
            bmProc.WaitForExit();
        }

        private string GetFontGenArgs()
        {
            string args =
                $"-name \"{form.SelectedFont.Name}\" " +
                $"-size {form.SelectedFont.SizeInPoints} " +
                $"-output \"{form.CustomFontName}\\{form.CustomFontName}-{styleId}\" " +
                GetFontStyleArgs() +
                $"-gpadx {padding.X} -gpady {padding.Y} " +
                "-bmsize 1024 " +
                $"-optfile {form.WorkingDir}\\Options\\range.txt ";

            return args;
        }

        private string GetFontStyleArgs()
        {
            string args = "";

            if ((styleId & 1) == 1)
                args += "-bold ";

            if ((styleId & 2) == 2)
                args += "-italic ";

            if ((styleId & 4) == 4)
                args += "-underline ";

            if ((styleId & 8) == 8)
                args += "-strikeout ";

            return args;
        }

        private BmGenData GetFontData()
        {
            XmlSerializer dataSerializer = new XmlSerializer(typeof(BmGenData));
            BmGenData data;

            using (StringReader xml = new StringReader(GetCleanXml()))
            {
                data = (BmGenData)dataSerializer.Deserialize(xml);
            }

            File.Delete(xmlPath);
            return data;
        }

        private string GetCleanXml()
        {
            string data;

            using (StreamReader reader = new StreamReader(xmlPath))
            {
                data = reader.ReadToEnd();
            }

            if (data != null)
            {
                int start = -1, end = -1;

                for (int n = 0; n < data.Length - 6; n++)
                {
                    if (start == -1) // because namespaces are evil, I guess
                    {
                        if (data.Substring(n, 7) == "xmlns=\"")
                        {
                            start = n;
                            n += 6;
                        }
                    }
                    else if (end == -1 && data[n] == '\"')
                    {
                        end = n;
                        break;
                    }
                }

                if (start > 0)
                    data = data.Remove(start, end - start + 1);
            }

            return data;
        }
    }
}