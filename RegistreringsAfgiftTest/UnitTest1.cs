using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistreringsAfgift;

namespace RegistreringsAfgiftTest
{
    [TestClass]
    public class UnitTest1
    {

        public Afgift _afgift = new Afgift();

        // ---------------
        // Normal bil test
        // ---------------

        [TestMethod]
        public void KaldMed_lovligVærdi_returnereResultat_NormalBil()
        {
            // arrange
            decimal lovligVærdi = 300000m; // Lovlig værdi
            decimal forventet = 320000m;

            // act
            decimal resultat = _afgift.BilAfgift(lovligVærdi);

            // assert
            Assert.AreEqual(forventet, resultat);

        }
        [TestMethod]
        public void KaldMed_lovligVærdi_ØvreGrænse_returnereResultat_NormalBil()
        {
            // arrange
            decimal lovligVærdi = 200000m; // Lige på øvre grænse
            decimal forventet = 170000m;

            // act
            decimal resultat = _afgift.BilAfgift(lovligVærdi);

            // assert
            Assert.AreEqual(forventet, resultat);

        }

        [TestMethod]
        public void KaldMed_ulovligVærdi_UnderNul_kasterException_NormalBil()
        {

            // arrange
            decimal ulovligVærdi = -1m; // Lige under nul

            try
            {
                // Kalder BilAfgift med en negativ værdi og forventer at få en exception af typen ArgumentOutOfRangeException med tilhørende besked
                
                // act
                _afgift.BilAfgift(ulovligVærdi);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // Undersøger om beskeden der bliver smidt med exception er den samme som den jeg forventer

                // assert
                StringAssert.Contains(e.Message, Afgift.PrisErUnderNulBesked);
                return;
            }

            // Hvis nu værdien er lovlig vil jeg sikre mig at metoden fejler, så min test består
            Assert.Fail();
        }

        [TestMethod]
        public void KaldMed_ulovligVærdi_LigeOverGrænse_returnereResultat_NormalBil()
        {
            // arrange
            decimal lovligVærdi = 200001m; // Lige over grænsen - skal skifte til den anden udregning her
            decimal forventet = 170001.5m;

            // act
            decimal resultat = _afgift.BilAfgift(lovligVærdi);

            // assert
            Assert.AreEqual(forventet, resultat);

        }

        // -----------
        // Elbil test
        // -----------

        [TestMethod]
        public void KaldMed_lovligVærdi_returnereResultat_ElBil()
        {
            // arrange
            decimal lovligVærdi = 300000m; // Lovlig værdi
            decimal forventet = 64000m;

            // act
            decimal resultat = _afgift.ElBilAfgift(lovligVærdi);

            // assert
            Assert.AreEqual(forventet, resultat);

        }
        [TestMethod]
        public void KaldMed_lovligVærdi_ØvreGrænse_returnereResultat_ElBil()
        {
            // arrange
            decimal lovligVærdi = 200000m; // Lige på øvre grænse
            decimal forventet = 34000m;

            // act
            decimal resultat = _afgift.ElBilAfgift(lovligVærdi);

            // assert
            Assert.AreEqual(forventet, resultat);

        }

        [TestMethod]
        public void KaldMed_ulovligVærdi_UnderNul_kasterException_ElBil()
        {

            // arrange
            decimal ulovligVærdi = -1m; // Lige under nul

            try
            {
                // Kalder ElBilAfgift med en negativ værdi og forventer at få en exception af typen ArgumentOutOfRangeException med tilhørende besked

                // act
                _afgift.ElBilAfgift(ulovligVærdi);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // Undersøger om beskeden der bliver smidt med exception er den samme som den jeg forventer

                // assert
                StringAssert.Contains(e.Message, Afgift.PrisErUnderNulBesked);
                return;
            }

            // Hvis nu værdien er lovlig vil jeg sikre mig at metoden fejler, så min test består
            Assert.Fail();
        }

        [TestMethod]
        public void KaldMed_ulovligVærdi_LigeOverGrænse_returnereResultat_ElBil()
        {
            // arrange
            decimal lovligVærdi = 200001m; // Lige over grænsen - skal skifte til den anden udregning her
            decimal forventet = 34000.3m;

            // act
            decimal resultat = _afgift.ElBilAfgift(lovligVærdi);

            // assert
            Assert.AreEqual(forventet, resultat);

        }
    }
}

