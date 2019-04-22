using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ListViewProject
{
    public partial class PickerItemsSourcePage : ContentPage
    {
        private List<FlashCard> FlashCards = new List<FlashCard>();
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
        public PickerItemsSourcePage()
        {
            InitializeComponent();
            InitializeFlashcards(Json);
            //this.BindingContext = new[] { "a", "b", "c" };
            picker.ItemsSource = FlashCards;
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            //var pick = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                //answerImage.FlashCards[selectedIndex];
                image.Source = FlashCards[selectedIndex].ImageName;
            }
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
    }
}
