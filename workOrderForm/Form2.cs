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
            NameLabel.Text = NameLabel.Text + Name;
            PlaneLabel.Text = PlaneLabel.Text + Plane;
            string uri = "http://boeing.elasticbeanstalk.com/vor/get_form/";
            get_form(uri);

        }

        async void get_form(String url)
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
    }
    public class form
    {
        public String form_name { get; set; }
        public IList<String> fields { get; set; }
    }

}
