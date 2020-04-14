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
    public partial class AjoutPilote : Window
    {
        #region VARIABLES
        private Pilote _nouvPilote;
        private AppControler _controler;
        #endregion


        #region PROPRIETES
        public Pilote NouvPilote
        {
            get { return _nouvPilote; }
            set { _nouvPilote = value; }
        }

        public AppControler Controler
        {
            get { return _controler; }
            set { _controler = value; }
        }
        #endregion


        #region CONSTRUCTEURS
        //Constructeur par défaut
        public AjoutPilote(AppControler controler) : this(controler, null, null) { }

        //Constructeur d'initialisation
        public AjoutPilote(AppControler controler, string nom, string prenom)
        {
            InitializeComponent();
            Controler = controler;
            NouvPilote = new Pilote
            {
                Nom = nom,
                Prenom = prenom
            };

            CurrentGrid.DataContext = NouvPilote;
        }
        #endregion

        #region BOUTONS
        //Bouton pour valider l'ajout du pilote
        private void ButtonValider_Click(object sender, RoutedEventArgs e)
        {
            if(Controler.PiloteOk(NouvPilote))
            {
                Controler.AjoutPilote(NouvPilote);
                this.Close();
            }
            else
            {

            }
        }

        //Bouton pour annuler l'ajout du pilote
        private void ButtonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            NouvPilote = null;
            this.Close();
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
                NouvPilote.Photo = openFileDialog.FileName;
            }
        }
        #endregion

    }
}
