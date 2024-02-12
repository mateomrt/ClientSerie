using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientSerie.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientSerie.ViewModels;

namespace ClientSerie.Views.Tests
{
    [TestClass()]
    public class AjoutSerieTests
    {
        /// <summary>
        /// Test constructeur.
        /// </summary>
        [TestMethod()]
        public void ConvertisseurEuroViewModelTest()
        {
            AjoutSerieViewModel ajoutSerie = new AjoutSerieViewModel();
            Assert.IsNotNull(ajoutSerie);
        }
    }
}