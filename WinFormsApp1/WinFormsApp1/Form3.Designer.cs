namespace WinFormsApp1
{
    partial class Form3
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
            button6 = new Button();
            button4 = new Button();
            button3 = new Button();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // button6
            // 
            button6.Location = new Point(405, 375);
            button6.Name = "button6";
            button6.Size = new Size(108, 23);
            button6.TabIndex = 9;
            button6.Text = "DESENCRIPTAR";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button4
            // 
            button4.Location = new Point(160, 375);
            button4.Name = "button4";
            button4.Size = new Size(108, 23);
            button4.TabIndex = 8;
            button4.Text = "Crear RSA ";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(291, 375);
            button3.Name = "button3";
            button3.Size = new Size(108, 23);
            button3.TabIndex = 7;
            button3.Text = "ENCRIPTAR";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(-1, 0);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(800, 352);
            richTextBox1.TabIndex = 10;
            richTextBox1.Text = "";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBox1);
            Controls.Add(button6);
            Controls.Add(button4);
            Controls.Add(button3);
            Name = "Form3";
            Text = "Form3";
            Load += Form3_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button6;
        private Button button4;
        private Button button3;
        private RichTextBox richTextBox1;
    }
}