using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _211483.Models;
using System.Windows.Forms;

namespace _211483.Views
{
    public partial class FrmMarca : Form
    {
        Marca m;
        public FrmMarca()
        {
            InitializeComponent();
        }

        void limpaControles()
        {
            txtID.Clear();
            txtMarca.Clear();
            txtPesquisa.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            m = new Marca()
            {
                marca = pesquisa
            };
            dgvMarcas.DataSource = m.Consultar();
        }

        private void FrmMarca_Load(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void btnLixo_Click(object sender, EventArgs e)
        {

            if (txtMarca.Text == String.Empty) return;

            if (MessageBox.Show("Deseja excluir essa marca?", "Excluir",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                m = new Marca()
                {
                    id = int.Parse(txtID.Text)
                };
            m.Excluir();

            limpaControles();
            carregarGrid("");
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtMarca.Text == String.Empty) return;

            m = new Marca()
            {
                marca = txtMarca.Text
            };
            m.Incluir();

            limpaControles();
            carregarGrid("");
        }

        private void dgvMarcas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMarcas.RowCount > 0)
            {
                txtID.Text = dgvMarcas.CurrentRow.Cells["id"].Value.ToString();
                txtMarca.Text = dgvMarcas.CurrentRow.Cells["marca"].Value.ToString();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtMarca.Text == String.Empty) return;

            m = new Marca()
            {
                id = int.Parse(txtID.Text),
                marca = txtMarca.Text
            };
            m.Alterar();

            limpaControles();
            carregarGrid("");
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }
    }
}
