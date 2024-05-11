using Microsoft.EntityFrameworkCore;
using static Domain.Contexts.ApplicationContext;

namespace Domain.Models.DB
{
   [EntityTypeConfiguration(typeof(DataJsonGasFuelModelConfiguration))]
    public class DataJsonGasFuelModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public DataGasFuelModel GasFuelModel { get; set; } = new DataGasFuelModel();
        public static DataJsonGasFuelModel GetDefaultModel()
        {
            var _cs = new DataJsonGasFuelModel();

            _cs.GasFuelModel.Name = "Шаблонный вариант";
            _cs.GasFuelModel.Description = "Пример";
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
