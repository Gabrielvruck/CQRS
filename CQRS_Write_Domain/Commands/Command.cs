using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Write_Domain.Commands
{
    public class Command : ICommand
    {
        public string Type
        {

            get
            {
                return this.GetType().Name;
            }

        }
    }
}
