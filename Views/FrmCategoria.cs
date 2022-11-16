using _211483.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _211483.Views
{
    public partial class FrmCategoria : Form
    {
        Categoria c;
        public FrmCategoria()
        {
            InitializeComponent();
        }
        void limpaControles()
        {
            txtID.Clear();
            txtCategoria.Clear();
            txtPesquisa.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            c = new Categoria()
            {
                categoria = pesquisa
            };
            dgvCategorias.DataSource = c.Consultar();
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void btnLixo_Click(object sender, EventArgs e)
        {
            if (txtCategoria.Text == String.Empty) return;

            if (MessageBox.Show("Deseja excluir essa categoria?", "Excluir",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                c = new Categoria()
                {
                    id = int.Parse(txtID.Text)
                };
            c.Excluir();

            limpaControles();
            carregarGrid("");
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtCategoria.Text == String.Empty) return;

            c = new Categoria()
            {
                categoria = txtCategoria.Text
            };
            c.Incluir();

            limpaControles();
            carregarGrid("");
        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategorias.RowCount > 0)
            {
                txtID.Text = dgvCategorias.CurrentRow.Cells["id"].Value.ToString();
                txtCategoria.Text = dgvCategorias.CurrentRow.Cells["categoria"].Value.ToString();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtCategoria.Text == String.Empty) return;

            c = new Categoria()
            {
                id = int.Parse(txtID.Text),
                categoria = txtCategoria.Text
            };
            c.Alterar();

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
