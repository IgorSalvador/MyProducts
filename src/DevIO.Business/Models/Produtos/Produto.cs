﻿using DevIO.Business.Core.Models;
using DevIO.Business.Models.Fornecedores;
using System;


namespace DevIO.Business.Models.Produtos
{
    public class Produto : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public Guid FornecedorId { get; set; }

        public Fornecedor Fornecedor { get; set; }
    }
}
