﻿using Shop.Application.Catalog.Specifications;
using Shop.Application.Interfaces;
using Shop.Entities.Catalog;

namespace Shop.Application.Catalog.UseCases.Read;

public class GetProgramProductsByCodeUseCase<TOutput>
{
    private readonly IRepository<ProgramProduct> _productRepository;
    private readonly IPresenter<ProgramProduct, TOutput> _presenter;

    public GetProgramProductsByCodeUseCase(IRepository<ProgramProduct> productRepository, IPresenter<ProgramProduct, TOutput> presenter)
    {
        _productRepository = productRepository;
        _presenter = presenter;
    }

    public async Task<TOutput?> ExecuteAsync(int programId, string productCode)
    {
        var spec = new GetProgramProductSpecification(programId, productCode);

        var products = await _productRepository.GetEntityWithSpec(spec);

        return _presenter.Present(products);
    }
}