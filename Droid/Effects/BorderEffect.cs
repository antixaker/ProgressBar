using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using CustomProgressbar.Droid.Effects;

[assembly: ResolutionGroupName("TestEffect")]
[assembly: ExportEffect(typeof(BorderEffect), "BorderEffect")]
namespace CustomProgressbar.Droid.Effects
{
    public class BorderEffect : PlatformEffect
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

        void OnElementSizeChanged(object sender, EventArgs e)
        {
            var elem = sender as View;
            if (elem == null)
                return;
            SetBorder();
        }

        void SetBorder()
        {
            var elem = Element as View;
            var density = Resources.System.DisplayMetrics.Density;
                
            using (var gDrawable = new GradientDrawable())
            {
                var fx = 0d;

                if (ViewEffectExtentions.GetRoundBorderedCorner(elem))
                    fx = elem.Height * density / 2;
                else
                    fx = ViewEffectExtentions.GetBorderedCornerRadius(elem) * density;

                gDrawable.SetCornerRadius((float)fx);
                gDrawable.SetStroke((int)(ViewEffectExtentions.GetBorderWidth(elem) * density), ViewEffectExtentions.GetBorderColor(elem).ToAndroid());

                Container.Background = gDrawable;
            }
        }
    }
}

