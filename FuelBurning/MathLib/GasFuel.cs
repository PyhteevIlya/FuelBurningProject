namespace MathLib
{
    public class GasFuel
    {
        #region Исходные данные (газообразное топливо)
        /// <summary>
        /// Масса CO2,%
        /// </summary> 
        private double _CO2;    // закрытая переменная класса 
        public double CO2
        {
            get { return _CO2; }
            set { _CO2 = value; }
        }

        /// <summary>
        /// Масса CO,%
        /// </summary> 
        private double _CO;    // закрытая переменная класса 
        public double CO
        {
            get { return _CO; }
            set { _CO = value; }
        }

        /// <summary>
        /// Масса H2,%
        /// </summary> 
        private double _H2;    // закрытая переменная класса 
        public double H2
        {
            get { return _H2; }
            set { _H2 = value; }
        }

        /// <summary>
        /// Масса CH4,%
        /// </summary> 
        private double _CH4;    // закрытая переменная класса 
        public double CH4
        {
            get { return _CH4; }
            set { _CH4 = value; }
        }

        /// <summary>
        /// Масса C2H6,%
        /// </summary> 
        private double _C2H6;    // закрытая переменная класса 
        public double C2H6
        {
            get { return _C2H6; }
            set { _C2H6 = value; }
        }

        /// <summary>
        /// Масса C3H8,%
        /// </summary> 
        private double _C3H8;    // закрытая переменная класса 
        public double C3H8
        {
            get { return _C3H8; }
            set { _C3H8 = value; }
        }

        /// <summary>
        /// Масса C4H10,%
        /// </summary> 
        private double _C4H10;    // закрытая переменная класса 
        public double C4H10
        {
            get { return _C4H10; }
            set { _C4H10 = value; }
        }

        /// <summary>
        /// Масса C5H12,%
        /// </summary> 
        private double _C5H12;    // закрытая переменная класса 
        public double C5H12
        {
            get { return _C5H12; }
            set { _C5H12 = value; }
        }

        /// <summary>
        /// Масса H2S,%
        /// </summary> 
        private double _H2S;    // закрытая переменная класса 
        public double H2S
        {
            get { return _H2S; }
            set { _H2S = value; }
        }

        /// <summary>
        /// Масса N2,%
        /// </summary> 
        private double _N2;    // закрытая переменная класса 
        public double N2
        {
            get { return _N2; }
            set { _N2 = value; }
        }

        /// <summary>
        /// Масса H2O,%
        /// </summary> 
        private double _H2O;    // закрытая переменная класса 
        public double H2O
        {
            get { return _H2O; }
            set { _H2O = value; }
        }

        /// <summary>
        /// Масса g,%
        /// </summary> 
        private double _g;    // закрытая переменная класса 
        public double G
        {
            get { return _g; }
            set { _g = value; }
        }

        /// <summary>
        /// Масса t_г, С
        /// </summary> 
        private double _t_г;    // закрытая переменная класса 
        public double Tг
        {
            get { return _t_г; }
            set { _t_г = value; }
        }

        /// <summary>
        /// Масса t_в, С
        /// </summary> 
        private double _t_в;    // закрытая переменная класса 
        public double Tв
        {
            get { return _t_в; }
            set { _t_в = value; }
        }

        /// <summary>
        /// Масса коэф.расхода воздуха на горение
        /// </summary> 
        private double _alfa;    // закрытая переменная класса 
        public double Alfa
        {
            get { return _alfa; }
            set { _alfa = value; }
        }

        /// <summary>
        /// Сумма исходных данных %
        /// </summary> 
        private double _Sumishdan;    // закрытая переменная класса 
        public double Sumishdan()
        {
            return _Sumishdan = _CO2 + _CO + _H2 + _CH4 + _C2H6 + _C3H8 + _C4H10 + _C5H12 + _H2S + _N2;
        }

        #endregion

        #region Промежуточные расчетные показатели (газообразное топливо)

        /// <summary>
        /// Рабочая масса H2O, %
        /// </summary> 
        //private double _H2Or;    // закрытая переменная класса 
        public double H2Or
        {
            get
            {
                return (0.1244 * _g) / (1 + 0.00124 * _g);
            }
        }

        /// <summary>
        /// Рабочая масса CO2, %
        /// </summary> 
        //private double _CO2r;    // закрытая переменная класса 
        public double CO2r
        {
            get
            {
                return _CO2 * (100 - H2Or) / 100;
            }
        }

        /// <summary>
        /// Рабочая масса CO2, %
        /// </summary> 
        //private double _COr;    // закрытая переменная класса 
        public double COr
        {
            get
            {
                return _CO * (100 - H2Or) / 100;
            }
        }


        /// <summary>
        /// Рабочая масса H2, %
        /// </summary> 
        //private double _H2r;    // закрытая переменная класса 
        public double H2r
        {
            get
            {
                return _H2 * (100 - H2Or) / 100;
            }
        }

        /// <summary>
        /// Рабочая масса CH4, %
        /// </summary> 
        //private double _CH4r;    // закрытая переменная класса 
        public double CH4r
        {
            get
            {
                return _CH4 * (100 - H2Or) / 100;
            }
        }

        /// <summary>
        /// Рабочая масса C2H6, %
        /// </summary> 
        //private double _C2H6r;    // закрытая переменная класса 
        public double C2H6r
        {
            get
            {
                return _C2H6 * (100 - H2Or) / 100;
            }
        }

        /// <summary>
        /// Рабочая масса C3H8, %
        /// </summary> 
        //private double _C3H8r;    // закрытая переменная класса 
        public double C3H8r
        {
            get
            {
                return _C3H8 * (100 - H2Or) / 100;
            }
        }
           

        /// <summary>
        /// Рабочая масса C4H10, %
        /// </summary> 
        //private double _C4H10r;    // закрытая переменная класса 
        public double C4H10r
        {
            get
            {
                return _C4H10 * (100 - H2Or) / 100;
            }
        }

        /// <summary>
        /// Рабочая масса C5H12, %
        /// </summary> 
        //private double _C5H12r;    // закрытая переменная класса 
        public double C5H12r
        {
            get
            {
                return _C5H12 * (100 - H2Or) / 100;
            }
        }

        /// <summary>
        /// Рабочая масса H2S, %
        /// </summary> 
        //private double _H2Sr;    // закрытая переменная класса 
        public double H2Sr
        {
            get
            {
                return _H2S * (100 - H2Or) / 100;
            }
        }

        /// <summary>
        /// Рабочая масса N2, %
        /// </summary> 
        //private double _N2r;    // закрытая переменная класса 
        public double N2r
        {
            get
            {
                return _N2 * (100 - H2Or) / 100;
            }
        }

        /// <summary>
        /// Сумма исходных данных (рабочая) %
        /// </summary> 
        //private double _Sumishdanrab;    // закрытая переменная класса 
        public double Sumishdanrab
        {
            get
            {
                return CO2r + COr + H2r + CH4r + C2H6r + C3H8r + C4H10r + C5H12r + H2Sr + N2r + H2Or;
            }
        }

        #endregion

        #region Расчетные показатели (газообразное топливо)

        /// <summary>
        /// Теоретический расход окислителя на горение L0, М3/М3
        /// </summary> 
        //private double _Lo;    // закрытая переменная класса 
        public double Lo
        {
            get
            {
                return (0.01 / 0.21) * (0.5 * COr + 0.5 * H2r + 1.5 * H2Sr + 2 * CH4r + 3.5 * C2H6r + 5 * C3H8r + 6.5 * C4H10r + 8 * C5H12r);
            }
        }

        /// <summary>
        /// Действительный расход окислителя на горение Lalfa, М3/М3
        /// </summary> 
        //private double _Lalfa;    // закрытая переменная класса 
        public double Lalfa
        {
            get
            {
                return Lo * _alfa;
            }
        }

        /// <summary>
        /// Количество CO2 в продуктах горения, м3/м3 _Vo_CO не считатется
        /// </summary> 
        //private double _Vo_CO2;    // закрытая переменная класса 
        public double Vo_CO2
        {
            get
            {
                return 0.01 * (CO2r + COr + CH4r + 2 * C2H6r + 3 * C3H8r + 4 * C4H10r + 5 * C5H12r) - Vo_CO;
            }
        }

        /// <summary>
        /// Количество SO2 в продуктах горения, м3/м3
        /// </summary> 
        //private double _Vo_SO2;    // закрытая переменная класса 
        public double Vo_SO2
        {
            get
            {
                return 0.01 * H2Sr;
            }
        }

        /// <summary>
        /// Количество H2O в продуктах горения, м3/м3
        /// </summary> 
        //private double _Vo_H2O;    // закрытая переменная класса 
        public double Vo_H2O
        {
            get
            {
                return 0.01 * (H2Or + H2r + H2Sr + 2 * CH4r + 3 * C2H6r + 4 * C3H8r + 5 * C4H10r + 6 * C5H12r) - Vo_H2;
            }
        }

        /// <summary>
        /// Количество N2 в продуктах горения, м3/м3
        /// </summary> 
        //private double _Vo_N2;    // закрытая переменная класса 
        public double Vo_N2
        {
            get
            {
                return 0.01 * N2r + 0.79 * Lo;
            }
        }

        /// <summary>
        /// Количество CO в продуктах горения, м3/м3
        /// </summary> 
        //private double _Vo_CO;    // закрытая переменная класса 
        public double Vo_CO
        {
            get
            {
                var Vo_CO12 = Math.Pow(2, 0.5);
                var Vo_CO2 = Math.Exp((17.628 * Temp_alfa - 58090) / (1.987 * Temp_alfa));
                var Vo_CO1 = Vo_CO12 * Vo_CO2;
               
                return Math.Pow(Vo_CO1, 0.6667);
            }
        }

        /// <summary>
        /// Количество H2 в продуктах горения, м3/м3
        /// </summary> 
        //private double _Vo_H2;    // закрытая переменная класса 
        public double Vo_H2
        {
            get
            {
                var Vo_H22 = Math.Pow(2, 0.5) * Math.Exp((-52300 + 12.081 * Temp_alfa) / (1.987 * Temp_alfa));
                
                return Math.Pow(Vo_H22, 0.6667); ;
            }
        }

        /// <summary>
        /// Количество O2 в продуктах горения, м3/м3
        /// </summary> 
        //private double _Vo_O2;    // закрытая переменная класса 
        public double Vo_O2
        {
            get
            {


                return 0.5 * Vo_CO + 0.5 * Vo_H2;
            }
        }

        /// <summary>
        /// Количество Vo в продуктах горения, м3/м3
        /// </summary> 
        //private double _Vo;    // закрытая переменная класса 
        public double Vo
        {
            get
            {


                return Vo_CO2 + Vo_SO2 + Vo_H2O + Vo_N2 + Vo_CO + Vo_H2 + Vo_O2;
            }
        }

        /// <summary>
        /// Практический выход N2 при избытке окислителя, м3/м3
        /// </summary> 
        //private double _V_alfa_N2;    // закрытая переменная класса 
        public double V_alfa_N2
        {
            get
            {
                return  0.01 * N2r + 0.79 * Lalfa;
            }
        }

        /// <summary>
        /// Количество избыточного кислорода в продуктах горения, м3/м3
        /// </summary> 
       // private double _V_O2_izb;    // закрытая переменная класса 
        public double V_O2_izb
        {
            get
            {
                return  0.21 * (_alfa - 1) * Lo + Vo_O2;
            }
        }

        /// <summary>
        /// Действительное количество продуктов горения, м3/м3
        /// </summary> 
        //private double _V_alfa;    // закрытая переменная класса 
        public double V_alfa
        {
            get
            {
                return Vo_CO2 + Vo_SO2 + Vo_H2O + Vo_CO + Vo_H2 + V_alfa_N2 + V_O2_izb;
            }
        }

        /// <summary>
        /// Содежание CO2 в продуктах горения alfa = 1, %
        /// </summary> 
        //private double _CO2alfa;    // закрытая переменная класса 
        public double CO2alfa
        {
            get
            {
                return Vo_CO2 / Vo * 100;
            }
        }

        /// <summary>
        /// Содежание CO2 в продуктах горения alfa > 1, %
        /// </summary> 
        //private double _CO2alfa2;    // закрытая переменная класса 
        public double CO2alfa2
        {
            get
            {
                return Vo_CO2 / V_alfa * 100;
            }
        }

        /// <summary>
        /// Содержание SO2 в продуктах горения alfa = 1, %
        /// </summary> 
       // private double _SO2alfa;    // закрытая переменная класса 
        public double SO2alfa
        {
            get
            {
                return Vo_SO2 / Vo * 100;
            }
        }

        /// <summary>
        /// Содержание SO2 в продуктах горения alfa > 1, %
        /// </summary> 
        //private double _SO2alfa2;    // закрытая переменная класса 
        public double SO2alfa2
        {
            get
            { 
                return Vo_SO2 / V_alfa * 100;
            }
        }

        /// <summary>
        /// Содержание H2O в продуктах горения alfa = 1, %
        /// </summary> 
        //private double _H2Oalfa;    // закрытая переменная класса 
        public double H2Oalfa
        {
            get
            {
                return Vo_H2O / Vo * 100;
            }
        }

        /// <summary>
        /// Содержание H2O в продуктах горения alfa > 1, %
        /// </summary> 
        //private double _H2Oalfa2;    // закрытая переменная класса 
        public double H2Oalfa2
        {
            get
            {
                return Vo_H2O / V_alfa * 100;
            }
        }

        /// <summary>
        /// Содержание N2 в продуктах горения alfa = 1, %
        /// </summary> 
        //private double _N2alfa;    // закрытая переменная класса 
        public double N2alfa
        {
            get
            {
                return Vo_N2 / Vo * 100;
            }
        }

        /// <summary>
        /// Содержание N2 в продуктах горения alfa > 1, %
        /// </summary> 
        //private double _N2alfa2;    // закрытая переменная класса 
        public double N2alfa2
        {
            get
            {
                return V_alfa_N2 / V_alfa * 100;
            }
        }

        /// <summary>
        /// Содержание CO в продуктах горения alfa = 1, %
        /// </summary> 
       // private double _COalfa;    // закрытая переменная класса 
        public double COalfa
        {
            get
            {
                return Vo_CO / Vo * 100;
            }
        }

        /// <summary>
        /// Содержание CO в продуктах горения alfa > 1, %
        /// </summary> 
       // private double _COalfa2;    // закрытая переменная класса 
        public double COalfa2
        {
            get
            {
                return Vo_CO / V_alfa * 100;
            }
        }

        /// <summary>
        /// Содержание H2 в продуктах горения alfa = 1, %
        /// </summary> 
       // private double _H2alfa;    // закрытая переменная класса 
        public double H2alfa
        {
            get
            {
                return Vo_H2 / Vo * 100;
            }
        }

        /// <summary>
        /// Содержание H2 в продуктах горения alfa > 1, %
        /// </summary> 
        //private double _H2alfa2;    // закрытая переменная класса 
        public double H2alfa2
        {
            get
            {
                return Vo_H2 / V_alfa * 100;
            }
        }

        /// <summary>
        /// Содержание O2 в продуктах горения alfa = 1, %
        /// </summary> 
        //private double _O2alfa;    // закрытая переменная класса 
        public double O2alfa
        {
            get
            {
                return Vo_O2 / Vo * 100;
            }
        }

        /// <summary>
        /// Содержание O2 в продуктах горения alfa > 1, %
        /// </summary> 
        //private double _O2alfa2;    // закрытая переменная класса 
        public double O2alfa2
        {
            get
            {
                return V_O2_izb / V_alfa * 100;
            }
        }

        /// <summary>
        /// Общая процентная сумма (100%) alfa = 1, %
        /// </summary> 
        //private double _Sumalfa;    // закрытая переменная класса 
        public double Sumalfa
        {
            get
            {
                return CO2alfa + SO2alfa + H2Oalfa + N2alfa + COalfa + H2alfa + O2alfa;
            }
        }

        /// <summary>
        /// Общая процентная сумма (100%) alfa > 1, %
        /// </summary> 
        //private double _Sumalfa2;    // закрытая переменная класса 
        public double Sumalfa2
        {
            get
            {
                return CO2alfa2 + SO2alfa2 + H2Oalfa2 + N2alfa2 + COalfa2 + H2alfa2 + O2alfa2;
            }
        }

        /// <summary>
        /// Теплота сгорания топлива, кДж/(М^3)
        /// </summary> 
        //private double _Qнр;    // закрытая переменная класса 
        public double Qнр
        {
            get
            {
                return 127.7 * COr + 108 * H2r + 358 * CH4r + 636 * C2H6r + 913 * C3H8r + 1185 * C4H10r + 1465 * C5H12r + 234 * H2Sr;
            }
        }

        /// <summary>
        /// Удельная теплоемкость газообразного топлива, кДж/(М^3 * Со)
        /// </summary> 
        //private double _Cтопл;    // закрытая переменная класса 
        public double Cтопл
        {
            get
            {
                return  0.01 * (CO2r * (0.0005 * _t_г + 1.6876) + _CO * (0.0001 * _t_г + 1.2851) + H2r * (0.00005 * _t_г + 1.2814) + CH4r * (0.0011 * _t_г + 1.5699) + C2H6r * (0.0022 * _t_г + 2.360) + C3H8r * (0.0032 * _t_г + 3.3462) + C4H10r * (0.004 * _t_г + 4.4928) + C5H12r * (0.0048 * _t_г + 5.5781) + H2Sr * (0.0004 * _t_г + 1.502) + N2r * (0.0001 * _t_г + 1.2796) + H2Or * (0.0002 * _t_г + 1.4756));
            }
        }

        /// <summary>
        /// Удельная теплоемкость воздуха, кДж/(М^3 * Со)
        /// </summary> 
        //private double _Cвозд;    // закрытая переменная класса 
        public double Cвозд
        {
            get
            {
                return 0.0001 * _t_в + 1.2857;
            }
        }

        /// <summary>
        /// Воздух в ПГ, %
        /// </summary> 
        //private double _ВоздВПГ;    // закрытая переменная класса 
        public double ВоздВПГ
        {
            get
            {
                return (Lalfa - Lo) * 100 / V_alfa;
            }
        }

        /// <summary>
        /// Химическая энтальпия топлива при alfa = 1, кДж/м^3
        /// </summary> 
        //private double _i_химalfa;    // закрытая переменная класса 
        public double i_химalfa
        {
            get
            {
                return Qнр / Vo;
            }
        }

        /// <summary>
        /// Химическая энтальпия топлива при alfa > 1, кДж/м^3
        /// </summary> 
        //private double _i_химalfa2;    // закрытая переменная класса 
        public double i_химalfa2
        {
            get
            {
                return Qнр / V_alfa;
            }
        }

        /// <summary>
        /// Физическая энтальпия подогрева топлива при alfa = 1, кДж/м^3
        /// </summary> 
        //private double _i_топлalfa;    // закрытая переменная класса 
        public double i_топлalfa
        {
            get
            {
                return Cтопл * _t_г / Vo;
            }
        }

        /// <summary>
        /// Физическая энтальпия подогрева топлива при alfa > 1, кДж/м^3
        /// </summary> 
        //private double _i_топлalfa2;    // закрытая переменная класса 
        public double i_топлalfa2
        {
            get
            {
                return Cтопл * _t_г / V_alfa;
            }
        }

        /// <summary>
        /// Физическая энтальпия подогрева воздуха  alfa = 1, кДж/м^3
        /// </summary> 
        //private double _i_воздalfa;    // закрытая переменная класса 
        public double i_воздalfa
        {
            get
            {
                return Cвозд * _t_в * Lo / Vo;
            }
        }

        /// <summary>
        /// Физическая энтальпия подогрева воздуха при alfa > 1, кДж/м^3
        /// </summary> 
        //private double _i_воздalfa2;    // закрытая переменная класса 
        public double i_воздalfa2
        {
            get
            {
                return Cвозд * _t_г * Lalfa / V_alfa;
            }
        }

        /// <summary>
        /// Общая (теоретическая) энтальпия продуктов горения alfa = 1, кДж/м^3
        /// </summary> 
        //private double _i_общ_т_alfa;    // закрытая переменная класса 
        public double i_общ_т_alfa
        {
            get
            {
                return i_химalfa + i_топлalfa + i_воздalfa;
            }  
        }

        /// <summary>
        /// Общая (теоретическая) энтальпия продуктов горения при alfa > 1, кДж/м^3
        /// </summary> 
        //private double _i_общ_т_alfa2;    // закрытая переменная класса 
        public double i_общ_т_alfa2
        {
            get
            {
                return i_химalfa2 + i_топлalfa2 + i_воздalfa2;
            }
        }

        /// <summary>
        /// Энтальпия химического недожога alfa = 1, кДж/м^3
        /// </summary> 
        //private double _i_з_alfa;    // закрытая переменная класса 
        public double i_з_alfa
        {
            get
            {
                return (Vo_CO * 12600 + Vo_H2 * 10800) / Vo;
            }
        }

        /// <summary>
        /// Энтальпия химического недожога alfa > 1, кДж/м^3
        /// </summary> 
        //private double _i_з_alfa2;    // закрытая переменная класса 
        public double i_з_alfa2
        {
            get
            {
                return (Vo_CO * 12600 + Vo_H2 * 10800) / V_alfa;
            }
        }

        /// <summary>
        /// Общая балансовая энтальпия продуктов горения alfa = 1, кДж/м^3
        /// </summary> 
        //private double _i_общ_б_alfa;    // закрытая переменная класса 
        public double i_общ_б_alfa
        {
            get
            {
                return  i_общ_т_alfa - i_з_alfa;
            }
        }

        /// <summary>
        /// Общая балансовая энтальпия продуктов горения при alfa > 1, кДж/м^3
        /// </summary> 
        //private double _i_общ_б_alfa2;    // закрытая переменная класса 
        public double i_общ_б_alfa2
        {
            get
            {
                return i_общ_т_alfa2 - i_з_alfa2;
            }
        }

        public void Temp_alfaCoreect()
        {
            var currentPogreshnost = pogreshnost;
            double pribavka = 0.1;

            for (int i = 0; (i < 10000 && Math.Abs(pogreshnost) > 0.1); i++)
            {
                Temp_alfa += pribavka;

                if (pogreshnost > currentPogreshnost & pogreshnost > 0 ) pribavka = -0.1;
                currentPogreshnost = pogreshnost;
            }

             var x = 0;
        }

        /// <summary>
        /// Теоретическая температура alfa = 1
        /// </summary> 
        public double Temp_alfa { get; set; } = 2153.51599842327;


        public double pogreshnost
        {
            get
            {
                var abs = Math.Abs(Temp_alfa - i_общ_т_alfa / ((CO2alfa * (0.0005 * Temp_alfa + 1.6876) + SO2alfa * (0.0004 * Temp_alfa + 1.8119) + H2Oalfa * (0.0002 * Temp_alfa + 1.4756) + N2alfa * (0.0001 * Temp_alfa + 1.2796) + COalfa * (0.0001 * Temp_alfa + 1.2851) + H2alfa * (0.00005 * Temp_alfa + 1.2814) + O2alfa * (0.0002 * Temp_alfa + 1.3094)) / 100));
                return abs;
            }
           
        }

        /// <summary>
        /// Теоретическая температура при alfa > 1
        /// </summary> 
        //private double _Temp_alfa2;    // закрытая переменная класса 
        public double Temp_alfa2 { get; set; } = 2026.520;


        /// <summary>
        /// Целевая функция(теор) (=0) alfa = 1
        /// </summary> 
        public void Temp_alfaCoreect2()
        {
            var currentPogreshnost = Cel_alfa2;
            double pribavka = 0.1;

            for (int i = 0; (i < 10000 && Math.Abs(Cel_alfa2) > 0.1); i++)
            {
                Temp_alfa2 += pribavka;

                if (Cel_alfa2 > currentPogreshnost & Cel_alfa2 > 0) pribavka = -0.1;
                currentPogreshnost = Cel_alfa2;
            }

            var x = 0;
        }


        /// <summary>
        /// Целевая функция(теор) (=0) при alfa > 1
        /// </summary> 
        // private double _Cel_alfa2;    // закрытая переменная класса 
        public double Cel_alfa2
        {
            get
            {
                return Temp_alfa2 - i_общ_т_alfa2 / ((CO2alfa2 * (0.0005 * Temp_alfa2 + 1.6876) + SO2alfa2 * (0.0004 * Temp_alfa2 + 1.8119) + H2Oalfa2 * (0.0002 * Temp_alfa2 + 1.4756) + N2alfa2 * (0.0001 * Temp_alfa2 + 1.2796) + COalfa2 * (0.0001 * Temp_alfa2 + 1.2851) + H2alfa2 * (0.00005 * Temp_alfa2 + 1.2814) + O2alfa2 * (0.0002 * Temp_alfa2 + 1.3094)) / 100);
            }
        }


        public void Tbalance_alfaCoreect()
        {
            var currentPogreshnost = Cel_balance_alfa;
            double pribavka = 0.1;

            for (int i = 0; (i < 10000 && Math.Abs(Cel_balance_alfa) > 0.1); i++)
            {
                Tbalance_alfa += pribavka;

                if (Cel_balance_alfa > currentPogreshnost & Cel_balance_alfa > 0) pribavka = -0.1;
                currentPogreshnost = Cel_balance_alfa;
            }

            var x = 0;
        }


        /// <summary>
        /// Балансовая температура alfa = 1
        /// </summary> 
        //private double _Tbalance_alfa;    // закрытая переменная класса 
        public double Tbalance_alfa { get; set; } = 2107.09643993952;



        /// <summary>
        /// Целевая функция(баланс) (=0) alfa = 1
        /// </summary> 
        //private double _Cel_balance_alfa;    // закрытая переменная класса 
        public double Cel_balance_alfa
        {
            get
            {
                return Tbalance_alfa - i_общ_б_alfa / ((CO2alfa * (0.0005 * Tbalance_alfa + 1.6876) + SO2alfa * (0.0004 * Tbalance_alfa + 1.8119) + H2Oalfa * (0.0002 * Tbalance_alfa + 1.4756) + N2alfa * (0.0001 * Tbalance_alfa + 1.2796) + COalfa * (0.0001 * Temp_alfa + 1.2851) + H2alfa * (0.00005 * Temp_alfa + 1.2814) + O2alfa * (0.0002 * Temp_alfa + 1.3094)) / 100);
            }
        }



        public void Tbalance_alfaCoreect2()
        {
            var currentPogreshnost = Cel_balance_alfa2;
            double pribavka = 0.1;

            for (int i = 0; (i < 10000 && Math.Abs(Cel_balance_alfa2) > 0.01); i++)
            {
                Tbalance_alfa2 += pribavka;

                if (Cel_balance_alfa2 > currentPogreshnost & Cel_balance_alfa2 > 0) pribavka = -0.01;
                currentPogreshnost = Cel_balance_alfa2;
            }

            var x = 0;
        }

        /// <summary>
        /// Балансовая температура при alfa > 1
        /// </summary> 
        //private double _Tbalance_alfa2;    // закрытая переменная класса 
        public double Tbalance_alfa2 { get; set; } = 1982.55448400305;


        /// <summary>
        /// Целевая функция(баланс) (=0) при alfa > 1
        /// </summary> 
        //private double _Cel_balance_alfa2;    // закрытая переменная класса 
        public double Cel_balance_alfa2
        {
            get
            {
                return Tbalance_alfa2 - i_общ_б_alfa2 / ((CO2alfa2 * (0.0005 * Tbalance_alfa2 + 1.6876) + SO2alfa2 * (0.0004 * Tbalance_alfa2 + 1.8119) + H2Oalfa2 * (0.0002 * Tbalance_alfa2 + 1.4756) + N2alfa2 * (0.0001 * Tbalance_alfa2 + 1.2796) + COalfa2 * (0.0001 * Temp_alfa2 + 1.2851) + H2alfa2 * (0.00005 * Temp_alfa2 + 1.2814) + O2alfa2 * (0.0002 * Temp_alfa2 + 1.3094)) / 100);
            }
        }

        #endregion

    
    }
}