using Microsoft.EntityFrameworkCore;
using static ApplicationContext;

namespace Fuel_burning.Models
{
    [EntityTypeConfiguration(typeof(DataLiquidFuelModelConfiguration))]
    public class DataLiquidFuelModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TypeCalculation { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public LiquidFuelModel LiquidFuelModel { get; set; } = new LiquidFuelModel();
        public static DataLiquidFuelModel GetDefaultModel()
        {
            var _cs = new DataLiquidFuelModel();

            _cs.Name = "Шаблонный вариант";
            _cs.Description = "Пример";
            _cs.TypeCalculation = "LiquidFuelBurning";
            _cs.LiquidFuelModel.C = 85.1;
            _cs.LiquidFuelModel.H = 9.90;
            _cs.LiquidFuelModel.S = 0.0;
            _cs.LiquidFuelModel.N = 0.5;
            _cs.LiquidFuelModel.O = 0.2;
            _cs.LiquidFuelModel.Wp = 3.9;
            _cs.LiquidFuelModel.Ap = 0.1;
            _cs.LiquidFuelModel.T_v = 280.0;
            _cs.LiquidFuelModel.T_t = 98.0;
            _cs.LiquidFuelModel.alfaG = 1.25;
            _cs.LiquidFuelModel.M_недожог = 4.0;
            _cs.LiquidFuelModel.gg = 13.0;

            _cs.Id = 4;
            _cs.IsActive = true;

            return _cs; ;
        }
    }
}
