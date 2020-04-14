/***********************************************************/
/*Auteur : DELAVAL Kevin                                   */
/*Groupe : 2203                                            */
/*Application : Gestion d'un club de motocross             */
/*Cours : C# - partie 3 du labo                            */
/*Date de la dernière mise à jour : 13/04/2020             */
/***********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClubObject
{
    public class Chronometre
    {
        #region VARIABLES MEMBRES
        private string      _numLicence;
        private string      _numCircuit;
        private DateTime    _dateChrono;
        private CondClim    _conditionClimatique;
        private EtatCirc    _etatCircuit;
        private TimeSpan    _tempsChrono;
        #endregion


        #region PROPRIETES
        public string NumLicence
        {
            get { return _numLicence; }
            set { _numLicence = value; }
        }

        public string NumCircuit
        {
            get { return _numCircuit; }
            set { _numCircuit = value; }
        }

        public DateTime DateChrono
        {
            get { return _dateChrono; }
            set { _dateChrono = value; }
        }

        public CondClim ConditionClimatique
        {
            get { return _conditionClimatique; }
            set { _conditionClimatique = value; }
        }

        public EtatCirc EtatCircuit
        {
            get { return _etatCircuit; }
            set { _etatCircuit = value; }
        }


        public TimeSpan TempsChrono
        {
            get { return _tempsChrono; }
            set { _tempsChrono = value; }
        }
        #endregion


        #region CONSTRUCTEURS
        //Constructeur par défaut
        public Chronometre() : this("PBE123456", "TBE0001", new DateTime(1, 1, 2000), CondClim.Nuageux, EtatCirc.Humide, new TimeSpan(0, 0, 2, 56, 453)) { }

        //Constructeur d'initialisation
        public Chronometre(string numLicence, string numCircuit, DateTime dateChrono, CondClim conditionClimatique, EtatCirc etatCircuit, TimeSpan tempsChrono)
        {
            NumLicence = numLicence;
            NumCircuit = numCircuit;
            DateChrono = dateChrono;
            ConditionClimatique = conditionClimatique;
            EtatCircuit = etatCircuit;
            TempsChrono = tempsChrono;
        }
        #endregion


        #region METHODES
        public override string ToString()
        {
            return "Numero de licence : " + NumLicence + "\nNumero de circuit : " + NumCircuit + "\nDate du chrono : " + DateChrono +
                    "\nCondition climatique : " + ConditionClimatique + "\nEtat du circuit : " + EtatCircuit + "\nTemps chrono : " + TempsChrono;
        }
        #endregion
    }
}
