﻿/***********************************************************/
/*Auteur : DELAVAL Kevin                                   */
/*Groupe : 2203                                            */
/*Application : Gestion d'un club de motocross             */
/*Cours : C# - partie 3 du labo                            */
/*Date de la dernière mise à jour : 02/05/2020             */
/***********************************************************/

using System;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace MyClubObject
{
    public class Pilote : INotifyPropertyChanged
    {
        #region EVENT
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region VARIABLES MEMBRES
        [XmlAttribute]
        private string      _numLicence;
        [XmlAttribute]
        private string      _photo;
        [XmlAttribute]
        private string      _nom;
        [XmlAttribute]
        private string      _prenom;
        [XmlAttribute]
        private DateTime    _dateNaissance;
        [XmlAttribute]
        private string      _adresse;
        [XmlAttribute]
        private string      _localite;

        private List<Chronometre> _listeChrono;
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
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Affiche"));
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
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Affiche"));
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
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Affiche"));
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

        public List<Chronometre> ListeChrono
        {
            get { return _listeChrono; }
            set { _listeChrono = value; }
        }

        public string Affiche
        {
            get { return this.ToString(); }
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
            return "- N° : " + NumLicence + " Nom : " + Nom + " " + Prenom;
        }
        #endregion
    }
}
