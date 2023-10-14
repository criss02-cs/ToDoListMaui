using CommunityToolkit.Maui.Core.Platform;
using CommunityToolkit.Maui.Core;
using ToDoListMaui.ViewModels;

namespace ToDoListMaui.Views;

public partial class ToDoListViewPage : ContentPage
{
	public ToDoListViewPage()
	{
		InitializeComponent();
		var viewModel = Application.Current.Handler.MauiContext.Services.GetService(typeof(ToDoListViewViewModel)) as ToDoListViewViewModel;
		BindingContext = viewModel;
    }

    private void ToDoListViewPage_OnAppearing(object sender, EventArgs e)
    {
        if (!Application.Current.Resources.TryGetValue("Primary", out var primary)) return;
        StatusBar.SetColor(primary as Color);
        StatusBar.SetStyle(StatusBarStyle.LightContent);
    }
}