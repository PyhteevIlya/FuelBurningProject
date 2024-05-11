using MathLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Fuel_burning.Models
{
    public class GasFuelModel
    {
        /// <summary>
        /// Масса CO2,%
        /// </summary> 
        public double CO2 { get; set; }
      
        /// <summary>
        /// Масса CO,%
        /// </summary> 
        public double CO { get; set; }

        /// <summary>
        /// Масса H2,%
        /// </summary> 
        public double H2 { get; set; }

        /// <summary>
        /// Масса CH4,%
        /// </summary> 
        public double CH4 { get; set; }

        /// <summary>
        /// Масса C2H6,%
        /// </summary> 
        public double C2H6 { get; set; }

        /// <summary>
        /// Масса C3H8,%
        /// </summary> 
        public double C3H8 { get; set; }

        /// <summary>
        /// Масса C4H10,%
        /// </summary>
        public double C4H10 { get; set; }

        /// <summary>
        /// Масса C5H12,%
        /// </summary>
        public double C5H12 { get; set; }

        /// <summary>
        /// Масса H2S,%
        /// </summary> 
        public double H2S { get; set; }

        /// <summary>
        /// Масса N2,%
        /// </summary>
        public double N2 { get; set; }

        /// <summary>
        /// Масса H2O,%
        /// </summary> 
        public double H2O { get; set; }

        /// <summary>
        /// Масса g,%
        /// </summary> 
        public double G { get; set; }


        /// <summary>
        /// Масса t_г, С
        /// </summary>  
        public double Tг { get; set; }

        /// <summary>
        /// Масса t_в, С
        /// </summary> 
        public double Tв { get; set; }

        /// <summary>
        /// Масса коэф.расхода воздуха на горение
        /// </summary> 
        public double Alfa { get; set; }

    }
}