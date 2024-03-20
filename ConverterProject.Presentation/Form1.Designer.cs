namespace ConverterProject.Presentation
{
    partial class frm_xmltocsv
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txt_readpath = new TextBox();
            txt_writepath = new TextBox();
            btn_chooseReadFile = new Button();
            btn_chooseWriteFile = new Button();
            btn_convert = new Button();
            lbl_writeName = new Label();
            txt_writeName = new TextBox();
            SuspendLayout();
            // 
            // txt_readpath
            // 
            txt_readpath.Location = new Point(36, 39);
            txt_readpath.Name = "txt_readpath";
            txt_readpath.Size = new Size(431, 27);
            txt_readpath.TabIndex = 0;
            // 
            // txt_writepath
            // 
            txt_writepath.Location = new Point(36, 98);
            txt_writepath.Name = "txt_writepath";
            txt_writepath.Size = new Size(431, 27);
            txt_writepath.TabIndex = 2;
            // 
            // btn_chooseReadFile
            // 
            btn_chooseReadFile.Location = new Point(486, 33);
            btn_chooseReadFile.Name = "btn_chooseReadFile";
            btn_chooseReadFile.Size = new Size(163, 33);
            btn_chooseReadFile.TabIndex = 1;
            btn_chooseReadFile.Text = "Choose a Read Path";
            btn_chooseReadFile.UseVisualStyleBackColor = true;
            btn_chooseReadFile.Click += btn_chooseReadFile_Click;
            // 
            // btn_chooseWriteFile
            // 
            btn_chooseWriteFile.Location = new Point(486, 91);
            btn_chooseWriteFile.Name = "btn_chooseWriteFile";
            btn_chooseWriteFile.Size = new Size(163, 33);
            btn_chooseWriteFile.TabIndex = 3;
            btn_chooseWriteFile.Text = "Choose a Write Path";
            btn_chooseWriteFile.UseVisualStyleBackColor = true;
            btn_chooseWriteFile.Click += btn_chooseWriteFile_Click;
            // 
            // btn_convert
            // 
            btn_convert.BackColor = Color.FromArgb(192, 0, 0);
            btn_convert.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btn_convert.ForeColor = SystemColors.ButtonHighlight;
            btn_convert.Location = new Point(36, 184);
            btn_convert.Name = "btn_convert";
            btn_convert.Size = new Size(613, 40);
            btn_convert.TabIndex = 4;
            btn_convert.Text = "Converter";
            btn_convert.UseVisualStyleBackColor = false;
            btn_convert.Click += btn_convert_Click;
            // 
            // lbl_writeName
            // 
            lbl_writeName.AutoSize = true;
            lbl_writeName.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_writeName.Location = new Point(517, 142);
            lbl_writeName.Name = "lbl_writeName";
            lbl_writeName.Size = new Size(107, 23);
            lbl_writeName.TabIndex = 6;
            lbl_writeName.Text = "Write Name";
            lbl_writeName.TextAlign = ContentAlignment.BottomRight;
            // 
            // txt_writeName
            // 
            txt_writeName.Location = new Point(36, 141);
            txt_writeName.Name = "txt_writeName";
            txt_writeName.Size = new Size(431, 27);
            txt_writeName.TabIndex = 7;
            // 
            // frm_xmltocsv
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(683, 236);
            Controls.Add(txt_writeName);
            Controls.Add(lbl_writeName);
            Controls.Add(btn_convert);
            Controls.Add(btn_chooseWriteFile);
            Controls.Add(btn_chooseReadFile);
            Controls.Add(txt_writepath);
            Controls.Add(txt_readpath);
            Name = "frm_xmltocsv";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xml To Csv";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_readpath;
        private TextBox txt_writepath;
        private Button btn_chooseReadFile;
        private Button btn_chooseWriteFile;
        private Button btn_convert;
        private Label lbl_writeName;
        private TextBox txt_writeName;
    }
}
