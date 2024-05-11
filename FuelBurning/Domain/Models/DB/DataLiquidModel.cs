using MathLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Domain.Models.DB
{
    public class DataLiquidModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Масса CO2,%
        /// </summary> 
        public double C { get; set; }
      
        /// <summary>
        /// Масса CO,%
        /// </summary> 
        public double H { get; set; }

        /// <summary>
        /// Масса H2,%
        /// </summary> 
        public double S { get; set; }

        /// <summary>
        /// Масса CH4,%
        /// </summary> 
        public double N { get; set; }

        /// <summary>
        /// Масса C2H6,%
        /// </summary> 
        public double O { get; set; }

        /// <summary>
        /// Масса C3H8,%
        /// </summary> 
        public double Wp { get; set; }

        /// <summary>
        /// Масса C4H10,%
        /// </summary>
        public double Ap { get; set; }

        /// <summary>
        /// Масса C5H12,%
        /// </summary>
        public double T_v { get; set; }

        /// <summary>
        /// Масса H2S,%
        /// </summary> 
        public double T_t { get; set; }

        /// <summary>
        /// Масса N2,%
        /// </summary>
        public double alfaG { get; set; }

        /// <summary>
        /// Масса H2O,%
        /// </summary> 
        public double M_недожог { get; set; }

        /// <summary>
        /// Масса g,%
        /// </summary> 
        public double gg { get; set; }
    }
}