using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Content.Res;
using CustomProgressbar.Droid.Effects;

//[assembly: ResolutionGroupName("TestEffect")]
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
                RedRaw();
            }
        }

        void OnElementSizeChanged(object sender, EventArgs e)
        {
            var elem = sender as View;
            if (elem == null)
                return;
            RedRaw();
        }

        void RedRaw()
        {
            var view = Element as View;
            var density = Resources.System.DisplayMetrics.Density;
            
            using (var imageBitmap = Bitmap.CreateBitmap((int)(view.Width * density), (int)(view.Height * density), Bitmap.Config.Argb8888))
            using (var canvas = new Canvas(imageBitmap))
            using (var paint = new Paint() { Dither = false, Color = view.BackgroundColor.ToAndroid(), AntiAlias = true })
            {
                paint.Hinting = PaintHinting.On;
                paint.Flags = PaintFlags.AntiAlias;
                
                var height = (float)view.Height;
                var fx = 0f;

                if (ViewEffects.GetRoundCorner(Element))
                    fx = height * density / 2;
                else
                    fx = ViewEffects.GetCornerRadius(view) * density;

                canvas.DrawRoundRect(new RectF(0, 0, (float)view.Width * density, height * density), fx, fx, paint);
                    
                canvas.Density = (int)density;
                
                Container.Background = new BitmapDrawable(imageBitmap);
            }
            
        }
    }
}

