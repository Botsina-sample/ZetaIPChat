using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZetaIpc.Runtime.Client;
using System.Threading;

namespace Chat_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Chat_Client(8080);
        }


        public void Chat_Client(int port)
        {
            try
            {
                Task.Factory.StartNew(() =>
                {
                    var c = new IpcClient();

                    c.Initialize(port);

                    listBox1.Items.Add("Started client.");

                    var rep = c.Send("Hello from client");

                    listBox1.Items.Add(rep);

                    
                });
                //while(true)
                //{
                //    Thread.Sleep(1000);
                //}
            }
            catch(Exception ex)
            {
                listBox1.Items.Add(ex.Message);
    
            }
          

            //Console.WriteLine();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Chat_Client(8080);
        }
    }
}
