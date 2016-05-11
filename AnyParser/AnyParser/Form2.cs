using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AnyParser
{
    public partial class Form2 : Form
    {
        private ILanguageParser parser;
        //private AnyParser ap;
        public Form2()
        {
            InitializeComponent();
            Logging.Logs.Initialize();
            Logging.Logs.PrintLog += new EventHandler<Logging.LogLine>(Logs_PrintLog);
            this.comboBox1.Items.Add("C#");
            this.comboBox1.Items.Add("MyLanguage");
            this.comboBox1.Items.Add("A-BNF");
            List<Models> m = new List<Models>();
            m.Add(new Models("Exemple 1", "MyLanguage", @"[v1] = [0]
si [true] alors aller à [vrai] sinon aller à [faux]
[true] :
[v2] = [3]
[false] :
[v2] = [4]
"));
            m.Add(new Models("Exemple 2", "MyLanguage", @"déclarer modèle [replace](name,value) {
[v1] = [0]
si [true] alors aller à [vrai] sinon aller à [faux]
[true] :
[v2] = [3]
poignée [test]
[false] :
[v2] = [4]
}
utiliser modèle [replace](@name=N @value=val) {
    codage [test] {
     texte []
    }
}
"));
            m.Add(new Models("Exemple 3", "MyLanguage", @"[v1] = :[v2] {
     -description:description de v2
     -type:String
     -expression:
}
éditer tableau [tableau] {
      -description: description du tableau
                          element de tableau
      -type:Tableau
      -expression:
} (0).[champ] {
       -description: description du champ
                           valeur du champ = null
       -type:String
       -expression:
}
"));
            this.comboBox2.DisplayMember = "Name";
            this.comboBox2.ValueMember = "Name";
            this.comboBox2.DataSource = m;
            //this.ap = new AnyParser();
            //this.ap.AddSeparator(" ");
            //this.ap.AddSeparator("\t");
            //this.ap.Compose("statements", "affectation", "\\S*[?] = [?]\r\n");
            //this.ap.Compose("statements", "condition", "\\S*si [?] alors aller à [?] sinon aller à [?]\r\n");
            //this.ap.Compose("statements", "parallel", "\\S*faire en parallèle {\r\n<statements>}\r\n");
        }

        void Logs_PrintLog(object sender, Logging.LogLine e)
        {
            this.listView1.Items.Add(e.Message);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.parser != null)
            {
                this.listView1.Items.Clear();
                Recognized reco = this.parser.Parse(this.textBox1.Text);
                this.treeView1.Nodes.Clear();
                if (reco != null)
                {
                    TreeNode sub = new TreeNode(reco.Value);
                    this.treeView1.Nodes.Add(sub);
                    foreach (Recognized subReco in reco.SubNodes)
                    {
                        this.ItereNodes(sub, subReco);
                    }
                }
                else
                {
                    MessageBox.Show("position:" + this.textBox1.Text.Substring(Error.Position, (Error.Position + 10 >= this.textBox1.Text.Length) ? this.textBox1.Text.Length - Error.Position : 10) + Environment.NewLine + Error.ExpectedValue,
                        "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("sélectionnez un langage");
            }

        }

        private void ItereNodes(TreeNode item, Recognized current)
        {
            TreeNode sub = new TreeNode(current.Value);
            item.Nodes.Add(sub);
            foreach (Recognized reco in current.SubNodes)
            {
                this.ItereNodes(sub, reco);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedItem.ToString() == "C#")
            {
                this.parser = new CSharpParser();
                //this.textBox1.Text = this.parser.LoadFile(AppDomain.CurrentDomain.BaseDirectory + "AnyParser.cs");
            }
            else if (this.comboBox1.SelectedItem.ToString() == "MyLanguage")
            {
                this.parser = new MyLanguage();
            }
            else if (this.comboBox1.SelectedItem.ToString() == "A-BNF")
            {
                this.parser = new ABNFParser();
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Logging.Logs.Release();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBox1.SelectedItem = (this.comboBox2.SelectedItem as Models).Language;
            this.textBox1.Text = (this.comboBox2.SelectedItem as Models).Text;
        }
    }

    internal class Models
    {
        private string name;
        private string language;
        private string text;

        public Models(string name, string language, string text)
        {
            this.name = name;
            this.language = language;
            this.text = text;
        }

        public string Name
        {
            get { return this.name; }
        }

        public string Language
        {
            get { return this.language; }
        }

        public string Text
        {
            get { return this.text; }
        }
    }
}