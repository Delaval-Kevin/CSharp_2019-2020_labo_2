/***********************************************************/
/*Auteur : DELAVAL Kevin                                   */
/*Groupe : 2203                                            */
/*Application : Gestion d'un club de motocross             */
/*Cours : C# - partie 3 du labo                            */
/*Date de la dernière mise à jour : 26/04/2020             */
/***********************************************************/

using System;
using Microsoft.Win32;

namespace MyClubObject
{
    public enum Params
    {
        SavePath,
        ListBackColor,
        ListFontColor
    }

    public class MyRegistry
    {
        #region VARIABLES
        private RegistryKey _rk;
        #endregion

        #region PROPRIETES
        private RegistryKey RK
        {
            get { return _rk; }
            set { _rk = value; }
        }
        #endregion

        #region CONSTRUCTEURS
        public MyRegistry()
        {
            RK = Registry.CurrentUser.CreateSubKey(@"Software\ClubManager");
            InitKeys();
        }
        #endregion

        #region METHODES
        public void InitKeys()
        {
            foreach (Params param in Enum.GetValues(typeof(Params)))
            {
                if (RK.GetValue(param.ToString()) == null)
                    SetDefault(param);
            }
        }

        public string GetValue(Params param)
        {
            if (RK.GetValue(param.ToString()) == null)
                SetDefault(param);
            return RK.GetValue(param.ToString()).ToString();
        }

        private void SetDefault(Params param)
        {
            switch (param)
            {
                case Params.SavePath:
                    RK.SetValue(param.ToString(), Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
                    break;

                case Params.ListBackColor:
                    RK.SetValue(param.ToString(), "#FF303030");
                    break;

                case Params.ListFontColor:
                    RK.SetValue(param.ToString(), "##DDFFFFFF");
                    break;
            }
        }

        public void SetValue(Params param, string value)
        {
            RK.SetValue(param.ToString(), value);
        }
        #endregion
    }
}
