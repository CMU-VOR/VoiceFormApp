using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace workOrderForm
{
    public partial class WorkOrderForm : Form
    {
        static String name;
        static String plane;
        public WorkOrderForm(String Name, String Plane)
        {
            InitializeComponent();
            NameLabel.Text = NameLabel.Text + Name;
            PlaneLabel.Text = PlaneLabel.Text + Plane;
            getResponse();


        }
        private String getResponse()
        {
            Uri uri = new Uri("http://boeing.elasticbeanstalk.com/vor/get_form");
            WebRequest request = WebRequest.Create(uri);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Console.WriteLine(response.StatusDescription);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            reader.Close();
            dataStream.Close();
            response.Close();
            //Dictionary<string, string> items = JsonConvert.DeserializeObject<Dictionary<string,string>>(responseFromServer);
            form orderForm = JsonConvert.DeserializeObject<form>(responseFromServer);
            Console.WriteLine(orderForm.form_name);
            return responseFromServer;
        }

        private void WorkOrderForm_Load(object sender, EventArgs e)
        {
            //set it full screen
            //this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {

        }
    }
    public class form
    {
        public String form_name { get; set; }
        public IList<String> fields { get; set; }
    }

}
