namespace Sofia_s_Ladybugs;

public partial class GamePage : ContentPage
{
    private bool findingMatch = false;
    private int matchesFound = 0;
    private Button? lastClicked;
    private readonly Dictionary<Button, string> buttonLetters = [];

    public GamePage()
    {
        InitializeComponent();

        GameButtons.IsVisible = true;
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

        foreach (var button in GameButtons.Children.OfType<Button>())
        {
            int index = Random.Shared.Next(characters.Count);
            string letter = characters[index];
            buttonLetters[button] = letter;
            button.Text = ""; 
            characters.RemoveAt(index);
        }
    }

    /// <summary>
    /// Handles the button click event to reveal letters and check for matches.
    /// </summary>
    /// <param name="sender">The button that was clicked.</param>
    /// <param name="e">Event arguments.</param>
    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (sender is Button clickedButton)
        {
            if (clickedButton.Text != "")
                return; // Ignore clicks on matched buttons

            clickedButton.Text = buttonLetters[clickedButton]; // Reveal the letter

            if (!findingMatch)
            {
                // First click
                lastClicked = clickedButton;
                findingMatch = true;
            }
            else
            {
                // Second click
                if (clickedButton == lastClicked)
                    return; // Same button clicked twice

                if (buttonLetters[clickedButton] == buttonLetters[lastClicked!])
                {
                    // Match found
                    await Task.Delay(200);
                    lastClicked!.Text = clickedButton.Text = " ";
                    lastClicked.BackgroundColor = Colors.Green;
                    clickedButton.BackgroundColor = Colors.Green;
                    matchesFound++;
                }
                else
                {
                    // No match
                    await Task.Delay(200);
                    clickedButton.Text = "";
                    lastClicked!.Text = "";
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
