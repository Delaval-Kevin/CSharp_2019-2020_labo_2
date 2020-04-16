/***********************************************************/
/*Auteur : DELAVAL Kevin                                   */
/*Groupe : 2203                                            */
/*Application : Gestion d'un club de motocross             */
/*Cours : C# - partie 3 du labo                            */
/*Date de la dernière mise à jour : 13/04/2020             */
/***********************************************************/

using Microsoft.Win32;
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
    public partial class ControlAjoutCircuit : UserControl
    {
        #region EVENEMENTS
        public event Action<Circuit> OnCircuitApply;
        public event Action OnControlClose;
        #endregion

        #region VARIABLES
        private Circuit _nouvCircuit;
        private AppControler _controler;
        #endregion

        #region PROPRIETES
        public Circuit NouvCircuit
        {
            get { return _nouvCircuit; }
            set { _nouvCircuit = value; }
        }

        public AppControler Controler
        {
            get { return _controler; }
            set { _controler = value; }
        }
        #endregion

        #region CONSTRUCTEURS
        public ControlAjoutCircuit(AppControler controler)
        {
            InitializeComponent();
            Controler = controler;
            NouvCircuit = new Circuit
            {
                Photo = "C:\\Users\\delav\\Documents\\2eme annee\\C#\\labo-phase-3-Head-Splitter\\Dossier_2\\ClubUI\\Data\\CircuitParDefaut.png"
            };

            CurentGrid.DataContext = NouvCircuit;
        }
        #endregion

        #region BOUTONS
        //Bouton pour valider l'ajout du circuit
        private void ButtonValider_Click(object sender, RoutedEventArgs e)
        {
            if (Controler.CircuitOk(NouvCircuit))
            {
                Controler.MyStatBar.SetMessage("Circuit ajouté correctement");
                OnCircuitApply?.Invoke(NouvCircuit);
                OnControlClose?.Invoke();
            }
            else
            {
                LabelErr.Content = "Veuillez remplir les champs correctements !";
            }
        }

        //Bouton pour annuler l'ajout de circuit
        private void ButtonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            Controler.MyStatBar.SetWarning("Ajout du circuit annulé");
            OnControlClose?.Invoke();
        }

        //Bouton pour ajouter une photo
        private void ButtonPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                NouvCircuit.Photo = openFileDialog.FileName;
            }
        }
        #endregion
    }
}
