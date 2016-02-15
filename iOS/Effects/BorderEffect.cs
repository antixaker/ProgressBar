using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using CustomProgressbar.iOS.Effects;

[assembly: ResolutionGroupName("TestEffect")]
[assembly: ExportEffect(typeof(BorderEffect), "BorderEffect")]
namespace CustomProgressbar.iOS.Effects
{
    public class BorderEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var currentView = this.Element as View;
            if (currentView != null)
            {
                currentView.SizeChanged += Renderer_Element_SizeChanged;
            }
        }

        protected override void OnDetached()
        {
            var currentView = this.Element as View;
            if (currentView != null)
            {
                currentView.SizeChanged -= Renderer_Element_SizeChanged;
            }
        }

        void Renderer_Element_SizeChanged(object sender, EventArgs e)
        {
            var currentView = sender as View;
            if (currentView == null)
                return;
            SetBorder();

        }

        void SetBorder()
        {
            var currentView = Element as View;

            var radius = 0d; 
            if (ViewEffectExtentions.GetRoundBorderedCorner(currentView))
            {
                radius = currentView.Height / 2;
            }
            else
            {
                radius = ViewEffectExtentions.GetBorderedCornerRadius(currentView);
            }

            Container.Layer.AllowsEdgeAntialiasing = true;
            Container.Layer.EdgeAntialiasingMask = CoreAnimation.CAEdgeAntialiasingMask.All;
        
            Container.Layer.BorderColor = Color.White.ToCGColor();
            Container.Layer.BorderWidth = 2;
            Container.Layer.CornerRadius = new nfloat(radius);
        }
    }
}

