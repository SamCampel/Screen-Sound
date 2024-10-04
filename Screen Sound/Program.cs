using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

internal class Program
{
    private static void Main(string[] args)
    {
        // Screen Sound;
        string Mensagem = "Boas vindas ao Screen Sound!";
        Dictionary<string, List<int>> dicionarioBandas = new Dictionary<string, List<int>>();
        dicionarioBandas.Add("Queen", new List<int> { 10, 9, 10, 7 });
        dicionarioBandas.Add("Linkin Park", new List<int>());


        // void - função;
        void ExibirLogo()
        {   //verbatim literal
            Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗    ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║    ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║    ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║    ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║    ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝    ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░

");
            Console.WriteLine(Mensagem);
        }

        void OpcoesMenu()
        {
            ExibirLogo();
            Console.WriteLine("\nDigite 1 para registrar uma banda");
            Console.WriteLine("Digite 2 para mostrar todas as bandas");
            Console.WriteLine("Digite 3 para avaliar uma banda");
            Console.WriteLine("Digite 4 para exibir a média de uma banda");
            Console.WriteLine("Digite -1 para sair");

            Console.Write("\nDigite a sua opção: ");
            string opcaoE = Console.ReadLine()!;
            int opcaoEnum = int.Parse(opcaoE);

            switch (opcaoEnum)
            {

                case 1:
                    Registrar();
                    break;
                case 2:
                    BandasRegistradas();
                    break;
                case 3:
                    AvaliarBanda();
                    break;
                case 4:
                    MediaBanda();
                    break;
                case -1:
                    Console.WriteLine(" Tchau! ");
                    break;

                default:
                    Console.WriteLine("Opçãp inválida");
                    break;
            }

        }
        void Registrar()
        {
            Console.Clear();
            ExibirLogo();
            Console.WriteLine("\n**********************************");
            Console.WriteLine("Registro de banda!");
            Console.WriteLine("**********************************\n");
            Console.Write("Digite o nome da banda que deseja registrar: ");
            string nomeBanda = Console.ReadLine()!;
            dicionarioBandas.Add(nomeBanda, new List<int>());
            Console.WriteLine($"A banda {nomeBanda} foi registrada com sucesso!");
            Thread.Sleep(2000);
            Console.Clear();

            OpcoesMenu();
        }

        void BandasRegistradas()
        {
            Console.Clear();
            ExibirLogo();
            Console.WriteLine("\n**********************************");
            Console.WriteLine("Bandas Registradas!");
            Console.WriteLine("**********************************\n");
            foreach (string banda in dicionarioBandas.Keys)
            {
                Console.WriteLine($"Banda: {banda}");
            }
            Console.WriteLine("\nDigite qualquer tecla para voltar ao menu.");
            Console.ReadKey();
            Console.Clear();
            OpcoesMenu();
        }

        void AvaliarBanda()//verificar se a banda existe para avaliar
        {
            Console.Clear();
            ExibirLogo();
            Console.WriteLine("\n**********************************");
            Console.WriteLine("Avaliar banda!");
            Console.WriteLine("**********************************\n");
            Console.Write("Digite o nome da banda que deseja avaliar: ");
            string nomeDAbanda = Console.ReadLine()!;
            if (dicionarioBandas.ContainsKey(nomeDAbanda))
            {
                List<int> notasDaBanda = dicionarioBandas[nomeDAbanda];
                Console.Write($"Digite a nota que vc quer dar para a banda {nomeDAbanda}: ");
                int nota = int.Parse(Console.ReadLine()!);
                dicionarioBandas[nomeDAbanda].Add(nota);
                Console.WriteLine($"\nA nota {nota} foi registrada com sucesso.");
                Thread.Sleep(2000);
                Console.Clear();
                OpcoesMenu();
            }
            else
            {
                Console.WriteLine($"\nA banda {nomeDAbanda} não foi encontrada.");
                Console.WriteLine("Digite qualquer tecla para voltar ao menu.");
                Console.ReadKey();
                Console.Clear();
                OpcoesMenu();
            }
        }

        void MediaBanda()
        {
            Console.Clear();
            ExibirLogo();
            Console.WriteLine("\n**********************************");
            Console.WriteLine("Média das bandas!");
            Console.WriteLine("**********************************\n");
            Console.Write("Digite o nome da banda que deseja ver a média: ");
            string nomeDAbanda = Console.ReadLine()!;
            if (dicionarioBandas.ContainsKey(nomeDAbanda))
            {
                List<int> notasDAbanda = dicionarioBandas[nomeDAbanda];
                Console.WriteLine($"\nA média da banda {nomeDAbanda} é: {notasDAbanda.Average()}.");
                Console.WriteLine("Digite uma tecla para voltar ao menu principal.");
                Console.ReadKey();
                Console.Clear();
                OpcoesMenu();
            }
            else
            {
                Console.WriteLine($"\nA banda {nomeDAbanda} não foi encontrada.");
                Console.WriteLine("Digite qualquer tecla para voltar ao menu.");
                Console.ReadKey();
                Console.Clear();
                OpcoesMenu();
            }
        }

        OpcoesMenu();
    }
}