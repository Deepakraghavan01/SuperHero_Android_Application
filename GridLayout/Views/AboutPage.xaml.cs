using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Xamarin.Forms;
using static GridLayout.ViewModels.AboutViewModel;



namespace GridLayout.Views
{
    public partial class AboutPage : ContentPage
    {
        List<Result> SearchResults = new List<Result>();
        public AboutPage()
        {
            InitializeComponent();
            MainPickerGender.Items.Add("All");
            MainPickerGender.Items.Add("Male");
            MainPickerGender.Items.Add("Female");
            MainPickerType.Items.Add("All");
            MainPickerType.Items.Add("Good");
            MainPickerType.Items.Add("Bad");
        }

        private async void searchbar_SearchButtonPressed(object sender, System.EventArgs e)
        {
            SearchSuperHerosLoader.IsVisible = true;
            SearchSuperHerosLayout.IsVisible = false;

            MainPickerPublisher.Items.Clear();
            MainPickerPublisher.Items.Add("All");
            var keyword = SearchSuperHeros.Text;
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://superheroapi.com/api/1608116966244916/search/" + keyword);
            
            var SuperheroResults = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(response);
            
            List<Result> resultnamrs = new List<Result>();
            
            if (SuperheroResults.response == "success")
            {
                resultnamrs.AddRange(SuperheroResults.results.ToList());
            }

            if (resultnamrs.Count > 0)
            {
                HashSet<string> publisherSets = new HashSet<string>();
                foreach(Result result in resultnamrs)
                {
                    publisherSets.Add(result.biography.publisher);
                }
                foreach (string result in publisherSets)
                {
                    MainPickerPublisher.Items.Add(result);
                }
                HerosList.IsVisible = true;
                NoHeroFound.IsVisible = false;
            } else
            {
                HerosList.IsVisible = false;
                NoHeroFound.IsVisible = true;
            }
            SearchResults = new List<Result>(resultnamrs);
            Powerstats.ItemsSource = resultnamrs;
            SearchSuperHerosLoader.IsVisible = false;
            SearchSuperHerosLayout.IsVisible = true;
        }

        private void OnTappingFilterItem(object sender, System.EventArgs e)
        {
            string SelectedGender = "";
            string SelectedType = "";
            string SelectedPublisher = "";
            List<Result> selectedHeros = SearchResults;
            if (MainPickerGender.SelectedIndex > 0)
            {
                SelectedGender = MainPickerGender.Items[MainPickerGender.SelectedIndex];
            }

            if (MainPickerType.SelectedIndex > 0)
            {
                SelectedType = MainPickerType.Items[MainPickerType.SelectedIndex];
            }

            if (MainPickerPublisher.SelectedIndex > 0)
            {
                SelectedPublisher = MainPickerPublisher.Items[MainPickerPublisher.SelectedIndex];
            }

            if (SelectedGender != "All" && SelectedGender != "")
            {
                selectedHeros = selectedHeros.Where(l => l.appearance.gender.ToLower() == SelectedGender.ToLower()).ToList();
            }

            if (SelectedType != "All" && SelectedType != "")
            {
                selectedHeros = selectedHeros.Where(l => l.biography.alignment.ToLower() == SelectedType.ToLower()).ToList();
            }

            if (SelectedPublisher != "All" && SelectedPublisher != "")
            {
                selectedHeros = selectedHeros.Where(l => l.biography.publisher.ToLower() == SelectedPublisher.ToLower()).ToList();
            }

            if (MainPickerGender.SelectedIndex <= 0 && MainPickerType.SelectedIndex <= 0 && MainPickerPublisher.SelectedIndex <= 0)
            {
                selectedHeros = SearchResults;
            }

            if (selectedHeros.Count > 0)
            {
                HerosList.IsVisible = true;
                NoHeroFound.IsVisible = false;
            }
            else
            {
                HerosList.IsVisible = false;
                NoHeroFound.IsVisible = true;
            }

            Powerstats.ItemsSource = selectedHeros;
        }
        async void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var x = e.SelectedItem as Result;
            var postDetailPage = new SuperHeroDetailsView(x);
            await Navigation.PushAsync(postDetailPage);


        }
    }
}