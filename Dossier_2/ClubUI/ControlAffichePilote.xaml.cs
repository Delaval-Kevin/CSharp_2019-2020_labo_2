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
    public partial class ControlAffichePilote : UserControl
    {
        #region VARIABLES
        private Pilote _pilote;
        private AppControler _controler;
        #endregion


        #region PROPRIETES
        public Pilote Pilote
        {
            get { return _pilote; }
            set { _pilote = value; }
        }

        public AppControler Controler
        {
            get { return _controler; }
            set { _controler = value; }
        }
        #endregion


        #region CONSTRUCTEURS
        public ControlAffichePilote(AppControler controler, Pilote pilote)
        {
            InitializeComponent();
            Controler = controler;
            Pilote = pilote;
            CurentGrid.DataContext = Pilote;
            ChronoGrid.DataContext = Controler.RechercheChronoPilote(Pilote.NumLicence);
        }
        #endregion
    }
}
