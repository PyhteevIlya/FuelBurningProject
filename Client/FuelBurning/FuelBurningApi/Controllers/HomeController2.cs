//using AspNetCore;
using Fuel_burning.Models;
using MathLib;
using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FuelBurningApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class HomeController2 : ControllerBase
    {
        private readonly ILogger<HomeController2> _logger;
        private readonly ApplicationContext _context;
        public HomeController2(ILogger<HomeController2> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(nameof(DataInputAdd))]

        public IActionResult DataInputAdd()
        {
            DataGasFuelModel _cs = DataGasFuelModel.GetDefaultModel();
           

            return Ok(_cs);
        }

        [HttpPost(nameof(DataInputAdd))]

        public IActionResult DataInputAdd(DataGasFuelModel dataInputJson)
        {
            //DataOutputModel _rezult = new DataOutputModel(DataInput);

            if (dataInputJson == null) return BadRequest();
            //dataInputJson.TypeCalculation = "GasFuelBurning";

            UserModel? user = _context.Users.FirstOrDefault(x => x.Login == User.Identity.Name);
            if (user == null) return BadRequest();
            dataInputJson.UserId = user.Id;


            _context.DataGasFuelModels.Add(dataInputJson);
            _context.SaveChanges();
            return Ok();

        }

        [HttpGet(nameof(Raschet))]
        public IActionResult Raschet()
        {
            UserModel? user = _context.Users.FirstOrDefault(x => x.Login == User.Identity.Name);
            return Ok(_context.DataGasFuelModels.Where(x => x.UserId == user.Id || x.UserId == 0).ToList());

        }

        [HttpDelete(nameof(Remove))]
        public IActionResult Remove(int id)
        {
            DataGasFuelModel? dataInput = _context.DataGasFuelModels.Find(id);
            if (dataInput == null) return NotFound();
            _context.DataGasFuelModels.Remove(dataInput);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet(nameof(DataInputEdit))]

        public IActionResult DataInputEdit(int id)
        {
            DataGasFuelModel? dataInput = _context.DataGasFuelModels.Find(id);
            if (dataInput == null) return NotFound();
            return Ok(dataInput);
        }

        [HttpPost(nameof(DataInputEdit))]
        public IActionResult DataInputEdit(DataGasFuelModel DataInput)
        {
            if (DataInput == null) return BadRequest();

            var existData = _context.DataGasFuelModels.AsNoTracking().FirstOrDefault(x => x.Id == DataInput.Id);

            if (existData == null) return BadRequest();

            if (existData.Name!= DataInput.Name)
            {
                DataInput.Id = 0;
                _context.DataGasFuelModels.Add(DataInput);
            }
            else
            {
                _context.DataGasFuelModels.Update(DataInput);
            }
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet(nameof(Calc))]
        public IActionResult Calc(int id)
        {
            DataGasFuelModel? dataInput = _context.DataGasFuelModels.FirstOrDefault(x => x.Id == id);
            if (dataInput == null) return NotFound();
            DataOutputModel rezult = new DataOutputModel(dataInput);

            return Ok(rezult);
        }

        [HttpGet(nameof(Report))]
        public IActionResult Report(int id)
        {
            DataGasFuelModel? dataInput = _context.DataGasFuelModels.Find(id);
            if (dataInput == null) return NotFound();
            DataOutputModel rezult = new DataOutputModel(dataInput);

            return Ok(new
            {
                dataInput,
                rezult
                
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet(nameof(Error))]
        public IActionResult Error()
        {
            return BadRequest(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}