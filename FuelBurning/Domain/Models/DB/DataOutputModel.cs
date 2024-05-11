using MathLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.DB
{
    public class DataOutputModel
    {
        public GasFuel cs = new GasFuel();

        private DataJsonGasFuelModel _DataInput = new DataJsonGasFuelModel();

        public DataOutputModel() { }

        public DataOutputModel(DataJsonGasFuelModel DataInput)
        {
            _DataInput = DataInput;

            #region --- Передать исходные данные в экземпляр библиотеки

            cs.CO2 = _DataInput.GasFuelModel.CO2;
            cs.CO = _DataInput.GasFuelModel.CO;
            cs.H2 = _DataInput.GasFuelModel.H2;
            cs.CH4 = _DataInput.GasFuelModel.CH4;
            cs.C2H6 = _DataInput.GasFuelModel.C2H6;
            cs.C3H8 = _DataInput.GasFuelModel.C3H8;
            cs.C4H10 = _DataInput.GasFuelModel.C4H10;
            cs.C5H12 = _DataInput.GasFuelModel.C5H12;
            cs.H2S = _DataInput.GasFuelModel.H2S;
            cs.N2 = _DataInput.GasFuelModel.N2;
            cs.G = _DataInput.GasFuelModel.G;
            cs.Tг = _DataInput.GasFuelModel.Tг;
            cs.Tв = _DataInput.GasFuelModel.Tв;
            cs.Alfa = _DataInput.GasFuelModel.Alfa;

            #endregion --- Передать исходные данные в экземпляр библиотеки
        }

        public void Temp_alfaCoreect()
        {
            cs.Temp_alfaCoreect();
        }
        public void Temp_alfaCoreect2()
        {
            cs.Temp_alfaCoreect2();
        }
        public void Tbalance_alfaCoreect()
        {
            cs.Tbalance_alfaCoreect();
        }
        public void Tbalance_alfaCoreect2()
        {
            cs.Tbalance_alfaCoreect2();
        }

        #region --- Получить расчетные показатели

        /// <summary>
        /// Рабочая масса H2O, %
        /// </summary> 
        public double Rh2o
        {
            get { return cs.H2Or; }
        }

        /// <summary>
        /// Рабочая масса CO2, %
        /// </summary> 
        public double Rco2
        {
            get { return cs.CO2r; }
        }

        /// <summary>
        /// Рабочая масса CO2, %
        /// </summary> 
        public double Rco
        {
            get { return cs.COr; }
        }

        /// <summary>
        /// Рабочая масса H2, %
        /// </summary> 
        public double Rh2
        {
            get { return cs.H2r; }
        }

        /// <summary>
        /// Рабочая масса CH4, %
        /// </summary>  
        public double Rch4
        {
            get { return cs.CH4r; }
        }

        /// <summary>
        /// Рабочая масса C2H6, %
        /// </summary> 
        public double Rc2h6
        {
            get { return cs.C2H6r; }
        }

        /// <summary>
        /// Рабочая масса C3H8, %
        /// </summary> 
        public double Rc3h8
        {
            get { return cs.C3H8r; }
        }

        /// <summary>
        /// Рабочая масса C4H10, %
        /// </summary> 
        public double Rc4h10
        {
            get { return cs.C4H10r; }
        }

        /// <summary>
        /// Рабочая масса C5H12, %
        /// </summary> 
        public double Rc5h12
        {
            get { return cs.C5H12r; }
        }

        /// <summary>
        /// Рабочая масса H2S, %
        /// </summary> 
        public double Rh2s
        {
            get { return cs.H2Sr; }
        }

        /// <summary>
        /// Рабочая масса N2, %
        /// </summary> 
        public double RN2
        {
            get { return cs.N2r; }
        }

        /// <summary>
        /// Сумма исходных данных (рабочая) %
        /// </summary> 
        public double Sumishdanrab
        {
            get { return cs.Sumishdanrab; }
        }


        /// <summary>
        /// Теоретический расход окислителя на горение L0, М3/М3
        /// </summary> 
        public double Lo
        {
            get { return cs.Lo; }
        }

        /// <summary>
        /// Действительный расход окислителя на горение Lalfa, м3/м3
        /// </summary> 
        public double Lalfa
        {
            get { return cs.Lalfa; }
        }




        /// <summary>
        /// Количество CO2 в продуктах горения, м3/м3
        /// </summary> 
        public double Vo_CO2
        {
            get { return cs.Vo_CO2; }
        }

        /// <summary>
        /// Количество SO2 в продуктах горения, м3/м3
        /// </summary> 
        public double Vo_SO2
        {
            get { return cs.Vo_SO2; }
        }

        /// <summary>
        /// Количество H2O в продуктах горения, м3/м3
        /// </summary> 
        public double Vo_H2O
        {
            get { return cs.Vo_H2O; }
        }

        /// <summary>
        /// Количество N2 в продуктах горения, м3/м3
        /// </summary> 
        public double Vo_N2
        {
            get { return cs.Vo_N2; }
        }

        /// <summary>
        /// Количество CO в продуктах горения, м3/м3
        /// </summary>  
        public double Vo_CO
        {
            get { return cs.Vo_CO; }
        }

        /// <summary>
        /// Количество H2 в продуктах горения, м3/м3
        /// </summary> 
        public double Vo_H2
        {
            get { return cs.Vo_H2; }
        }

        /// <summary>
        /// Количество O2 в продуктах горения, м3/м3
        /// </summary> 
        public double Vo_O2
        {
            get { return cs.Vo_O2; }
        }

        /// <summary>
        /// Количество Vo в продуктах горения, м3/м3
        /// </summary> 
        public double Vo
        {
            get { return cs.Vo; }
        }

        /// <summary>
        /// Практический выход N2 при избытке окислителя, м3/м3
        /// </summary> 
        public double V_alfa_N2
        {
            get { return cs.V_alfa_N2; }
        }

        /// <summary>
        /// Количество избыточного кислорода в продуктах горения, м3/м3
        /// </summary> 
        public double V_O2_izb
        {
            get { return cs.V_O2_izb; }
        }

        /// <summary>
        /// Действительное количество продуктов горения, м3/м3
        /// </summary> 
        public double V_alfa
        {
            get { return cs.V_alfa; }
        }



        /// <summary>
        /// Содежание CO2 в продуктах горения alfa = 1, %
        /// </summary> 
        public double CO2alfa
        {
            get { return cs.CO2alfa; }
        }

        /// <summary>
        /// Содежание CO2 в продуктах горения alfa > 1, %
        /// </summary> 
        public double CO2alfa2
        {
            get { return cs.CO2alfa2; }
        }

        /// <summary>
        /// Содержание SO2 в продуктах горения alfa = 1, %
        /// </summary> 
        public double SO2alfa
        {
            get { return cs.SO2alfa; }
        }

        /// <summary>
        /// Содержание SO2 в продуктах горения alfa > 1, %
        /// </summary> 
        public double SO2alfa2
        {
            get { return cs.SO2alfa2; }
        }

        /// <summary>
        /// Содержание H2O в продуктах горения alfa = 1, %
        /// </summary> 
        public double H2Oalfa
        {
            get { return cs.H2Oalfa; }
        }

        /// <summary>
        /// Содержание H2O в продуктах горения alfa > 1, %
        /// </summary> 
        public double H2Oalfa2
        {
            get { return cs.H2Oalfa2; }
        }

        /// <summary>
        /// Содержание N2 в продуктах горения alfa = 1, %
        /// </summary> 
        public double N2alfa
        {
            get { return cs.N2alfa; }
        }

        /// <summary>
        /// Содержание N2 в продуктах горения alfa > 1, %
        /// </summary> 
        public double N2alfa2
        {
            get { return cs.N2alfa2; }
        }

        /// <summary>
        /// Содержание CO в продуктах горения alfa = 1, %
        /// </summary> 
        public double COalfa
        {
            get { return cs.COalfa; }
        }

        /// <summary>
        /// Содержание CO в продуктах горения alfa > 1, %
        /// </summary> 
        public double COalfa2
        {
            get { return cs.COalfa2; }
        }

        /// <summary>
        /// Содержание H2 в продуктах горения alfa = 1, %
        /// </summary> 
        public double H2alfa
        {
            get { return cs.H2alfa; }
        }

        /// <summary>
        /// Содержание H2 в продуктах горения alfa > 1, %
        /// </summary> 
        public double H2alfa2
        {
            get { return cs.H2alfa2; }
        }

        /// <summary>
        /// Содержание O2 в продуктах горения alfa = 1, %
        /// </summary> 
        public double O2alfa
        {
            get { return cs.O2alfa; }
        }

        /// <summary>
        /// Содержание O2 в продуктах горения alfa > 1, %
        /// </summary> 
        public double O2alfa2
        {
            get { return cs.O2alfa2; }
        }

        /// <summary>
        /// Общая процентная сумма (100%) alfa = 1, %
        /// </summary> 
        public double Sumalfa
        {
            get { return cs.Sumalfa; }
        }

        /// <summary>
        /// Общая процентная сумма (100%) alfa > 1, %
        /// </summary> 
        public double Sumalfa2
        {
            get { return cs.Sumalfa2; }
        }



        /// <summary>
        /// Теплота сгорания топлива, кДж/(М^3)
        /// </summary> 
        public double Qнр
        {
            get { return cs.Qнр; }
        }

        /// <summary>
        /// Удельная теплоемкость газообразного топлива, кДж/(М^3 * Со)
        /// </summary> 
        public double Cтопл
        {
            get { return cs.Cтопл; }
        }

        /// <summary>
        /// Удельная теплоемкость воздуха, кДж/(М^3 * Со)
        /// </summary> 
        public double Cвозд
        {
            get { return cs.Cвозд; }
        }

        /// <summary>
        /// Воздух в ПГ, %
        /// </summary> 
        public double ВоздВПГ
        {
            get { return cs.ВоздВПГ; }
        }



        /// <summary>
        /// Химическая энтальпия топлива при alfa = 1, кДж/м^3
        /// </summary> 
        public double i_химalfa
        {
            get { return cs.i_химalfa; }
        }

        /// <summary>
        /// Химическая энтальпия топлива при alfa > 1, кДж/м^3
        /// </summary> 
        public double i_химalfa2
        {
            get { return cs.i_химalfa2; }
        }

        /// <summary>
        /// Физическая энтальпия подогрева топлива при alfa = 1, кДж/м^3
        /// </summary> 
        public double i_топлalfa
        {
            get { return cs.i_топлalfa; }
        }

        /// <summary>
        /// Физическая энтальпия подогрева топлива при alfa > 1, кДж/м^3
        /// </summary> 
        public double i_топлalfa2
        {
            get { return cs.i_топлalfa2; }
        }

        /// <summary>
        /// Физическая энтальпия подогрева воздуха  alfa = 1, кДж/м^3
        /// </summary> 
        public double i_воздalfa
        {
            get { return cs.i_воздalfa; }
        }

        /// <summary>
        /// Физическая энтальпия подогрева воздуха при alfa > 1, кДж/м^3
        /// </summary> 
        public double i_воздalfa2
        {
            get { return cs.i_воздalfa2; }
        }

        /// <summary>
        /// Общая (теоретическая) энтальпия продуктов горения alfa = 1, кДж/м^3
        /// </summary> 
        public double i_общ_т_alfa
        {
            get { return cs.i_общ_т_alfa; }
        }

        /// <summary>
        /// Общая (теоретическая) энтальпия продуктов горения при alfa > 1, кДж/м^3
        /// </summary> 
        public double i_общ_т_alfa2
        {
            get { return cs.i_общ_т_alfa2; }
        }

        /// <summary>
        /// Энтальпия химического недожога alfa = 1, кДж/м^3
        /// </summary> 
        public double i_з_alfa
        {
            get { return cs.i_з_alfa; }
        }

        /// <summary>
        /// Энтальпия химического недожога alfa > 1, кДж/м^3
        /// </summary> 
        public double i_з_alfa2
        {
            get { return cs.i_з_alfa2; }
        }

        /// <summary>
        /// Общая балансовая энтальпия продуктов горения alfa = 1, кДж/м^3
        /// </summary> 
        public double i_общ_б_alfa
        {
            get { return cs.i_общ_б_alfa; }
        }

        /// <summary>
        /// Общая балансовая энтальпия продуктов горения при alfa > 1, кДж/м^3
        /// </summary> 
        public double i_общ_б_alfa2
        {
            get { return cs.i_общ_б_alfa2; }
        }

        /// <summary>
        /// Теоретическая температура alfa = 1
        /// </summary>  
        public double Temp_alfa
        {
            get { return cs.Temp_alfa; }
        }

        /// <summary>
        /// Теоретическая температура при alfa > 1
        /// </summary>  
        public double Temp_alfa2
        {
            get { return cs.Temp_alfa2; }
        }

        /// <summary>
        /// Целевая функция(теор) (=0) alfa = 1
        /// </summary>  
        public double Cel_alfa
        {
            get { return cs.pogreshnost; }
        }

        /// <summary>
        /// Целевая функция(теор) (=0) при alfa > 1
        /// </summary> 
        public double Cel_alfa2
        {
            get { return cs.Cel_alfa2; }
        }

        /// <summary>
        /// Балансовая температура alfa = 1
        /// </summary>  
        public double Tbalance_alfa
        {
            get { return cs.Tbalance_alfa; }
        }

        /// <summary>
        /// Балансовая температура при alfa > 1
        /// </summary> 
        public double Tbalance_alfa2
        {
            get { return cs.Tbalance_alfa2; }
        }

        /// <summary>
        /// Целевая функция(баланс) (=0) alfa = 1
        /// </summary> 
        public double Cel_balance_alfa
        {
            get { return cs.Cel_balance_alfa; }
        }

        /// <summary>
        /// Целевая функция(баланс) (=0) при alfa > 1
        /// </summary>  
        public double Cel_balance_alfa2
        {
            get { return cs.Cel_balance_alfa2; }
        }

        #endregion --- Получить расчетные показатели

    }
}
