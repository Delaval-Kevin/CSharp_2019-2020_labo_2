/***********************************************************/
/*Auteur : DELAVAL Kevin                                   */
/*Groupe : 2203                                            */
/*Application : Gestion d'un club de motocross             */
/*Cours : C# - partie 3 du labo                            */
/*Date de la dernière mise à jour : 17/04/2020             */
/***********************************************************/

using System;
using System.Windows;
using System.Windows.Media;


namespace ClubUI
{
    public partial class Option : Window
    {
        #region EVENEMENTS
        public event Action<Color, Color, String> ColorChange;
        #endregion

        #region CONSTRUCTEURS
        public Option(string pa)
        {
            InitializeComponent();
            path.Text = pa;
        }
        #endregion

        #region BOUTONS
        private void OK_Button(object sender, RoutedEventArgs e)
        {
            ColorChange?.Invoke(TextColor.Color, BackColor.Color, path.Text);
            this.Close();
        }

        private void Apply_Button(object sender, RoutedEventArgs e)
        {
            ColorChange?.Invoke(TextColor.Color, BackColor.Color, path.Text);
        }

        private void Cancel_Button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
