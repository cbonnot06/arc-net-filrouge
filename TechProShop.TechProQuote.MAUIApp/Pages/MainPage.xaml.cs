using TechProShop.TechProQuote.MAUIApp.Models;
using TechProShop.TechProQuote.MAUIApp.PageModels;

namespace TechProShop.TechProQuote.MAUIApp.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}