using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientSerie.ViewModels;

namespace ClientSerieTests.ViewModels
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