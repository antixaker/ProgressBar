using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using CustomProgressbar.iOS.Effects;

//[assembly: ResolutionGroupName("TestEffect")]
[assembly: ExportEffect(typeof(CornerRadius), "CornerEffect")]
namespace CustomProgressbar.iOS.Effects
{
    public class CornerRadius : PlatformEffect
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
            DisableCornerEffect();
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
            SetCornerRadius();
        }

        void SetCornerRadius()
        {
            Container.Layer.AllowsEdgeAntialiasing = true;
            Container.Layer.EdgeAntialiasingMask = CoreAnimation.CAEdgeAntialiasingMask.All;

            var radius = ViewEffects.GetRoundCorner(Element) ? (Element as View).Height / 2 : ViewEffects.GetCornerRadius(Element);//new nfloat(currentView.Height / 2);
            Container.Layer.CornerRadius = new nfloat(radius);
        }

        void DisableCornerEffect()
        {
            Container.Layer.CornerRadius = 0;
        }
    }
}

