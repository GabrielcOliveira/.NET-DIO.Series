using System;
using DIO.Series.classes;
using DIO.Series.enums;

namespace DIO.Series
{
    class Program
    {

        static readonly SerieRepositorio repositorio = new SerieRepositorio();
        static readonly Escreva obj = new Escreva();

        static void Main(string[] args)
        {
            exibirMenu();

            obj.escrevaL("Encerrando o programa.");
        }

        private static string obterOpcaoUsuario()
        {
            
            obj.escrevaL("------------------------------------Exibindo o Menu------------------------------");

            obj.escrevaL("DIO Séries e a seu dispor !!!");
            
            obj.escrevaL("Informe a opção desejada");
            
            obj.escrevaL("1 - Listar séries");
            obj.escreva("2 - Inserir nova série");
            obj.escreva("3 - Atualizar série");
            obj.escreva("4 - Excluir série");
            obj.escreva("5 - Visualizar Serie");
            obj.escreva("L - Limpar Tela");
            obj.escreva("S - Sair");
            
            obj.escrevaL("Qual opção deseja ?: ");
            string opcaoUsuario = Console.ReadLine();
            obj.escreva("");
            return opcaoUsuario;

        }

        private static void exibirMenu(){

            var opt = obterOpcaoUsuario().ToUpper();

            while(opt != "S"){

                switch(opt)
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

                    case "L":
                        Console.Clear();
                        break;

                    case "S":
                        opt = "S";
                        break;

                
                }

                if(opt != "S")
                opt = obterOpcaoUsuario().ToUpper();

            }


        }

        // Métodos de Operação do menu

        private static void ListarSeries()
        {
            obj.escreva("Listar séries");
            obj.escreva("");

            var lista = repositorio.Lista();

            if(lista.Count == 0){
                 obj.escreva("Nenhuma série foi cadastrada.");
                 return;
            }

            foreach(var serie in lista){
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), serie.isExcluido == true ? "(Esta série foi excluída)" : "");
            }
        }

        private static void InserirSerie() {

            obj.escrevaL("Inserir nova série");
            obj.escreva("");

            // Inserindo....
            repositorio.Insere(exibirFormulario(null));

        }

        private static void AtualizarSerie() {

            obj.escrevaL("Atualizar série");
            obj.escreva("");

            // Atualizando....
            obj.escrevaL("Selecione o ID da Série que deseja atualizar: ");
            int id = int.Parse(Console.ReadLine());

            obj.escreva("");

            repositorio.Atualiza(id, exibirFormulario(id));

        }

        private static void VisualizarSerie() {

            obj.escrevaL("Selecione o ID da Série que deseja visualizar: ");
            int id = int.Parse(Console.ReadLine());

            var entidade = repositorio.RetornaPorId(id);

            obj.escrevaL("\nTitulo: "+ entidade.Titulo);
            obj.escreva("\nGenero: "+ entidade.Genero);
            obj.escreva("\nAno: "+ entidade.Ano);
            obj.escreva("\nDescricao: "+ entidade.Descricao);
            obj.escreva("\nExcluída ?: "+ (entidade.isExcluido == true ? "Sim" : "Não"));
        
        }

        private static void ExcluirSerie() {

            obj.escrevaL("Excluir série");
            obj.escreva("");

            // Excluindo....
            obj.escrevaL("Selecione o ID da Série que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            repositorio.Exclui(id);
            obj.escrevaL("Série excluida com sucesso!");

        }

        private static Serie exibirFormulario(int? id) {

            foreach(int item in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", item, Enum.GetName(typeof(Genero), item));
            }

            obj.escrevaL("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            obj.escrevaL("Digite o titulo da série: ");
            string entradaTitulo = Console.ReadLine();

            obj.escrevaL("Digite o Ano de Inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            obj.escrevaL("Digite a Descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            if(id == null) {

                Serie objNovaSerie = new Serie
                (
                    id: repositorio.ProximoId(),
                    genero: (Genero)entradaGenero,
                    titulo: entradaTitulo,
                    ano: entradaAno,
                    descricao: entradaDescricao,
                    isExcluido: false
                );

                return objNovaSerie;

            } else {
                
                bool isExcluido = false;

                if(repositorio.RetornaPorId(id.Value).isExcluido == true){

                    obj.escrevaL("Deseja manter a série como excluída responda Sim ou Não: " );
                    string aux = Console.ReadLine();
                    

                    if(aux.Equals("Sim"))
                        isExcluido = true;

                }

                Serie objNovaSerie = new Serie
                (
                    id: id.Value,
                    genero: (Genero)entradaGenero,
                    titulo: entradaTitulo,
                    ano: entradaAno,
                    descricao: entradaDescricao,
                    isExcluido: isExcluido
                );

                return objNovaSerie;

            }


        }

    }

}
