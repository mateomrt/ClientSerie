using ClientSerie.Models;
using ClientSerie.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSerie.ViewModels
{
    public class AjoutSerieViewModel : SerieViewModel
    {

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
        public IRelayCommand BtnAjoutSerie { get; }
        public AjoutSerieViewModel()
        {
            GetDataOnLoadAsync();
            SerieToAdd = new Serie();

            

            BtnAjoutSerie = new RelayCommand(AjoutSerie);
        }

        

        public async void AjoutSerie()
        {
            
            
            ContentDialogResult result = await MessageYesNoAsync("Êtes-vous sur de vouloir créer ?", "Confirmation");
            if (result == ContentDialogResult.Primary)
            {
                Service.PostSerieAsync("series", SerieToAdd);
            }
        }

        
    }
}
