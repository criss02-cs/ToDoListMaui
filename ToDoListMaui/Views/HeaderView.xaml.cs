namespace ToDoListMaui.Views;

public partial class HeaderView : ContentView
{
    private static readonly BindableProperty TitleProperty = BindableProperty.Create(
        nameof(Title), typeof(string), typeof(HeaderView), propertyChanged: TitlePropertyChanged);
    private static readonly BindableProperty SubTitleProperty = BindableProperty.Create(
        nameof(SubTitle), typeof(string), typeof(HeaderView), propertyChanged: SubTitlePropertyChanged);
    private static readonly BindableProperty AngleProperty = BindableProperty.Create(
        nameof(Angle), typeof(double), typeof(HeaderView), propertyChanged: AnglePropertyChanged);
    public static readonly BindableProperty BgColorProperty = BindableProperty.Create(
        nameof(BgColor), typeof(Color), typeof(HeaderView), propertyChanged: BackgroundColorPropertyChanged);

    public HeaderView()
    {
        InitializeComponent();
    }

    public double RectangleWidth => DeviceDisplay.Current.MainDisplayInfo.Width * 3;

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string SubTitle
    {
        get => (string)GetValue(SubTitleProperty); 
        set => SetValue(SubTitleProperty, value);
    }

    public double Angle
    {
        get => (double)GetValue(AngleProperty);
        set => SetValue(AngleProperty, value);
    }

    public Color BgColor
    {
        get => (Color)GetValue(BgColorProperty);
        set => SetValue(BgColorProperty, value);
    }

    private static void TitlePropertyChanged(BindableObject bindable, object oldvalue, object newValue)
    {
        if (bindable is not HeaderView control) return;
        if (newValue is not string value) return;
        control.TitleLabel.Text = value;
    }

    private static void SubTitlePropertyChanged(BindableObject bindable, object oldvalue, object newValue)
    {
        if (bindable is not HeaderView control) return;
        if (newValue is not string value) return;
        control.SubTitleLabel.Text = value;
    }

    private static void AnglePropertyChanged(BindableObject bindable, object oldvalue, object newValue)
    {
        if (bindable is not HeaderView control) return;
        if (newValue is not double value) return;
        control.BackgroundBox.Rotation = value;
        control.LabelStackLayout.Rotation = -value;
    }

    private static void BackgroundColorPropertyChanged(BindableObject bindable, object oldvalue, object newValue)
    {
        if (bindable is not HeaderView control) return;
        if (newValue is not Color value) return;
        control.BackgroundBox.BackgroundColor = value;
    }
}