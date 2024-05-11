//using AspNetCore;
using Fuel_burning.Models;
using MathLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Fuel_burning.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult DataInputAdd()
        {
            DataGasFuelModel _cs = DataGasFuelModel.GetDefaultModel();

            ViewBag.DataInput = _cs;

            return View(/*"DataInput"*/);
        }

        [HttpPost]

        public IActionResult DataInputAdd(DataGasFuelModel DataInput)
        {
            //DataOutputModel _rezult = new DataOutputModel(DataInput);

            if (DataInput == null) return BadRequest();
            UserModel user = _context.Users.FirstOrDefault(x => x.Login == User.Identity.Name);
            if (user == null) return BadRequest();
            DataInput.UserId = user.Id;

            _context.DataGasFuelModels.Add(DataInput);
            _context.SaveChanges();
            return RedirectToAction("Raschet");

        }

        [HttpGet]
        public IActionResult Raschet()
        {
            UserModel user = _context.Users.FirstOrDefault(x => x.Login == User.Identity.Name);
            return View(_context.DataGasFuelModels.Where(x => x.UserId == user.Id || x.UserId == 0));

        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            DataGasFuelModel dataInput = _context.DataGasFuelModels.Find(id);
            if (dataInput == null) return NotFound();
            _context.DataGasFuelModels.Remove(dataInput);
            _context.SaveChanges();
            return RedirectToAction("Raschet");

        }

        [HttpGet]

        public IActionResult DataInputEdit(int id)
        {
            DataGasFuelModel dataInput = _context.DataGasFuelModels.Find(id);
            if (dataInput == null) return NotFound();
            return View(dataInput);
        }

        [HttpPost]
        public IActionResult DataInputEdit(DataGasFuelModel DataInput)
        {
            if (DataInput == null) return RedirectToAction(nameof(Index));

            var existData = _context.DataGasFuelModels.AsNoTracking().FirstOrDefault(x => x.Id == DataInput.Id);

            if (existData == null) return RedirectToAction(nameof(Index));

            if (existData.Name != DataInput.Name)
            {
                DataInput.Id = 0;
                _context.DataGasFuelModels.Add(DataInput);
            }
            else
            {
                _context.DataGasFuelModels.Update(DataInput);
            }
            _context.SaveChanges();

            return RedirectToAction("Raschet");
        }

        [HttpGet]
        public IActionResult Calc(int id)
        {
            DataGasFuelModel dataInput = _context.DataGasFuelModels.FirstOrDefault(x => x.Id == id);
            if (dataInput == null) return NotFound();
            DataOutputModel _rezult = new DataOutputModel(dataInput);

            #region --- Вернуть на въюшку промежуточные результаты расчетов

            _rezult.Temp_alfaCoreect();
            _rezult.Temp_alfaCoreect2();
            _rezult.Tbalance_alfaCoreect();
            _rezult.Tbalance_alfaCoreect2();

            ViewBag.Rh2o = _rezult.Rh2o;
            ViewBag.Rco2 = _rezult.Rco2;
            ViewBag.Rco = _rezult.Rco;
            ViewBag.Rh2 = _rezult.Rh2;
            ViewBag.Rch4 = _rezult.Rch4;
            ViewBag.Rc2h6 = _rezult.Rc2h6;
            ViewBag.Rc3h8 = _rezult.Rc3h8;
            ViewBag.Rc4h10 = _rezult.Rc4h10;
            ViewBag.Rc5h12 = _rezult.Rc5h12;
            ViewBag.Rh2s = _rezult.Rh2s;
            ViewBag.RN2 = _rezult.RN2;
            ViewBag.Sumishdanrab = _rezult.Sumishdanrab;

            ViewBag.Lo = _rezult.Lo;
            ViewBag.Lalfa = _rezult.Lalfa;

            ViewBag.Vo_CO2 = _rezult.Vo_CO2;
            ViewBag.Vo_SO2 = _rezult.Vo_SO2;
            ViewBag.Vo_H2O = _rezult.Vo_H2O;
            ViewBag.Vo_N2 = _rezult.Vo_N2;
            ViewBag.Vo_CO = _rezult.Vo_CO;
            ViewBag.Vo_H2 = _rezult.Vo_H2;
            ViewBag.Vo_O2 = _rezult.Vo_O2;
            ViewBag.Vo = _rezult.Vo;
            ViewBag.V_alfa_N2 = _rezult.V_alfa_N2;
            ViewBag.V_O2_izb = _rezult.V_O2_izb;
            ViewBag.V_alfa = _rezult.V_alfa;

            ViewBag.CO2alfa = _rezult.CO2alfa;
            ViewBag.CO2alfa2 = _rezult.CO2alfa2;
            ViewBag.SO2alfa = _rezult.SO2alfa;
            ViewBag.SO2alfa2 = _rezult.SO2alfa2;
            ViewBag.H2Oalfa = _rezult.H2Oalfa;
            ViewBag.H2Oalfa2 = _rezult.H2Oalfa2;
            ViewBag.N2alfa = _rezult.N2alfa;
            ViewBag.N2alfa2 = _rezult.N2alfa2;
            ViewBag.COalfa = _rezult.COalfa;
            ViewBag.COalfa2 = _rezult.COalfa2;
            ViewBag.H2alfa = _rezult.H2alfa;
            ViewBag.H2alfa2 = _rezult.H2alfa2;
            ViewBag.O2alfa = _rezult.O2alfa;
            ViewBag.O2alfa2 = _rezult.O2alfa2;
            ViewBag.Sumalfa = _rezult.Sumalfa;
            ViewBag.Sumalfa2 = _rezult.Sumalfa2;

            ViewBag.Qнр = _rezult.Qнр;
            ViewBag.Cтопл = _rezult.Cтопл;
            ViewBag.Cвозд = _rezult.Cвозд;
            ViewBag.ВоздВПГ = _rezult.ВоздВПГ;

            ViewBag.i_химalfa = _rezult.i_химalfa;
            ViewBag.i_химalfa2 = _rezult.i_химalfa2;
            ViewBag.i_топлalfa = _rezult.i_топлalfa;
            ViewBag.i_топлalfa2 = _rezult.i_топлalfa2;
            ViewBag.i_воздalfa = _rezult.i_воздalfa;
            ViewBag.i_воздalfa2 = _rezult.i_воздalfa2;
            ViewBag.i_общ_т_alfa = _rezult.i_общ_т_alfa;
            ViewBag.i_общ_т_alfa2 = _rezult.i_общ_т_alfa2;
            ViewBag.i_з_alfa = _rezult.i_з_alfa;
            ViewBag.i_з_alfa2 = _rezult.i_з_alfa2;
            ViewBag.i_общ_б_alfa = _rezult.i_общ_б_alfa;
            ViewBag.i_общ_б_alfa2 = _rezult.i_общ_б_alfa2;

            ViewBag.Temp_alfa = _rezult.Temp_alfa;
            ViewBag.Temp_alfa2 = _rezult.Temp_alfa2;
            ViewBag.Cel_alfa = _rezult.Cel_alfa;
            ViewBag.Cel_alfa2 = _rezult.Cel_alfa2;
            ViewBag.Tbalance_alfa = _rezult.Tbalance_alfa;
            ViewBag.Tbalance_alfa2 = _rezult.Tbalance_alfa2;
            ViewBag.Cel_balance_alfa = _rezult.Cel_balance_alfa;
            ViewBag.Cel_balance_alfa2 = _rezult.Cel_balance_alfa2;

            #endregion --- Вернуть на въюшку промежуточные результаты расчетов



            #region --- Лист для круговой диаграммы

            var lists = new List<double>()
            {

               _rezult.Temp_alfa,
               _rezult.Temp_alfa2,
               _rezult.Tbalance_alfa,
               _rezult.Tbalance_alfa2,

            };
            ViewBag.lists = Newtonsoft.Json.JsonConvert.SerializeObject(lists);

            #endregion --- Лист для круговой диаграммы

            ViewBag.inputId = dataInput.Id;

            return View("Rezult");
        }

        [HttpGet]
        public IActionResult Report(int id)
        {
            DataGasFuelModel dataInput = _context.DataGasFuelModels.Find(id);
            if (dataInput == null) return NotFound();
            DataOutputModel _rezult = new DataOutputModel(dataInput);

            #region Исходные данные

            ViewBag.CO2 = dataInput.GasFuelModel.CO2;
            ViewBag.CO = dataInput.GasFuelModel.CO;
            ViewBag.H2 = dataInput.GasFuelModel.H2;
            ViewBag.CH4 = dataInput.GasFuelModel.CH4;
            ViewBag.C2H6 = dataInput.GasFuelModel.C2H6;
            ViewBag.C3H8 = dataInput.GasFuelModel.C3H8;
            ViewBag.C4H10 = dataInput.GasFuelModel.C4H10;
            ViewBag.C5H12 = dataInput.GasFuelModel.C5H12;
            ViewBag.H2S = dataInput.GasFuelModel.H2S;
            ViewBag.N2 = dataInput.GasFuelModel.N2;
            ViewBag.G = dataInput.GasFuelModel.G;
            ViewBag.Tг = dataInput.GasFuelModel.Tг;
            ViewBag.Tв = dataInput.GasFuelModel.Tв;
            ViewBag.Alfa = dataInput.GasFuelModel.Alfa;

            #endregion 

            #region --- Вернуть на въюшку промежуточные результаты расчетов

            _rezult.Temp_alfaCoreect();
            _rezult.Temp_alfaCoreect2();
            _rezult.Tbalance_alfaCoreect();
            _rezult.Tbalance_alfaCoreect2();

            ViewBag.Rh2o = _rezult.Rh2o;
            ViewBag.Rco2 = _rezult.Rco2;
            ViewBag.Rco = _rezult.Rco;
            ViewBag.Rh2 = _rezult.Rh2;
            ViewBag.Rch4 = _rezult.Rch4;
            ViewBag.Rc2h6 = _rezult.Rc2h6;
            ViewBag.Rc3h8 = _rezult.Rc3h8;
            ViewBag.Rc4h10 = _rezult.Rc4h10;
            ViewBag.Rc5h12 = _rezult.Rc5h12;
            ViewBag.Rh2s = _rezult.Rh2s;
            ViewBag.RN2 = _rezult.RN2;
            ViewBag.Sumishdanrab = _rezult.Sumishdanrab;

            ViewBag.Lo = _rezult.Lo;
            ViewBag.Lalfa = _rezult.Lalfa;

            ViewBag.Vo_CO2 = _rezult.Vo_CO2;
            ViewBag.Vo_SO2 = _rezult.Vo_SO2;
            ViewBag.Vo_H2O = _rezult.Vo_H2O;
            ViewBag.Vo_N2 = _rezult.Vo_N2;
            ViewBag.Vo_CO = _rezult.Vo_CO;
            ViewBag.Vo_H2 = _rezult.Vo_H2;
            ViewBag.Vo_O2 = _rezult.Vo_O2;
            ViewBag.Vo = _rezult.Vo;
            ViewBag.V_alfa_N2 = _rezult.V_alfa_N2;
            ViewBag.V_O2_izb = _rezult.V_O2_izb;
            ViewBag.V_alfa = _rezult.V_alfa;

            ViewBag.CO2alfa = _rezult.CO2alfa;
            ViewBag.CO2alfa2 = _rezult.CO2alfa2;
            ViewBag.SO2alfa = _rezult.SO2alfa;
            ViewBag.SO2alfa2 = _rezult.SO2alfa2;
            ViewBag.H2Oalfa = _rezult.H2Oalfa;
            ViewBag.H2Oalfa2 = _rezult.H2Oalfa2;
            ViewBag.N2alfa = _rezult.N2alfa;
            ViewBag.N2alfa2 = _rezult.N2alfa2;
            ViewBag.COalfa = _rezult.COalfa;
            ViewBag.COalfa2 = _rezult.COalfa2;
            ViewBag.H2alfa = _rezult.H2alfa;
            ViewBag.H2alfa2 = _rezult.H2alfa2;
            ViewBag.O2alfa = _rezult.O2alfa;
            ViewBag.O2alfa2 = _rezult.O2alfa2;
            ViewBag.Sumalfa = _rezult.Sumalfa;
            ViewBag.Sumalfa2 = _rezult.Sumalfa2;

            ViewBag.Qнр = _rezult.Qнр;
            ViewBag.Cтопл = _rezult.Cтопл;
            ViewBag.Cвозд = _rezult.Cвозд;
            ViewBag.ВоздВПГ = _rezult.ВоздВПГ;

            ViewBag.i_химalfa = _rezult.i_химalfa;
            ViewBag.i_химalfa2 = _rezult.i_химalfa2;
            ViewBag.i_топлalfa = _rezult.i_топлalfa;
            ViewBag.i_топлalfa2 = _rezult.i_топлalfa2;
            ViewBag.i_воздalfa = _rezult.i_воздalfa;
            ViewBag.i_воздalfa2 = _rezult.i_воздalfa2;
            ViewBag.i_общ_т_alfa = _rezult.i_общ_т_alfa;
            ViewBag.i_общ_т_alfa2 = _rezult.i_общ_т_alfa2;
            ViewBag.i_з_alfa = _rezult.i_з_alfa;
            ViewBag.i_з_alfa2 = _rezult.i_з_alfa2;
            ViewBag.i_общ_б_alfa = _rezult.i_общ_б_alfa;
            ViewBag.i_общ_б_alfa2 = _rezult.i_общ_б_alfa2;

            ViewBag.Temp_alfa = _rezult.Temp_alfa;
            ViewBag.Temp_alfa2 = _rezult.Temp_alfa2;
            ViewBag.Cel_alfa = _rezult.Cel_alfa;
            ViewBag.Cel_alfa2 = _rezult.Cel_alfa2;
            ViewBag.Tbalance_alfa = _rezult.Tbalance_alfa;
            ViewBag.Tbalance_alfa2 = _rezult.Tbalance_alfa2;
            ViewBag.Cel_balance_alfa = _rezult.Cel_balance_alfa;
            ViewBag.Cel_balance_alfa2 = _rezult.Cel_balance_alfa2;

            #endregion --- Вернуть на въюшку промежуточные результаты расчетов

            #region --- Лист для круговой диаграммы

            var lists = new List<double>()
            {

               _rezult.Temp_alfa,
               _rezult.Temp_alfa2,
               _rezult.Tbalance_alfa,
               _rezult.Tbalance_alfa2,

            };
            ViewBag.lists = Newtonsoft.Json.JsonConvert.SerializeObject(lists);

            #endregion --- Лист для круговой диаграммы


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Choice()
        {
            var vm = new FuelViewModel()
            {

                DataJsonLiquidFuelModel = new List<DataLiquidFuelModel>(),
                DataJsonGasFuelModel = new List<DataGasFuelModel>()
            };
            return View(vm);
        }

    }
}