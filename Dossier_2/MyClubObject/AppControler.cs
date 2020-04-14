/***********************************************************/
/*Auteur : DELAVAL Kevin                                   */
/*Groupe : 2203                                            */
/*Application : Gestion d'un club de motocross             */
/*Cours : C# - partie 3 du labo                            */
/*Date de la dernière mise à jour : 13/04/2020             */
/***********************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClubObject
{
    class AppControler
    {
        #region VARIABLES MEMBRES
        private ObservableCollection<Pilote>        _listePilotes;
        private ObservableCollection<Circuit>       _listeCircuit;
        private ObservableCollection<Chronometre>   _listeChrono;
        #endregion


        #region PROPRIETES
        public ObservableCollection<Pilote> ListePilotes
        {
            get { return _listePilotes; }
            private set { _listePilotes = value; }
        }

        public ObservableCollection<Circuit> ListeCircuit
        {
            get { return _listeCircuit; }
            private set { _listeCircuit = value; }
        }

        public ObservableCollection<Chronometre> ListeChrono
        {
            get { return _listeChrono; }
            private set { _listeChrono = value; }
        }
        #endregion


        #region CONSTRUCTEURS
        public AppControler()
        {
            ListePilotes = new ObservableCollection<Pilote>();
            ListeCircuit = new ObservableCollection<Circuit>();
            ListeChrono = new ObservableCollection<Chronometre>();
        }
        #endregion


        #region METHODES

        #endregion
    }
}
