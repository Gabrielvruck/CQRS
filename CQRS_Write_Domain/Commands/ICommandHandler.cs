using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Write_Domain.Commands
{
    public interface ICommandHandler<T> : ICommandHandler where T : ICommand
    {
        void Handle(T command);
    }
    public interface ICommandHandler { }
}
