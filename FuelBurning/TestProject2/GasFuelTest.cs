global using NUnit.Framework;
using MathLib;
using Excel = Microsoft.Office.Interop.Excel;

namespace TestProjectDemo
{
    public class GasFuelTest
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
            GasFuel _ml = new GasFuel();

            #region 1. Присвоить исходные данные 

            _ml.CO2 = 0.3;
            _ml.CO = 5.0;
            _ml.H2 = 0.0;
            _ml.CH4 = 88.0;
            _ml.C2H6 = 1.9;
            _ml.C3H8 = 0.2;
            _ml.C4H10 = 0.3;
            _ml.C5H12 = 0.0;
            _ml.H2S = 0.0;
            _ml.N2 = 9.3;
            _ml.G = 5.0;
            _ml.Tг = 200.0;
            _ml.Tв = 200.0;
            _ml.Alfa = 1.1;

            #endregion 1. Присвоить исходные данные

            //try
            //{
            //    #region 2. Передать исходные данные в Excel-файл, записать в соответствующие ячейки
            //    objExcel = new Excel.Application();
            //    WorkBook = objExcel.Workbooks.Open(
            //                Directory.GetCurrentDirectory() + "\\" + fileName);
            //    Excel.Worksheet WorkSheet = (Excel.Worksheet)WorkBook.Sheets["Газообразное топливо"];

            //    // Cells[СТРОКА,СТОЛБЕЦ]
            //    ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[9, 2]).Value2 = _ml.CO2;
            //    ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[10, 2]).Value2 = _ml.CO;
            //    ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[11, 2]).Value2 = _ml.H2;
            //    ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[12, 2]).Value2 = _ml.CH4;
            //    ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[13, 2]).Value2 = _ml.C2H6;
            //    ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[14, 2]).Value2 = _ml.C3H8;
            //    ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[15, 2]).Value2 = _ml.C4H10;
            //    ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[16, 2]).Value2 = _ml.C5H12;
            //    ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[17, 2]).Value2 = _ml.H2S;
            //    ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[18, 2]).Value2 = _ml.N2;
            //    ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[21, 2]).Value2 = _ml.G;
            //    ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[22, 2]).Value2 = _ml.Tг;
            //    ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[23, 2]).Value2 = _ml.Tв;
            //    ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[24, 2]).Value2 = _ml.Alfa;

            //    // отобразить в журнале тестирования
            //    Console.WriteLine("--- Исходные данные");
            //    Console.WriteLine("Число 1: {0}", _ml.CO2.ToString());
            //    Console.WriteLine("Число 2: {0}", _ml.CO.ToString());
            //    Console.WriteLine("Число 3: {0}", _ml.H2.ToString());
            //    Console.WriteLine("Число 4: {0}", _ml.CH4.ToString());
            //    Console.WriteLine("Число 5: {0}", _ml.C2H6.ToString());
            //    Console.WriteLine("Число 6: {0}", _ml.C3H8.ToString());
            //    Console.WriteLine("Число 7: {0}", _ml.C4H10.ToString());
            //    Console.WriteLine("Число 8: {0}", _ml.C5H12.ToString());
            //    Console.WriteLine("Число 9: {0}", _ml.H2S.ToString());
            //    Console.WriteLine("Число 10: {0}", _ml.N2.ToString());
            //    Console.WriteLine("Число 11: {0}", _ml.G.ToString());
            //    Console.WriteLine("Число 12: {0}", _ml.Tг.ToString());
            //    Console.WriteLine("Число 13: {0}", _ml.Tв.ToString());
            //    Console.WriteLine("Число 14: {0}", _ml.Alfa.ToString());



            //    #endregion 2. Передать исходные данные в Excel-файл, записать в соответствующие ячейки

            //    #region 3. Прочитать из ячейки Excel-файла значение расчетных величин

            //    double Rh2o = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[19, 3]).Value.ToString());
            //    double Rco2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[9, 3]).Value.ToString());
            //    double Rco = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[10, 3]).Value.ToString());
            //    double Rh2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[11, 3]).Value.ToString());
            //    double Rch4 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[12, 3]).Value.ToString());
            //    double Rc2h6 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[13, 3]).Value.ToString());
            //    double Rc3h8 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[14, 3]).Value.ToString());
            //    double Rc4h10 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[15, 3]).Value.ToString());
            //    double Rc5h12 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[16, 3]).Value.ToString());
            //    double Rh2s = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[17, 3]).Value.ToString());
            //    double Rn2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[18, 3]).Value.ToString());
            //    double Sumishdanrab = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[20, 3]).Value.ToString());
            //    double Sumishdan = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[20, 2]).Value.ToString());

