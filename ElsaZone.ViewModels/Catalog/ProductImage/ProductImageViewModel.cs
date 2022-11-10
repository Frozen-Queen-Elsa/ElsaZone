using ElsaZone.Data.Enums.Common;

namespace ElsaZone.ViewModels.Catalog.ProductImage
{
    public class ProductImageViewModel
    {
        public int ProductImageId { get; set; }

        public int ProductId { get; set; }

        public string ImagePath { get; set; }

        public string Caption { get; set; }

        public IsDefault IsDefault { get; set; }

        public DateTime CreatedDate { get; set; }

        public int SortOrder { get; set; }

        public long FileSize { get; set; }
    }
}