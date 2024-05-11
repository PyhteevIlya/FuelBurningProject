using MathLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fuel_burning.Models
{
    public class LiquidDataOutputModel
    {
        public LiquidFuel cs = new LiquidFuel();

        private DataLiquidFuelModel _dataInputLiquid = new DataLiquidFuelModel();

        public LiquidDataOutputModel() { }

        public LiquidDataOutputModel(DataLiquidFuelModel DataInputLiquid)
        {
            _dataInputLiquid = DataInputLiquid;

            #region --- Передать исходные данные в экземпляр библиотеки

            cs.C = _dataInputLiquid.LiquidFuelModel.C;
            cs.H = _dataInputLiquid.LiquidFuelModel.H;
            cs.S = _dataInputLiquid.LiquidFuelModel.S;
            cs.N = _dataInputLiquid.LiquidFuelModel.N;
            cs.O = _dataInputLiquid.LiquidFuelModel.O;
            cs.Wp = _dataInputLiquid.LiquidFuelModel.Wp;
            cs.Ap = _dataInputLiquid.LiquidFuelModel.Ap;
            cs.T_v = _dataInputLiquid.LiquidFuelModel.T_v;
            cs.T_t = _dataInputLiquid.LiquidFuelModel.T_t;
            cs.alfaG = _dataInputLiquid.LiquidFuelModel.alfaG;
            cs.M_недожог = _dataInputLiquid.LiquidFuelModel.M_недожог;
            cs.gg = _dataInputLiquid.LiquidFuelModel.gg;
            

            #endregion --- Передать исходные данные в экземпляр библиотеки
        }

        public void Temp_alfaCoreect()
        {
            cs.Temp_alfaCoreect_g();
        }
        public void Temp_alfaCoreect2()
        {
            cs.Temp_alfaCoreect2_g();
        }
        public void Tbalance_alfaCoreect()
        {
            cs.Tbalance_alfaCoreect1_g();
        }
        public void Tbalance_alfaCoreect2()
        {
            cs.Tbalance_alfaCoreect2_g();
        }

        #region --- Получить расчетные показатели



        /// <summary>
        /// Рабочая масса CO2, %
        /// </summary> 
        public double Rc
        {
            get { return cs.C; }
        }

        /// <summary>
        /// Рабочая масса CO2, %
        /// </summary> 
        public double Rh
        {
            get { return cs.H; }
        }

        /// <summary>
        /// Рабочая масса H2, %
        /// </summary> 
        public double Rs
        {
            get { return cs.S; }
        }

        /// <summary>
        /// Рабочая масса CH4, %
        /// </summary>  
        public double Rn
        {
            get { return cs.N; }
        }

        /// <summary>
        /// Рабочая масса C2H6, %
        /// </summary> 
        public double Ro
        {
            get { return cs.O; }
        }

        /// <summary>
        /// Рабочая масса C3H8, %
        /// </summary> 
        public double Rwp
        {
            get { return cs.Wp; }
        }

        /// <summary>
        /// Рабочая масса C4H10, %
        /// </summary> 
        public double Rap
        {
            get { return cs.Ap; }
        }

        /// <summary>
        /// Рабочая масса C5H12, %
        /// </summary> 
        public double Rt_v
        {
            get { return cs.T_v; }
        }

        /// <summary>
        /// Рабочая масса H2S, %
        /// </summary> 
        public double Rt_t
        {
            get { return cs.T_t; }
        }

        /// <summary>
        /// Рабочая масса N2, %
        /// </summary> 
        public double Ralfag
        {
            get { return cs.alfaG; }
        }

        /// <summary>
        /// Сумма исходных данных (рабочая) %
        /// </summary> 
        public double M_недожог
        {
            get { return cs.M_недожог; }
        }


        /// <summary>
        /// Теоретический расход окислителя на горение L0, М3/М3
        /// </summary> 
        public double gg
        {
            get { return cs.gg; }
        }

        /// <summary>
        /// Действительный расход окислителя на горение Lalfa, м3/м3
        /// </summary> 
        public double V_O2
        {
            get { return cs.V_O2_g; }
        }




        /// <summary>
        /// Количество CO2 в продуктах горения, м3/м3
        /// </summary> 
        public double Lo_св
        {
            get { return cs.Lo_св; }
        }

        /// <summary>
        /// Количество SO2 в продуктах горения, м3/м3
        /// </summary> 
        public double Lo_вв
        {
            get { return cs.Lo_вв; }
        }

        /// <summary>
        /// Количество H2O в продуктах горения, м3/м3
        /// </summary> 
        public double L_alfa_вв
        {
            get { return cs.L_alfa_вв; }
        }

        /// <summary>
        /// Количество N2 в продуктах горения, м3/м3
        /// </summary> 
        public double Vo_CO2_alfa1_g
        {
            get { return cs.Vo_CO2_alfa1_g; }
        }

        /// <summary>
        /// Количество CO в продуктах горения, м3/м3
        /// </summary>  
        public double Vo_CO2_alfa2_g
        {
            get { return cs.Vo_CO2_alfa2_g; }
        }

        /// <summary>
        /// Количество H2 в продуктах горения, м3/м3
        /// </summary> 
        public double Vo_SO2_alfa1_g
        {
            get { return cs.Vo_SO2_alfa1_g; }
        }

        /// <summary>
        /// Количество O2 в продуктах горения, м3/м3
        /// </summary> 
        public double Vo_SO2_alfa2_g
        {
            get { return cs.Vo_SO2_alfa2_g; }
        }

        /// <summary>
        /// Количество Vo в продуктах горения, м3/м3
        /// </summary> 
        public double Vo
        {
            get { return cs.Vo_alfa1_g; }
        }

        /// <summary>
        /// Практический выход N2 при избытке окислителя, м3/м3
        /// </summary> 
        public double Vo_H2O_alfa1_g
        {
            get { return cs.Vo_H2O_alfa1_g; }
        }

        /// <summary>
        /// Количество избыточного кислорода в продуктах горения, м3/м3
        /// </summary> 
        public double Vo_H2O_alfa2_g
        {
            get { return cs.Vo_H2O_alfa2_g; }
        }

        /// <summary>
        /// Действительное количество продуктов горения, м3/м3
        /// </summary> 
        public double Vo_N2_alfa1_g
        {
            get { return cs.Vo_N2_alfa1_g; }
        }



        /// <summary>
        /// Содежание CO2 в продуктах горения alfa = 1, %
        /// </summary> 
        public double Vo_N2_alfa2_g
        {
            get { return cs.Vo_N2_alfa2_g; }
        }

        /// <summary>
        /// Содежание CO2 в продуктах горения alfa > 1, %
        /// </summary> 
        public double Vo_CO_alfa1_g
        {
            get { return cs.Vo_CO_alfa1_g; }
        }

        /// <summary>
        /// Содержание SO2 в продуктах горения alfa = 1, %
        /// </summary> 
        public double Vo_CO_alfa2_g
        {
            get { return cs.Vo_CO_alfa2_g; }
        }

        /// <summary>
        /// Содержание SO2 в продуктах горения alfa > 1, %
        /// </summary> 
        public double Vo_H2_alfa1_g
        {
            get { return cs.Vo_H2_alfa1_g; }
        }

        /// <summary>
        /// Содержание H2O в продуктах горения alfa = 1, %
        /// </summary> 
        public double Vo_H2_alfa2_g
        {
            get { return cs.Vo_H2_alfa2_g; }
        }

        /// <summary>
        /// Содержание H2O в продуктах горения alfa > 1, %
        /// </summary> 
        public double Vo_O2_alfa1_g
        {
            get { return cs.Vo_O2_alfa1_g; }
        }

        /// <summary>
        /// Содержание N2 в продуктах горения alfa = 1, %
        /// </summary> 
        public double Vo_O2_alfa2_g
        {
            get { return cs.Vo_O2_alfa2_g; }
        }

        /// <summary>
        /// Содержание N2 в продуктах горения alfa > 1, %
        /// </summary> 
        public double V_O2_izd_alfa2_g
        {
            get { return cs.V_O2_izd_alfa2_g; }
        }

        /// <summary>
        /// Содержание CO в продуктах горения alfa = 1, %
        /// </summary> 
        public double V_alfa_g
        {
            get { return cs.V_alfa_g; }
        }

        /// <summary>
        /// Содержание CO в продуктах горения alfa > 1, %
        /// </summary> 
        public double CO2_alfa1_g
        {
            get { return cs.CO2_alfa1_g; }
        }

        /// <summary>
        /// Содержание H2 в продуктах горения alfa = 1, %
        /// </summary> 
        public double CO2_alfa2_g
        {
            get { return cs.CO2_alfa2_g; }
        }

        /// <summary>
        /// Содержание H2 в продуктах горения alfa > 1, %
        /// </summary> 
        public double SO2_alfa1_g
        {
            get { return cs.SO2_alfa1_g; }
        }

        /// <summary>
        /// Содержание O2 в продуктах горения alfa = 1, %
        /// </summary> 
        public double SO2_alfa2_g
        {
            get { return cs.SO2_alfa2_g; }
        }

        /// <summary>
        /// Содержание O2 в продуктах горения alfa > 1, %
        /// </summary> 
        public double H2O_alfa1_g
        {
            get { return cs.H2O_alfa1_g; }
        }

        /// <summary>
        /// Общая процентная сумма (100%) alfa = 1, %
        /// </summary> 
        public double H2O_alfa2_g
        {
            get { return cs.H2O_alfa2_g; }
        }

        /// <summary>
        /// Общая процентная сумма (100%) alfa > 1, %
        /// </summary> 
        public double N2_alfa1_g
        {
            get { return cs.N2_alfa1_g; }
        }



        /// <summary>
        /// Теплота сгорания топлива, кДж/(М^3)
        /// </summary> 
        public double Q_нр_g
        {
            get { return cs.Q_нр_g; }
        }

        /// <summary>
        /// Удельная теплоемкость газообразного топлива, кДж/(М^3 * Со)
        /// </summary> 
        public double N2_alfa2_g
        {
            get { return cs.N2_alfa2_g; }
        }

        /// <summary>
        /// Удельная теплоемкость воздуха, кДж/(М^3 * Со)
        /// </summary> 
        public double CO_alfa1_g
        {
            get { return cs.CO_alfa1_g; }
        }

        /// <summary>
        /// Воздух в ПГ, %
        /// </summary> 
        public double CO_alfa2_g
        {
            get { return cs.CO_alfa2_g; }
        }



        /// <summary>
        /// Химическая энтальпия топлива при alfa = 1, кДж/м^3
        /// </summary> 
        public double H2_alfa1_g
        {
            get { return cs.H2_alfa1_g; }
        }

        /// <summary>
        /// Химическая энтальпия топлива при alfa > 1, кДж/м^3
        /// </summary> 
        public double H2_alfa2_g
        {
            get { return cs.H2_alfa2_g; }
        }

        /// <summary>
        /// Физическая энтальпия подогрева топлива при alfa = 1, кДж/м^3
        /// </summary> 
        public double O2_alfa1_g
        {
            get { return cs.O2_alfa1_g; }
        }

        /// <summary>
        /// Физическая энтальпия подогрева топлива при alfa > 1, кДж/м^3
        /// </summary> 
        public double O2_alfa2_g
        {
            get { return cs.O2_alfa2_g; }
        }

        /// <summary>
        /// Физическая энтальпия подогрева воздуха  alfa = 1, кДж/м^3
        /// </summary> 
        public double Sum_alfa1_g
        {
            get { return cs.Sum_alfa1_g; }
        }

        /// <summary>
        /// Физическая энтальпия подогрева воздуха при alfa > 1, кДж/м^3
        /// </summary> 
        public double Sum_alfa2_g
        {
            get { return cs.Sum_alfa2_g; }
        }

        /// <summary>
        /// Общая (теоретическая) энтальпия продуктов горения alfa = 1, кДж/м^3
        /// </summary> 
        public double c_топл_g
        {
            get { return cs.c_топл_g; }
        }

        /// <summary>
        /// Общая (теоретическая) энтальпия продуктов горения при alfa > 1, кДж/м^3
        /// </summary> 
        public double c_возд_g
        {
            get { return cs.c_возд_g; }
        }

        /// <summary>
        /// Энтальпия химического недожога alfa = 1, кДж/м^3
        /// </summary> 
        public double PG_возд_g
        {
            get { return cs.PG_возд_g; }
        }

        /// <summary>
        /// Энтальпия химического недожога alfa > 1, кДж/м^3
        /// </summary> 
        public double iхим_alfa1_g
        {
            get { return cs.iхим_alfa1_g; }
        }

        /// <summary>
        /// Общая балансовая энтальпия продуктов горения alfa = 1, кДж/м^3
        /// </summary> 
        public double iхим_alfa2_g
        {
            get { return cs.iхим_alfa2_g; }
        }

        /// <summary>
        /// Общая балансовая энтальпия продуктов горения при alfa > 1, кДж/м^3
        /// </summary> 
        public double iтопл_alfa1_g
        {
            get { return cs.iтопл_alfa1_g; }
        }

        /// <summary>
        /// Теоретическая температура alfa = 1
        /// </summary>  
        public double iтопл_alfa2_g
        {
            get { return cs.iтопл_alfa2_g; }
        }

        /// <summary>
        /// Теоретическая температура при alfa > 1
        /// </summary>  
        public double iвозд_alfa1_g
        {
            get { return cs.iвозд_alfa1_g; }
        }

        /// <summary>
        /// Целевая функция(теор) (=0) alfa = 1
        /// </summary>  
        public double iвозд_alfa2_g
        {
            get { return cs.iвозд_alfa2_g; }
        }

        /// <summary>
        /// Целевая функция(теор) (=0) при alfa > 1
        /// </summary> 
        public double iобщ_т_alfa1_g
        {
            get { return cs.iобщ_т_alfa1_g; }
        }

        /// <summary>
        /// Балансовая температура alfa = 1
        /// </summary>  
        public double iобщ_т_alfa2_g
        {
            get { return cs.iобщ_т_alfa2_g; }
        }

        /// <summary>
        /// Балансовая температура при alfa > 1
        /// </summary> 
        public double i_3_i_4_alfa1_g
        {
            get { return cs.i_3_i_4_alfa1_g; }
        }

        /// <summary>
        /// Целевая функция(баланс) (=0) alfa = 1
        /// </summary> 
        public double i_3_i_4_alfa2_g
        {
            get { return cs.i_3_i_4_alfa2_g; }
        }

        /// <summary>
        /// Общая балансовая энтальпия продуктов горения alfa = 1, кДж/м^3
        /// </summary> 
        public double i_общ_б_alfa_g
        {
            get { return cs.i_общ_б_alfa1_g; }
        }

        /// <summary>
        /// Общая балансовая энтальпия продуктов горения при alfa > 1, кДж/м^3
        /// </summary> 
        public double i_общ_б_alfa2_g
        {
            get { return cs.i_общ_б_alfa2_g; }
        }

        /// <summary>
        /// Теоретическая температура alfa = 1
        /// </summary>  
        public double Temp_alfa_g
        {
            get { return cs.Temp_alfa_g; }
        }

        /// <summary>
        /// Теоретическая температура при alfa > 1
        /// </summary>  
        public double Temp_alfa2_g
        {
            get { return cs.Temp_alfa2_g; }
        }

        /// <summary>
        /// Целевая функция(теор) (=0) alfa = 1
        /// </summary>  
        public double Cel_alfa_g
        {
            get { return cs.Cel_alfa_g; }
        }

        /// <summary>
        /// Целевая функция(теор) (=0) при alfa > 1
        /// </summary> 
        public double Cel_alfa2_g
        {
            get { return cs.Cel_alfa2_g; }
        }

        /// <summary>
        /// Балансовая температура alfa = 1
        /// </summary>  
        public double Tbalance_alfa_g
        {
            get { return cs.Tbalance_alfa_g; }
        }

        /// <summary>
        /// Балансовая температура при alfa > 1
        /// </summary> 
        public double Tbalance_alfa2_g
        {
            get { return cs.Tbalance_alfa2_g; }
        }

        /// <summary>
        /// Целевая функция(баланс) (=0) alfa = 1
        /// </summary> 
        public double Cel_balance_alfa_g
        {
            get { return cs.Cel_balance_alfa_g; }
        }

        /// <summary>
        /// Целевая функция(баланс) (=0) при alfa > 1
        /// </summary>  
        public double Cel_balance_alfa2_g
        {
            get { return cs.Cel_balance_alfa2_g; }
        }

        #endregion --- Получить расчетные показатели

    }
}
