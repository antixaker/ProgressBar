using System;

using Xamarin.Forms;
using System.Text;

namespace CustomProgressbar.Views
{
    public class TECheckbox : ContentView
    {
        StackLayout _layout;
        Label _text;
        Label _checker;

        public TECheckbox()
        {
            _layout = new StackLayout() { Orientation = StackOrientation.Horizontal };
            _text = new Label();
            _checker = new TELabel() { 
                BackgroundColor = Color.FromHex("#FF6A00"), 
                VerticalTextAlignment = TextAlignment.Center, 
                HorizontalTextAlignment = TextAlignment.Center,
                HeightRequest = 20,
                WidthRequest = 20,
                VerticalOptions = LayoutOptions.Center,
                MinimumHeightRequest = 20,
                MinimumWidthRequest = 20
            };

            var tap = new TapGestureRecognizer();
            tap.Tapped += OnLabelTapped;

            _text.GestureRecognizers.Add(tap);
            _checker.GestureRecognizers.Add(tap);

            ViewEffectExtentions.SetHasCornerRadius(_checker, true);

            _layout.Children.Add(_checker);
            _layout.Children.Add(_text);

            Content = _layout;
        }

        void OnLabelTapped(object sender, EventArgs e)
        {
            Checked = !Checked;
        }

        public static readonly BindableProperty CheckedProperty = 
            BindableProperty.Create("Checked", typeof(bool), typeof(TECheckbox), false);

        public bool Checked
        {
            get { return (bool)GetValue(CheckedProperty); }
            set { SetValue(CheckedProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(TECheckbox), "");

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty CornerRadiusProperty = 
            BindableProperty.Create("CornerRadius", typeof(int), typeof(TECheckbox), 0);

        public int CornerRadius
        {
            get { return (int)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }


        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == Label.TextProperty.PropertyName)
            {
                _text.Text = Text;
            }
            else if (propertyName == CheckedProperty.PropertyName)
            {
                if (Checked)
                    _checker.Text = "\uf00c";
                else
                {
                    _checker.Text = string.Empty;
                }
            }
            else if (propertyName == CornerRadiusProperty.PropertyName)
            {
                ViewEffectExtentions.SetCornerRadius(_checker, CornerRadius);
            }
        }

    }
}


