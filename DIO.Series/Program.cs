using System;

namespace DIO.Series
{
    class Program
    {
        static SeriesRepositorio repositorio = new SeriesRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "x")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                         AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "X":
                        Environment.Exit(0);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.ReadLine();

        }

        public static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série encontrada.");
                return;
            }
            

            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                
                Console.WriteLine("#ID{0}: -{1}", serie.retornaId(), serie.retornaTitulo(),(excluido ? "Série excluida": "" ));
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("#ID {0}-{1}", i, Enum.GetName(typeof(Genero), i));
              
            }

                Console.WriteLine("Digite o gênero da série: ");
                int entraGenero = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o título da série: ");
                string entraTitulo = Console.ReadLine();

                Console.WriteLine("Digite o ano de início da série: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite a descrição da sérieÇ: ");
                string entraDescrição = Console.ReadLine();

                Serie atualizaSerie = new Serie(id: indiceSerie,
                    genero: (Genero)entraGenero,
                    titulo: entraTitulo,
                    ano: entradaAno,
                    descricao: entraDescrição
                    );

                repositorio.Atualiza(indiceSerie, atualizaSerie);
            
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
           
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor");
            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série ");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("c- Limpar o terminal");
            Console.WriteLine("x- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

    }
}
