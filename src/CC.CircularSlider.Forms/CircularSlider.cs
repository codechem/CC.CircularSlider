using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;

using Xamarin.Forms;

namespace CC
{
    public class CircularSlider : SKCanvasView
    {
        bool hasTouch = false;
        double progress = 0;
        double progressArc = 0;

        float touchX = -1;
        float touchY = -1;

        private SKPaint progressPaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = Color.Red.ToSKColor(),
            StrokeWidth = 10,
            IsAntialias = true
        };

        private SKPaint knobPaint = new SKPaint
        {
            Style = SKPaintStyle.StrokeAndFill,
            Color = Color.Red.ToSKColor(),
            StrokeWidth = 10,
            IsAntialias = true
        };

        private SKPaint trackPaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = Color.Gray.ToSKColor(),
            StrokeWidth = 5,
            IsAntialias = true
        };

        private double CalculatedValue => Minimum + Maximum * progress;

        public static readonly BindableProperty TrackColorProperty = BindableProperty.Create(nameof(TrackColor),
            typeof(Color), typeof(CircularSlider), Color.Red, BindingMode.OneWay, null, (BindableObject bindable, object oldValue, object newValue) =>
            {
                var instance = (CircularSlider)bindable;
                instance.trackPaint.Color = ((Color)newValue).ToSKColor();
            });

        public static readonly BindableProperty KnobColorProperty = BindableProperty.Create(nameof(KnobColor),
            typeof(Color), typeof(CircularSlider), Color.Red, BindingMode.OneWay, null, (BindableObject bindable, object oldValue, object newValue) =>
            {
                var instance = (CircularSlider)bindable;
                instance.knobPaint.Color = ((Color)newValue).ToSKColor();
            });

        public static readonly BindableProperty TrackProgressColorProperty = BindableProperty.Create(nameof(TrackProgressColor),
            typeof(Color), typeof(CircularSlider), Color.Red, BindingMode.OneWay, null, (BindableObject bindable, object oldValue, object newValue) =>
            {
                var instance = (CircularSlider)bindable;
                instance.progressPaint.Color = ((Color)newValue).ToSKColor();
            });

        public static readonly BindableProperty TrackWidthProperty = BindableProperty.Create(nameof(TrackWidth),
            typeof(double), typeof(CircularSlider), 5.0, BindingMode.OneWay, null, BindablePropertyChanged);

        public static readonly BindableProperty TrackProgressWidthProperty = BindableProperty.Create(nameof(TrackProgressWidth),
            typeof(double), typeof(CircularSlider), 10.0, BindingMode.OneWay, null, BindablePropertyChanged);

        public static readonly BindableProperty KnobWidthProperty = BindableProperty.Create(nameof(KnobWidth),
            typeof(double), typeof(CircularSlider), 20.0, BindingMode.OneWay, null, BindablePropertyChanged);

        public static readonly BindableProperty StartProperty = BindableProperty.Create(nameof(Start),
            typeof(double), typeof(CircularSlider), 90.0, BindingMode.OneWay, null, BindablePropertyChanged);

        public static readonly BindableProperty MinimumProperty = BindableProperty.Create(nameof(Minimum),
            typeof(double), typeof(CircularSlider), 0.0, BindingMode.OneWay, null, BindablePropertyChanged);

        public static readonly BindableProperty MaximumProperty = BindableProperty.Create(nameof(Maximum),
            typeof(double), typeof(CircularSlider), 1.0, BindingMode.OneWay, null, BindablePropertyChanged);

        public static readonly BindableProperty ArcProperty = BindableProperty.Create(nameof(Arc),
            typeof(double), typeof(CircularSlider), 360.0, BindingMode.OneWay, null, BindablePropertyChanged);

        public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value),
            typeof(double), typeof(CircularSlider), 0.0, BindingMode.TwoWay, null, (obj, oldVal, newVal) => {
                BindablePropertyChanged(obj, oldVal, newVal);
                if (oldVal != newVal)
                {
                    var instance = (CircularSlider)obj;
                    instance.OnValueChanged?.Invoke(instance, new ValueChangedEventArgs((double)oldVal, (double)newVal));
                }
            });

        public static readonly BindableProperty PaddingAroundProperty = BindableProperty.Create(nameof(PaddingAround),
            typeof(double), typeof(CircularSlider), 25.0);

        public delegate void ValueChangedHandler(object sender, ValueChangedEventArgs e);
        public event ValueChangedHandler OnValueChanged;

        public double Start
        {
            get => (double)GetValue(StartProperty);
            set => SetValue(StartProperty, (double)value);
        }

        public double Arc
        {
            get => (double)GetValue(ArcProperty);
            set => SetValue(ArcProperty, (double)value);
        }

        public double Minimum
        {
            get => (double)GetValue(MinimumProperty);
            set => SetValue(MinimumProperty, (double)value);
        }

        public double Maximum
        {
            get => (double)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, (double)value);
        }

        public double Value
        {
            get => (double)GetValue(ValueProperty);
            set {
                var old = Value;
                SetValue(ValueProperty, (double)value);
                if (old != Value)
                {
                    OnValueChanged?.Invoke(this, new ValueChangedEventArgs(old, Value));
                }
                BindablePropertyChanged(this, old, value);
            }
        }

        public double PaddingAround
        {
            get => (double)GetValue(PaddingAroundProperty);
            set => SetValue(PaddingAroundProperty, (double)value);
        }

        public double KnobWidth
        {
            get => (double)GetValue(KnobWidthProperty);
            set => SetValue(KnobWidthProperty, (double)value);
        }

        public double TrackWidth
        {
            get => (double)GetValue(TrackWidthProperty);
            set => SetValue(TrackWidthProperty, (double)value);
        }

        public double TrackProgressWidth
        {
            get => (double)GetValue(TrackProgressWidthProperty);
            set => SetValue(TrackProgressWidthProperty, (double)value);
        }

        public Color TrackProgressColor
        {
            get => (Color)GetValue(TrackProgressColorProperty);
            set => SetValue(TrackProgressColorProperty, (Color)value);
        }

        public Color TrackColor
        {
            get => (Color)GetValue(TrackColorProperty);
            set => SetValue(TrackColorProperty, (Color)value);
        }

        public Color KnobColor
        {
            get => (Color)GetValue(KnobColorProperty);
            set => SetValue(KnobColorProperty, (Color)value);
        }

        public CircularSlider()
        {
            EnableTouchEvents = true;
        }

        protected override void OnTouch(SKTouchEventArgs e)
        {
            base.OnTouch(e);
            hasTouch = true;
            touchX = e.Location.X;
            touchY = e.Location.Y;
            InvalidateSurface();
            e.Handled = true;
        }

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            canvas.Clear();

            var info = e.Info;
            var padding = (float) PaddingAround;
            var smallest = Math.Min(info.Width, info.Height);

            var x = padding + (info.Width * 0.5f - smallest * 0.5f);
            var y = padding + (info.Height * 0.5f - smallest * 0.5f);

            var arcRect = new SKRect((float)x, (float)y, (float)(x + smallest) - 2*padding, (float)(y + smallest) - 2*padding);

            var radius = arcRect.Width / 2.0f;

            var originX = arcRect.MidX;
            var originY = arcRect.MidY;

            if (hasTouch)
            {
                var (cx, cy) = Utils.PointOnCircle(originX, originY, radius, touchX, touchY);
                double theta = Utils.PointOnCircleToAngle(cx, cy, originX, originY);
                var angleEnd = Utils.Modulo(Start + Arc, 360.0);
                        
                var diffToStart = Math.Abs(Utils.AbsoluteDiff(Start, theta));
                var diffToEnd = Math.Abs(Utils.AbsoluteDiff(angleEnd, theta));

                // Clamp to beginning and end of track
                if (Utils.IsInRange(angleEnd, Start, theta))
                {
                    if (diffToStart < diffToEnd)
                        theta = Start;
                    else
                        theta = angleEnd;
                }

                if (Start > theta && theta <= angleEnd)
                {
                    /*
                     * If we made a full circle (angle is now back to 0, normalize by adding 360)
                     * so we can properly find the difference from the starting angle
                     */
                    theta += 360;
                }

                progressArc = theta - Start;
                if (progressArc > Arc) progressArc = Arc;
                else if (progressArc < 0) progressArc = 0;

                var oldVal = Value;
                progress = progressArc / Arc;
                if (oldVal != CalculatedValue)
                {
                    Value = CalculatedValue;
                }
            }

            var px = originX + (float)(radius * Math.Cos(Utils.ToRadians(Start + progressArc)));
            var py = originY + (float)(radius * Math.Sin(Utils.ToRadians(Start + progressArc)));


            trackPaint.StrokeWidth = (float)TrackWidth;
            progressPaint.StrokeWidth = (float)TrackProgressWidth;

            // Back arc
            canvas.DrawArc(arcRect, (float)Start, (float)Arc, false, trackPaint);

            // Progress arc
            canvas.DrawArc(arcRect, (float)Start, (float)progressArc, false, progressPaint);

            // Knob
            var knobPt = new SKPoint((float)px, (float)py);
            canvas.DrawCircle(knobPt, (float)KnobWidth, knobPaint);

            // Translate whole rect to middle
            canvas.Translate(arcRect.Width * 0.5f, arcRect.MidY - arcRect.Height * 0.5f);
        }

        private static void BindablePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (CircularSlider)bindable;
            instance.hasTouch = false;
            instance.progress = instance.Value / instance.Maximum;
            instance.progressArc = instance.Arc * instance.progress;
            instance.InvalidateSurface();
        }
    }
}