using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Recognition;


namespace workOrderForm
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
            
        }
        // The handler to change the Text in the comboBox 
        void ser_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine("Speech recognized:  " + e.Result.Text);
            MessageBox.Show("Speech recognized: " + e.Result.Text);
            NameBox.Text = e.Result.Text.Split().Last();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void GoButton_Click(object sender, EventArgs e)
        {
            string name = NameBox.Text;
            string plane = PlaneBox.Text;
            // System.Diagnostics.Debug.WriteLine(name);
            // System.Diagnostics.Debug.WriteLine(plane);

            this.Hide();
            var wf = new WorkOrderForm(name, plane);
            // set new close event here
            wf.FormClosed += (s, args) => this.Close();
            wf.Show();
        }
        
        private void RecordButton2_Click(object sender, EventArgs e)
        {

        }
        SpeechRecognizer recognizer;
        GrammarBuilder gb;
        Choices names;
        Grammar g;
        private void RecordButton1_Click(object sender, EventArgs e)
        {
            recognizer = new SpeechRecognizer();
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(ser_SpeechRecognized);
            gb = new GrammarBuilder("The customer name is");
            names = new Choices();
            names.Add(new String[] { "Ravi", "Michael", "Ariel", "Sansa", "Bhiksha" });
            gb.Append(names);
            g = new Grammar(gb);
            recognizer.LoadGrammar(g);
        }

        private void NameBox_TextChanged(object sender, EventArgs e)
        {
            // TextBox t = (TextBox)sender;
            // var text = t.Text;
            // System.Diagnostics.Debug.WriteLine(text);
        }

        private void PlaneBox_TextChanged(object sender, EventArgs e)
        {
            // TextBox t = (TextBox)sender;
            // var text = t.Text;
            // System.Diagnostics.Debug.WriteLine(text);
        }
    }
}

