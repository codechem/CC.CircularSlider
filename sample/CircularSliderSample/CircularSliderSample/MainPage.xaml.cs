using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace CircularSliderSample
{
    public class VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public VM Model = new VM();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = Model;
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

            Console.WriteLine(e.NewValue);
        }
    }
}