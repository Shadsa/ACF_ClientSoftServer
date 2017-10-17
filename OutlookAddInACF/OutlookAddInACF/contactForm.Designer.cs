namespace OutlookAddInACF
{
    partial class contactForm
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
            this.data_Mail_Box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.data_Entreprise_Box = new System.Windows.Forms.TextBox();
            this.data_Adresse_Box = new System.Windows.Forms.TextBox();
            this.data_CP_Box = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.data_Ville_Box = new System.Windows.Forms.TextBox();
            this.data_Fonction_Box = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.data_Civilite_Box = new System.Windows.Forms.TextBox();
            this.data_Tel_Box = new System.Windows.Forms.TextBox();
            this.data_Nom_Box = new System.Windows.Forms.TextBox();
            this.data_clientvalue = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // data_Mail_Box
            // 
            this.data_Mail_Box.Location = new System.Drawing.Point(337, 173);
            this.data_Mail_Box.Name = "data_Mail_Box";
            this.data_Mail_Box.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.data_Mail_Box.Size = new System.Drawing.Size(100, 20);
            this.data_Mail_Box.TabIndex = 0;
            this.data_Mail_Box.TextChanged += new System.EventHandler(this.ContactName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(254, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nom :";
            // 
            // data_Entreprise_Box
            // 
            this.data_Entreprise_Box.Location = new System.Drawing.Point(113, 42);
            this.data_Entreprise_Box.Name = "data_Entreprise_Box";
            this.data_Entreprise_Box.Size = new System.Drawing.Size(100, 20);
            this.data_Entreprise_Box.TabIndex = 2;
            // 
            // data_Adresse_Box
            // 
            this.data_Adresse_Box.Location = new System.Drawing.Point(113, 72);
            this.data_Adresse_Box.Name = "data_Adresse_Box";
            this.data_Adresse_Box.Size = new System.Drawing.Size(100, 20);
            this.data_Adresse_Box.TabIndex = 3;
            this.data_Adresse_Box.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // data_CP_Box
            // 
            this.data_CP_Box.Location = new System.Drawing.Point(113, 103);
            this.data_CP_Box.Name = "data_CP_Box";
            this.data_CP_Box.Size = new System.Drawing.Size(100, 20);
            this.data_CP_Box.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Entreprise :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Adresse :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "CP :";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // data_Ville_Box
            // 
            this.data_Ville_Box.Location = new System.Drawing.Point(113, 137);
            this.data_Ville_Box.Name = "data_Ville_Box";
            this.data_Ville_Box.Size = new System.Drawing.Size(100, 20);
            this.data_Ville_Box.TabIndex = 8;
            // 
            // data_Fonction_Box
            // 
            this.data_Fonction_Box.Location = new System.Drawing.Point(337, 103);
            this.data_Fonction_Box.Name = "data_Fonction_Box";
            this.data_Fonction_Box.Size = new System.Drawing.Size(100, 20);
            this.data_Fonction_Box.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Ville :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(254, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Civilite :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(254, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Tel :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(254, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Mail :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(254, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Fonction :";
            // 
            // data_Civilite_Box
            // 
            this.data_Civilite_Box.Location = new System.Drawing.Point(337, 72);
            this.data_Civilite_Box.Name = "data_Civilite_Box";
            this.data_Civilite_Box.Size = new System.Drawing.Size(100, 20);
            this.data_Civilite_Box.TabIndex = 16;
            // 
            // data_Tel_Box
            // 
            this.data_Tel_Box.Location = new System.Drawing.Point(337, 137);
            this.data_Tel_Box.Name = "data_Tel_Box";
            this.data_Tel_Box.Size = new System.Drawing.Size(100, 20);
            this.data_Tel_Box.TabIndex = 17;
            // 
            // data_Nom_Box
            // 
            this.data_Nom_Box.Location = new System.Drawing.Point(337, 42);
            this.data_Nom_Box.Name = "data_Nom_Box";
            this.data_Nom_Box.Size = new System.Drawing.Size(100, 20);
            this.data_Nom_Box.TabIndex = 18;
            this.data_Nom_Box.TextChanged += new System.EventHandler(this.textBox8_TextChanged);
            // 
            // data_clientvalue
            // 
            this.data_clientvalue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.data_clientvalue.AutoSize = true;
            this.data_clientvalue.Checked = true;
            this.data_clientvalue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.data_clientvalue.Location = new System.Drawing.Point(337, 209);
            this.data_clientvalue.Name = "data_clientvalue";
            this.data_clientvalue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.data_clientvalue.Size = new System.Drawing.Size(15, 14);
            this.data_clientvalue.TabIndex = 19;
            this.data_clientvalue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.data_clientvalue.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(155, 302);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Valider";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.button2.Location = new System.Drawing.Point(270, 302);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 21;
            this.button2.Text = "Annuler";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(254, 209);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Client ?";
            // 
            // contactForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.data_clientvalue);
            this.Controls.Add(this.data_Nom_Box);
            this.Controls.Add(this.data_Tel_Box);
            this.Controls.Add(this.data_Civilite_Box);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.data_Fonction_Box);
            this.Controls.Add(this.data_Ville_Box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.data_CP_Box);
            this.Controls.Add(this.data_Adresse_Box);
            this.Controls.Add(this.data_Entreprise_Box);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.data_Mail_Box);
            this.Name = "contactForm";
            this.Text = "ACF : Formulaire d\'ajout de Contact";
            this.Load += new System.EventHandler(this.contactForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox data_Mail_Box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox data_Entreprise_Box;
        private System.Windows.Forms.TextBox data_Adresse_Box;
        private System.Windows.Forms.TextBox data_CP_Box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox data_Ville_Box;
        private System.Windows.Forms.TextBox data_Fonction_Box;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox data_Civilite_Box;
        private System.Windows.Forms.TextBox data_Tel_Box;
        private System.Windows.Forms.TextBox data_Nom_Box;
        private System.Windows.Forms.CheckBox data_clientvalue;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label10;
    }
}