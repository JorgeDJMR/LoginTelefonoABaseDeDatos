namespace practica1;

public partial class RecuperarContrasena : ContentPage
{

    private Conexion conexion;
    private string nombreUsuarioRecuperado; // Declaraci�n de la variable a nivel de clase

    public RecuperarContrasena()
	{
		InitializeComponent();
        conexion = new Conexion();
    }


    private async void Button_Clicked(object sender, EventArgs e)
    {
        Conexion conexion1 = new Conexion();
        //string usuario = Dnombre.Text;
        //string correo = Dcorreo.Text;

        //// Verificar si el usuario y el correo existen en la base de datos
        //bool usuarioCorreoExiste = conexion1.VerificarUsuarioCorreo(usuario, correo);

        //if (usuarioCorreoExiste)
        //{
        //    // Navegar a la p�gina CambiarContrase�aPage si el usuario y el correo existen
        //    Navigation.PushAsync(new CambiarContrase�aPage());
        //}
        //else
        //{
        //    // Mostrar un mensaje de que el usuario no existe
        //    DisplayAlert("Usuario no encontrado", "El usuario o correo electr�nico proporcionados no existen en la base de datos.", "OK");
        //}

        string usuario = Dnombre.Text;
        string correo = Dcorreo.Text;

        if (conexion.VerificarUsuarioCorreo(usuario, correo))
        {
            nombreUsuarioRecuperado = usuario; // Asignaci�n del valor al campo de clase
            await Navigation.PushAsync(new CambiarContrase�aPage(nombreUsuarioRecuperado)); // Pasar el valor al constructor de CambiarContrase�aPage
        }
        else
        {
            await DisplayAlert("Error", "Usuario o correo electr�nico incorrecto", "OK");
        }
    }
}
