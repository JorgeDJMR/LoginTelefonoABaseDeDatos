namespace practica1;

public partial class CambiarContraseñaPage : ContentPage
{
    private Conexion conexion;
    private string nombreUsuarioRecuperado; // Variable local para almacenar el valor recibido

    public CambiarContraseñaPage(string nombreUsuario)
	{
		InitializeComponent();
        conexion = new Conexion();
        nombreUsuarioRecuperado = nombreUsuario; // Asignar el valor recibido a la variable local
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        string nuevaContrasena = NuevaContraseñaEntry.Text;

        if (conexion.ModificarContrasena(nombreUsuarioRecuperado, nuevaContrasena))
        {
            await DisplayAlert("Éxito", "La contraseña se ha modificado correctamente", "OK");
        }
        else
        {
            await DisplayAlert("Error", "No se pudo modificar la contraseña", "OK");
        }
    }
}