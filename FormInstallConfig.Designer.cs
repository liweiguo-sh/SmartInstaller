
namespace SmartInstaller {
    partial class FormInstallConfig {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInstallConfig));
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnSelectTargetPath = new System.Windows.Forms.Button();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.BtnInstall = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(83, 40);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(489, 26);
            this.txtTarget.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "安装目录";
            // 
            // BtnSelectTargetPath
            // 
            this.BtnSelectTargetPath.Location = new System.Drawing.Point(578, 39);
            this.BtnSelectTargetPath.Name = "BtnSelectTargetPath";
            this.BtnSelectTargetPath.Size = new System.Drawing.Size(36, 28);
            this.BtnSelectTargetPath.TabIndex = 3;
            this.BtnSelectTargetPath.Text = "...";
            this.BtnSelectTargetPath.UseVisualStyleBackColor = true;
            this.BtnSelectTargetPath.Click += new System.EventHandler(this.BtnSelectTargetPath_Click);
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(83, 284);
            this.txtSource.Name = "txtSource";
            this.txtSource.ReadOnly = true;
            this.txtSource.Size = new System.Drawing.Size(489, 26);
            this.txtSource.TabIndex = 3;
            this.txtSource.TabStop = false;
            // 
            // BtnInstall
            // 
            this.BtnInstall.Location = new System.Drawing.Point(514, 179);
            this.BtnInstall.Name = "BtnInstall";
            this.BtnInstall.Size = new System.Drawing.Size(100, 36);
            this.BtnInstall.TabIndex = 1;
            this.BtnInstall.Text = "安装(&I)";
            this.BtnInstall.UseVisualStyleBackColor = true;
            this.BtnInstall.Click += new System.EventHandler(this.BtnInstall_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.ForeColor = System.Drawing.Color.Blue;
            this.lblWelcome.Location = new System.Drawing.Point(79, 9);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(269, 20);
            this.lblWelcome.TabIndex = 4;
            this.lblWelcome.Text = "感谢安装使用 码尚打印服务工作站 客户端";
            // 
            // FormInstallConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 236);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.BtnInstall);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.BtnSelectTargetPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTarget);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormInstallConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Smart install config";
            this.Load += new System.EventHandler(this.FormInstallConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnSelectTargetPath;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Button BtnInstall;
        private System.Windows.Forms.Label lblWelcome;
    }
}