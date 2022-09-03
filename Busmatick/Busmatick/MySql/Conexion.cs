using MySql.Data.MySqlClient;

namespace Busmatick.MySql
{
    public class Conexion : IDisposable
    {
        
        public MySqlConnection ConexionBD { get; }

        public Conexion(string connectionString)
        {
            try
            {
                ConexionBD = new MySqlConnection(connectionString);
                Console.WriteLine("Conectados a Busmatick");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectarse"+ex.Message.ToString());
            }
            
        }

        public void Dispose() => ConexionBD.Dispose();

    }


}