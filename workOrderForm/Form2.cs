using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;

namespace workOrderForm
{
    public partial class WorkOrderForm : Form
    {
        static String name;
        static String plane;
        Dictionary<string, string> dictionary;
        List<Control> controls;
        public WorkOrderForm(String Name, String Plane)
        {
            InitializeComponent();
            name = Name;
            plane = Plane;
            NameLabel.Text = NameLabel.Text + Name;
            PlaneLabel.Text = PlaneLabel.Text + Plane;
            generateComponents(Name, Plane);

        }
        List<string> Text1 = new List<string>();
        List<string> Text2 = new List<string>();
        async void generateComponents(String Name, String Plane)
        {
            string uri = "http://boeing.elasticbeanstalk.com/vor/get_form/";
            await get_form(uri);

            foreach (Control p in panel1.Controls)
            {
                //Console.WriteLine(p.Name);
                if (p.Name == "user")
                {
                    p.Text = Name;
                }
                else if (p.Name == "plane")
                {
                    p.Text = Plane;
                }
                else if (p.Name == "location")
                {
                    ComboBox t = (ComboBox)p;
                    foreach (var item in t.Items)
                        Text1.Add(item.ToString());
                }
                else if (p.Name == "job_type")
                {
                    ComboBox t = (ComboBox)p;
                    foreach (var item in t.Items)
                        Text2.Add(item.ToString());
                }
            }
  
        }
        private Grammar CreateFormGrammar()
        {
            Choices locationChoices = new Choices(Text1.ToArray());
            GrammarBuilder locationElement = new GrammarBuilder(locationChoices);
            Choices jobTypeChoices = new Choices(Text2.ToArray());
            GrammarBuilder jobTypeElement = new GrammarBuilder(jobTypeChoices);
            // Create grammar builders for the two versions of the phrase.
            GrammarBuilder locationPhrase = new GrammarBuilder("The location of the problem is at");
            locationPhrase.Append(locationElement);
            GrammarBuilder jobTypePhrase = new GrammarBuilder("The type of job is");
            jobTypePhrase.Append(jobTypeElement);

            // Create a Choices for the two alternative phrases, convert the Choices
            // to a GrammarBuilder, and construct the grammar from the result.
            Choices bothChoices = new Choices(new GrammarBuilder[] { locationPhrase, jobTypePhrase });
            Grammar grammar = new Grammar((GrammarBuilder)bothChoices);
            grammar.Name = "FormGrammar";
            return grammar;
        }
        SpeechRecognizer recognizer;
        Grammar g;


        async Task get_form(String url)
        {

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        JObject o = JObject.Parse(content.ReadAsStringAsync().Result);
                        IList<JToken> fields = o["fields"].Children().ToList();
                        int xLabel = 0;
                        int xElement = 100;
                        int yLabel = 18;
                        int yElement = 16;
                        dictionary = new Dictionary<string, string>();
                        controls = new List<Control>();
                        foreach (JToken field in fields)
                        {
                            string field_type = field["field_type"].ToString();
                            if (field_type.Equals("TextInput"))
                            {
                                TextBox txt = new TextBox();
                                txt.Name = field["column_name"].ToString();
                                txt.Location = new System.Drawing.Point(xElement, yElement);
                                txt.Size = new System.Drawing.Size(200, 28);
                                Label label = new Label();
                                label.Location = new System.Drawing.Point(xLabel, yLabel);
                                label.Text = field["field_name"].ToString();
                                panel1.Controls.Add(label);
                                panel1.Controls.Add(txt);
                                controls.Add(txt);
                            }
                            else if (field_type.Equals("Select"))
                            {
                                var select = new ComboBox();
                                select.Name = field["column_name"].ToString();
                                select.Location = new System.Drawing.Point(xElement, yElement);
                                select.Size = new System.Drawing.Size(200, 28);
                                Label label = new Label();
                                label.Location = new System.Drawing.Point(xLabel, yLabel);
                                label.Text = field["field_name"].ToString();
                                IList<JToken> choices = field["choices"].Children().ToArray<JToken>();
                                foreach (JToken choice in choices)
                                {
                                    select.Items.Add(choice["value"].ToString());
                                    dictionary.Add(choice["value"].ToString(), choice["id"].ToString());
                                }
                                //if (select.Name != "plane")
                                //{
                                //    Button btn = new Button();
                                //    btn.Location = new System.Drawing.Point(xLabel + 350, yLabel);
                                //    btn.Size = new System.Drawing.Size(50, 28);
                                //    btn.Text = "P";
                                //    panel1.Controls.Add(btn);
                                //}   
                                panel1.Controls.Add(select);
                                panel1.Controls.Add(label);
                                controls.Add(select);
                                

                            }
                            else if (field_type.Equals("Textarea"))
                            {
                                var box = new RichTextBox();
                                box.Name = field["column_name"].ToString();
                                box.Location = new System.Drawing.Point(xElement, yElement);
                                box.Size = new System.Drawing.Size(250, 100);
                                Label label = new Label();
                                label.Location = new System.Drawing.Point(xLabel, yLabel);
                                label.Text = field["field_name"].ToString();
                                panel1.Controls.Add(box);
                                panel1.Controls.Add(label);
                                controls.Add(box);
                            }
                            yLabel = yLabel + 50;
                            yElement = yElement + 50;
                        }
                    }
                }
            }
        }

        async void post_form(String url)
        {
            List<KeyValuePair<String, String>> data = new List<KeyValuePair<String, String>>();
            data.Add(new KeyValuePair<string, string>("form_name", "Aform"));
            foreach (Control item in controls)
            {
                if (item.Name.Equals("location"))
                {
                    data.Add(new KeyValuePair<string, string>(item.Name, dictionary[item.Text]));
                }
                else {
                    data.Add(new KeyValuePair<string, string>(item.Name, item.Text));
                }
            }
            string q = new FormUrlEncodedContent(data).ReadAsStringAsync().Result;
            url = url + "?" + q;
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        label1.Text = content.ReadAsStringAsync().Result;
                    }
                }
            }
        }

        private void WorkOrderForm_Load(object sender, EventArgs e)
        {
            //set it full screen
            //this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string uri = "http://boeing.elasticbeanstalk.com/vor/post_form/";
            post_form(uri);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            recognizer = new SpeechRecognizer();
            g = CreateFormGrammar();
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(location_ser_SpeechRecognized);
            recognizer.LoadGrammar(g);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            recognizer = new SpeechRecognizer();
            g = CreateFormGrammar();
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(jobType_ser_SpeechRecognized);
            recognizer.LoadGrammar(g);
        }

        void location_ser_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine("Speech recognized:  " + e.Result.Text);
            MessageBox.Show("Speech recognized: " + e.Result.Text);
            foreach (Control p in panel1.Controls)
            {
                if (p.Name == "location")
                {
                    p.Text = e.Result.Text.Split().Last();
                }         
                else if (p.Name == "description")
                {
                    p.Text = e.Result.Text + ". ";
                }
            }

        }
        void jobType_ser_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine("Speech recognized:  " + e.Result.Text);
            MessageBox.Show("Speech recognized: " + e.Result.Text);
            foreach (Control p in panel1.Controls)
            {
                if (p.Name == "job_type")
                {
                    p.Text = e.Result.Text.Split().Last();
                }
                else if (p.Name == "description")
                {
                    p.Text += e.Result.Text + ". ";
                }
            }
        }
    }


}
