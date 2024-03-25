namespace WinFormsApp1
{
    partial class Form5
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
            button2 = new Button();
            button1 = new Button();
            richTextBox1 = new RichTextBox();
            textBox3 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(-2, 424);
            button2.Name = "button2";
            button2.Size = new Size(152, 23);
            button2.TabIndex = 9;
            button2.Text = "<-";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(647, 377);
            button1.Name = "button1";
            button1.Size = new Size(152, 23);
            button1.TabIndex = 10;
            button1.Text = "Encriptar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(-2, 0);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(801, 169);
            richTextBox1.TabIndex = 11;
            richTextBox1.Text = "";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(-2, 331);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(801, 23);
            textBox3.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(-2, 313);
            label3.Name = "label3";
            label3.Size = new Size(123, 15);
            label3.TabIndex = 16;
            label3.Text = "Etiqueta de Validacion";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(-2, 272);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(801, 23);
            textBox2.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(-2, 254);
            label2.Name = "label2";
            label2.Size = new Size(127, 15);
            label2.TabIndex = 14;
            label2.Text = "Vector de Inicializacion";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(-2, 193);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 13;
            label1.Text = "Llave Simetrica";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(-2, 211);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(801, 23);
            textBox1.TabIndex = 12;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(richTextBox1);
            Controls.Add(button1);
            Controls.Add(button2);
            Name = "Form5";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ENCRYPT";
            Load += Form5_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Button button1;
        private RichTextBox richTextBox1;
        private TextBox textBox3;
        private Label label3;
        private TextBox textBox2;
        private Label label2;
        private Label label1;
        private TextBox textBox1;
    }
}