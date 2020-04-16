/***********************************************************/
/*Auteur : DELAVAL Kevin                                   */
/*Groupe : 2203                                            */
/*Application : Gestion d'un club de motocross             */
/*Cours : C# - partie 3 du labo                            */
/*Date de la dernière mise à jour : 13/04/2020             */
/***********************************************************/

using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

namespace MyClubObject
{
    public class AppControler
    {
        #region VARIABLES MEMBRES
        [XmlAttribute]
        private ObservableCollection<Pilote>        _listePilotes;
        [XmlAttribute]
        private ObservableCollection<Circuit>       _listeCircuits;
        [XmlAttribute]
        private ObservableCollection<Chronometre>   _listeChronos;

        private readonly string _pilotesFileName = @"C:\Users\delav\Documents\2eme annee\C#\labo-phase-3-Head-Splitter\Dossier_2\ClubUI\Data\listePilotes.xml";
        private readonly string _circuitsFileName = @"C:\Users\delav\Documents\2eme annee\C#\labo-phase-3-Head-Splitter\Dossier_2\ClubUI\Data\listeCircuits.xml";
        private readonly string _chronosFileName = @"C:\Users\delav\Documents\2eme annee\C#\labo-phase-3-Head-Splitter\Dossier_2\ClubUI\Data\listeChronos.xml";
        private MyStatusBar _myStatBar;
        #endregion


        #region PROPRIETES
        public ObservableCollection<Pilote> ListePilotes
        {
            get { return _listePilotes; }
            private set { _listePilotes = value; }
        }

        public ObservableCollection<Circuit> ListeCircuits
        {
            get { return _listeCircuits; }
            private set { _listeCircuits = value; }
        }

        public ObservableCollection<Chronometre> ListeChronos
        {
            get { return _listeChronos; }
            private set { _listeChronos = value; }
        }

        private string PilotesFileName
        {
            get { return _pilotesFileName; }
        }

        private string CircuitsFileName
        {
            get { return _circuitsFileName; }
        }

        private string ChronosFileName
        {
            get { return _chronosFileName; }
        }

        public MyStatusBar MyStatBar
        {
            get { return _myStatBar; }
            set { _myStatBar = value; }
        }
        #endregion


        #region CONSTRUCTEURS
        public AppControler()
        {
            ListePilotes = new ObservableCollection<Pilote>();
            ListeCircuits = new ObservableCollection<Circuit>();
            ListeChronos = new ObservableCollection<Chronometre>();
            MyStatBar = new MyStatusBar();
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

            #region FICHIER
            //Fonction pour charger les données au debut le l'application
            public void ChargementDonnees()
            {
                ChargementPilotes();
                ChargementCircuits();
                ChargementChronos();
            }

            //Fonction pour charger les pilotes
            public void ChargementPilotes()
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(ObservableCollection<Pilote>));
                using (Stream fStream = File.OpenRead(PilotesFileName)) 
                { 
                    ListePilotes = (ObservableCollection<Pilote>)xmlFormat.Deserialize(fStream); 
                }
            }

            //Fonction pour charger les circuits
            public void ChargementCircuits()
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(ObservableCollection<Circuit>));
                using (Stream fStream = File.OpenRead(CircuitsFileName))
                {
                    ListeCircuits = (ObservableCollection<Circuit>)xmlFormat.Deserialize(fStream);
                }
            }

            //Fonction pour charger les chronos
            public void ChargementChronos()
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(ObservableCollection<Chronometre>));
                using (Stream fStream = File.OpenRead(ChronosFileName))
                {
                    ListeChronos = (ObservableCollection<Chronometre>)xmlFormat.Deserialize(fStream);
                }
            }

            //Fonction pour charger les données au debut le l'application
            public void SauvegardeDonnees()
            {
                SauvegardePilotes();
                SauvegardeCircuits();
                SauvegardeChronos();
            }

            //Fonction pour charger les pilotes
            public void SauvegardePilotes()
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(ObservableCollection<Pilote>));
                using (Stream fStream = new FileStream(PilotesFileName, FileMode.Create, FileAccess.Write, FileShare.None)) 
                { 
                    xmlFormat.Serialize(fStream, ListePilotes); 
                }
            }

            //Fonction pour charger les circuits
            public void SauvegardeCircuits()
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(ObservableCollection<Circuit>));
                using (Stream fStream = new FileStream(CircuitsFileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    xmlFormat.Serialize(fStream, ListeCircuits);
                }
            }

            //Fonction pour charger les chronos
            public void SauvegardeChronos()
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(ObservableCollection<Chronometre>));
                using (Stream fStream = new FileStream(ChronosFileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    xmlFormat.Serialize(fStream, ListeChronos);
                }
            }
            #endregion

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
                return ListeCircuits.ToList<Circuit>().Find(circuit => circuit.NumCircuit == numcircuit);
            }
            #endregion

            #region VERIFICATION
            //Fonction qui vérifie que les données minimums requises sont remplies pour le pilote
            public Boolean PiloteOk(Pilote pilote)
            { 
                if(pilote.NumLicence != null && pilote.NumLicence.Length == 10 && pilote.Nom != null && pilote.Nom.Length > 0 && pilote.Prenom != null && pilote.Prenom.Length > 0 && pilote.Photo != null && pilote.Photo.Length > 0)
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
                if (chrono.TempsChrono!= null && chrono.TempsChrono.TotalSeconds > 0)
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
                SauvegardePilotes();
            }

            //Fonction qui permet d'ajouter un circuit à la liste
            public void AjoutCircuit(Circuit circuit)
            {
                ListeCircuits.Add(circuit);
            }

            //Fonction qui permet d'ajouter un chrono à la liste
            public void AjoutChrono(Chronometre chrono)
            {
                ListeChronos.Add(chrono);
            }
            #endregion

        #endregion
    }
}
