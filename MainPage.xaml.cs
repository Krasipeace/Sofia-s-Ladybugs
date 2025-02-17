namespace Sofia_s_Ladybugs
{
    using Microsoft.Maui.Platform;

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Toggles the visibility of the ladybug images.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTapGestureRecognizerTappedMainPageImage(object sender, EventArgs e)
        {
            LadybugImage1.IsVisible = !LadybugImage1.IsVisible;
            LadybugImage2.IsVisible = !LadybugImage2.IsVisible;
        }

        /// <summary>
        /// Redirects the user to GamePage(clothes).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnClothesChoiceButtonClicked(object sender, EventArgs e)
        {
            var clothes = GetEmojiList(["🥼", "🧦", "👗", "👒", "🥿", "👟", "🧣", "🧤", "🧥", "🥻",  "👕", "👖"]);

            await Navigation.PushAsync(new GamePage(clothes));
        }

        /// <summary>
        /// Redirects the user to GamePage(animals).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnAnimalsChoiceButtonClicked(object sender, EventArgs e)
        {
            var animals = GetEmojiList(["🐶", "🐱", "🐭", "🐹", "🐰", "🦊", "🐻", "🐼", "🐨", "🐯", "🦁", "🐮"]);

            await Navigation.PushAsync(new GamePage(animals));
        }

        /// <summary>
        /// Redirects the user to GamePage(fruits).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnFruitsChoiceButtonClicked(object sender, EventArgs e)
        {
            var fruits = GetEmojiList(["🍎", "🍌", "🍇", "🍉", "🍍", "🍊", "🍓", "🍑", "🍒", "🍈", "🍋", "🥭"]);

            await Navigation.PushAsync(new GamePage(fruits));
        }

        /// <summary>
        /// Redirects the user to GamePage(vegetables).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnVegetablesChoiceButtonClicked(object sender, EventArgs e)
        {
            var vegetables = GetEmojiList(["🥦", "🥕", "🌽", "🍆", "🥒", "🧄", "🧅", "🍅", "🥔", "🌶", "🥬", "🍠"]);

            await Navigation.PushAsync(new GamePage(vegetables));
        }

        /// <summary>
        /// Redirects the user to GamePage(music).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnMusicChoiceButtonClicked(object sender, EventArgs e)
        {
            var music = GetEmojiList(["🎤", "🎧", "🎼", "🥁", "🎹", "🎷", "🎺", "🎸", "🎻", "🎙", "📻", "💿"]);

            await Navigation.PushAsync(new GamePage(music));
        }

        /// <summary>
        /// Redirects the user to MediumGamePage(buildings).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnBuildingsChoiceButtonClicked(object sender, EventArgs e)
        {
            var buildings = GetEmojiList(["🏠", "🏭", "🏗", "🏘", "🏢", "🏬", "🏣", "🏤", "🏥", "🏦", "🏪", "🏫", "🏛", "⛪️", "🕌", "🕍", "🛕", "🏡", "🏯", "🏰" ]);

            await Navigation.PushAsync(new MediumGamePage(buildings));
        }

        /// <summary>
        /// Redirects the user to MediumGamePage(foods).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnFoodsChoiceButtonClicked(object sender, EventArgs e)
        {
            var foods = GetEmojiList(["🍞", "🧀", "🍳", "🌭", "🍔", "🍕", "🍣", "🥣", "🍩", "🍿", "🍫", "🍬", "🍭", "🍮", "🥮", "🍨", "🍰", "🧆", "🍯", "🥗"]);

            await Navigation.PushAsync(new MediumGamePage(foods));
        }

        /// <summary>
        /// Returns a list of emojis, each repeated twice.
        /// </summary>
        /// <param name="emojis">Array of emojis to be repeated.</param>
        /// <returns>List of repeated emojis.</returns>
        private static List<string> GetEmojiList(string[] emojis)
        {
            var emojiList = new List<string>();

            foreach (var emoji in emojis)
            {
                emojiList.Add(emoji);
                emojiList.Add(emoji);
            }

            return emojiList;
        }
    }
}
