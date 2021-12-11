using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_Project1
{
    public partial class Form1 : Form
    {
        public Employee emp;
        public Form1()
        {
            InitializeComponent();
            emp = new Employee();
        }
        
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {   
                int count = Convert.ToInt32(txtQuantity.Text);
                if (count <= 0) {
                    listBox1.Items.Add( "It's worries number!");
                    return;
                }
                string foodName = (rbtnChicken.Checked) ? "Chicken" : "Egg";

                var order = emp.NewRequest(count, foodName);
                if (order.Name() == "Egg")
                    lblQuality.Text = order.GetQuality()?.ToString();
                listBox1.Items.Add(emp.Inspect());
            }catch(Exception ex)
            {
               listBox1.Items.Add(ex.Message);
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void btnCopy_Click(object sender, EventArgs e)
        {
             var order = emp.CopyRequest();
            if(order.GetType()==new Exception().GetType())
            {
                listBox1.Items.Add(order.Message);
                return;
            }
            if (order.Name() == "Egg")
                lblQuality.Text = order.GetQuality()?.ToString();
            listBox1.Items.Add(emp.Inspect());
        }

        private void btnPrepare_Click(object sender, EventArgs e)
        {
            var cook = emp.PrepareFood();
            listBox1.Items.Add(cook);
           
                
        }

    }
}
