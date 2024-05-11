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
        /// ����� ������������ �������������� ����������
        /// </summary>
        [Test]
        public void CalculationTest()
        {
            GasFuel _ml = new GasFuel();

            #region 1. ��������� �������� ������ 

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
            _ml.T� = 200.0;
            _ml.T� = 200.0;
            _ml.Alfa = 1.1;

            #endregion 1. ��������� �������� ������

            //try
            //{
            //    #region 2. �������� �������� ������ � Excel-����, �������� � ��������������� ������
            //    objExcel = new Excel.Application();
            //    WorkBook = objExcel.Workbooks.Open(
            //                Directory.GetCurrentDirectory() + "\\" + fileName);
            //    Excel.Worksheet WorkSheet = (Excel.Worksheet)WorkBook.Sheets["������������ �������"];

            //    // Cells[������,�������]
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
            //    ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[22, 2]).Value2 = _ml.T�;
            //    ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[23, 2]).Value2 = _ml.T�;
            //    ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[24, 2]).Value2 = _ml.Alfa;

            //    // ���������� � ������� ������������
            //    Console.WriteLine("--- �������� ������");
            //    Console.WriteLine("����� 1: {0}", _ml.CO2.ToString());
            //    Console.WriteLine("����� 2: {0}", _ml.CO.ToString());
            //    Console.WriteLine("����� 3: {0}", _ml.H2.ToString());
            //    Console.WriteLine("����� 4: {0}", _ml.CH4.ToString());
            //    Console.WriteLine("����� 5: {0}", _ml.C2H6.ToString());
            //    Console.WriteLine("����� 6: {0}", _ml.C3H8.ToString());
            //    Console.WriteLine("����� 7: {0}", _ml.C4H10.ToString());
            //    Console.WriteLine("����� 8: {0}", _ml.C5H12.ToString());
            //    Console.WriteLine("����� 9: {0}", _ml.H2S.ToString());
            //    Console.WriteLine("����� 10: {0}", _ml.N2.ToString());
            //    Console.WriteLine("����� 11: {0}", _ml.G.ToString());
            //    Console.WriteLine("����� 12: {0}", _ml.T�.ToString());
            //    Console.WriteLine("����� 13: {0}", _ml.T�.ToString());
            //    Console.WriteLine("����� 14: {0}", _ml.Alfa.ToString());



            //    #endregion 2. �������� �������� ������ � Excel-����, �������� � ��������������� ������

            //    #region 3. ��������� �� ������ Excel-����� �������� ��������� �������

            //    double Rh2o = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[19, 3]).Value.ToString());
            //    double Rco2 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[9, 3]).Value.ToString());
            //    double Rco = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[10, 3]).Value.ToString());
            //    double Rh2 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[11, 3]).Value.ToString());
            //    double Rch4 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[12, 3]).Value.ToString());
            //    double Rc2h6 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[13, 3]).Value.ToString());
            //    double Rc3h8 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[14, 3]).Value.ToString());
            //    double Rc4h10 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[15, 3]).Value.ToString());
            //    double Rc5h12 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[16, 3]).Value.ToString());
            //    double Rh2s = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[17, 3]).Value.ToString());
            //    double Rn2 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[18, 3]).Value.ToString());
            //    double Sumishdanrab = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[20, 3]).Value.ToString());
            //    double Sumishdan = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[20, 2]).Value.ToString());

            //    //������� 1

            //    double Lo = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[8, 6]).Value.ToString());
            //    double Lalfa = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[9, 6]).Value.ToString());
                
            //    //������� 2

            //    double Vo_CO2 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[11, 6]).Value.ToString());
            //    double Vo_SO2 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[12, 6]).Value.ToString());
            //    double Vo_H2O = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[13, 6]).Value.ToString());
            //    double Vo_N2 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[14, 6]).Value.ToString());
            //    double Vo_CO = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[15, 6]).Value.ToString());
            //    double Vo_H2 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[16, 6]).Value.ToString());
            //    double Vo_O2 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[17, 6]).Value.ToString());
            //    double Vo = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[18, 6]).Value.ToString());
            //    double V_alfa_N2 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[19, 6]).Value.ToString());
            //    double V_O2_izb = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[20, 6]).Value.ToString());
            //    double V_alfa = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[21, 6]).Value.ToString());

            //    //������� 3

            //    double CO2alfa = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[9, 8]).Value.ToString());
            //    double SO2alfa = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[10, 8]).Value.ToString());
            //    double H2Oalfa = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[11, 8]).Value.ToString());
            //    double N2alfa = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[12, 8]).Value.ToString());
            //    double COalfa = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[13, 8]).Value.ToString());
            //    double H2alfa = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[14, 8]).Value.ToString());
            //    double O2alfa = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[15, 8]).Value.ToString());
            //    double Sumalfa = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[16, 8]).Value.ToString());

            //    double CO2alfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[9, 9]).Value.ToString());
            //    double SO2alfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[10, 9]).Value.ToString());
            //    double H2Oalfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[11, 9]).Value.ToString());
            //    double N2alfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[12, 9]).Value.ToString());
            //    double COalfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[13, 9]).Value.ToString());
            //    double H2alfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[14, 9]).Value.ToString());
            //    double O2alfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[15, 9]).Value.ToString());
            //    double Sumalfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[16, 9]).Value.ToString());

            //    double Q�� = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[16, 11]).Value.ToString());

            //    //������� 4

            //    double C���� = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[19, 8]).Value.ToString());
            //    double C���� = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[20, 8]).Value.ToString());
            //    double ������� = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[21, 8]).Value.ToString());

            //    //������� 5 

            //    double i_���alfa = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[25, 6]).Value.ToString());
            //    double i_����alfa = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[26, 6]).Value.ToString());
            //    double i_����alfa = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[27, 6]).Value.ToString());
            //    double i_���_�_alfa = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[28, 6]).Value.ToString());
            //    double i_�_alfa = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[29, 6]).Value.ToString());
            //    double i_���_�_alfa = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[30, 6]).Value.ToString());

            //    double i_���alfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[25, 7]).Value.ToString());
            //    double i_����alfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[26, 7]).Value.ToString());
            //    double i_����alfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[27, 7]).Value.ToString());
            //    double i_���_�_alfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[28, 7]).Value.ToString());
            //    double i_�_alfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[29, 7]).Value.ToString());
            //    double i_���_�_alfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[30, 7]).Value.ToString());

            //    //������� 6

            //    double Temp_alfa = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[23, 11]).Value.ToString());
            //    double Cel_alfa = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[24, 11]).Value.ToString());
            //    double Tbalance_alfa = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[25, 11]).Value.ToString());
            //    double Cel_balance_alfa = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[26, 11]).Value.ToString());

            //    double Temp_alfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[23, 12]).Value.ToString());
            //    double Cel_alfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[24, 12]).Value.ToString());
            //    double Tbalance_alfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[25, 12]).Value.ToString());
            //    double Cel_balance_alfa2 = double.Parse(((Excel.Range)WorkBook.Sheets["������������ �������"].Cells[26, 12]).Value.ToString());


            //    #endregion 3. ��������� �� ������ Excel-����� �������� ��������� �������

            //    #region  4. �������� �������� �� Excel � �� ���������� � �������� ���������

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

                //        //������� 1

                //        Assert.AreEqual(Lo, Math.Round(_ml.Lo, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Lo: expected =" +
                //                    Lo + "; actual=" + Math.Round(_ml.Lo, 3));

                //        Assert.AreEqual(Lalfa, Math.Round(_ml.Lalfa, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Lalfa: expected =" +
                //                    Lalfa + "; actual=" + Math.Round(_ml.Lalfa, 3));

                //        //������� 2

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

                //        //������� 3

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


                //        Assert.AreEqual(Q��, Math.Round(_ml.Q��, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("Q��: expected =" +
                //                    Q�� + "; actual=" + Math.Round(_ml.Q��, 3));

                //        //������� 4

                //        Assert.AreEqual(C����, Math.Round(_ml.C����, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("C����: expected =" +
                //                    C���� + "; actual=" + Math.Round(_ml.C����, 3));

                //        Assert.AreEqual(C����, Math.Round(_ml.C����, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("C����: expected =" +
                //                    C���� + "; actual=" + Math.Round(_ml.C����, 3));

                //        Assert.AreEqual(�������, Math.Round(_ml.�������, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("�������: expected =" +
                //                    ������� + "; actual=" + Math.Round(_ml.�������, 3));

                //        //������� 5

                //        Assert.AreEqual(i_���alfa, Math.Round(_ml.i_���alfa, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("i_���alfa: expected =" +
                //                    i_���alfa + "; actual=" + Math.Round(_ml.i_���alfa, 3));

                //        Assert.AreEqual(i_����alfa, Math.Round(_ml.i_����alfa, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("i_����alfa: expected =" +
                //                    i_����alfa + "; actual=" + Math.Round(_ml.i_����alfa, 3));

                //        Assert.AreEqual(i_����alfa, Math.Round(_ml.i_����alfa, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("i_����alfa: expected =" +
                //                   i_����alfa + "; actual=" + Math.Round(_ml.i_����alfa, 3));

                //        Assert.AreEqual(i_���_�_alfa, Math.Round(_ml.i_���_�_alfa, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("i_���_�_alfa: expected =" +
                //                    i_���_�_alfa + "; actual=" + Math.Round(_ml.i_���_�_alfa, 3));

                //        Assert.AreEqual(i_�_alfa, Math.Round(_ml.i_�_alfa, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("i_�_alfa: expected =" +
                //                    i_�_alfa + "; actual=" + Math.Round(_ml.i_�_alfa, 3));

                //        Assert.AreEqual(i_���_�_alfa, Math.Round(_ml.i_���_�_alfa, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("i_���_�_alfa: expected =" +
                //                    i_���_�_alfa + "; actual=" + Math.Round(_ml.i_���_�_alfa, 3));


                //        Assert.AreEqual(i_���alfa2, Math.Round(_ml.i_���alfa2, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("i_���alfa2: expected =" +
                //                    i_���alfa2 + "; actual=" + Math.Round(_ml.i_���alfa2, 3));

                //        Assert.AreEqual(i_����alfa2, Math.Round(_ml.i_����alfa2, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("i_����alfa2: expected =" +
                //                    i_����alfa2 + "; actual=" + Math.Round(_ml.i_����alfa2, 3));

                //        Assert.AreEqual(i_����alfa2, Math.Round(_ml.i_����alfa2, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("i_����alfa2: expected =" +
                //                   i_����alfa2 + "; actual=" + Math.Round(_ml.i_����alfa2, 3));

                //        Assert.AreEqual(i_���_�_alfa2, Math.Round(_ml.i_���_�_alfa2, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("i_���_�_alfa2: expected =" +
                //                    i_���_�_alfa2 + "; actual=" + Math.Round(_ml.i_���_�_alfa2, 3));

                //        Assert.AreEqual(i_�_alfa2, Math.Round(_ml.i_�_alfa2, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("i_�_alfa2: expected =" +
                //                    i_�_alfa2 + "; actual=" + Math.Round(_ml.i_�_alfa2, 3));

                //        Assert.AreEqual(i_���_�_alfa2, Math.Round(_ml.i_���_�_alfa2, 3), 0.001);
                //        System.Diagnostics.Debug.WriteLine("i_���_�_alfa2: expected =" +
                //                    i_���_�_alfa2 + "; actual=" + Math.Round(_ml.i_���_�_alfa2, 3));

                //        //������� 6

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

                //        // ���������� � ������� ������������
                //        Console.WriteLine("");
                //        Console.WriteLine("--- ���������� �������");
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

                //        //������� 1

                //        Console.WriteLine("Lo: expected = " +
                //                 Lo + "; actual=" + Math.Round(_ml.Lo, 3));

                //        Console.WriteLine("Lalfa: expected = " +
                //                 Lalfa + "; actual=" + Math.Round(_ml.Lalfa, 3));

                //        //������� 2

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

                //        //������� 3

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


                //        Console.WriteLine("Q��: expected = " +
                //               Q�� + "; actual=" + Math.Round(_ml.Q��, 3));


                //        //������� 4

                //        Console.WriteLine("C����: expected = " +
                //              C���� + "; actual=" + Math.Round(_ml.C����, 3));

                //        Console.WriteLine("C����: expected = " +
                //              C���� + "; actual=" + Math.Round(_ml.C����, 3));

                //        Console.WriteLine("�������: expected = " +
                //              ������� + "; actual=" + Math.Round(_ml.�������, 3));

                //        //������� 5

                //        Console.WriteLine("i_���alfa: expected = " +
                //              i_���alfa + "; actual=" + Math.Round(_ml.i_���alfa, 3));

                //        Console.WriteLine("i_����alfa: expected = " +
                //              i_����alfa + "; actual=" + Math.Round(_ml.i_����alfa, 3));

                //        Console.WriteLine("i_����alfa: expected = " +
                //              i_����alfa + "; actual=" + Math.Round(_ml.i_����alfa, 3));

                //        Console.WriteLine("i_���_�_alfa: expected = " +
                //              i_���_�_alfa + "; actual=" + Math.Round(_ml.i_���_�_alfa, 3));

                //        Console.WriteLine("i_�_alfa: expected = " +
                //              i_�_alfa + "; actual=" + Math.Round(_ml.i_�_alfa, 3));

                //        Console.WriteLine("i_���_�_alfa: expected = " +
                //              i_���_�_alfa + "; actual=" + Math.Round(_ml.i_���_�_alfa, 3));


                //        Console.WriteLine("i_���alfa2: expected = " +
                //              i_���alfa2 + "; actual=" + Math.Round(_ml.i_���alfa2, 3));

                //        Console.WriteLine("i_����alfa2: expected = " +
                //              i_����alfa2 + "; actual=" + Math.Round(_ml.i_����alfa2, 3));

                //        Console.WriteLine("i_����alfa2: expected = " +
                //              i_����alfa2 + "; actual=" + Math.Round(_ml.i_����alfa2, 3));

                //        Console.WriteLine("i_���_�_alfa2: expected = " +
                //              i_���_�_alfa2 + "; actual=" + Math.Round(_ml.i_���_�_alfa2, 3));

                //        Console.WriteLine("i_�_alfa2: expected = " +
                //              i_�_alfa2 + "; actual=" + Math.Round(_ml.i_�_alfa2, 3));

                //        Console.WriteLine("i_���_�_alfa2: expected = " +
                //              i_���_�_alfa2 + "; actual=" + Math.Round(_ml.i_���_�_alfa2, 3));

                //        //������� 6

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

            //    #endregion  4. �������� �������� �� Excel � �� ���������� � �������� ���������

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