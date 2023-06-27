using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace task1
{
    public partial class Form1 : Form
    {
        private string csvFilePath = "C:/Users/User/source/repos/task1/task1.csv";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Name = textName.Text;
            string Email = textEmail.Text;
            string Contact = textPhoneNum.Text;

            string csvLine = $"{Name},{Email},{Contact}";

            using (StreamWriter sw = File.AppendText(csvFilePath))
            {
                sw.WriteLine(csvLine);
            }
            MessageBox.Show("Data saved successfully!");

        }
    }
}