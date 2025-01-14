﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using DevIO.AppMvc.Models.ViewModels;
using DevIO.Business.Models.Produtos;
using DevIO.Business.Models.Produtos.Services;

namespace DevIO.AppMvc.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoRepository produtoRepository, 
                                  IProdutoService produtoService, 
                                  IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [HttpGet, Route("lista-de-produtos")]
        public async Task<ActionResult> Index()
        {
            var produtosViewModel = _mapper.Map<IEnumerable<ProdutoViewModel>>
                (await _produtoRepository.ObterTodos());

            return View(produtosViewModel);
        }

        [HttpGet, Route("dados-do-produto/{id:guid}")]
        public async Task<ActionResult> Details(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);

            if (produtoViewModel == null)
                return HttpNotFound();

            return View(produtoViewModel);
        }

        [HttpGet, Route("novo-produto")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, Route("novo-produto"), ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                await _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel));

                return RedirectToAction("Index");
            }

            return View(produtoViewModel);
        }

        [HttpGet, Route("editar-produto/{id:guid}")]
        public async Task<ActionResult> Edit(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);

            if (produtoViewModel == null)
                return HttpNotFound();

            return View(produtoViewModel);
        }

        [HttpPost, Route("editar-produto/{id:guid}"), ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                await _produtoRepository.Atualizar(_mapper.Map<Produto>(produtoViewModel));
                
                return RedirectToAction("Index");
            }

            return View(produtoViewModel);
        }

        [HttpGet, Route("excluir-produto/{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);

            if (produtoViewModel == null)
                return HttpNotFound();

            return View(produtoViewModel);
        }

        [HttpPost, Route("excluir-produto/{id:guid}"), ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);

            if (produtoViewModel == null)
                return HttpNotFound();

            await _produtoRepository.Remover(id);

            return RedirectToAction("Index");
        }

        private async Task<ProdutoViewModel> ObterProduto(Guid id)
        {
            var produto = _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterProdutoFornecedor(id));

            return produto;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _produtoRepository?.Dispose();
                _produtoService?.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
