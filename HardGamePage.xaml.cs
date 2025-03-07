﻿namespace Sofia_s_Ladybugs;

public partial class HardGamePage : ContentPage
{
    private const int VictoryCondition = 30;
    private const string DefaultButton = "🐞";
    private bool isMatch = false;
    private int matchesFound = 0;
    private int attempts = 0;
    private Button? lastClicked;
    private readonly Dictionary<Button, string> buttonChoices = [];

    public HardGamePage(List<string> gameType)
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
        if (sender is not Button clickedButton || clickedButton.Text != DefaultButton)
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
                return;

            await Task.Delay(250);

            if (buttonChoices[clickedButton] == buttonChoices[lastClicked!])
            {
                lastClicked!.Text = clickedButton.Text = " ";
                lastClicked.BackgroundColor = Colors.Green;
                clickedButton.BackgroundColor = Colors.Green;
                matchesFound++;
            }
            else
            {
                clickedButton.Text = DefaultButton;
                lastClicked!.Text = DefaultButton;
                clickedButton.BackgroundColor = Colors.LightBlue;
                lastClicked.BackgroundColor = Colors.LightBlue;
            }

            attempts++;
            isMatch = false;
        }

        if (matchesFound == VictoryCondition)
        {
            GameButtons.IsVisible = false;
            VictoryMessage.Text = $"Браво, ти успя да събереш всички калинки след {attempts} опита.";
            VictoryMessage.IsVisible = true;

            await Task.Delay(5000);
            await Navigation.PushAsync(new MainPage());
            Navigation.RemovePage(this);
        }
    }
}
