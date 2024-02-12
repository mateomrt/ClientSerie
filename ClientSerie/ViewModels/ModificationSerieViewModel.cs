using ClientSerie.Models;
using ClientSerie.Services;
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
    public class ModificationSerieViewModel : SerieViewModel
    {
        
        private List<Serie> numeroSerie;
        public List<Serie> NumeroSerie
        {
            get
            {
                return NumeroSerie;
            }
            set
            {
                NumeroSerie = value;
                OnPropertyChanged();
            }
        }

        public IRelayCommand BtnModificationSerie { get; }
        public IRelayCommand BtnRechercher { get; }
        public ModificationSerieViewModel()
        {
            GetDataOnLoadAsync();
            SerieToAdd = new Serie();



            BtnModificationSerie = new RelayCommand(ModifierSerie);
        }

        public async void ModifierSerie()
        {
            ContentDialogResult result = await MessageYesNoAsync("Êtes-vous sur de vouloir créer ?", "Confirmation");
            if (result == ContentDialogResult.Primary)
            {
                Service.PostSerieAsync("series", SerieToAdd);
            }
        }
    }
}