            //    //ТАБЛИЦА 1

            //    double Lo = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[8, 6]).Value.ToString());
            //    double Lalfa = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[9, 6]).Value.ToString());
                
            //    //ТАБЛИЦА 2

            //    double Vo_CO2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[11, 6]).Value.ToString());
            //    double Vo_SO2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[12, 6]).Value.ToString());
            //    double Vo_H2O = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[13, 6]).Value.ToString());
            //    double Vo_N2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[14, 6]).Value.ToString());
            //    double Vo_CO = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[15, 6]).Value.ToString());
            //    double Vo_H2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[16, 6]).Value.ToString());
            //    double Vo_O2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[17, 6]).Value.ToString());
            //    double Vo = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[18, 6]).Value.ToString());
            //    double V_alfa_N2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[19, 6]).Value.ToString());
            //    double V_O2_izb = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[20, 6]).Value.ToString());
            //    double V_alfa = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[21, 6]).Value.ToString());

            //    //ТАБЛИЦА 3

            //    double CO2alfa = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[9, 8]).Value.ToString());
            //    double SO2alfa = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[10, 8]).Value.ToString());
            //    double H2Oalfa = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[11, 8]).Value.ToString());
            //    double N2alfa = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[12, 8]).Value.ToString());
            //    double COalfa = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[13, 8]).Value.ToString());
            //    double H2alfa = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[14, 8]).Value.ToString());
            //    double O2alfa = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[15, 8]).Value.ToString());
            //    double Sumalfa = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[16, 8]).Value.ToString());

            //    double CO2alfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[9, 9]).Value.ToString());
            //    double SO2alfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[10, 9]).Value.ToString());
            //    double H2Oalfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[11, 9]).Value.ToString());
            //    double N2alfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[12, 9]).Value.ToString());
            //    double COalfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[13, 9]).Value.ToString());
            //    double H2alfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[14, 9]).Value.ToString());
            //    double O2alfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[15, 9]).Value.ToString());
            //    double Sumalfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[16, 9]).Value.ToString());

            //    double Qнр = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[16, 11]).Value.ToString());

            //    //ТАБЛИЦА 4

            //    double Cтопл = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[19, 8]).Value.ToString());
            //    double Cвозд = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[20, 8]).Value.ToString());
            //    double ВоздВПГ = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[21, 8]).Value.ToString());

            //    //ТАБЛИЦА 5 

            //    double i_химalfa = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[25, 6]).Value.ToString());
            //    double i_топлalfa = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[26, 6]).Value.ToString());
            //    double i_воздalfa = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[27, 6]).Value.ToString());
            //    double i_общ_т_alfa = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[28, 6]).Value.ToString());
            //    double i_з_alfa = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[29, 6]).Value.ToString());
            //    double i_общ_б_alfa = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[30, 6]).Value.ToString());

            //    double i_химalfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[25, 7]).Value.ToString());
            //    double i_топлalfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[26, 7]).Value.ToString());
            //    double i_воздalfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[27, 7]).Value.ToString());
            //    double i_общ_т_alfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[28, 7]).Value.ToString());
            //    double i_з_alfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[29, 7]).Value.ToString());
            //    double i_общ_б_alfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[30, 7]).Value.ToString());

            //    //ТАБЛИЦА 6

            //    double Temp_alfa = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[23, 11]).Value.ToString());
            //    double Cel_alfa = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[24, 11]).Value.ToString());
            //    double Tbalance_alfa = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[25, 11]).Value.ToString());
            //    double Cel_balance_alfa = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[26, 11]).Value.ToString());

            //    double Temp_alfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[23, 12]).Value.ToString());
            //    double Cel_alfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[24, 12]).Value.ToString());
            //    double Tbalance_alfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[25, 12]).Value.ToString());
            //    double Cel_balance_alfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[26, 12]).Value.ToString());


            //    #endregion 3. Прочитать из ячейки Excel-файла значение расчетных величин

            //    #region  4. Сравнить значения из Excel и из библиотеки с заданной точностью

                //        Assert.AreEqual(Rh2o, Math.Round(_ml.H2Or, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Rh2o: expected =" +
                //                    Rh2o + "; actual=" + Math.Round(_ml.H2Or, 3));

                //        Assert.AreEqual(Rco2, Math.Round(_ml.CO2r, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Rco2: expected =" +
                //                    Rco2 + "; actual=" + Math.Round(_ml.CO2r, 3));

