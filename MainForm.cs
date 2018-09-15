using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

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

            var wordApp = new Word.Application();
            wordApp.Visible = false;

            try
            {
                var wordDocument = wordApp.Documents.Open(TemplateFileName);
                ReplaceWordStub("{name}", name, wordDocument);
                ReplaceWordStub("{enddate}", endDate, wordDocument);
                ReplaceWordStub("{signDate}", signDate, wordDocument);

                wordDocument.SaveAs2(@"c:\result.doc");
                wordApp.Visible = true;
            }
            catch
            {
                MessageBox.Show("Произошла ошибка");
            }
            
        }

        private void ReplaceWordStub(string stubToReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }
    }
}
