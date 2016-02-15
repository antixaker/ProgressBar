using System;
using Xamarin.Forms;
using CustomProgressbar.Views;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using CustomProgressbar.iOS.Renderers;

[assembly: ExportRenderer(typeof(TELabel), typeof(TELabelRenderer))]
namespace CustomProgressbar.iOS.Renderers
{
    public class TELabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Label> e)
        {
            base.OnElementChanged(e);

            if (Control != null && Element != null)
            {
                SetCustomFont();
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == Label.TextProperty.PropertyName)
            {
                SetCustomFont();
            }
        }

        void SetCustomFont()
        {
            Control.Font = UIFont.FromName("fontawesome", new nfloat(Element.FontSize));
        }
    }
}
