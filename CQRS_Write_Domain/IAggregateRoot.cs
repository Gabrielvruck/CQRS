using CQRS_Write_Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Write_Domain
{
    public interface IAggregateRoot<T> : IAggregateRoot
    {
        T Id { get; }
    }
    public interface IAggregateRoot
    {
        object GetId();
        int Version { get; }
        //Obter alterações não confirmadas
        IEnumerable<IEvent> GetUncommittedChanges();
        //Marcar alterações como confirmadas
        void MarkChangesAsCommitted();
        //Cargas da História
        void LoadsFromHistory(IEnumerable<IEvent> history);
        //Aplicar alteração
        void ApplyChange(IEvent @event, bool isNew = true);
    }
}
