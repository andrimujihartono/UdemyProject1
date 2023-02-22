using Core.Entities;

namespace Core.Spesifications
{
    public class ProductWithTypesAndBrandsSpesification
        : BaseSpesification<Product>
    {
        public ProductWithTypesAndBrandsSpesification(string sort, int? brandId, int? typeId) : base(x =>
            (!brandId.HasValue || x.ProductBrandId == brandId) &&  
            (!typeId.HasValue || x.ProductTypeId == typeId)
        )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);

            if(!string.IsNullOrEmpty(sort))
            {
                switch(sort)
                {
                    case "priceAsc":
                        AddOrderBy(x => x.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(x => x.Price);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
        }
        public ProductWithTypesAndBrandsSpesification(int id) : base(x=> x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            
        }
    }
}