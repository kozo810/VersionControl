using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace hetedikhazi
{
    public partial class Form1 : Form
    {
        private BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";

            InitializeComponent();
            label1.Text = Resource1.LastName;

            button2.Text = "Fájlba írás";
            

            button1.Text = Resource1.Add;

            
            var u = new User()
            {
                FullName = textBox1.Text,
                
            };
            users.Add(u);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd1 = new SaveFileDialog();
            if (sfd1.ShowDialog() != DialogResult.OK) return;
            using StreamWriter sw = new StreamWriter(sfd1.FileName, false, Encoding.UTF8);
            {
                foreach (var s in users)
                {
                    sw.WriteLine(s.ID);
                    sw.WriteLine(";");
                    sw.WriteLine(s.FullName);
                    sw.WriteLine();

                }

            }
        }
        }
    }

