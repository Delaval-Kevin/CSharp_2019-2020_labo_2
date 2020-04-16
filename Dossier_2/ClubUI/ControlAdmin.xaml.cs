/***********************************************************/
/*Auteur : DELAVAL Kevin                                   */
/*Groupe : 2203                                            */
/*Application : Gestion d'un club de motocross             */
/*Cours : C# - partie 3 du labo                            */
/*Date de la dernière mise à jour : 13/04/2020             */
/***********************************************************/

using MyClubObject;
using System.Windows.Controls;


namespace ClubUI
{
    public partial class ControlAdmin : UserControl
    {
        #region VARIABLES
        private AppControler _controler;
        #endregion

        #region PROPRIETES
        public AppControler Controler
        {
            get { return _controler; }
            set { _controler = value; }
        }
        #endregion

        #region CONSTRUCTEURS
        public ControlAdmin(AppControler controler)
        {
            InitializeComponent();
            Controler = controler;
            GridPilote.DataContext = Controler.ListePilotes;
            GridCircuit.DataContext = Controler.ListeCircuits;
        }
        #endregion

        #region BOUTONS

        #endregion

    }
}
