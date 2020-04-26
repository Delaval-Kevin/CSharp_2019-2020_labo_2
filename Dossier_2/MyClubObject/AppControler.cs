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
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

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

        private readonly string _pilotesFileName = @"\listePilotes.xml";
        private readonly string _circuitsFileName = @"\listeCircuits.xml";
        private readonly string _chronosFileName = @"\listeChronos.dat";
        private MyStatusBar _myStatBar;
        private MyRegistry _myRegistry;
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

        public string PilotesFileName
        {
            get { return _pilotesFileName; }
        }

        public string CircuitsFileName
        {
            get { return _circuitsFileName; }
        }

        public string ChronosFileName
        {
            get { return _chronosFileName; }
        }

        public MyStatusBar MyStatBar
        {
            get { return _myStatBar; }
            set { _myStatBar = value; }
        }

        public MyRegistry MyRegist
        {
            get { return _myRegistry; }
            set { _myRegistry = value; }
        }
        #endregion


        #region CONSTRUCTEURS
        public AppControler()
        {
            ListePilotes = new ObservableCollection<Pilote>();
            ListeCircuits = new ObservableCollection<Circuit>();
            ListeChronos = new ObservableCollection<Chronometre>();
            MyStatBar = new MyStatusBar();
            MyRegist = new MyRegistry();
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
                using (Stream fStream = File.OpenRead(MyRegist.GetValue(Params.SavePath) + PilotesFileName)) 
                { 
                    ListePilotes = (ObservableCollection<Pilote>)xmlFormat.Deserialize(fStream); 
                }
            }

            //Fonction pour charger les circuits
            public void ChargementCircuits()
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(ObservableCollection<Circuit>));
                using (Stream fStream = File.OpenRead(MyRegist.GetValue(Params.SavePath) + CircuitsFileName))
                {
                    ListeCircuits = (ObservableCollection<Circuit>)xmlFormat.Deserialize(fStream);
                }
            }

            //Fonction pour charger les chronos
            public void ChargementChronos()
            {
                BinaryFormatter binFormat = new BinaryFormatter();
                using (Stream fstream = File.OpenRead(MyRegist.GetValue(Params.SavePath) + ChronosFileName))
                {
                    ListeChronos = (ObservableCollection<Chronometre>)binFormat.Deserialize(fstream);
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
                using (Stream fStream = new FileStream(MyRegist.GetValue(Params.SavePath) + PilotesFileName, FileMode.Create, FileAccess.Write, FileShare.None)) 
                { 
                    xmlFormat.Serialize(fStream, ListePilotes); 
                }
            }

            //Fonction pour charger les circuits
            public void SauvegardeCircuits()
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(ObservableCollection<Circuit>));
                using (Stream fStream = new FileStream(MyRegist.GetValue(Params.SavePath) + CircuitsFileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    xmlFormat.Serialize(fStream, ListeCircuits);
                }
            }

            //Fonction pour charger les chronos
            public void SauvegardeChronos()
            {
                BinaryFormatter binFormat = new BinaryFormatter();
                using (Stream fStream = new FileStream(MyRegist.GetValue(Params.SavePath) + ChronosFileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    binFormat.Serialize(fStream, ListeChronos);
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

            //Fonction qui retourne la liste de tous les chronos du pilote avec son numéro de licence
            public List<Chronometre> RechercheChronoPilote(string numlicence)
            {
                return ListeChronos.ToList<Chronometre>().FindAll(chrono => chrono.NumLicence == numlicence);
            }

            //Fonction qui retourne la liste de tous les chronos du circuit avec son numéro de circuit
            public List<Chronometre> RechercheChronoCircuit(string numcircuit)
            {
                return ListeChronos.ToList<Chronometre>().FindAll(chrono => chrono.NumCircuit == numcircuit);
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

            //Fonction qui vérifie l'intégrité des listes après le mode admin
            public void VerifListes()
            {
                VerifListePilotes();
                VerifListeCircuits();
                VerifListeChronos();
            }

            //Fonction qui vérifie l'intégrité de la liste des pilotes
            public void VerifListePilotes()
            {
                int count = ListePilotes.Count;
                int i = 0;
                while (i < count)
                {
                    if(!PiloteOk(ListePilotes[i]))
                    {
                        ListePilotes.Remove(ListePilotes[i]);
                        count = ListePilotes.Count;
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            //Fonction qui vérifie l'intégrité de la liste des circuits
            public void VerifListeCircuits()
            {
                int count = ListeCircuits.Count;
                int i = 0;
                while (i < count)
                {
                    if (!CircuitOk(ListeCircuits[i]))
                    {
                        ListeCircuits.Remove(ListeCircuits[i]);
                        count = ListeCircuits.Count;
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            //Fonction qui vérifie l'intégrité de la liste des chronos
            public void VerifListeChronos()
            {
                int count = ListeChronos.Count;
                int i = 0;
                while (i < count)
                {
                    if (!ChronoOk(ListeChronos[i]) || RecherchePilote(ListeChronos[i].NumLicence) == null || RechercheCircuit(ListeChronos[i].NumCircuit) == null)
                    {
                        ListeChronos.Remove(ListeChronos[i]);
                        count = ListeChronos.Count;
                    }
                    else
                    {
                        i++;
                    }
                }
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
