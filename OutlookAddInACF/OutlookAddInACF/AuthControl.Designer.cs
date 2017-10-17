namespace OutlookAddInACF
{
    partial class AuthControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.data_Mail = new System.Windows.Forms.TextBox();
            this.data_password = new System.Windows.Forms.TextBox();
            this.ValidationButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mail du compte :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mot de passe :";
            // 
            // data_Mail
            // 
            this.data_Mail.Location = new System.Drawing.Point(9, 82);
            this.data_Mail.Name = "data_Mail";
            this.data_Mail.Size = new System.Drawing.Size(169, 20);
            this.data_Mail.TabIndex = 2;
            // 
            // data_password
            // 
            this.data_password.Location = new System.Drawing.Point(9, 144);
            this.data_password.Name = "data_password";
            this.data_password.PasswordChar = '*';
            this.data_password.Size = new System.Drawing.Size(169, 20);
            this.data_password.TabIndex = 3;
            this.data_password.UseSystemPasswordChar = true;
            // 
            // ValidationButton
            // 
            this.ValidationButton.Location = new System.Drawing.Point(34, 255);
            this.ValidationButton.Name = "ValidationButton";
            this.ValidationButton.Size = new System.Drawing.Size(96, 23);
            this.ValidationButton.TabIndex = 4;
            this.ValidationButton.Text = "Se Connecter";
            this.ValidationButton.UseVisualStyleBackColor = true;
            this.ValidationButton.Click += new System.EventHandler(this.OnClick);
            // 
            // AuthControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ValidationButton);
            this.Controls.Add(this.data_password);
            this.Controls.Add(this.data_Mail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AuthControl";
            this.Size = new System.Drawing.Size(194, 324);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox data_Mail;
        private System.Windows.Forms.TextBox data_password;
        private System.Windows.Forms.Button ValidationButton;
    }
}
