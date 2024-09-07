
using CRUD.Models;
using SQLite;

namespace CRUD.Services
{
    public class EmpleadoService
    {
        private readonly SQLiteConnection dbConnection;
        public EmpleadoService()
        {
            //construir la ruta
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Empleado.db3");

            //Inicializar el objeto
            dbConnection = new SQLiteConnection(dbPath);

            //creamos la tabla empleado
            dbConnection.CreateTable<Empleado>();


        }
        //lista todos los empleados y retorna todos los empleados
        public List<Empleado> GetAll()
        {
            var res = dbConnection.Table<Empleado>().ToList();
            return res;
        }
        //guarda un registro a la base de datos y retorna la cantidad de registros ingresados
        public int Insert(Empleado empleado)
        {
            return dbConnection.Insert(empleado);
        }
        //actualiza un registro a la base de datos y retorna la cantidad de registros actualizados
        public int Update(Empleado empleado) 
        {
            return dbConnection.Update(empleado);
        }
        //elimina un registro a la base de datos y retorna la cantidad de registros eliminados
        public int Delete(Empleado empleado)
        {
            return dbConnection.Delete(empleado);
        }
    }
}