                //        Assert.AreEqual(Rco, Math.Round(_ml.COr, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Rco: expected =" +
                //                    Rco + "; actual=" + Math.Round(_ml.COr, 3));

                //        Assert.AreEqual(Rh2, Math.Round(_ml.H2r, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Rh2: expected =" +
                //                    Rh2 + "; actual=" + Math.Round(_ml.H2r, 3));

                //        Assert.AreEqual(Rch4, Math.Round(_ml.CH4r, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Rch4: expected =" +
                //                    Rch4 + "; actual=" + Math.Round(_ml.CH4r, 3));

                //        Assert.AreEqual(Rc2h6, Math.Round(_ml.C2H6r, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Rc2h6: expected =" +
                //                    Rc2h6 + "; actual=" + Math.Round(_ml.C2H6r, 3));

                //        Assert.AreEqual(Rc3h8, Math.Round(_ml.C3H8r, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Rc3h8: expected =" +
                //                    Rc3h8 + "; actual=" + Math.Round(_ml.C3H8r, 3));

                //        Assert.AreEqual(Rc4h10, Math.Round(_ml.C4H10r, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Rc4h10: expected =" +
                //                    Rc4h10 + "; actual=" + Math.Round(_ml.C4H10r, 3));

                //        Assert.AreEqual(Rc5h12, Math.Round(_ml.C5H12r, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Rc5h12: expected =" +
                //                    Rc5h12 + "; actual=" + Math.Round(_ml.C5H12r, 3));

                //        Assert.AreEqual(Rh2s, Math.Round(_ml.H2Sr, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Rh2s: expected =" +
                //                    Rh2s + "; actual=" + Math.Round(_ml.H2Sr, 3));

                //        Assert.AreEqual(Rn2, Math.Round(_ml.N2r, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("RN2: expected =" +
                //                    Rn2 + "; actual=" + Math.Round(_ml.N2r, 3));

                //        Assert.AreEqual(Sumishdanrab, Math.Round(_ml.Sumishdanrab, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Sumishdanrab: expected =" +
                //                    Sumishdanrab + "; actual=" + Math.Round(_ml.Sumishdanrab, 3));

                //        //Assert.AreEqual(Sumishdan, Math.Round(_ml.Sumishdan, 3), 0.001);
                //        //System.Diagnostics.Debug.WriteLine("Sumishdan: expected =" +
                //        //            Sumishdan + "; actual=" + Math.Round(_ml.Sumishdan, 3));

                //        //ТАБЛИЦА 1

                //        Assert.AreEqual(Lo, Math.Round(_ml.Lo, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Lo: expected =" +
                //                    Lo + "; actual=" + Math.Round(_ml.Lo, 3));

                //        Assert.AreEqual(Lalfa, Math.Round(_ml.Lalfa, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Lalfa: expected =" +
                //                    Lalfa + "; actual=" + Math.Round(_ml.Lalfa, 3));

                //        //ТАБЛИЦА 2

                //        Assert.AreEqual(Vo_CO2, Math.Round(_ml.Vo_CO2, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Vo_CO2: expected =" +
                //                    Vo_CO2 + "; actual=" + Math.Round(_ml.Vo_CO2, 3));

                //        Assert.AreEqual(Vo_SO2, Math.Round(_ml.Vo_SO2, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Vo_SO2: expected =" +
                //                    Vo_SO2 + "; actual=" + Math.Round(_ml.Vo_SO2, 3));

                //        Assert.AreEqual(Vo_H2O, Math.Round(_ml.Vo_H2O, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Vo_H2O: expected =" +
                //                    Vo_H2O + "; actual=" + Math.Round(_ml.Vo_H2O, 3));

                //        Assert.AreEqual(Vo_N2, Math.Round(_ml.Vo_N2, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Vo_N2: expected =" +
                //                    Vo_N2 + "; actual=" + Math.Round(_ml.Vo_N2, 3));

                //        Assert.AreEqual(Vo_CO, Math.Round(_ml.Vo_CO, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Vo_CO: expected =" +
                //                    Vo_CO + "; actual=" + Math.Round(_ml.Vo_CO, 3));

                //        Assert.AreEqual(Vo_H2, Math.Round(_ml.Vo_H2, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Vo_H2: expected =" +
                //                    Vo_H2 + "; actual=" + Math.Round(_ml.Vo_H2, 3));

                //        Assert.AreEqual(Vo_O2, Math.Round(_ml.Vo_O2, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Vo_O2: expected =" +
                //                    Vo_O2 + "; actual=" + Math.Round(_ml.Vo_O2, 3));

