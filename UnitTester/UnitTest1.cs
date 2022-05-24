using Microsoft.VisualStudio.TestTools.UnitTesting;
using VisitorPlacementTool;
using System;
using System.Collections.Generic;

namespace UnitTester
{
    [TestClass]
    public class UnitTest1
    {
        Evenement? evenement;
        [TestInitialize]
        public void TestInIt()
        {
            evenement = new("Pop013");
            evenement.Vakken.Add(new Vak("A", 3, 5));
            evenement.Vakken.Add(new Vak("B", 3, 6));
            evenement.Vakken.Add(new Vak("C", 3, 6));
            evenement.Vakken.Add(new Vak("D", 3, 6));
        }
        [TestMethod]
        public void CheckJuisteVak()
        {
            //Arrange
            for (int i = 0; i < evenement.Vakken[0].BeschikbareStoelen;)
            {
                evenement.Vakken[0].AddBezoekerEerstLegeStoel(new Bezoeker(Convert.ToDateTime("01/06/2002")));
            }
            //Act
            Vak vb = evenement.Vakken[evenement.CheckAvailableVak(1)];
            //Assert
            Assert.AreEqual(evenement.Vakken[1].Naam, vb.Naam);
        }

        [TestMethod]
        public void CheckToevoegenEenBezoeker()
        {
            //Arrange
            Bezoeker bezoeker = new(Convert.ToDateTime("01/06/2002"));
            //Act
            evenement.AddBezoekerToStoel(bezoeker);
            //Assert
            Assert.AreEqual(bezoeker, evenement.Vakken[0].Stoelen[0].Bezoeker);
        }
        [TestMethod]
        public void CheckBenamingStoel()
        {
            //Arrange
           
            //Act

            //Assert
            Assert.AreEqual(evenement.Vakken[0].Stoelen[0].Stoelnaam, "A1-1");
            Assert.AreEqual(evenement.Vakken[0].Stoelen[1].Stoelnaam, "A1-2");
        }
        [TestMethod]
        public void VoegGroepAanEersteGeschikteVak()
        {
            //Arrange
            
            Bezoeker bezoeker = new(Convert.ToDateTime("01/06/2002"));
            List<Bezoeker> testlijstje = new();
            Bezoeker volwassen = new(Convert.ToDateTime("01/06/2002"));
            for (int i = 0; i < 4; i++)
            {
                testlijstje.Add(new Bezoeker(Convert.ToDateTime("01/06/2018")));
            }
            testlijstje.Add(volwassen);
            //Act

            evenement.AddBezoekerToStoel(bezoeker);
            evenement.AddGroupToStoelen(testlijstje);
            //Assert
            Assert.AreEqual(testlijstje[0], evenement.Vakken[1].Stoelen[0].Bezoeker);
        }

        [TestMethod]
        public void VoegMeerdereGroepenToe()
        {
            //Arrange
            List<Bezoeker> testlijstje = new();
            List<Bezoeker> testlijstje2 = new();
            Bezoeker volwassen = new(Convert.ToDateTime("01/06/2002"));
            Bezoeker volwassen2 = new(Convert.ToDateTime("01/06/2002"));
            for (int i = 0; i < 4; i++)
            {
                testlijstje.Add(new Bezoeker(Convert.ToDateTime("01/06/2018")));
                testlijstje2.Add(new Bezoeker(Convert.ToDateTime("01/06/2018")));
            }
            testlijstje.Add(volwassen);
            testlijstje2.Add(volwassen2);
            //Act
            evenement.AddGroupToStoelen(testlijstje);
            evenement.AddGroupToStoelen(testlijstje2);
            //Assert
            Assert.AreEqual(testlijstje[0],evenement.Vakken[1].Stoelen[0].Bezoeker);
            Assert.AreEqual(testlijstje[1],evenement.Vakken[1].Stoelen[1].Bezoeker);
            Assert.AreEqual(testlijstje[2],evenement.Vakken[1].Stoelen[2].Bezoeker);
            Assert.AreEqual(testlijstje[3],evenement.Vakken[1].Stoelen[3].Bezoeker);
            
            Assert.AreEqual(testlijstje2[0],evenement.Vakken[2].Stoelen[0].Bezoeker);
            Assert.AreEqual(testlijstje2[1],evenement.Vakken[2].Stoelen[1].Bezoeker);
            Assert.AreEqual(testlijstje2[2],evenement.Vakken[2].Stoelen[2].Bezoeker);
            Assert.AreEqual(testlijstje2[3],evenement.Vakken[2].Stoelen[3].Bezoeker);


        }
    }
}