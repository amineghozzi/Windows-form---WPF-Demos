#region using
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
#endregion

namespace Test_Browser
{
    #region class cIni
    public class cIni
    {
        #region declaration
        const int MAX_ENTRY = 32768;

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern int GetPrivateProfileString(string sSection, string sItem, string sDefault, StringBuilder sBuffer, int lSize, string sPathIni);
        #endregion

        #region LireINI
        public static string LireINI(string Entete, string Variable, string PathFichier)
        {
            string defval = "";
            try
            {
                System.Text.StringBuilder StrBuild  = new System.Text.StringBuilder(MAX_ENTRY);
                int Ret = GetPrivateProfileString(Entete, Variable, defval, StrBuild, MAX_ENTRY, PathFichier);
                return StrBuild.ToString();
            }
            catch
            {
                return defval;
            }
        }
        #endregion
    }
    #endregion
}
