using Xamarin.Forms;

namespace Plugin.RoundedFrame
{
    /// <summary>
    /// Cross RoundedFrame
    /// </summary>
    public class CrossRoundedFrame : Frame
    {
        /// <summary>
        /// BindableProperty
        /// </summary>
        public static new readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CrossRoundedFrame), typeof(CornerRadius), typeof(Frame));

        /// <summary>
        /// Constructor
        /// </summary>
        public CrossRoundedFrame()
        {
            // MK Clearing default values (e.g. on iOS it's 5)
            base.CornerRadius = 0;
        }

        /// <summary>
        /// BindableProperty backing field
        /// </summary>
        public new CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }        
    }
}
