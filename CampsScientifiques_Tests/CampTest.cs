using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CampsScientifiques_Affaire;

namespace CampsScientifiques_Tests
{
    [TestClass]
    public class CampTest
    {
        private Camp _physiqueMecanique;
        private Camp _bioInformatique;

        [TestInitialize]
        public void initialisation()
        {
            _physiqueMecanique = new Camp("Physique mécanique", 1, 14);
            _bioInformatique = new Camp("Bio-informatique", 4, 17);

        }
        [TestMethod]
        public void Camp_TestCreation()
        {
            Assert.IsNotNull(_physiqueMecanique);
            Assert.AreEqual("Physique mécanique", _physiqueMecanique.Titre);
            Assert.AreEqual(1, _physiqueMecanique.NiveauRequis);
            Assert.AreEqual(14, _physiqueMecanique.AgeRequis);

            Assert.AreEqual("Bio-informatique", _bioInformatique.Titre);
            Assert.AreEqual(4, _bioInformatique.NiveauRequis);
            Assert.AreEqual(17, _bioInformatique.AgeRequis);
        }
    }
}
