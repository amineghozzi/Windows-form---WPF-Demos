using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AnyParser
{
    public class ABNFParser : ILanguageParser
    {
        #region Private Fields
        private AnyParser ap;
        #endregion

        #region Public Constructor
        public ABNFParser()
        {
            this.ap = new AnyParser();
            this.ap.IgnoreCase = true;
            this.ap.AddSeparator(" ");
            this.ap.AddSeparator("\t");
            this.ap.AddSeparator("\r\n");
            //this.ap.Compose("ruleName", "name", "\\e([a-zA-Z]([a-zA-Z0-9_])*)");
            this.ap.Compose("ruleName", "name", "?");
            this.ap.Compose("ruleName", "name", "<?>");
            this.ap.Compose("rules", "rule", "\\S*\\<ruleName\\>\\S*=\\<elements\\>\r\n");
            //this.ap.Compose("elements", "def", "\\S*\\e([a-zA-Z]([a-zA-Z0-9_])*)");
            this.ap.Compose("elements", "def", "\\S*<?>");
            this.ap.Compose("elements", "def", "\\S*?");
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
            return this.ap.Parse("rules", text);
        }
        #endregion
    }
}
