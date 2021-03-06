﻿using System;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Media.Animation;

namespace BlueHour.WP8.Utils
{
    public class LoadedBehavior : Behavior<FrameworkElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            CreateStoryboard().Begin();
        }

        private Storyboard CreateStoryboard()
        {
            Storyboard sb = new Storyboard();
            DoubleAnimation animation = new DoubleAnimation
            {
                Duration = TimeSpan.FromMilliseconds(1000),
                From = -90,
                To = 0,
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("(UIElement.Projection).(PlaneProjection.RotationY)"));

            sb.Children.Add(animation);

            animation = new DoubleAnimation
            {
                Duration = TimeSpan.FromMilliseconds(1000),
                From = 0,
                To = 1,
                EasingFunction =
                    new CubicEase() { EasingMode = EasingMode.EaseOut }
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath(UIElement.OpacityProperty));

            sb.Children.Add(animation);
            Storyboard.SetTarget(sb, AssociatedObject);
            return sb;
        }
    }
}
