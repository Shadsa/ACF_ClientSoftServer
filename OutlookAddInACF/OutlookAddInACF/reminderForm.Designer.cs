namespace OutlookAddInACF
{
    partial class reminderForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ReminderObject = new System.Windows.Forms.TextBox();
            this.DateReminder = new System.Windows.Forms.DateTimePicker();
            this.NoteReminder = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Objet du Reminder :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Note :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date :";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // ReminderObject
            // 
            this.ReminderObject.Location = new System.Drawing.Point(218, 45);
            this.ReminderObject.Name = "ReminderObject";
            this.ReminderObject.Size = new System.Drawing.Size(200, 20);
            this.ReminderObject.TabIndex = 3;
            // 
            // DateReminder
            // 
            this.DateReminder.Location = new System.Drawing.Point(218, 100);
            this.DateReminder.Name = "DateReminder";
            this.DateReminder.Size = new System.Drawing.Size(200, 20);
            this.DateReminder.TabIndex = 4;
            // 
            // NoteReminder
            // 
            this.NoteReminder.BackColor = System.Drawing.SystemColors.Window;
            this.NoteReminder.Location = new System.Drawing.Point(218, 166);
            this.NoteReminder.Name = "NoteReminder";
            this.NoteReminder.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.NoteReminder.Size = new System.Drawing.Size(200, 161);
            this.NoteReminder.TabIndex = 6;
            this.NoteReminder.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(155, 407);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Valider";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(270, 407);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Annuler";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // reminderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.NoteReminder);
            this.Controls.Add(this.DateReminder);
            this.Controls.Add(this.ReminderObject);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "reminderForm";
            this.Text = "Inscrire un Reminder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ReminderObject;
        private System.Windows.Forms.DateTimePicker DateReminder;
        private System.Windows.Forms.RichTextBox NoteReminder;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}