using GridLayout.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static GridLayout.ViewModels.AboutViewModel;

namespace GridLayout.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class SuperHeroDetailsView : ContentPage
    {
        private SuperHeroDetailsViewModel superHeroDetailsViewModel;
        public SuperHeroDetailsView(Result hero)
        {
            InitializeComponent();
            superHeroDetailsViewModel = new SuperHeroDetailsViewModel(hero);
            this.BindingContext = superHeroDetailsViewModel;
        }
        public SuperHeroDetailsView()
        {
            InitializeComponent();
        }

        

    }
}