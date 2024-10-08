using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp10
{
    public partial class Form1 : Form
    {
        databaseHandler db;
        public Form1()
        {
            db = new databaseHandler();
            
            InitializeComponent();
            start();
        }
        public void start()
        {
            update();
        }
        public void update()
        {
            db.readAll();
        }
    }
}
