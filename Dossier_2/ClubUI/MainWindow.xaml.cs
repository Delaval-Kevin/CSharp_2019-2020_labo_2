/***********************************************************/
/*Auteur : DELAVAL Kevin                                   */
/*Groupe : 2203                                            */
/*Application : Gestion d'un club de motocross             */
/*Cours : C# - partie 3 du labo                            */
/*Date de la dernière mise à jour : 13/04/2020             */
/***********************************************************/


using System;
using MyClubObject;
using System.Windows;


namespace ClubUI
{
    public partial class MainWindow : Window
    {
        #region VARIABLES
        private AppControler _controler;
        private Pilote       _user;
        #endregion


        #region PROPRIETES
        public AppControler Controler
        {
            get { return _controler; }
            set { _controler = value; }
        }

        public Pilote User
        {
            get { return _user; }
            set { _user = value; }
        }
        #endregion


        #region CONSTRUCTEURS
        public MainWindow()
        {
            InitializeComponent();
            Controler = new AppControler();
            try
            {
                Controler.ChargementDonnees();
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            SideListe.ItemsSource = Controler.ListePilotes;

            Login login = new Login();
            login.ShowDialog();

            User = Controler.RecherchePilote(login.Nom, login.Prenom);

            if(User == null)
            {
                AjoutPilote ajoutPilote = new AjoutPilote(Controler, login.Nom, login.Prenom);
                ajoutPilote.ShowDialog();


                if(ajoutPilote.AjoutOK)//verifie si l'ajout du pilote est OK
                {
                    User = ajoutPilote.NouvPilote;
                }
                else
                {
                    Close();
                }
            }

            if (User != null)
            {
                this.Title = "Club Manager : " + User.Nom + " " + User.Prenom;
                StatBar.Text = "Bienvenue " + User.Nom + " " + User.Prenom;
            }
        }
        #endregion

        #region BOUTONS
        //Bouton d'ajout d'un chrono
        private void ButtonAjoutChrono_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(Controler.ListeCircuits.Count);
            if (Controler.ListeCircuits.Count > 0)
            {
                AjoutChrono ajoutChrono = new AjoutChrono(Controler, User);
                ajoutChrono.ShowDialog();

                if (ajoutChrono.AjoutOK)//verifie si l'ajout du pilote est OK
                {
                    StatBar.Text = "Chrono ajouté correctement";
                    Controler.SauvegardeChronos();
                }
                else
                {
                    StatBar.Text = "Ajout annulé";
                }
            }
            else
            {
                StatBar.Text = "Ajout impossible, aucun circuit enregistré";
            }
        }

        //Bouton d'ajout d'un pilote
        private void ButtonAjoutPilote_Click(object sender, RoutedEventArgs e)
        {
            AjoutPilote ajoutPilote = new AjoutPilote(Controler);
            ajoutPilote.ShowDialog();

            if (ajoutPilote.AjoutOK)//verifie si l'ajout du pilote est OK
            {
                StatBar.Text = "Pilote ajouté correctement";
                Controler.SauvegardePilotes();
            }
            else 
            {
                StatBar.Text = "Ajout annulé";
            }
        }

        //Bouton d'ajout d'un circuit
        private void ButtonAjoutCircuit_Click(object sender, RoutedEventArgs e)
        {
            AjoutCircuit ajoutCircuit = new AjoutCircuit(Controler);
            ajoutCircuit.ShowDialog();

            if (ajoutCircuit.AjoutOK)//verifie si l'ajout du pilote est OK
            {
                StatBar.Text = "Circuit ajouté correctement";
                Controler.SauvegardeCircuits();
            }
            else
            {
                StatBar.Text = "Ajout annulé";
            }
        }

        //Bouton de modification d'un pilote
        private void ButtonModifPilote_Click(object sender, RoutedEventArgs e)
        {

        }

        //Bouton de modification d'un circuit
        private void ButtonModifCircuit_Click(object sender, RoutedEventArgs e)
        {

        }

        //Bouton pour sauvegarder les données
        private void ButtonEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            Controler.SauvegardeDonnees();
            StatBar.Text = "Données sauvegardées";
        }

        //Bouton pour ce déconnecter
        private void ButtonDeconnecter_Click(object sender, RoutedEventArgs e)
        {
            User = null;

            this.Hide();

            Login login = new Login();
            login.ShowDialog();

            User = Controler.RecherchePilote(login.Nom, login.Prenom);

            if (User == null)
            {
                AjoutPilote ajoutPilote = new AjoutPilote(Controler, login.Nom, login.Prenom);
                ajoutPilote.ShowDialog();

                if (ajoutPilote.AjoutOK)//verifie si l'ajout du pilote est OK
                {
                    User = ajoutPilote.NouvPilote;
                }
                else
                {
                    Close();
                }
            }

            if (User != null)
            {
                this.Title = "Club Manager : " + User.Nom + " " + User.Prenom;
                this.Show();
                StatBar.Text = "Bienvenue " + User.Nom + " " + User.Prenom;
            }
        }

        //Bouton pour quitter
        private void ButtonQuitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Bouton pour la fenêtre d'option
        private void ButtonOption_Click(object sender, RoutedEventArgs e)
        {

        }

        //Bouton pour la box à propos
        private void ButtonAPropos_Click(object sender, RoutedEventArgs e)
        {
            APropos aPropos = new APropos();
            aPropos.ShowDialog();
        }

        //Bouton radio Pilote checked
        private void Pilote_Click(object sender, RoutedEventArgs e)
        {
            SideListe.ItemsSource = Controler.ListePilotes;
        }

        //Bouton radio Circuit checked 
        private void Circuit_Click(object sender, RoutedEventArgs e)
        {
            SideListe.ItemsSource = Controler.ListeCircuits;
        }
        #endregion
    }
}
