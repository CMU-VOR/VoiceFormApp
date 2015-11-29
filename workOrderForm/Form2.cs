using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            //System.Diagnostics.Debug.WriteLine(plane+"!!");
            NameLabel.Text = NameLabel.Text + Name;
            PlaneLabel.Text = PlaneLabel.Text + Plane;

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
}
