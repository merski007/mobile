using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

namespace DcPersonalityQuiz
{
    public partial class QuestionsPage : ContentPage
    {
        public int QuestionCounter;
        public Question Question1 = new Question("Which super power do you have?", "Flight", "superman", "Superhuman Strength", "wonder woman", "Super Speed", "flash", "Cool Gadgets", "batman");
        public Question Question2 = new Question("What fuels your passion for super-heroing?", "Justice", "wonder woman", "Vengeance", "batman", "Protection", "superman", "Anger", "flash");
        public Question Question3 = new Question("What are you hiding?", "My dark past", "batman", "My pain", "flash", "My identity", "superman", "My strength", "wonder woman");
        public Question Question4 = new Question("Do you prefer to think a situation through carefully or act immediately?", "ACT!", "flash", "Think critical", "batman", "I overthink", "superman", "My gut", "wonder woman");
        public Question Question5 = new Question("What upsets you the fastest?", "Evil", "wonder woman", "Injustice", "superman", "Rejection", "flash", "Bullies", "batman");

        public Question[] Questions = new Question[5];

        public String[] Images = new string[5];

        public int Superman;
        public int Batman;
        public int WonderWoman;
        public int Flash;

        public QuestionsPage()
        {
            InitializeComponent();

            ShowGameButtons(false);
            ShowAnswerButtons(true);

            Images[0] = "one.jpg";
            Images[1] = "two.jpg";
            Images[2] = "three.jpg";
            Images[3] = "four.jpg";
            Images[4] = "five.jpg";

            Questions[0] = Question1;
            Questions[1] = Question2;
            Questions[2] = Question3;
            Questions[3] = Question4;
            Questions[4] = Question5;
            QuestionCounter = 0;
            GetQuestion();

            //image.Source = "https://picsum.photos/200/200/?random";
            //image.Source = "superman.png";
            //image.Source = "https://source.unsplash.com/collection/468543/200x200";

            ResetAnswers();
        }

        void OnButtonAClicked(object sender, EventArgs e)
        {
            AnswerIncrement(Questions[QuestionCounter].AnswerA[1]);
            QuestionCounter++;
            GetQuestion();
        }
        void OnButtonBClicked(object sender, EventArgs e)
        {
            AnswerIncrement(Questions[QuestionCounter].AnswerB[1]);
            QuestionCounter++;
            GetQuestion();
        }
        void OnButtonCClicked(object sender, EventArgs e)
        {
            AnswerIncrement(Questions[QuestionCounter].AnswerC[1]);
            QuestionCounter++;
            GetQuestion();
        }
        void OnButtonDClicked(object sender, EventArgs e)
        {
            AnswerIncrement(Questions[QuestionCounter].AnswerD[1]);
            QuestionCounter++;
            GetQuestion();
        }

        void GetQuestion()
        {
            if (QuestionCounter <= 4)
            {
                image.Source = Images[QuestionCounter];
                question.Text = Questions[QuestionCounter].UserQuestion;
                answerA.Text = Questions[QuestionCounter].AnswerA[0];
                answerB.Text = Questions[QuestionCounter].AnswerB[0];
                answerC.Text = Questions[QuestionCounter].AnswerC[0];
                answerD.Text = Questions[QuestionCounter].AnswerD[0];
            }
            else
            {
                question.Text = GetHero();
                ShowGameButtons(true);
                ShowAnswerButtons(false);
            }
        }

        public void AnswerIncrement(string Superhero)
        {
            if (String.Equals(Superhero, "superman"))
            {
                Superman++;
            }
            else if (String.Equals(Superhero, "batman"))
            {
                Batman++;
            }
            else if (String.Equals(Superhero, "wonder woman"))
            {
                WonderWoman++;
            }
            else if (String.Equals(Superhero, "flash"))
            {
                Flash++;
            }

        }

        public string GetHero()
        {
            var Superheros = new Dictionary<string,int>(4);
            Superheros.Add("Superman",Superman);
            Superheros.Add("Batman", Batman);
            Superheros.Add("Wonder Woman", WonderWoman);
            Superheros.Add("Flash", Flash);

            var items = from pair in Superheros
            orderby pair.Value ascending
            select pair;

            string Superhero = "";

            foreach (KeyValuePair<string, int> pair in items)
            {
                Superhero = pair.Key;
            }

            switch (Superhero)
            {
                case "Superman":
                    image.Source = "superman.png";
                    break;
                case "Batman":
                    image.Source = "batman.png";
                    break;
                case "Wonder Woman":
                    image.Source = "wonderwoman.png";
                    break;
                case "Flash":
                    image.Source = "flash.png";
                    break;
            }


            return "You are: " + Superhero;
        }

        public void ResetAnswers()
        {
            Superman = 0;
            Batman = 0;
            WonderWoman = 0;
            Flash = 0;
            QuestionCounter = 0;
        }

        public void NewGame()
        {
            ResetAnswers();
            GetQuestion();
            ShowGameButtons(false);
            ShowAnswerButtons(true);
        }

        public void ExitGame()
        {

        }

        public void OnButtonNewGameClicked(object sender, EventArgs e)
        {
            NewGame();
        }

        async void OnButtonExitGameClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        public void ShowAnswerButtons(bool value)
        {
            answerA.IsVisible = value;
            answerB.IsVisible = value;
            answerC.IsVisible = value;
            answerD.IsVisible = value;
        }

        public void ShowGameButtons(bool value)
        {
            newGame.IsVisible = value;
            exitGame.IsVisible = value;
        }

    }
}
