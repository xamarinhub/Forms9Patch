﻿using System.Threading.Tasks;
using Xamarin.Forms;

namespace Forms9Patch.Elements.Popups.Core.Animations.Base
{
    /// <summary>
    /// Animation to fade popup's background
    /// </summary>
    public abstract class FadeBackgroundAnimation : BaseAnimation
    {
        private Color _backgroundColor;

        /// <summary>
        /// Huh?
        /// </summary>
        public bool HasBackgroundAnimation { get; set; } = true;

        /// <summary>
        /// Called before Popup appears 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="page"></param>
        public override void Preparing(View content, PopupPage page)
        {
            if (HasBackgroundAnimation && page.BackgroundImageSource == null)
            {
                _backgroundColor = page.BackgroundColor;
                page.BackgroundColor = GetColor(0);
            }
        }

        /// <summary>
        /// Called after the Popup disappears
        /// </summary>
        /// <param name="content"></param>
        /// <param name="page"></param>
        public override void Disposing(View content, PopupPage page)
        {
            if (HasBackgroundAnimation && page.BackgroundImageSource == null)
            {
                page.BackgroundColor = _backgroundColor;
            }
        }

        /// <summary>
        /// Called when animating the popup's appearance
        /// </summary>
        /// <param name="content"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public override Task Appearing(View content, PopupPage page)
        {
            if (HasBackgroundAnimation && page.BackgroundImageSource == null)
            {
                TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
                page.Animate("backgroundFade", d =>
                {
                    page.BackgroundColor = GetColor(d);
                }, 0, _backgroundColor.A, length: DurationIn, finished: (d, b) =>
                {
                    task.SetResult(true);
                });

                return task.Task;
            }

            return Task.FromResult(0);
        }

        /// <summary>
        /// Called when animating the popup's disappearance
        /// </summary>
        /// <param name="content"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public override Task Disappearing(View content, PopupPage page)
        {
            if (HasBackgroundAnimation && page.BackgroundImageSource == null)
            {
                TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();

                _backgroundColor = page.BackgroundColor;

                page.Animate("backgroundFade", d =>
                {
                    page.BackgroundColor = GetColor(d);
                }, _backgroundColor.A, 0, length: DurationOut, finished: (d, b) =>
                {
                    task.SetResult(true);
                });

                return task.Task;
            }

            return Task.FromResult(0);
        }

        private Color GetColor(double transparent)
        {
            return new Color(_backgroundColor.R, _backgroundColor.G, _backgroundColor.B, transparent);
        }
    }
}
