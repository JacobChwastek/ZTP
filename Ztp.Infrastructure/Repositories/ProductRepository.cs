using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Ztp.Domain.Products;
using Ztp.Domain.Repositories;
using Ztp.Infrastructure.EF;
using Ztp.Infrastructure.EF.Models;
using Ztp.Shared.Abstractions.Exceptions;

namespace Ztp.Infrastructure.Repositories;

internal class ProductRepository(LabDbContext dbContext) : IProductRepository
{
    private readonly LabDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task SaveProduct(Product product, CancellationToken cancellationToken = default)
    {
        await _dbContext.Database.EnsureCreatedAsync(cancellationToken);
        var dbProduct = await _dbContext.Products.SingleOrDefaultAsync(x => x.Id == product.Id,
            cancellationToken: cancellationToken);

        var productDetailsDbModel = product.Details ?? (ProductDetailsDbModel)product.Details;

        if (dbProduct is null)
        {
            await _dbContext.AddAsync(new ProductDbModel
            {
                Id = product.Id,
                Version = product.Version,
                Details = productDetailsDbModel,
                CreatedAt = product.CreatedAt,
                IsDeleted = product.IsDeleted,
                UpdatedAt = product.UpdateAt,
                Changelog = JsonConvert.SerializeObject(product.Changelog)
            }, cancellationToken);
        }
        else
        {
            dbProduct.Details = productDetailsDbModel;
            dbProduct.IsDeleted = product.IsDeleted;
            dbProduct.CreatedAt = product.CreatedAt;
            dbProduct.UpdatedAt = product.UpdateAt;
            dbProduct.Version = product.Version;
            dbProduct.Changelog = JsonConvert.SerializeObject(product.Changelog);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Product>> BrowseProducts(CancellationToken cancellationToken = default)
    {
        await _dbContext.Database.EnsureCreatedAsync(cancellationToken);
        var dbProducts = await _dbContext.Products.Include(productDbModel => productDbModel.Details)
            .ThenInclude(productDetailsDbModel => productDetailsDbModel!.Price)
            .ToListAsync(cancellationToken: cancellationToken);

        return dbProducts.Select(p => new Product(
                p.Id,
                p.Details,
                p.CreatedAt,
                p.UpdatedAt,
                JsonConvert.DeserializeObject<List<ProductDetails>>(p.Changelog), p.Version))
            .ToList().AsReadOnly();
    }

    public async Task<Product> GetProductById(Guid productId, CancellationToken cancellationToken = default)
    {
        await _dbContext.Database.EnsureCreatedAsync(cancellationToken);
        var dbProduct = await _dbContext.Products.Include(productDbModel => productDbModel.Details)
            .ThenInclude(productDetailsDbModel => productDetailsDbModel!.Price)
            .SingleOrDefaultAsync(p => p.Id == productId, cancellationToken: cancellationToken);


        if (dbProduct is null)
        {
            throw new DoesNotExistException(nameof(Product), productId.ToString());
        }

        var changeLog = JsonConvert.DeserializeObject<List<ProductDetails>>(dbProduct.Changelog);

        return new Product(dbProduct.Id, (ProductDetails)dbProduct.Details, dbProduct.CreatedAt, dbProduct.UpdatedAt, changeLog, dbProduct.Version);
    }
}