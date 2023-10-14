using CommunityToolkit.Maui.Core.Platform;
using CommunityToolkit.Maui.Core;
using ToDoListMaui.ViewModels;

namespace ToDoListMaui.Views;

public partial class ProfileViewPage : ContentPage
{
	public ProfileViewPage(ProfileViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }

    private void ProfileViewPage_OnAppearing(object sender, EventArgs e)
    {
        //if (!Application.Current.Resources.TryGetValue("Primary", out var primary)) return;
        StatusBar.SetColor(Colors.White);
        StatusBar.SetStyle(StatusBarStyle.LightContent);

    }
}