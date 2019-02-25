using System;
using System.IO;
using Xamarin.Forms;

namespace TipCalculator
{
    public partial class MainPage : ContentPage
    {
        string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tipCalculator.txt");

        public MainPage()
        {
            InitializeComponent();

            if (File.Exists(_fileName))
            {
                billAmountEditor.Text = File.ReadAllText(_fileName);
            }
        }

        void OnSaveButtonClicked(object sender, EventArgs e)
        {
            File.WriteAllText(_fileName, billAmountEditor.Text);
        }

        void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }
            billAmountEditor.Text = string.Empty;
        }

        private double BillAmount;
        private double TipPercentage;
        private double TipAmount;
        private double TotalBillAmount;

        // Add Getters and Setters for these variables

        void OnCalculateButtonClicked(object sender, EventArgs e)
        {
            // set tip and bill values
            TipPercentage = Convert.ToDouble(tipPrecentageEditor.Text) / 100;
            BillAmount = Convert.ToDouble(billAmountEditor.Text);

            // calculate the tip amount and total bill with tip
            TipAmount = BillAmount * TipPercentage;
            TotalBillAmount = BillAmount + TipAmount;

            // output to screen
            tipAmountLabel.Text = "Tip Amount: " + TipAmount.ToString() + "%";
            billAmountLabel.Text = "Total Bill: $" + TotalBillAmount.ToString();

        }


    }
}