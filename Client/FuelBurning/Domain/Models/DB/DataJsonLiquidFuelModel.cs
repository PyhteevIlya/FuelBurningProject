using Microsoft.EntityFrameworkCore;
using static Domain.Contexts.ApplicationContext;

namespace Domain.Models.DB
{
    [EntityTypeConfiguration(typeof(DataJsonLiquidFuelModelConfiguration))]
    public class DataJsonLiquidFuelModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public DataLiquidModel LiquidFuelModel { get; set; } = new DataLiquidModel();
        public static DataJsonLiquidFuelModel GetDefaultModel()
        {
            var _cs = new DataJsonLiquidFuelModel();

            _cs.LiquidFuelModel.Name = "Шаблонный вариант";
            _cs.LiquidFuelModel.Description = "Пример";
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
