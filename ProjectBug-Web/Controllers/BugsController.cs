using Microsoft.AspNetCore.Mvc;
using ProjectBug_Services;
using ProjectBug_Services.DTO;

namespace ProjectBug_Web.Controllers
{
    [ApiController]
    
    public class BugsController : ControllerBase
    {
        private IBugServices _bugServices;
        private readonly ILogger<WeatherForecastController> _logger;

        public BugsController(ILogger<WeatherForecastController> logger, IBugServices bugServices)
        {
            _logger = logger;
            _bugServices = bugServices;
        }

        [HttpGet]
        [Route("bugs")]
        public IActionResult FindAll([FromQuery] string? project_id, [FromQuery] string? user_id, [FromQuery] string? start_date, [FromQuery] string? end_date)
        {
            if(String.IsNullOrEmpty(project_id) && String.IsNullOrEmpty(user_id) && String.IsNullOrEmpty(start_date) && String.IsNullOrEmpty(end_date))
            {
                return BadRequest();
            }
            else {
               BugFilter filter = new BugFilter() { 
               CreatedAt = new RangeFilter<DateTime?>
                    {
                        From = !String.IsNullOrEmpty(start_date)?Convert.ToDateTime(start_date) : null,
                        To = !String.IsNullOrEmpty(start_date) ? Convert.ToDateTime(end_date) : null,
                    },
               ProjectId = !String.IsNullOrEmpty(project_id) ? Convert.ToInt32(project_id) : null,
               UserId = !String.IsNullOrEmpty(user_id) ? Convert.ToInt32(user_id) : null   
               
               };
               var data = _bugServices.FindAll(filter);

               if(data.Bugs.Count == 0) return NotFound();

               return Ok(data);
            }

        }
        [HttpPost]
        [Route("bug")]
        public IActionResult Create([FromBody] BugInput bugInput)
        {
            var id = _bugServices.Create(bugInput);
            if(id == 0) { return BadRequest(); }
            return Ok(id);
        }
    }
}