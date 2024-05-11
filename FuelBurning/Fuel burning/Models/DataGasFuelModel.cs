using Microsoft.EntityFrameworkCore;
using static ApplicationContext;

namespace Fuel_burning.Models
{
   [EntityTypeConfiguration(typeof(DataGasFuelModelConfiguration))]
    public class DataGasFuelModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TypeCalculation { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public GasFuelModel GasFuelModel { get; set; } = new GasFuelModel();
        public static DataGasFuelModel GetDefaultModel()
        {
            var _cs = new DataGasFuelModel();

            _cs.Name = "Шаблонный вариант";
            _cs.Description = "Пример";
            _cs.TypeCalculation = "GasFuelBurning";
            _cs.GasFuelModel.CO2 = 0.3;
            _cs.GasFuelModel.CO = 0.0;
            _cs.GasFuelModel.H2 = 0.0;
            _cs.GasFuelModel.CH4 = 88.0;
            _cs.GasFuelModel.C2H6 = 1.9;
            _cs.GasFuelModel.C3H8 = 0.2;
            _cs.GasFuelModel.C4H10 = 0.3;
            _cs.GasFuelModel.C5H12 = 0.0;
            _cs.GasFuelModel.H2S = 0.0;
            _cs.GasFuelModel.N2 = 9.3;
            _cs.GasFuelModel.G = 5.0;
            _cs.GasFuelModel.Tг = 200.0;
            _cs.GasFuelModel.Tв = 200.0;
            _cs.GasFuelModel.Alfa = 1.1;

            _cs.Id = 3;
            _cs.IsActive = true;

            return _cs;
        }
    }
}
