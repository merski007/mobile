using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Data;
using FlashCards.Model;
using System.Collections;

namespace FlashCards
{
    public partial class QuestionsPage : ContentPage
    {
        private IList<Flashcard> Flashcards = new List<Flashcard>();

        public string Json = @"{'Flashcards': [
                                    {
                                        'Question': 'Name the element',
                                        'Answer': 'Oxygen',
                                        'IsCorrect': false,
                                        'ImageName': 'oxygen.png'
                                    },
                                    {
                                        'Question': 'Name the element',
                                        'Answer': 'Fluorine',
                                        'IsCorrect': false,
                                        'ImageName': 'fluorine.png'
                                    },
                                    {
                                        'Question': 'Name the element',
                                        'Answer': 'Helium',
                                        'IsCorrect': false,
                                        'ImageName': 'helium.png'
                                    },
                                    {
                                        'Question': 'Name the element',
                                        'Answer': 'Hydrogen',
                                        'IsCorrect': false,
                                        'ImageName': 'hydrogen.png'
                                    },
                                    {
                                        'Question': 'Name the element',
                                        'Answer': 'Neon',
                                        'IsCorrect': false,
                                        'ImageName': 'neon.png'
                                    },
                                    {
                                        'Question': 'Name the element',
                                        'Answer': 'Nitrogen',
                                        'IsCorrect': false,
                                        'ImageName': 'nitrogen.png'
                                    }
                                ]
                            }";

        public int counter;

        public bool QuestionVisible;
        public bool AnswerVisible;

        public QuestionsPage()
        {
            InitializeComponent();

            //App.Database.PopulateDatabase();

            counter = 0;

            InitializeFlashcards(Json);

            OnGameStartVisibility(true, false);

            GetQuestion();
        }

        public void AddCardsToList(Flashcard card)
        {
            Flashcards.Add(card);
        }

        public void InitializeFlashcards(string json)
        {
            //clear out Flashcards
            Flashcards.Clear();

            //commenting out to try and populate via database
            //var rootObject = JsonConvert.DeserializeObject<RootObject>(json);
            //foreach(var card in rootObject.Flashcards)
            //{
            //    AddCardsToList(card);
            //}

            Flashcards = App.Database.GetItemsAsync().Result;


        }

        public void SetIncorrectFlashcards()
        {
            Flashcards = Flashcards.Where(c => !c.IsCorrect).ToList();
        }

        public void ResetGame()
        {
            counter = 0;
            InitializeFlashcards(Json);
            GetQuestion();
            OnGameStartVisibility(true, false);
        }

        public void ContinueGame()
        {
            counter = 0;
            SetIncorrectFlashcards();
            GetQuestion();
            OnGameStartVisibility(true, false);
        }

        public void GetQuestion()
        {
            if (counter < Flashcards.Count)
            {
                OnQuestionVisiblity(true, false);

                Flashcard tempObj = Flashcards[counter];
                image.Source = tempObj.ImageName;
                question.Text = tempObj.Question;
                answer.Text = tempObj.Answer;
            }
            else
            {
                OnGameSummaryVisibility(true, false);

                correctAnswerCount.Text = "Correct: " + Flashcards.Count(x => x.IsCorrect).ToString();
                wrongAnswerCount.Text = "Wrong: " + Flashcards.Count(x => !x.IsCorrect).ToString();
            }

        }

        public void OnSwiped(object sender, EventArgs e)
        {
            OnAnswerVisiblity(true, false);
        }

        public void AnswerVisibility(bool value)
        {
            answer.IsVisible = value;
        }

        public void QuestionVisibility(bool value)
        {
            question.IsVisible = value;
        }

        public void ImageVisibility(bool value)
        {
            image.IsVisible = value;
        }

        public void SwipeBoxVisibilty(bool value)
        {
            swipeBox.IsVisible = value;
        }

        public void CorrectAnswerVisiblity(bool value)
        {
            correctAnswerCount.IsVisible = value;
        }

        public void WrongAnswerVisiblity(bool value)
        {
            wrongAnswerCount.IsVisible = value;
        }

        public void GameButtonsVisibility(bool value)
        {
            correct.IsVisible = value;
            wrong.IsVisible = value;
        }

        public void NewGameButtonsVisibility(bool value)
        {
            continueGame.IsVisible = value;
            startGameOver.IsVisible = value;
        }

        public void OnGameStartVisibility(bool show, bool hide)
        {
            // show these game elements
            ImageVisibility(show);
            QuestionVisibility(show);
            SwipeBoxVisibilty(show);

            // hide these game elements
            AnswerVisibility(hide);
            GameButtonsVisibility(hide);
            NewGameButtonsVisibility(hide);
            CorrectAnswerVisiblity(hide);
            WrongAnswerVisiblity(hide);
        }

        public void OnQuestionVisiblity(bool show, bool hide)
        {
            // show these game elements
            ImageVisibility(show);
            QuestionVisibility(show);
            SwipeBoxVisibilty(show);

            // hide these game elements
            GameButtonsVisibility(hide);
            AnswerVisibility(hide);
        }

        public void OnAnswerVisiblity(bool show, bool hide)
        {
            // hide these game elements
            ImageVisibility(hide);
            QuestionVisibility(hide);
            SwipeBoxVisibilty(hide);

            // show these game elements
            GameButtonsVisibility(show);
            AnswerVisibility(show);
        }

        public void OnGameSummaryVisibility(bool show, bool hide)
        {
            // hide these game elements
            ImageVisibility(hide);
            QuestionVisibility(hide);
            SwipeBoxVisibilty(hide);
            AnswerVisibility(hide);
            GameButtonsVisibility(hide);

            // show these game elements
            NewGameButtonsVisibility(show);
            CorrectAnswerVisiblity(show);
            WrongAnswerVisiblity(show);
        }

        public void OnButtonCorrectClicked(object sender, EventArgs e)
        {
            Flashcards[counter].IsCorrect = true;
            counter++;
            GetQuestion();
        }

        public void OnButtonWrongClicked(object sender, EventArgs e)
        {
            Flashcards[counter].IsCorrect = false;
            counter++;
            GetQuestion();
        }

        public void OnButtonContinueGameClicked(object sender, EventArgs e)
        {
            ContinueGame();
        }

        public void OnButtonStartGameOverClicked(object sender, EventArgs e)
        {
            ResetGame();
        }
    }
}
