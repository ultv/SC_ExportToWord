using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExportToWord
{
    public partial class MainForm : Form
    {
        private readonly string TemplateFileName = @"c:\test.doc";

        public MainForm()
        {
            InitializeComponent();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            var name = NameTextBox.Text;
            var endDate = EndDateTimePicker.Value.ToShortDateString();
            var signDate = SignDateTimePicker.Value.ToShortDateString();

            // TODO: Word Export
        }
    }
}
