using PM022PTarea2.Clases;
using PM022PTarea2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;

namespace PM022PTarea2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaFrimas : ContentPage
    {
        List<Modelo> service;
        Firmas crud = new Firmas();
        byte[] image;
        public ListaFrimas()
        {
            InitializeComponent();
            cargarLista();
        }

        public async void cargarLista()
        {
            try
            {
                var lista_Ubicaciones = await crud.getReadFirmas();

                if (lista_Ubicaciones != null)
                {
                    listaUbicaciones.ItemsSource = lista_Ubicaciones;
                }
            }
            catch (SQLiteException e)
            {
                await DisplayAlert("Mensaje", "No hay ubicaciones guardadas", "Cerrar");

            }
        }
    }
}