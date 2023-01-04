using CQRS_Write_Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Write_Application.People
{
    public class PersonRenameCommand : Command
    {
        public int Id { get; }
        public string Nome { get; }

        public PersonRenameCommand(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }
    }
}