                //        Assert.AreEqual(Vo, Math.Round(_ml.Vo, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Vo: expected =" +
                //                    Vo + "; actual=" + Math.Round(_ml.Vo, 3));

                //        Assert.AreEqual(V_alfa_N2, Math.Round(_ml.V_alfa_N2, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("V_alfa_N2: expected =" +
                //                    V_alfa_N2 + "; actual=" + Math.Round(_ml.V_alfa_N2, 3));

                //        Assert.AreEqual(V_O2_izb, Math.Round(_ml.V_O2_izb, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("V_O2_izb: expected =" +
                //                    V_O2_izb + "; actual=" + Math.Round(_ml.V_O2_izb, 3));

                //        Assert.AreEqual(V_alfa, Math.Round(_ml.V_alfa, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("V_alfa: expected =" +
                //                    V_alfa + "; actual=" + Math.Round(_ml.V_alfa, 3));

                //        //ТАБЛИЦА 3

                //        Assert.AreEqual(CO2alfa, Math.Round(_ml.CO2alfa, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("CO2alfa: expected =" +
                //                    CO2alfa + "; actual=" + Math.Round(_ml.CO2alfa, 3));

                //        Assert.AreEqual(SO2alfa, Math.Round(_ml.SO2alfa, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("SO2alfa: expected =" +
                //                    SO2alfa + "; actual=" + Math.Round(_ml.SO2alfa, 3));

                //        Assert.AreEqual(H2Oalfa, Math.Round(_ml.H2Oalfa, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("H2Oalfa: expected =" +
                //                    H2Oalfa + "; actual=" + Math.Round(_ml.H2Oalfa, 3));

                //        Assert.AreEqual(N2alfa, Math.Round(_ml.N2alfa, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("N2alfa: expected =" +
                //                    N2alfa + "; actual=" + Math.Round(_ml.N2alfa, 3));

                //        Assert.AreEqual(COalfa, Math.Round(_ml.COalfa, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("COalfa: expected =" +
                //                    COalfa + "; actual=" + Math.Round(_ml.COalfa, 3));

                //        Assert.AreEqual(H2alfa, Math.Round(_ml.H2alfa, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("H2alfa: expected =" +
                //                    H2alfa + "; actual=" + Math.Round(_ml.H2alfa, 3));

                //        Assert.AreEqual(O2alfa, Math.Round(_ml.O2alfa, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("O2alfa: expected =" +
                //                    O2alfa + "; actual=" + Math.Round(_ml.O2alfa, 3));

                //        Assert.AreEqual(Sumalfa, Math.Round(_ml.Sumalfa, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Sumalfa: expected =" +
                //                    Sumalfa + "; actual=" + Math.Round(_ml.Sumalfa, 3));


                //        Assert.AreEqual(CO2alfa2, Math.Round(_ml.CO2alfa2, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("CO2alfa2: expected =" +
                //                    CO2alfa2 + "; actual=" + Math.Round(_ml.CO2alfa2, 3));

                //        Assert.AreEqual(SO2alfa2, Math.Round(_ml.SO2alfa2, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("SO2alfa2: expected =" +
                //                    SO2alfa2 + "; actual=" + Math.Round(_ml.SO2alfa2, 3));

                //        Assert.AreEqual(H2Oalfa2, Math.Round(_ml.H2Oalfa2, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("H2Oalfa2: expected =" +
                //                    H2Oalfa2 + "; actual=" + Math.Round(_ml.H2Oalfa2, 3));

                //        Assert.AreEqual(N2alfa2, Math.Round(_ml.N2alfa2, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("N2alfa2: expected =" +
                //                    N2alfa2 + "; actual=" + Math.Round(_ml.N2alfa2, 3));

                //        Assert.AreEqual(COalfa2, Math.Round(_ml.COalfa2, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("COalfa2: expected =" +
                //                    COalfa2 + "; actual=" + Math.Round(_ml.COalfa2, 3));

                //        Assert.AreEqual(H2alfa2, Math.Round(_ml.H2alfa2, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("H2alfa2: expected =" +
                //                    H2alfa2 + "; actual=" + Math.Round(_ml.H2alfa2, 3));

                //        Assert.AreEqual(O2alfa2, Math.Round(_ml.O2alfa2, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("O2alfa2: expected =" +
                //                    O2alfa2 + "; actual=" + Math.Round(_ml.O2alfa2, 3));

                //        Assert.AreEqual(Sumalfa2, Math.Round(_ml.Sumalfa2, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Sumalfa2: expected =" +
                //                    Sumalfa2 + "; actual=" + Math.Round(_ml.Sumalfa2, 3));


