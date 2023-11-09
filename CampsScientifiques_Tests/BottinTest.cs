using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CampsScientifiques_Affaire;

namespace CampsScientifiques_Tests
{
    [TestClass]
    public class BottinTest
    {
        private DateTime _ddn15ans, _ddn18ans;
        private Jeune _adam, _charles, _eric;
        private Camp _physiqueMecanique, _genetique, _physiqueQuantique;
        private Camp _lasersMicroOndes, _electriciteMagnetisme, _supraConducteurs;
        private Camp _bioInformatique, _chimieIndustrielle, _chimieOrganique;
        private Bottin _bottin;

        [TestInitialize]
        public void initialiser()
        {
            _ddn15ans = DateTime.Now.AddYears(-15);
            _ddn18ans = DateTime.Now.AddYears(-18);
            _ddn15ans.AddMonths(-2);
            _ddn15ans.AddDays(-5);
            _adam = new Jeune("Adam Bernard", _ddn15ans, 4); //
            _charles = new Jeune("Charles Demers", _ddn18ans, 6);
            _eric = new Jeune("Eric Fillion", _ddn15ans.AddYears(2), 1); // 13 ans
            _physiqueMecanique = new Camp("Physique mécanique", 1, 14);
            _physiqueQuantique = new Camp("Physique quantique", 5, 18);
            _lasersMicroOndes = new Camp("Lasers et micro-ondes",3,16);
            _electriciteMagnetisme = new Camp("Électricité et magnétisme",3,16);
            _supraConducteurs = new Camp("Supra-conducteurs",4,17);
            _bioInformatique = new Camp("Bio-informatique", 4, 17);
            _chimieIndustrielle = new Camp("Chimie industrielle",1,13);
            _chimieOrganique = new Camp("Chimie organique",2,15);
            _genetique = new Camp("Génétique", 6, 20);
            _bottin = new Bottin();
        }
        [TestMethod]
        public void Bottin_TestCreation()
        {
            Assert.IsNotNull(_bottin);
            Assert.IsNotNull(_bottin.Camps);
            Assert.AreEqual(0, _bottin.Camps.Count);
        }
        [TestMethod]
        public void Bottin_TestAjoutsCamps()
        {
            Assert.AreEqual(0, _bottin.Camps.Count);
            _bottin.ajouterCamp(_physiqueMecanique);
            Assert.AreEqual(1, _bottin.Camps.Count);
            Assert.AreEqual(_physiqueMecanique, _bottin.Camps[0]);
            _bottin.ajouterCamp(_physiqueQuantique);
            Assert.AreEqual(2, _bottin.Camps.Count);
            Assert.AreEqual(_physiqueMecanique, _bottin.Camps[0]);
            Assert.AreEqual(_physiqueQuantique, _bottin.Camps[1]);
        }
        [TestMethod]
        public void Bottin_TestExtraction()
        {
            peuplerBottin();
            Assert.AreEqual(3, _bottin.extraireCampsAdmissibles(_adam).Count);
            Assert.AreEqual(8, _bottin.extraireCampsAdmissibles(_charles).Count);
            Assert.AreEqual(1, _bottin.extraireCampsAdmissibles(_eric).Count);
            Assert.AreEqual(_chimieIndustrielle, _bottin.extraireCampsAdmissibles(_eric)[0]);
        }

        [TestMethod]
        public void Bottin_TestDenombrement()
        {
            peuplerBottin();
            Assert.AreEqual(3, _bottin.denombrerCampsAdmissibles(_adam));
            Assert.AreEqual(8, _bottin.denombrerCampsAdmissibles(_charles));
            Assert.AreEqual(1, _bottin.denombrerCampsAdmissibles(_eric));

            Assert.AreEqual(2, _bottin.denombrerCamps(1));
            Assert.AreEqual(1, _bottin.denombrerCamps(2));
            Assert.AreEqual(2, _bottin.denombrerCamps(3));
            Assert.AreEqual(2, _bottin.denombrerCamps(4));
            Assert.AreEqual(1, _bottin.denombrerCamps(5));
            Assert.AreEqual(1, _bottin.denombrerCamps(6));
            Assert.AreEqual(0, _bottin.denombrerCamps(7));
        }
        [TestMethod]
        public void Bottin_TestAgeMinCamps()
        {
            peuplerBottin();
            Assert.AreEqual(13, _bottin.determinerAgeMinRequis(1));
            Assert.AreEqual(15, _bottin.determinerAgeMinRequis(2));
            Assert.AreEqual(16, _bottin.determinerAgeMinRequis(3));
            Assert.AreEqual(17, _bottin.determinerAgeMinRequis(4));
            Assert.AreEqual(18, _bottin.determinerAgeMinRequis(5));
            Assert.AreEqual(20, _bottin.determinerAgeMinRequis(6));
            Assert.AreEqual(0, _bottin.determinerAgeMinRequis(7));
        }

        public void peuplerBottin()
        {
            _bottin.ajouterCamp(_physiqueMecanique);
            _bottin.ajouterCamp(_lasersMicroOndes);
            _bottin.ajouterCamp(_physiqueQuantique);
            _bottin.ajouterCamp(_electriciteMagnetisme);
            _bottin.ajouterCamp(_supraConducteurs);
            _bottin.ajouterCamp(_bioInformatique);
            _bottin.ajouterCamp(_chimieIndustrielle);
            _bottin.ajouterCamp(_chimieOrganique);
            _bottin.ajouterCamp(_genetique);
        }
    }
}
