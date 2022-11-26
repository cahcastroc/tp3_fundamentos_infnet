
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PessoaLibrary
{
   public static class Repository
    {

        private static List<Pessoa> pessoas = new List<Pessoa>();


        public static void AddPessoa(Pessoa pessoa)
        {
            pessoas.Add(pessoa);
        }


        public static List<Pessoa> ListaPessoas()
        {
            return pessoas;
        }


        public static Pessoa? BuscaPessoa(string nome, string sobrenome)
        {
            foreach (Pessoa pessoa in pessoas)
            {
                if (pessoa.Nome.Equals(nome, StringComparison.InvariantCultureIgnoreCase)
                    && pessoa.Sobrenome.Equals(sobrenome, StringComparison.InvariantCultureIgnoreCase))
                    return pessoa;
            }            
            return null;
        }        

    }
}
