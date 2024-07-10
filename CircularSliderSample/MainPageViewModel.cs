using System.ComponentModel;

namespace CircularSliderSample;

public class MainPageViewModel : INotifyPropertyChanged
{
    private Color _color = Colors.Orange;

    private double _value = 25;

    public double Value
    {
        get => _value;
        set
        {
            _value = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
        }
    }

    public Color Color
    {
        get => _color;
        set
        {
            _color = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Color)));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}