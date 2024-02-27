using MySql.Data.MySqlClient;
using MySqlConnector;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace practica1;

public partial class NuevoUsuario : ContentPage
{
	public NuevoUsuario()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {

    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        Conexion conexion = new Conexion();
        // Obtener los datos del nuevo usuario desde los controles de la página
        string nombre = textNombre.Text;
        string telefono = textTelefono.Text;
        string email = textEmail.Text;
        string genero = chkMasculino.IsChecked ? "Masculino" : "Femenino";
        DateTime fechaNacimiento = fechaDada.Date;
        string contrasena = textPassword.Text;

        // Guardar los datos del nuevo usuario en la base de datos
        if (conexion.GuardarUsuario(nombre, telefono, email, genero, fechaNacimiento, contrasena))
        {
            await DisplayAlert("Aviso", "Si jalo esta madre", "Ok");
        }
        else
        {
            await DisplayAlert("Aviso", conexion.errorMessage, "Ok");
        }
        
        
    }

    private void Button_Clicked_2(object sender, EventArgs e)
    {

    }

    private async void Button_Clicked_3(object sender, EventArgs e)
    {
        var resultado = await MediaPicker.PickPhotoAsync();
        if (resultado != null)
        {
            imgFoto.Source = ImageSource.FromStream(() => resultado.OpenReadAsync().Result);
        }
    }

    private void chkMasculino_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender == chkMasculino && chkMasculino.IsChecked)
        {
            chkFemenino.IsChecked = false;
        }
        else if (sender == chkFemenino && chkFemenino.IsChecked)
        {
            chkMasculino.IsChecked = false;
        }

    }

}