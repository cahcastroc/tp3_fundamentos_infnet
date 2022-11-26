using System;
namespace PessoaLibrary
{
    public class Pessoa
    {
        
        private string nome;
        private string sobrenome;
        private DateTime aniversario;

        public Pessoa(string nome, string sobrenome, DateTime aniversario)
        {
            this.nome = nome;
            this.sobrenome = sobrenome;
            this.aniversario = aniversario;
        }

        public string Nome
        {
            get => nome;
            set => nome = value;
        }

        public string Sobrenome
        {
            get => sobrenome;
            set => sobrenome = value;
        }

        public DateTime Aniversario
        {
            get => aniversario;
            set => aniversario = value;
        }

        public override string? ToString()
        {
            return $"Nome: {nome}\nSobrenome: {sobrenome}\nAniversário: {aniversario.ToString("dd/MM/yyyy")}";
        }
    }

}