using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AnyParser
{
    public class CSharpParser : ILanguageParser
    {
        #region Private Fields
        private AnyParser ap;
        #endregion

        #region Public Constructor
        public CSharpParser()
        {
            this.ap = new AnyParser();
            ap.AddSeparator(" ");
            ap.AddSeparator("\t");
            ap.AddSeparator("\r\n");
            ap.Compose("global", "using", "\\S*using\\S+\\e([a-zA-Z.0-9]+);");
            ap.Compose("global", "namespace", "\\S*namespace\\S+\\e([a-zA-Z.0-9]+)\\S*{\\<class\\>\\S*}");
            ap.Compose("class", "classDeclaration", "\\S*public\\S+class\\S+\\e([a-zA-Z.0-9]+)\\S+{\\<functions\\>\\S*}");
            ap.Compose("class", "classDeclaration", "\\S*private\\S+class\\S+\\e([a-zA-Z.0-9]+)\\S+{\\<functions\\>\\S*}");
            ap.Compose("class", "classDeclaration", "\\S*protected\\S+class\\S+\\e([a-zA-Z.0-9]+)\\S+{\\<functions\\>\\S*}");
            ap.Compose("class", "classDeclaration", "\\S*internal\\S+class\\S+\\e([a-zA-Z.0-9]+)\\S+{\\<functions\\>\\S*}");
            ap.Compose("class", "classDeclaration", "\\S*class\\S+\\e([a-zA-Z.0-9]+)\\S+{\\<functions\\>\\S*}");
            ap.Compose("class", "interfaceDeclaration", "\\S*public\\S+interface\\S+\\e([a-zA-Z.0-9]+)\\S+{\\<functions\\>\\S*}");
            ap.Compose("class", "interfaceDeclaration", "\\S*private\\S+interface\\S+\\e([a-zA-Z.0-9]+)\\S+{\\<functions\\>\\S*}");
            ap.Compose("class", "interfaceDeclaration", "\\S*protected\\S+interface\\S+\\e([a-zA-Z.0-9]+)\\S+{\\<functions\\>\\S*}");
            ap.Compose("class", "interfaceDeclaration", "\\S*internal\\S+interface\\S+\\e([a-zA-Z.0-9]+)\\S+{\\<functions\\>\\S*}");
            ap.Compose("class", "interfaceDeclaration", "\\S*interface\\S+\\e([a-zA-Z.0-9]+)\\S+{\\<functions\\>\\S*}");
            ap.Compose("functions", "field", "\\S*\\e([a-zA-Z.0-9]+)\\S+\\e([a-zA-Z.0-9]+);");
            ap.Compose("functions", "field", "\\S*\\e([a-zA-Z.0-9]+)\\S+\\e([a-zA-Z.0-9]+)\\S+=\\S+?;");
            ap.Compose("functions", "function", "\\S*public\\S+\\e([a-zA-Z.0-9]+)\\S+\\e([a-zA-Z.0-9]+)(\\<parameters\\>\\S+)\\S*{\\<statements\\>}");
            ap.Compose("functions", "function", "\\S*private\\S+\\e([a-zA-Z.0-9]+)\\S+\\e([a-zA-Z.0-9]+)(\\<parameters\\>\\S+)\\S*{\\<statements\\>}");
            ap.Compose("functions", "function", "\\S*protected\\S+\\e([a-zA-Z.0-9]+)\\S+\\e([a-zA-Z.0-9]+)(\\<parameters\\>\\S+)\\S*{\\<statements\\>}");
            ap.Compose("functions", "function", "\\S*internal\\S+\\e([a-zA-Z.0-9]+)\\S+\\e([a-zA-Z.0-9]+)(\\<parameters\\>\\S+)\\S*{\\<statements\\>}");
            ap.Compose("parameters", "first", "\\S*\\<parameter\\>");
            ap.Compose("parameters", "next", "\\S*,\\S*\\<parameter\\>");
            ap.Compose("parameter", "parameter", "\\e([a-zA-Z.0-9]+)\\S*\\e([a-zA-Z.0-9]+)");
            ap.Compose("statements", "affectation", "\\S*\\e([a-zA-Z.0-9]+)\\S+\\e([a-zA-Z.0-9]+)\\S*=\\S*?;");
            ap.Compose("statements", "callProperty", "\\S*\\e([a-zA-Z.0-9]+)\\S*=\\S*?;");
            ap.Compose("statements", "callMethod", "\\S*\\e([a-zA-Z.0-9]+)\\S*(\\<EffectiveParameters\\>)\\S*;");
            ap.Compose("EffectiveParameters", "first", "\\S*\\<EffectiveParameter\\>");
            ap.Compose("EffectiveParameters", "next", "\\S*,\\S*\\<EffectiveParameter\\>");
            ap.Compose("EffectiveParameter", "parameter", "?");
            ap.Compose("statements", "si", "\\S*if\\S+(?)\\S*{\\<statements\\>}");
            ap.Compose("statements", "siElse", "\\S*if\\S+(?)\\S*{\\<statements\\>}\\S*else\\S*{\\<statements\\>}");
            ap.Compose("statements", "while", "\\S*while\\S+(?)\\S*{\\<statements\\>}");
            ap.Compose("statements", "for", "\\S*for\\S*(?;?;?)\\S*{\\<statements\\>}");
            ap.Compose("statements", "return", "\\S*return\\S+?;");
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
            return this.ap.Parse("global", text);
        }
        #endregion
    }
}
