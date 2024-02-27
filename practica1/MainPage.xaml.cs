namespace practica1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnNewUser_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NuevoUsuario());
        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            

            string usuario = User.Text;
            string contrasena = Password.Text;

            Conexion conexion = new Conexion();
            if (conexion.ExisteUsuario(usuario, contrasena))
            {
                await DisplayAlert("Aviso", "¡El usuario ya existe!", "OK");
                // Aquí puedes navegar a otra página o realizar otras acciones
            }
            else
            {
                await DisplayAlert("Aviso", "El usuario no está registrado", "OK");
                // Aquí puedes mostrar un mensaje o permitir que el usuario se registre
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecuperarContrasena());
        }
    }

}
