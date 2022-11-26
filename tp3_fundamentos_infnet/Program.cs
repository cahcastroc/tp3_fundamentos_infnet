using System;
using System.Collections.Generic;
using PessoaLibrary;
using System.Text.RegularExpressions;

namespace tp3_fundamentos_infnet
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();         

        }

        //----------Menu e operações de interação com usuário

        static int EscolherMenu()
        {

            int opcao;
            do
            {

                Console.WriteLine();
                Console.WriteLine("-*-*-*-*-Registros de aniversários-*-*-*-*-");
                Console.WriteLine("Selecione uma das opções abaixo: ");
                Console.WriteLine("1 - Listar todas as pessoas");
                Console.WriteLine("2 - Pesquisar um pessoa");
                Console.WriteLine("3 - Adicionar nova pessoa");
                Console.WriteLine("0 - Sair");
                opcao = int.Parse(Console.ReadLine());
                Console.WriteLine();

            } while (opcao < 0 || opcao > 3);

            return opcao;

        }

        static void Menu()
        {
            int opcao;

            do
            {
                opcao = EscolherMenu();
                switch (opcao)
                {
                    case 1:
                        ListarPessoas();
                        break;
                    case 2:
                        BuscarPessoa();
                        break;
                    case 3:
                        AddPessoa();
                        break;
                    case 0:
                        Console.WriteLine("Programa finalizado!");
                        break;
                }
            }
            while (opcao != 0);
        }


        static void ConfirmarOperacao(string nome, string sobrenome, DateTime aniversario)
        {


            Console.WriteLine("*-*-*-*-*Os dados abaixo estão corretos?*-*-*-*-*");
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Sobrenome: {sobrenome}");
            Console.WriteLine($"Data de nascimento: {aniversario.ToString("dd/MM/yyyy")}");
            Console.WriteLine("Digite 1 para Confirmar ou 2 para repetir a operação");
            int opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                Service.RegistraPessoa(nome, sobrenome, aniversario);
                Console.WriteLine("Registro salvo com sucesso!");
            }
            else
            {
                Console.WriteLine("Repita a operação!");
                Menu();
            }

        }

        //----------Adicionar, Listar todos e buscar pessoa

        static void AddPessoa()
        {
            Regex regex = new Regex(@"[a-zA-Z]+");
            try
            {
                Console.WriteLine("*-*-*-*-Adicionar Pessoa:-*-*-*-*");
                Console.WriteLine("Digite o nome da pessoa:");
                var nome = Console.ReadLine();
                if (!regex.IsMatch(nome))
                    throw new FormatException();

                Console.WriteLine("Digite o sobrenome da pessoa:");
                var sobrenome = Console.ReadLine();
                if (!regex.IsMatch(sobrenome))
                    throw new FormatException();

                Console.WriteLine("Digite a data de nascimento da pessoa:");
                var aniversario = Convert.ToDateTime(Console.ReadLine());
                if (aniversario > DateTime.Now)
                    throw new ArgumentException();

                ConfirmarOperacao(nome, sobrenome, aniversario);

            }
            catch (FormatException)
            {
                Console.WriteLine("Formato inválido. Repita a operação!");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Data de aniversário não pode ser maior que a data atual");
            }
        }

        static void ListarPessoas()
        {
            Console.WriteLine("*-*-*-*-Listar Pessoas:-*-*-*-*");
            List<Pessoa> lista = Service.ListaPessoas();

            if (lista.Count == 0)
                Console.WriteLine("Não há registros de pessoas no momento. Adicione pessoas através da opção 3 do Menu!");
            else
                lista.ForEach(p => Console.WriteLine($"*-*-> Nome: {p.Nome}\nSobrenome: {p.Sobrenome}\n" +
                $"Data de nascimento: {p.Aniversario.ToString("dd/MM/yyyy")}"));
        }


        static void BuscarPessoa()
        {
            Console.WriteLine("*-*-*-*-Pesquisar Pessoa:-*-*-*-*");
            Console.WriteLine("Insira o nome da pessoa: ");
            var nome = Console.ReadLine();
            Console.WriteLine("Insira o sobrenome da pessoa: ");
            var sobrenome = Console.ReadLine();

            Pessoa pessoa = Service.BuscaPessoa(nome, sobrenome);

            if (pessoa != null)
            {
                int dias = CalcularAniversario(pessoa.Aniversario);
                Console.WriteLine(pessoa.ToString());
                Console.WriteLine($"Dias para o próximo aniversário: {dias}");
            }
            else
            {
                Console.WriteLine("Pessoa não encontrada!");
            }

        }

        static int CalcularAniversario(DateTime aniversario)
        {

            DateTime proxAniversario = new(DateTime.Today.Year, aniversario.Month, aniversario.Day);


            if (DateTime.Today.Month > aniversario.Month)
            {

                proxAniversario = new(DateTime.Today.Year + 1, aniversario.Month, aniversario.Day);

            }
            return (int)proxAniversario.Subtract(DateTime.Today).TotalDays;
        }
    }
}
