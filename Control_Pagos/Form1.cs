using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_Pagos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var bd = new C_PagosEntities())
                {
                    var alumno = new Alumno();
                    alumno.CodigoAlumno = Convert.ToInt32(textBox1.Text);
                    alumno.Nombre = textBox2.Text;
                    alumno.ApellidoPaterno = textBox3.Text;
                    alumno.ApellidoMaterno = textBox4.Text;
                    alumno.Direccion = textBox7.Text;
                    alumno.Correo = textBox6.Text;
                    alumno.Telefono = Convert.ToInt32(textBox5.Text);
                    bd.Alumno.Add(alumno);
                    bd.SaveChanges();
                    MessageBox.Show("Cliente registrado correctamente.");
                    LimpiarCampos();
                }
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }      
    }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'c_PagosDataSet1.PagosPendientes' Puede moverla o quitarla según sea necesario.
            this.pagosPendientesTableAdapter.Fill(this.c_PagosDataSet1.PagosPendientes);
            // TODO: esta línea de código carga datos en la tabla 'c_PagosDataSet.Alumno' Puede moverla o quitarla según sea necesario.
            this.alumnoTableAdapter.Fill(this.c_PagosDataSet.Alumno);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                
                int codigoAlumno = int.Parse(textBox1.Text);
                using (var bd = new C_PagosEntities())
                {             
                    var alumno = bd.Alumno.First(s => s.CodigoAlumno == codigoAlumno);            
                    textBox2.Text = alumno.Nombre;
                    textBox3.Text = alumno.ApellidoPaterno;
                    textBox4.Text = alumno.ApellidoMaterno;
                    textBox7.Text = alumno.Direccion;
                    textBox6.Text = alumno.Correo;
                    textBox5.Text = alumno.Telefono.ToString();
                    MessageBox.Show("Cliente encontrado");
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cliente no registrado: {ex.Message}", "Cliente no encontrado");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int codigoAlumno = int.Parse(textBox1.Text);
                using (var bd = new C_PagosEntities())
                {
                    var alumno = bd.Alumno.First(s => s.CodigoAlumno == codigoAlumno);                  
                    alumno.CodigoAlumno = Convert.ToInt32(textBox1.Text);
                    alumno.Nombre = textBox2.Text;
                    alumno.ApellidoPaterno = textBox3.Text;
                    alumno.ApellidoMaterno = textBox4.Text;
                    alumno.Direccion = textBox7.Text;
                    alumno.Correo = textBox6.Text;
                    alumno.Telefono = Convert.ToInt32(textBox5.Text);
                    bd.SaveChanges();
                    MessageBox.Show("Cliente actualizado");
                    LimpiarCampos();
                }
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cliente no actualizado: {ex.Message}", "Cliente no actualizado");
            }
        }
        private void LimpiarCampos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void buteliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigoAlumno = int.Parse(textBox1.Text);

                using (var bd = new C_PagosEntities())
                {
                    var alumno = bd.Alumno.FirstOrDefault(s => s.CodigoAlumno == codigoAlumno);

                    if (alumno != null)
                    {
                        bd.Alumno.Remove(alumno);
                        bd.SaveChanges();
                        MessageBox.Show("Cliente eliminado correctamente");
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("El cliente no existe en la base de datos", "Cliente no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {        

        }

        private void btnPAGOS_Click(object sender, EventArgs e)
        {
            try
            {
                using (var bd = new C_PagosEntities())
                {
                    var pagos = new PagosPendientes();
                    pagos.IDPago = Convert.ToInt32(textcodpago.Text);
                    pagos.CodigoAlumno = Convert.ToInt32(textcodalum.Text);
                    pagos.Monto = Convert.ToInt32(textmonto.Text);
                    pagos.Mes = textmes.Text;
                    DateTime fechaVencimiento;
                    if (DateTime.TryParseExact(textBox11.Text, "yyyy-MM-dd", null, DateTimeStyles.None, out fechaVencimiento))
                    {
                        pagos.FechaVencimiento = fechaVencimiento;
                    }
                    else
                    {
                        MessageBox.Show("Formato de fecha inválido. El formato debe ser 'yyyy-MM-dd'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string pagoRealizado = textRP.Text.ToUpper();
                    if (pagoRealizado != "SI" && pagoRealizado != "NO")
                    {
                        MessageBox.Show("El campo PagoRealizado debe ser 'SI' o 'NO'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    pagos.PagoRealizado = pagoRealizado;

                    bd.PagosPendientes.Add(pagos);
                    bd.SaveChanges();
                    MessageBox.Show("Pagos registrado correctamente.");               
                }
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar Pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {

                int codigoAlumno = int.Parse(textcodalum.Text);
                using (var bd = new C_PagosEntities())
                {
                    var pagos = bd.PagosPendientes.First(s => s.CodigoAlumno == codigoAlumno);
                    textcodpago.Text = pagos.IDPago.ToString();
                    textcodalum.Text = pagos.CodigoAlumno.ToString();
                    textmonto.Text = pagos.Monto.ToString();
                    textmes.Text = pagos.Mes;
                    textBox11.Text = pagos.FechaVencimiento.ToString();
                    textRP.Text = pagos.PagoRealizado;
                    MessageBox.Show("Registro encontrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Registro no Encontrado: {ex.Message}", "Registro no encontrado");
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int codigoAlumno;
                if (!int.TryParse(textcodalum.Text, out codigoAlumno))
                {
                    MessageBox.Show("Por favor, ingrese un código de alumno Exitente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                using (var bd = new C_PagosEntities())
                {
                    var pagos = bd.PagosPendientes.First(s => s.CodigoAlumno == codigoAlumno);
                    pagos.IDPago = Convert.ToInt32(textcodpago.Text);
                    pagos.CodigoAlumno = Convert.ToInt32(textcodalum.Text);
                    pagos.Monto = Convert.ToInt32(textmonto.Text);
                    pagos.Mes = textmes.Text;
                    DateTime fechaVencimiento;
                    if (DateTime.TryParseExact(textBox11.Text, "yyyy-MM-dd", null, DateTimeStyles.None, out fechaVencimiento))
                    {
                        pagos.FechaVencimiento = fechaVencimiento;
                    }
                    else
                    {
                        MessageBox.Show("Formato de fecha inválido. El formato debe ser 'yyyy-MM-dd'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    pagos.PagoRealizado = textRP.Text;
                    bd.SaveChanges();
                    MessageBox.Show("Registro actualizado");
                    LimpiarCampos();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Registro no actualizado: {ex.Message}", "Registro no actualizado");
            }

        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.alumnoTableAdapter.Fill(this.c_PagosDataSet.Alumno);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
