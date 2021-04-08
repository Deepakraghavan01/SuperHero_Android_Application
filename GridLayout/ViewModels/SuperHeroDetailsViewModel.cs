using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using static GridLayout.ViewModels.AboutViewModel;

namespace GridLayout.ViewModels
{
    public class SuperHeroDetailsViewModel : ContentPage
    {
        private Result _result;
        public Result Result
        {
            get => _result;
            set
            {
                SetProperty(ref _result, value);
            }
        }

        private void SetProperty(ref Result result, Result value)
        {
            throw new NotImplementedException();
        }

        public SuperHeroDetailsViewModel(Result result)
        {
            this._result = result;
        }
        public SuperHeroDetailsViewModel()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Welcome To SuperHeros Dashboard!" }
                }
            };
        }
    }
}