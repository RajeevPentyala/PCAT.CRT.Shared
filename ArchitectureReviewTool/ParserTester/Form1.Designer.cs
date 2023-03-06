
namespace ParserTester
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
            this.text_StartCode = new System.Windows.Forms.TextBox();
            this.text_Resultat = new System.Windows.Forms.TextBox();
            this.btn_testMasse = new System.Windows.Forms.Button();
            this.TxtPathMsapp = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.MsappDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.text_Propriete = new System.Windows.Forms.TextBox();
            this.text_Controle = new System.Windows.Forms.TextBox();
            this.btn_TestUnit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.text_Ecran = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.check_Nested = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // text_StartCode
            // 
            this.text_StartCode.Location = new System.Drawing.Point(47, 75);
            this.text_StartCode.Multiline = true;
            this.text_StartCode.Name = "text_StartCode";
            this.text_StartCode.Size = new System.Drawing.Size(982, 237);
            this.text_StartCode.TabIndex = 0;
            // 
            // text_Resultat
            // 
            this.text_Resultat.Location = new System.Drawing.Point(1047, 77);
            this.text_Resultat.Multiline = true;
            this.text_Resultat.Name = "text_Resultat";
            this.text_Resultat.Size = new System.Drawing.Size(1110, 616);
            this.text_Resultat.TabIndex = 1;
            // 
            // btn_testMasse
            // 
            this.btn_testMasse.Location = new System.Drawing.Point(509, 629);
            this.btn_testMasse.Name = "btn_testMasse";
            this.btn_testMasse.Size = new System.Drawing.Size(507, 64);
            this.btn_testMasse.TabIndex = 2;
            this.btn_testMasse.Text = "Test En Masse";
            this.btn_testMasse.UseVisualStyleBackColor = true;
            this.btn_testMasse.Click += new System.EventHandler(this.button1_Click);
            // 
            // TxtPathMsapp
            // 
            this.TxtPathMsapp.Location = new System.Drawing.Point(34, 586);
            this.TxtPathMsapp.Name = "TxtPathMsapp";
            this.TxtPathMsapp.Size = new System.Drawing.Size(820, 38);
            this.TxtPathMsapp.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(872, 585);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 38);
            this.button2.TabIndex = 4;
            this.button2.Text = "Browse ...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // text_Propriete
            // 
            this.text_Propriete.Location = new System.Drawing.Point(382, 431);
            this.text_Propriete.Name = "text_Propriete";
            this.text_Propriete.Size = new System.Drawing.Size(634, 38);
            this.text_Propriete.TabIndex = 5;
            // 
            // text_Controle
            // 
            this.text_Controle.Location = new System.Drawing.Point(382, 378);
            this.text_Controle.Name = "text_Controle";
            this.text_Controle.Size = new System.Drawing.Size(634, 38);
            this.text_Controle.TabIndex = 6;
            // 
            // btn_TestUnit
            // 
            this.btn_TestUnit.Location = new System.Drawing.Point(509, 486);
            this.btn_TestUnit.Name = "btn_TestUnit";
            this.btn_TestUnit.Size = new System.Drawing.Size(507, 64);
            this.btn_TestUnit.TabIndex = 7;
            this.btn_TestUnit.Text = "Lancer test unitaire";
            this.btn_TestUnit.UseVisualStyleBackColor = true;
            this.btn_TestUnit.Click += new System.EventHandler(this.btn_TestUnit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 381);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 32);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nom du contrôle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 434);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 32);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nom de la propriete";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1041, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 32);
            this.label3.TabIndex = 10;
            this.label3.Text = "Résultat";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 331);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 32);
            this.label4.TabIndex = 12;
            this.label4.Text = "Nom de l\'écran";
            // 
            // text_Ecran
            // 
            this.text_Ecran.Location = new System.Drawing.Point(382, 328);
            this.text_Ecran.Name = "text_Ecran";
            this.text_Ecran.Size = new System.Drawing.Size(634, 38);
            this.text_Ecran.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(235, 32);
            this.label5.TabIndex = 13;
            this.label5.Text = "Code PowerApps";
            // 
            // check_Nested
            // 
            this.check_Nested.AutoSize = true;
            this.check_Nested.Location = new System.Drawing.Point(872, 33);
            this.check_Nested.Name = "check_Nested";
            this.check_Nested.Size = new System.Drawing.Size(143, 36);
            this.check_Nested.TabIndex = 14;
            this.check_Nested.Text = "Nestée";
            this.check_Nested.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2235, 751);
            this.Controls.Add(this.check_Nested);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.text_Ecran);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_TestUnit);
            this.Controls.Add(this.text_Controle);
            this.Controls.Add(this.text_Propriete);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.TxtPathMsapp);
            this.Controls.Add(this.btn_testMasse);
            this.Controls.Add(this.text_Resultat);
            this.Controls.Add(this.text_StartCode);
            this.Name = "Form1";
            this.Text = "Autofail testeur";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox text_StartCode;
        private System.Windows.Forms.TextBox text_Resultat;
        private System.Windows.Forms.Button btn_testMasse;
        private System.Windows.Forms.TextBox TxtPathMsapp;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FolderBrowserDialog MsappDialog1;
        private System.Windows.Forms.TextBox text_Propriete;
        private System.Windows.Forms.TextBox text_Controle;
        private System.Windows.Forms.Button btn_TestUnit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox text_Ecran;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox check_Nested;
    }
}

