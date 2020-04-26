/***********************************************************/
/*Auteur : DELAVAL Kevin                                   */
/*Groupe : 2203                                            */
/*Application : Gestion d'un club de motocross             */
/*Cours : C# - partie 3 du labo                            */
/*Date de la dernière mise à jour : 17/04/2020             */
/***********************************************************/

using System;
using MyClubObject;
using System.Windows;
using System.Windows.Media;
using System.Windows.Forms;

namespace ClubUI
{
    public partial class Option : Window
    {
        #region EVENEMENTS
        public event Action<Color, Color> ColorChange;
        #endregion

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
        public Option(AppControler controler)
        {
            InitializeComponent();
            Controler = controler;
            path.Text = Controler.MyRegist.GetValue(Params.SavePath);
            TextColor.Color = (Color)ColorConverter.ConvertFromString(Controler.MyRegist.GetValue(Params.ListFontColor));
            BackColor.Color = (Color)ColorConverter.ConvertFromString(Controler.MyRegist.GetValue(Params.ListBackColor));
        }
        #endregion

        #region BOUTONS
        private void OK_Button(object sender, RoutedEventArgs e)
        {
            ColorChange?.Invoke(TextColor.Color, BackColor.Color);

            if(!Controler.MyRegist.GetValue(Params.SavePath).Equals(path.Text))
            {
                System.IO.File.Move(Controler.MyRegist.GetValue(Params.SavePath) + Controler.PilotesFileName, path.Text + Controler.PilotesFileName);
                System.IO.File.Move(Controler.MyRegist.GetValue(Params.SavePath) + Controler.CircuitsFileName, path.Text + Controler.CircuitsFileName);
                System.IO.File.Move(Controler.MyRegist.GetValue(Params.SavePath) + Controler.ChronosFileName, path.Text + Controler.ChronosFileName);
            }

            Controler.MyRegist.SetValue(Params.SavePath, path.Text);
            Controler.MyRegist.SetValue(Params.ListBackColor, BackColor.Color.ToString());
            Controler.MyRegist.SetValue(Params.ListFontColor, TextColor.Color.ToString());

            this.Close();
        }

        private void Apply_Button(object sender, RoutedEventArgs e)
        {
            if (!Controler.MyRegist.GetValue(Params.SavePath).Equals(path.Text))
            {
                System.IO.File.Move(Controler.MyRegist.GetValue(Params.SavePath) + Controler.PilotesFileName, path.Text + Controler.PilotesFileName);
                System.IO.File.Move(Controler.MyRegist.GetValue(Params.SavePath) + Controler.CircuitsFileName, path.Text + Controler.CircuitsFileName);
                System.IO.File.Move(Controler.MyRegist.GetValue(Params.SavePath) + Controler.ChronosFileName, path.Text + Controler.ChronosFileName);
            }

            Controler.MyRegist.SetValue(Params.SavePath, path.Text);
            Controler.MyRegist.SetValue(Params.ListBackColor, BackColor.Color.ToString());
            Controler.MyRegist.SetValue(Params.ListFontColor, TextColor.Color.ToString());

            ColorChange?.Invoke(TextColor.Color, BackColor.Color);
        }

        private void Cancel_Button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Changer_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog brow = new FolderBrowserDialog
            {
                Description = "Selectionner le dossier souhaité",
                SelectedPath = Controler.MyRegist.GetValue(Params.SavePath)
            };

            brow.ShowDialog();

            path.Text = brow.SelectedPath;
        }
        #endregion

    }
}
