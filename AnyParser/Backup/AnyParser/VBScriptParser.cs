using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AnyParser
{
    public class VBScriptParser : ILanguageParser
    {
        #region Private Fields
        private AnyParser ap;
        #endregion

        #region Public Constructor
        public VBScriptParser()
        {
            this.ap = new AnyParser();
        }
        #endregion

        #region Public Methods
        public string LoadFile(string fileName)
        {
            string output = String.Empty;
            FileInfo fi = new FileInfo(fileName);
            if (fi.Exists)
            {
                StreamReader sr = new StreamReader(fi.OpenRead());
                output = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();
            }
            return output;
        }

        public Recognized Parse(string text)
        {
            return this.ap.Parse("statements", text);
        }
        #endregion
    }
}