                //        Assert.AreEqual(Qнр, Math.Round(_ml.Qнр, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Qнр: expected =" +
                //                    Qнр + "; actual=" + Math.Round(_ml.Qнр, 3));

                //        //ТАБЛИЦА 4

                //        Assert.AreEqual(Cтопл, Math.Round(_ml.Cтопл, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Cтопл: expected =" +
                //                    Cтопл + "; actual=" + Math.Round(_ml.Cтопл, 3));

                //        Assert.AreEqual(Cвозд, Math.Round(_ml.Cвозд, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Cвозд: expected =" +
                //                    Cвозд + "; actual=" + Math.Round(_ml.Cвозд, 3));

                //        Assert.AreEqual(ВоздВПГ, Math.Round(_ml.ВоздВПГ, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("ВоздВПГ: expected =" +
                //                    ВоздВПГ + "; actual=" + Math.Round(_ml.ВоздВПГ, 3));

                //        //ТАБЛИЦА 5

                //        Assert.AreEqual(i_химalfa, Math.Round(_ml.i_химalfa, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("i_химalfa: expected =" +
                //                    i_химalfa + "; actual=" + Math.Round(_ml.i_химalfa, 3));

                //        Assert.AreEqual(i_топлalfa, Math.Round(_ml.i_топлalfa, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("i_топлalfa: expected =" +
                //                    i_топлalfa + "; actual=" + Math.Round(_ml.i_топлalfa, 3));

                //        Assert.AreEqual(i_воздalfa, Math.Round(_ml.i_воздalfa, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("i_воздalfa: expected =" +
                //                   i_воздalfa + "; actual=" + Math.Round(_ml.i_воздalfa, 3));

                //        Assert.AreEqual(i_общ_т_alfa, Math.Round(_ml.i_общ_т_alfa, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("i_общ_т_alfa: expected =" +
                //                    i_общ_т_alfa + "; actual=" + Math.Round(_ml.i_общ_т_alfa, 3));

                //        Assert.AreEqual(i_з_alfa, Math.Round(_ml.i_з_alfa, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("i_з_alfa: expected =" +
                //                    i_з_alfa + "; actual=" + Math.Round(_ml.i_з_alfa, 3));

                //        Assert.AreEqual(i_общ_б_alfa, Math.Round(_ml.i_общ_б_alfa, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("i_общ_б_alfa: expected =" +
                //                    i_общ_б_alfa + "; actual=" + Math.Round(_ml.i_общ_б_alfa, 3));


                //        Assert.AreEqual(i_химalfa2, Math.Round(_ml.i_химalfa2, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("i_химalfa2: expected =" +
                //                    i_химalfa2 + "; actual=" + Math.Round(_ml.i_химalfa2, 3));

                //        Assert.AreEqual(i_топлalfa2, Math.Round(_ml.i_топлalfa2, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("i_топлalfa2: expected =" +
                //                    i_топлalfa2 + "; actual=" + Math.Round(_ml.i_топлalfa2, 3));

                //        Assert.AreEqual(i_воздalfa2, Math.Round(_ml.i_воздalfa2, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("i_воздalfa2: expected =" +
                //                   i_воздalfa2 + "; actual=" + Math.Round(_ml.i_воздalfa2, 3));

                //        Assert.AreEqual(i_общ_т_alfa2, Math.Round(_ml.i_общ_т_alfa2, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("i_общ_т_alfa2: expected =" +
                //                    i_общ_т_alfa2 + "; actual=" + Math.Round(_ml.i_общ_т_alfa2, 3));

                //        Assert.AreEqual(i_з_alfa2, Math.Round(_ml.i_з_alfa2, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("i_з_alfa2: expected =" +
                //                    i_з_alfa2 + "; actual=" + Math.Round(_ml.i_з_alfa2, 3));

                //        Assert.AreEqual(i_общ_б_alfa2, Math.Round(_ml.i_общ_б_alfa2, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("i_общ_б_alfa2: expected =" +
                //                    i_общ_б_alfa2 + "; actual=" + Math.Round(_ml.i_общ_б_alfa2, 3));

                //        //ТАБЛИЦА 6

                //        Assert.AreEqual(Temp_alfa, Math.Round(_ml.Temp_alfa, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Temp_alfa: expected =" +
                //                    Temp_alfa + "; actual=" + Math.Round(_ml.Temp_alfa, 3));

