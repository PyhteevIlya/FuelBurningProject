using MathLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Fuel_burning.Models
{
    public class FuelViewModel
    {
        public IEnumerable<DataGasFuelModel> DataJsonGasFuelModel { get; set; }

        public IEnumerable<DataLiquidFuelModel> DataJsonLiquidFuelModel { get; set; }

    }
}