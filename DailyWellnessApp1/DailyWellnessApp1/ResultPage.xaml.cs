namespace DailyWellnessApp1;
//debug using ChatGPT

//define score status and gender 
public sealed class WellnessResult
{
    public double Score { get; set; }
    public string Status { get; set; } = "Unknown";
    public Gender Gender { get; set; } = Gender.Unknown;
}

//partial indicates that it is combined with the class generated from the XAML file.
public partial class ResultPage : ContentPage
{//_input stores input data passed from Page1 (sleep, stress, exercise, gender).
    private readonly WellnessInput _input;
    //_result stores the Wellness results calculated on this page.
    private WellnessResult _result = new();

    public ResultPage(WellnessInput input)
    {
        InitializeComponent();
        _input = input;//get the input data to _input
    }

    //determent the result
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _result = CalculateResult(_input);
        ScoreLabel.Text = $"{_result.Score:F0}";
        StatusLabel.Text = _result.Status;
    }
    // function for the score
    WellnessResult CalculateResult(WellnessInput input)
    {
        // get in put
        double sleep = input.SleepHours;
        double stress = input.StressLevel;
        double activity = input.ActivityMinutes;

        // score
        double raw = (sleep * 8) - (stress * 5) + (activity * 0.5);
        double clamped = Math.Clamp(raw, 0, 100);
        int score = (int)Math.Round(clamped, MidpointRounding.AwayFromZero);

        // status
        string status = score >= 80 ? "Excellent"
                     : score >= 60 ? "Good"
                     : score >= 40 ? "Fair"
                     : "Poor";

        return new WellnessResult
        {
            Score = score,
            Status = status,
            Gender = input.Gender
        };
    }

    //pop to next session
    async void OnRecommendationsClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new RecommendationsPage(_result));
    }

    // This is optional
    async void OnBackToInputsClicked(object? sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    
}
