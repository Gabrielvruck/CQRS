using CQRS_read_Application.People;
using CQRS_Write_Domain.Commands;
using CQRS_Write_Domain.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Write_Application.People
{
    public class PersonCommandHandlers : ICommandHandler<PersonCreateCommand>, ICommandHandler<PersonDeleteCommand>, ICommandHandler
    {
        private readonly ICommandEventRepository eventRepository;
        private readonly IPersonService personService;

        public PersonCommandHandlers(IPersonService personService, ICommandEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
            this.personService = personService;
        }

        public void Handle(PersonCreateCommand command)
        {
            Person person = new Person(this.personService.GetAll().Count() + 1,
                command.Class, command.Nome, command.Idade);
            this.eventRepository.Save(person);
        }

        public void Handle(PersonDeleteCommand command)
        {
            Person person = this.eventRepository.GetByCommandId<Person>(command.Id);
            person.Delete();
            this.eventRepository.Save(person);
        }

        public void Handle(PersonRenameCommand command)
        {
            Person person = this.eventRepository.GetByCommandId<Person>(command.Id);
            person.Rename(command.Nome);
            this.eventRepository.Save(person);
        }
    }
}
