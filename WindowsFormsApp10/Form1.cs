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
            addButton.Click += AddButtonClick;
            deleteButton.Click += deleteButtonClick;
            deleteAllButton.Click += deleteAllButtonClick;
        }
        void deleteAllButtonClick(object s, EventArgs e)
        {
            db.delAll();
            update();
        }
        void deleteButtonClick(object s, EventArgs e)
        {
            int temp = listBox1.SelectedIndex;
            if (temp<0)
            {
                return;
            }
            db.delOne(db.sigmak[temp]);
            db.sigmak.RemoveAt(temp);
            update();
        }
        void AddButtonClick(object s, EventArgs e)
        {
            sigma onesigma = new sigma();
            onesigma.nev = guna2TextBox1.Text;
            onesigma.rizzlevel = Convert.ToInt32(guna2NumericUpDown1.Value);
            db.addOne(onesigma);
            update();
        }
        public void update()
        {
            listBox1.Items.Clear();

            db.readAll();
            foreach (sigma item in db.sigmak)
            {
                listBox1.Items.Add($"ID: {item.id}; NÉV: {item.nev}; RIZZ LEVEL: {item.rizzlevel}");
            }
        }
    }
}
