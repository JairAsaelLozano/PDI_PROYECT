namespace PDI_PROYECTO
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
            label1 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            label2 = new Label();
            pictureBox2 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            Fotoradio = new RadioButton();
            radioButton2 = new RadioButton();
            pictureBox3 = new PictureBox();
            openFileDialog1 = new OpenFileDialog();
            imagenradio = new RadioButton();
            Histograma = new PictureBox();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Histograma).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Script", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(78, 67);
            label1.Name = "label1";
            label1.Size = new Size(115, 34);
            label1.TabIndex = 0;
            label1.Text = "Cámara: ";
            label1.Click += label1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FlatStyle = FlatStyle.System;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(78, 104);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 28);
            comboBox1.TabIndex = 1;
            // 
            // comboBox2
            // 
            comboBox2.FlatStyle = FlatStyle.System;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(78, 209);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 28);
            comboBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe Script", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label2.Location = new Point(78, 172);
            label2.Name = "label2";
            label2.Size = new Size(91, 34);
            label2.TabIndex = 2;
            label2.Text = "Filtro: ";
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(549, 26);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(236, 211);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.OldLace;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe Script", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ControlText;
            button1.Location = new Point(323, 243);
            button1.Name = "button1";
            button1.Size = new Size(135, 40);
            button1.TabIndex = 6;
            button1.Text = "Capturar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.BackColor = Color.OldLace;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Segoe Script", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.ControlText;
            button2.Location = new Point(594, 243);
            button2.Name = "button2";
            button2.Size = new Size(135, 40);
            button2.TabIndex = 7;
            button2.Text = "Guardar";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // Fotoradio
            // 
            Fotoradio.AutoSize = true;
            Fotoradio.Location = new Point(78, 282);
            Fotoradio.Name = "Fotoradio";
            Fotoradio.Size = new Size(91, 24);
            Fotoradio.TabIndex = 8;
            Fotoradio.TabStop = true;
            Fotoradio.Text = "Fotografía";
            Fotoradio.UseVisualStyleBackColor = true;
            Fotoradio.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(78, 312);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(63, 24);
            radioButton2.TabIndex = 9;
            radioButton2.TabStop = true;
            radioButton2.Text = "Video";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(281, 26);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(236, 211);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 10;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk_1;
            // 
            // imagenradio
            // 
            imagenradio.AutoSize = true;
            imagenradio.Location = new Point(80, 342);
            imagenradio.Name = "imagenradio";
            imagenradio.Size = new Size(72, 24);
            imagenradio.TabIndex = 12;
            imagenradio.TabStop = true;
            imagenradio.Text = "Imagen";
            imagenradio.UseVisualStyleBackColor = true;
            imagenradio.CheckedChanged += radioButton1_CheckedChanged_1;
            // 
            // Histograma
            // 
            Histograma.Location = new Point(281, 289);
            Histograma.Name = "Histograma";
            Histograma.Size = new Size(222, 54);
            Histograma.TabIndex = 13;
            Histograma.TabStop = false;
            // 
            // button4
            // 
            button4.BackColor = Color.OldLace;
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Segoe Script", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            button4.ForeColor = SystemColors.ControlText;
            button4.Location = new Point(281, 359);
            button4.Name = "button4";
            button4.Size = new Size(222, 40);
            button4.TabIndex = 14;
            button4.Text = "Histograma";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(809, 421);
            Controls.Add(button4);
            Controls.Add(Histograma);
            Controls.Add(imagenradio);
            Controls.Add(pictureBox3);
            Controls.Add(radioButton2);
            Controls.Add(Fotoradio);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox2);
            Controls.Add(comboBox2);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Font = new Font("Segoe Script", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "FilterApp";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)Histograma).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label2;
        private PictureBox pictureBox2;
        private Button button1;
        private Button button2;
        private RadioButton Fotoradio;
        private RadioButton radioButton2;
        private PictureBox pictureBox3;
        private OpenFileDialog openFileDialog1;
        private RadioButton imagenradio;
        private PictureBox Histograma;
        private Button button4;
    }
}