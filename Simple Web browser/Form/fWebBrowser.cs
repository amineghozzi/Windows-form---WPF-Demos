#region using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
#endregion

namespace Test_Browser
{
    #region class fWebBrowser
    public partial class fWebBrowser : Form
    {
        #region variable
        UCFavoris gUCFavoris = null;
        #endregion

        #region constructor
        public fWebBrowser()
        {
            InitializeComponent();
        }
        #endregion

        #region BrowserUrl
        private string BrowserUrl
        {
            get { return txtUrl.Text.Trim(); }
            set { txtUrl.Text = value; }
        }
        #endregion

        #region initialisation et fermeture application

        #region fWebBrowser_Load
        private void fWebBrowser_Load(object sender, EventArgs e)
        {

            try
            {
                gUCFavoris = new UCFavoris();
                gUCFavoris.Dock = DockStyle.Fill;
                SplitContainer1.Panel1.Controls.Add(gUCFavoris);
                gUCFavoris.url_Selected += new UCFavoris.Url_Selected(UCFavoris_Url_Selected);
                webToolStripStatusBar.Visible = false;
                webToolStripStatusBar.Value = 0;
                wb_Browser.GoHome();
                UpdateButtons();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region fWebBrowser_FormClosed
        private void FormClosed_FormClosed(object sender, FormClosedEventArgs e)
        {
            gUCFavoris.url_Selected -= new UCFavoris.Url_Selected(UCFavoris_Url_Selected);
        }
        #endregion

        #region UCFavoris_Url_Selected
        void UCFavoris_Url_Selected(object sender, Uri uri)
        {
            this.wb_Browser.Url = uri;
        }
        #endregion

        #region FermerToolStripMenuItem_Click
        private void m_Quit_Click(object sender, EventArgs e)
        {
            this.quitter();
        }
        #endregion

        #endregion

        #region Menu ...

        #region ToolStripMenuItem1_Click
        private void m_Open_Click(object sender, EventArgs e)
        {
            this.ouvrir("Tous les fichiers (*.*)|*.*", wb_Browser);
        }
        #endregion

        #region ToolStripMenuItem2_Click
        private void m_Preview_Click(object sender, EventArgs e)
        {
            this.apercu_avant_impression();
        }
        #endregion

        #region ToolStripMenuItem3_Click
        private void m_Print_Click(object sender, EventArgs e)
        {
            this.imprimer();
        }
        #endregion

        #region BarreMenuToolStripMenuItem_Click
        private void m_Toolbar_Click(object sender, EventArgs e)
        {
            this.afficher_barre_menu();
        }
        #endregion

        #region BarreDeStatutToolStripMenuItem_Click
        private void m_StatusBar_Click(object sender, EventArgs e)
        {
            this.afficher_barre_etat();
        }
        #endregion

        #region PagePrécédenteToolStripMenuItem_Click
        private void m_PreviousPage_Click(object sender, EventArgs e)
        {
            this.page_precedente();
        }
        #endregion

        #region PageSuivanteToolStripMenuItem_Click
        private void m_NextPage_Click(object sender, EventArgs e)
        {
            this.page_suivante();
        }
        #endregion

        #region PageDeDémarrageToolStripMenuItem_Click
        private void m_HomePage_Click(object sender, EventArgs e)
        {
            this.page_demarrage();
        }
        #endregion

        #region ArrêterToolStripMenuItem_Click
        private void m_Stop_Click(object sender, EventArgs e)
        {
            this.arreter();
        }
        #endregion

        #region ActualiserToolStripMenuItem_Click
        private void m_Refresh_Click(object sender, EventArgs e)
        {
            this.actualiser();
        }
        #endregion

        #region SystêmeToolStripMenuItem_Click
        private void m_System_Click(object sender, EventArgs e)
        {
            this.SetRenderer(this, ToolStripRenderMode.System);
        }
        #endregion

        #region ProfessionnelToolStripMenuItem_Click
        private void m_Professional_Click(object sender, EventArgs e)
        {
            this.SetRenderer(this, ToolStripRenderMode.Professional);
        }
        #endregion

        #endregion

        #region ToolStrip button ...

        #region ToolStripButton1_ButtonClick
        private void tb_PreviousPage_ButtonClick(object sender, EventArgs e)
        {
            this.page_precedente();
        }
        #endregion

        #region ToolStripButton2_ButtonClick
        private void tb_NextPage_ButtonClick(object sender, EventArgs e)
        {
            this.page_suivante();
        }
        #endregion

        #region stopToolStripButton_Click
        private void tb_Stop_Click(object sender, EventArgs e)
        {
            this.arreter();
        }
        #endregion

        #region ToolStripButton3_Click
        private void tb_Refresh_Click(object sender, EventArgs e)
        {
            this.actualiser();
        }
        #endregion

        #region ToolStripButton4_Click
        private void tb_Home_Click(object sender, EventArgs e)
        {
            this.page_demarrage();
        }
        #endregion

        #region ToolStripButton5_Click
        private void tb_Goto_Click(object sender, EventArgs e)
        {
            this.atteindre_url();
        }
        #endregion

        #region ToolStripButton6_Click
        private void tb_Favourite_Click(object sender, EventArgs e)
        {
            this.afficher_favoris();
        }
        #endregion

        #endregion

        #region txtUrl_KeyDown
        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                wb_Browser.Navigate(this.txtUrl.Text);
        }
        #endregion

        #region WebBrowser ...

        #region WebBrowser1_Navigating
        private void wb_Browser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            this.UpdateButtons();
            webToolStripStatusBar.Visible = true;
        }
        #endregion