                //        Assert.AreEqual(Cel_alfa, Math.Round(_ml.pogreshnost, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Cel_alfa: expected =" +
                //                    Cel_alfa + "; actual=" + Math.Round(_ml.pogreshnost, 3));

                //        Assert.AreEqual(Tbalance_alfa, Math.Round(_ml.Tbalance_alfa, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Tbalance_alfa: expected =" +
                //                    Tbalance_alfa + "; actual=" + Math.Round(_ml.Tbalance_alfa, 3));

                //        Assert.AreEqual(Cel_balance_alfa, Math.Round(_ml.Cel_balance_alfa, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Cel_balance_alfa: expected =" +
                //                    Cel_balance_alfa + "; actual=" + Math.Round(_ml.Cel_balance_alfa, 3));


                //        Assert.AreEqual(Temp_alfa2, Math.Round(_ml.Temp_alfa2, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Temp_alfa2: expected =" +
                //                    Temp_alfa2 + "; actual=" + Math.Round(_ml.Temp_alfa2, 3));

                //        Assert.AreEqual(Cel_alfa2, Math.Round(_ml.Cel_alfa2, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Cel_alfa2: expected =" +
                //                    Cel_alfa2 + "; actual=" + Math.Round(_ml.Cel_alfa2, 3));

                //        Assert.AreEqual(Tbalance_alfa2, Math.Round(_ml.Tbalance_alfa2, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Tbalance_alfa2: expected =" +
                //                    Tbalance_alfa2 + "; actual=" + Math.Round(_ml.Tbalance_alfa2, 3));

                //        Assert.AreEqual(Cel_balance_alfa2, Math.Round(_ml.Cel_balance_alfa2, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Cel_balance_alfa2: expected =" +
                //                    Cel_balance_alfa2 + "; actual=" + Math.Round(_ml.Cel_balance_alfa2, 3));

                //        // отобразить в журнале тестирования
                //        Console.WriteLine("");
                //        Console.WriteLine("--- Результаты расчета");
                //        Console.WriteLine("Rh2o = " +
                //                    Rh2o + "; actual=" + Math.Round(_ml.H2Or, 3));

                //        Console.WriteLine("Rco2: expected = " +
                //                    Rco2 + "; actual=" + Math.Round(_ml.CO2r, 3));

                //        Console.WriteLine("Rco: expected = " +
                //                  Rco + "; actual=" + Math.Round(_ml.COr, 3));

                //        Console.WriteLine("Rh2: expected = " +
                //                  Rh2 + "; actual=" + Math.Round(_ml.H2r, 3));

                //        Console.WriteLine("Rch4: expected = " +
                //                  Rch4 + "; actual=" + Math.Round(_ml.CH4r, 3));

                //        Console.WriteLine("Rc2h6: expected = " +
                //                  Rc2h6 + "; actual=" + Math.Round(_ml.C2H6r, 3));

                //        Console.WriteLine("Rc3h8: expected = " +
                //                  Rc3h8 + "; actual=" + Math.Round(_ml.C3H8r, 3));

                //        Console.WriteLine("Rc4h10: expected = " +
                //                  Rc4h10 + "; actual=" + Math.Round(_ml.C4H10r, 3));

                //        Console.WriteLine("Rc5h12: expected = " +
                //                  Rc5h12 + "; actual=" + Math.Round(_ml.C5H12r, 3));

                //        Console.WriteLine("Rh2s: expected = " +
                //                  Rh2s + "; actual=" + Math.Round(_ml.H2Sr, 3));

                //        Console.WriteLine("RN2: expected = " +
                //                  Rn2 + "; actual=" + Math.Round(_ml.N2r, 3));

                //        Console.WriteLine("Sumishdanrab: expected = " +
                //                 Sumishdanrab + "; actual=" + Math.Round(_ml.Sumishdanrab, 3));

                //        Console.WriteLine("Sumishdan: expected = " +
                //                 Sumishdan + "; actual=" + Math.Round(_ml.Sumishdan(), 3));

                //        //ТАБЛИЦА 1

                //        Console.WriteLine("Lo: expected = " +
                //                 Lo + "; actual=" + Math.Round(_ml.Lo, 3));

                //        Console.WriteLine("Lalfa: expected = " +
                //                 Lalfa + "; actual=" + Math.Round(_ml.Lalfa, 3));

                //        //ТАБЛИЦА 2

                //        Console.WriteLine("Vo_CO2: expected = " +
                //                 Vo_CO2 + "; actual=" + Math.Round(_ml.Vo_CO2, 3));

