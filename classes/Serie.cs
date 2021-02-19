using System;
using DIO.Series.enums;

namespace DIO.Series.classes
{
    public class Serie: EntidadeBase
    {

        //Atributos

        public Genero Genero { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Ano { get; set; }
        public bool isExcluido { get; set; }
    
        // Construtor Default

        public Serie()
        {
            
        }
        
        // Métodos da classe

        public Serie(int id, Genero genero, string titulo, int ano, string descricao, bool? isExcluido){

            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Ano = ano;
            this.Descricao = descricao;

            if(isExcluido != null)
                this.isExcluido = isExcluido.Value;

        }

        public override string ToString()
        {
            
            string retorno = "";
            retorno += "Genero " + this.Genero + Environment.NewLine;
            retorno += "Titulo " + this.Titulo + Environment.NewLine;
            retorno += "Descrição " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início " + this.Ano;

            return retorno; 


        }

        public string retornaTitulo(){

            return this.Titulo;

        }

        public int retornaId(){

            return this.Id;

        }

        public void Excluir()
        {
            this.isExcluido = true;
        }


    }
}