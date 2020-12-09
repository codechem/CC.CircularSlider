# CC.CircularSlider.Forms
![License](https://img.shields.io/github/license/codechem/CC.CircularSlider.Forms)
[]![Nuget](https://img.shields.io/nuget/v/CC.CircularSlider.Forms)

Circle Slider Component for Xamarin.Forms.

## Preview
![](preview.gif)


## Supported Platforms

Supported platforms are currently iOS and Android, UWP support is possible, but not in scope right now, drop an issue if you're interested in having it implemented, or open a PR, of course.


## Setup

Supported platforms are currently iOS and Android, UWP support is possible, but not in scope right now, drop an issue if you're interested in having it implemented, or open a PR, of course.

```
Install-Package CC.CircularSlider
```

## Usage

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

And in the C#:

```c#
using System;
using Xamarin.Forms;

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
- CC.TouchTracking.Forms - forked from https://github.com/OndrejKunc/SkiaScene, thanks to OndrejKunc for writing this