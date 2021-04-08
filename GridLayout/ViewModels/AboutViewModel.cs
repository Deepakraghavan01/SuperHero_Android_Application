using GridLayout.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace GridLayout.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Search SuperHeros";

        }

        public class Powerstats
        {
            public string intelligence { get; set; }
            public string strength { get; set; }
            public string speed { get; set; }
            public string durability { get; set; }
            public string power { get; set; }
            public string combat { get; set; }
        }

        public class Biography
        {
            [JsonProperty("full-name")]
            public string FullName { get; set; }

            [JsonProperty("alter-egos")]
            public string AlterEgos { get; set; }
            private List<string> alias;
            public List<string> aliases { get => alias; set {
                    alias = value;
                }
            }

            [JsonProperty("place-of-birth")]
            public string PlaceOfBirth { get; set; }

            [JsonProperty("first-appearance")]
            public string FirstAppearance { get; set; }
            public string publisher { get; set; }
            public string alignment { get; set; }
        }

        public class Appearance
        {
            public string gender { get; set; }
            public string race { get; set; }
            public List<string> height { get; set; }
            public List<string> weight { get; set; }

            [JsonProperty("eye-color")]
            public string EyeColor { get; set; }

            [JsonProperty("hair-color")]
            public string HairColor { get; set; }
        }

        public class Work
        {
            public string occupation { get; set; }
            public string @base { get; set; }
        }

        public class Connections
        {
            [JsonProperty("group-affiliation")]
            public string GroupAffiliation { get; set; }
            public string relatives { get; set; }
        }

        public class Image
        {
            public string url { get; set; }
        }

        public class Result
        {
            public string id { get; set; }
            public string name { get; set; }
            public Powerstats powerstats { get; set; }
            public Biography biography { get; set; }
            public Appearance appearance { get; set; }
            public Work work { get; set; }
            public Connections connections { get; set; }
            public Image image { get; set; }
        }

        public class Root
        {
            public string response { get; set; }

            [JsonProperty("results-for")]
            public string ResultsFor { get; set; }
            public List<Result> results { get; set; }
        }
    }
}