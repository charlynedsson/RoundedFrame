using Xamarin.Forms;

namespace Plugin.RoundedFrame
{
    /// <summary>
    /// Cross RoundedFrame
    /// </summary>
    public class CrossRoundedFrame : Frame
    {
        /// <summary>
        /// BindableProperty Corner radius
        /// </summary>
        public static new readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CrossRoundedFrame), typeof(CornerRadius), typeof(Frame));

        /// <summary>
        /// BindableProperty Start color
        /// </summary>
        public static readonly BindableProperty StartColorProperty = BindableProperty.Create(nameof(CrossRoundedFrame), typeof(Color), typeof(Frame), null);

        /// <summary>
        /// BindableProperty End color
        /// </summary>
        public static readonly BindableProperty EndColorProperty = BindableProperty.Create(nameof(CrossRoundedFrame), typeof(Color), typeof(Frame), null);

        /// <summary>
        /// BindableProperty Gradient direction
        /// </summary>
        public static readonly BindableProperty GradientDirectionsProperty = BindableProperty.Create(nameof(CrossRoundedFrame), typeof(GradientDirections), typeof(Frame), GradientDirections.ToRight);

        /// <summary>
        /// Constructor
        /// </summary>
        public CrossRoundedFrame()
        {
            // MK Clearing default values (e.g. on iOS it's 5)
            base.CornerRadius = 0;
        }

        /// <summary>
        /// BindableProperty backing field of Corner radius
        /// </summary>
        public new CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        /// <summary>
        /// BindableProperty backing field of Start color
        /// </summary>
        public Color StartColor
        {
            get => (Color)GetValue(StartColorProperty);
            set => SetValue(StartColorProperty, value);
        }

        /// <summary>
        /// BindableProperty backing field of End color
        /// </summary>
        public Color EndColor
        {
            get => (Color)GetValue(EndColorProperty);
            set => SetValue(EndColorProperty, value);
        }

        /// <summary>
        /// BindableProperty backing field of Grdient direction
        /// </summary>
        public GradientDirections GradientDirection
        {
            get => (GradientDirections)GetValue(GradientDirectionsProperty);
            set => SetValue(GradientDirectionsProperty, value);
        }
    }

    /// <summary>
    /// Enum for standardized Gradient directions 
    /// </summary>
    public enum GradientDirections
    {
        ToRight,
        ToLeft,
        ToTop,
        ToBottom,
        ToTopLeft,
        ToTopRight,
        ToBottomLeft,
        ToBottomRight
    }
}
