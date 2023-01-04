using CQRS_read_Application.People;
using CQRS_read_Infrastructure.Persistence;
using CQRS_read_Infrastructure.Persistence.People;
using CQRS_Write_Application.People;
using CQRS_Write_Domain.Commands;
using CQRS_Write_Domain.People;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationCQRS.Models;

namespace WebApplicationCQRS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ICommandBus commandBus;
        private IPersonService personService;
        private ICommandEventRepository commandEventRepository;
        private IContexto context;
        private IPersonRepository personRepository;
       
        public HomeController(ILogger<HomeController> logger,
           ICommandBus commandBus, IPersonService personService, ICommandEventRepository commandEventRepository
           , IPersonRepository personRepository)
        {
            _logger = logger;
            this.commandBus = commandBus;
            this.personService = personService;
            this.commandEventRepository = commandEventRepository;
            this.personRepository = personRepository;
            this.context = new Contexto(personRepository);
        }


        public IActionResult Index()
        {
            //registrando os comandos handlers
            commandBus.RegisterCommandHandlers(new PersonCommandHandlers(personService, commandEventRepository));
            //registrando os eventos
            commandBus.RegisterEventHandlers(new PersonEventsHandlers(personService));

            commandBus.Send(new PersonCreateCommand(CQRS_Write_Domain.People.PersonClass.Admin, "Lucas", 38));
            commandBus.Send(new PersonCreateCommand(CQRS_Write_Domain.People.PersonClass.Admin, "Beatriz", 5));
            commandBus.Send(new PersonCreateCommand(CQRS_Write_Domain.People.PersonClass.Comum, "Cna Vruck", 25));
            commandBus.Send(new PersonCreateCommand(CQRS_Write_Domain.People.PersonClass.Comum, "Gabriela Beleza", 50));

            //leitura dos registro cadastrado
            var lista = personRepository.Get();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}