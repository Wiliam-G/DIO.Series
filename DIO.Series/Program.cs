using System;

namespace DIO.Series
{
    class Program
    {
        private const string V = "0";
        static SeriesRepositorio repositorioSeries = new SeriesRepositorio();
        static FilmesRepositorio repositorioFilmes = new FilmesRepositorio();
        static void Main(string[] args)
        {
            string tipoCadastro = ObterTipoCadastro();

            while (tipoCadastro.ToUpper() != "X")
            {
                switch (tipoCadastro)
                {
                    case "1":
                        CadastrarFilmes();
                        break;
                    case "2":
                        CadastrarSeries();
                        break;
                    case "X":
                        Environment.Exit(0);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                tipoCadastro = ObterTipoCadastro();
            }

            static void CadastrarFilmes()
            {
                Console.WriteLine("Filmes");
                string opcaoUsuario = ObterOpcaoUsuario();

                while (opcaoUsuario.ToUpper() != "X")
                {
                    switch (opcaoUsuario)
                    {
                        case "1":
                            ListarFilmes();
                            break;
                        case "2":
                            InserirFilme();
                            break;
                        case "3":
                            AtualizarFilme();
                            break;
                        case "4":
                            ExcluirFilme();
                            break;
                        case "5":
                            VisualizarFilme();
                            break;
                        case "C":
                            Console.Clear();
                            break;
                        case "X":
                            ObterTipoCadastro();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    opcaoUsuario = ObterOpcaoUsuario();
                }

               
            }


            static void CadastrarSeries()
            {
                Console.WriteLine("Séries");

                string opcaoUsuario = ObterOpcaoUsuario();

                while (opcaoUsuario.ToUpper() != "X")
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
                            ObterTipoCadastro();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                   
                    Console.ReadLine();
                    opcaoUsuario = ObterOpcaoUsuario();

                }

                
            }


            static string ObterTipoCadastro()
            {
                Console.WriteLine("DIO a seu dispor");
                Console.WriteLine("");
                Console.WriteLine("1- Cadastrar Filmes");
                Console.WriteLine("2- Cadastrar Séries");
                Console.WriteLine("x- Sair");
                Console.WriteLine("");

                return Console.ReadLine().ToUpper();
            }

            // #FILMES

            static void ListarFilmes()
            {
                Console.WriteLine("Listar filmes");

                var lista = repositorioFilmes.Lista();

                if (lista.Count == 0 )
                {
                    Console.WriteLine("Nenhum filme encontrado!");
                    return;
                }

                foreach (var filme in lista)
                {
                    var excluido = filme.retornaExcluido();
                    Console.WriteLine("#ID{0}: -{1}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "Série excluida" : ""));


                }
            }

            static void InserirFilme()
            {
                Console.WriteLine("Inserir filme");

                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                }
                Console.Write("Digite o gênero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.Write("Digite o título do filme: ");
                string entradaTitulo = Console.ReadLine();

                Console.Write("Digite o ano de início do filme: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.Write("Digite a descrição do filme: ");
                string entradaDescricao = Console.ReadLine();

                Filme novoFilme = new Filme(id: repositorioFilmes.ProximoId(),
                    genero: (Genero)entradaGenero,
                    titulo: entradaTitulo,
                    ano: entradaAno,
                    descricao: entradaDescricao);

                repositorioFilmes.Insere(novoFilme);
            }

            static void AtualizarFilme()
            {
                Console.WriteLine("Digite o id do filme: ");
                int indiceFilme = int.Parse(Console.ReadLine());

                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("#ID {0}-{1}", i, Enum.GetName(typeof(Genero), i));

                }

                Console.WriteLine("Digite o gênero do filme: ");
                int entraGenero = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o título do filme: ");
                string entraTitulo = Console.ReadLine();

                Console.WriteLine("Digite o ano de início do filme: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite a descrição do filme: ");
                string entraDescrição = Console.ReadLine();

                Filme atualizaFilme = new Filme(id: indiceFilme,
                    genero: (Genero)entraGenero,
                    titulo: entraTitulo,
                    ano: entradaAno,
                    descricao: entraDescrição
                    );

                repositorioFilmes.Atualiza(indiceFilme, atualizaFilme);

            }

            static void ExcluirFilme()
            {
                Console.WriteLine("Digite o id do filme: ");
                int indiceFilme = int.Parse(Console.ReadLine());

                repositorioFilmes.Exclui(indiceFilme);

            }

            static void VisualizarFilme()
            {
                Console.WriteLine("Digite o id do filme: ");
                int indiceFilme = int.Parse(Console.ReadLine());

                var filme = repositorioFilmes.RetornaPorId(indiceFilme);
                Console.WriteLine(filme);
            }


            // #SÉRIES  

            static void ListarSeries()
            {
                Console.WriteLine("Listar séries");

                var lista = repositorioSeries.Lista();

                if (lista.Count == 0)
                {
                    Console.WriteLine("Nenhuma série encontrada.");
                    return;
                }


                foreach (var serie in lista)
                {
                    var excluido = serie.retornaExcluido();

                    Console.WriteLine("#ID{0}: -{1}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Série excluida" : ""));
                }
            }

            static void InserirSerie()
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

                Console.Write("Digite a descrição da série: ");
                string entradaDescricao = Console.ReadLine();

                Serie novaSerie = new Serie(id: repositorioSeries.ProximoId(),
                    genero: (Genero)entradaGenero,
                    titulo: entradaTitulo,
                    ano: entradaAno,
                    descricao: entradaDescricao);

                repositorioSeries.Insere(novaSerie);
            }

            static void AtualizarSerie()
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

                Console.WriteLine("Digite a descrição da série: ");
                string entraDescrição = Console.ReadLine();

                Serie atualizaSerie = new Serie(id: indiceSerie,
                    genero: (Genero)entraGenero,
                    titulo: entraTitulo,
                    ano: entradaAno,
                    descricao: entraDescrição
                    );

                repositorioSeries.Atualiza(indiceSerie, atualizaSerie);

            }

            static void ExcluirSerie()
            {
                Console.WriteLine("Digite o id da série: ");
                int indiceSerie = int.Parse(Console.ReadLine());

                repositorioSeries.Exclui(indiceSerie);

            }

            static void VisualizarSerie()
            {
                Console.WriteLine("Digite o id da série: ");
                int indiceSerie = int.Parse(Console.ReadLine());

                var serie = repositorioSeries.RetornaPorId(indiceSerie);
                Console.WriteLine(serie);
            }

            static string ObterOpcaoUsuario()
            {
                Console.WriteLine();
                Console.WriteLine("Escolha entre as opções abaixo");
                Console.WriteLine("1- Listar");
                Console.WriteLine("2- Inserir");
                Console.WriteLine("3- Atualizar");
                Console.WriteLine("4- Excluir");
                Console.WriteLine("5- Visualizar");
                Console.WriteLine("c- Limpar o terminal");
                Console.WriteLine("x- Voltar ao início");
                Console.WriteLine();

                string opcaoUsuario = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return opcaoUsuario;
            }

        }
    } }
