#region using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
#endregion

namespace Test_Browser
{
    #region class UCFavoris
    public partial class UCFavoris : UserControl
    {

        #region variable
        public string PathDossier;
        public TreeNode NoeudSelect;
        public delegate void Url_Selected(object sender, Uri uri);
        public event Url_Selected url_Selected;
        #endregion

        #region constructor
        public UCFavoris()
        {
            InitializeComponent();

            InitTreeviewFichiersSource();
        }
        #endregion

        #region TreeView1_AfterLabelEdit
        private void TreeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            string Source, Cible;

            if (e.Label != null)
            {
                if (e.Label.Length > 0)
                {
                    e.Node.EndEdit(false);
                    Source = e.Node.FullPath.ToString() + e.Node.Tag;
                    Cible = e.Node.Parent.FullPath.ToString();
                    if (!Cible.EndsWith("\\")) Cible += "\\";
                    Cible += e.Label + e.Node.Tag;
                    if (System.IO.Directory.Exists(Cible) || System.IO.File.Exists(Cible)) //-Il existe
                    {
                        e.CancelEdit = true;
                        MessageBox.Show("Le dossier ou fichier à renommer existe déja", this.Text);
                        e.Node.BeginEdit();
                    }
                    else
                    {
                        Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(Source, Cible);
                        TreeView1.Refresh();
                    }
                }
                else
                {
                    e.CancelEdit = true;
                    MessageBox.Show("Aucun caractères saisies:Abandon", this.Text);
                    e.Node.BeginEdit();
                }
                TreeView1.LabelEdit = false;
            }
        }
        #endregion

        #region TreeView1_BeforeExpand
        private void TreeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                e.Node.Nodes.Clear();
                AjouteDossiersFichiers(e.Node);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), this.Text);
            }
        }
        #endregion

        #region TreeView1_DoubleClick
        private void TreeView1_DoubleClick(object sender, EventArgs e)
        {
            string addresse_noeud;

            try
            {
                addresse_noeud = "";
                addresse_noeud = cIni.LireINI("InternetShortcut", "URL", TreeView1.SelectedNode.FullPath + TreeView1.SelectedNode.Tag);
                url_Selected(this, new Uri(addresse_noeud));
            }
            catch
            {
            }
        }
        #endregion

        // AFFICHAGE

        #region InitTreeviewFichiersSource
        public void InitTreeviewFichiersSource()
        {
            TreeNode NoeudRacine;
            PathDossier = Environment.GetFolderPath(Environment.SpecialFolder.Favorites);
            TreeView1.Nodes.Clear();
            NoeudRacine = TreeView1.Nodes.Add(PathDossier);
            AjouteDossiersFichiers(NoeudRacine);
            NoeudRacine.Expand();
        }
        #endregion

        #region AjouteDossiersFichiers
        private void AjouteDossiersFichiers(TreeNode LeNod)
        {
            string Dossiers, fichiers;


            Dossiers = LeNod.FullPath;

            if (!Dossiers.EndsWith("\\")) Dossiers += "\\";

            foreach (string Dossier in System.IO.Directory.GetDirectories(Dossiers))
            {
                LeNod.Nodes.Add(System.IO.Path.GetFileName(Dossier.ToLower())).Nodes.Add("Factice");
            }
            fichiers = LeNod.FullPath;
            if (!fichiers.EndsWith("\\")) fichiers += "\\";
            foreach (string fichier in System.IO.Directory.GetFiles(fichiers))
            {
                TreeNode node = LeNod.Nodes.Add(System.IO.Path.GetFileNameWithoutExtension(fichier));
                node.ImageIndex = 2;
                node.SelectedImageIndex = 2;
                node.Tag = System.IO.Path.GetExtension(fichier);
            }
        }
        #endregion

    }
    #endregion
}
