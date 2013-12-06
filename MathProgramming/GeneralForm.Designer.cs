namespace MathProgramming
{
    partial class GeneralForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBoxInput = new System.Windows.Forms.RichTextBox();
            this.contextMenuStripInput = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавлятьПробелыПослеЦифрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            this.textBoxK = new System.Windows.Forms.TextBox();
            this.textBoxS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonClearInput = new System.Windows.Forms.Button();
            this.buttonClearOutput = new System.Windows.Forms.Button();
            this.buttonClearAll = new System.Windows.Forms.Button();
            this.buttonLog = new System.Windows.Forms.Button();
            this.buttonResult = new System.Windows.Forms.Button();
            this.comboBoxLab = new System.Windows.Forms.ComboBox();
            this.contextMenuStripInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(438, 284);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "Вычислить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBoxInput
            // 
            this.richTextBoxInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxInput.ContextMenuStrip = this.contextMenuStripInput;
            this.richTextBoxInput.Location = new System.Drawing.Point(0, 33);
            this.richTextBoxInput.Name = "richTextBoxInput";
            this.richTextBoxInput.Size = new System.Drawing.Size(266, 247);
            this.richTextBoxInput.TabIndex = 0;
            this.richTextBoxInput.Text = "";
            this.toolTip1.SetToolTip(this.richTextBoxInput, "Введите сюда исходную матрицу. \r\nЭлементы разделяйте пробелом. \r\nРазделителем дро" +
                    "бной и целой части является запятая.\r\n");
            this.richTextBoxInput.TextChanged += new System.EventHandler(this.richTextBoxInput_TextChanged);
            this.richTextBoxInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBoxInput_KeyPress);
            this.richTextBoxInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTextBoxInput_KeyUp);
            // 
            // contextMenuStripInput
            // 
            this.contextMenuStripInput.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавлятьПробелыПослеЦифрToolStripMenuItem});
            this.contextMenuStripInput.Name = "contextMenuStripInput";
            this.contextMenuStripInput.Size = new System.Drawing.Size(255, 26);
            // 
            // добавлятьПробелыПослеЦифрToolStripMenuItem
            // 
            this.добавлятьПробелыПослеЦифрToolStripMenuItem.Checked = true;
            this.добавлятьПробелыПослеЦифрToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.добавлятьПробелыПослеЦифрToolStripMenuItem.Name = "добавлятьПробелыПослеЦифрToolStripMenuItem";
            this.добавлятьПробелыПослеЦифрToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.добавлятьПробелыПослеЦифрToolStripMenuItem.Text = "Добавлять пробелы после цифр";
            this.добавлятьПробелыПослеЦифрToolStripMenuItem.ToolTipText = "Только для однозначно-элементных матриц";
            this.добавлятьПробелыПослеЦифрToolStripMenuItem.Click += new System.EventHandler(this.добавлятьПробелыПослеЦифрToolStripMenuItem_Click);
            // 
            // richTextBoxOutput
            // 
            this.richTextBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxOutput.Location = new System.Drawing.Point(272, 33);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.Size = new System.Drawing.Size(257, 247);
            this.richTextBoxOutput.TabIndex = 7;
            this.richTextBoxOutput.Text = "";
            this.toolTip1.SetToolTip(this.richTextBoxOutput, "Здесь Вы увидете результат.");
            // 
            // textBoxK
            // 
            this.textBoxK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxK.Location = new System.Drawing.Point(358, 2);
            this.textBoxK.Name = "textBoxK";
            this.textBoxK.Size = new System.Drawing.Size(24, 29);
            this.textBoxK.TabIndex = 1;
            this.toolTip1.SetToolTip(this.textBoxK, "Отсчет строк ведется с нуля!");
            this.textBoxK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxS_KeyPress);
            // 
            // textBoxS
            // 
            this.textBoxS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxS.Location = new System.Drawing.Point(428, 2);
            this.textBoxS.Name = "textBoxS";
            this.textBoxS.Size = new System.Drawing.Size(24, 29);
            this.textBoxS.TabIndex = 2;
            this.toolTip1.SetToolTip(this.textBoxS, "Отсчет столбцов ведется с нуля!");
            this.textBoxS.TextChanged += new System.EventHandler(this.textBoxS_TextChanged);
            this.textBoxS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxS_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(317, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "k = ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(389, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "s = ";
            // 
            // buttonClearInput
            // 
            this.buttonClearInput.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonClearInput.Location = new System.Drawing.Point(186, 284);
            this.buttonClearInput.Name = "buttonClearInput";
            this.buttonClearInput.Size = new System.Drawing.Size(88, 29);
            this.buttonClearInput.TabIndex = 5;
            this.buttonClearInput.Text = "Очистить";
            this.buttonClearInput.UseVisualStyleBackColor = true;
            this.buttonClearInput.Click += new System.EventHandler(this.buttonCleatOutput_Click);
            // 
            // buttonClearOutput
            // 
            this.buttonClearOutput.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonClearOutput.Location = new System.Drawing.Point(280, 284);
            this.buttonClearOutput.Name = "buttonClearOutput";
            this.buttonClearOutput.Size = new System.Drawing.Size(88, 29);
            this.buttonClearOutput.TabIndex = 6;
            this.buttonClearOutput.Text = "Очистить";
            this.buttonClearOutput.UseVisualStyleBackColor = true;
            this.buttonClearOutput.Click += new System.EventHandler(this.buttonCleatOutput_Click);
            // 
            // buttonClearAll
            // 
            this.buttonClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClearAll.Location = new System.Drawing.Point(2, 284);
            this.buttonClearAll.Name = "buttonClearAll";
            this.buttonClearAll.Size = new System.Drawing.Size(109, 29);
            this.buttonClearAll.TabIndex = 4;
            this.buttonClearAll.Text = "Очистить все";
            this.buttonClearAll.UseVisualStyleBackColor = true;
            this.buttonClearAll.Click += new System.EventHandler(this.buttonClearAll_Click);
            // 
            // buttonLog
            // 
            this.buttonLog.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonLog.Location = new System.Drawing.Point(243, 0);
            this.buttonLog.Name = "buttonLog";
            this.buttonLog.Size = new System.Drawing.Size(68, 29);
            this.buttonLog.TabIndex = 8;
            this.buttonLog.Text = "Лог";
            this.buttonLog.UseVisualStyleBackColor = true;
            this.buttonLog.Click += new System.EventHandler(this.buttonLog_Click);
            // 
            // buttonResult
            // 
            this.buttonResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonResult.Location = new System.Drawing.Point(458, 1);
            this.buttonResult.Name = "buttonResult";
            this.buttonResult.Size = new System.Drawing.Size(88, 29);
            this.buttonResult.TabIndex = 10;
            this.buttonResult.Text = "Ответ";
            this.buttonResult.UseVisualStyleBackColor = true;
            this.buttonResult.Click += new System.EventHandler(this.buttonResult_Click);
            // 
            // comboBoxLab
            // 
            this.comboBoxLab.FormattingEnabled = true;
            this.comboBoxLab.Location = new System.Drawing.Point(2, 1);
            this.comboBoxLab.Name = "comboBoxLab";
            this.comboBoxLab.Size = new System.Drawing.Size(235, 29);
            this.comboBoxLab.TabIndex = 11;
            this.comboBoxLab.SelectedIndexChanged += new System.EventHandler(this.comboBoxLab_SelectedIndexChanged);
            // 
            // GeneralForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 317);
            this.Controls.Add(this.buttonLog);
            this.Controls.Add(this.buttonResult);
            this.Controls.Add(this.buttonClearAll);
            this.Controls.Add(this.comboBoxLab);
            this.Controls.Add(this.buttonClearOutput);
            this.Controls.Add(this.buttonClearInput);
            this.Controls.Add(this.richTextBoxInput);
            this.Controls.Add(this.richTextBoxOutput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxS);
            this.Controls.Add(this.textBoxK);
            this.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(548, 262);
            this.Name = "GeneralForm";
            this.ShowIcon = false;
            this.Text = "Математическое программирование 1.3";
            this.Load += new System.EventHandler(this.GeneralForm_Load);
            this.Resize += new System.EventHandler(this.GeneralForm_Resize);
            this.contextMenuStripInput.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBoxInput;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.RichTextBox richTextBoxOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxK;
        private System.Windows.Forms.TextBox textBoxS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonClearInput;
        private System.Windows.Forms.Button buttonClearOutput;
        private System.Windows.Forms.Button buttonClearAll;
        private System.Windows.Forms.Button buttonLog;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripInput;
        private System.Windows.Forms.ToolStripMenuItem добавлятьПробелыПослеЦифрToolStripMenuItem;
        private System.Windows.Forms.Button buttonResult;
        private System.Windows.Forms.ComboBox comboBoxLab;
    }
}

