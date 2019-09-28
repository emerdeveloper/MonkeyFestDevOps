using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using MonkeyFestDemo.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonkeyFestDemo.ViewModels
{
   public class SerieDetailsPageViewModel : ViewModelBase
    {
        private Serie serie;
        public Serie Serie
        {
            get { return serie; }
            set { SetProperty(ref serie, value); }
        }

        public SerieDetailsPageViewModel(INavigationService navigationService):
            base(navigationService)
        {
            Title = "Details";
        }
        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            Serie = (Serie)parameters["model"];

            //TODO: Add Analytics to track event with the Serie's data
            var analyticsData = new Dictionary<string, string> { { "Name", Serie.Name } };
            Analytics.TrackEvent("Serie clicked", analyticsData);
            //Analytics.TrackEvent("List of series fetched from internet");
            //TODO: Add fake crash if the name of the serie contains "Game of"
            if (Serie.Name.Contains("Game of")) { Crashes.TrackError(new Exception("The winter is here!")); }
        }

    }
}
