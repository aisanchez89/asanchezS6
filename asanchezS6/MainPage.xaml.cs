using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace asanchezS6
{
    public partial class MainPage : ContentPage
    {
        private string Url = "http://192.168.100.65/ws_uisrael/post.php";
        private HttpClient cliente = new HttpClient();
        private ObservableCollection<Estudiante> post;
        public MainPage()
        {
            InitializeComponent();
            ObtenerDatos();
        }

        private async void ObtenerDatos()
        {
            var contenido = await cliente.GetStringAsync(Url);
            List<Estudiante> listaPost = JsonConvert.DeserializeObject<List<Estudiante>>(contenido);
            post = new ObservableCollection<Estudiante>(listaPost);
            ListaEstudiantes.ItemsSource = post;
        }

       /*private async void btnMostrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Insertar());
        }*/

        private void ListaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objeto = (Estudiante)e.SelectedItem;
            var codigoTem = objeto.codigo.ToString();
            int codigo = Convert.ToInt32(codigoTem);
            string nombre = objeto.nombre.ToString();
            string apellido = objeto.apellido.ToString();
            var edadTem = objeto.edad.ToString();
            int edad = Convert.ToInt32(edadTem);

            Navigation.PushAsync(new ActualizarEliminar(codigo, nombre, apellido, edad));
        }

        /*private void btnMostrar_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Insertar());
        }*/

        private void btnMostrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Insertar());
        }
    }
}
