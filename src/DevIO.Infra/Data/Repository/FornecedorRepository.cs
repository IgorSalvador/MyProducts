using DevIO.Business.Models.Fornecedores;
using DevIO.Infra.Data.Context;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DevIO.Infra.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await db.Fornecedores.AsNoTracking()
                .Include(f => f.Endereco)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedoresProdutoEndereco(Guid id)
        {
            return await db.Fornecedores.AsNoTracking()
                .Include(f => f.Endereco)
                .Include(f => f.Produtos)
                .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