                //        Console.WriteLine("Vo_SO2: expected = " +
                //                 Vo_SO2 + "; actual=" + Math.Round(_ml.Vo_SO2, 3));

                //        Console.WriteLine("Vo_H2O: expected = " +
                //                 Vo_H2O + "; actual=" + Math.Round(_ml.Vo_H2O, 3));

                //        Console.WriteLine("Vo_N2: expected = " +
                //                 Vo_N2 + "; actual=" + Math.Round(_ml.Vo_N2, 3));

                //        Console.WriteLine("Vo_CO: expected = " +
                //                 Vo_CO + "; actual=" + Math.Round(_ml.Vo_CO, 3));

                //        Console.WriteLine("Vo_H2: expected = " +
                //                 Vo_H2 + "; actual=" + Math.Round(_ml.Vo_H2, 3));

                //        Console.WriteLine("Vo_O2: expected = " +
                //                 Vo_O2 + "; actual=" + Math.Round(_ml.Vo_O2, 3));

                //        Console.WriteLine("Vo: expected = " +
                //                 Vo + "; actual=" + Math.Round(_ml.Vo, 3));

                //        Console.WriteLine("V_alfa_N2: expected = " +
                //                 V_alfa_N2 + "; actual=" + Math.Round(_ml.V_alfa_N2, 3));

                //        Console.WriteLine("V_O2_izb: expected = " +
                //                 V_O2_izb + "; actual=" + Math.Round(_ml.V_O2_izb, 3));

                //        Console.WriteLine("V_alfa: expected = " +
                //                 V_alfa + "; actual=" + Math.Round(_ml.V_alfa, 3));

                //        //ТАБЛИЦА 3

                //        Console.WriteLine("CO2alfa: expected = " +
                //                 CO2alfa + "; actual=" + Math.Round(_ml.CO2alfa, 3));

                //        Console.WriteLine("SO2alfa: expected = " +
                //                 SO2alfa + "; actual=" + Math.Round(_ml.SO2alfa, 3));

                //        Console.WriteLine("H2Oalfa: expected = " +
                //                 H2Oalfa + "; actual=" + Math.Round(_ml.H2Oalfa, 3));

                //        Console.WriteLine("N2alfa: expected = " +
                //                 N2alfa + "; actual=" + Math.Round(_ml.N2alfa, 3));

                //        Console.WriteLine("COalfa: expected = " +
                //                 COalfa + "; actual=" + Math.Round(_ml.COalfa, 3));

                //        Console.WriteLine("H2alfa: expected = " +
                //                 H2alfa + "; actual=" + Math.Round(_ml.H2alfa, 3));

                //        Console.WriteLine("O2alfa: expected = " +
                //                 O2alfa + "; actual=" + Math.Round(_ml.O2alfa, 3));

                //        Console.WriteLine("Sumalfa: expected = " +
                //                 Sumalfa + "; actual=" + Math.Round(_ml.Sumalfa, 3));


                //        Console.WriteLine("CO2alfa2: expected = " +
                //                 CO2alfa2 + "; actual=" + Math.Round(_ml.CO2alfa2, 3));

                //        Console.WriteLine("SO2alfa2: expected = " +
                //                 SO2alfa2 + "; actual=" + Math.Round(_ml.SO2alfa2, 3));

                //        Console.WriteLine("H2Oalfa2: expected = " +
                //                H2Oalfa2 + "; actual=" + Math.Round(_ml.H2Oalfa2, 3));

                //        Console.WriteLine("N2alfa2: expected = " +
                //                 N2alfa2 + "; actual=" + Math.Round(_ml.N2alfa2, 3));

                //        Console.WriteLine("COalfa2: expected = " +
                //                 COalfa2 + "; actual=" + Math.Round(_ml.COalfa2, 3));

                //        Console.WriteLine("H2alfa2: expected = " +
                //                 H2alfa2 + "; actual=" + Math.Round(_ml.H2alfa2, 3));

                //        Console.WriteLine("O2alfa2: expected = " +
                //                 O2alfa2 + "; actual=" + Math.Round(_ml.O2alfa2, 3));

                //        Console.WriteLine("Sumalfa2: expected = " +
                //                 Sumalfa2 + "; actual=" + Math.Round(_ml.Sumalfa2, 3));


                //        Console.WriteLine("Qнр: expected = " +
                //               Qнр + "; actual=" + Math.Round(_ml.Qнр, 3));


                //        //ТАБЛИЦА 4

                //        Console.WriteLine("Cтопл: expected = " +
                //              Cтопл + "; actual=" + Math.Round(_ml.Cтопл, 3));

