namespace GramStore.Nomenclature.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(object name, object key) 
            : base($"Entity \"{name}\" ({key}) not found.") { }
    }
}
