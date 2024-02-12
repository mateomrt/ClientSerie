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
        
        private int numeroSerie;
        public int NumeroSerie
        {
            get
            {
                return numeroSerie;
            }
            set
            {
                numeroSerie = value;
                OnPropertyChanged();
            }
        }

        private Serie serieToModify;
        public Serie SerieToModify
        {
            get
            {
                return serieToModify;
            }
            set
            {
                serieToModify = value;
                OnPropertyChanged();
            }
        }

        public IRelayCommand BtnModifier { get; }
        public IRelayCommand BtnSupprimer { get; }
        public IRelayCommand BtnRechercher { get; }
        public ModificationSerieViewModel()
        {
            GetDataOnLoadAsync();
            SerieToModify = new Serie();



            BtnModifier = new RelayCommand(ModifierSerie);
            BtnSupprimer = new RelayCommand(SupprimerSerie);
            BtnRechercher = new RelayCommand(RechercherSerie);
        }

        public async void RechercherSerie()
        {
            Serie serieRecherche = await Service.GetSerieAsync("series", NumeroSerie);
            SerieToModify = serieRecherche;
        }
        public async void ModifierSerie()
        {
            bool result = await Service.PutSerieAsync("series", SerieToModify.Serieid, SerieToModify);

            if (result) 
                await MessageAsync("Modification réussie !", "Validation");
            else
                await MessageAsync("Opération ratée", "Erreur");
        }
        public async void SupprimerSerie()
        {
            
            ContentDialogResult result = await MessageYesNoAsync("Êtes-vous sur de vouloir supprimer ?", "Confirmation");
            if (result == ContentDialogResult.Primary)
            {
                bool suppr = await Service.DeleteSerieAsync("series", SerieToModify.Serieid);
                if (suppr)
                {
                    await MessageAsync("suppression réussite !", "YOUHOU");
                    NumeroSerie = 0;
                    RechercherSerie();
                }
                else
                    await MessageAsync("Opération ratée", "Erreur");
            }
        }
    }
}
