namespace GramStore.MenuService.Models
{
    public class Category
    {
        public long Id { get; set; }
        public long OrganizationId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
