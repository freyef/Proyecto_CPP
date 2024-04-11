using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }      
    }

        private void Form1_Load(object sender, EventArgs e)
        {
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
    }
}
