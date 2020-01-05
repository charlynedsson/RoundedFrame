using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Plugin.RoundedFrame;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CrossRoundedFrame), typeof(Plugin.RoundedFrame.Droid.RoundedFrameImplementation))]
namespace Plugin.RoundedFrame.Droid
{
    /// <summary>
    /// Interface for RoundedFrame
    /// </summary>
    public class RoundedFrameImplementation : VisualElementRenderer<Frame>
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

            if (e.NewElement != null)
            {
                var gradientDrawable = new GradientDrawable();
                ViewGroup.SetBackground(gradientDrawable);
                UpdateCornerRadius(gradientDrawable);
                UpdateBackgroundColor(gradientDrawable);
            }
        }

        /// <summary>
        /// Property changed handler
        /// </summary>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var gradientDrawable = ViewGroup?.Background as GradientDrawable;
            if (e.PropertyName == nameof(CrossRoundedFrame) || e.PropertyName == nameof(CrossRoundedFrame.CornerRadius)
                || e.PropertyName == nameof(CrossRoundedFrame.StartColor) || e.PropertyName == nameof(CrossRoundedFrame.EndColor)
                    || e.PropertyName == nameof(CrossRoundedFrame.GradientDirection))
            {
                UpdateCornerRadius(gradientDrawable);
                UpdateBackgroundColor(gradientDrawable);
            }
        }

        /// <summary>
        /// Method triggered when changes occures on corner radius parameters
        /// </summary>
        private void UpdateCornerRadius(GradientDrawable gradientDrawable)
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

            gradientDrawable.SetCornerRadii(cornerRadii);        
        }

        /// <summary>
        /// Method triggered when changes occures on gradient parameters
        /// </summary>
        private void UpdateBackgroundColor(GradientDrawable gradientDrawable)
        {
            var customFrame = (Element as CrossRoundedFrame);
            var startColor = customFrame?.StartColor;
            var endColor = customFrame?.EndColor;
            var gradientDirection = customFrame?.GradientDirection;

            if (startColor.Value.IsDefault && endColor.Value.IsDefault)
            {
                var aColor = customFrame.BackgroundColor.IsDefault ? Xamarin.Forms.Color.Accent.ToAndroid() : customFrame.BackgroundColor.ToAndroid();
                gradientDrawable.SetColor(aColor);
                return;
            }

            int[] colors = new int[2];

            colors[0] = startColor.Value.ToAndroid();
            colors[1] = endColor.Value.ToAndroid();

            switch (gradientDirection.Value)
            {
                default:
                case GradientDirections.ToRight:
                    gradientDrawable.SetOrientation(GradientDrawable.Orientation.LeftRight);
                    break;
                case GradientDirections.ToLeft:
                    gradientDrawable.SetOrientation(GradientDrawable.Orientation.RightLeft);
                    break;
                case GradientDirections.ToTop:
                    gradientDrawable.SetOrientation(GradientDrawable.Orientation.BottomTop);
                    break;
                case GradientDirections.ToBottom:
                    gradientDrawable.SetOrientation(GradientDrawable.Orientation.TopBottom);
                    break;
                case GradientDirections.ToTopLeft:
                    gradientDrawable.SetOrientation(GradientDrawable.Orientation.BrTl);
                    break;
                case GradientDirections.ToTopRight:
                    gradientDrawable.SetOrientation(GradientDrawable.Orientation.BlTr);
                    break;
                case GradientDirections.ToBottomLeft:
                    gradientDrawable.SetOrientation(GradientDrawable.Orientation.TrBl);
                    break;
                case GradientDirections.ToBottomRight:
                    gradientDrawable.SetOrientation(GradientDrawable.Orientation.TlBr);
                    break;
            }

            gradientDrawable.SetColors(colors);
        }
    }
}