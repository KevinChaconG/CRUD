
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CRUD.Models;
using CRUD.Services;
using CRUD.Views;
using System.Collections.ObjectModel;

namespace CRUD.ViewModels
{
    public partial class EmpleadoMainViewModel : ObservableObject
    {
        //Coleccion de datos para interactuar con la vista
        [ObservableProperty]
        private ObservableCollection<Empleado> empleadoCollection = new ObservableCollection<Empleado>();

        //Llamamos a la clase en donde configuramos la base de datos
        private readonly EmpleadoService EmpleadoService;

        public EmpleadoMainViewModel()
        {
            EmpleadoService = new EmpleadoService();
        }
        //Muestra un mensaje de alerta personalizado
        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje,"Aceptar"));
        }

        public void GetAll()
        {
            var getAll = EmpleadoService.GetAll();

            if (getAll.Count > 0)
            {
                empleadoCollection.Clear();
                foreach (var empleado in getAll)
                {
                    empleadoCollection.Add(empleado);
                }
            } 
        }

        //Redirecciona a la vista de agregar/editar empleado

        [RelayCommand]
        private async Task goToAddEmpleadoForm()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new AddEmpleadoForm());
        }

        [RelayCommand]
        private async Task SelectEmpleado(Empleado empleado)
        {
            try
            {
                string actualizar = "Actualizar";
                string eliminar = "Eliminar";

                //Alerta de consulta con su respectiva respuesta
                string res = await App.Current!.MainPage!.DisplayActionSheet("Opciones", "Cancelar", null, actualizar, eliminar);

                if (res == actualizar)
                {
                    await App.Current.MainPage.Navigation.PushAsync(new AddEmpleadoForm(empleado));
                } else if (res == eliminar)
                {
                    bool respuesta = await App.Current!.MainPage!.DisplayAlert("Eliminar Empleado", "Desea eliminar el registro de empleado?", "Si", "No");

                    if (respuesta)
                    {
                        int del = EmpleadoService.Delete(empleado);

                        if(del > 0)
                        {
                            empleadoCollection.Remove(empleado);
                        }
                    }
                }


            }catch(Exception ex)
            {
                Alerta("Error", ex.Message);
            }

        }
    }
}
