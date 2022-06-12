using Core.Entities;

namespace Core.Spesifications
{
    public class ProductWithTypesAndBrandsSpesification
        : BaseSpesification<Product>
    {
        public ProductWithTypesAndBrandsSpesification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
        public ProductWithTypesAndBrandsSpesification(int id): base(x=> x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}