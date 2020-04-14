/***********************************************************/
/*Auteur : DELAVAL Kevin                                   */
/*Groupe : 2203                                            */
/*Application : Gestion d'un club de motocross             */
/*Cours : C# - partie 3 du labo                            */
/*Date de la dernière mise à jour : 13/04/2020             */
/***********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClubObject
{
    public class Pilote
    {
        #region VARIABLES MEMBRES
        private string      _numLicence;
        private string      _photo;
        private string      _nom;
        private string      _prenom;
        private DateTime    _dateNaissance;
        private string      _adresse;
        private string      _localite;
        #endregion


        #region PROPRIETES
        public string NumLicence
        {
            get { return _numLicence; }
            set { _numLicence = value; }
        }

        public string Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }

        public DateTime DateNaissance
        {
            get { return _dateNaissance; }
            set { _dateNaissance = value; }
        }

        public string Adresse
        {
            get { return _adresse; }
            set { _adresse = value; }
        }

        public string Localite
        {
            get { return _localite; }
            set { _localite = value; }
        }
        #endregion


        #region CONSTRUCTEURS
        //Constructeur par défaut
        public Pilote() : this("PBE123456", "", "Dupond", "Jean", new DateTime(1980, 10, 02), "Rue cachee 25", "1000 Bruxelles") { }

        //Constructeur d'initialisation partiel
        public Pilote(string numLicence, string photo, string nom, string prenom) : this(numLicence, photo, nom, prenom, new DateTime(1, 1, 1), null, null) { }

        //Constructeur d'initialisation complet
        public Pilote(string numLicence, string photo, string nom, string prenom, DateTime dateNaissance, string adresse, string localite)
        {
            NumLicence = numLicence;
            Photo = photo;
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            Adresse = adresse;
            Localite = localite;
        }
        #endregion


        #region METHODES
        public override string ToString()
        {
            return "Numero de licence : " + "\nNom : " + Nom + "\nPrenom : " + Prenom + "\nDate de Naissance : " + DateNaissance + "\nAdresse : " + Adresse + "\nLocalite : " + Localite;
        }
        #endregion
    }
}
