namespace DNFtranslate
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.radioButtonLangCHT = new System.Windows.Forms.RadioButton();
            this.radioButtonLangENG = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBoxPatchJap = new System.Windows.Forms.CheckBox();
            this.buttonProcess = new System.Windows.Forms.Button();
            this.radioButtonTT = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxPatchGame = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // radioButtonLangCHT
            // 
            this.radioButtonLangCHT.AutoSize = true;
            this.radioButtonLangCHT.Location = new System.Drawing.Point(12, 12);
            this.radioButtonLangCHT.Name = "radioButtonLangCHT";
            this.radioButtonLangCHT.Size = new System.Drawing.Size(119, 24);
            this.radioButtonLangCHT.TabIndex = 0;
            this.radioButtonLangCHT.Text = "Use text\\cht";
            this.radioButtonLangCHT.UseVisualStyleBackColor = true;
            // 
            // radioButtonLangENG
            // 
            this.radioButtonLangENG.AutoSize = true;
            this.radioButtonLangENG.Checked = true;
            this.radioButtonLangENG.Location = new System.Drawing.Point(12, 42);
            this.radioButtonLangENG.Name = "radioButtonLangENG";
            this.radioButtonLangENG.Size = new System.Drawing.Size(124, 24);
            this.radioButtonLangENG.TabIndex = 1;
            this.radioButtonLangENG.TabStop = true;
            this.radioButtonLangENG.Text = "Use text\\eng";
            this.radioButtonLangENG.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(215, 32);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(573, 406);
            this.textBox1.TabIndex = 2;
            // 
            // checkBoxPatchJap
            // 
            this.checkBoxPatchJap.AutoSize = true;
            this.checkBoxPatchJap.Location = new System.Drawing.Point(12, 139);
            this.checkBoxPatchJap.Name = "checkBoxPatchJap";
            this.checkBoxPatchJap.Size = new System.Drawing.Size(131, 24);
            this.checkBoxPatchJap.TabIndex = 3;
            this.checkBoxPatchJap.Text = "Patch text\\jap";
            this.checkBoxPatchJap.UseVisualStyleBackColor = true;
            // 
            // buttonProcess
            // 
            this.buttonProcess.Location = new System.Drawing.Point(12, 199);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(188, 62);
            this.buttonProcess.TabIndex = 4;
            this.buttonProcess.Text = "Process";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
            // 
            // radioButtonTT
            // 
            this.radioButtonTT.AutoSize = true;
            this.radioButtonTT.Location = new System.Drawing.Point(12, 72);
            this.radioButtonTT.Name = "radioButtonTT";
            this.radioButtonTT.Size = new System.Drawing.Size(188, 24);
            this.radioButtonTT.TabIndex = 5;
            this.radioButtonTT.Text = "use translated.txt only";
            this.radioButtonTT.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Missing Text to Translate";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 286);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(188, 53);
            this.progressBar1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Complete";
            this.label2.Visible = false;
            // 
            // checkBoxPatchGame
            // 
            this.checkBoxPatchGame.AutoSize = true;
            this.checkBoxPatchGame.Location = new System.Drawing.Point(12, 169);
            this.checkBoxPatchGame.Name = "checkBoxPatchGame";
            this.checkBoxPatchGame.Size = new System.Drawing.Size(149, 24);
            this.checkBoxPatchGame.TabIndex = 9;
            this.checkBoxPatchGame.Text = "Patch game.exe";
            this.checkBoxPatchGame.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBoxPatchGame);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButtonTT);
            this.Controls.Add(this.buttonProcess);
            this.Controls.Add(this.checkBoxPatchJap);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.radioButtonLangENG);
            this.Controls.Add(this.radioButtonLangCHT);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "DNFtranslate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonLangCHT;
        private System.Windows.Forms.RadioButton radioButtonLangENG;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBoxPatchJap;
        private System.Windows.Forms.Button buttonProcess;
        private System.Windows.Forms.RadioButton radioButtonTT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxPatchGame;
    }
}

