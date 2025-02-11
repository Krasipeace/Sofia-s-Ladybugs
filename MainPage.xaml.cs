namespace Sofia_s_Ladybugs
{
    using Microsoft.Maui.Platform;

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnTapGestureRecognizerTapped(object sender, EventArgs e)
        {
            LadybugImage1.IsVisible = !LadybugImage1.IsVisible;
            LadybugImage2.IsVisible = !LadybugImage2.IsVisible;
        }

        private async void OnNewGameButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GamePage());
        }
    }

}
