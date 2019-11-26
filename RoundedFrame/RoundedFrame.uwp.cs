using System;
using Windows.UI.Xaml;
using Xamarin.Forms.Platform.UWP;
using Xamarin.Forms;
using Windows.UI.Xaml.Media;
using System.ComponentModel;
using Plugin.RoundedFrame;

[assembly: ExportRenderer(typeof(CrossRoundedFrame), typeof(Plugin.RoundedFrame.UWP.RoundedFrameImplementation))]
namespace Plugin.RoundedFrame.UWP
{
    /// <summary>
    /// Interface for RoundedFrame
    /// </summary>
    public class RoundedFrameImplementation : FrameRenderer
    {
        /// <summary>
        /// Element changed handler
        /// </summary>
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Frame> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null && Control != null)
            {
                UpdateCornerRadius();
            }
        }

        /// <summary>
        /// Property changed handler
        /// </summary>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == nameof(CrossRoundedFrame.CornerRadius) ||
                e.PropertyName == nameof(CrossRoundedFrame))
            {
                UpdateCornerRadius();
            }
        }

        /// <summary>
        /// Method triggered when changes occures
        /// </summary>
        private void UpdateCornerRadius()
        {
            var cornerRadius = (Element as CrossRoundedFrame)?.CornerRadius;
            if (!cornerRadius.HasValue)
            {
                return;
            }

            int topLeft = (int)cornerRadius.Value.TopLeft;
            int topRight = (int)cornerRadius.Value.TopRight;
            int bottomRight = (int)cornerRadius.Value.BottomRight;
            int bottomLeft = (int)cornerRadius.Value.BottomLeft;

            this.Control.CornerRadius = new Windows.UI.Xaml.CornerRadius(topLeft, topRight, bottomRight, bottomLeft);
        }
    }
}