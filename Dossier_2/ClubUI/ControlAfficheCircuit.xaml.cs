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
    public partial class ControlAfficheCircuit : UserControl
    {
        #region VARIABLES
        private Circuit _circuit;
        private AppControler _controler;
        #endregion

        #region PROPRIETES
        public Circuit Circuit
        {
            get { return _circuit; }
            set { _circuit = value; }
        }

        public AppControler Controler
        {
            get { return _controler; }
            set { _controler = value; }
        }
        #endregion

        #region CONSTRUCTEURS
        public ControlAfficheCircuit(AppControler controler, Circuit circuit)
        {
            InitializeComponent();
            Controler = controler;
            Circuit = circuit;
            CurentGrid.DataContext = Circuit;
            ChronoGrid.DataContext = Controler.RechercheChronoCircuit(Circuit.NumCircuit);
        }
        #endregion
    }
}
