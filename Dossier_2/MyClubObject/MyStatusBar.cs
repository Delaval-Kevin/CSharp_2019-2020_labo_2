/***********************************************************/
/*Auteur : DELAVAL Kevin                                   */
/*Groupe : 2203                                            */
/*Application : Gestion d'un club de motocross             */
/*Cours : C# - partie 3 du labo                            */
/*Date de la dernière mise à jour : 13/04/2020             */
/***********************************************************/

using System.Windows.Media;
using System.ComponentModel;

namespace MyClubObject
{
    public class MyStatusBar : INotifyPropertyChanged
    {
        #region EVENT
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region VARIABLES MEMBRES
        private string _message;
        private int _taille;
        private Color _couleur;
        #endregion

        #region PROPRIETES
        public string Message
        {
            get { return _message; }
            set
            {
                if (_message != value)
                {
                    _message = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Message"));
                }
            }
        }

        public int Taille
        {
            get { return _taille; }
            set
            {
                if (_taille != value)
                {
                    _taille = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Taille"));
                }
            }
        }

        public Color Couleur
        {
            get { return _couleur; }
            set
            {
                if (_couleur != value)
                {
                    _couleur = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Couleur"));
                }
            }
        }
        #endregion

        #region CONSTRUCTEURS
        //Constructeur par défaut
        public MyStatusBar() : this("", 12, Colors.Black) { }

        //Constructeur d'initialisation
        public MyStatusBar(string message, int taille, Color couleur)
        {
            Message = message;
            Taille = taille;
            Couleur = couleur;
        }
        #endregion

        #region METHODES
        public void SetMessage(string msg)
        {
            Message = msg;
            Couleur = Colors.Black;
        }

        public void SetWarning(string msg)
        {
            Message = msg;
            Couleur = Colors.Yellow;
        }

        public void SetError(string msg)
        {
            Message = msg;
            Couleur = Colors.Red;
        }
        #endregion
    }
}