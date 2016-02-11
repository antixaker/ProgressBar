using System;
using Xamarin.Forms;

namespace CustomProgressbar.Views
{
    public class ProgressBar : ContentView
    {
        StackLayout _layout;
        Label _progressLabel;
        Label _textLabel;

        public ProgressBar()
        {
            _layout = new StackLayout();
            _progressLabel = new Label(){ BackgroundColor = Color.FromHex("#FF6A00"), WidthRequest = 200, HeightRequest = 50 };
            _progressLabel.Effects.Add(Effect.Resolve("TestEffect.CornerEffect"));
            _textLabel = new Label(){ Text = "%", TextColor = Color.White, VerticalOptions = LayoutOptions.Center };
            _layout.Children.Add(_progressLabel);
            _layout.Children.Add(_textLabel);
            _layout.Orientation = StackOrientation.Horizontal;

            Content = _layout;

        }

        public int StepCount{ get; set; }

        public int CurrentStep { get; set; }

        public void Increment()
        {
            if (CurrentStep < StepCount)
            {
                CurrentStep++;
            }
        }

        public void Decrement()
        {
            if (CurrentStep > 0)
            {
                CurrentStep--;
            }
        }

    }
}

