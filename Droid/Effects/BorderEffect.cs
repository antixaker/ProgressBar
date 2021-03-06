﻿using System;
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

            var density = Resources.System.DisplayMetrics.Density;

            using (var imageBitmap = Bitmap.CreateBitmap((int)((elem.Width + 2) * density), (int)((elem.Height + 1) * density), Bitmap.Config.Argb8888))
            using (var canvas = new Canvas(imageBitmap))
            using (var paint = new Paint() { Dither = false, Color = Xamarin.Forms.Color.White.ToAndroid(), AntiAlias = true })
            {
                paint.Hinting = PaintHinting.On;
                paint.Flags = PaintFlags.AntiAlias;
                paint.SetStyle(Paint.Style.Stroke);
                paint.StrokeWidth = 2 * density;

                var height = (float)elem.Height;

                canvas.DrawRoundRect(new RectF(density, density, (float)(elem.Width) * density, (float)(height) * density), height * density / 2, height * density / 2, paint);
                canvas.Density = (int)density;

                Container.Background = new BitmapDrawable(imageBitmap);
            }
        }

    }
}

