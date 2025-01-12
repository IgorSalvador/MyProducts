using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace DevIO.AppMvc.Models.ViewModels
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [DisplayName("Fornecedor")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid FornecedorId { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.")]
        public string Descricao { get; set; }

        //[DisplayName("Imagem do Produto")]
        //public HttpPostedFileBase ImageUpload { get; set; }

        public string Imagem { get; set; }

        [DisplayName("Valor")]
        public decimal Valor { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [DisplayName("Status")]
        public bool Ativo { get; set; }

        //public FornecedorViewModel Fornecedor { get; set; }

        //Coleção de fornecedores para utilização na visualização
        //public IEnumerable<FornecedorViewModel> Fornecedores { get; set; }
    }
}