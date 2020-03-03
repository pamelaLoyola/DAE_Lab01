using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();

        }

        //cadena de conexion a la base de datos
        SqlConnection cn = new SqlConnection("Data Source=(local);Initial Catalog=neptuno; Integrated Security= True");

        public void ListaClientes()
        {
            using (SqlDataAdapter df = new SqlDataAdapter ("select * from clientes", cn))
            {
                using  (DataSet da = new DataSet())
                {
                    df.Fill(da, "Clientes");

                    dgClientes.DataSource = da.Tables["Clientes"];

                    lblTotal.Text = da.Tables["Clientes"].Rows.Count.ToString();    
                }
            }
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {

            ListaClientes();
        }
    }
}

