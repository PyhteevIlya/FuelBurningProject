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
    public class LiquidController : Controller
    {
        private readonly ILogger<LiquidController> _logger;
        private readonly ApplicationContext _context;
        public LiquidController(ILogger<LiquidController> logger, ApplicationContext context)
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
            DataLiquidFuelModel _cs = DataLiquidFuelModel.GetDefaultModel();

            ViewBag.DataInputsLiquid = _cs;

            return View(/*"DataInput"*/);
        }

        [HttpPost]

        public IActionResult DataInputAdd(DataLiquidFuelModel DataInputsLiquid)
        {
            if (DataInputsLiquid == null) return BadRequest();
            UserModel user = _context.Users.FirstOrDefault(x => x.Login == User.Identity.Name);
            if (user == null) return BadRequest();
            DataInputsLiquid.UserId = user.Id;

            _context.DataLiquidFuelModels.Add(DataInputsLiquid);
            _context.SaveChanges();
            return RedirectToAction("Raschet");

        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            DataLiquidFuelModel DataInputsLiquid = _context.DataLiquidFuelModels.Find(id);
            if (DataInputsLiquid == null) return NotFound();
            _context.DataLiquidFuelModels.Remove(DataInputsLiquid);
            _context.SaveChanges();
            return RedirectToAction("Raschet");

        }

        [HttpGet]

        public IActionResult DataInputEdit(int id)
        {
            DataLiquidFuelModel DataInputsLiquid = _context.DataLiquidFuelModels.Find(id);
            if (DataInputsLiquid == null) return NotFound();
            return View(DataInputsLiquid);
        }

        [HttpPost]
        public IActionResult DataInputEdit(DataLiquidFuelModel DataInputsLiquid)
        {
            if (DataInputsLiquid == null) return RedirectToAction(nameof(Index));

            var existData = _context.DataLiquidFuelModels.AsNoTracking().FirstOrDefault(x => x.Id == DataInputsLiquid.Id);

            if (existData == null) return RedirectToAction(nameof(Index));

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

            return RedirectToAction("Raschet");
        }

        [HttpGet]
        public IActionResult Calc(int id)
        {
            DataLiquidFuelModel DataInputsLiquid = _context.DataLiquidFuelModels.FirstOrDefault(x => x.Id == id);
            if (DataInputsLiquid == null) return NotFound();
            LiquidDataOutputModel _rezult = new LiquidDataOutputModel(DataInputsLiquid);

            #region --- Вернуть на въюшку промежуточные результаты расчетов

            _rezult.Temp_alfaCoreect();
            _rezult.Temp_alfaCoreect2();
            _rezult.Tbalance_alfaCoreect();
            _rezult.Tbalance_alfaCoreect2();

            ViewBag.Rc = _rezult.Rc;
            ViewBag.Rh = _rezult.Rh;
            ViewBag.Rs = _rezult.Rs;
            ViewBag.Rn = _rezult.Rn;
            ViewBag.Ro = _rezult.Ro;
            ViewBag.Rwp = _rezult.Rwp;
            ViewBag.Rap = _rezult.Rap;
            ViewBag.Rt_v = _rezult.Rt_v;
            ViewBag.Rt_t = _rezult.Rt_t;
            ViewBag.Ralfag = _rezult.Ralfag;
            ViewBag.M_недожог = _rezult.M_недожог;

            ViewBag.gg = _rezult.gg;
            //ViewBag.Lalfa = _rezult.Lalfa;

            ViewBag.V_O2 = _rezult.V_O2;
            ViewBag.Lo_св = _rezult.Lo_св;
            ViewBag.Lo_вв = _rezult.Lo_вв;
            ViewBag.L_alfa_вв = _rezult.L_alfa_вв;

            ViewBag.Vo_CO2_alfa1_g = _rezult.Vo_CO2_alfa1_g;
            ViewBag.Vo_SO2_alfa1_g = _rezult.Vo_SO2_alfa1_g;
            ViewBag.Vo_H2O_alfa1_g = _rezult.Vo_H2O_alfa1_g;
            ViewBag.Vo_N2_alfa1_g = _rezult.Vo_N2_alfa1_g;
            ViewBag.Vo_CO_alfa1_g = _rezult.Vo_CO_alfa1_g;
            ViewBag.Vo_H2_alfa1_g = _rezult.Vo_H2_alfa1_g;
            ViewBag.Vo_O2_alfa1_g = _rezult.Vo_O2_alfa1_g;
            ViewBag.Vo = _rezult.Vo;
            ViewBag.Vo_CO2_alfa2_g = _rezult.Vo_CO2_alfa2_g;
            ViewBag.Vo_SO2_alfa2_g = _rezult.Vo_SO2_alfa2_g;
            ViewBag.Vo_H2O_alfa2_g = _rezult.Vo_H2O_alfa2_g;
            ViewBag.Vo_N2_alfa2_g = _rezult.Vo_N2_alfa2_g;
            ViewBag.Vo_CO_alfa2_g = _rezult.Vo_CO_alfa2_g;
            ViewBag.Vo_H2_alfa2_g = _rezult.Vo_H2_alfa2_g;
            ViewBag.Vo_O2_alfa2_g = _rezult.Vo_O2_alfa2_g;
            ViewBag.V_O2_izd_alfa2_g = _rezult.V_O2_izd_alfa2_g;
            ViewBag.V_alfa_g = _rezult.V_alfa_g;

            ViewBag.CO2alfa = _rezult.CO2_alfa1_g;
            ViewBag.CO2alfa2 = _rezult.CO2_alfa2_g;
            ViewBag.SO2alfa = _rezult.SO2_alfa1_g;
            ViewBag.SO2alfa2 = _rezult.SO2_alfa2_g;
            ViewBag.H2Oalfa = _rezult.H2O_alfa1_g;
            ViewBag.H2Oalfa2 = _rezult.H2O_alfa2_g;
            ViewBag.N2alfa = _rezult.N2_alfa1_g;
            ViewBag.N2alfa2 = _rezult.N2_alfa2_g;
            ViewBag.COalfa = _rezult.CO_alfa1_g;
            ViewBag.COalfa2 = _rezult.CO_alfa2_g;
            ViewBag.H2alfa = _rezult.H2_alfa1_g;
            ViewBag.H2alfa2 = _rezult.H2_alfa2_g;
            ViewBag.O2alfa = _rezult.O2_alfa1_g;
            ViewBag.O2alfa2 = _rezult.O2_alfa2_g;
            ViewBag.Sumalfa = _rezult.Sum_alfa1_g;
            ViewBag.Sumalfa2 = _rezult.Sum_alfa2_g;

            ViewBag.Qнр = _rezult.Q_нр_g;
            ViewBag.Cтопл = _rezult.c_топл_g;
            ViewBag.Cвозд = _rezult.c_возд_g;
            ViewBag.ВоздВПГ = _rezult.PG_возд_g;

            ViewBag.i_химalfa = _rezult.iхим_alfa1_g;
            ViewBag.i_химalfa2 = _rezult.iхим_alfa2_g;
            ViewBag.i_топлalfa = _rezult.iтопл_alfa1_g;
            ViewBag.i_топлalfa2 = _rezult.iтопл_alfa2_g;
            ViewBag.i_воздalfa = _rezult.iвозд_alfa1_g;
            ViewBag.i_воздalfa2 = _rezult.iвозд_alfa2_g;
            ViewBag.i_общ_т_alfa = _rezult.iобщ_т_alfa1_g;
            ViewBag.i_общ_т_alfa2 = _rezult.iобщ_т_alfa2_g;
            ViewBag.i_з_alfa = _rezult.i_3_i_4_alfa1_g;
            ViewBag.i_з_alfa2 = _rezult.i_3_i_4_alfa2_g;
            ViewBag.i_общ_б_alfa = _rezult.i_общ_б_alfa_g;
            ViewBag.i_общ_б_alfa2 = _rezult.i_общ_б_alfa2_g;

            ViewBag.Temp_alfa = _rezult.Temp_alfa_g;
            ViewBag.Temp_alfa2 = _rezult.Temp_alfa2_g;
            ViewBag.Cel_alfa = _rezult.Cel_alfa_g;
            ViewBag.Cel_alfa2 = _rezult.Cel_alfa2_g;
            ViewBag.Tbalance_alfa = _rezult.Tbalance_alfa_g;
            ViewBag.Tbalance_alfa2 = _rezult.Tbalance_alfa2_g;
            ViewBag.Cel_balance_alfa = _rezult.Cel_balance_alfa_g;
            ViewBag.Cel_balance_alfa2 = _rezult.Cel_balance_alfa2_g;

            #endregion --- Вернуть на въюшку промежуточные результаты расчетов



            #region --- Лист для круговой диаграммы

            var lists = new List<double>()
            {

               _rezult.Temp_alfa_g,
               _rezult.Temp_alfa2_g,
               _rezult.Tbalance_alfa_g,
               _rezult.Tbalance_alfa2_g,

            };
            ViewBag.lists = Newtonsoft.Json.JsonConvert.SerializeObject(lists);

            #endregion --- Лист для круговой диаграммы

            ViewBag.inputId = DataInputsLiquid.Id;

            return View("Rezult");
        }

        [HttpGet]
        public IActionResult Report(int id)
        {
            DataLiquidFuelModel DataInputsLiquid = _context.DataLiquidFuelModels.Find(id);
            if (DataInputsLiquid == null) return NotFound();
            LiquidDataOutputModel _rezult = new LiquidDataOutputModel(DataInputsLiquid);

            #region Исходные данные

            ViewBag.C = DataInputsLiquid.LiquidFuelModel.C;
            ViewBag.H = DataInputsLiquid.LiquidFuelModel.H;
            ViewBag.S = DataInputsLiquid.LiquidFuelModel.S;
            ViewBag.N = DataInputsLiquid.LiquidFuelModel.N;
            ViewBag.O = DataInputsLiquid.LiquidFuelModel.O;
            ViewBag.Wp = DataInputsLiquid.LiquidFuelModel.Wp;
            ViewBag.Ap = DataInputsLiquid.LiquidFuelModel.Ap;
            ViewBag.T_v = DataInputsLiquid.LiquidFuelModel.T_v;
            ViewBag.T_t = DataInputsLiquid.LiquidFuelModel.T_t;
            ViewBag.alfaG = DataInputsLiquid.LiquidFuelModel.alfaG;
            ViewBag.M_недожог = DataInputsLiquid.LiquidFuelModel.M_недожог;
            ViewBag.gg = DataInputsLiquid.LiquidFuelModel.gg;

            #endregion 

            #region --- Вернуть на въюшку промежуточные результаты расчетов

            _rezult.Temp_alfaCoreect();
            _rezult.Temp_alfaCoreect2();
            _rezult.Tbalance_alfaCoreect();
            _rezult.Tbalance_alfaCoreect2();

            ViewBag.Rc = _rezult.Rc;
            ViewBag.Rh = _rezult.Rh;
            ViewBag.Rs = _rezult.Rs;
            ViewBag.Rn = _rezult.Rn;
            ViewBag.Ro = _rezult.Ro;
            ViewBag.Rwp = _rezult.Rwp;
            ViewBag.Rap = _rezult.Rap;
            ViewBag.Rt_v = _rezult.Rt_v;
            ViewBag.Rt_t = _rezult.Rt_t;
            ViewBag.Ralfag = _rezult.Ralfag;
            ViewBag.M_недожог = _rezult.M_недожог;

            ViewBag.gg = _rezult.gg;
            //ViewBag.Lalfa = _rezult.Lalfa;

            ViewBag.V_O2 = _rezult.V_O2;
            ViewBag.Lo_св = _rezult.Lo_св;
            ViewBag.Lo_вв = _rezult.Lo_вв;
            ViewBag.L_alfa_вв = _rezult.L_alfa_вв;

            ViewBag.Vo_CO2_alfa1_g = _rezult.Vo_CO2_alfa1_g;
            ViewBag.Vo_SO2_alfa1_g = _rezult.Vo_SO2_alfa1_g;
            ViewBag.Vo_H2O_alfa1_g = _rezult.Vo_H2O_alfa1_g;
            ViewBag.Vo_N2_alfa1_g = _rezult.Vo_N2_alfa1_g;
            ViewBag.Vo_CO_alfa1_g = _rezult.Vo_CO_alfa1_g;
            ViewBag.Vo_H2_alfa1_g = _rezult.Vo_H2_alfa1_g;
            ViewBag.Vo_O2_alfa1_g = _rezult.Vo_O2_alfa1_g;
            ViewBag.Vo = _rezult.Vo;
            ViewBag.Vo_CO2_alfa2_g = _rezult.Vo_CO2_alfa2_g;
            ViewBag.Vo_SO2_alfa2_g = _rezult.Vo_SO2_alfa2_g;
            ViewBag.Vo_H2O_alfa2_g = _rezult.Vo_H2O_alfa2_g;
            ViewBag.Vo_N2_alfa2_g = _rezult.Vo_N2_alfa2_g;
            ViewBag.Vo_CO_alfa2_g = _rezult.Vo_CO_alfa2_g;
            ViewBag.Vo_H2_alfa2_g = _rezult.Vo_H2_alfa2_g;
            ViewBag.Vo_O2_alfa2_g = _rezult.Vo_O2_alfa2_g;
            ViewBag.V_O2_izd_alfa2_g = _rezult.V_O2_izd_alfa2_g;
            ViewBag.V_alfa_g = _rezult.V_alfa_g;

            ViewBag.CO2alfa = _rezult.CO2_alfa1_g;
            ViewBag.CO2alfa2 = _rezult.CO2_alfa2_g;
            ViewBag.SO2alfa = _rezult.SO2_alfa1_g;
            ViewBag.SO2alfa2 = _rezult.SO2_alfa2_g;
            ViewBag.H2Oalfa = _rezult.H2O_alfa1_g;
            ViewBag.H2Oalfa2 = _rezult.H2O_alfa2_g;
            ViewBag.N2alfa = _rezult.N2_alfa1_g;
            ViewBag.N2alfa2 = _rezult.N2_alfa2_g;
            ViewBag.COalfa = _rezult.CO_alfa1_g;
            ViewBag.COalfa2 = _rezult.CO_alfa2_g;
            ViewBag.H2alfa = _rezult.H2_alfa1_g;
            ViewBag.H2alfa2 = _rezult.H2_alfa2_g;
            ViewBag.O2alfa = _rezult.O2_alfa1_g;
            ViewBag.O2alfa2 = _rezult.O2_alfa2_g;
            ViewBag.Sumalfa = _rezult.Sum_alfa1_g;
            ViewBag.Sumalfa2 = _rezult.Sum_alfa2_g;

            ViewBag.Qнр = _rezult.Q_нр_g;
            ViewBag.Cтопл = _rezult.c_топл_g;
            ViewBag.Cвозд = _rezult.c_возд_g;
            ViewBag.ВоздВПГ = _rezult.PG_возд_g;

            ViewBag.i_химalfa = _rezult.iхим_alfa1_g;
            ViewBag.i_химalfa2 = _rezult.iхим_alfa2_g;
            ViewBag.i_топлalfa = _rezult.iтопл_alfa1_g;
            ViewBag.i_топлalfa2 = _rezult.iтопл_alfa2_g;
            ViewBag.i_воздalfa = _rezult.iвозд_alfa1_g;
            ViewBag.i_воздalfa2 = _rezult.iвозд_alfa2_g;
            ViewBag.i_общ_т_alfa = _rezult.iобщ_т_alfa1_g;
            ViewBag.i_общ_т_alfa2 = _rezult.iобщ_т_alfa2_g;
            ViewBag.i_з_alfa = _rezult.i_3_i_4_alfa1_g;
            ViewBag.i_з_alfa2 = _rezult.i_3_i_4_alfa2_g;
            ViewBag.i_общ_б_alfa = _rezult.i_общ_б_alfa_g;
            ViewBag.i_общ_б_alfa2 = _rezult.i_общ_б_alfa2_g;

            ViewBag.Temp_alfa = _rezult.Temp_alfa_g;
            ViewBag.Temp_alfa2 = _rezult.Temp_alfa2_g;
            ViewBag.Cel_alfa = _rezult.Cel_alfa_g;
            ViewBag.Cel_alfa2 = _rezult.Cel_alfa2_g;
            ViewBag.Tbalance_alfa = _rezult.Tbalance_alfa_g;
            ViewBag.Tbalance_alfa2 = _rezult.Tbalance_alfa2_g;
            ViewBag.Cel_balance_alfa = _rezult.Cel_balance_alfa_g;
            ViewBag.Cel_balance_alfa2 = _rezult.Cel_balance_alfa2_g;

            #endregion --- Вернуть на въюшку промежуточные результаты расчетов

            #region --- Лист для круговой диаграммы

            var lists = new List<double>()
            {

               _rezult.Temp_alfa_g,
               _rezult.Temp_alfa2_g,
               _rezult.Tbalance_alfa_g,
               _rezult.Tbalance_alfa2_g,

            };
            ViewBag.lists = Newtonsoft.Json.JsonConvert.SerializeObject(lists);

            #endregion --- Лист для круговой диаграммы


            return View();
        }

        public IActionResult DataInputLiquid()
        {
            LiquidFuel _cs = new LiquidFuel();

            #region --- Задать исходные данные для первого найденного варианта

            _cs.C = 85.1;
            _cs.H = 9.90;
            _cs.S = 0.0;
            _cs.N = 0.5;
            _cs.O = 0.2;
            _cs.Wp = 3.9;
            _cs.Ap = 0.1;
            _cs.T_v = 280.0;
            _cs.T_t = 98.0;
            _cs.alfaG = 1.25;
            _cs.M_недожог = 4.0;
            _cs.gg = 13.0;


            #endregion --- Задать исходные данные для первого найденного варианта

            ViewBag.DataInputLiquid = _cs;

            return View("DataInputLiquid");
        }

        [HttpPost]

        public IActionResult DataInputLiquid(DataLiquidFuelModel DataInputsLiquid)
        {
            LiquidDataOutputModel _rezult = new LiquidDataOutputModel(DataInputsLiquid);

            _rezult.Temp_alfaCoreect();
            _rezult.Temp_alfaCoreect2();
            _rezult.Tbalance_alfaCoreect();
            _rezult.Tbalance_alfaCoreect2();

            ViewBag.Rc = _rezult.Rc;
            ViewBag.Rh = _rezult.Rh;
            ViewBag.Rs = _rezult.Rs;
            ViewBag.Rn = _rezult.Rn;
            ViewBag.Ro = _rezult.Ro;
            ViewBag.Rwp = _rezult.Rwp;
            ViewBag.Rap = _rezult.Rap;
            ViewBag.Rt_v = _rezult.Rt_v;
            ViewBag.Rt_t = _rezult.Rt_t;
            ViewBag.Ralfag = _rezult.Ralfag;
            ViewBag.M_недожог = _rezult.M_недожог;

            ViewBag.gg = _rezult.gg;
            //ViewBag.Lalfa = _rezult.Lalfa;

            ViewBag.V_O2 = _rezult.V_O2;
            ViewBag.Lo_св = _rezult.Lo_св;
            ViewBag.Lo_вв = _rezult.Lo_вв;
            ViewBag.L_alfa_вв = _rezult.L_alfa_вв;

            ViewBag.Vo_CO2_alfa1_g = _rezult.Vo_CO2_alfa1_g;
            ViewBag.Vo_SO2_alfa1_g = _rezult.Vo_SO2_alfa1_g;
            ViewBag.Vo_H2O_alfa1_g = _rezult.Vo_H2O_alfa1_g;
            ViewBag.Vo_N2_alfa1_g = _rezult.Vo_N2_alfa1_g;
            ViewBag.Vo_CO_alfa1_g = _rezult.Vo_CO_alfa1_g;
            ViewBag.Vo_H2_alfa1_g = _rezult.Vo_H2_alfa1_g;
            ViewBag.Vo_O2_alfa1_g = _rezult.Vo_O2_alfa1_g;
            ViewBag.Vo = _rezult.Vo;
            ViewBag.Vo_CO2_alfa2_g = _rezult.Vo_CO2_alfa2_g;
            ViewBag.Vo_SO2_alfa2_g = _rezult.Vo_SO2_alfa2_g;
            ViewBag.Vo_H2O_alfa2_g = _rezult.Vo_H2O_alfa2_g;
            ViewBag.Vo_N2_alfa2_g = _rezult.Vo_N2_alfa2_g;
            ViewBag.Vo_CO_alfa2_g = _rezult.Vo_CO_alfa2_g;
            ViewBag.Vo_H2_alfa2_g = _rezult.Vo_H2_alfa2_g;
            ViewBag.Vo_O2_alfa2_g = _rezult.Vo_O2_alfa2_g;
            ViewBag.V_O2_izd_alfa2_g = _rezult.V_O2_izd_alfa2_g;
            ViewBag.V_alfa_g = _rezult.V_alfa_g;

            ViewBag.CO2alfa = _rezult.CO2_alfa1_g;
            ViewBag.CO2alfa2 = _rezult.CO2_alfa2_g;
            ViewBag.SO2alfa = _rezult.SO2_alfa1_g;
            ViewBag.SO2alfa2 = _rezult.SO2_alfa2_g;
            ViewBag.H2Oalfa = _rezult.H2O_alfa1_g;
            ViewBag.H2Oalfa2 = _rezult.H2O_alfa2_g;
            ViewBag.N2alfa = _rezult.N2_alfa1_g;
            ViewBag.N2alfa2 = _rezult.N2_alfa2_g;
            ViewBag.COalfa = _rezult.CO_alfa1_g;
            ViewBag.COalfa2 = _rezult.CO_alfa2_g;
            ViewBag.H2alfa = _rezult.H2_alfa1_g;
            ViewBag.H2alfa2 = _rezult.H2_alfa2_g;
            ViewBag.O2alfa = _rezult.O2_alfa1_g;
            ViewBag.O2alfa2 = _rezult.O2_alfa2_g;
            ViewBag.Sumalfa = _rezult.Sum_alfa1_g;
            ViewBag.Sumalfa2 = _rezult.Sum_alfa2_g;

            ViewBag.Qнр = _rezult.Q_нр_g;
            ViewBag.Cтопл = _rezult.c_топл_g;
            ViewBag.Cвозд = _rezult.c_возд_g;
            ViewBag.ВоздВПГ = _rezult.PG_возд_g;

            ViewBag.i_химalfa = _rezult.iхим_alfa1_g;
            ViewBag.i_химalfa2 = _rezult.iхим_alfa2_g;
            ViewBag.i_топлalfa = _rezult.iтопл_alfa1_g;
            ViewBag.i_топлalfa2 = _rezult.iтопл_alfa2_g;
            ViewBag.i_воздalfa = _rezult.iвозд_alfa1_g;
            ViewBag.i_воздalfa2 = _rezult.iвозд_alfa2_g;
            ViewBag.i_общ_т_alfa = _rezult.iобщ_т_alfa1_g;
            ViewBag.i_общ_т_alfa2 = _rezult.iобщ_т_alfa2_g;
            ViewBag.i_з_alfa = _rezult.i_3_i_4_alfa1_g;
            ViewBag.i_з_alfa2 = _rezult.i_3_i_4_alfa2_g;
            ViewBag.i_общ_б_alfa = _rezult.i_общ_б_alfa_g;
            ViewBag.i_общ_б_alfa2 = _rezult.i_общ_б_alfa2_g;

            ViewBag.Temp_alfa = _rezult.Temp_alfa_g;
            ViewBag.Temp_alfa2 = _rezult.Temp_alfa2_g;
            ViewBag.Cel_alfa = _rezult.Cel_alfa_g;
            ViewBag.Cel_alfa2 = _rezult.Cel_alfa2_g;
            ViewBag.Tbalance_alfa = _rezult.Tbalance_alfa_g;
            ViewBag.Tbalance_alfa2 = _rezult.Tbalance_alfa2_g;
            ViewBag.Cel_balance_alfa = _rezult.Cel_balance_alfa_g;
            ViewBag.Cel_balance_alfa2 = _rezult.Cel_balance_alfa2_g;
            /*
            var lists = new List<double>()
            {
                _rezult.GetS_sum,
                _rezult.GetS_multiplication
            };

            ViewBag.lists = Newtonsoft.Json.JsonConvert.SerializeObject(lists);
            */
            return View("RezultLiquid", _rezult.cs);

        }

        [HttpGet]
        public IActionResult Raschet()
        {
            UserModel user = _context.Users.FirstOrDefault(x => x.Login == User.Identity.Name);
            return View(_context.DataLiquidFuelModels.Where(x => x.UserId == user.Id || x.UserId == 0));

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}