using CircularSlider.Maui;

namespace CircularSliderSample;

public partial class MainPage : ContentPage
{
	private readonly MainPageViewModel _viewModel = new();
	public MainPage()
	{
		InitializeComponent();
		this.BindingContext = _viewModel;
	}

	private void CircularSlider_OnValueChanged(object sender, ValueChangedEventArgs e)
	{
		
		if (e.NewValue < 30)
		{
			_viewModel.Color = Colors.Green;
		}

		if (e.NewValue > 30)
		{
			_viewModel.Color = Colors.Orange;
		}

		if (e.NewValue > 70)
		{
			_viewModel.Color = Colors.Red;
		}

		Console.WriteLine($"ValueChanged: {e.NewValue}");
	}

	private void CircularSlider_OnDragEnd(object sender, DragEndEventArgs e)
	{
		Console.WriteLine($"DragEnd: {e.Value}");
	}

	private void Button_Clicked(object? sender, EventArgs e)
	{
		_viewModel.Value = 25;
	}
}

