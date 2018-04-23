using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace T328505 {
    public partial class Form1 : XtraForm {
        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            this.tokenEdit1.Properties.UseCustomFilter = true;
            this.tokenEdit1.Properties.CustomFilterTokens = new EventHandler<MyFilterEventArgs>(TokenEdit_CustomFilterText);           
        }
        private void TokenEdit_CustomFilterText(object sender, MyFilterEventArgs e) {
            if(this.checkEdit1.Checked)
                e.IsValidToken = e.Token.Description.Contains("Morais");
        }
    }
}
