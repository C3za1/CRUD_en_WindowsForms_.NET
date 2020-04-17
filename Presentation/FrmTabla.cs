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

namespace CRUD_en_WindowsForms_.NET.Presentation
{
    public partial class FrmTabla : Form
    {
        public int? id;
        tabla oTabla = null;
        public FrmTabla(int? id=null)
        {
            InitializeComponent();

            this.id = id;
            if (id != null)
                CargarDatos();
        }

        private void CargarDatos()
        {
            using (CrudEntities db = new CrudEntities())
            {
                oTabla = db.tabla.Find(id);
                txtCorreo.Text = oTabla.correo;
                txtNombre.Text = oTabla.nombre;
                DTP_FechaNacimiento.Value = oTabla.fecha_nacimiento;
            }
        }

        private void FrmTabla_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            using (CrudEntities db=new CrudEntities())
            {
                if(id==null)
                       oTabla = new tabla();

                oTabla.nombre = txtNombre.Text;
                oTabla.correo = txtCorreo.Text;
                oTabla.fecha_nacimiento = DTP_FechaNacimiento.Value;

                if(id==null)
                    db.tabla.Add(oTabla);
                else
                {
                    db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();

                this.Close();
            }
        }
    }
}
