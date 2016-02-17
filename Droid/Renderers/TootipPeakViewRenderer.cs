using System;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using Xamarin.Forms;
using CustomProgressbar.Views;
using CustomProgressbar.Droid.Renderers;

[assembly: ExportRenderer(typeof(TooltipPeakView), typeof(TootipPeakViewRenderer))]
namespace CustomProgressbar.Droid.Renderers
{
    public class TootipPeakViewRenderer : BoxRenderer
    {
        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            using (var paint = new Paint() { Dither = false, Color = Xamarin.Forms.Color.FromHex("#FF6A00").ToAndroid(), AntiAlias = true })
            {
                paint.Hinting = PaintHinting.On;
                paint.Flags = PaintFlags.AntiAlias;
                paint.SetStyle(Paint.Style.Fill);

                var rectForDrawing = canvas.ClipBounds;

                var path = new Path();
                path.MoveTo((float)rectForDrawing.Left, (float)rectForDrawing.Bottom);
                path.LineTo((float)rectForDrawing.CenterX(), (float)rectForDrawing.Top);
                path.LineTo((float)rectForDrawing.Right, (float)rectForDrawing.Bottom);
                path.LineTo((float)rectForDrawing.Left, (float)rectForDrawing.Bottom);

                canvas.DrawPath(path, paint);
            }
        }
    }
}

