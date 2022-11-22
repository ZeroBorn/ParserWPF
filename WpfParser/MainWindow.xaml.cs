using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Windows;
using System.Xml.Linq;

namespace WpfParser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HelpUse_Click(object sender, RoutedEventArgs e)
        {
            string path = "Help.txt";
            txtEditor.Text = System.IO.File.ReadAllText(path);
        }

        private void OpenDoc_Click(object sender, RoutedEventArgs e)
        {
  
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var get_text = openFileDialog.FileName;
                var json_text = GetJsonFromXml(get_text);
                txtEditor.Text = json_text;
            }
        }

        private void AddDb_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            txtEditor.Text = "";
        }
        static string GetJsonFromXml(string path)
        {
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            string data = Encoding.UTF8.GetString(bytes);

            var xdoc = XDocument.Parse(data);
            return JsonConvert.SerializeXNode(xdoc, Newtonsoft.Json.Formatting.Indented);
        }
    }
}
