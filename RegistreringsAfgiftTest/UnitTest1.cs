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
        public void KaldMed_lovligV�rdi_returnereResultat_NormalBil()
        {
            // arrange
            decimal lovligV�rdi = 300000m; // Lovlig v�rdi
            decimal forventet = 320000m;

            // act
            decimal resultat = _afgift.BilAfgift(lovligV�rdi);

            // assert
            Assert.AreEqual(forventet, resultat);

        }
        [TestMethod]
        public void KaldMed_lovligV�rdi_�vreGr�nse_returnereResultat_NormalBil()
        {
            // arrange
            decimal lovligV�rdi = 200000m; // Lige p� �vre gr�nse
            decimal forventet = 170000m;

            // act
            decimal resultat = _afgift.BilAfgift(lovligV�rdi);

            // assert
            Assert.AreEqual(forventet, resultat);

        }

        [TestMethod]
        public void KaldMed_ulovligV�rdi_UnderNul_kasterException_NormalBil()
        {

            // arrange
            decimal ulovligV�rdi = -1m; // Lige under nul

            try
            {
                // Kalder BilAfgift med en negativ v�rdi og forventer at f� en exception af typen ArgumentOutOfRangeException med tilh�rende besked
                
                // act
                _afgift.BilAfgift(ulovligV�rdi);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // Unders�ger om beskeden der bliver smidt med exception er den samme som den jeg forventer

                // assert
                StringAssert.Contains(e.Message, Afgift.PrisErUnderNulBesked);
                return;
            }

            // Hvis nu v�rdien er lovlig vil jeg sikre mig at metoden fejler, s� min test best�r
            Assert.Fail();
        }

        [TestMethod]
        public void KaldMed_ulovligV�rdi_LigeOverGr�nse_returnereResultat_NormalBil()
        {
            // arrange
            decimal lovligV�rdi = 200001m; // Lige over gr�nsen - skal skifte til den anden udregning her
            decimal forventet = 170001.5m;

            // act
            decimal resultat = _afgift.BilAfgift(lovligV�rdi);

            // assert
            Assert.AreEqual(forventet, resultat);

        }

        // -----------
        // Elbil test
        // -----------

        [TestMethod]
        public void KaldMed_lovligV�rdi_returnereResultat_ElBil()
        {
            // arrange
            decimal lovligV�rdi = 300000m; // Lovlig v�rdi
            decimal forventet = 64000m;

            // act
            decimal resultat = _afgift.ElBilAfgift(lovligV�rdi);

            // assert
            Assert.AreEqual(forventet, resultat);

        }
        [TestMethod]
        public void KaldMed_lovligV�rdi_�vreGr�nse_returnereResultat_ElBil()
        {
            // arrange
            decimal lovligV�rdi = 200000m; // Lige p� �vre gr�nse
            decimal forventet = 34000m;

            // act
            decimal resultat = _afgift.ElBilAfgift(lovligV�rdi);

            // assert
            Assert.AreEqual(forventet, resultat);

        }

        [TestMethod]
        public void KaldMed_ulovligV�rdi_UnderNul_kasterException_ElBil()
        {

            // arrange
            decimal ulovligV�rdi = -1m; // Lige under nul

            try
            {
                // Kalder ElBilAfgift med en negativ v�rdi og forventer at f� en exception af typen ArgumentOutOfRangeException med tilh�rende besked

                // act
                _afgift.ElBilAfgift(ulovligV�rdi);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // Unders�ger om beskeden der bliver smidt med exception er den samme som den jeg forventer

                // assert
                StringAssert.Contains(e.Message, Afgift.PrisErUnderNulBesked);
                return;
            }

            // Hvis nu v�rdien er lovlig vil jeg sikre mig at metoden fejler, s� min test best�r
            Assert.Fail();
        }

        [TestMethod]
        public void KaldMed_ulovligV�rdi_LigeOverGr�nse_returnereResultat_ElBil()
        {
            // arrange
            decimal lovligV�rdi = 200001m; // Lige over gr�nsen - skal skifte til den anden udregning her
            decimal forventet = 34000.3m;

            // act
            decimal resultat = _afgift.ElBilAfgift(lovligV�rdi);

            // assert
            Assert.AreEqual(forventet, resultat);

        }
    }
}

