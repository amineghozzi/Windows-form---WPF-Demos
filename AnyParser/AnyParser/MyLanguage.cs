using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AnyParser
{
    public class MyLanguage : ILanguageParser
    {
        #region Private Fields
        private AnyParser ap;
        #endregion

        #region Public Constructor
        public MyLanguage()
        {
            this.ap = new AnyParser();
            this.ap.AddSeparator(" ");
            this.ap.AddSeparator("\t");
            this.ap.Compose("statements", "texte", "\\S*texte [?]\r\n");
            this.ap.Compose("statements", "affectation", "\\S*[?] = [?]\r\n");
            this.ap.Compose("statements", "condition", "\\S*si [?] alors aller à [?] sinon aller à [?]\r\n");
            this.ap.Compose("statements", "parallel", "\\S*faire en parallèle {\r\n\\<statements\\>}\r\n");
            this.ap.Compose("statements", "label", "\\S*[?] :\r\n");
            this.ap.Compose("statements", "edit", "\\S*éditer [?] {\r\n\\<legende\\>}\r\n");
            this.ap.Compose("statements", "editTab", "\\S*éditer tableau [?] {\r\n\\<legendeTab\\>} (?).[?] {\r\n\\<legende\\>}\r\n");
            this.ap.Compose("statements", "useTemplate", "\\S*utiliser modèle [?](?) {\r\n\\<coding\\>}\r\n");
            this.ap.Compose("statements", "declareTemplate", "\\S*déclarer modèle [?](?) {\r\n\\<statements\\>}\r\n");
            this.ap.Compose("statements", "handler", "\\S*poignée [?]\r\n");
            this.ap.Compose("statements", "affectationChaine", "\\S*[?] = :[?] {\r\n\\<legende\\>}\r\n");
            this.ap.Compose("statements", "affectationChamp", "\\S*[?] = [?] {\r\n\\<legendeTab\\>} (?).[?] {\r\n\\<legende\\>}\r\n");
            this.ap.Compose("coding", "codage", "\\S*codage [?] {\r\n\\<statements\\>}\r\n");
            this.ap.Compose("legende", "legende", "\\S*-description:?\r\n\\S*-type:?\r\n\\S*-expression:?\r\n");
            this.ap.Compose("legendeTab", "legende", "\\S*-description:?\r\n\\S*-type:?\r\n\\S*-expression:?\r\n");
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
