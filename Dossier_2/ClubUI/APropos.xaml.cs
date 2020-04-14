/***********************************************************/
/*Auteur : DELAVAL Kevin                                   */
/*Groupe : 2203                                            */
/*Application : Gestion d'un club de motocross             */
/*Cours : C# - partie 3 du labo                            */
/*Date de la dernière mise à jour : 13/04/2020             */
/***********************************************************/

using System.Windows;

namespace ClubUI
{
    public partial class APropos : Window
    {
        #region CONSTRUCTEURS
        public APropos()
        {
            InitializeComponent();
        }
        #endregion

        #region BOUTONS
        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
