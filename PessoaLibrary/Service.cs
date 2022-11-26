using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PessoaLibrary
{
    public class Service
    {

        public static void RegistraPessoa(string nome, string sobrenome, DateTime aniversario)
        {
            Pessoa pessoa = new Pessoa(nome, sobrenome, aniversario);
            Repository.AddPessoa(pessoa);
        }

        public static List<Pessoa> ListaPessoas()
        {
            return Repository.ListaPessoas();
        }

        public static Pessoa BuscaPessoa(string nome, string sobrenome)
        {
            return Repository.BuscaPessoa(nome, sobrenome);
        }

    }


}

