using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CampsScientifiques_Affaire;

namespace CampsScientifiques_Tests
{
    [TestClass]
    public class JeuneTest
    {
        private DateTime _ddn15ans, _ddn18ans;
        private Jeune _adam, _charles;
        private Camp _physiqueMecanique, _genetique, _physiqueQuantique;

        [TestInitialize]
        public void initialiser()
        {
            _ddn15ans = DateTime.Now.AddYears(-15);
            _ddn18ans = DateTime.Now.AddYears(-18);
            _ddn15ans.AddMonths(-2);
            _ddn15ans.AddDays(-5);
            _adam = new Jeune("Adam Bernard", _ddn15ans, 4); //
            _charles = new Jeune("Charles Demers", _ddn18ans, 6);
            _physiqueMecanique = new Camp("Physique mécanique", 1, 14);
            _genetique = new Camp("Génétique", 6, 20);
            _physiqueQuantique = new Camp("Physique quantique", 5, 18);
        }

        [TestMethod]
        public void Jeune_TestCreation()
        {
            Assert.IsNotNull(_adam);
            Assert.AreEqual("Adam Bernard", _adam.Nom);
            Assert.AreEqual(4, _adam.NiveauComplete);
            Assert.AreEqual(_ddn15ans, _adam.DateNaissance);
        }
        [TestMethod]
        public void Jeune_TestCalculAge()
        {
            Assert.AreEqual(15, _adam.calculerAge());
            Assert.AreEqual(18, _charles.calculerAge());
        }
        [TestMethod]
        public void Jeune_TestAccessibilite()
        {
            Assert.IsTrue(_adam.aAgeRequis(_physiqueMecanique));
            Assert.IsFalse(_adam.aAgeRequis(_genetique));
            Assert.IsTrue(_charles.aAgeRequis(_physiqueMecanique));
            Assert.IsTrue(_charles.aAgeRequis(_physiqueQuantique));
            Assert.IsTrue(_adam.aNiveauRequis(_physiqueMecanique));
            Assert.IsFalse(_adam.aNiveauRequis(_genetique));
            Assert.IsTrue(_charles.aNiveauRequis(_physiqueMecanique));
            Assert.IsTrue(_charles.aNiveauRequis(_genetique));
            Assert.IsTrue(_adam.estAdmissible(_physiqueMecanique));
            Assert.IsFalse(_adam.estAdmissible(_genetique));
            Assert.IsFalse(_adam.estAdmissible(_physiqueQuantique));
            Assert.IsTrue(_charles.estAdmissible(_physiqueMecanique));
            Assert.IsFalse(_charles.estAdmissible(_genetique));
            Assert.IsTrue(_charles.estAdmissible(_physiqueQuantique));
        }
    }
}
