namespace HudLibFontGen
{
    partial class FontGenForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.richConsoleBox = new System.Windows.Forms.RichTextBox();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.paddingBox1X = new System.Windows.Forms.TextBox();
            this.paddingBox1Y = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxBold = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxVerboseOutput = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.paddingBox2X = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.paddingBox2Y = new System.Windows.Forms.TextBox();
            this.checkBoxUseName = new System.Windows.Forms.CheckBox();
            this.checkBoxKeepPng = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.modNameBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(604, 419);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(249, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "Select Font";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.FontDialogOpen_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(604, 455);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(249, 29);
            this.button2.TabIndex = 1;
            this.button2.Text = "Generate Font Data";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Start_Click);
            // 
            // richConsoleBox
            // 
            this.richConsoleBox.Location = new System.Drawing.Point(15, 15);
            this.richConsoleBox.Margin = new System.Windows.Forms.Padding(4);
            this.richConsoleBox.Name = "richConsoleBox";
            this.richConsoleBox.ReadOnly = true;
            this.richConsoleBox.Size = new System.Drawing.Size(573, 468);
            this.richConsoleBox.TabIndex = 3;
            this.richConsoleBox.Text = "";
            // 
            // fontDialog
            // 
            this.fontDialog.FontMustExist = true;
            this.fontDialog.ShowApply = true;
            this.fontDialog.ShowEffects = false;
            this.fontDialog.Apply += new System.EventHandler(this.FontDialog_Apply);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Base: ";
            // 
            // paddingBox1X
            // 
            this.paddingBox1X.CausesValidation = false;
            this.paddingBox1X.Location = new System.Drawing.Point(130, 24);
            this.paddingBox1X.Margin = new System.Windows.Forms.Padding(4);
            this.paddingBox1X.Name = "paddingBox1X";
            this.paddingBox1X.Size = new System.Drawing.Size(40, 22);
            this.paddingBox1X.TabIndex = 4;
            this.paddingBox1X.Text = "7";
            // 
            // paddingBox1Y
            // 
            this.paddingBox1Y.Location = new System.Drawing.Point(208, 24);
            this.paddingBox1Y.Margin = new System.Windows.Forms.Padding(4);
            this.paddingBox1Y.Name = "paddingBox1Y";
            this.paddingBox1Y.Size = new System.Drawing.Size(40, 22);
            this.paddingBox1Y.TabIndex = 6;
            this.paddingBox1Y.Text = "4";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Y:";
            // 
            // checkBoxBold
            // 
            this.checkBoxBold.AutoSize = true;
            this.checkBoxBold.Location = new System.Drawing.Point(8, 12);
            this.checkBoxBold.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxBold.Name = "checkBoxBold";
            this.checkBoxBold.Size = new System.Drawing.Size(58, 21);
            this.checkBoxBold.TabIndex = 8;
            this.checkBoxBold.Text = "Bold";
            this.checkBoxBold.UseVisualStyleBackColor = true;
            this.checkBoxBold.CheckedChanged += new System.EventHandler(this.CheckBoxBold_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxBold);
            this.groupBox1.Location = new System.Drawing.Point(596, 31);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(256, 41);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(662, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Optional Text Style(s)";
            // 
            // checkBoxVerboseOutput
            // 
            this.checkBoxVerboseOutput.AutoSize = true;
            this.checkBoxVerboseOutput.Location = new System.Drawing.Point(604, 296);
            this.checkBoxVerboseOutput.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxVerboseOutput.Name = "checkBoxVerboseOutput";
            this.checkBoxVerboseOutput.Size = new System.Drawing.Size(185, 21);
            this.checkBoxVerboseOutput.TabIndex = 15;
            this.checkBoxVerboseOutput.Text = "Verbose Console Output";
            this.checkBoxVerboseOutput.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(698, 79);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Padding";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.paddingBox2X);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.paddingBox2Y);
            this.groupBox2.Controls.Add(this.paddingBox1X);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.paddingBox1Y);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(596, 96);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(256, 93);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(101, 28);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 17);
            this.label12.TabIndex = 18;
            this.label12.Text = "X:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(101, 61);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 17);
            this.label11.TabIndex = 17;
            this.label11.Text = "X:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(179, 61);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Y:";
            // 
            // paddingBox2X
            // 
            this.paddingBox2X.Location = new System.Drawing.Point(130, 58);
            this.paddingBox2X.Margin = new System.Windows.Forms.Padding(4);
            this.paddingBox2X.Name = "paddingBox2X";
            this.paddingBox2X.Size = new System.Drawing.Size(40, 22);
            this.paddingBox2X.TabIndex = 8;
            this.paddingBox2X.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 61);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Bold Offset:";
            // 
            // paddingBox2Y
            // 
            this.paddingBox2Y.Location = new System.Drawing.Point(208, 58);
            this.paddingBox2Y.Margin = new System.Windows.Forms.Padding(4);
            this.paddingBox2Y.Name = "paddingBox2Y";
            this.paddingBox2Y.Size = new System.Drawing.Size(40, 22);
            this.paddingBox2Y.TabIndex = 10;
            this.paddingBox2Y.Text = "0";
            // 
            // checkBoxUseName
            // 
            this.checkBoxUseName.AutoSize = true;
            this.checkBoxUseName.Location = new System.Drawing.Point(604, 325);
            this.checkBoxUseName.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxUseName.Name = "checkBoxUseName";
            this.checkBoxUseName.Size = new System.Drawing.Size(147, 21);
            this.checkBoxUseName.TabIndex = 19;
            this.checkBoxUseName.Text = "Use Custom Name";
            this.checkBoxUseName.UseVisualStyleBackColor = true;
            this.checkBoxUseName.CheckedChanged += new System.EventHandler(this.CheckBoxUseName_CheckedChanged);
            // 
            // checkBoxKeepPng
            // 
            this.checkBoxKeepPng.AutoSize = true;
            this.checkBoxKeepPng.Location = new System.Drawing.Point(604, 267);
            this.checkBoxKeepPng.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxKeepPng.Name = "checkBoxKeepPng";
            this.checkBoxKeepPng.Size = new System.Drawing.Size(104, 21);
            this.checkBoxKeepPng.TabIndex = 20;
            this.checkBoxKeepPng.Text = "Keep PNGs";
            this.checkBoxKeepPng.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(601, 390);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 17);
            this.label13.TabIndex = 21;
            this.label13.Text = "Name:";
            // 
            // nameBox
            // 
            this.nameBox.Enabled = false;
            this.nameBox.Location = new System.Drawing.Point(682, 386);
            this.nameBox.Margin = new System.Windows.Forms.Padding(4);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(162, 22);
            this.nameBox.TabIndex = 22;
            // 
            // modNameBox
            // 
            this.modNameBox.Location = new System.Drawing.Point(682, 356);
            this.modNameBox.Margin = new System.Windows.Forms.Padding(4);
            this.modNameBox.Name = "modNameBox";
            this.modNameBox.Size = new System.Drawing.Size(162, 22);
            this.modNameBox.TabIndex = 24;
            this.modNameBox.Text = "ModName";
            this.modNameBox.TextChanged += new System.EventHandler(this.modNameBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(601, 360);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 23;
            this.label4.Text = "Mod Name:";
            // 
            // FontGenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(868, 494);
            this.Controls.Add(this.modNameBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.checkBoxKeepPng);
            this.Controls.Add(this.checkBoxUseName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.checkBoxVerboseOutput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richConsoleBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FontGenForm";
            this.Text = "Rich Hud Font Generator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox richConsoleBox;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox paddingBox1X;
        private System.Windows.Forms.TextBox paddingBox1Y;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxBold;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxVerboseOutput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox paddingBox2X;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox paddingBox2Y;
        private System.Windows.Forms.CheckBox checkBoxUseName;
        private System.Windows.Forms.CheckBox checkBoxKeepPng;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox modNameBox;
        private System.Windows.Forms.Label label4;
    }
}

