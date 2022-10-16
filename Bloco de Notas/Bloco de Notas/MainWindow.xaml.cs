using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace Bloco_de_Notas
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public string Titulo
        {
            get { return NoteItems.title;}
            set { NoteItems.title = value;}

        }

        static class NoteItems
        {
            public static string filename;
            public static string title;
        }
        public MainWindow()
        {
            NoteItems.filename = "";
            NoteItems.title = "Bloco de Notas";
            InitializeComponent();
        }


        public string StringFromRichTextBox(RichTextBox rtb)
        {
            TextRange textRange = new TextRange(
                // TextPointer to the start of content in the RichTextBox.
                rtb.Document.ContentStart,
                // TextPointer to the end of content in the RichTextBox.
                rtb.Document.ContentEnd
            );

            // The Text property on a TextRange object returns a string
            // representing the plain text content of the TextRange.
            return textRange.Text;
        }

        public void SaveFileAs()
        {
            string preFilename;
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Arquivo de Texto (*.txt)|*.txt";
            saveDialog.DefaultExt = "txt";
            saveDialog.AddExtension = true;
            saveDialog.ShowDialog();
            if (saveDialog.FileName != "")
            {
                preFilename = saveDialog.FileName;
                File.WriteAllText(preFilename, StringFromRichTextBox(text_area));
                NoteItems.filename = preFilename;
                NoteItems.title = "Bloco de Notas | "+ Path.GetFileName(preFilename);
            }
        }
        private void click_salvar_como(object sender, RoutedEventArgs e)
        {
            SaveFileAs();
            
        }

        private void salvar_unico(object sender, RoutedEventArgs e)
        {
            if( NoteItems.filename == "")
            {
                SaveFileAs();
            }
            else
            {
                File.WriteAllText(NoteItems.filename, StringFromRichTextBox(text_area));
            }
        }
    }
}

