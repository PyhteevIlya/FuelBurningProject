using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib
{
    public class LiquidFuel
    {
        #region Исходные данные (жидкое топливо) 

        /// <summary>
        /// Масса C,%
        /// </summary> 
        private double _C;    // закрытая переменная класса 
        public double C
        {
            get { return _C; }
            set { _C = value; }
        }

        /// <summary>
        /// Масса H,%
        /// </summary> 
        private double _H;    // закрытая переменная класса 
        public double H
        {
            get { return _H; }
            set { _H = value; }
        }

        /// <summary>
        /// Масса S,%
        /// </summary> 
        private double _S;    // закрытая переменная класса 
        public double S
        {
            get { return _S; }
            set { _S = value; }
        }

        /// <summary>
        /// Масса N,%
        /// </summary> 
        private double _N;    // закрытая переменная класса 
        public double N
        {
            get { return _N; }
            set { _N = value; }
        }

        /// <summary>
        /// Масса O,%
        /// </summary> 
        private double _O;    // закрытая переменная класса 
        public double O
        {
            get { return _O; }
            set { _O = value; }
        }

        /// <summary>
        /// Содержание влаги в топливе, %
        /// </summary> 
        private double _Wp;    // закрытая переменная класса 
        public double Wp
        {
            get { return _Wp; }
            set { _Wp = value; }
        }

        /// <summary>
        /// Содержание золы в топливе, %
        /// </summary> 
        private double _Ap;    // закрытая переменная класса 
        public double Ap
        {
            get { return _Ap; }
            set { _Ap = value; }
        }

        /// <summary>
        /// Температура подогрева воздуха перед горением
        /// </summary> 
        private double _T_v;    // закрытая переменная класса 
        public double T_v
        {
            get { return _T_v; }
            set { _T_v = value; }
        }

        /// <summary>
        /// Температура подогрева воздуха перед горением (только для мазута)
        /// </summary> 
        private double _T_t;    // закрытая переменная класса 
        public double T_t
        {
            get { return _T_t; }
            set { _T_t = value; }
        }

        /// <summary>
        /// Коэффициент расхода воздуха на горение
        /// </summary> 
        private double _alfaG;    // закрытая переменная класса 
        public double alfaG
        {
            get { return _alfaG; }
            set { _alfaG = value; }
        }

        /// <summary>
        /// Механический недожог топлива, % к теплоте сгорания топлива
        /// </summary> 
        private double _M_недожог;    // закрытая переменная класса 
        public double M_недожог
        {
            get { return _M_недожог; }
            set { _M_недожог = value; }
        }

        /// <summary>
        /// Влагосодержание воздуха, г/м3 сухого воздуха
        /// </summary> 
        private double _gg;    // закрытая переменная класса 
        public double gg
        {
            get { return _gg; }
            set { _gg = value; }
        }


        #endregion

        #region Промежуточные расчетные показатели (жидкое топливо) 

        ///// <summary>
        ///// Рабочая масса C, %
        ///// </summary> 
        //private double _Cr;    // закрытая переменная класса 
        //public double Cr()
        //{
        //    return _Cr = (0.1244 * _g) / (1 + 0.00124 * _g);
        //}


        #endregion

        #region Расчетные показатели (жидкое топливо) 

        /// <summary>
        /// Количество необходимого кислорода для окисление всех горючих компонентов топлива м3/кг
        /// </summary> 
        public double V_O2_g
        {
            get
            {
                return 0.01 * (1.867 * _C + 5.6 * _H + 0.7 * _S - 0.7 * _O);
            }
        }

        /// <summary>
        /// Теоретический расход сухого воздуха, м3/кг
        /// </summary> 
        public double Lo_св
        {
            get
            {
                return (1 + 3.76) * V_O2_g;
            }
        }

        /// <summary>
        /// Теоретический расход влажного воздуха, м3/кг
        /// </summary> 
        public double Lo_вв
        {
            get
            {
                return (1 + 0.00124 * _gg) * Lo_св;
            }
        }

        /// <summary>
        /// Действительный расход влажного воздуха, м3/кг
        /// </summary> 
        public double L_alfa_вв
        {
            get
            {
                return _alfaG * Lo_вв;
            }
        }

        /// <summary>
        /// Количество CO2 в продутах горения при alfa=1 м3/кг топлива
        /// </summary>  
        public double Vo_CO2_alfa1_g
        {
            get
            {
                return 0.01 * 1.867 * _C - Vo_CO_alfa1_g;
            }
        }

        /// <summary>
        /// Количество CO2 в продутах горения при alfa>1 м3/кг топлива
        /// </summary>  
        public double Vo_CO2_alfa2_g
        {
            get
            {
                return Vo_CO2_alfa1_g;
            }
        }

        /// <summary>
        /// Количество SO2 в продутах горения при alfa=1 м3/кг топлива
        /// </summary> 
        public double Vo_SO2_alfa1_g
        {
            get
            {
                    return 0.01 * 0.7 * _S;
            }
        }

        /// <summary>
        /// Количество SO2 в продутах горения при alfa>1 м3/кг топлива
        /// </summary> 
        public double Vo_SO2_alfa2_g
        {
            get
            {
                return Vo_SO2_alfa1_g;
            }
        }

        /// <summary>
        /// Количество H2O в продутах горения при alfa=1 м3/кг топлива
        /// </summary> 
        public double Vo_H2O_alfa1_g
        {
            get
            {
                return 0.01 * 1.244 * _Wp + 0.01 * 11.2 * _H + 0.00124 * _gg * Lo_св - Vo_H2_alfa1_g;
            }
        }

        /// <summary>
        /// Количество H2O в продутах горения при alfa>1 м3/кг топлива
        /// </summary>  
        public double Vo_H2O_alfa2_g
        {
            get
            {
                return Vo_H2O_alfa1_g + 0.00124 * _gg * (_alfaG - 1) * Lo_св;
            }
        }

        /// <summary>
        /// Количество N2 в продутах горения при alfa=1 м3/кг топлива
        /// </summary> 
        public double Vo_N2_alfa1_g
        {
            get
            {
                return 0.01 * 0.8 * _N + 3.76 * V_O2_g;
            }
        }

        /// <summary>
        /// Количество N2 в продутах горения при alfa>1 м3/кг топлива
        /// </summary>  
        public double Vo_N2_alfa2_g
        {
            get
            {
                return Vo_N2_alfa1_g + 3.76 * (_alfaG - 1) * V_O2_g;
            }
        }

        /// <summary>
        /// Количество CO в продутах горения при alfa=1 м3/кг топлива
        /// </summary>  
        public double Vo_CO_alfa1_g
        {
            get
            {
                var Vo_CO_alfa12_g = (Math.Pow(2, 0.5) * Math.Exp((-58090 + 17.628 * Temp_alfa_g) / (1.987 * Temp_alfa_g)));
                return  Math.Pow(Vo_CO_alfa12_g, 0.6667);
            }
        }

        /// <summary>
        /// Количество CO в продутах горения при alfa>1 м3/кг топлива
        /// </summary>  
        public double Vo_CO_alfa2_g
        {
            get
            {
                var Vo_CO_alfa22_g = (Math.Pow(2, 0.5) * Math.Exp((-58090 + 17.628 * Temp_alfa2_g) / (1.987 * Temp_alfa2_g)));
                return Math.Pow(Vo_CO_alfa22_g, 0.6667);
            }
        }

        /// <summary>
        /// Количество H2 в продутах горения при alfa=1 м3/кг топлива
        /// </summary> 
        public double Vo_H2_alfa1_g
        {
            get
            {
                var Vo_H2_alfa12_g = (Math.Pow(2, 0.5) * Math.Exp((-52300 + 12.081 * Temp_alfa_g) / (1.987 * Temp_alfa_g)));
                return Math.Pow(Vo_H2_alfa12_g, 0.6667);
            }
        }

        /// <summary>
        /// Количество H2 в продутах горения при alfa>1 м3/кг топлива
        /// </summary> 
        public double Vo_H2_alfa2_g
        {
            get
            {
                var Vo_H2_alfa22_g = (Math.Pow(2, 0.5) * Math.Exp((-52300 + 12.081 * Temp_alfa2_g) / (1.987 * Temp_alfa2_g)));
                return Math.Pow(Vo_H2_alfa22_g, 0.6667);
            }
        }

        /// <summary>
        /// Количество O2 в продутах горения при alfa=1 м3/кг топлива
        /// </summary>  
        public double Vo_O2_alfa1_g
        {
            get
            {
                return 0.5 * Vo_CO_alfa1_g + 0.5 * Vo_H2_alfa1_g;
            }
        }

        /// <summary>
        /// Количество O2 в продутах горения при alfa>1 м3/кг топлива
        /// </summary>  
        public double Vo_O2_alfa2_g
        {
            get
            {
                return 0.5 * Vo_CO_alfa2_g + 0.5 * Vo_H2_alfa2_g;
            }
        }

        /// <summary>
        /// Теоретический объем продуктов гроения при alfa=1 м3/кг топлива
        /// </summary>  
        public double Vo_alfa1_g
        {
            get
            {
                return Vo_CO2_alfa1_g + Vo_SO2_alfa1_g + Vo_H2O_alfa1_g + Vo_N2_alfa1_g + Vo_CO_alfa1_g + Vo_H2_alfa1_g + Vo_O2_alfa1_g;
            }
        }

        /// <summary>
        /// Количество избыточного кислорода в продуктах горения при alfa>1 м3/кг топлива
        /// </summary>  
        public double V_O2_izd_alfa2_g
        {
            get
            {
                return (_alfaG - 1) * V_O2_g;
            }
        }

        /// <summary>
        /// Дествительное количество продуктов гроения при alfa>1 м3/кг топлива
        /// </summary>  
        public double V_alfa_g
        {
            get
            {
                return Vo_CO2_alfa2_g + Vo_SO2_alfa2_g + Vo_H2O_alfa2_g + Vo_N2_alfa2_g + Vo_CO_alfa2_g + Vo_H2_alfa2_g + Vo_O2_alfa2_g + V_O2_izd_alfa2_g;
            }
        }

        /// <summary>
        /// Содержание CO2 в продуктах горения при alfa=1, %
        /// </summary> 
        public double CO2_alfa1_g
        {
            get
            {
                return Vo_CO2_alfa1_g / Vo_alfa1_g * 100;
            }
        }

        /// <summary>
        /// Содержание CO2 в продуктах горения при alfa>1, %
        /// </summary> 
        public double CO2_alfa2_g
        {
            get
            {
                return Vo_CO2_alfa2_g / V_alfa_g * 100;
            }
        }

        /// <summary>
        /// Содержание SO2 в продуктах горения при alfa=1, %
        /// </summary>  
        public double SO2_alfa1_g
        {
            get
            {
                return Vo_SO2_alfa1_g / Vo_alfa1_g * 100;
            }
        }

        /// <summary>
        /// Содержание SO2 в продуктах горения при alfa>1, %
        /// </summary>  
        public double SO2_alfa2_g
        {
            get
            {
                return Vo_SO2_alfa2_g / V_alfa_g * 100;
            }
        }

        /// <summary>
        /// Содержание H2O в продуктах горения при alfa=1, %
        /// </summary>  
        public double H2O_alfa1_g
        {
            get
            {
                return Vo_H2O_alfa1_g / Vo_alfa1_g * 100;
            }
        }

        /// <summary>
        /// Содержание H2O в продуктах горения при alfa>1, %
        /// </summary>  
        public double H2O_alfa2_g
        {
            get
            {
                return Vo_H2O_alfa2_g / V_alfa_g * 100;
            }
        }

        /// <summary>
        /// Содержание N2 в продуктах горения при alfa=1, %
        /// </summary>  
        public double N2_alfa1_g
        {
            get
            {
                return Vo_N2_alfa1_g / Vo_alfa1_g * 100;
            }
        }

        /// <summary>
        /// Содержание N2 в продуктах горения при alfa>1, %
        /// </summary>  
        public double N2_alfa2_g
        {
            get
            {
                return Vo_N2_alfa2_g / V_alfa_g * 100;
            }
        }

        /// <summary>
        /// Содержание CO в продуктах горения при alfa=1, %
        /// </summary>  
        public double CO_alfa1_g
        {
            get
            {
                return Vo_CO_alfa1_g / Vo_alfa1_g * 100;
            }
        }

        /// <summary>
        /// Содержание CO в продуктах горения при alfa>1, %
        /// </summary>  
        public double CO_alfa2_g
        {
            get
            {
                return Vo_CO_alfa2_g / V_alfa_g * 100;
            }
        }

        /// <summary>
        /// Содержание H2 в продуктах горения при alfa=1, %
        /// </summary>  
        public double H2_alfa1_g
        {
            get
            {
                return Vo_H2_alfa1_g / Vo_alfa1_g * 100;
            }
        }

        /// <summary>
        /// Содержание H2 в продуктах горения при alfa>1, %
        /// </summary>  
        public double H2_alfa2_g
        {
            get
            {
                return Vo_H2_alfa2_g / V_alfa_g * 100;
            }
        }

        /// <summary>
        /// Содержание O2 в продуктах горения при alfa=1, %
        /// </summary>  
        public double O2_alfa1_g
        {
            get
            {
                return Vo_O2_alfa1_g / Vo_alfa1_g * 100;
            }
        }

        /// <summary>
        /// Содержание O2 в продуктах горения при alfa>1, %
        /// </summary>  
        public double O2_alfa2_g
        {
            get
            {
                return (Vo_O2_alfa2_g + V_O2_izd_alfa2_g) / V_alfa_g * 100;
            }
        }

        /// <summary>
        /// Общая процентная сумма всех компонентов при alfa=1, %
        /// </summary>  
        public double Sum_alfa1_g
        {
            get
            {
                return CO2_alfa1_g + SO2_alfa1_g + H2O_alfa1_g + N2_alfa1_g + CO_alfa1_g + H2_alfa1_g + O2_alfa1_g;
            }
        }

        /// <summary>
        /// Общая процентная сумма всех компонентов при alfa>1, %
        /// </summary>  
        public double Sum_alfa2_g
        {
            get
            {
                return CO2_alfa2_g + SO2_alfa2_g + H2O_alfa2_g + N2_alfa2_g + CO_alfa2_g + H2_alfa2_g + O2_alfa2_g;
            }
        }

        /// <summary>
        /// Удельная теплоемкость топлива(только для мазута), кДж/(кг * ^о С)
        /// </summary>  
        public double c_топл_g
        {
            get
            {
                return 0.005 * _T_t + 1.78;
            }
        }

        /// <summary>
        /// Удельная теплоемкость воздуха, кДж/(кг * ^о С)
        /// </summary>  
        public double c_возд_g
        {
            get
            {
                return 0.0001 * _T_v + 1.2857;
            }
        }

        /// <summary>
        /// Содержание воздуха в продуктах горения %
        /// </summary>  
        public double PG_возд_g
        {
            get
            {
                return (L_alfa_вв - Lo_вв) * 100 / V_alfa_g;
            }
        }

        /// <summary>
        /// Теплота сгорания топлива, кДж/кг
        /// </summary>  
        public double Q_нр_g
        {
            get
            {
                return 339 * _C + 1030 * _H - 109 * (_O - _S) - 25 * (9 * _H + _Wp);
            }
        }

        /// <summary>
        /// Химическая энтальпия топлива при alfa=1, кДж/м3
        /// </summary>  
        public double iхим_alfa1_g
        {
            get
            {
                return Q_нр_g / Vo_alfa1_g;
            }
        }

        /// <summary>
        /// Химическая энтальпия топлива при alfa>1, кДж/м3
        /// </summary>  
        public double iхим_alfa2_g
        {
            get
            {
                return Q_нр_g / V_alfa_g;
            }
        }

        /// <summary>
        /// Физическая энтальпия подогретого топлива при alfa=1, кДж/м3
        /// </summary>  
        public double iтопл_alfa1_g
        {
            get
            {
                return c_топл_g * T_t / Vo_alfa1_g;
            }
        }

        /// <summary>
        /// Физическая энтальпия подогретого топлива при alfa>1, кДж/м3
        /// </summary>  
        public double iтопл_alfa2_g
        {
            get
            {
                return c_топл_g * T_t / V_alfa_g;
            }
        }

        /// <summary>
        /// Физическая энтальпия подогретого воздуха при alfa=1, кДж/м3
        /// </summary>  
        public double iвозд_alfa1_g
        {
            get
            {
                return c_возд_g * T_v * Lo_вв / Vo_alfa1_g;
            }
        }

        /// <summary>
        /// Физическая энтальпия подогретого воздуха при alfa>1, кДж/м3
        /// </summary>  
        public double iвозд_alfa2_g
        {
            get
            {
                return c_возд_g * T_v * L_alfa_вв / V_alfa_g;
            }
        }

        /// <summary>
        /// Общая (теоретическая) энтальпия продуктов горения при alfa=1, кДж/м3
        /// </summary>  
        public double iобщ_т_alfa1_g
        {
            get
            {
                return iхим_alfa1_g + iтопл_alfa1_g + iвозд_alfa1_g;
            }
        }

        /// <summary>
        /// Общая (теоретическая) энтальпия продуктов горения при alfa>1, кДж/м3
        /// </summary>  
        public double iобщ_т_alfa2_g
        {
            get
            {
                return iхим_alfa2_g + iтопл_alfa2_g + iвозд_alfa2_g;
            }
        }

        /// <summary>
        /// Энтальпия химического и физического недожогов при alfa=1, кДж/м3
        /// </summary>  
        public double i_3_i_4_alfa1_g
        {
            get
            {
                return (_M_недожог / 100) * iхим_alfa1_g + (Vo_CO_alfa1_g * 12600 + Vo_H2_alfa1_g * 10800) / Vo_alfa1_g;
            }
        }

        /// <summary>
        /// Энтальпия химического и механического недожогов при alfa>1, кДж/м3
        /// </summary>  
        public double i_3_i_4_alfa2_g
        {
            get
            {
                return (_M_недожог / 100) * iхим_alfa2_g + (Vo_CO_alfa2_g * 12600 + Vo_H2_alfa2_g * 10800) / V_alfa_g;
            }
        }

        /// <summary>
        /// Энтальпия химического и механического недожогов при alfa=1, кДж/м3
        /// </summary>  
        public double i_общ_б_alfa1_g
        {
            get
            {
                return iобщ_т_alfa1_g - i_3_i_4_alfa1_g;
            }
        }

        /// <summary>
        /// Энтальпия химического и физического недожогов при alfa>1, кДж/м3
        /// </summary>  
        public double i_общ_б_alfa2_g
        {
            get
            {
                return iобщ_т_alfa2_g - i_3_i_4_alfa2_g;
            }
        }

        public void Temp_alfaCoreect_g()
        {
            var currentPogreshnost = Cel_alfa_g;
            double pribavka = 0.1;

            for (int i = 0; (i < 10000 && Math.Abs(Cel_alfa_g) > 0.1); i++)
            {
                Temp_alfa_g += pribavka;

                if (Cel_alfa_g > currentPogreshnost & Cel_alfa_g > 0) pribavka = -0.1;
                currentPogreshnost = Cel_alfa_g;
            }

            var x = 0;
        }

        /// <summary>
        /// Теоретическая температура alfa = 1
        /// </summary>  
        public double Temp_alfa_g { get; set; } = 2150.7659273209;


        public void Temp_alfaCoreect2_g()
        {
            var currentPogreshnost = Cel_alfa2_g;
            double pribavka = 0.1;

            for (int i = 0; (i < 10000 && Math.Abs(Cel_alfa2_g) > 0.1); i++)
            {
                Temp_alfa2_g += pribavka;

                if (Cel_alfa2_g > currentPogreshnost & Cel_alfa2_g > 0) pribavka = -0.1;
                currentPogreshnost = Cel_alfa2_g;
            }

            var x = 0;
        }

        /// <summary>
        /// Теоретическая температура при alfa > 1
        /// </summary>  
        public double Temp_alfa2_g { get; set; } = 1874.6625511434;


        /// <summary>
        /// Целевая функция(теор) (=0) alfa = 1
        /// </summary>  
        public double Cel_alfa_g
        {
            get
            {
               
                return Temp_alfa_g - iобщ_т_alfa1_g / ((CO2_alfa1_g * (0.0005 * Temp_alfa_g + 1.6876) + SO2_alfa1_g * (0.0004 * Temp_alfa_g + 1.8119) + H2O_alfa1_g * (0.0002 * Temp_alfa_g + 1.4756) + N2_alfa1_g * (0.0001 * Temp_alfa_g + 1.2796) + CO_alfa1_g * (0.0001 * Temp_alfa_g + 1.2851) + H2_alfa1_g * (0.00005 * Temp_alfa_g + 1.2814) + O2_alfa1_g * (0.0002 * Temp_alfa_g + 1.3094)) / 100);
            }
        }

        /// <summary>
        /// Целевая функция(теор) (=0) при alfa > 1
        /// </summary>  
        public double Cel_alfa2_g
        {
            get
            {
                return Temp_alfa2_g - iобщ_т_alfa2_g / ((CO2_alfa2_g * (0.0005 * Temp_alfa2_g + 1.6876) + SO2_alfa2_g * (0.0004 * Temp_alfa2_g + 1.8119) + H2O_alfa2_g * (0.0002 * Temp_alfa2_g + 1.4756) + N2_alfa2_g * (0.0001 * Temp_alfa2_g + 1.2796) + CO_alfa2_g * (0.0001 * Temp_alfa2_g + 1.2851) + H2_alfa2_g * (0.00005 * Temp_alfa2_g + 1.2814) + O2_alfa2_g * (0.0002 * Temp_alfa2_g + 1.3094)) / 100);
            }
        }

        public void Tbalance_alfaCoreect1_g()
        {
            var currentPogreshnost = Cel_balance_alfa_g;
            double pribavka = 0.1;

            for (int i = 0; (i < 10000 && Math.Abs(Cel_balance_alfa_g) > 0.1); i++)
            {
                Tbalance_alfa_g += pribavka;

                if (Cel_balance_alfa_g > currentPogreshnost & Cel_balance_alfa_g > 0) pribavka = -0.1;
                currentPogreshnost = Cel_balance_alfa_g;
            }

            var x = 0;
        }

        /// <summary>
        /// Балансовая температура alfa = 1
        /// </summary> 
        public double Tbalance_alfa_g { get; set; } = 2046.31477486374;

        public void Tbalance_alfaCoreect2_g()
        {
            var currentPogreshnost = Cel_balance_alfa2_g;
            double pribavka = 0.1;

            for (int i = 0; (i < 10000 && Math.Abs(Cel_balance_alfa2_g) > 0.1); i++)
            {
                Tbalance_alfa2_g += pribavka;

                if (Cel_balance_alfa2_g > currentPogreshnost & Cel_balance_alfa2_g > 0) pribavka = -0.1;
                currentPogreshnost = Cel_balance_alfa2_g;
            }

            var x = 0;
        }

        /// <summary>
        /// Балансовая температура при alfa > 1
        /// </summary> 
        public double Tbalance_alfa2_g { get; set; } = 1809.04492469862;

        /// <summary>
        /// Целевая функция(баланс) (=0) alfa = 1
        /// </summary> 
        public double Cel_balance_alfa_g
        {
            get
            {
                return Tbalance_alfa_g - i_общ_б_alfa1_g / ((CO2_alfa1_g * (0.0005 * Tbalance_alfa_g + 1.6876) + SO2_alfa1_g * (0.0004 * Tbalance_alfa_g + 1.8119) + H2O_alfa1_g * (0.0002 * Tbalance_alfa_g + 1.4756) + N2_alfa1_g * (0.0001 * Tbalance_alfa_g + 1.2796) + CO_alfa1_g * (0.0001 * Tbalance_alfa_g + 1.2851) + H2_alfa1_g * (0.00005 * Tbalance_alfa_g + 1.2814) + O2_alfa1_g * (0.0002 * Tbalance_alfa_g + 1.3094)) / 100);
            }
        }

        /// <summary>
        /// Целевая функция(баланс) (=0) при alfa > 1
        /// </summary>  
        public double Cel_balance_alfa2_g
        {
            get
            {
                return Tbalance_alfa2_g - i_общ_б_alfa2_g / ((CO2_alfa2_g * (0.0005 * Tbalance_alfa2_g + 1.6876) + SO2_alfa2_g * (0.0004 * Tbalance_alfa2_g + 1.8119) + H2O_alfa2_g * (0.0002 * Tbalance_alfa2_g + 1.4756) + N2_alfa2_g * (0.0001 * Tbalance_alfa2_g + 1.2796) + CO_alfa2_g * (0.0001 * Tbalance_alfa2_g + 1.2851) + H2_alfa2_g * (0.00005 * Tbalance_alfa2_g + 1.2814) + O2_alfa2_g * (0.0002 * Tbalance_alfa2_g + 1.3094)) / 100);
            }
        }

        #endregion
    }
}
