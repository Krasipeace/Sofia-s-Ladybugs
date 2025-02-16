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
            List<string> clothes = [
                "🥼", "🥼",
                "🧦", "🧦",
                "👗", "👗",
                "👒", "👒",
                "🥿", "🥿",
                "👟", "👟",
                "🧣", "🧣",
                "🧤", "🧤",
                "🧥", "🧥",
                "🥻", "🥻",
                "👕", "👕",
                "👖", "👖"
            ];

            await Navigation.PushAsync(new GamePage(clothes));
        }
    }
}
