using CRUD.ViewModels;

namespace CRUD.Views;

public partial class EmpleadoMain : ContentPage
{

	private EmpleadoMainViewModel ViewModel;
	public EmpleadoMain()
	{
		InitializeComponent();
		ViewModel = new EmpleadoMainViewModel();
		this.BindingContext = ViewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		ViewModel.GetAll();
    }
}