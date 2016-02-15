using System;
using Xamarin.Forms;

namespace CustomProgressbar.Views
{
    public class ProgressBar : ContentView
    {
        Grid _grid;
        Label _textLabel;

        public ProgressBar()
        {
            var layout = new StackLayout(){ Orientation = StackOrientation.Horizontal };
            _textLabel = new Label(){ Text = "0%", TextColor = Color.White, VerticalOptions = LayoutOptions.Center };

            _grid = new Grid(){ WidthRequest = 200, HeightRequest = 10, Padding = new Thickness(0), ColumnSpacing = 0 };

            ViewEffectExtentions.SetHasBorder(_grid, true);
            ViewEffectExtentions.SetRoundBorderedCorner(_grid, true);

            _grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });

            AddColumnsToGrid();

            var roundLabelStart = GetRoundLabel();
            var roundLabelEnd = GetRoundLabel();

            _grid.Children.Add(roundLabelStart, 0, 0);
            Grid.SetColumnSpan(roundLabelStart, 2);
            _grid.Children.Add(new Label(), 1, 0);
            _grid.Children.Add(new Label(), 2, 0);
            _grid.Children.Add(new Label(), 3, 0);
            _grid.Children.Add(new Label(), 4, 0);
            _grid.Children.Add(new Label(), 5, 0);
            _grid.Children.Add(new Label(), 6, 0);
            _grid.Children.Add(roundLabelEnd, 6, 0);
            Grid.SetColumnSpan(roundLabelEnd, 2);

            layout.Children.Add(_grid);
            layout.Children.Add(_textLabel);

            Content = layout;
        }

        public int StepCount{ get; } = 4;


        public static readonly BindableProperty CurrentStepProperty = 
            BindableProperty.Create("CurrentStep", typeof(int), typeof(ProgressBar), 0);

        public int CurrentStep
        {
            get { return (int)GetValue(CurrentStepProperty); }
            set
            { 
                var valueForSet = 0;
                if (value > StepCount)
                    valueForSet = StepCount;
                else if (value < 0)
                    valueForSet = 0;
                else
                    valueForSet = value;

                SetValue(CurrentStepProperty, valueForSet); 

                FillProgressbar();
            }
        }

        void FillProgressbar()
        {
            for (int i = 0; i < StepCount; i++)
            { 
                if (i < CurrentStep)
                {
                    _grid.Children[i * 2].BackgroundColor = Color.White;
                    _grid.Children[i * 2 + 1].BackgroundColor = Color.White;
                }
                else
                {
                    _grid.Children[i * 2].BackgroundColor = Color.Transparent;
                    _grid.Children[i * 2 + 1].BackgroundColor = Color.Transparent;
                }
            }

            var pers = (float)CurrentStep / (float)StepCount * 100;
            _textLabel.Text = string.Format("{0}%", pers);
        }

        Label GetRoundLabel()
        {
            var roundLabel = new Label();
           
            ViewEffectExtentions.SetHasCornerRadius(roundLabel, true);
            ViewEffectExtentions.SetRoundCorner(roundLabel, true);

            return roundLabel;
        }

        void AddColumnsToGrid(int count = 8)
        {
            for (int i = 0; i < count; i++)
            {
                _grid.ColumnDefinitions.Add(new ColumnDefinition{ Width = new GridLength(20, GridUnitType.Star) });
            }
        }
    }
}

