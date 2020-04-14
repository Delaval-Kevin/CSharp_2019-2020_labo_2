/***********************************************************/
/*Auteur : DELAVAL Kevin                                   */
/*Groupe : 2203                                            */
/*Application : Gestion d'un club de motocross             */
/*Cours : C# - partie 3 du labo                            */
/*Date de la dernière mise à jour : 13/04/2020             */
/***********************************************************/

using MyClubObject;
using System.Windows;

namespace ClubUI
{
    public partial class AjoutChrono : Window
    {
        #region VARIABLES
        private Chronometre _nouvChrono;
        private AppControler _controler;
        #endregion


        #region PROPRIETES
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
        public AjoutChrono(AppControler controler)
        {
            InitializeComponent();

            Controler = controler;
            NouvChrono = new Chronometre();
        }
        #endregion

        #region BOUTONS
        //Bouton pour valider l'ajout du chrono
        private void ButtonValider_Click(object sender, RoutedEventArgs e)
        {

        }

        //Bouton pour annuler l'ajout du chrono
        private void ButtonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
