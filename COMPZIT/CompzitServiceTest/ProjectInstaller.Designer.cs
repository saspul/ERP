namespace CompzitServiceTest
{
    partial class ProjectInstaller
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CompzitServiceTestProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.CompzitServiceTestInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // CompzitServiceTestProcessInstaller
            // 
            this.CompzitServiceTestProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.CompzitServiceTestProcessInstaller.Password = null;
            this.CompzitServiceTestProcessInstaller.Username = null;
            // 
            // CompzitServiceTestInstaller
            // 
            this.CompzitServiceTestInstaller.ServiceName = "CompzitTestService";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.CompzitServiceTestProcessInstaller,
            this.CompzitServiceTestInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller CompzitServiceTestProcessInstaller;
        private System.ServiceProcess.ServiceInstaller CompzitServiceTestInstaller;
    }
}