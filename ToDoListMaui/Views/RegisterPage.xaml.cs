using ToDoListMaui.ViewModels;

namespace ToDoListMaui.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}