using CommunityToolkit.Maui.Core.Platform;
using CommunityToolkit.Maui.Core;
using ToDoListMaui.ViewModels;

namespace ToDoListMaui.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }

    private void RegisterPage_OnAppearing(object sender, EventArgs e)
    {
        StatusBar.SetColor(Colors.Orange);
        StatusBar.SetStyle(StatusBarStyle.LightContent);
    }
}