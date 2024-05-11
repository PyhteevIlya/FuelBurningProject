using MathLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Domain.Models.DB
{
    public class FuelViewModel
    {
        public IEnumerable<DataJsonGasFuelModel> DataJsonGasFuelModel { get; set; }

        public IEnumerable<DataJsonLiquidFuelModel> DataJsonLiquidFuelModel { get; set; }

    }
}