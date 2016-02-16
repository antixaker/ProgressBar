using System;
using Xamarin.Forms;
using System.Linq;

namespace CustomProgressbar
{
    public static class ViewEffectExtentions
    {
        #region Corner effect

        public static readonly BindableProperty HasCornerRadiusProperty =
            BindableProperty.CreateAttached("HasCornerRadius", typeof(bool), typeof(ViewEffectExtentions), false, propertyChanged: OnHasCornerRadiusChanged);

        private static void OnHasCornerRadiusChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as View;
            if (view == null)
                return;
            var cornerEffect = Effect.Resolve("TestEffect.CornerEffect");

            var hasCorner = (bool)newValue;
            if (hasCorner)
            {
                view.Effects.Add(cornerEffect);
            }
            else
            {
                if (view.Effects.Contains(cornerEffect))
                    view.Effects.Remove(cornerEffect);
            }
        }

        public static void SetHasCornerRadius(BindableObject view, bool hasShadow)
        {
            view.SetValue(HasCornerRadiusProperty, hasShadow);
        }

        public static bool GetHasCornerRadius(BindableObject view)
        {
            return (bool)view.GetValue(HasCornerRadiusProperty);
        }

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.CreateAttached("CornerRadius", typeof(int), typeof(ViewEffectExtentions), 0);

        public static void SetCornerRadius(BindableObject view, int size)
        {
            view.SetValue(CornerRadiusProperty, size);
        }

        public static int GetCornerRadius(BindableObject view)
        {
            return (int)view.GetValue(CornerRadiusProperty);
        }

        public static readonly BindableProperty IsRoundCornerProperty =
            BindableProperty.CreateAttached("IsRoundCorner", typeof(bool), typeof(ViewEffectExtentions), false);

        public static void SetRoundCorner(BindableObject view, bool newValue)
        {
            view.SetValue(IsRoundCornerProperty, newValue);
        }

        public static bool GetRoundCorner(BindableObject view)
        {
            return (bool)view.GetValue(IsRoundCornerProperty);
        }

        #endregion

        #region Border effect

        public static readonly BindableProperty HasBorderProperty =
            BindableProperty.CreateAttached("HasBorder", typeof(bool), typeof(ViewEffectExtentions), false, propertyChanged: OnHasBorderChanged);

        private static void OnHasBorderChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as View;
            if (view == null)
                return;
            var borderEffect = Effect.Resolve("TestEffect.BorderEffect");

            var hasBorder = (bool)newValue;
            if (hasBorder)
            {
                view.Effects.Add(borderEffect);
            }
            else
            {
                if (view.Effects.Contains(borderEffect))
                    view.Effects.Remove(borderEffect);
            }
        }

        public static void SetHasBorder(BindableObject view, bool hasBorder)
        {
            view.SetValue(HasBorderProperty, hasBorder);
        }

        public static bool GetHasBorder(BindableObject view)
        {
            return (bool)view.GetValue(HasBorderProperty);
        }

        public static readonly BindableProperty IsRoundBorderedCornerProperty =
            BindableProperty.CreateAttached("IsRoundBorderedCorner", typeof(bool), typeof(ViewEffectExtentions), false);

        public static void SetRoundBorderedCorner(BindableObject view, bool newValue)
        {
            view.SetValue(IsRoundBorderedCornerProperty, newValue);
        }

        public static bool GetRoundBorderedCorner(BindableObject view)
        {
            return (bool)view.GetValue(IsRoundBorderedCornerProperty);
        }

        public static readonly BindableProperty BorderedCornerRadiusProperty =
            BindableProperty.CreateAttached("BorderedCornerRadius", typeof(int), typeof(ViewEffectExtentions), 0);

        public static void SetBorderedCornerRadius(BindableObject view, int size)
        {
            view.SetValue(BorderedCornerRadiusProperty, size);
        }

        public static int GetBorderedCornerRadius(BindableObject view)
        {
            return (int)view.GetValue(BorderedCornerRadiusProperty);
        }

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.CreateAttached("BorderColor", typeof(Color), typeof(ViewEffectExtentions), Color.Black);

        public static void SetBorderColor(BindableObject view, Color newColor)
        {
            view.SetValue(BorderColorProperty, newColor);
        }

        public static Color GetBorderColor(BindableObject view)
        {
            return (Color)view.GetValue(BorderColorProperty);
        }

        public static readonly BindableProperty BorderWidthProperty =
            BindableProperty.CreateAttached("BorderWidth", typeof(int), typeof(ViewEffectExtentions), 0);

        public static void SetBorderWidth(BindableObject view, int size)
        {
            view.SetValue(BorderWidthProperty, size);
        }

        public static int GetBorderWidth(BindableObject view)
        {
            return (int)view.GetValue(BorderWidthProperty);
        }

        #endregion
    }
}

