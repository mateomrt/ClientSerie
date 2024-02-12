using ClientSerie.Models;
using ClientSerie.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSerie.ViewModels
{
    public abstract class SerieViewModel : ObservableObject
    {
        private WSService service;
        public WSService Service
        {
            get
            {
                return service;
            }
            set
            {
                service = value;
                OnPropertyChanged();
            }
        }

        private Serie serieToAdd;
        public Serie SerieToAdd
        {
            get
            {
                return serieToAdd;
            }
            set
            {
                serieToAdd = value;
                OnPropertyChanged();
            }
        }

        private List<Serie> lesSeries;
        public List<Serie> LesSeries
        {
            get
            {
                return lesSeries;
            }
            set
            {
                lesSeries = value;
                OnPropertyChanged();
            }
        }

        public async void GetDataOnLoadAsync()
        {
            Service = new WSService("https://apiseriesmarmat.azurewebsites.net/api/");

            List<Serie> result = await Service.GetSeriesAsync("series");

            if (result == null)
            {
                await MessageAsync("API non disponible !", "Erreur");
            }
            else
            {
                LesSeries = new List<Serie>(result);
            }


        }

        public async Task MessageAsync(string message, string titre)
        {
            ContentDialog contentDialog = new ContentDialog
            {
                Title = titre,
                Content = message,
                CloseButtonText = "Ok"
            };
            contentDialog.XamlRoot = App.MainRoot.XamlRoot;
            await contentDialog.ShowAsync();
        }
        public async Task<ContentDialogResult> MessageYesNoAsync(string message, string titre)
        {
            ContentDialog contentDialog = new ContentDialog
            {
                Title = titre,
                Content = message,
                CloseButtonText = "Annuler",
                PrimaryButtonText = "Confirmer"
            };
            contentDialog.XamlRoot = App.MainRoot.XamlRoot;
            return await contentDialog.ShowAsync();
        }
    }
}
