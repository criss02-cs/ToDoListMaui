using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Platform;
using ToDoListMaui.ViewModels;

namespace ToDoListMaui.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }

    public Color Pink => Color.FromArgb("fe274b");

    private void LoginPage_OnAppearing(object sender, EventArgs e)
    {
        StatusBar.SetColor(Pink);
        StatusBar.SetStyle(StatusBarStyle.LightContent);
    }
}