using Fuel_burning.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FuelBurningApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class LiquidController2 : ControllerBase
    {
        private readonly ILogger<LiquidController2> _logger;
        private readonly ApplicationContext _context;
        public LiquidController2(ILogger<LiquidController2> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet(nameof(DataInputAdd))]
        public IActionResult DataInputAdd()
        {
            DataLiquidFuelModel _cs = DataLiquidFuelModel.GetDefaultModel();


            return Ok(_cs);
        }

        [HttpPost(nameof(DataInputAdd))]

        public IActionResult DataInputAdd(DataLiquidFuelModel dataInputsLiquid)
        {

            if (dataInputsLiquid == null) return BadRequest();
            //dataInputsLiquid.TypeCalculation = "GasFuelBurning";

            UserModel? user = _context.Users.FirstOrDefault(x => x.Login == User.Identity.Name);
            if (user == null) return BadRequest();
            dataInputsLiquid.UserId = user.Id;



            _context.DataLiquidFuelModels.Add(dataInputsLiquid);
            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete(nameof(Remove))]
        public IActionResult Remove(int id)
        {
            DataLiquidFuelModel? DataInputsLiquid = _context.DataLiquidFuelModels.Find(id);
            if (DataInputsLiquid == null) return NotFound();
            _context.DataLiquidFuelModels.Remove(DataInputsLiquid);
            _context.SaveChanges();
            return Ok();

        }

        [HttpGet(nameof(DataInputEdit))]

        public IActionResult DataInputEdit(int id)
        {
            DataLiquidFuelModel? DataInputsLiquid = _context.DataLiquidFuelModels.FirstOrDefault(x => x.Id == id);
            if (DataInputsLiquid == null) return NotFound();
            return Ok(DataInputsLiquid);
        }

        [HttpPost(nameof(DataInputEdit))]

        public IActionResult DataInputEdit(DataLiquidFuelModel DataInputsLiquid)
        {
            if (DataInputsLiquid == null) return BadRequest();

            var existData = _context.DataLiquidFuelModels.AsNoTracking().FirstOrDefault(x => x.Id == DataInputsLiquid.Id);

            if (existData == null) return BadRequest();

            if (existData.Name != DataInputsLiquid.Name)
            {
                DataInputsLiquid.Id = 0;
                _context.DataLiquidFuelModels.Add(DataInputsLiquid);
            }
            else
            {
                _context.DataLiquidFuelModels.Update(DataInputsLiquid);
            }
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet(nameof(Calc))]
        public IActionResult Calc(int id)
        {
            DataLiquidFuelModel? DataInputsLiquid = _context.DataLiquidFuelModels.Find(id);
            if (DataInputsLiquid == null) return NotFound();
            LiquidDataOutputModel rezult = new LiquidDataOutputModel(DataInputsLiquid);



            //#region --- Лист для круговой диаграммы

            //var lists = new List<double>()
            //{

            //   _rezult.Temp_alfa_g,
            //   _rezult.Temp_alfa2_g,
            //   _rezult.Tbalance_alfa_g,
            //   _rezult.Tbalance_alfa2_g,

            //};

            //#endregion --- Лист для круговой диаграммы

            return Ok(rezult);
        }

        [HttpGet(nameof(Report))]
        public IActionResult Report(int id)
        {
            DataLiquidFuelModel? DataInputsLiquid = _context.DataLiquidFuelModels.Find(id);
            if (DataInputsLiquid == null) return NotFound();
            LiquidDataOutputModel rezult = new LiquidDataOutputModel(DataInputsLiquid);



            //#region --- Лист для круговой диаграммы

            //var lists = new List<double>()
            //{

            //   _rezult.Temp_alfa_g,
            //   _rezult.Temp_alfa2_g,
            //   _rezult.Tbalance_alfa_g,
            //   _rezult.Tbalance_alfa2_g,

            //};


            //#endregion --- Лист для круговой диаграммы
            var dataInput = DataInputsLiquid;

            return Ok(new
            {
                dataInput,
                rezult,
            }) ;
        }


        [HttpGet(nameof(Raschet))]
        public IActionResult Raschet()
        {
            UserModel? user = _context.Users.FirstOrDefault(x => x.Login == User.Identity.Name);
            return Ok(_context.DataLiquidFuelModels.Where(x => x.UserId == user.Id || x.UserId == 0).ToList());

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        [HttpGet(nameof(Error))]
        public IActionResult Error()
        {
            return BadRequest(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}