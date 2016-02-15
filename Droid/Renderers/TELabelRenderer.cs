using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using CustomProgressbar.Droid.Renderers;
using CustomProgressbar.Views;
using Android.Graphics;

[assembly: ExportRenderer(typeof(TELabel), typeof(TELabelRenderer))]
namespace CustomProgressbar.Droid.Renderers
{
    public class TELabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Label> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Typeface = Typeface.CreateFromAsset(Forms.Context.Assets, "fontawesome-webfont.ttf");
            }
        }

    }
}

