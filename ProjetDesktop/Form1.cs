using ProjetDesktop.Model;
using ProjetDesktop.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetDesktop
{
    public partial class frmCampus : Form
    {
        private CampusService campusService = new CampusService();
        private int idCurrent;

        public frmCampus()
        {
            InitializeComponent();
        }

        public async Task loadTableAsync()
        {
            List<Campus> campuses = await campusService.GetServices();
            dgCampus.DataSource = campuses;
            reset();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            loadTableAsync();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void btnSupprimer_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgCampus.CurrentRow.Cells[0].Value.ToString());
            bool isDeleted = await campusService.SupprimerCampus(id);
            if (isDeleted)
            {
                MessageBox.Show("Supprimer avec success");
            }
            else
            {
                MessageBox.Show("Echec lors de la suppression");
            }
            loadTableAsync();
        }

        private async void btnAjouter_Click(object sender, EventArgs e)
        {
            if (txtAdresse.Text!="" && txtDepartement.Text!="" && txtNomCampus.Text!="" && txtRegion.Text!=""
                && txtTelephone.Text!="")
            {
                Campus campus = new Campus();
                campus.adresse = txtAdresse.Text;
                campus.telephone = txtTelephone.Text;
                campus.nomCampus = txtNomCampus.Text;
                campus.departement = txtDepartement.Text;
                campus.region = txtRegion.Text;
                campus.etat = "RAS";
                campus.idUser = 1;

                Campus last = await campusService.AjoutCampus(campus);

                if (last != null)
                {
                    MessageBox.Show("Campus ajouter avec success");
                }
                else
                {
                    MessageBox.Show("Echec lors de l'ajout");
                }
                loadTableAsync();
            }
            else
            {
                MessageBox.Show("Tous les champs sont obligatoires");
            }
            
        }

        private void reset()
        {
            txtAdresse.Text = "";
            txtDepartement.Text = "";
            txtNomCampus.Text = "";
            txtRegion.Text = "";
            txtTelephone.Text = "";
        }

        private async void btnModifier_Click(object sender, EventArgs e)
        {
            if (txtAdresse.Text != "" && txtDepartement.Text != "" && txtNomCampus.Text != "" && txtRegion.Text != ""
                    && txtTelephone.Text != "")
                {
                    Campus campus = new Campus();
                    campus.adresse = txtAdresse.Text;
                    campus.telephone = txtTelephone.Text;
                    campus.nomCampus = txtNomCampus.Text;
                    campus.departement = txtDepartement.Text;
                    campus.region = txtRegion.Text;
                    campus.etat = "RAS";
                    campus.idUser = 1;

                    Campus result = await campusService.UpdateCampus(idCurrent, campus);

                    if (result != null)
                    {
                        MessageBox.Show("Campus modifier avec success");
                    }
                    else
                    {
                        MessageBox.Show("Echec lors de la modification");
                    }
                    loadTableAsync();
                }
                else
                {
                    MessageBox.Show("Tous les champs sont obligatoires");
                }

            }

        private void dgCampus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idCurrent = int.Parse(dgCampus.CurrentRow.Cells[0].Value.ToString());
            txtAdresse.Text = dgCampus.CurrentRow.Cells[4].Value.ToString();
            txtDepartement.Text = dgCampus.CurrentRow.Cells[5].Value.ToString();
            txtNomCampus.Text = dgCampus.CurrentRow.Cells[2].Value.ToString();
            txtRegion.Text = dgCampus.CurrentRow.Cells[6].Value.ToString();
            txtTelephone.Text = dgCampus.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
