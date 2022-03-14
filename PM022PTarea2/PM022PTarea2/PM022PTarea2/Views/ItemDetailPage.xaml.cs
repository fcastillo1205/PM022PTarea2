using PM022PTarea2.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PM022PTarea2.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}