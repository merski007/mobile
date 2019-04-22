using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ListView
{
    public partial class MainPage : ContentPage
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

        public MainPage()
        {
            InitializeComponent();
            InitializeFlashcards(Json);
        }

        public void AddCardsToList(Flashcard card)
        {
            Flashcards.Add(card);
        }

        public void InitializeFlashcards(string json)
        {
            //clear out Flashcards
            Flashcards.Clear();

            var rootObject = JsonConvert.DeserializeObject<RootObject>(json);
            foreach (var card in rootObject.Flashcards)
            {
                AddCardsToList(card);
            }
        }

        void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null) return; // has been set to null, do not 'process' tapped event
            Debug.WriteLine("Tapped: " + e.Item);
            ((ListView)sender).SelectedItem = null; // de-select the row
        }
    }
}
