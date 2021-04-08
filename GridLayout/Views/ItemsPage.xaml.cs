using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GridLayout.Models;
using GridLayout.Views;
using GridLayout.ViewModels;
using System.Net.Http;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using static GridLayout.ViewModels.AboutViewModel;

namespace GridLayout.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        // ItemsViewModel viewModel;
        private int i = 1;
        List<Result> superHeroList = new List<Result>();

        public ItemsPage()
        {
            InitializeComponent();
            DashSuperHerosLayout.IsVisible = false;
            this.loadHeros();
        }

        private async void loadHeros()
        {
            DashSuperHerosLoader.IsVisible = true;
            DashSuperHerosButton.IsVisible = false;
            HttpClient client = new HttpClient();
            var i = this.i;
            List<Result> superHeroListTemp = new List<Result>(superHeroList);

            for (; this.i < i+3; this.i++)
            {
                var response = await client.GetStringAsync("https://superheroapi.com/api/1608116966244916/"+ this.i.ToString());
                var SuperheroResults = Newtonsoft.Json.JsonConvert.DeserializeObject<Result>(response);
                superHeroListTemp.Add(SuperheroResults);
            }
            superHeroList = superHeroListTemp;
            HeroList.ItemsSource = superHeroListTemp;
            DashSuperHerosButton.IsVisible = true;
            DashSuperHerosLoader.IsVisible = false;
            DashSuperHerosLayout.IsVisible = true;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            this.loadHeros();
        }

        async void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var x = e.SelectedItem as Result;
            var postDetailPage = new SuperHeroDetailsView(x);
            await Navigation.PushAsync(postDetailPage);
        }
    }
}