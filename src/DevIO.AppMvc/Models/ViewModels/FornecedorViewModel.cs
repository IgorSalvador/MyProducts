using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DevIO.AppMvc.Models.ViewModels
{
    public class FornecedorViewModel
    {
        public FornecedorViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.")]
        public string Nome { get; set; }

        [DisplayName("Documento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.")]
        public string Documento { get; set; }

        [DisplayName("Tipo")]
        public int TipoFornecedor { get; set; }

        public EnderecoViewModel Endereco { get; set; }

        [DisplayName("Status")]
        public bool Ativo { get; set; }

        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}