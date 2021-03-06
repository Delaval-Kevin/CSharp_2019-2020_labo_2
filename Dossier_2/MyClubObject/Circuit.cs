﻿/***********************************************************/
/*Auteur : DELAVAL Kevin                                   */
/*Groupe : 2203                                            */
/*Application : Gestion d'un club de motocross             */
/*Cours : C# - partie 3 du labo                            */
/*Date de la dernière mise à jour : 02/05/2020             */
/***********************************************************/

using System.ComponentModel;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace MyClubObject
{
    public class Circuit : INotifyPropertyChanged
    {
        #region EVENT
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region VARIABLES MEMBRES
        [XmlAttribute]
        private string _numCircuit;
        [XmlAttribute]
        private string _nom;
        [XmlAttribute]
        private string _photo;
        [XmlAttribute]
        private string _adresse;
        [XmlAttribute]
        private string _localite;

        private List<Chronometre> _listeChrono;
        #endregion


        #region PROPRIETES
        public string NumCircuit
        {
            get { return _numCircuit; }
            set
            {
                if (_numCircuit != value)
                {
                    _numCircuit = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NumCircuit"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Affiche"));
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
        public Circuit() { }

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
            return "- N° : " + NumCircuit + " Nom : " + Nom;
        }
        #endregion
    }
}
