using HudLibFontGen.Templates;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace HudLibFontGen
{
    public partial class FontGenForm : Form
    {
        /// <summary>
        /// Font last selected in the font dialog
        /// </summary>
        public Font SelectedFont { get; private set; }

        /// <summary>
        /// Font styles to be generated
        /// </summary>
        public int StyleCfg { get; private set; }

        /// <summary>
        /// Font name to be used specified by the user
        /// </summary>
        public string CustomFontName { get; private set; }

        public string WorkingDir { get; private set; }

        public string ParentDir { get; private set; }

        /// <summary>
        /// Directory where BmFontGen was found
        /// </summary>
        public string BmGenDir { get; private set; }

        /// <summary>
        /// Directory where DirectXTex Texconv was found
        /// </summary>
        public string XTexDir { get; private set; }

        public FontGenForm()
        {
            InitializeComponent(); // Form init

            WorkingDir = Directory.GetCurrentDirectory();
            ParentDir = Directory.GetParent(Directory.GetParent(WorkingDir).FullName).FullName;

            BmGenDir = $"{ParentDir}\\Fonts\\BMFontGen";
            XTexDir = $"{ParentDir}\\TexturePacking\\Tools"; // requires vccredist2013_x86

            CheckDependencies();
        }

        private void FontDialogOpen_Click(object sender, EventArgs e) =>
            fontDialog.ShowDialog();

        private void FontDialog_Apply(object sender, EventArgs e)
        {
            if (fontDialog.Font != null)
            {
                SelectedFont = fontDialog.Font;
                ResetHeader();
            }
        }

        /// <summary>
        /// If bold is checked/unchecked, update the style configuration
        /// </summary>
        private void CheckBoxBold_CheckedChanged(object sender, EventArgs e) =>
            UpdateStyleCfg();

        /// <summary>
        /// Toggle custom name use
        /// </summary>
        private void CheckBoxUseName_CheckedChanged(object sender, EventArgs e) =>
            nameBox.Enabled = checkBoxUseName.Checked;

        private void modNameBox_TextChanged(object sender, EventArgs e)
        { }

        /// <summary>
        /// Updates font style to reflect configuration specified by the UI.
        /// </summary>
        private void UpdateStyleCfg()
        {
            StyleCfg = 0;

            if (checkBoxBold.Checked)
                StyleCfg += 1;
        }

        /// <summary>
        /// Start font generation
        /// </summary>
        private void Start_Click(object sender, EventArgs args)
        {
            if (Enabled) // if the menu is enabled
            {
                if (SelectedFont != null)
                {
                    if (CheckDependencies())
                    {
                        Enabled = false;
                        ResetHeader();
                        richConsoleBox.AppendRichText($"Generating Font Data...\n", FontStyle.Bold);

                        try
                        {
                            GenerateFontData();
                            richConsoleBox.AppendRichText($"\nFont Data Generation Complete.", FontStyle.Bold);
                        }
                        catch (Exception e)
                        {
                            richConsoleBox.AppendRichText($"\nFont Data Generation Failed.\n", FontStyle.Bold, Color.DarkRed);
                            richConsoleBox.AppendText($"Reason: {e.Message}\n");
                        }

                        richConsoleBox.ScrollToCaret();
                        Enabled = true;
                    }
                }
                else
                {
                    richConsoleBox.Clear();
                    richConsoleBox.AppendRichText("Error: A font must be selected before font data can be generated.", FontStyle.Bold, Color.DarkRed);
                }
            }
        }

        /// <summary>
        /// Confirms that DirectXTex and BmFontGen are present and notifies the user if they aren't.
        /// </summary>
        /// <returns></returns>
        private bool CheckDependencies()
        {
            bool xTexFound = File.Exists($"{XTexDir}\\texconv.exe"), bmGenFound = File.Exists($"{BmGenDir}\\bmfontgen.exe");
            richConsoleBox.Clear();

            if (!xTexFound)
                richConsoleBox.AppendRichText("Error: texconv.exe not found.\n", FontStyle.Bold, Color.DarkRed);

            if (!bmGenFound)
                richConsoleBox.AppendRichText("Error: bmfontgen.exe not found.\n", FontStyle.Bold, Color.DarkRed);

            return xTexFound && bmGenFound;
        }

        /// <summary>
        /// Clear console readout and write a new header displaying the current font selection
        /// </summary>
        private void ResetHeader()
        {
            richConsoleBox.Clear();
            richConsoleBox.AppendRichText("Current Selection:\n", FontStyle.Bold);
            richConsoleBox.AppendText($"Font: {SelectedFont.Name}\nSize {SelectedFont.SizeInPoints}\n\n");
        }

        private void GenerateFontData()
        {
            // If a custom name is enabled and one is set, use it in place of the font name
            if (nameBox.Enabled && nameBox.Text != null && nameBox.Text.Length > 0)
                CustomFontName = nameBox.Text.RemoveSpaces();
            else
                CustomFontName = SelectedFont.Name.RemoveSpaces();

            Directory.CreateDirectory(CustomFontName);
            List<FontData> data = GetFontStyles();
            bool success = true;

            foreach (FontData style in data)
            {
                string styleName = "";

                if (style.styleId == 0)
                    styleName = "Regular";
                else if (style.styleId == 1)
                    styleName = "Bold";
                else if (style.styleId == 2)
                    styleName = "Italic";
                else if (style.styleId == 3)
                    styleName = "Bold Italic";

                richConsoleBox.AppendText($"Generating Font Data for Style {styleName} ({style.styleId})...\n");

                if (style.BmData == null)
                    success = false;

                if (checkBoxVerboseOutput.Checked || !success)
                {
                    richConsoleBox.AppendRichText($"\n[Style: {style.styleId}] BmGen Console Output:\n", FontStyle.Bold);
                    richConsoleBox.AppendText(style.ConsoleOutput + "\n");
                }

                if (!success)
                {
                    throw new Exception("Unable to retrieve font data.");
                }

                richConsoleBox.ScrollToCaret();
            }

            string modName = modNameBox.Text;

            if (modName.Length == 0)
                modName = "ModName";

            richConsoleBox.AppendText($"Using mod name: {modName}\n");
            richConsoleBox.ScrollToCaret();

            WriteSbcData(data, $"{CustomFontName}\\Data");
            WriteCsData(data, $"{CustomFontName}\\Data\\Scripts\\{modName}\\FontData");
            MoveAtlases(data, $"{CustomFontName}\\Fonts\\{CustomFontName}");
            ConvertAtlases(data, $"{CustomFontName}\\Fonts\\{CustomFontName}");
        }

        /// <summary>
        /// Generates atlases and glyph data for each of the styles selected using the padding
        /// specified by the UI.
        /// </summary>
        private List<FontData> GetFontStyles()
        {
            List<FontData> styles = new List<FontData>();
            Vector2
                padding = GetPadding(paddingBox1X, paddingBox1Y),
                offsetB = GetPadding(paddingBox2X, paddingBox2Y);

            for (int n = 0; n < 4; n++)
            {
                if ((n & StyleCfg) == n)
                {
                    Vector2 offset = new Vector2();

                    if ((n & 1) == 1)
                        offset += offsetB;

                    styles.Add(new FontData(this, padding + offset, n));
                }
            }

            return styles;
        }

        /// <summary>
        /// Parses text from padding textboxes into Vector2's
        /// </summary>
        private Vector2 GetPadding(TextBox X, TextBox Y)
        {
            return new Vector2()
            {
                X = float.Parse(X.Text),
                Y = float.Parse(Y.Text)
            };
        }

        /// <summary>
        /// Converts parsed XML data from <see cref="FontData"/> into a CS representation using
        /// a code generation template.
        /// </summary>
        private void WriteCsData(List<FontData> styles, string localPath)
        {
            Directory.CreateDirectory($"{WorkingDir}\\{localPath}");
            CsDataTemplate csData = new CsDataTemplate(this, styles);

            using (StreamWriter writer = new StreamWriter($"{WorkingDir}\\{localPath}\\{CustomFontName}.cs"))
            {
                writer.Write(csData.TransformText());
            }
        }

        /// <summary>
        /// Generates texture resource files in XML for the generated atlases.
        /// </summary>
        private void WriteSbcData(List<FontData> styles, string localPath)
        {  
            Directory.CreateDirectory($"{WorkingDir}\\{localPath}\\FontResources");
            MatSbcTemplate sbcData = new MatSbcTemplate(this, styles);

            using (StreamWriter writer = new StreamWriter($"{WorkingDir}\\{localPath}\\FontResources\\{CustomFontName}.sbc"))
            {
                writer.Write(sbcData.TransformText());
            }
        }

        private void MoveAtlases(List<FontData> data, string localPath)
        {
            Directory.CreateDirectory($"{WorkingDir}\\{localPath}");

            foreach (FontData style in data)
            {
                foreach (BitmapData bmp in style.BmData.bitmaps)
                {
                    string destDir = $"{WorkingDir}\\{localPath}\\{CustomFontName}-{style.styleId}-{bmp.id}.png",
                        currentDir = $"{WorkingDir}\\{CustomFontName}\\{CustomFontName}-{style.styleId}-{bmp.id}.png";

                    if (File.Exists(currentDir))
                    {
                        if (File.Exists(destDir))
                            File.Delete(destDir);

                        File.Move(currentDir, destDir);
                    }
                    else
                    {
                        throw new Exception($"Couldn't find font atlas at: {destDir}.");
                    }
                }
            }
        }

        /// <summary>
        /// Converts the PNG atlases generated by BmFontGen into BC7 
        /// </summary>
        private void ConvertAtlases(List<FontData> data, string localPath)
        {
            Process xtex = new Process();
            string consoleOutput = "";
            bool success = true;

            richConsoleBox.AppendRichText($"\nStarting Texture Conversion...\n", FontStyle.Bold);

            xtex.StartInfo.CreateNoWindow = true;
            xtex.StartInfo.UseShellExecute = false;
            xtex.StartInfo.RedirectStandardOutput = true;
            xtex.StartInfo.RedirectStandardError = true;
            xtex.StartInfo.FileName = $"{XTexDir}\\texconv.exe";
            xtex.StartInfo.Arguments = $"-y -f BC7_UNORM_SRGB -srgb -pmalpha -if LINEAR -o \"{WorkingDir}\\{localPath}\" -r \"{WorkingDir}\\{localPath}\\*.png\"";
            xtex.Start();

            consoleOutput += xtex.StandardOutput.ReadToEnd() + xtex.StandardError.ReadToEnd();
            xtex.WaitForExit();

            foreach (FontData style in data)
            {
                richConsoleBox.AppendText($"Converting Atlases for Style {style.styleId}...\n");
                richConsoleBox.ScrollToCaret();

                foreach (BitmapData bmp in style.BmData.bitmaps)
                {
                    string file = $"{WorkingDir}\\{localPath}\\{CustomFontName}-{style.styleId}-{bmp.id}";

                    if (File.Exists($"{file}.DDS") && File.Exists($"{file}.png"))
                    {
                        File.Move($"{file}.DDS", $"{file}.dds");

                        if (!checkBoxKeepPng.Checked)
                            File.Delete($"{file}.png");
                    }
                    else
                    {
                        success = false;
                        break;
                    }
                }

                if (!success)
                    break;
            }

            if (checkBoxVerboseOutput.Checked || !success)
            {
                richConsoleBox.AppendRichText($"\nxTex Console Output:\n", FontStyle.Bold);
                richConsoleBox.AppendText(consoleOutput + "\n");
                richConsoleBox.ScrollToCaret();
            }

            if (!success)
                throw new Exception("Texture conversion failed.");
        }
    }

    /// <summary>
    /// Utility extensions
    /// </summary>
    public static class Extensions
    {
        public static void AppendRichText(this RichTextBox textBox, string text, FontStyle style)
        {
            FontStyle startStyle = textBox.SelectionFont.Style;

            textBox.DeselectAll();
            textBox.SelectionFont = new Font(textBox.SelectionFont, style);
            textBox.AppendText(text);
            textBox.SelectionFont = new Font(textBox.SelectionFont, startStyle);
        }

        public static void AppendRichText(this RichTextBox textBox, string text, FontStyle style, Color color)
        {
            Color startColor = textBox.SelectionColor;
            FontStyle startStyle = textBox.SelectionFont.Style;

            textBox.DeselectAll();
            textBox.SelectionColor = color;
            textBox.SelectionFont = new Font(textBox.SelectionFont, style);
            textBox.AppendText(text);

            textBox.SelectionColor = startColor;
            textBox.SelectionFont = new Font(textBox.SelectionFont, startStyle);
        }

        public static string RemoveSpaces(this string text)
        {
            StringBuilder sb = new StringBuilder(text.Length);

            for (int n = 0; n < text.Length; n++)
            {
                if (text[n] != ' ')
                    sb.Append(text[n]);
            }

            return sb.ToString();
        }

        public static string Remove(this string text, List<char> exclude)
        {
            StringBuilder sb = new StringBuilder(text.Length);

            for (int n = 0; n < text.Length; n++)
            {
                if (!exclude.Contains(text[n]))
                    sb.Append(text[n]);
            }

            return sb.ToString();
        }
    }
}
