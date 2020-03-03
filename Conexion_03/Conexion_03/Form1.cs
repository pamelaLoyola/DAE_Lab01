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
using System.Configuration;

namespace Conexion_03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Pamela"].ConnectionString);

        public void ListaProductos()
        {
            using (SqlDataAdapter df = new SqlDataAdapter("Usp_ListaProductos_Neptuno", cn))
            {
                df.SelectCommand.CommandType = CommandType.StoredProcedure;
                using (DataSet da = new DataSet())
                {
                    df.Fill(da, "Productos");
                    dgProductos.DataSource = da.Tables["Productos"];
                    lblTotal.Text = da.Tables["Productos"].Rows.Count.ToString();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListaProductos();
        }
    }
}
