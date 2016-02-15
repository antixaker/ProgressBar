using System;
using Xamarin.Forms;
using System.Linq;

namespace CustomProgressbar
{
    public static class ViewEffects
    {
        public static readonly BindableProperty HasCornerRadiusProperty =
            BindableProperty.CreateAttached("HasCornerRadius", typeof(bool), typeof(ViewEffects), false, propertyChanged: OnHasCornerRadiusChanged);

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
            BindableProperty.CreateAttached("CornerRadius", typeof(int), typeof(ViewEffects), 0);

        public static void SetCornerRadius(BindableObject view, int size)
        {
            view.SetValue(CornerRadiusProperty, size);
        }

        public static int GetCornerRadius(BindableObject view)
        {
            return (int)view.GetValue(CornerRadiusProperty);
        }

        public static readonly BindableProperty IsRoundCornerProperty =
            BindableProperty.CreateAttached("IsRoundCorner", typeof(bool), typeof(ViewEffects), false);

        public static void SetRoundCorner(BindableObject view, bool newValue)
        {
            view.SetValue(IsRoundCornerProperty, newValue);
        }

        public static bool GetRoundCorner(BindableObject view)
        {
            return (bool)view.GetValue(IsRoundCornerProperty);
        }

    }
}

