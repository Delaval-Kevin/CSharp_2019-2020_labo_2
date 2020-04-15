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
    public partial class AjoutChrono : Window
    {
        #region VARIABLES
        private Boolean _ajoutOK;
        private Chronometre _nouvChrono;
        private AppControler _controler;
        #endregion


        #region PROPRIETES
        public Boolean AjoutOK
        {
            get { return _ajoutOK; }
            set { _ajoutOK = value; }
        }

        public Chronometre NouvChrono
        {
            get { return _nouvChrono; }
            set { _nouvChrono = value; }
        }

        public AppControler Controler
        {
            get { return _controler; }
            set { _controler = value; }
        }
        #endregion


        #region CONSTRUCTEURS
        public AjoutChrono(AppControler controler, Pilote user)
        {
            InitializeComponent();

            Controler = controler;

            ComboBoxNumLicence.ItemsSource = Controler.ListePilotes;
            ComboBoxNumLicence.SelectedItem = (Controler.RecherchePilote(user.NumLicence));
            ComboBoxNumCircuit.ItemsSource = Controler.ListeCircuits;
            ComboBoxNumCircuit.SelectedItem = Controler.ListeCircuits[0];
            ComboBoxCondClim.ItemsSource = Enum.GetValues(typeof(CondClim));
            ComboBoxCondClim.SelectedItem = CondClim.Soleil;
            ComboBoxEtatCirc.ItemsSource = Enum.GetValues(typeof(EtatCirc));
            ComboBoxEtatCirc.SelectedItem = EtatCirc.Sec;
            NouvChrono = new Chronometre
            {
                NumLicence = (Controler.RecherchePilote(user.NumLicence)).NumLicence,
                NumCircuit = Controler.ListeCircuits[0].NumCircuit,
                DateChrono = DateTime.Today,
            };

            AjoutOK = false;
            CurentGrid.DataContext = NouvChrono;
        }
        #endregion

        #region BOUTONS
        //Bouton pour valider l'ajout du chrono
        private void ButtonValider_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TextBoxMinutes.Text, out int min) && int.TryParse(TextBoxSecondes.Text, out int sec) && int.TryParse(TextBoxMiliemes.Text, out int mili))
            {
                NouvChrono.TempsChrono = new TimeSpan(0, 0, min, sec, mili);

                if (Controler.ChronoOk(NouvChrono))
                {
                    Controler.AjoutChrono(NouvChrono);
                    AjoutOK = true;
                    this.Close();
                }
                else
                {
                    LabelErr.Content = "Veuillez remplir les champs correctements !";
                }

            }
            else
            {
                LabelErr.Content = "Veuillez remplir les champs correctements !";
            }
        }

        //Bouton pour annuler l'ajout du chrono
        private void ButtonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
