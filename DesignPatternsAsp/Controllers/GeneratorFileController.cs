using DesignPatterns.Models.Data;
using DesignPatterns.Repository;
using Microsoft.AspNetCore.Mvc;
using Tools.Generator;

namespace DesignPatternsAsp.Controllers
{
    public class GeneratorFileController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private GeneratorConcreteBuilder _generatorConcreteBuilder;

        public GeneratorFileController(IUnitOfWork unitOfWork, GeneratorConcreteBuilder generatorConcreteBuilder)
        {
            _unitOfWork = unitOfWork;
            _generatorConcreteBuilder = generatorConcreteBuilder;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateFile(int optionFile)
        {
            try
            {
                IEnumerable<Beer> beers = _unitOfWork.Beers.Get();
                List<string> content = beers.Select(b => b.Name).ToList();
                string path = "file" + DateTime.Now.Ticks + new Random().Next(1000) + ".txt";

                var generatorDirector = new GeneratorDirector(_generatorConcreteBuilder);

                switch (optionFile)
                {
                    case 1:
                        generatorDirector.CreateSimpleJsonGenerator(content, path);
                        break;
                    case 2:
                        generatorDirector.CreateSimplePipeGenerator(content, path);
                        break;
                }

                var generator = _generatorConcreteBuilder.GetGenerator();
                generator.Save();

                return Json("File generated");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
