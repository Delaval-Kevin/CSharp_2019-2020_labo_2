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
using Microsoft.Win32;

namespace ClubUI
{
    public partial class AjoutCircuit : Window
    {
        #region VARIABLES
        private Boolean _ajoutOK;
        private Circuit _nouvCircuit;
        private AppControler _controler;
        #endregion


        #region PROPRIETES
        public Boolean AjoutOK
        {
            get { return _ajoutOK; }
            set { _ajoutOK = value; }
        }

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
        public AjoutCircuit(AppControler controler)
        {
            InitializeComponent();
            Controler = controler;
            NouvCircuit = new Circuit
            {
                Photo = "C:\\Users\\delav\\Documents\\2eme annee\\C#\\labo-phase-3-Head-Splitter\\Dossier_2\\ClubUI\\Data\\CircuitParDefaut.png"
            };

            AjoutOK = false;
            CurentGrid.DataContext = NouvCircuit;
        }
        #endregion

        #region BOUTONS
        //Bouton pour valider l'ajout du circuit
        private void ButtonValider_Click(object sender, RoutedEventArgs e)
        {
            if (Controler.CircuitOk(NouvCircuit))
            {
                Controler.AjoutCircuit(NouvCircuit);
                AjoutOK = true;
                Close();
            }
            else
            {
                LabelErr.Content = "Veuillez remplir les champs correctements !";
            }
        }

        //Bouton pour annuler l'ajout de circuit
        private void ButtonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
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
