namespace CC.CircularSlider.iOS
{
    public static class PlatformInit
    {
        public static void Init() {
            var _ = new TouchTracking.Forms.iOS.TouchEffect();
        }
    }
}
