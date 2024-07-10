using System.ComponentModel;

namespace CircularSliderSample;

public class MainPageViewModel : INotifyPropertyChanged
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

    Color color = Colors.Orange;
    public Color Color
    {
        get => color;
        set {
            color = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Color)));
        }
    }
}