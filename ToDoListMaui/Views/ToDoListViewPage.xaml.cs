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
}