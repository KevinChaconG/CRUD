using CRUD.Models;
using CRUD.ViewModels;

namespace CRUD.Views;

public partial class AddEmpleadoForm : ContentPage
{

	private AddEmpleadoFormViewModel viewModel;
	public AddEmpleadoForm()
	{
		InitializeComponent();
		viewModel = new AddEmpleadoFormViewModel();
		BindingContext = viewModel;
	}

	public AddEmpleadoForm(Empleado empleado)
	{
		InitializeComponent();
		viewModel = new AddEmpleadoFormViewModel(empleado);
		BindingContext = viewModel;
	}
}