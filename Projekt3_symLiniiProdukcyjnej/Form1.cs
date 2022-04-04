using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt3_symLiniiProdukcyjnej
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            this.CenterToScreen();
            ReadFileLog();
        }

        public void ReadFileLog()
        {
            try
            {
                lines = File.ReadAllLines("log.txt").ToList();
                for (int i = 0; i < lines.Count - 1; i += 2)
                {
                    logins[i / 2] = lines[i];
                    passwords[i / 2] = lines[i + 1];
                    Console.WriteLine(logins[i / 2]);
                    Console.WriteLine(passwords[i / 2]);
                }
            }
            catch(IOException)
            {
                MessageBox.Show("Nie znaleziono pliku z danymi logowania! Logowanie nie będzie możliwe!");
            }
        }
        public void WriteFileLog()
        {
            lines.Add(registeredLogin);
            lines.Add(registeredPassword);
            File.WriteAllLines("log.txt", lines);
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.TextLength >= 5 && textBoxPassword.TextLength >= 5)
            {
                registeredLogin = textBoxLogin.Text;
                registeredPassword = textBoxPassword.Text;
                WriteFileLog();
                ReadFileLog();
                MessageBox.Show("Pomyślnie zarejestrowano: " + registeredLogin);
            }
            else
            {
                MessageBox.Show("Hasło i login muszą mieć minimum 5 znaków!");
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < logins.Length; i++)
            {
                if (logins[i] == textBoxLogin.Text && passwords[i] == textBoxPassword.Text)
                {
                    logged = true;
                    break;
                }
                
            }
            if (logged)
            {
                MessageBox.Show("Pomyślnie zalogowano!");
                this.Hide();
                FormSimulator simulator = new FormSimulator();
                simulator.Show();
            }
            else
            {
                MessageBox.Show("Źle wprowadzony login lub hasło!");
            }
        }
    }
}
