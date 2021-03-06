﻿#region Header
// --------------------------------------------------------------------
// Project:           Transitionz - WPF Animation extensions
// Description:       Collection of markup extensions allowing WPF animations to be applied to elements
// Copyright:		  Copyright © 2013-2016 SciChart Ltd & Transitionz Contributors
// License:           Apache v2.0 License https://www.apache.org/licenses/LICENSE-2.0
// --------------------------------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Windows.Media.Animation
{
    internal static class AnimationExtensions
    {
        internal static void SetDesiredFrameRate(this Timeline animation, int? fps)
        {
#if !SILVERLIGHT
            Timeline.SetDesiredFrameRate(animation, fps);
#endif
        }

#if SILVERLIGHT
        public static void BeginAnimation(this DependencyObject obj, DependencyProperty property, Timeline animation)
        {
            var storyboard = new Storyboard();
            storyboard.Children.Add(animation);
            Storyboard.SetTarget(storyboard, obj);
            Storyboard.SetTargetProperty(storyboard, new PropertyPath(property));
            storyboard.Begin();
        }
#endif
    }
}
