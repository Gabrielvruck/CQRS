using CQRS_Write_Domain.People;
using CQRS_Write_Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Write_Application.People
{
    public class PersonCreateCommand : Command
    {
        public PersonClass Class { get; set; }

        public string Nome { get; set; }

        public int Idade { get; set; }

        public PersonCreateCommand(PersonClass personClass, string nome, int idade)
        {
            this.Class = personClass;
            this.Nome = nome;
            this.Idade = idade;
        }
    }
}
