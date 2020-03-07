using System;

namespace AulaLiteDb.Domain.Entities
{
    public class Usuario
    {
        public Usuario(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;

            Id = Guid.NewGuid();
        }

        public Guid Id { get;  set; }
        public string Nome { get;  set; }
        public int Idade { get;  set; }
    }
}
