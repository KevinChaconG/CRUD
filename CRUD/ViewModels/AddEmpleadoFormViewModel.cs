using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CRUD.Models;
using CRUD.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.ViewModels
{
    public partial class AddEmpleadoFormViewModel : ObservableObject
    {
        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string nombre;

        [ObservableProperty]
        private string direccion;

        [ObservableProperty]
        private string email;

        private readonly EmpleadoService EmpleadoService;

        public AddEmpleadoFormViewModel()
        {
            EmpleadoService = new EmpleadoService();
        }

        public AddEmpleadoFormViewModel(Empleado Empleado)
        {
            EmpleadoService=new EmpleadoService();
            id = Empleado.Id;
            nombre = Empleado.Nombre;
            direccion = Empleado.Direccion;
            email= Empleado.Email;
        }

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        [RelayCommand]
        private async Task AddUpdate()
        {
            try
            {
                Empleado Empleado = new Empleado
                {
                    Id = id,
                    Nombre = nombre,
                    Direccion = direccion,
                    Email = email,
                };

                if (Validar(Empleado))
                {
                    if (id == 0)
                    {
                        EmpleadoService.Insert(Empleado);
                    }
                    else
                    {
                        EmpleadoService.Update(Empleado);
                    }
                    await App.Current!.MainPage!.Navigation.PopAsync();
                }


            }
            catch (Exception ex)
            {
                Alerta("Error", ex.Message);
            }
        }

        private bool Validar(Empleado Empleado)
        {
            if (Empleado.Nombre == null || Empleado.Nombre == "")
            {
                Alerta("Advertencia", "Ingrese el nombre completo");
                return false;
            }
            else if (Empleado.Email == null || Empleado.Email == "") ;
            {
                Alerta("Advertencia", "Ingrese el correo electronico");
                return false;
            }
        }
    }
}
