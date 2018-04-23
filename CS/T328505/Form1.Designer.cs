namespace T328505 {
    partial class Form1 {
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
            this.tokenEdit1 = new T328505.MyTokenEdit();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tokenEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tokenEdit1
            //             
            this.tokenEdit1.Location = new System.Drawing.Point(12, 12);
            this.tokenEdit1.Name = "tokenEdit1";
            this.tokenEdit1.Properties.UseCustomFilter = false;
            this.tokenEdit1.Properties.PopupFilterMode = DevExpress.XtraEditors.TokenEditPopupFilterMode.Contains;
            this.tokenEdit1.Properties.Separators.AddRange(new string[] {
            ","});
            this.tokenEdit1.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Harlen Morais Naves", "Harlen Morais Naves"));
            this.tokenEdit1.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Alex Bob Smith", "Alex Bob Smith"));
            this.tokenEdit1.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("John Morais Davis", "John Morais Davis"));
            this.tokenEdit1.Size = new System.Drawing.Size(292, 20);
            this.tokenEdit1.TabIndex = 0;
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(331, 13);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Enable custom filtering";
            this.checkEdit1.Size = new System.Drawing.Size(133, 19);
            this.checkEdit1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 60);
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.tokenEdit1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tokenEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MyTokenEdit tokenEdit1;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
    }
}

