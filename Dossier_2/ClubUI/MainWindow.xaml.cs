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
using MyClubObject;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

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

            Login login = new Login();
            login.ShowDialog();

            User = Controler.RecherchePilote(login.Nom, login.Prenom);

            if(User == null)
            {
                AjoutPilote ajoutPilote = new AjoutPilote(Controler, login.Nom, login.Prenom);
                ajoutPilote.ShowDialog();


                if(ajoutPilote.NouvPilote == null)
                {
                    Close();
                }

                User = ajoutPilote.NouvPilote;
            }

            if (User != null)
            {
                this.Title = "Club Manager : " + User.Nom + " " + User.Prenom;
            }
        }
        #endregion

        #region BOUTONS
        //Bouton d'ajout d'un chrono
        private void ButtonAjoutChrono_Click(object sender, RoutedEventArgs e)
        {
            AjoutChrono ajoutChrono = new AjoutChrono(Controler);
            ajoutChrono.ShowDialog();
        }

        //Bouton d'ajout d'un pilote
        private void ButtonAjoutPilote_Click(object sender, RoutedEventArgs e)
        {
            AjoutPilote ajoutPilote = new AjoutPilote(Controler);
            ajoutPilote.ShowDialog();
        }

        //Bouton d'ajout d'un circuit
        private void ButtonAjoutCircuit_Click(object sender, RoutedEventArgs e)
        {
            AjoutCircuit ajoutCircuit = new AjoutCircuit(Controler);
            ajoutCircuit.ShowDialog();
        }

        //Bouton de modification d'un pilote
        private void ButtonModifPilote_Click(object sender, RoutedEventArgs e)
        {

        }

        //Bouton de modification d'un circuit
        private void ButtonModifCircuit_Click(object sender, RoutedEventArgs e)
        {

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

                if (ajoutPilote.NouvPilote == null)
                {
                    Close();
                }

                User = ajoutPilote.NouvPilote;
            }

            if (User != null)
            {
                this.Title = "Club Manager : " + User.Nom + " " + User.Prenom;
                this.Show();
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
        #endregion

    }
}
