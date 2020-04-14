/***********************************************************/
/*Auteur : DELAVAL Kevin                                   */
/*Groupe : 2203                                            */
/*Application : Gestion d'un club de motocross             */
/*Cours : C# - partie 3 du labo                            */
/*Date de la dernière mise à jour : 13/04/2020             */
/***********************************************************/

using MyClubObject;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;


namespace ClubUI
{
    public partial class Login : Window
    {
        #region VARIABLES
        private bool _errorN = false;
        private bool _errorP = false;
        #endregion


        #region PROPRIETES
        public bool ErrorN
        {
            get { return _errorN; }
            set { _errorN = value; }
        }

        public bool ErrorP
        {
            get { return _errorP; }
            set { _errorP = value; }
        }

        public string Nom
        {
            get { return BoxNom.Text; }
            set { BoxNom.Text = value; }
        }

        public string Prenom
        {
            get { return BoxPrenom.Text; }
            set { BoxPrenom.Text = value; }
        }
        #endregion

        #region CONSTRUCTEURS
        public Login()
        {
            InitializeComponent();
        }
        #endregion

        #region BOUTONS
        //Button de validation du nom et prénom
        private void ButtonValider_Click(object sender, RoutedEventArgs e)
        {
            //Vefification si la TextBox est vide 
            if (AppControler.ChaineVide(Nom) || AppControler.ChaineVide(Prenom))
            {
                if (AppControler.ChaineVide(Nom))
                {
                    Nom = "Please enter your first name";
                    BoxNom.SetCurrentValue(ForegroundProperty, Brushes.Red);
                    ErrorN = true;
                }
                if (AppControler.ChaineVide(Prenom))
                {
                    Prenom = "Please enter your last name";
                    BoxPrenom.SetCurrentValue(ForegroundProperty, Brushes.Red);
                    ErrorP = true;
                }
            }
            else
            {
                if (ErrorN == false && ErrorP == false)
                {
                    this.Close();
                }
            }
        }
        #endregion

        #region EVENTS
        //Evenement pour effacer le contenu si erreur
        private void MouseEnter_Event(object sender, System.Windows.Input.MouseEventArgs e)
        {
            TextBox tmp = sender as TextBox;

            if (ErrorN == true && tmp == BoxNom)
            {
                tmp.Text = "";
                tmp.SetCurrentValue(ForegroundProperty, Brushes.WhiteSmoke);
                ErrorN = false;
            }
            if (ErrorP == true && tmp == BoxPrenom)
            {
                tmp.Text = "";
                tmp.SetCurrentValue(ForegroundProperty, Brushes.WhiteSmoke);
                ErrorP = false;
            }
        }
        #endregion
    }
}
