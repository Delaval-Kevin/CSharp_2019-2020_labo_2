/***********************************************************/
/*Auteur : DELAVAL Kevin                                   */
/*Groupe : 2203                                            */
/*Application : Gestion d'un club de motocross             */
/*Cours : C# - partie 3 du labo                            */
/*Date de la dernière mise à jour : 13/04/2020             */
/***********************************************************/

using System;
using System.Text;
using System.Linq;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MyClubObject
{
    public class Circuit : INotifyPropertyChanged
    {
        #region EVENT
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

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
            set
            {
                if (_numCircuit != value)
                {
                    _numCircuit = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NumCircuit"));
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
            return "Numero de circuit : " + NumCircuit + "\nNom : " + Nom + "\nAdresse : " + Adresse + "\nLocalite : " + Localite;
        }
        #endregion
    }
}
