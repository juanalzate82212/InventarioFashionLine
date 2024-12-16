using FashionLine.Models;
using MongoDB.Driver;

namespace FashionLine.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<Producto> _products;

        public ProductService(MongoDbService mongoDbService)
        {
            _products = mongoDbService.GetCollection<Producto>("Productos");
        }

        public async Task<List<Producto>> GetAllAsync() =>
            await _products.Find(_ => true).ToListAsync();

        public async Task<Producto> GetByIdAsync(string id) =>
            await _products.Find(p => p.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Producto product) =>
            await _products.InsertOneAsync(product);

        public async Task UpdateAsync(string id, Producto updatedProduct) =>
            await _products.ReplaceOneAsync(p => p.Id == id, updatedProduct);

        public async Task DeleteAsync(string id) =>
            await _products.DeleteOneAsync(p => p.Id == id);
    }
}
