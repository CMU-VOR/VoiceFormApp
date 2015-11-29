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
        void name_ser_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine("Speech recognized:  " + e.Result.Text);
            MessageBox.Show("Speech recognized: " + e.Result.Text);
            NameBox.Text = e.Result.Text.Split().Last();
        }
        void plane_ser_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine("Speech recognized:  " + e.Result.Text);
            MessageBox.Show("Speech recognized: " + e.Result.Text);
            PlaneBox.Text = e.Result.Text.Split().Last();
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
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            recognizer.Dispose();
        }
        private Grammar CreateLogInGrammar()
        {
            Choices nameChoices = new Choices(new string[] { "Ravi", "Ariel", "Bhiksha" });
            GrammarBuilder nameElement = new GrammarBuilder(nameChoices);
            Choices planeChoices = new Choices(new string[] { "787", "777", "747" });
            GrammarBuilder planeElement = new GrammarBuilder(planeChoices);
            // Create grammar builders for the two versions of the phrase.
            GrammarBuilder namePhrase = new GrammarBuilder("The customer name is");
            namePhrase.Append(nameElement);
            GrammarBuilder planePhrase = new GrammarBuilder("The plane model is");
            planePhrase.Append(planeElement);

            // Create a Choices for the two alternative phrases, convert the Choices
            // to a GrammarBuilder, and construct the grammar from the result.
            Choices bothChoices = new Choices(new GrammarBuilder[] { namePhrase, planePhrase });
            Grammar grammar = new Grammar((GrammarBuilder)bothChoices);
            grammar.Name = "loginGrammar";
            return grammar;
        }
        SpeechRecognizer recognizer;
        Grammar g;
        private void RecordButton2_Click(object sender, EventArgs e)
        {
            recognizer = new SpeechRecognizer();
            g = CreateLogInGrammar();
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(plane_ser_SpeechRecognized);
            recognizer.LoadGrammar(g);
        }

        private void RecordButton1_Click(object sender, EventArgs e)
        {
            recognizer = new SpeechRecognizer();
            g = CreateLogInGrammar();
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(name_ser_SpeechRecognized);
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

