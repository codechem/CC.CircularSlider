using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace CircularSliderSample
{
    public class VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        double value = 25;
        public double Value
        {
            get => value;
            set
            {
                this.value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
            }
        }

        Color color = Color.Orange;
        public Color Color
        {
            get => color;
            set {
                color = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Color)));
            }
        }
    }

    public partial class MainPage : ContentPage
    {
        public VM Model = new VM();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = Model;
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
                Model.Value = 25;
        }

        private void CircularSlider_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (e.NewValue < 30)
            {
                Model.Color = Color.Green;
            }

            if (e.NewValue > 30)
            {
                Model.Color = Color.Orange;
            }

            if (e.NewValue > 70)
            {
                Model.Color = Color.Red;
            }
        }
    }
}