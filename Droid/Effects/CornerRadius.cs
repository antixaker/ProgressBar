using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Content.Res;
using CustomProgressbar.Droid.Effects;

[assembly: ExportEffect(typeof(CornerRadius), "CornerEffect")]
namespace CustomProgressbar.Droid.Effects
{
    public class CornerRadius : PlatformEffect
    {
        protected override void OnAttached()
        {
            var view = Element as View;
            if (view != null)
            {
                view.SizeChanged += OnElementSizeChanged;
            }
        }

        protected override void OnDetached()
        {
            var view = Element as View;
            if (view != null)
            {
                view.SizeChanged -= OnElementSizeChanged;
            }
        }

        protected override void OnElementPropertyChanged(System.ComponentModel.PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
            if (args.PropertyName == View.BackgroundColorProperty.PropertyName)
            {
                DrawCorners();
            }
        }

        void OnElementSizeChanged(object sender, EventArgs e)
        {
            var elem = sender as View;
            if (elem == null)
                return;
            DrawCorners();
        }

        void DrawCorners()
        {
            var view = Element as View;
            var density = Resources.System.DisplayMetrics.Density;

            using (var gDrawable = new GradientDrawable())
            {
                gDrawable.SetColor(view.BackgroundColor.ToAndroid());

                var fx = 0d;
            
                if (ViewEffectExtentions.GetRoundCorner(Element))
                    fx = view.Height * density / 2;
                else
                    fx = ViewEffectExtentions.GetCornerRadius(view) * density;

                gDrawable.SetCornerRadius((float)fx);

                Container.Background = gDrawable;
            }
        }
    }
}

