using AulaLiteDb.Domain.Entities;
using LiteDB;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AulaLiteDb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario("Paulo Rogerio", 39);
            Usuario usuario2 = new Usuario("Fernanda", 35);
            Usuario usuario3 = new Usuario("Maria", 29);

            using (var db = new LiteDatabase("banco.db"))
            {
                var usuarioCollection = db.GetCollection<Usuario>("usuarios");
                usuarioCollection.Insert(usuario);
                usuarioCollection.Insert(usuario2);
                usuarioCollection.Insert(usuario3);
            }

        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            using (var db = new LiteDatabase("banco.db"))
            {
                var usuarioCollection = db.GetCollection<Usuario>("usuarios");

                var resultCollection = usuarioCollection.FindAll();

                resultCollection.ToList().ForEach(usuario =>
                {
                    string id = usuario.Id.ToString();
                    string nome = usuario.Nome;
                });

            }
        }

        private void BtnAlterar_Click(object sender, EventArgs e)
        {
            using (var db = new LiteDatabase("banco.db"))
            {
                var usuarioCollection = db.GetCollection<Usuario>("usuarios");

                var usuario = usuarioCollection.FindOne(x => x.Nome.Contains("Paulo"));


                usuario.Nome = "Ilovecode";
                usuario.Idade = 2020;

                usuarioCollection.Update(usuario);



            }
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            using (var db = new LiteDatabase("banco.db"))
            {
                var usuarioCollection = db.GetCollection<Usuario>("usuarios");

                usuarioCollection.Delete(Guid.Parse("dcad2899-1319-495e-9856-3e2619218d22"));
            }
        }
    }
}
