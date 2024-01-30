using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TempConvert
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Number_Temperature(object sender, EventArgs e)
        {
            Button TempratureButton = (Button)sender;
            if(lblTemprature.Text == "0")
            {
                lblTemprature.Text = "";
            }
            if(TempratureButton.Text == ".")
            {
                if (!lblTemprature.Text.Contains("."))
                {
                    lblTemprature.Text = lblTemprature.Text + TempratureButton.Text;
                }
            }
            else
            {
                lblTemprature.Text = lblTemprature.Text + TempratureButton.Text;
            }
            calculateTemp();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblTemprature.Text = "0";
            calculateTemp();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if(lblTemprature.Text.Length > 0)
            {
                lblTemprature.Text = lblTemprature.Text.Remove(lblTemprature.Text.Length - 1, 1);

            }
            if(lblTemprature.Text == "")
            {
                lblTemprature.Text = "0";
            }
            calculateTemp();
        }

        private void btnPlusMin_Click(object sender, EventArgs e)
        {
            if (lblTemprature.Text.Contains("-"))
            {
                lblTemprature.Text = lblTemprature.Text.Remove(0, 1);  //-25  
            }
            else
            {
                lblTemprature.Text = "-" + lblTemprature.Text;
            }
            calculateTemp();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cmbTemperature.Text = ("Fahrenheit");

            cmbTemperature.Items.Add("Celsius");
            cmbTemperature.Items.Add("Fahrenheit");
            cmbTemperature.Items.Add("Kelvin");


            cmbConverter.Text = ("Celsius");

            cmbConverter.Items.Add("Celsius");
            cmbConverter.Items.Add("Fahrenheit");
            cmbConverter.Items.Add("Kelvin");

            calculateTemp();
        }

        private String Converter(Double value, String tempFrom, String tempTo)
        {
            try
            {
                switch (tempFrom)
                {
                case "Celsius":
                    switch (tempTo)
                    {
                        case "Fahrenheit":
                            return String.Format("{0}\u00B0F", Math.Round(value * 9 / 5 + 32, 2).ToString());
                        case "Kelvin":
                            return String.Format("{0}K", Math.Round(value + 273.15, 2).ToString());
                        case "Celsius":
                            return String.Format("{0}\u00B0C", Math.Round(value, 2).ToString());
                    }
                    break;
                case "Fahrenheit":
                    switch (tempTo)
                    {
                        case "Celsius":
                            return String.Format("{0}\u00B0C", Math.Round((value - 32) * 5 / 9, 2).ToString());
                        case "Kelvin":
                            return String.Format("{0}K", Math.Round((((value - 32) * 5) / 9) + 273.15, 2), ToString());
                        case "Fahrenheit":
                            return String.Format("{0}\u00B0F", Math.Round(value, 2).ToString());
                    }
                    break;
                case "Kelvin":
                    switch (tempTo)
                    {
                        case "Fahrenheit":
                            return String.Format("{0}\u00B0F", Math.Round((value - 273.15) * 9 / 5 + 32, 2).ToString());
                        case "Kelvin":
                            return String.Format("{0}K", Math.Round(value, 2).ToString());
                        case "Celsius":
                            return String.Format("{0}\u00B0C", Math.Round(value - 273.15, 2).ToString());
                      
                    }
                    break;
                        
            }
                throw new ArgumentException("Invalid conversion type");
            }
            catch (Exception e)
            {
                return "Error: " + e;
            }
            
        }
        private void calculateTemp()
        {
            Double value;
            value = Double.Parse(lblTemprature.Text);

            lblConvert.Text = Converter(value, cmbTemperature.Text, cmbConverter.Text);
            if(cmbTemperature == cmbConverter)
            {
                lblDiffer.Text = cmbTemperature.Text == "Celsius"
                    ? String.Format("{0} and {1}", Converter(value, cmbTemperature.Text, "Fahrenheit"), Converter(value, cmbTemperature.Text, "Kelvin"))
                    : cmbTemperature.Text == "Fahrenheit"
                    ? String.Format("{0} and {1}", Converter(value, cmbTemperature.Text, "Celsius"), Converter(value, cmbTemperature.Text, "Kelvin"))
                    : String.Format("{0} and {1}", Converter(value, cmbTemperature.Text, "Celsius"), Converter(value, cmbTemperature.Text, "Fahrenheit"));
            }
            else if(cmbTemperature.Text == "Celsius")
            {
                lblDiffer.Text = cmbConverter.Text == "Fahrenheit"
                    ? String.Format("{0}", Converter(value, cmbTemperature.Text, "Kelvin"))
                    : String.Format("{0}", Converter(value, cmbTemperature.Text, "Fahrenheit"));
            }
            else if(cmbTemperature.Text == "Fahrenheit")
            {
                lblDiffer.Text = cmbConverter.Text == "Celsius"
                    ? String.Format("{0}", Converter(value, cmbTemperature.Text, "Kelvin"))
                    : String.Format("{0}", Converter(value, cmbTemperature.Text, "Celsius"));
            }
            else
            {
                lblDiffer.Text = cmbConverter.Text == "Celsius"
                    ? String.Format("{0}", Converter(value, cmbTemperature.Text, "Fahrenheit"))
                    : String.Format("{0}", Converter(value, cmbTemperature.Text, "Celsius"));
            }
        }
    }
}
