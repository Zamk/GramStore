namespace GramStore.MenuService.Models
{
    public class Organization
    {
        public long Id { get; set; }
        public long ClientId {  get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
