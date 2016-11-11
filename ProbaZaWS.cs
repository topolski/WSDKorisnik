using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WSKorisnik
{
    public partial class ProbaZaWS : Form
    {
        public ProbaZaWS()
        {
            InitializeComponent();
        }

        private string[] links = new string[50];
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            linkLabel1.Text = "";
            int i = 0;
            if (comboBox2.Size.IsEmpty)
            {
                comboBox2.Text = "";
            }
            else { comboBox2.Items.Clear(); comboBox2.Text = ""; }
            WSProxies.WebService service = new WSProxies.WebService();
            if (comboBox3.SelectedItem.ToString() == "XML")
            {
                WSProxies.Post[] postovi = service.getPosts(comboBox1.SelectedItem.ToString());
                foreach (WSProxies.Post post in postovi)
                {
                    comboBox2.Items.Add(post.Naslov);
                    links[i] = post.LinkKaPostu;
                    i++;
                }
            }
            else if (comboBox3.SelectedItem.ToString() == "JSON")
            {
                WSProxies.Post[] postoviJson = service.getPostsJson(comboBox1.SelectedItem.ToString());
                foreach (WSProxies.Post post in postoviJson)
                {
                    comboBox2.Items.Add(post.Naslov);
                    links[i] = post.LinkKaPostu;
                    i++;
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {   
            linkLabel1.Text = links[comboBox2.SelectedIndex];
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear(); 
            comboBox1.Text = "";
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            linkLabel1.Text = "";
            WSProxies.WebService service = new WSProxies.WebService();
            if (comboBox3.SelectedItem.ToString() == "XML")
            {
                WSProxies.Kategorija[] kat = service.getKategorije();
                foreach (WSProxies.Kategorija kate in kat)
                {
                    comboBox1.Items.Add(kate.nazivKategorije);
                }
            }
            else if (comboBox3.SelectedItem.ToString() == "JSON")
            {
                WSProxies.Kategorija[] katJson = service.getKategorijeJson();
                foreach (WSProxies.Kategorija kate in katJson)
                {
                    comboBox1.Items.Add(kate.nazivKategorije);
                }
            }
        }
    }
}
