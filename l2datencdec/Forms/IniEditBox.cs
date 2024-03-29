#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using L2DatEncDec.Tools;

#endregion

namespace L2DatEncDec
{
    public partial class IniEditBox : Form
    {
        private string IniFileName = "";
        public IniEditBox(string IniFileName, string IniText)
        {
            InitializeComponent();
            this.IniFileName = IniFileName;
            this.IniEditer.Text = IniText;
        }

        private void IniEditBox_Load(object sender, EventArgs e)
        {
            // Set Localization
            Program.language.setLocalization(this);
            this.Text = Program.main_form.MenuL2encdecItem2.Text;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string dst_fname = Path.Combine(Program.config.LineAgeDirectory, IniFileName);
            if (Program.config.LineAgeSaveBakFiles)
            {
                try
                {
                    File.Move(dst_fname, Path.ChangeExtension(dst_fname, ".bak"));
                }
                catch
                {
                }
            }
            this.IniEditer.SaveFile(dst_fname, RichTextBoxStreamType.PlainText);
            L2EncDec.Encrypt(IniFileName);
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}