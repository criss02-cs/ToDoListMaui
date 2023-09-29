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
}