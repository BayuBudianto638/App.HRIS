using App.HRIS.Services.Employees;
using App.HRIS.ViewModels;

namespace App.HRIS.Views;

public partial class HomePage : ContentPage
{
    private readonly EmployeeDetailsViewModel _viewModel;

    public HomePage()
	{
		InitializeComponent();
        BindingContext = new EmployeeDetailsViewModel(new EmployeeService());
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadEmployeeData();
    }
}