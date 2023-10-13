using ToDoListMaui.ViewModels;

namespace ToDoListMaui.Views;

public partial class ProfileViewPage : ContentPage
{
	public ProfileViewPage(ProfileViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}