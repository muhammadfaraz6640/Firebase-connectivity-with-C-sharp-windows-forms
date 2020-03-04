using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
namespace firebase
{
    public partial class Form1 : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "G4hhYiM1oT9i5JyFcIHZvuEQEmHmu0RqGl3rbjtE",
            BasePath = "https://fir-connection-ed01b.firebaseio.com/"
        };
        IFirebaseClient client;
        public Form1()
        {
            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            if(client!=null)
            {
                MessageBox.Show("successfully established");                
            }

        }
  
        private async void button1_Click(object sender, EventArgs e)
        {
            var data = new Data
            {
                Id = textBox1.Text,
                Pass = textBox2.Text
            };
            SetResponse res = await client.SetTaskAsync("" + textBox1.Text, data);
            Data result = res.ResultAs<Data>();
            MessageBox.Show("inserted....");
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var data = new Data
            {
                Id = textBox1.Text,
                Pass = textBox2.Text
            };
            FirebaseResponse response = await client.GetTaskAsync(textBox1.Text);
            Data obj = response.ResultAs<Data>();
            textBox2.Text = obj.Pass;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var data = new Data
            {
                Id = textBox1.Text,
                Pass = textBox2.Text
            };
            //SetResponse res = await client.UpdateTaskAsync("" + textBox1.Text, data);
            var set = client.Update(textBox1.Text, data);
            //Data result = res.ResultAs<Data>();
            MessageBox.Show("updated....");
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            var set = client.Delete(textBox1.Text);
            MessageBox.Show("deleted....");
        }
    }
}
