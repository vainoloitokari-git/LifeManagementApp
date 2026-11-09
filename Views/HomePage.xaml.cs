using LifeManagementApp.ViewModels;

namespace LifeManagementApp.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();

        BindingContext = new HomeViewModel();
    }
}