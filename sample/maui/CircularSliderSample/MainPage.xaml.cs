using System.ComponentModel;

namespace CircularSliderSample;

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

    Color color = Colors.Orange;

    public Color Color
    {
        get => color;
        set
        {
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

    void CircularSlider_OnDragEnd(System.Object sender, CC.DragEndEventArgs e)
    {
        Console.WriteLine($"DragEnd: {e.Value}");
    }

    private void CircularSlider_OnValueChanged(object sender, ValueChangedEventArgs e)
    {
        if (e.NewValue < 30)
        {
            Model.Color = Colors.Green;
        }

        if (e.NewValue > 30)
        {
            Model.Color = Colors.Orange;
        }

        if (e.NewValue > 70)
        {
            Model.Color = Colors.Red;
        }

        Console.WriteLine($"ValueChanged: {e.NewValue}");
    }
}