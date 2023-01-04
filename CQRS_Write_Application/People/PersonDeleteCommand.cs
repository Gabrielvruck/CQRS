using CQRS_Write_Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Write_Application.People
{
    public class PersonDeleteCommand : Command
    {
        public int Id { get; set; }

        public PersonDeleteCommand(int id)
        {
            this.Id = id;
        }
    }
}
