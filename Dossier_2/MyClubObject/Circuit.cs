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
    public class Circuit
    {
        #region VARIABLES MEMBRES
        private string _numCircuit;
        private string _nom;
        private string _photo;
        private string _adresse;
        private string _localite;
        #endregion


        #region PROPRIETES
        public string NumCircuit
        {
            get { return _numCircuit; }
            set { _numCircuit = value; }
        }

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public string Photo
        {
            get { return _photo; }
            set { _photo = value; }
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
        public Circuit() : this("TBE0001", null, "Dupond", "Rue de la perche 50", "6880 Bertrix") { }

        //Constructeur d'initialisation
        public Circuit(string numCircuit, string nom, string photo, string adresse, string localite)
        {
            NumCircuit = numCircuit;
            Nom = nom;
            Photo = photo;
            Adresse = adresse;
            Localite = localite;
        }
        #endregion


        #region METHODES
        public override string ToString()
        {
            return "Numero de circuit : " + NumCircuit + "\nNom : " + Nom + "\nAdresse : " + Adresse + "\nLocalite : " + Localite;
        }
        #endregion
    }
}
