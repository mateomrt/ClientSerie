using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientSerie.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientSerie.Models;

namespace ClientSerie.ViewModels.Tests
{
    [TestClass()]
    public class ModificationSerieViewModelTests
    {
        [TestMethod()]
        public void ModificationSerieViewModelTest()
        {
            ModificationSerieViewModel ajoutSerie = new ModificationSerieViewModel();
            Assert.IsNotNull(ajoutSerie);
        }

        [TestMethod()]
        public void RechercherSerieTest()
        {
            ModificationSerieViewModel viewModel = new ModificationSerieViewModel();
            viewModel.NumeroSerie = 1;
            viewModel.RechercherSerie();
            Thread.Sleep(1000);

            var expectedSerie = new Serie
            {
                Serieid = 1,
                Titre = "Scrubs",
                Resume = "J.D. est un jeune médecin qui débute sa carrière dans l'hôpital du Sacré-Coeur. Il vit avec son meilleur ami Turk, qui lui est chirurgien dans le même hôpital. Très vite, Turk tombe amoureux d'une infirmière Carla. Elliot entre dans la bande. C'est une étudiante en médecine quelque peu surprenante. Le service de médecine est dirigé par l'excentrique Docteur Cox alors que l'hôpital est géré par le diabolique Docteur Kelso. A cela viennent s'ajouter plein de personnages hors du commun : Todd le chirurgien obsédé, Ted l'avocat dépressif, le concierge qui trouve toujours un moyen d'embêter JD... Une belle galerie de personnage !",
                Nbsaisons = 9,
                Nbepisodes = 184,
                Anneecreation = 2001,
                Network = "ABC (US)"
            };

            Assert.AreEqual(expectedSerie, viewModel.SerieToModify);
        }

        [TestMethod()]
        public void ModifierSerieTest()
        {
            
        }
    }
}