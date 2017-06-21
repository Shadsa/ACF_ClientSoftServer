namespace OutlookAddInACF
{
    partial class ACF : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public ACF()
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
            this.ACFTab = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.SaveButton = this.Factory.CreateRibbonButton();
            this.OptionButton = this.Factory.CreateRibbonButton();
            this.ACFTab.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ACFTab
            // 
            this.ACFTab.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.ACFTab.Groups.Add(this.group1);
            this.ACFTab.Label = "ACF-AddIn";
            this.ACFTab.Name = "ACFTab";
            // 
            // group1
            // 
            this.group1.Items.Add(this.SaveButton);
            this.group1.Items.Add(this.OptionButton);
            this.group1.Label = "Sauvegarde / Option";
            this.group1.Name = "group1";
            // 
            // SaveButton
            // 
            this.SaveButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.SaveButton.Description = "Sauvegarde";
            this.SaveButton.Label = "Sauvegarde";
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.ScreenTip = "Sauvegarde ce mail et les donnée sur l\'application ACF";
            this.SaveButton.ShowImage = true;
            this.SaveButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.SaveButton_Click);
            // 
            // OptionButton
            // 
            this.OptionButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.OptionButton.Description = "Option";
            this.OptionButton.Label = "Option d\'envoi automatique";
            this.OptionButton.Name = "OptionButton";
            this.OptionButton.ScreenTip = "Permet de définir des paramétre d\'envois automatique relatif à ce genre de mail.";
            this.OptionButton.ShowImage = true;
            this.OptionButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.OptionButton_Click);
            // 
            // ACF
            // 
            this.Name = "ACF";
            this.RibbonType = "Microsoft.Outlook.Explorer, Microsoft.Outlook.Mail.Compose, Microsoft.Outlook.Mai" +
    "l.Read";
            this.Tabs.Add(this.ACFTab);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.ACFTab.ResumeLayout(false);
            this.ACFTab.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab ACFTab;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton OptionButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton SaveButton;
    }

    partial class ThisRibbonCollection
    {
        internal ACF Ribbon1
        {
            get { return this.GetRibbon<ACF>(); }
        }
    }
}
