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
using System.Windows.Media;

namespace ClubUI
{
    public partial class MainWindow : Window
    {
        #region VARIABLES
        private AppControler _controler;
        private Pilote       _user;
        ControlAdmin         _admin;
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

        public ControlAdmin Admin
        {
            get { return _admin; }
            set { _admin = value; }
        }

        public Boolean AdminIsClose
        {
            get 
            { 
                if(Admin == null)
                {
                    return true;
                }
               return false;
            }
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
                SideListe.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Controler.MyRegist.GetValue(Params.ListFontColor)));
                SideListe.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Controler.MyRegist.GetValue(Params.ListBackColor)));
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            this.DataContext = Controler;
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
                    Controler.AjoutPilote(ajoutPilote.NouvPilote);
                }
                else
                {
                    Close();
                }
            }

            if (User != null)
            {
                this.Title = "Club Manager : " + User.Nom + " " + User.Prenom;
                Controler.MyStatBar.SetMessage("Bienvenue " + User.Nom + " " + User.Prenom);
            }
        }
        #endregion

        #region BOUTONS
        //Bouton d'ajout d'un chrono
        private void ButtonAjoutChrono_Click(object sender, RoutedEventArgs e)
        {
            if (Controler.ListeCircuits.Count > 0)
            {
                ControlAjoutChrono controlAjoutChrono = new ControlAjoutChrono(Controler, User);
                controlAjoutChrono.OnChronoApply += Controler.AjoutChrono;
                controlAjoutChrono.OnControlClose += Fenetre_OnControlClose;
                PrincipalControl.Content = controlAjoutChrono;
                Controler.MyStatBar.SetMessage("Vous allez ajouter un chrono");
            }
            else
            {
                Controler.MyStatBar.SetError("Ajout impossible, aucun circuit enregistré");
            }
        }

        //Bouton d'ajout d'un pilote
        private void ButtonAjoutPilote_Click(object sender, RoutedEventArgs e)
        {
            ControlAjoutPilote controlAjoutPilote = new ControlAjoutPilote(Controler);
            controlAjoutPilote.OnPiloteApply += Controler.AjoutPilote;
            controlAjoutPilote.OnControlClose += Fenetre_OnControlClose;
            PrincipalControl.Content = controlAjoutPilote;
            Controler.MyStatBar.SetMessage("Vous allez ajouter un pilote");
        }

        //Bouton d'ajout d'un circuit
        private void ButtonAjoutCircuit_Click(object sender, RoutedEventArgs e)
        {
            ControlAjoutCircuit controlAjoutCircuit = new ControlAjoutCircuit(Controler);
            controlAjoutCircuit.OnCircuitApply += Controler.AjoutCircuit;
            controlAjoutCircuit.OnControlClose += Fenetre_OnControlClose;
            PrincipalControl.Content = controlAjoutCircuit;
            Controler.MyStatBar.SetMessage("Vous allez ajouter un circuit");
        }

        //Bouton du mode admin
        private void ButtonAdmin_Click(object sender, RoutedEventArgs e)
        {
            ButtonFichier.IsEnabled = false;
            Pilote.IsEnabled = false;
            Circuit.IsEnabled = false;
            Admin = new ControlAdmin(Controler);
            Admin.OnControlClose += Fenetre_OnControlClose;
            PrincipalControl.Content = Admin;
            Controler.MyStatBar.SetWarning("ATTENTION vous êtes en mode ADMINISTRATEUR");
        }

        //Bouton pour sauvegarder les données
        private void ButtonEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            Controler.SauvegardeDonnees();
            Controler.MyStatBar.SetMessage("Données sauvegardées");
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
                Controler.MyStatBar.SetMessage("Bienvenue " + User.Nom + " " + User.Prenom);
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
            Option option = new Option(Controler);
            option.ColorChange += Option_colorChange;
            option.Show();
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

        //Double-click sur un élement de la liste
        private void SideListe_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (AdminIsClose)
            {
                if (SideListe.SelectedItem is Pilote pilote)
                {
                    ControlAffichePilote affichePilote = new ControlAffichePilote(Controler, pilote);
                    PrincipalControl.Content = affichePilote;
                }
                else if (SideListe.SelectedItem is Circuit circuit)
                {
                    ControlAfficheCircuit afficheCircuit = new ControlAfficheCircuit(Controler, circuit);
                    PrincipalControl.Content = afficheCircuit;
                }
            }
            else
            {
                Controler.MyStatBar.SetError("Fermer d'abord le mode administrateur");
            }
        }
        #endregion

        #region METHODES
        //Vide la grid principale
        private void Fenetre_OnControlClose()
        {
            PrincipalControl.Content = null;
            if(!AdminIsClose)
            {
                Admin = null;
                ButtonFichier.IsEnabled = true;
                Pilote.IsEnabled = true;
                Circuit.IsEnabled = true;
            }
        }

        //Fonction appelée par l'évenement de la fenetre option
        private void Option_colorChange(Color text, Color back)
        {
            SideListe.Foreground = new SolidColorBrush(text);
            SideListe.Background = new SolidColorBrush(back);
            Controler.MyStatBar.SetMessage("Options modifiées");
        }
        #endregion

    }
}
