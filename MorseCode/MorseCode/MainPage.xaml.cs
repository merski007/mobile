using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MorseCode
{
    public partial class MainPage : ContentPage
    {
        //Outside constructor
        IDictionary<string, string> morse = new Dictionary<string, string>();
        string message;
        //string characterOutput;

        public MainPage()
        {
            InitializeComponent();

            //Inside constructor
            morse.Add(".-", "A");
            morse.Add("-...", "B");
            morse.Add("-.-.", "C");
            morse.Add("-..", "D");
            morse.Add(".", "E");
            morse.Add("..-.", "F");
            morse.Add("--.", "G");
            morse.Add("....", "H");
            morse.Add("..", "I");
            morse.Add(".---", "J");
            morse.Add("-.-", "K");
            morse.Add(".-..", "L");
            morse.Add("--", "M");
            morse.Add("-.", "N");
            morse.Add("---", "O");
            morse.Add(".--.", "P");
            morse.Add("--.-", "Q");
            morse.Add(".-.", "R");
            morse.Add("...", "S");
            morse.Add("-", "T");
            morse.Add("..-", "U");
            morse.Add("...-", "V");
            morse.Add("-..-", "X");
            morse.Add("-.--", "Y");
            morse.Add("--..", "Z");
            morse.Add(".----", "1");
            morse.Add("..---", "2");
            morse.Add("...--", "3");
            morse.Add("....-", "4");
            morse.Add(".....", "5");
            morse.Add("-....", "6");
            morse.Add("--...", "7");
            morse.Add("---..", "8");
            morse.Add("----.", "9");
            morse.Add("-----", "0");
        }

        void OnDotButtonClicked(object sender, EventArgs e)
        {
            if (input.Text == "ERROR")
            {
                input.Text = string.Empty;
            }
            input.Text += "."; 
        }

        void OnDashButtonClicked(object sender, EventArgs e)
        {
            if (input.Text == "ERROR")
            {
                input.Text = string.Empty;
            }
            input.Text += "-";
        }

        void OnSpaceButtonClicked(object sender, EventArgs e)
        {
            // read in the screen input
            string temp = input.Text;
            // clear out screen input
            input.Text = string.Empty;

            if (temp.Length == 0)
            {
                message += " ";
            }
            else
            {
                if (morse.ContainsKey(temp))
                {
                    // convert temp to character and add to message
                    message += morse[temp];
                }
                else
                {
                    temp = string.Empty;
                    input.Text = "ERROR";
                }
            }

            // output message to screen
            output.Text = message;
        }

        //void addToMorseCodeInput(string value)
        //{
        //    morseCodeInput += value;
        //}

        //void emptyMorseCodeInput()
        //{
        //    morseCodeInput = string.Empty;
        //}

        //void addToCharacterOutput(string value)
        //{
        //    characterOutput += value;
        //}

        //void emptyCharacterOutput()
        //{
        //    characterOutput = string.Empty;
        //}

    }

}
