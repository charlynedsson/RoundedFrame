
using Plugin.RoundedFrame;
using System.ComponentModel;
using Windows.UI.Xaml.Media;
using Xamarin.Forms.Platform.UWP;
using Point = Windows.Foundation.Point;

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
                UpdateBackgroundColor();
            }
        }

        /// <summary>
        /// Property changed handler
        /// </summary>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == nameof(CrossRoundedFrame.CornerRadius) || e.PropertyName == nameof(CrossRoundedFrame.GradientDirection) ||
                 e.PropertyName == nameof(CrossRoundedFrame.StartColor) || e.PropertyName == nameof(CrossRoundedFrame.EndColor) ||
                 e.PropertyName == nameof(CrossRoundedFrame))
            {
                UpdateCornerRadius();
                UpdateBackgroundColor();
            }
        }

        /// <summary>
        /// Method triggered when changes occures to corner radius parameters
        /// </summary>
        private void UpdateCornerRadius()
        {
            var customFrame = (Element as CrossRoundedFrame);
            var cornerRadius = customFrame?.CornerRadius;

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

        /// <summary>
        /// Method triggered when changes occures to gradient parameters
        /// </summary>
        protected override void UpdateBackgroundColor()
        {
            base.UpdateBackgroundColor();
            var customFrame = (Element as CrossRoundedFrame);
            var startColor = customFrame?.StartColor;
            var endColor = customFrame?.EndColor;
            var gradientDirection = customFrame?.GradientDirection;
            var backgroundColor = customFrame?.BackgroundColor;
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush();

            if (!startColor.Value.IsDefault && !endColor.Value.IsDefault)
            {
                linearGradientBrush.GradientStops.Add(
                    new GradientStop() { Color = startColor.Value.ToWindowsColor(), Offset = 0 });
                linearGradientBrush.GradientStops.Add(
                    new GradientStop() { Color = endColor.Value.ToWindowsColor(), Offset = 1 });

                switch (gradientDirection.Value)
                {
                    default:
                    case GradientDirections.ToRight:
                        linearGradientBrush.StartPoint = new Point(0.0, 0.5);
                        linearGradientBrush.EndPoint = new Point(1.0, 0.5);
                        break;
                    case GradientDirections.ToLeft:
                        linearGradientBrush.StartPoint = new Point(1.0, 0.5);
                        linearGradientBrush.EndPoint = new Point(0.0, 0.5);
                        break;
                    case GradientDirections.ToTop:
                        linearGradientBrush.StartPoint = new Point(0.5, 1.0);
                        linearGradientBrush.EndPoint = new Point(0.5, 0.0);
                        break;
                    case GradientDirections.ToBottom:
                        linearGradientBrush.StartPoint = new Point(0.5, 0.0);
                        linearGradientBrush.EndPoint = new Point(0.5, 1.0);
                        break;
                    case GradientDirections.ToTopLeft:
                        linearGradientBrush.StartPoint = new Point(1.0, 1.0);
                        linearGradientBrush.EndPoint = new Point(0.0, 0.0);
                        break;
                    case GradientDirections.ToTopRight:
                        linearGradientBrush.StartPoint = new Point(0.0, 1.0);
                        linearGradientBrush.EndPoint = new Point(1.0, 0.0);
                        break;
                    case GradientDirections.ToBottomLeft:
                        linearGradientBrush.StartPoint = new Point(1.0, 0.0);
                        linearGradientBrush.EndPoint = new Point(0.0, 1.0);
                        break;
                    case GradientDirections.ToBottomRight:
                        linearGradientBrush.StartPoint = new Point(0.0, 0.0);
                        linearGradientBrush.EndPoint = new Point(1.0, 1.0);
                        break;
                }
            }

            if (this.Control != null)
            {
                if (!startColor.Value.IsDefault && !endColor.Value.IsDefault)
                    this.Control.Background = linearGradientBrush;
                else
                    Control.Background = backgroundColor.Value.IsDefault ? Xamarin.Forms.Color.Accent.ToBrush() : backgroundColor.Value.ToBrush();
            }
        }
    }
}