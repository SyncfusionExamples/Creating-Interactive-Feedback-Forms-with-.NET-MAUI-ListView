# Creating interactive feedback forms with .NET MAUI ListView (SfListView)

This example demonstrate How to create Interactive Feedback Forms with .NET MAUI ListView.

## Sample

```xaml
<ContentPage.Resources>
    <ResourceDictionary>
        <local:VisibilityConverter x:Key="VisibilityConverter" />
    </ResourceDictionary>
</ContentPage.Resources>

<Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="*" />
        <RowDefinition Height="Auto" />
    </Grid.RowDefinitions>
    <syncfusion:SfListView
        x:Name="feedbackList"
        AutoFitMode="DynamicHeight"
        ItemSpacing="20"
        ItemsSource="{Binding Feedbacks}"
        SelectionMode="None">
        <syncfusion:SfListView.ItemTemplate>
            <DataTemplate>
                <Grid x:Name="Feedback">
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="40" />
                        <ColumnDefinition Width="*" />
                    </Grid.ColumnDefinitions>
                    <Label Text="{Binding QNo}" />
                    <Grid
                        x:Name="QA"
                        Grid.Column="1"
                        RowSpacing="10">
                        <Grid.RowDefinitions>
                            <RowDefinition Height="Auto" />
                            <RowDefinition Height="Auto" />
                        </Grid.RowDefinitions>
                        <Label
                            Grid.Row="0"
                            FontSize="16"
                            Text="{Binding Question}" />

                        <Entry
                            Grid.Row="1"
                            IsVisible="{Binding IsDetailedFeedback}"
                            Text="{Binding Answer}" />

                        <buttons:SfRadioGroup
                            x:Name="radioGroup"
                            Grid.Row="1"
                            BindableLayout.ItemsSource="{Binding Answers}"
                            IsVisible="{Binding IsDetailedFeedback, Converter={StaticResource VisibilityConverter}}"
                            SelectedValue="{Binding SelectedValue}">
                            <BindableLayout.ItemTemplate>
                                <DataTemplate>
                                    <buttons:SfRadioButton IsChecked="{Binding IsChecked}" Text="{Binding Answer}" />
                                </DataTemplate>
                            </BindableLayout.ItemTemplate>
                        </buttons:SfRadioGroup>

                    </Grid>
                </Grid>
            </DataTemplate>
        </syncfusion:SfListView.ItemTemplate>
    </syncfusion:SfListView>

    <Button
        Grid.Row="1"
        Margin="20"
        Command="{Binding SubmitCommand}"
        HeightRequest="40"
        HorizontalOptions="End"
        Text="Submit" />

</Grid>
```

```c#
internal class VisibilityConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value != null && (bool)value)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
```

## Requirements to run the demo

* [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/)
* Xamarin add-ons for Visual Studio (available via the Visual Studio installer).

## Troubleshooting

### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.
