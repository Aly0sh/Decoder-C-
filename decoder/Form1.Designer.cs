namespace decoder
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.inputText = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.keys = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ress = new System.Windows.Forms.RichTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.keyTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inputText);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(816, 207);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter the text";
            // 
            // inputText
            // 
            this.inputText.Location = new System.Drawing.Point(6, 26);
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(804, 175);
            this.inputText.TabIndex = 0;
            this.inputText.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.keys);
            this.groupBox2.Location = new System.Drawing.Point(12, 225);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(816, 84);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Key";
            // 
            // keys
            // 
            this.keys.Location = new System.Drawing.Point(6, 26);
            this.keys.Name = "keys";
            this.keys.Size = new System.Drawing.Size(804, 52);
            this.keys.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 321);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "Decrypt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(219, 321);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(201, 33);
            this.button2.TabIndex = 3;
            this.button2.Text = "Auto solve";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ress);
            this.groupBox3.Location = new System.Drawing.Point(12, 360);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(816, 277);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Result";
            // 
            // ress
            // 
            this.ress.Location = new System.Drawing.Point(6, 26);
            this.ress.Name = "ress";
            this.ress.Size = new System.Drawing.Size(804, 245);
            this.ress.TabIndex = 9;
            this.ress.Text = "";
            this.ress.TextChanged += new System.EventHandler(this.ress_TextChanged);
            this.ress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ress_KeyDown);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(621, 321);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(201, 33);
            this.button3.TabIndex = 7;
            this.button3.Text = "Decrypt by key";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // keyTextBox
            // 
            this.keyTextBox.Location = new System.Drawing.Point(480, 321);
            this.keyTextBox.Multiline = true;
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.PlaceholderText = "Enter the key";
            this.keyTextBox.Size = new System.Drawing.Size(135, 33);
            this.keyTextBox.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 648);
            this.Controls.Add(this.keyTextBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Decoder";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private RichTextBox inputText;
        private GroupBox groupBox2;
        private FlowLayoutPanel keys;
        private Button button1;
        private Button button2;
        private GroupBox groupBox3;
        private Button button3;
        private TextBox keyTextBox;
        private RichTextBox ress;
    }
}