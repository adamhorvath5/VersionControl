using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mnbgyakk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        private void meghivas()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
