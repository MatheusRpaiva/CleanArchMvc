using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using MediatR;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private IMapper _mapper;
        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ProductDTO> GetByIdAsync(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value);
            if (productByIdQuery == null)
            {
                throw new Exception("Entity could not be loaded");
            }
            var result = await _mediator.Send(productByIdQuery);
            return _mapper.Map<ProductDTO>(result);
        }

        //public async Task<ProductDTO> GetProductCategory(int? id)
        //{
        //    var productByIdQuery = new GetProductByIdQuery(id.Value);
        //    if (productByIdQuery == null)
        //    {
        //        throw new Exception("Entity could not be loaded");
        //    }
        //    var result = await _mediator.Send(productByIdQuery);
        //    return _mapper.Map<ProductDTO>(result);

        //}

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            //var productsEntity = await _productRepository.GetProducts();
            //return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);

            var productsQuery = new GetProductsQuery();
            if (productsQuery == null)
            {
                throw new Exception("Entity could not be loaded");
            }
            var result = await _mediator.Send(productsQuery);
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }
        public async Task add(ProductDTO productDTO)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(productCreateCommand);
        }

        public async Task update(ProductDTO productDTO)
        {
            var productCreateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(productCreateCommand);
        }
        public async Task remove(int? id)
        {
            var productRemove = new ProductRemoveCommand(id.Value);
            if (productRemove == null)
            {
                throw new Exception("Entity could not be loaded");
            }
            await _mediator.Send(productRemove);

        }

    }
}
