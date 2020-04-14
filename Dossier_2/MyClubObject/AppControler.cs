/***********************************************************/
/*Auteur : DELAVAL Kevin                                   */
/*Groupe : 2203                                            */
/*Application : Gestion d'un club de motocross             */
/*Cours : C# - partie 3 du labo                            */
/*Date de la dernière mise à jour : 13/04/2020             */
/***********************************************************/

using System;
using System.Linq;
using System.Collections.ObjectModel;

namespace MyClubObject
{
    public class AppControler
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


        #region METHODES STATIQUES
        //Fonction statique qui permet de voir si une chaine de caractère est vide ou non
        public static Boolean ChaineVide(string chaine)
        { 
            if(chaine.Length > 0)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region METHODES

            #region RECHERCHE
            //Fonction de recherche d'un pilote par numéro de licence
            public Pilote RecherchePilote(string numlicence)
            {
                return ListePilotes.ToList<Pilote>().Find(pilote => pilote.NumLicence == numlicence);
            }

            //Fonction de recherche d'un pilote par nom et prénom
            public Pilote RecherchePilote(string nom, string prenom)
            {
                return ListePilotes.ToList<Pilote>().Find(pilote => pilote.Nom == nom && pilote.Prenom == prenom);
            }

            //Fonction de recherche d'un circuit par numero de circuit
            public Circuit RechercheCircuit(string numcircuit)
            {
                return ListeCircuit.ToList<Circuit>().Find(circuit => circuit.NumCircuit == numcircuit);
            }
            #endregion

            #region VERIFICATION
            //Fonction qui vérifie que les données minimums requises sont remplies pour le pilote
            public Boolean PiloteOk(Pilote pilote)
            { 
                if(pilote.NumLicence != null && pilote.NumLicence.Length == 10 && pilote.Nom.Length > 0 && pilote.Prenom.Length > 0 && pilote.Photo.Length > 0)
                {
                    return true;
                }
                return false;
            }

            //Fonction qui vérifie que les données minimums requises sont remplies pour le circuit
            public Boolean CircuitOk(Circuit circuit)
            {
                if (circuit.NumCircuit != null && circuit.NumCircuit.Length == 8 && circuit.Nom != null && circuit.Nom.Length > 0)
                {
                    return true;
                }
                return false;
            }

            //Fonction qui vérifie que les données minimums requises sont remplies pour le chrono
            public Boolean ChronoOk(Chronometre chrono)
            {
                if (chrono.TempsChrono.TotalSeconds > 0)
                {
                    return true;
                }
                return false;
            }
            #endregion

            #region AJOUT
            //Fonction qui permet d'ajouter un pilote à la liste
            public void AjoutPilote(Pilote pilote)
            {
                ListePilotes.Add(pilote);
            }

            //Fonction qui permet d'ajouter un circuit à la liste
            public void AjoutCircuit(Circuit circuit)
            {
                ListeCircuit.Add(circuit);
            }

            //Fonction qui permet d'ajouter un chrono à la liste
            public void AjoutChrono(Chronometre chrono)
            {
                ListeChrono.Add(chrono);
            }
            #endregion

        #endregion
    }
}
