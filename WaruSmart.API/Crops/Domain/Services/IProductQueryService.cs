using WaruSmart.API.Crops.Domain.Model.Entities;
using WaruSmart.API.Crops.Domain.Model.Queries;

namespace WaruSmart.API.Crops.Domain.Services;

public interface IProductQueryService
{
    /**
     * Return all products
     */
    Task<IEnumerable<Product>> Handle(GetAllProductsQuery query);
    
    /**
     * Return products by type
     */
    Task<IEnumerable<Product>> Handle(GetProductsByTypeQuery query);
    
    /**
     * Return product by id
     */
    Task<Product?> Handle(GetProductByIdQuery query);
}