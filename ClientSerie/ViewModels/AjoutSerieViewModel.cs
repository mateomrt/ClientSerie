using ClientSerie.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSerie.ViewModels
{
    public class AjoutSerieViewModel: ObservableObject
    {

        private Serie serieToAdd;
        public Serie SerieToAdd
        { 
            get { 
                return serieToAdd; 
            }
            set
            {
                serieToAdd = value;
                OnPropertyChanged();
            }
        }

        public IRelayCommand BtnAjoutSerie { get; }
        public AjoutSerieViewModel()
        {
            SerieToAdd = new Serie();
            
            BtnAjoutSerie = new RelayCommand(AjoutSerie);
        }
        public async void AjoutSerie()
        {
            await MessageAsync("Problème chef !", "Erreur");
            

        }

        private async Task MessageAsync(string message, string titre)
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
    }
}
