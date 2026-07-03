namespace OPTestTool
{
    partial class WriteIntForm
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
            radioButton3 = new RadioButton();
            radioButton1 = new RadioButton();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            Txt_Number = new TextBox();
            radioButton2 = new RadioButton();
            radioButton4 = new RadioButton();
            radioButton6 = new RadioButton();
            radioButton7 = new RadioButton();
            radioButton8 = new RadioButton();
            SuspendLayout();
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(106, 26);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(88, 21);
            radioButton3.TabIndex = 1;
            radioButton3.Tag = "+16";
            radioButton3.Text = "16位有符号";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(12, 26);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(88, 21);
            radioButton1.TabIndex = 0;
            radioButton1.Tag = "+32";
            radioButton1.Text = "32位有符号";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(81, 135);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 9;
            button1.Text = "确定";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(172, 135);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 10;
            button2.Text = "取消";
            button2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Cursor = Cursors.SizeWE;
            label2.Location = new Point(70, 98);
            label2.Name = "label2";
            label2.Size = new Size(59, 17);
            label2.TabIndex = 7;
            label2.Tag = "Txt_Number";
            label2.Text = "写入的值:";
            label2.MouseDown += LabelInt_MouseDown;
            label2.MouseMove += LabelInt_MouseMove;
            label2.MouseUp += LabelInt_MouseUp;
            // 
            // Txt_Number
            // 
            Txt_Number.Location = new Point(135, 95);
            Txt_Number.Name = "Txt_Number";
            Txt_Number.Size = new Size(129, 23);
            Txt_Number.TabIndex = 8;
            Txt_Number.Text = "0";
            Txt_Number.TextChanged += TextBoxInt_TextChanged;
            Txt_Number.KeyPress += TextBoxInt_KeyPress;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(200, 26);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(81, 21);
            radioButton2.TabIndex = 2;
            radioButton2.Tag = "+8";
            radioButton2.Text = "8位有符号";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(289, 26);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(52, 21);
            radioButton4.TabIndex = 3;
            radioButton4.Tag = "+64";
            radioButton4.Text = "64位";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            radioButton6.AutoSize = true;
            radioButton6.Location = new Point(200, 53);
            radioButton6.Name = "radioButton6";
            radioButton6.Size = new Size(81, 21);
            radioButton6.TabIndex = 6;
            radioButton6.Tag = "-8";
            radioButton6.Text = "8位无符号";
            radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            radioButton7.AutoSize = true;
            radioButton7.Location = new Point(106, 53);
            radioButton7.Name = "radioButton7";
            radioButton7.Size = new Size(88, 21);
            radioButton7.TabIndex = 5;
            radioButton7.Tag = "-16";
            radioButton7.Text = "16位无符号";
            radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            radioButton8.AutoSize = true;
            radioButton8.Location = new Point(12, 53);
            radioButton8.Name = "radioButton8";
            radioButton8.Size = new Size(88, 21);
            radioButton8.TabIndex = 4;
            radioButton8.Tag = "-32";
            radioButton8.Text = "32位无符号";
            radioButton8.UseVisualStyleBackColor = true;
            // 
            // WriteIntForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(353, 170);
            Controls.Add(radioButton6);
            Controls.Add(radioButton7);
            Controls.Add(radioButton8);
            Controls.Add(radioButton4);
            Controls.Add(radioButton2);
            Controls.Add(Txt_Number);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(radioButton3);
            Controls.Add(radioButton1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "WriteIntForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "请选择";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private RadioButton radioButton3;
        private RadioButton radioButton1;
        private Button button1;
        private Button button2;
        private Label label2;
        private TextBox Txt_Number;
        private RadioButton radioButton2;
        private RadioButton radioButton4;
        private RadioButton radioButton6;
        private RadioButton radioButton7;
        private RadioButton radioButton8;
    }
}