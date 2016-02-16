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
                
            using (var imageBitmap = Bitmap.CreateBitmap((int)((elem.Width + 2) * density), (int)((elem.Height + 1) * density), Bitmap.Config.Argb8888))
            using (var canvas = new Canvas(imageBitmap))
            using (var paint = new Paint() { Dither = false, Color = ViewEffectExtentions.GetBorderColor(elem).ToAndroid(), AntiAlias = true })
            {
                paint.Hinting = PaintHinting.On;
                paint.Flags = PaintFlags.AntiAlias;
                paint.SetStyle(Paint.Style.Stroke);
                paint.StrokeWidth = ViewEffectExtentions.GetBorderWidth(elem) * density;
                    
                var height = (float)elem.Height;
                var rx = 0f;
                if (ViewEffectExtentions.GetRoundBorderedCorner(elem))
                {
                    rx = height * density / 2;
                }
                else
                {
                    rx = ViewEffectExtentions.GetBorderedCornerRadius(elem);
                }
                    
                canvas.DrawRoundRect(new RectF(density, density, (float)(elem.Width) * density, (float)(height) * density), rx, rx, paint);
                canvas.Density = (int)density;
                    
                Container.Background = new BitmapDrawable(imageBitmap);
            }
        }
           
    }
}

