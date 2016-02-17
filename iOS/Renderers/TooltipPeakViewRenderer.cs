using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using CustomProgressbar.Views;
using CustomProgressbar.iOS.Renderers;
using UIKit;
using CoreGraphics;

[assembly: ExportRenderer(typeof(TooltipPeakView), typeof(TooltipPeakViewRenderer))]
namespace CustomProgressbar.iOS.Renderers
{
    public class TooltipPeakViewRenderer : BoxRenderer
    {
        public override void Draw(CoreGraphics.CGRect rect)
        {
            base.Draw(rect);

            var color = Xamarin.Forms.Color.FromHex("#FF6A00").ToCGColor();
            var cgContext = UIGraphics.GetCurrentContext();
            var rectForDrawing = rect.ToRectangle();

            cgContext.SetFillColor(color);
            cgContext.SetStrokeColor(color);

            var path = new CGPath();
            path.AddLines(new CGPoint[] {
                    new CGPoint(rectForDrawing.Left, rectForDrawing.Bottom),
                    new CGPoint(rectForDrawing.Center.X, rectForDrawing.Top), 
                    new CGPoint(rectForDrawing.Right, rectForDrawing.Bottom)
                }); 
            path.CloseSubpath();

            cgContext.AddPath(path);
            cgContext.DrawPath(CGPathDrawingMode.FillStroke);
        }
    }
}