                //        Console.WriteLine("Cвозд: expected = " +
                //              Cвозд + "; actual=" + Math.Round(_ml.Cвозд, 3));

                //        Console.WriteLine("ВоздВПГ: expected = " +
                //              ВоздВПГ + "; actual=" + Math.Round(_ml.ВоздВПГ, 3));

                //        //ТАБЛИЦА 5

                //        Console.WriteLine("i_химalfa: expected = " +
                //              i_химalfa + "; actual=" + Math.Round(_ml.i_химalfa, 3));

                //        Console.WriteLine("i_топлalfa: expected = " +
                //              i_топлalfa + "; actual=" + Math.Round(_ml.i_топлalfa, 3));

                //        Console.WriteLine("i_воздalfa: expected = " +
                //              i_воздalfa + "; actual=" + Math.Round(_ml.i_воздalfa, 3));

                //        Console.WriteLine("i_общ_т_alfa: expected = " +
                //              i_общ_т_alfa + "; actual=" + Math.Round(_ml.i_общ_т_alfa, 3));

                //        Console.WriteLine("i_з_alfa: expected = " +
                //              i_з_alfa + "; actual=" + Math.Round(_ml.i_з_alfa, 3));

                //        Console.WriteLine("i_общ_б_alfa: expected = " +
                //              i_общ_б_alfa + "; actual=" + Math.Round(_ml.i_общ_б_alfa, 3));


                //        Console.WriteLine("i_химalfa2: expected = " +
                //              i_химalfa2 + "; actual=" + Math.Round(_ml.i_химalfa2, 3));

                //        Console.WriteLine("i_топлalfa2: expected = " +
                //              i_топлalfa2 + "; actual=" + Math.Round(_ml.i_топлalfa2, 3));

                //        Console.WriteLine("i_воздalfa2: expected = " +
                //              i_воздalfa2 + "; actual=" + Math.Round(_ml.i_воздalfa2, 3));

                //        Console.WriteLine("i_общ_т_alfa2: expected = " +
                //              i_общ_т_alfa2 + "; actual=" + Math.Round(_ml.i_общ_т_alfa2, 3));

                //        Console.WriteLine("i_з_alfa2: expected = " +
                //              i_з_alfa2 + "; actual=" + Math.Round(_ml.i_з_alfa2, 3));

                //        Console.WriteLine("i_общ_б_alfa2: expected = " +
                //              i_общ_б_alfa2 + "; actual=" + Math.Round(_ml.i_общ_б_alfa2, 3));

                //        //ТАБЛИЦА 6

                //        Console.WriteLine("Temp_alfa: expected = " +
                //              Temp_alfa + "; actual=" + Math.Round(_ml.Temp_alfa, 3));

                //        Console.WriteLine("Cel_alfa: expected = " +
                //              Cel_alfa + "; actual=" + Math.Round(_ml.pogreshnost, 3));

                //        Console.WriteLine("Tbalance_alfa: expected = " +
                //              Tbalance_alfa + "; actual=" + Math.Round(_ml.Tbalance_alfa, 3));

                //        Console.WriteLine("Cel_balance_alfa: expected = " +
                //              Cel_balance_alfa + "; actual=" + Math.Round(_ml.Cel_balance_alfa, 3));


                //        Console.WriteLine("Temp_alfa2: expected = " +
                //              Temp_alfa2 + "; actual=" + Math.Round(_ml.Temp_alfa2, 3));

                //        Console.WriteLine("Cel_alfa2: expected = " +
                //              Cel_alfa2 + "; actual=" + Math.Round(_ml.Cel_alfa2, 3));

                //        Console.WriteLine("Tbalance_alfa2: expected = " +
                //              Tbalance_alfa2 + "; actual=" + Math.Round(_ml.Tbalance_alfa2, 3));

                //        Console.WriteLine("Cel_balance_alfa2: expected = " +
                //              Cel_balance_alfa2 + "; actual=" + Math.Round(_ml.Cel_balance_alfa2, 3));

            //    #endregion  4. Сравнить значения из Excel и из библиотеки с заданной точностью

            //    //WorkBook.Close(false, null, null);
            //    //objExcel.Quit();
            //}
            //catch
            //{
            //    if (WorkBook != null) WorkBook.Close(false, null, null);
            //    if (objExcel != null) objExcel.Quit();
            //}
            //finally
            //{
            //    //WorkBook.Close(false, null, null);
            //    //objExcel.Quit();
            //}
        }


        [SetUp]
        public void Setup()
        {
        }

    }
}