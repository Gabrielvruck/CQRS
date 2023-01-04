using CQRS_read_Infrastructure.Persistence.People;

namespace CQRS_read_Infrastructure.Persistence
{
    public interface IContexto
    {
        IPersonRepository People { get; set; }
    }
}
