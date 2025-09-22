using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;


// ChatGPT was use for debug
namespace Daily_Wellness_Score_App;

public partial class WellPage : ContentPage
{
    string? _gender;

    public WellPage()
    {
        InitializeComponent();
        UpdateGender();
        Calculate();
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        _gender = "Male";
        UpdateGender();
        Calculate();
    }

    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        _gender = "Female";
        UpdateGender();
        Calculate();
    }

    //function when chicked
    private void Button_Clicked(object sender, EventArgs e) => Calculate(); 

    private void ValueChanged0(object sender, ValueChangedEventArgs e) => Calculate();


    //change color in background when selected
    private void UpdateGender()
    {
        const string sel = "#4e8cff";
        const string normal = "#cccccc";
        const string fill = "#E9F1FF"; 

        if (_gender == "Male")
        {
            FrameMale.BorderColor = Color.FromArgb(sel);
            FrameMale.BackgroundColor = Color.FromArgb(fill);
            FrameFemale.BorderColor = Color.FromArgb(normal);
            FrameFemale.BackgroundColor = Colors.Transparent;
        }
        else if (_gender == "Female")
        {
            FrameFemale.BorderColor = Color.FromArgb(sel);
            FrameFemale.BackgroundColor = Color.FromArgb(fill);
            FrameMale.BorderColor = Color.FromArgb(normal);
            FrameMale.BackgroundColor = Colors.Transparent;
        }
        else
        {
            FrameMale.BorderColor = Color.FromArgb(normal);
            FrameFemale.BorderColor = Color.FromArgb(normal);
            FrameMale.BackgroundColor = Colors.Transparent;
            FrameFemale.BackgroundColor = Colors.Transparent;
        }
    }

    //Function for calculate
    private void Calculate()
    {   //Get the value for Wellpage
        double sleep = SleepSlider.Value;
        double stress = StressSlider.Value;
        double activity = ActivitySlider.Value;

        // Calculate the status
        double raw = (sleep * 8) - (stress * 5) + (activity * 0.5);
        double clamped = Math.Clamp(raw, 0, 100);
        int score = (int)Math.Round(clamped, MidpointRounding.AwayFromZero);

        string status = score >= 80 ? "Excellent"
                       : score >= 60 ? "Good"
                       : score >= 40 ? "Fair"
                       : "Poor";
        //define rec with staus and gender 
        string rec = GetRecommendation(status, _gender);
        // label text for display score and status and recommendation
        ScoreLabel.Text = $"Score: {score}";
        StatusLabel.Text = $"Status: {status}";
        RecLabel.Text = rec;    
    }

    private static string GetRecommendation(string status, string? gender)
    {
        gender = string.IsNullOrWhiteSpace(gender) ? "Male" : char.ToUpper(gender[0]) + gender.Substring(1).ToLower();

        return (status, gender) switch
        {
            ("Excellent", "Male") => "Maintain daily routine; 2–3x/week resistance training; ensure protein at each meal.",
            ("Excellent", "Female") => "Keep good habits; add yoga/Pilates; prioritize calcium and vitamin D.",
            ("Good", "Male") => "Sleep a bit earlier; +15 min light cardio/stretching; hydrate well.",
            ("Good", "Female") => "Balanced breakfast; +15 min walk; consider iron-rich foods if fatigued.",
            ("Fair", "Male") => "+1 hour sleep; reduce afternoon caffeine; light activity or gentle stroll.",
            ("Fair", "Female") => "Improve sleep regularity; reduce evening screen time; try meditation/journaling.",
            ("Poor", "Male") => "Rest; avoid strenuous exercise; hydrate; 20–30 min gentle walk.",
            ("Poor", "Female") => "Prioritize rest/self-care; short nap if possible; only light yoga/stretching.",
            _ => "Please select your gender to view personalized recommendations."
        };
    }
}
