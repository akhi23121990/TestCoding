using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
       public readonly Dictionary<string, double> lstofProducts = new Dictionary<string, double>();
        public readonly Dictionary<string,Promotion> lstofPromtions = new Dictionary<string, Promotion>();
        public double Total = 0.00;
        public List<string> purchasedItems = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lstofProducts.Add(textBox1.Text, Convert.ToDouble(textBox2.Text));
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex==0)
            {
                lstofPromtions.Add(textBox4.Text, new Promotion(Convert.ToInt32(textBox3.Text), Convert.ToDouble(textBox5.Text),Promotiontype.Single,""));
            }
            else
            {
                lstofPromtions.Add(textBox4.Text, new Promotion(Convert.ToInt32(textBox3.Text), Convert.ToDouble(textBox5.Text),Promotiontype.Combo, textBox8.Text));
            }

            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            purchasedItems.Add(textBox7.Text);
            var promotion = lstofPromtions.FirstOrDefault(x => x.Key == textBox7.Text).Value;
            if (promotion != null)
            {
                if (promotion._Promotiontype == Promotiontype.Combo)
                {
                    Total += Convert.ToInt32(textBox6.Text) * lstofProducts.FirstOrDefault(x => x.Key == textBox7.Text).Value;
                }
                else
                {
                    var difference = Convert.ToInt32(textBox6.Text);

                    for (int i = Convert.ToInt32(textBox6.Text); i >= promotion._Quantity; i = difference)
                    {
                        difference = i - promotion._Quantity;
                        Total += promotion._Amount;
                    }


                    if (difference != 0)
                    {
                        Total += difference * lstofProducts.FirstOrDefault(x => x.Key == textBox7.Text).Value;
                    }
                }
            }
            else
            {
                var DependentProductPromotion = lstofPromtions.FirstOrDefault(x => x.Value._DependentProduct == textBox7.Text).Value;
                if (DependentProductPromotion != null)
                {
                    var valueofComboItem = lstofPromtions.FirstOrDefault(x => x.Value._DependentProduct == DependentProductPromotion._DependentProduct).Key;
                    Total += DependentProductPromotion._Amount;
                    Total -= Convert.ToInt32(textBox6.Text) * lstofProducts.FirstOrDefault(x => x.Key == valueofComboItem).Value;
                }
                else
                {
                    Total += Convert.ToInt32(textBox6.Text) * lstofProducts.FirstOrDefault(x => x.Key == textBox7.Text).Value;
                }
            }


            textBox6.Clear();
            textBox7.Clear();


            label9.Text = Total.ToString();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex==0)
            {
                textBox8.Visible = false;
            }
            else
            {
                textBox8.Visible = true;
            }
        }

   

        private void button4_Click(object sender, EventArgs e)
        {
            purchasedItems.Clear();
            Total = 0.00;

        }
    }
}
