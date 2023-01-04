using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Write_Domain.People
{
    public class PersonType
    {
        public PersonClass Class { get; private set; }
        public string Nome { get; private set; }
        public int Idade { get; private set; }
        public PersonType(PersonClass personClass, String nome, int idade)
        {
            this.Class = personClass;
            this.Nome = nome;
            this.Idade = idade;
        }
    }
}
