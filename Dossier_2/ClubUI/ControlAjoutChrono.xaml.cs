/***********************************************************/
/*Auteur : DELAVAL Kevin                                   */
/*Groupe : 2203                                            */
/*Application : Gestion d'un club de motocross             */
/*Cours : C# - partie 3 du labo                            */
/*Date de la dernière mise à jour : 13/04/2020             */
/***********************************************************/

using MyClubObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClubUI
{
    public partial class ControlAjoutChrono : UserControl
    {
        #region EVENEMENTS
        public event Action<Chronometre> OnChronoApply;
        public event Action OnControlClose;
        #endregion

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
        public ControlAjoutChrono(AppControler controler, Pilote user)
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
                    Controler.MyStatBar.SetMessage("Chrono ajouté correctement");
                    OnChronoApply?.Invoke(NouvChrono);
                    OnControlClose?.Invoke();
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
            Controler.MyStatBar.SetWarning("Ajout du circuit annulé");
            OnControlClose?.Invoke();
        }
        #endregion

    }
}