        #region WebBrowser1_Navigated
        private void wb_Browser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            BrowserUrl = e.Url.ToString();
            UpdateButtons();
        }
        #endregion

        #region WebBrowser1_ProgressChanged
        private void wb_Browser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            progression(e);
        }
        #endregion

        #endregion

        #region ouvrir
        private bool ouvrir(string filter, WebBrowser target)
        {
            dlg_OpenFile.Filter = filter;
            if (System.Windows.Forms.DialogResult.OK == dlg_OpenFile.ShowDialog())
            {
                target.Navigate(dlg_OpenFile.FileName);
                return true;
            }
            return false;
        }
        #endregion

        #region UpdateButtons
        private void UpdateButtons()
        {
            this.tb_NextPage.Enabled = this.wb_Browser.CanGoForward;
            this.tb_PreviousPage.Enabled = this.wb_Browser.CanGoBack;
        }
        #endregion

        #region quitter
        private void quitter()
        {
            try
            {
                this.Close();
                //Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de fermer l'application :" + ex.Message);
            }
        }
        #endregion

        #region apercu_avant_impression
        private void apercu_avant_impression()
        {
            try
            {
                wb_Browser.ShowPrintPreviewDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible d'afficher l'aperçu avant impression : " + ex.Message);
            }
        }
        #endregion

        #region imprimer
        private void imprimer()
        {
            try
            {
                wb_Browser.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible d'imprimer : " + ex.Message);
            }
        }
        #endregion

        #region Navigation ...

        #region page_precedente
        private void page_precedente()
        {
            try
            {
                wb_Browser.GoBack();
            }
            catch
            {
            }
        }
        #endregion

        #region page_suivante
        private void page_suivante()
        {
            try
            {
                wb_Browser.GoForward();
            }
            catch
            {
            }
        }
        #endregion

        #region arreter
        private void arreter()
        {
            try
            {
                wb_Browser.Stop();
            }
            catch
            {
            }
        }
        #endregion

        #region actualiser
        private void actualiser()
        {
            try
            {
                wb_Browser.Refresh();
            }
            catch
            {
            }
        }
        #endregion

        #region page_demarrage
        private void page_demarrage()
        {
            try
            {
                wb_Browser.GoHome();
            }
            catch
            {
            }
        }
        #endregion

        #region atteindre_url
        private void atteindre_url()
        {
            try
            {
                wb_Browser.Url = new Uri(txtUrl.Text);
            }
            catch
            {
                MessageBox.Show("Impossible de trouver le site ");
            }
        }
        #endregion

        #region progression
        private void progression(System.Windows.Forms.WebBrowserProgressChangedEventArgs e)
        {
            webToolStripStatusLabel.Text = wb_Browser.StatusText;
            webToolStripStatusBar.Value = (int)((e.CurrentProgress / e.MaximumProgress) * 100);

            if (webToolStripStatusBar.Value == webToolStripStatusBar.Maximum || webToolStripStatusLabel.Text == "Terminé")
                webToolStripStatusBar.Visible = false;
        }
        #endregion

        #region afficher_favoris
        private void afficher_favoris()
        {
            if (this.SplitContainer1.SplitterDistance == 0)
            {

                this.SplitContainer1.SplitterDistance = 254;
                this.SplitContainer1.Panel1.Show();
                this.SplitContainer1.Panel1.Enabled = true;
            }
            else
            {
                this.SplitContainer1.SplitterDistance = 0;
                this.SplitContainer1.Panel1.Hide();
                this.SplitContainer1.Panel1.Enabled = false;
            }
        }
        #endregion

        #endregion

        #region afficher_barre_menu
        private void afficher_barre_menu()
        {
            try
            {
                tb_Toolbar.Visible = m_Toolbar.Checked;
                //statusStrip1.Visible = BarreDeStatutToolStripMenuItem.Checked;
            }
            catch
            {
            }
        }
        #endregion

        #region afficher_barre_etat
        private void afficher_barre_etat()
        {
            try
            {
                ss_Status.Visible = m_StatusBar.Checked;
            }
            catch
            {
            }
        }
        #endregion

        #region SetRenderer
        private void SetRenderer(Control ctl, ToolStripRenderMode renderMode)
        {
            foreach (Control control in ctl.Controls)
            {
                //Dim prop As System.ComponentModel.PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(control)("RenderMode")
                System.ComponentModel.PropertyDescriptor prop = System.ComponentModel.TypeDescriptor.GetProperties(control)["RenderMode"];
                if (prop != null)
                    prop.SetValue(control, renderMode);
                if (ctl.Controls.Count > 0)
                    SetRenderer(control, renderMode);
            }

            ss_Status.RenderMode = ToolStripRenderMode.System;
        }
        #endregion

    }
    #endregion
}