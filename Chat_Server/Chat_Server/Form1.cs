using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZetaIpc.Runtime.Server;
using System.Threading;

namespace Chat_Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        public int _Port;
        public string _response = "Hello from Sever";
        public string _request;
        public bool _stop = false;

        IpcServer s = new IpcServer();

        public void Chat_Server(int port)
        {
            
            s.Start(port); // Passing no port selects a free port automatically.

            

            listBox1.Items.Add("Started server on port {0}." + s.Port);

            s.ReceivedRequest += (sender, args) =>
            {

                args.Response = _response;

                _request = args.Request;



                

                args.Handled = true;

                listBox1.Items.Add(_request);

            };

            

            //if (_stop == true)
            //{
            //    s.Stop();
              
            //}
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        // input Port number
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //_Port = int.Parse(textBox1.Text);
        }

        // send text to listbox
        private void button2_Click(object sender, EventArgs e)
        {
            s.ReceivedRequest += (sender1, args) =>
            {

                args.Response = "Hello";

                _request = args.Request;





                args.Handled = true;

                listBox1.Items.Add(_request);

            };


        }

        //Start Server
        private void button1_Click(object sender, EventArgs e)
        {
            Chat_Server(8080);
       
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            s.Stop();

        }
    }
}
