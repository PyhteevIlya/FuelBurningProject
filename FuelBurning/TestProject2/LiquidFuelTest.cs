global using NUnit.Framework;
using MathLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace TestProjectDemo
{
    internal class LiquidFuelTest
    {
        private string fileName = "ForTest.xls";
        Excel.Application objExcel = null;
        Excel.Workbook WorkBook = null;

        private object oMissing = System.Reflection.Missing.Value;

        /// <summary>
        /// Метод тестирования математической библиотеки
        /// </summary>
        [Test]
        public void CalculationTest()
        {
            LiquidFuel _ml = new LiquidFuel();

            #region 1. Присвоить исходные данные 

            _ml.C = 85.10;
            _ml.H = 9.90;
            _ml.S = 0.0;
            _ml.N = 0.2;
            _ml.O = 0.2;
            _ml.Wp = 3.9;
            _ml.Ap = 0.1;
            _ml.T_v = 280.0;
            _ml.T_t = 98.0;
            _ml.alfaG = 1.25;
            _ml.M_недожог = 4.0;
            _ml.gg = 13.0;

            #endregion 1. Присвоить исходные данные

            try
            {
                #region 2. Передать исходные данные в Excel-файл, записать в соответствующие ячейки
                objExcel = new Excel.Application();
                WorkBook = objExcel.Workbooks.Open(
                            Directory.GetCurrentDirectory() + "\\" + fileName);
                Excel.Worksheet WorkSheet = (Excel.Worksheet)WorkBook.Sheets["Твердое (жидкое) топливо"];

                // Cells[СТРОКА,СТОЛБЕЦ]
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[8, 2]).Value2 = _ml.C;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[9, 2]).Value2 = _ml.H;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[10, 2]).Value2 = _ml.S;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[11, 2]).Value2 = _ml.N;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[12, 2]).Value2 = _ml.O;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[13, 2]).Value2 = _ml.Wp;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[14, 2]).Value2 = _ml.Ap;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[16, 2]).Value2 = _ml.T_v;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[17, 2]).Value2 = _ml.T_t;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[18, 2]).Value2 = _ml.alfaG;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[19, 2]).Value2 = _ml.M_недожог;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[20, 2]).Value2 = _ml.gg;

                // отобразить в журнале тестирования
                Console.WriteLine("--- Исходные данные");
                Console.WriteLine("Число 1: {0}", _ml.C.ToString());
                Console.WriteLine("Число 2: {0}", _ml.H.ToString());
                Console.WriteLine("Число 3: {0}", _ml.S.ToString());
                Console.WriteLine("Число 4: {0}", _ml.N.ToString());
                Console.WriteLine("Число 5: {0}", _ml.O.ToString());
                Console.WriteLine("Число 6: {0}", _ml.Wp.ToString());
                Console.WriteLine("Число 7: {0}", _ml.Ap.ToString());
                Console.WriteLine("Число 8: {0}", _ml.T_v.ToString());
                Console.WriteLine("Число 9: {0}", _ml.T_t.ToString());
                Console.WriteLine("Число 10: {0}", _ml.alfaG.ToString());
                Console.WriteLine("Число 11: {0}", _ml.M_недожог.ToString());
                Console.WriteLine("Число 12: {0}", _ml.gg.ToString());

                #endregion 2. Передать исходные данные в Excel-файл, записать в соответствующие ячейки

                #region 3. Прочитать из ячейки Excel-файла значение расчетных величин

                //ТАБЛИЦА 1

                double V_O2_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[6, 6]).Value.ToString());
                double Lo_св = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[7, 6]).Value.ToString());
                double Lo_вв = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[8, 6]).Value.ToString());
                double L_alfa_вв = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[9, 6]).Value.ToString());

                //ТАБЛИЦА 2

                double Vo_CO2_alfa1_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[12, 6]).Value.ToString());
                double Vo_SO2_alfa1_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[13, 6]).Value.ToString());
                double Vo_H2O_alfa1_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[14, 6]).Value.ToString());
                double Vo_N2_alfa1_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[15, 6]).Value.ToString());
                double Vo_CO_alfa1_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[16, 6]).Value.ToString());
                double Vo_H2_alfa1_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[17, 6]).Value.ToString());
                double Vo_O2_alfa1_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[18, 6]).Value.ToString());
                double Vo_alfa1_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[19, 6]).Value.ToString());

                double Vo_CO2_alfa2_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[12, 8]).Value.ToString());
                double Vo_SO2_alfa2_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[13, 8]).Value.ToString());
                double Vo_H2O_alfa2_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[14, 8]).Value.ToString());
                double Vo_N2_alfa2_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[15, 8]).Value.ToString());
                double Vo_CO_alfa2_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[16, 8]).Value.ToString());
                double Vo_H2_alfa2_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[17, 8]).Value.ToString());
                double Vo_O2_alfa2_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[18, 8]).Value.ToString());
                double V_O2_izd_alfa2_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[19, 8]).Value.ToString());
                double V_alfa_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[19, 8]).Value.ToString());

                //ТАБЛИЦА 3

                double CO2_alfa1_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[7, 10]).Value.ToString());
                double SO2_alfa1_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[8, 10]).Value.ToString());
                double H2O_alfa1_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[9, 10]).Value.ToString());
                double N2_alfa1_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[10, 10]).Value.ToString());
                double CO_alfa1_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[11, 10]).Value.ToString());
                double H2_alfa1_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[12, 10]).Value.ToString());
                double O2_alfa1_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[13, 10]).Value.ToString());
                double Sum_alfa1_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[14, 10]).Value.ToString());

                double CO2_alfa2_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[7, 11]).Value.ToString());
                double SO2_alfa2_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[8, 11]).Value.ToString());
                double H2O_alfa2_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[9, 11]).Value.ToString());
                double N2_alfa2_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[10, 11]).Value.ToString());
                double CO_alfa2_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[11, 11]).Value.ToString());
                double H2_alfa2_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[12, 11]).Value.ToString());
                double O2_alfa2_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[13, 11]).Value.ToString());
                double Sum_alfa2_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[14, 11]).Value.ToString());

                double Q_нр_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[22, 6]).Value.ToString());

                //ТАБЛИЦА 4

                double c_топл_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[16, 10]).Value.ToString());
                double c_возд_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[17, 10]).Value.ToString());
                double PG_возд_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[18, 10]).Value.ToString());

                //ТАБЛИЦА 5 

                double iхим_alfa1_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[25, 6]).Value.ToString());
                double iтопл_alfa1_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[26, 6]).Value.ToString());
                double iвозд_alfa1_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[27, 6]).Value.ToString());
                double iобщ_т_alfa1_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[28, 6]).Value.ToString());
                double i_3_i_4_alfa1_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[29, 6]).Value.ToString());
                double i_общ_б_alfa1_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[30, 6]).Value.ToString());

                double iхим_alfa2_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[25, 7]).Value.ToString());
                double iтопл_alfa2_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[26, 7]).Value.ToString());
                double iвозд_alfa2_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[27, 7]).Value.ToString());
                double iобщ_т_alfa2_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[28, 7]).Value.ToString());
                double i_3_i_4_alfa2_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[29, 7]).Value.ToString());
                double i_общ_б_alfa2_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[30, 7]).Value.ToString());

                //ТАБЛИЦА 6

                double Temp_alfa_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[24, 11]).Value.ToString());
                double Cel_alfa_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[25, 11]).Value.ToString());
                double Tbalance_alfa_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[26, 11]).Value.ToString());
                double Cel_balance_alfa_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[27, 11]).Value.ToString());

                double Temp_alfa2_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[24, 12]).Value.ToString());
                double Cel_alfa2_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[25, 12]).Value.ToString());
                double Tbalance_alfa2_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[26, 12]).Value.ToString());
                double Cel_balance_alfa2_g = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое (жидкое) топливо"].Cells[27, 12]).Value.ToString());


                #endregion 3. Прочитать из ячейки Excel-файла значение расчетных величин

                #region  4. Сравнить значения из Excel и из библиотеки с заданной точностью


                //ТАБЛИЦА 1

                //Assert.AreEqual(V_O2_g, Math.Round(_ml.V_O2_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("V_O2_g: expected =" +
                //            V_O2_g + "; actual=" + Math.Round(_ml.V_O2_g(), 3));

                //Assert.AreEqual(Lo_св, Math.Round(_ml.Lo_св(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("Lo_св: expected =" +
                //            Lo_св + "; actual=" + Math.Round(_ml.Lo_св(), 3));

                //Assert.AreEqual(Lo_вв, Math.Round(_ml.Lo_вв(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("Rco: expected =" +
                //            Lo_вв + "; actual=" + Math.Round(_ml.Lo_вв(), 3));

                //Assert.AreEqual(L_alfa_вв, Math.Round(_ml.L_alfa_вв(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("L_alfa_вв: expected =" +
                //            L_alfa_вв + "; actual=" + Math.Round(_ml.L_alfa_вв(), 3));

                ////ТАБЛИЦА 2

                //Assert.AreEqual(Vo_CO2_alfa1_g, Math.Round(_ml.Vo_CO2_alfa1_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("Vo_CO2_alfa1_g: expected =" +
                //            Vo_CO2_alfa1_g + "; actual=" + Math.Round(_ml.Vo_CO2_alfa1_g(), 3));

                //Assert.AreEqual(Vo_SO2_alfa1_g, Math.Round(_ml.Vo_SO2_alfa1_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("Vo_SO2_alfa1_g: expected =" +
                //            Vo_SO2_alfa1_g + "; actual=" + Math.Round(_ml.Vo_SO2_alfa1_g(), 3));

                //Assert.AreEqual(Vo_H2O_alfa1_g, Math.Round(_ml.Vo_H2O_alfa1_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("Vo_H2O_alfa1_g: expected =" +
                //            Vo_H2O_alfa1_g + "; actual=" + Math.Round(_ml.Vo_H2O_alfa1_g(), 3));

                //Assert.AreEqual(Vo_N2_alfa1_g, Math.Round(_ml.Vo_N2_alfa1_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("Vo_N2_alfa1_g: expected =" +
                //            Vo_N2_alfa1_g + "; actual=" + Math.Round(_ml.Vo_N2_alfa1_g(), 3));

                //Assert.AreEqual(Vo_CO_alfa1_g, Math.Round(_ml.Vo_CO_alfa1_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("Vo_CO_alfa1_g: expected =" +
                //            Vo_CO_alfa1_g + "; actual=" + Math.Round(_ml.Vo_CO_alfa1_g(), 3));

                //Assert.AreEqual(H2_alfa1_g, Math.Round(_ml.H2_alfa1_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("H2_alfa1_g: expected =" +
                //            H2_alfa1_g + "; actual=" + Math.Round(_ml.H2_alfa1_g(), 3));

                //Assert.AreEqual(O2_alfa1_g, Math.Round(_ml.O2_alfa1_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("O2_alfa1_g: expected =" +
                //            O2_alfa1_g + "; actual=" + Math.Round(_ml.O2_alfa1_g(), 3));

                //Assert.AreEqual(Vo_alfa1_g, Math.Round(_ml.Vo_alfa1_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("Vo_alfa1_g: expected =" +
                //            Vo_alfa1_g + "; actual=" + Math.Round(_ml.Vo_alfa1_g(), 3));



                //Assert.AreEqual(Vo_CO2_alfa2_g, Math.Round(_ml.Vo_CO2_alfa2_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("Vo_CO2_alfa2_g: expected =" +
                //            Vo_CO2_alfa2_g + "; actual=" + Math.Round(_ml.Vo_CO2_alfa2_g(), 3));

                //Assert.AreEqual(Vo_SO2_alfa2_g, Math.Round(_ml.Vo_SO2_alfa2_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("Vo_SO2_alfa2_g: expected =" +
                //            Vo_SO2_alfa2_g + "; actual=" + Math.Round(_ml.Vo_SO2_alfa2_g(), 3));

                //Assert.AreEqual(Vo_H2O_alfa2_g, Math.Round(_ml.Vo_H2O_alfa2_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("Vo_H2O_alfa2_g: expected =" +
                //            Vo_H2O_alfa2_g + "; actual=" + Math.Round(_ml.Vo_H2O_alfa2_g(), 3));

                //Assert.AreEqual(Vo_N2_alfa2_g, Math.Round(_ml.Vo_N2_alfa2_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("Vo_N2_alfa2_g: expected =" +
                //            Vo_N2_alfa2_g + "; actual=" + Math.Round(_ml.Vo_N2_alfa2_g(), 3));

                //Assert.AreEqual(Vo_CO_alfa2_g, Math.Round(_ml.Vo_CO_alfa2_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("Vo_CO_alfa2_g: expected =" +
                //            Vo_CO_alfa2_g + "; actual=" + Math.Round(_ml.Vo_CO_alfa2_g(), 3));

                //Assert.AreEqual(H2_alfa2_g, Math.Round(_ml.H2_alfa2_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("H2_alfa2_g: expected =" +
                //            H2_alfa2_g + "; actual=" + Math.Round(_ml.H2_alfa2_g(), 3));

                //Assert.AreEqual(V_O2_izd_alfa2_g, Math.Round(_ml.V_O2_izd_alfa2_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("V_O2_izd_alfa2_g: expected =" +
                //            V_O2_izd_alfa2_g + "; actual=" + Math.Round(_ml.V_O2_izd_alfa2_g(), 3));

                //Assert.AreEqual(V_alfa_g, Math.Round(_ml.V_alfa_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("V_alfa_g: expected =" +
                //            V_alfa_g + "; actual=" + Math.Round(_ml.V_alfa_g(), 3));


                ////ТАБЛИЦА 3

                //Assert.AreEqual(CO2_alfa1_g, Math.Round(_ml.CO2_alfa1_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("CO2_alfa1_g: expected =" +
                //            CO2_alfa1_g + "; actual=" + Math.Round(_ml.CO2_alfa1_g(), 3));

                //Assert.AreEqual(SO2_alfa1_g, Math.Round(_ml.SO2_alfa1_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("SO2_alfa1_g: expected =" +
                //            SO2_alfa1_g + "; actual=" + Math.Round(_ml.SO2_alfa1_g(), 3));

                //Assert.AreEqual(H2O_alfa1_g, Math.Round(_ml.H2O_alfa1_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("H2O_alfa1_g: expected =" +
                //            H2O_alfa1_g + "; actual=" + Math.Round(_ml.H2O_alfa1_g(), 3));

                //Assert.AreEqual(N2_alfa1_g, Math.Round(_ml.N2_alfa1_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("N2_alfa1_g: expected =" +
                //            N2_alfa1_g + "; actual=" + Math.Round(_ml.N2_alfa1_g(), 3));

                //Assert.AreEqual(CO_alfa1_g, Math.Round(_ml.CO_alfa1_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("CO_alfa1_g: expected =" +
                //            CO_alfa1_g + "; actual=" + Math.Round(_ml.CO_alfa1_g(), 3));

                //Assert.AreEqual(H2_alfa1_g, Math.Round(_ml.H2_alfa1_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("H2_alfa1_g: expected =" +
                //            H2_alfa1_g + "; actual=" + Math.Round(_ml.H2_alfa1_g(), 3));

                //Assert.AreEqual(O2_alfa1_g, Math.Round(_ml.O2_alfa1_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("O2alfa: expected =" +
                //            O2_alfa1_g + "; actual=" + Math.Round(_ml.O2_alfa1_g(), 3));

                //Assert.AreEqual(Sum_alfa1_g, Math.Round(_ml.Sum_alfa1_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("Sum_alfa1_g: expected =" +
                //            Sum_alfa1_g + "; actual=" + Math.Round(_ml.Sum_alfa1_g(), 3));


                //Assert.AreEqual(CO2_alfa2_g, Math.Round(_ml.CO2_alfa2_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("CO2_alfa2_g: expected =" +
                //            CO2_alfa2_g + "; actual=" + Math.Round(_ml.CO2_alfa2_g(), 3));

                //Assert.AreEqual(SO2_alfa2_g, Math.Round(_ml.SO2_alfa2_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("SO2_alfa2_g: expected =" +
                //            SO2_alfa2_g + "; actual=" + Math.Round(_ml.SO2_alfa2_g(), 3));

                //Assert.AreEqual(H2O_alfa2_g, Math.Round(_ml.H2O_alfa2_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("H2O_alfa2_g: expected =" +
                //            H2O_alfa2_g + "; actual=" + Math.Round(_ml.H2O_alfa2_g(), 3));

                //Assert.AreEqual(N2_alfa2_g, Math.Round(_ml.N2_alfa2_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("N2_alfa2_g: expected =" +
                //            N2_alfa2_g + "; actual=" + Math.Round(_ml.N2_alfa2_g(), 3));

                //Assert.AreEqual(CO_alfa2_g, Math.Round(_ml.CO_alfa2_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("CO_alfa2_g: expected =" +
                //            CO_alfa2_g + "; actual=" + Math.Round(_ml.CO_alfa2_g(), 3));

                //Assert.AreEqual(H2_alfa2_g, Math.Round(_ml.H2_alfa2_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("H2_alfa2_g: expected =" +
                //            H2_alfa2_g + "; actual=" + Math.Round(_ml.H2_alfa2_g(), 3));

                //Assert.AreEqual(O2_alfa2_g, Math.Round(_ml.O2_alfa2_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("O2_alfa2_g: expected =" +
                //            O2_alfa2_g + "; actual=" + Math.Round(_ml.O2_alfa2_g(), 3));

                //Assert.AreEqual(Sum_alfa2_g, Math.Round(_ml.Sum_alfa2_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("Sum_alfa2_g: expected =" +
                //            Sum_alfa2_g + "; actual=" + Math.Round(_ml.Sum_alfa2_g(), 3));


                //Assert.AreEqual(Q_нр_g, Math.Round(_ml.Q_нр_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("Q_нр_g: expected =" +
                //            Q_нр_g + "; actual=" + Math.Round(_ml.Q_нр_g(), 3));

                ////ТАБЛИЦА 4

                //Assert.AreEqual(c_топл_g, Math.Round(_ml.c_топл_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("c_топл_g: expected =" +
                //            c_топл_g + "; actual=" + Math.Round(_ml.c_топл_g(), 3));

                //Assert.AreEqual(c_возд_g, Math.Round(_ml.c_возд_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("c_возд_g: expected =" +
                //            c_возд_g + "; actual=" + Math.Round(_ml.c_возд_g(), 3));

                //Assert.AreEqual(PG_возд_g, Math.Round(_ml.PG_возд_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("PG_возд_g: expected =" +
                //            PG_возд_g + "; actual=" + Math.Round(_ml.PG_возд_g(), 3));

                ////ТАБЛИЦА 5

                //Assert.AreEqual(iхим_alfa1_g, Math.Round(_ml.iхим_alfa1_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("iхим_alfa1_g: expected =" +
                //            iхим_alfa1_g + "; actual=" + Math.Round(_ml.iхим_alfa1_g(), 3));

                //Assert.AreEqual(iтопл_alfa1_g, Math.Round(_ml.iтопл_alfa1_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("iтопл_alfa1_g: expected =" +
                //            iтопл_alfa1_g + "; actual=" + Math.Round(_ml.iтопл_alfa1_g(), 3));

                //Assert.AreEqual(iвозд_alfa1_g, Math.Round(_ml.iвозд_alfa1_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("iвозд_alfa1_g: expected =" +
                //           iвозд_alfa1_g + "; actual=" + Math.Round(_ml.iвозд_alfa1_g(), 3));

                //Assert.AreEqual(iобщ_т_alfa1_g, Math.Round(_ml.iобщ_т_alfa1_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("iобщ_т_alfa1_g: expected =" +
                //            iобщ_т_alfa1_g + "; actual=" + Math.Round(_ml.iобщ_т_alfa1_g(), 3));

                //Assert.AreEqual(i_3_i_4_alfa1_g, Math.Round(_ml.i_3_i_4_alfa1_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("i_3_i_4_alfa1_g: expected =" +
                //            i_3_i_4_alfa1_g + "; actual=" + Math.Round(_ml.i_3_i_4_alfa1_g(), 3));

                //Assert.AreEqual(i_общ_б_alfa1_g, Math.Round(_ml.i_общ_б_alfa1_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("i_общ_б_alfa1_g: expected =" +
                //            i_общ_б_alfa1_g + "; actual=" + Math.Round(_ml.i_общ_б_alfa1_g(), 3));


                //Assert.AreEqual(iхим_alfa2_g, Math.Round(_ml.iхим_alfa2_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("iхим_alfa2_g: expected =" +
                //            iхим_alfa2_g + "; actual=" + Math.Round(_ml.iхим_alfa2_g(), 3));

                //Assert.AreEqual(iтопл_alfa2_g, Math.Round(_ml.iтопл_alfa2_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("iтопл_alfa2_g: expected =" +
                //            iтопл_alfa2_g + "; actual=" + Math.Round(_ml.iтопл_alfa2_g(), 3));

                //Assert.AreEqual(iвозд_alfa2_g, Math.Round(_ml.iвозд_alfa2_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("iвозд_alfa2_g: expected =" +
                //           iвозд_alfa2_g + "; actual=" + Math.Round(_ml.iвозд_alfa2_g(), 3));

                //Assert.AreEqual(iобщ_т_alfa2_g, Math.Round(_ml.iобщ_т_alfa2_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("iобщ_т_alfa2_g: expected =" +
                //            iобщ_т_alfa2_g + "; actual=" + Math.Round(_ml.iобщ_т_alfa2_g(), 3));

                //Assert.AreEqual(i_3_i_4_alfa2_g, Math.Round(_ml.i_3_i_4_alfa2_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("i_3_i_4_alfa2_g: expected =" +
                //            i_3_i_4_alfa2_g + "; actual=" + Math.Round(_ml.i_3_i_4_alfa2_g(), 3));

                //Assert.AreEqual(i_общ_б_alfa2_g, Math.Round(_ml.i_общ_б_alfa2_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("i_общ_б_alfa2_g: expected =" +
                //            i_общ_б_alfa2_g + "; actual=" + Math.Round(_ml.i_общ_б_alfa2_g(), 3));


                ////ТАБЛИЦА 6

                //Assert.AreEqual(Temp_alfa_g, Math.Round(_ml.Temp_alfa_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("Temp_alfa_g: expected =" +
                //            Temp_alfa_g + "; actual=" + Math.Round(_ml.Temp_alfa_g(), 3));

                //Assert.AreEqual(Cel_alfa_g, Math.Round(_ml.Cel_alfa_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("Cel_alfa_g: expected =" +
                //            Cel_alfa_g + "; actual=" + Math.Round(_ml.Cel_alfa_g(), 3));

                //Assert.AreEqual(Tbalance_alfa_g, Math.Round(_ml.Tbalance_alfa_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("Tbalance_alfa_g: expected =" +
                //            Tbalance_alfa_g + "; actual=" + Math.Round(_ml.Tbalance_alfa_g(), 3));

                //Assert.AreEqual(Cel_balance_alfa_g, Math.Round(_ml.Cel_balance_alfa_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("Cel_balance_alfa_g: expected =" +
                //            Cel_balance_alfa_g + "; actual=" + Math.Round(_ml.Cel_balance_alfa_g(), 3));


                //Assert.AreEqual(Temp_alfa2_g, Math.Round(_ml.Temp_alfa2_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("Temp_alfa2_g: expected =" +
                //            Temp_alfa2_g + "; actual=" + Math.Round(_ml.Temp_alfa2_g(), 3));

                //Assert.AreEqual(Cel_alfa2_g, Math.Round(_ml.Cel_alfa2_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("Cel_alfa2_g: expected =" +
                //            Cel_alfa2_g + "; actual=" + Math.Round(_ml.Cel_alfa2_g(), 3));

                //Assert.AreEqual(Tbalance_alfa2_g, Math.Round(_ml.Tbalance_alfa2_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("Tbalance_alfa2_g: expected =" +
                //            Tbalance_alfa2_g + "; actual=" + Math.Round(_ml.Tbalance_alfa2_g(), 3));

                //Assert.AreEqual(Cel_balance_alfa2_g, Math.Round(_ml.Cel_balance_alfa2_g(), 3), 0.001);
                //System.Diagnostics.Debug.WriteLine("Cel_balance_alfa2_g: expected =" +
                //            Cel_balance_alfa2_g + "; actual=" + Math.Round(_ml.Cel_balance_alfa2_g(), 3));

                //// отобразить в журнале тестирования
                //Console.WriteLine("");
                //Console.WriteLine("--- Результаты расчета");


                ////ТАБЛИЦА 1

                //Console.WriteLine("V_O2_g: expected = " +
                //         V_O2_g + "; actual=" + Math.Round(_ml.V_O2_g(), 3));

                //Console.WriteLine("Lo_св: expected = " +
                //         Lo_св + "; actual=" + Math.Round(_ml.Lo_св(), 3));

                //Console.WriteLine("Lo_вв: expected = " +
                //        Lo_вв + "; actual=" + Math.Round(_ml.Lo_вв(), 3));

                //Console.WriteLine("L_alfa_вв: expected = " +
                //        L_alfa_вв + "; actual=" + Math.Round(_ml.L_alfa_вв(), 3));

                ////ТАБЛИЦА 2

                //Console.WriteLine("Vo_CO2_alfa1_g: expected = " +
                //         Vo_CO2_alfa1_g + "; actual=" + Math.Round(_ml.Vo_CO2_alfa1_g(), 3));

                //Console.WriteLine("Vo_SO2_alfa1_g: expected = " +
                //         Vo_SO2_alfa1_g + "; actual=" + Math.Round(_ml.Vo_SO2_alfa1_g(), 3));

                //Console.WriteLine("Vo_H2O_alfa1_g: expected = " +
                //         Vo_H2O_alfa1_g + "; actual=" + Math.Round(_ml.Vo_H2O_alfa1_g(), 3));

                //Console.WriteLine("Vo_N2_alfa1_g: expected = " +
                //         Vo_N2_alfa1_g + "; actual=" + Math.Round(_ml.Vo_N2_alfa1_g(), 3));

                //Console.WriteLine("Vo_CO_alfa1_g: expected = " +
                //         Vo_CO_alfa1_g + "; actual=" + Math.Round(_ml.Vo_CO_alfa1_g(), 3));

                //Console.WriteLine("Vo_H2_alfa1_g: expected = " +
                //         Vo_H2_alfa1_g + "; actual=" + Math.Round(_ml.Vo_H2_alfa1_g(), 3));

                //Console.WriteLine("Vo_O2_alfa1_g: expected = " +
                //         Vo_O2_alfa1_g + "; actual=" + Math.Round(_ml.Vo_O2_alfa1_g(), 3));

                //Console.WriteLine("Vo_alfa1_g: expected = " +
                //         Vo_alfa1_g + "; actual=" + Math.Round(_ml.Vo_alfa1_g(), 3));


                //Console.WriteLine("Vo_CO2_alfa2_g: expected = " +
                //         Vo_CO2_alfa2_g + "; actual=" + Math.Round(_ml.Vo_CO2_alfa2_g(), 3));

                //Console.WriteLine("Vo_SO2_alfa2_g: expected = " +
                //         Vo_SO2_alfa2_g + "; actual=" + Math.Round(_ml.Vo_SO2_alfa2_g(), 3));

                //Console.WriteLine("Vo_H2O_alfa2_g: expected = " +
                //         Vo_H2O_alfa2_g + "; actual=" + Math.Round(_ml.Vo_H2O_alfa2_g(), 3));

                //Console.WriteLine("Vo_N2_alfa2_g: expected = " +
                //         Vo_N2_alfa2_g + "; actual=" + Math.Round(_ml.Vo_N2_alfa2_g(), 3));

                //Console.WriteLine("Vo_CO_alfa2_g: expected = " +
                //         Vo_CO_alfa2_g + "; actual=" + Math.Round(_ml.Vo_CO_alfa2_g(), 3));

                //Console.WriteLine("Vo_H2_alfa2_g: expected = " +
                //         Vo_H2_alfa2_g + "; actual=" + Math.Round(_ml.Vo_H2_alfa2_g(), 3));

                //Console.WriteLine("Vo_O2_alfa2_g: expected = " +
                //         Vo_O2_alfa2_g + "; actual=" + Math.Round(_ml.Vo_O2_alfa2_g(), 3));

                //Console.WriteLine("V_O2_izd_alfa2_g: expected = " +
                //         V_O2_izd_alfa2_g + "; actual=" + Math.Round(_ml.V_O2_izd_alfa2_g(), 3));


                //Console.WriteLine("V_alfa_g: expected = " +
                //         V_alfa_g + "; actual=" + Math.Round(_ml.V_alfa_g(), 3));

                ////ТАБЛИЦА 3

                //Console.WriteLine("CO2_alfa1_g: expected = " +
                //         CO2_alfa1_g + "; actual=" + Math.Round(_ml.CO2_alfa1_g(), 3));

                //Console.WriteLine("SO2_alfa1_g: expected = " +
                //         SO2_alfa1_g + "; actual=" + Math.Round(_ml.SO2_alfa1_g(), 3));

                //Console.WriteLine("H2O_alfa1_g: expected = " +
                //         H2O_alfa1_g + "; actual=" + Math.Round(_ml.H2O_alfa1_g(), 3));

                //Console.WriteLine("N2_alfa1_g: expected = " +
                //         N2_alfa1_g + "; actual=" + Math.Round(_ml.N2_alfa1_g(), 3));

                //Console.WriteLine("CO_alfa1_g: expected = " +
                //         CO_alfa1_g + "; actual=" + Math.Round(_ml.CO_alfa1_g(), 3));

                //Console.WriteLine("H2_alfa1_g: expected = " +
                //         H2_alfa1_g + "; actual=" + Math.Round(_ml.H2_alfa1_g(), 3));

                //Console.WriteLine("O2_alfa1_g: expected = " +
                //         O2_alfa1_g + "; actual=" + Math.Round(_ml.O2_alfa1_g(), 3));

                //Console.WriteLine("Sum_alfa1_g: expected = " +
                //         Sum_alfa1_g + "; actual=" + Math.Round(_ml.Sum_alfa1_g(), 3));


                //Console.WriteLine("CO2_alfa2_g: expected = " +
                //         CO2_alfa2_g + "; actual=" + Math.Round(_ml.CO2_alfa2_g(), 3));

                //Console.WriteLine("SO2_alfa2_g: expected = " +
                //         SO2_alfa2_g + "; actual=" + Math.Round(_ml.SO2_alfa2_g(), 3));

                //Console.WriteLine("H2O_alfa2_g: expected = " +
                //         H2O_alfa2_g + "; actual=" + Math.Round(_ml.H2O_alfa2_g(), 3));

                //Console.WriteLine("N2_alfa2_g: expected = " +
                //         N2_alfa2_g + "; actual=" + Math.Round(_ml.N2_alfa2_g(), 3));

                //Console.WriteLine("CO_alfa2_g: expected = " +
                //         CO_alfa2_g + "; actual=" + Math.Round(_ml.CO_alfa2_g(), 3));

                //Console.WriteLine("H2_alfa2_g: expected = " +
                //         H2_alfa2_g + "; actual=" + Math.Round(_ml.H2_alfa2_g(), 3));

                //Console.WriteLine("O2_alfa2_g: expected = " +
                //         O2_alfa2_g + "; actual=" + Math.Round(_ml.O2_alfa2_g(), 3));

                //Console.WriteLine("Sum_alfa2_g: expected = " +
                //         Sum_alfa2_g + "; actual=" + Math.Round(_ml.Sum_alfa2_g(), 3));


                //Console.WriteLine("Q_нр_g: expected = " +
                //       Q_нр_g + "; actual=" + Math.Round(_ml.Q_нр_g(), 3));


                ////ТАБЛИЦА 4

                //Console.WriteLine("c_топл_g: expected = " +
                //      c_топл_g + "; actual=" + Math.Round(_ml.c_топл_g(), 3));

                //Console.WriteLine("c_возд_g: expected = " +
                //      c_возд_g + "; actual=" + Math.Round(_ml.c_возд_g(), 3));

                //Console.WriteLine("PG_возд_g: expected = " +
                //      PG_возд_g + "; actual=" + Math.Round(_ml.PG_возд_g(), 3));

                ////ТАБЛИЦА 5

                //Console.WriteLine("iхим_alfa1_g: expected = " +
                //      iхим_alfa1_g + "; actual=" + Math.Round(_ml.iхим_alfa1_g(), 3));

                //Console.WriteLine("iтопл_alfa1_g: expected = " +
                //      iтопл_alfa1_g + "; actual=" + Math.Round(_ml.iтопл_alfa1_g(), 3));

                //Console.WriteLine("iвозд_alfa1_g: expected = " +
                //      iвозд_alfa1_g + "; actual=" + Math.Round(_ml.iвозд_alfa1_g(), 3));

                //Console.WriteLine("iобщ_т_alfa1_g: expected = " +
                //      iобщ_т_alfa1_g + "; actual=" + Math.Round(_ml.iобщ_т_alfa1_g(), 3));

                //Console.WriteLine("i_3_i_4_alfa1_g: expected = " +
                //      i_3_i_4_alfa1_g + "; actual=" + Math.Round(_ml.i_3_i_4_alfa1_g(), 3));

                //Console.WriteLine("i_общ_б_alfa1_g: expected = " +
                //      i_общ_б_alfa1_g + "; actual=" + Math.Round(_ml.i_общ_б_alfa1_g(), 3));


                //Console.WriteLine("iхим_alfa2_g: expected = " +
                //      iхим_alfa2_g + "; actual=" + Math.Round(_ml.iхим_alfa2_g(), 3));

                //Console.WriteLine("iтопл_alfa2_g: expected = " +
                //      iтопл_alfa2_g + "; actual=" + Math.Round(_ml.iтопл_alfa2_g(), 3));

                //Console.WriteLine("iвозд_alfa2_g: expected = " +
                //      iвозд_alfa2_g + "; actual=" + Math.Round(_ml.iвозд_alfa2_g(), 3));

                //Console.WriteLine("iобщ_т_alfa2_g: expected = " +
                //      iобщ_т_alfa2_g + "; actual=" + Math.Round(_ml.iобщ_т_alfa2_g(), 3));

                //Console.WriteLine("i_3_i_4_alfa2_g: expected = " +
                //      i_3_i_4_alfa2_g + "; actual=" + Math.Round(_ml.i_3_i_4_alfa2_g(), 3));

                //Console.WriteLine("i_общ_б_alfa2_g: expected = " +
                //      i_общ_б_alfa2_g + "; actual=" + Math.Round(_ml.i_общ_б_alfa2_g(), 3));

                ////ТАБЛИЦА 6

                //Console.WriteLine("Temp_alfa_g: expected = " +
                //      Temp_alfa_g + "; actual=" + Math.Round(_ml.Temp_alfa_g(), 3));

                //Console.WriteLine("Cel_alfa_g: expected = " +
                //      Cel_alfa_g + "; actual=" + Math.Round(_ml.Cel_alfa_g(), 3));

                //Console.WriteLine("Tbalance_alfa_g: expected = " +
                //      Tbalance_alfa_g + "; actual=" + Math.Round(_ml.Tbalance_alfa_g(), 3));

                //Console.WriteLine("Cel_balance_alfa_g: expected = " +
                //      Cel_balance_alfa_g + "; actual=" + Math.Round(_ml.Cel_balance_alfa_g(), 3));


                //Console.WriteLine("Temp_alfa2_g: expected = " +
                //      Temp_alfa2_g + "; actual=" + Math.Round(_ml.Temp_alfa2_g(), 3));

                //Console.WriteLine("Cel_alfa2_g: expected = " +
                //      Cel_alfa2_g + "; actual=" + Math.Round(_ml.Cel_alfa2_g(), 3));

                //Console.WriteLine("Tbalance_alfa2_g: expected = " +
                //      Tbalance_alfa2_g + "; actual=" + Math.Round(_ml.Tbalance_alfa2_g(), 3));

                //Console.WriteLine("Cel_balance_alfa2_g: expected = " +
                //      Cel_balance_alfa2_g + "; actual=" + Math.Round(_ml.Cel_balance_alfa2_g(), 3));

                #endregion  4. Сравнить значения из Excel и из библиотеки с заданной точностью

                //WorkBook.Close(false, null, null);
                //objExcel.Quit();
            }
            catch
            {
                if (WorkBook != null) WorkBook.Close(false, null, null);
                if (objExcel != null) objExcel.Quit();
            }
            finally
            {
                //WorkBook.Close(false, null, null);
                //objExcel.Quit();
            }
        }


        [SetUp]
        public void Setup()
        {
        }

    }
}
