using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientSerie.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientSerie.Models;

namespace ClientSerie.Services.Tests
{
    [TestClass()]
    public class WSServiceTests
    {
        [TestMethod()]
        public void ConstructeurTest()
        {
            //Arrange
            WSService service = new WSService("https://apiseriesmarmat.azurewebsites.net/api/");

            Assert.IsNotNull(service);
        }

        [TestMethod()]
        public void GetSeriesAsyncTest()
        {
            WSService service = new WSService("https://apiseriesmarmat.azurewebsites.net/api/");
            var result = service.GetSeriesAsync("series").Result;
            
            
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<Serie>));

            List<Serie> resultList = result.Where(s => s.Serieid <= 3).OrderBy(s => s.Serieid).ToList();


            List<Serie> expectedSeries = new List<Serie>
            {
                new Serie {
                    Serieid = 1,
                    Titre = "Scrubs",
                    Resume = "J.D. est un jeune médecin qui débute sa carrière dans l'hôpital du Sacré-Coeur. Il vit avec son meilleur ami Turk, qui lui est chirurgien dans le même hôpital. Très vite, Turk tombe amoureux d'une infirmière Carla. Elliot entre dans la bande. C'est une étudiante en médecine quelque peu surprenante. Le service de médecine est dirigé par l'excentrique Docteur Cox alors que l'hôpital est géré par le diabolique Docteur Kelso. A cela viennent s'ajouter plein de personnages hors du commun : Todd le chirurgien obsédé, Ted l'avocat dépressif, le concierge qui trouve toujours un moyen d'embêter JD... Une belle galerie de personnage !",
                    Nbsaisons = 9,
                    Nbepisodes = 184,
                    Anneecreation = 2001,
                    Network = "ABC (US)"
                },
                new Serie
                {
                    Serieid= 2,
                    Titre= "James May's 20th Century",
                    Resume= "The world in 1999 would have been unrecognisable to anyone from 1900. James May takes a look at some of the greatest developments of the 20th century, and reveals how they shaped the times we live in now.",
                    Nbsaisons= 1,
                    Nbepisodes= 6,
                    Anneecreation= 2007,
                    Network= "BBC Two"
                },

                new Serie
                {
                    Serieid= 3,
                    Titre= "True Blood",
                    Resume= "Ayant trouvé un substitut pour se nourrir sans tuer (du sang synthétique), les vampires vivent désormais parmi les humains. Sookie, une serveuse capable de lire dans les esprits, tombe sous le charme de Bill, un mystérieux vampire. Une rencontre qui bouleverse la vie de la jeune femme...",
                    Nbsaisons= 7,
                    Nbepisodes= 81,
                    Anneecreation= 2008,
                    Network="HBO"
                }
            };


            CollectionAssert.AreEqual(expectedSeries, resultList); 
        }

        [TestMethod()]
        public void GetSerieAsyncTest()
        {
            WSService service = new WSService("https://apiseriesmarmat.azurewebsites.net/api/");
            var result = service.GetSerieAsync("series", 1).Result;


            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Serie));

            Serie expectedSerie = new Serie
            {
                Serieid = 1,
                Titre = "Scrubs",
                Resume = "J.D. est un jeune médecin qui débute sa carrière dans l'hôpital du Sacré-Coeur. Il vit avec son meilleur ami Turk, qui lui est chirurgien dans le même hôpital. Très vite, Turk tombe amoureux d'une infirmière Carla. Elliot entre dans la bande. C'est une étudiante en médecine quelque peu surprenante. Le service de médecine est dirigé par l'excentrique Docteur Cox alors que l'hôpital est géré par le diabolique Docteur Kelso. A cela viennent s'ajouter plein de personnages hors du commun : Todd le chirurgien obsédé, Ted l'avocat dépressif, le concierge qui trouve toujours un moyen d'embêter JD... Une belle galerie de personnage !",
                Nbsaisons = 9,
                Nbepisodes = 184,
                Anneecreation = 2001,
                Network = "ABC (US)"
            };

            Assert.AreEqual(expectedSerie, result);
        }

        [TestMethod()]
        public void PostSerieAsyncTest()
        {
            Serie serieTest = new Serie
            {
                Titre = "test123",
                Resume = "test Resume",
                Nbsaisons = 5,
                Nbepisodes = 184,
                Anneecreation = 2001,
                Network = "ABC (US)"
            };
            WSService service = new WSService("https://apiseriesmarmat.azurewebsites.net/api/");
            var result = service.PostSerieAsync("series", serieTest).Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(bool));


            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void PutSerieAsyncTest()
        {
            WSService service = new WSService("https://apiseriesmarmat.azurewebsites.net/api/");
            var result = service.GetSerieAsync("series", 143).Result;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Serie));

            result.Resume = result.Resume + " change";

            var putResult = service.PutSerieAsync("series", result.Serieid ,result).Result;

            Assert.IsNotNull(putResult);
            Assert.IsInstanceOfType(putResult, typeof(bool));


            Assert.AreEqual(true, putResult);
        }
    }
}