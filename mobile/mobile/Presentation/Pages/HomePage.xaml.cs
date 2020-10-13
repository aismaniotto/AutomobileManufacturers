using mobile.ViewModels;
using Xamarin.Forms;

namespace mobile.Presentation.Pages
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel();

        }
    }
}
