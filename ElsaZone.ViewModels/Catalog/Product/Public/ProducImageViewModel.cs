using ElsaZone.Data.Enums.Common;

namespace ElsaZone.ViewModels.Catalog.Product.Public;

public class ProducImageViewModel
{
    public int ProductImageId { get; set; }
    public string ImagePath { get; set; }
    public IsDefault IsDefault { get; set; }
    public long FileSize { get; set; }
}