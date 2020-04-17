using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUD_en_WindowsForms_.NET.Models;

namespace CRUD_en_WindowsForms_.NET
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Refrescar();
        }
        #region HELPER
        private void Refrescar()
        {
            using (CrudEntities db = new CrudEntities())
            {
                var lst = from d in db.tabla
                          select d;
                dataGridView1.DataSource = lst.ToList();
            }
        }
        private int? GetId()
        {
            try
            {
               return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Presentation.FrmTabla oFrmTabla = new Presentation.FrmTabla();
            oFrmTabla.ShowDialog();
            Refrescar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if(id!=null)
            {
                Presentation.FrmTabla oFrmTabla = new Presentation.FrmTabla(id);
                oFrmTabla.ShowDialog();

                Refrescar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id!= null)
            {
                using (CrudEntities db=new CrudEntities())
                {
                    tabla oTabla = db.tabla.Find(id);
                    db.tabla.Remove(oTabla);

                    db.SaveChanges();
                }

                Refrescar();
            }
        }
    }
}
