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
        /// Redirects the user to GamePage(characters).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnLettersChoiceButtonClicked(object sender, EventArgs e)
        {
            List<string> characters = [
                "A", "A",
                "B", "B",
                "C", "C",
                "D", "D",
                "E", "E",
                "F", "F",
                "G", "G",
                "H", "H"
            ];

            await Navigation.PushAsync(new GamePage(characters));
        }

        /// <summary>
        /// Redirects the user to GamePage(numbers).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnNumbersChoiceButtonClicked(object sender, EventArgs e)
        {
            List<string> numbers = [
                "1", "1",
                "2", "2",
                "3", "3",
                "4", "4",
                "5", "5",
                "6", "6",
                "7", "7",
                "8", "8"
            ];

            await Navigation.PushAsync(new GamePage(numbers));
        }
    }
}
