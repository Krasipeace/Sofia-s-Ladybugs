namespace Sofia_s_Ladybugs;

public partial class GamePage : ContentPage
{
    private const int VictoryCondition = 12;
    private const string DefaultButton = "🐞";
    private bool isMatch = false;
    private int matchesFound = 0;
    private Button? lastClicked;
    private readonly Dictionary<Button, string> buttonChoices = [];

    public GamePage(List<string> gameType)
    {
        InitializeComponent();

        GameButtons.IsVisible = true;
        VictoryMessage.IsVisible = false;

        foreach (var button in GameButtons.Children.OfType<Button>())
        {
            int index = Random.Shared.Next(gameType.Count);
            string choice = gameType[index];
            buttonChoices[button] = choice;
            button.Text = DefaultButton;
            gameType.RemoveAt(index);
        }
    }

    /// <summary>
    /// Handles the button click event to reveal clickedButton and check for matches.
    /// </summary>
    /// <param name="sender">The button that was clicked.</param>
    /// <param name="e">Event arguments.</param>
    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (sender is Button clickedButton)
        {
            if (clickedButton.Text != DefaultButton)
                return;

            clickedButton.Text = buttonChoices[clickedButton];

            if (!isMatch)
            {
                lastClicked = clickedButton;
                isMatch = true;
            }
            else
            {
                if (clickedButton == lastClicked)
                    return; // Same button clicked twice

                if (buttonChoices[clickedButton] == buttonChoices[lastClicked!])
                {
                    await Task.Delay(200);
                    lastClicked!.Text = clickedButton.Text = " ";
                    lastClicked.BackgroundColor = Colors.Green;
                    clickedButton.BackgroundColor = Colors.Green;
                    matchesFound++;
                }
                else
                {
                    await Task.Delay(200);
                    clickedButton.Text = DefaultButton;
                    lastClicked!.Text = DefaultButton;
                    clickedButton.BackgroundColor = Colors.LightBlue;
                    lastClicked.BackgroundColor = Colors.LightBlue;
                }

                isMatch = false;
            }

            if (matchesFound == VictoryCondition)
            {
                GameButtons.IsVisible = false;
                VictoryMessage.IsVisible = true;

                await Task.Delay(5000);
                await Navigation.PushAsync(new MainPage());
                Navigation.RemovePage(this);
            }
        }
    }
}
