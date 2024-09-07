using CRUD.Views;
namespace CRUD

{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new EmpleadoMain());
        }
    }
}
