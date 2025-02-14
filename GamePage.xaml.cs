namespace Sofia_s_Ladybugs;

public partial class GamePage : ContentPage
{
    private bool findingMatch = false;
    private int matchesFound = 0;
    private Button? lastClicked;
    private readonly Dictionary<Button, string> buttonChoices = [];
    private readonly string defaultButton = "🐞";

    public GamePage(List<string> gameType)
    {
        InitializeComponent();

        GameButtons.IsVisible = true;

        foreach (var button in GameButtons.Children.OfType<Button>())
        {
            int index = Random.Shared.Next(gameType.Count);
            string choice = gameType[index];
            buttonChoices[button] = choice;
            button.Text = defaultButton; 
            gameType.RemoveAt(index);
        }
    }

    /// <summary>
    /// Handles the button click event to reveal objType and check for matches.
    /// </summary>
    /// <param name="sender">The button that was clicked.</param>
    /// <param name="e">Event arguments.</param>
    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (sender is Button clickedButton)
        {
            if (clickedButton.Text != defaultButton)
                return; 

            clickedButton.Text = buttonChoices[clickedButton]; 

            if (!findingMatch)
            {
                lastClicked = clickedButton;
                findingMatch = true;
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
                    clickedButton.Text = defaultButton;
                    lastClicked!.Text = defaultButton;
                    clickedButton.BackgroundColor = Colors.LightBlue;
                    lastClicked.BackgroundColor = Colors.LightBlue;
                }
                findingMatch = false;
            }

            if (matchesFound == 8)
            {
                await Navigation.PushAsync(new MainPage());
                Navigation.RemovePage(this);
            }
        }
    }
}
