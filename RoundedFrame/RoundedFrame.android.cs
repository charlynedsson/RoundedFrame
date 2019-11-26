using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Plugin.RoundedFrame;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using FrameRenderer = Xamarin.Forms.Platform.Android.AppCompat.FrameRenderer;

[assembly: ExportRenderer(typeof(CrossRoundedFrame), typeof(Plugin.RoundedFrame.Droid.RoundedFrameImplementation))]
namespace Plugin.RoundedFrame.Droid
{
    /// <summary>
    /// Interface for RoundedFrame
    /// </summary>
    public class RoundedFrameImplementation : FrameRenderer
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public RoundedFrameImplementation(Context context)
                    : base(context)
        {
        }

        /// <summary>
        /// Element changed handler
        /// </summary>
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
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
            if (Control.Background is GradientDrawable backgroundGradient)
            {
                var cornerRadius = (Element as CrossRoundedFrame)?.CornerRadius;
                if (!cornerRadius.HasValue)
                {
                    return;
                }

                var topLeftCorner = Context.ToPixels(cornerRadius.Value.TopLeft);
                var topRightCorner = Context.ToPixels(cornerRadius.Value.TopRight);
                var bottomLeftCorner = Context.ToPixels(cornerRadius.Value.BottomLeft);
                var bottomRightCorner = Context.ToPixels(cornerRadius.Value.BottomRight);

                var cornerRadii = new[]
                {
                    topLeftCorner,
                    topLeftCorner,

                    topRightCorner,
                    topRightCorner,

                    bottomRightCorner,
                    bottomRightCorner,

                    bottomLeftCorner,
                    bottomLeftCorner,
                };

                backgroundGradient.SetCornerRadii(cornerRadii);
            }
        }
    }
}