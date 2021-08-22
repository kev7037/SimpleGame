using AutoMapper;
using Game.DTOs;
using Game.Models;
using Game.Repo.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Game.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;

        public HomeController(IUnitOfWork unitOfWork, ILogger<HomeController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> NextImage(int id)
        {
            if (!(id > 0 && id < 14))
            {
                _logger.LogError($"Invalid Update attempt in {nameof(NextImage)}");
                return BadRequest(ModelState);
            }
            var gameData = await _unitOfWork.GameData.Get(expression: x => x.Id == id);
            var mappedGameData = _mapper.Map<GameDataDto>(gameData);
            
            CustomActionResult<GameDataDto> result = new CustomActionResult<GameDataDto>();
            result.Data = mappedGameData;
            result.IsSuccess = true;

            return Ok(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
