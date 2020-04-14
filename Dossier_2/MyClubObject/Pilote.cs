/***********************************************************/
/*Auteur : DELAVAL Kevin                                   */
/*Groupe : 2203                                            */
/*Application : Gestion d'un club de motocross             */
/*Cours : C# - partie 3 du labo                            */
/*Date de la dernière mise à jour : 13/04/2020             */
/***********************************************************/

using System;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MyClubObject
{
    public class Pilote : INotifyPropertyChanged
    {
        #region EVENT
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

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
            set 
            {
                if( _numLicence != value)
                {
                    _numLicence = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NumLicence"));
                }
            }
        }

        public string Photo
        {
            get { return _photo; }
            set 
            {
                if (_photo != value)
                {
                    _photo = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Photo"));
                }
            }
        }

        public string Nom
        {
            get { return _nom; }
            set 
            {
                if (_nom != value)
                {
                    _nom = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Nom"));
                }
            }
        }

        public string Prenom
        {
            get { return _prenom; }
            set
            {
                if (_prenom != value)
                {
                    _prenom = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Prenom"));
                }
            }
        }

        public DateTime DateNaissance
        {
            get { return _dateNaissance; }
            set
            {
                if (_dateNaissance != value)
                {
                    _dateNaissance = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DateNaissance"));
                }
            }
        }

        public string Adresse
        {
            get { return _adresse; }
            set
            {
                if (_adresse != value)
                {
                    _adresse = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Adresse"));
                }
            }
        }

        public string Localite
        {
            get { return _localite; }
            set
            {
                if (_localite != value)
                {
                    _localite = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Localite"));
                }
            }
        }
        #endregion


        #region CONSTRUCTEURS
        //Constructeur par défaut
        public Pilote() { }

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
