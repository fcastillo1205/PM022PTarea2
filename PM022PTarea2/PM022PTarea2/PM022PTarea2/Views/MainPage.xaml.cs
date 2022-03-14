using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM022PTarea2.Clases;
using PM022PTarea2.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM022PTarea2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void guardar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Nombre.Text))
            {
                await DisplayAlert("Error", "Complete el campo de nombre", "Cerrar");
                return;
            }else if (string.IsNullOrEmpty(Descripcion.Text))
            {
                await DisplayAlert("Error", "Complete el campo de nombre", "Cerrar");
                return;
            }

            string base64;
            Byte[] bytes;

            Stream img = await padFirma.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png);
            if(img != null)
            {
                BinaryReader br = new BinaryReader(img);
                bytes = br.ReadBytes((Int32)img.Length);
                base64 = Convert.ToBase64String(bytes, 0, bytes.Length);
            }
            else
            {
                await DisplayAlert("Error", "Debe crear una firma", "Cerrar");
                return;
            }

            if (base64 != null)
            {
                Firmas operacionesDB = new Firmas();
                ConexionDB conn = new ConexionDB();

                var firma = new Modelo()
                {
                    Name = Nombre.Text,
                    Descripcion=Descripcion.Text,
                    Firma = base64

                };
                conn.conn().CreateTable<Modelo>();
                conn.conn().Insert(firma);
                await DisplayAlert("Mensaje", "Registro Guardado", "Salir");
                vaciarCampos();
            }
            else
            {
                await DisplayAlert("Mensaje", "No se pudo guardar", "Salir");
                return;
            }


        }

        private async void Limpiar_Clicked(object sender, EventArgs e)
        {
            vaciarCampos();
        }

        public void vaciarCampos()
        {
            padFirma.Clear();
            Nombre.Text = "";
            Descripcion.Text = "";
        }

        private async void Listar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaFrimas());
        }
    }
}