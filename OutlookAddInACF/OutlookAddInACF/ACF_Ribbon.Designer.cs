namespace OutlookAddInACF
{
    partial class ACF_Ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public ACF_Ribbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.SauvegarderPJ = this.Factory.CreateRibbonButton();
            this.SauvegarderMail = this.Factory.CreateRibbonButton();
            this.ParametreEnvoisMailAuto = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.ExportFile = this.Factory.CreateRibbonButton();
            this.AddReminder = this.Factory.CreateRibbonButton();
            this.AddContact = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.group2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Groups.Add(this.group2);
            this.tab1.Label = "ACF_Addin";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.SauvegarderPJ);
            this.group1.Items.Add(this.SauvegarderMail);
            this.group1.Items.Add(this.ParametreEnvoisMailAuto);
            this.group1.Label = "Sauvegarde/Option";
            this.group1.Name = "group1";
            // 
            // SauvegarderPJ
            // 
            this.SauvegarderPJ.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.SauvegarderPJ.Label = "Sauvegarder Pièce Jointe";
            this.SauvegarderPJ.Name = "SauvegarderPJ";
            this.SauvegarderPJ.ShowImage = true;
            this.SauvegarderPJ.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.SauvegarderPJ_Click);
            // 
            // SauvegarderMail
            // 
            this.SauvegarderMail.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.SauvegarderMail.Label = "Sauvegarder Mail";
            this.SauvegarderMail.Name = "SauvegarderMail";
            this.SauvegarderMail.ShowImage = true;
            this.SauvegarderMail.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.SauvegarderMail_Click);
            // 
            // ParametreEnvoisMailAuto
            // 
            this.ParametreEnvoisMailAuto.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.ParametreEnvoisMailAuto.Label = "Paramétre d\'envois Auto";
            this.ParametreEnvoisMailAuto.Name = "ParametreEnvoisMailAuto";
            this.ParametreEnvoisMailAuto.ShowImage = true;
            this.ParametreEnvoisMailAuto.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ParametreEnvoisMailAuto_Click);
            // 
            // group2
            // 
            this.group2.Items.Add(this.ExportFile);
            this.group2.Items.Add(this.AddReminder);
            this.group2.Items.Add(this.AddContact);
            this.group2.Label = "Envois de donner (APP ACF)";
            this.group2.Name = "group2";
            // 
            // ExportFile
            // 
            this.ExportFile.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.ExportFile.Label = "Exporter un fichier";
            this.ExportFile.Name = "ExportFile";
            this.ExportFile.ShowImage = true;
            this.ExportFile.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ExportFile_Click);
            // 
            // AddReminder
            // 
            this.AddReminder.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.AddReminder.Label = "Ajouter un Reminder";
            this.AddReminder.Name = "AddReminder";
            this.AddReminder.ShowImage = true;
            this.AddReminder.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.AddReminder_Click);
            // 
            // AddContact
            // 
            this.AddContact.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.AddContact.Label = "Ajouter Contact";
            this.AddContact.Name = "AddContact";
            this.AddContact.ShowImage = true;
            this.AddContact.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.AddContact_Click);
            // 
            // ACF_Ribbon
            // 
            this.Name = "ACF_Ribbon";
            this.RibbonType = "Microsoft.Outlook.Explorer, Microsoft.Outlook.Task";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.ACF_Ribbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ParametreEnvoisMailAuto;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton SauvegarderMail;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ExportFile;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AddReminder;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AddContact;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton SauvegarderPJ;
    }

    partial class ThisRibbonCollection
    {
        internal ACF_Ribbon ACF_Ribbon
        {
            get { return this.GetRibbon<ACF_Ribbon>(); }
        }
    }
}
