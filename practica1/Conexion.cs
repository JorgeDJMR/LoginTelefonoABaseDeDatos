using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;


namespace practica1
{
    class Conexion
    {
        private const string ConnectionString = "Server=192.168.137.211;Database=datosmaui;Uid=Final;Pwd=Abcd1234.;SSL Mode=None;allowPublicKeyRetrieval=true";
        public string errorMessage;
        

        public bool GuardarUsuario(string nombre, string telefono, string email, string genero, DateTime fechaNacimiento, string contrasena)
        {
            bool sijala = false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                string query = "INSERT INTO Usuarios (Nombre, Telefono, Email, Genero, FechaNacimiento, Contrasena) VALUES (@nombre, @telefono, @email, @genero, @fechaNacimiento, @contrasena)";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@telefono", telefono);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@genero", genero);
                command.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
                command.Parameters.AddWithValue("@contrasena", contrasena);

                try
                {
                    connection.Open(); 
                    command.ExecuteNonQuery();
                    sijala= true;
                }
                catch (MySqlException ex)
                {
                    errorMessage = ex.Message;
                    // Manejo de excepciones específicas de MySQL
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                    // Manejo de otras excepciones
                }

            }
            return sijala;
        }


        public bool ExisteUsuario(string usuario, string contrasena)
        {
            bool existe = false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM Usuarios WHERE Nombre = @usuario AND Contrasena = @contrasena";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@usuario", usuario);
                command.Parameters.AddWithValue("@contrasena", contrasena);

                try
                {
                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                    {
                        existe = true;
                    }
                }
                catch (MySqlException ex)
                {
                    // Manejo de excepciones específicas de MySQL
                    Console.WriteLine("Error al verificar usuario: " + ex.Message);
                }
                catch (Exception ex)
                {
                    // Manejo de otras excepciones
                    Console.WriteLine("Error al verificar usuario: " + ex.Message);
                }
            }
            return existe;
        }

        public bool VerificarUsuarioCorreo(string usuario, string correo)
        {
            bool usuarioCorreoExisten = false;

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM Usuarios WHERE Nombre = @usuario AND Email = @correo";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@usuario", usuario);
                command.Parameters.AddWithValue("@correo", correo);

                try
                {
                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    usuarioCorreoExisten = count > 0;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error al verificar usuario y correo: " + ex.Message);
                }
            }

            return usuarioCorreoExisten;
        }

        public bool ModificarContrasena(string nombreUsuario, string nuevaContrasena)
        {
            bool contrasenaModificada = false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                string query = "UPDATE Usuarios SET Contrasena = @nuevaContrasena WHERE Nombre = @nombreUsuario";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@nuevaContrasena", nuevaContrasena);
                command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    contrasenaModificada = (rowsAffected > 0);
                }
                catch (MySqlException ex)
                {
                    // Manejar la excepción, por ejemplo, registrarla o mostrar un mensaje de error
                }
            }
            return contrasenaModificada;
        }






    }

}

