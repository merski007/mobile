using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ListViewProject
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<FlashCard> FlashCards = new ObservableCollection<FlashCard>();
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

        public MainPage()
        {
            InitializeComponent();
            InitializeFlashcards(Json);
            //this.BindingContext = new[] { "a", "b", "c" };
            FlashCardList.ItemsSource = FlashCards;
        }

        public void AddCardsToList(FlashCard card)
        {
            FlashCards.Add(card);
        }

        public void InitializeFlashcards(string json)
        {
            //clear out Flashcards
            FlashCards.Clear();

            var rootObject = JsonConvert.DeserializeObject<RootObject>(json);
            foreach (var card in rootObject.FlashCards)
            {
                AddCardsToList(card);
            }
        }

        async void OnItemTappedAsync(object sender, ItemTappedEventArgs e)
        {
            if (e == null) return; // has been set to null, do not 'process' tapped event
            Debug.WriteLine("Tapped: " + e.Item);
            ((ListView)sender).SelectedItem = null; // de-select the row

            var correctAnswer = e.Item as FlashCard;
            await DisplayAlert("The element is:", correctAnswer.Answer, "Ok");
            //Debug.WriteLine("Answer: " + answer);
        }

    }
}
