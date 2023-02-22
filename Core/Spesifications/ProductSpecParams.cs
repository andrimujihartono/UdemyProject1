namespace Core.Spesifications
{
    public class ProductSpecParams
    {
        private const int PageSizeMax = 50;
        public int PageIndex {get; set; } = 1;
        private int _pageSize = 6;	
        public int PageSize {
            get => _pageSize;
            set => _pageSize = (value > PageSizeMax) ? PageSizeMax : value;
        }
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public string Sort { get; set; }

    }
    
}