using System.Windows.Forms;
using System.Xml.Linq;

namespace Projeto1_JogoVelha
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            label2 = new Label();
            labelX = new Label();
            labelO = new Label();
            label3 = new Label();
            label5 = new Label();
            button11 = new Button();
            button12 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            button1.Location = new Point(10, 99);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(105, 90);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            button2.Location = new Point(121, 99);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(105, 90);
            button2.TabIndex = 1;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            button3.Location = new Point(231, 99);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(105, 90);
            button3.TabIndex = 2;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            button4.Location = new Point(10, 194);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(105, 90);
            button4.TabIndex = 3;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button_Click;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            button5.Location = new Point(121, 194);
            button5.Margin = new Padding(3, 2, 3, 2);
            button5.Name = "button5";
            button5.Size = new Size(105, 90);
            button5.TabIndex = 4;
            button5.UseVisualStyleBackColor = true;
            button5.Click += button_Click;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            button6.Location = new Point(231, 194);
            button6.Margin = new Padding(3, 2, 3, 2);
            button6.Name = "button6";
            button6.Size = new Size(105, 90);
            button6.TabIndex = 5;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button_Click;
            // 
            // button7
            // 
            button7.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            button7.Location = new Point(10, 288);
            button7.Margin = new Padding(3, 2, 3, 2);
            button7.Name = "button7";
            button7.Size = new Size(105, 90);
            button7.TabIndex = 6;
            button7.UseVisualStyleBackColor = true;
            button7.Click += button_Click;
            // 
            // button8
            // 
            button8.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            button8.Location = new Point(121, 288);
            button8.Margin = new Padding(3, 2, 3, 2);
            button8.Name = "button8";
            button8.Size = new Size(105, 90);
            button8.TabIndex = 7;
            button8.UseVisualStyleBackColor = true;
            button8.Click += button_Click;
            // 
            // button9
            // 
            button9.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            button9.Location = new Point(231, 288);
            button9.Margin = new Padding(3, 2, 3, 2);
            button9.Name = "button9";
            button9.Size = new Size(105, 90);
            button9.TabIndex = 8;
            button9.UseVisualStyleBackColor = true;
            button9.Click += button_Click;
            // 
            // button10
            // 
            button10.BackColor = Color.MediumSlateBlue;
            button10.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            button10.Location = new Point(10, 400);
            button10.Margin = new Padding(3, 2, 3, 2);
            button10.Name = "button10";
            button10.Size = new Size(326, 56);
            button10.TabIndex = 9;
            button10.Text = "Reiniciar Jogo";
            button10.UseVisualStyleBackColor = false;
            button10.Click += button10_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label2.Location = new Point(14, 7);
            label2.Name = "label2";
            label2.Size = new Size(134, 20);
            label2.TabIndex = 11;
            label2.Text = "Jogador da vez:    ";
            // 
            // labelX
            // 
            labelX.AutoSize = true;
            labelX.Location = new Point(194, 10);
            labelX.Name = "labelX";
            labelX.Size = new Size(34, 15);
            labelX.TabIndex = 12;
            labelX.Text = "X = 0";
            // 
            // labelO
            // 
            labelO.AutoSize = true;
            labelO.Location = new Point(269, 10);
            labelO.Name = "labelO";
            labelO.Size = new Size(36, 15);
            labelO.TabIndex = 13;
            labelO.Text = "O = 0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(14, 34);
            label3.Name = "label3";
            label3.Size = new Size(284, 15);
            label3.TabIndex = 14;
            label3.Text = "Use o mouse ou o teclado numérico para selecionar\r\n";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 64);
            label5.Name = "label5";
            label5.Size = new Size(144, 15);
            label5.TabIndex = 16;
            label5.Text = "Escolha o tipo de jogador:";
            // 
            // button11
            // 
            button11.BackColor = Color.DodgerBlue;
            button11.Location = new Point(177, 60);
            button11.Margin = new Padding(3, 2, 3, 2);
            button11.Name = "button11";
            button11.Size = new Size(71, 24);
            button11.TabIndex = 17;
            button11.Text = "Humano";
            button11.UseVisualStyleBackColor = false;
            button11.Click += button11_Click;
            // 
            // button12
            // 
            button12.Location = new Point(249, 61);
            button12.Margin = new Padding(3, 2, 3, 2);
            button12.Name = "button12";
            button12.Size = new Size(89, 24);
            button12.TabIndex = 18;
            button12.Text = "Computador";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(345, 467);
            Controls.Add(button12);
            Controls.Add(button11);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(labelO);
            Controls.Add(labelX);
            Controls.Add(label2);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "POE - Jogo da Velha";
            KeyDown += Form1_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Label label2;
        private Label labelX;
        private Label labelO;
        private Label label3;
        private Label label5;
        private Button button11;
        private Button button12;
    }
}
