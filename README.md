# CC.CircularSlider.Forms
![License](https://img.shields.io/github/license/codechem/CC.CircularSlider.Forms)
[![Nuget](https://img.shields.io/nuget/v/CC.CircularSlider.Forms)](https://www.nuget.org/packages/CC.CircularSlider.Forms/)

Circle Slider Component for Xamarin.Forms and .NET MAUI.

## Preview
![](preview.gif)


## Supported Platforms

Supported platforms are currently iOS and Android, UWP support is possible, but not in scope right now, drop an issue if you're interested in having it implemented, or open a PR, of course.


## Setup

Supported platforms are currently iOS and Android, UWP support is possible, but not in scope right now, drop an issue if you're interested in having it implemented, or open a PR, of course.

```
Install-Package CC.CircularSlider.Forms
```

## Usage 

### Xamarin.Forms

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage
    x:Class="CircularSliderSample.MainPage"
    xmlns="http://xamarin.com/schemas/2014/forms"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:cc="clr-namespace:CC;assembly=CC.CircularSlider.Forms">

    <StackLayout Padding="50">
        <cc:CircularSlider
            Arc="360"
            KnobColor="{Binding Color}"
            Maximum="100"
            Minimum="0"
            OnValueChanged="CircularSlider_OnValueChanged"
            PaddingAround="10"
            Start="90"
            TrackProgressColor="{Binding Color}"
            VerticalOptions="FillAndExpand"
            Value="50" />
    </StackLayout>
</ContentPage>
```

### .NET MAUI

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage 
    x:Class="CircularSliderSample.MainPage"
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:cc="clr-namespace:CC;assembly=CC.CircularSlider.MAUI"
    x:Class="CircularSliderSample.MainPage">

    <StackLayout 
        Orientation="Horizontal" 
        HorizontalOptions="Fill" 
        VerticalOptions="Center">
            <slider:CircularSlider 
                PaddingAround="45" 
                Start="120" 
                Arc="300" 
                TrackWidth="2" 
                KnobColor="{DynamicResource BrandColor}" 
                TrackColor="{DynamicResource BrandColor}" 
                TrackProgressColor="{DynamicResource BrandColor}" 
                Minimum="{Binding MinimumValue}" 
                Maximum="{Binding MaximumValue}" 
                Value="{Binding ActualValue}" 
                OnValueChanged="CircularSlider_OnOnValueChanged" 
                VerticalOptions="Center" 
                HeightRequest="400" 
                HorizontalOptions="Fill"/> 
    </StackLayout>
</ContentPage>
```

And in the C#:

```c#
namespace CircularSliderSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void CircularSlider_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            Console.WriteLine(e.NewValue);
        }
    }
}
```

This should give you a page with a large slider embedded.

## Bindable Properties/Events

| Type       | Property                  | Description                                                                                                                         | Default Value              |
|------------|---------------------------|-------------------------------------------------------------------------------------------------------------------------------------|----------------------------|
| Property   | Minimum                   | The minimum value of the slider.                                                                                                    | `0`                        |
| Property   | Maximum                   | The maximum value of the slider.                                                                                                    | `1`                        |
| Property   | TrackColor                | The color of the background track (the back, unfilled part of the slider)                                                           | `Color.Gray`               |
| Property   | TrackProgressColor        | The color of the progress track (the front, filled part of the slider)                                                              | `Color.Red`                |
| Property   | KnobColor                 | The color of the knob/handle of the slider                                                                                          | `Color.Red`                |
| Property   | TrackWidth                | The width of the background track (the back, unfilled part of the slider)                                                           | `20`                       |
| Property   | TrackProgressWidth        | The width of the progress track (the front, filled part of the slider)                                                              | `10`                       |
| Property   | KnobWidth                 | The width of the knob/handle of the slider                                                                                          | `5`                        |
| Property   | Value                     | The `Value` of the slider.                                                                                                          | `0`                        |
| Property   | Start                     | The `Start` of the slider in degrees (0 degrees is on the right side of the circle, and the angles are clockwise).                  | `90`                       |
| Property   | Arc                       | How many degrees the slider should take up from the start (Max 360 - a full circle)                                                 | `360`                      |
| Property   | PaddingAround             | Spacing from the edges of the control.                                                                                              | `25`                       |
| Event      | ValueChanged              | Event fired when the value changes due to user interaction - same event args as the regular Xamarin.Forms Slider control.           |                            |


## Dependencies and special thanks

- SkiaSharp.Views.Forms
- SkiaSharp.Views.Maui.Controls
