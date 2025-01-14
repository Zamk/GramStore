namespace GramStore.MenuService.Models
{
    public class Product
    {
        public long Id { get; set; }
        public long OrganizationId { get; set; }
        public long CategoryId {  get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageLink { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
