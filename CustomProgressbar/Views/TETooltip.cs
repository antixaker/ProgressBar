using System;

using Xamarin.Forms;

namespace CustomProgressbar.Views
{
    public class TETooltip : ContentView
    {
        Grid _grid;
        Label _tooltipLabel;
        Label _roundedLabel;
        Color _orangeColor = Color.FromRgb(255, 122, 0);
        TooltipPeakView _peak;
        ContentView _contentView;

        public TETooltip()
        {
            _grid = new Grid();

            _grid = new Grid(){ WidthRequest = 200, HeightRequest = 120, Padding = new Thickness(0), ColumnSpacing = 0, RowSpacing = 0 };

            _grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(3, GridUnitType.Auto) });
            _grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(18, GridUnitType.Star) });
            _grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(3, GridUnitType.Star) });

            _grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
            _grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(24, GridUnitType.Star) });

            _grid.ColumnDefinitions.Add(new ColumnDefinition{ Width = new GridLength(4, GridUnitType.Auto) });
            _grid.ColumnDefinitions.Add(new ColumnDefinition{ Width = new GridLength(10, GridUnitType.Absolute) });
            _grid.ColumnDefinitions.Add(new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Auto) });
            _grid.ColumnDefinitions.Add(new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star) });

            _peak = new TooltipPeakView(){ IsVisible = false, HorizontalOptions = LayoutOptions.Center, WidthRequest = 25 };
            _grid.Children.Add(_peak, 2, 2);
            Grid.SetRowSpan(_peak, 2);

            _tooltipLabel = new Label(){ BackgroundColor = _orangeColor, IsVisible = false };
            ViewEffectExtentions.SetHasCornerRadius(_tooltipLabel, true);
            ViewEffectExtentions.SetCornerRadius(_tooltipLabel, 5);

            _contentView = new ContentView(){ BackgroundColor = Color.Blue, WidthRequest = 60 };
            _grid.Children.Add(_contentView, 0, 0);
            Grid.SetRowSpan(_contentView, 3);

            _roundedLabel = new Label() { 
                Text = "?", 
                VerticalOptions = LayoutOptions.Center, 
                HorizontalOptions = LayoutOptions.Center, 
                BackgroundColor = Color.White, 
                TextColor = _orangeColor,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                HeightRequest = 40,
                WidthRequest = 40
            };

            ViewEffectExtentions.SetHasBorder(_roundedLabel, true);
            ViewEffectExtentions.SetRoundBorderedCorner(_roundedLabel, true);
            ViewEffectExtentions.SetBorderColor(_roundedLabel, _orangeColor);
            ViewEffectExtentions.SetBorderWidth(_roundedLabel, 2);

            var tap = new TapGestureRecognizer();
            tap.Tapped += OnLabelTapped;

            _roundedLabel.GestureRecognizers.Add(tap);

            _grid.Children.Add(_roundedLabel, 2, 1);
            Grid.SetRowSpan(_roundedLabel, 2);

            _grid.Children.Add(_tooltipLabel, 0, 4);
            Grid.SetColumnSpan(_tooltipLabel, 4);

            Content = _grid;

        }

        public static readonly BindableProperty TargetViewProperty = 
            BindableProperty.Create("TargetView", typeof(View), typeof(TETooltip), null);

        public View TargetView
        {
            get { return (View)GetValue(TargetViewProperty); }
            set { SetValue(TargetViewProperty, value); }
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == TargetViewProperty.PropertyName)
            {
                _contentView.Content = TargetView;
            }
        }

        void OnLabelTapped(object sender, EventArgs e)
        {
            IsShowingToolTip = !IsShowingToolTip;
        }

        bool _isShowingTooltip;

        bool IsShowingToolTip
        {
            get { return _isShowingTooltip; }
            set
            {
                _isShowingTooltip = value;
                _tooltipLabel.IsVisible = value;
                _peak.IsVisible = value;
                _roundedLabel.Text = value ? "x" : "?";
            }
        }
    }
}


