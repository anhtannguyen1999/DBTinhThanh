using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace CreateDB64TinhThanhFromExcel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvertToJson_Click(object sender, EventArgs e)
        {
            readExcelFile();
            Thread myThread = new Thread(new ThreadStart(readExcelFile));
            myThread.Start();

        }

        private void readExcelFile()
        {
            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"F:\ThayTuong2\Tools\CreateDB64TinhThanhFromExcel\DBTinhThanh.xls");
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            // MessageBox.Show(colCount+":"+rowCount);
            
            //LocTinh
            string preMaTinh = "";
            string preMaHuyen = "";
            string preMaXa = "";

            //Viet vao file tinh//.json
            string firstContent = "{\"listItem\":[";
            string lastContent = "]}";
            writeToFileWithUTF8("tinh",firstContent);
            //Duyet het tat ca cac row
            for (int i = 2; i <= rowCount; i++)
            {
                //Neu o 1 khac null && o 2 khac null
                if ((xlRange.Cells[i, 1] != null && xlRange.Cells[i, 1].Value2 != null)&&
                    (xlRange.Cells[i, 2] != null && xlRange.Cells[i, 2].Value2 != null))
                {
                    //Gap tinh khac thi in ra
                    if(xlRange.Cells[i, 2].Value2 != preMaTinh)
                    {
                        string jsonTinh = "{\"id\": \"" + xlRange.Cells[i, 2].Value2.ToString() 
                            + "\", \"title\":\""+xlRange.Cells[i,1].Value2.ToString()+"\"}";
                        //Append to file tinh//.json
                        //MessageBox.Show(jsonTinh);
                        if(preMaTinh=="")//Neu la tinh dau tien
                            writeToFileWithUTF8("tinh",jsonTinh);
                        else
                            writeToFileWithUTF8("tinh",","+jsonTinh);
                        
                    }

                    //Gap Huyen khac thi in ra
                    if (xlRange.Cells[i, 4].Value2 != preMaHuyen)
                    {
                        //Tao folder ma tinh
                        if( !Directory.Exists("QuanHuyen"))
                        {
                            Directory.CreateDirectory("QuanHuyen");
                        }
                        //Dong file huyen cu
                        if (preMaTinh != xlRange.Cells[i, 2].Value2.ToString())
                            writeToFileWithUTF8(@"QuanHuyen/" + preMaTinh + "",lastContent);


                        string jsonHuyen = "{\"id\": \"" + xlRange.Cells[i, 4].Value2.ToString()
                            + "\", \"title\":\"" + xlRange.Cells[i, 3].Value2.ToString() + "\", \"idTinh\":\""+
                            xlRange.Cells[i, 2].Value2.ToString() + "\"}";
                        //Append to file QuanHuyen/xlRange.Cells[i, 2].Value2.ToString()
                        //MessageBox.Show(jsonHuyen);
                        if (preMaTinh != xlRange.Cells[i, 2].Value2.ToString())//Neu la huyen dau tien cua tinh
                        {
                            string path = @"QuanHuyen/" + xlRange.Cells[i, 2].Value2.ToString() + "";
                            writeToFileWithUTF8(path, firstContent+" "+jsonHuyen);
                        }
                        else
                        {
                            string path = @"QuanHuyen/" + xlRange.Cells[i, 2].Value2.ToString() + "";
                            writeToFileWithUTF8(path, ","+jsonHuyen);
                        }
                    }

                    //Gap xa khac thi in ra
                    if (xlRange.Cells[i, 6].Value2 != preMaXa)
                    {
                        //Tao folder xa
                        if (!Directory.Exists("XaPhuong"))
                        {
                            Directory.CreateDirectory("XaPhuong");
                        }

                        //Dong file xa cu
                        if (preMaHuyen != xlRange.Cells[i, 4].Value2.ToString())
                            writeToFileWithUTF8(@"XaPhuong/" + preMaHuyen + "", lastContent);

                        string jsonXa = "{\"id\": \"" + xlRange.Cells[i, 6].Value2.ToString()
                            + "\", \"title\":\"" + xlRange.Cells[i, 5].Value2.ToString() + "\", \"idTinh\":\"" +
                            xlRange.Cells[i, 2].Value2.ToString() + "\", \"idHuyen\":\""+
                            xlRange.Cells[i, 4].Value2.ToString() + "\"}";
                        //Append to file PhuongXa/xlRange.Cells[i, 4].Value2.ToString()
                        //MessageBox.Show(jsonXa);
                        if (preMaHuyen != xlRange.Cells[i, 4].Value2.ToString())//Neu la xa dau tien cua huyen
                        {
                            string path = @"XaPhuong/" + xlRange.Cells[i, 4].Value2.ToString() + "";
                            writeToFileWithUTF8(path, firstContent+" "+jsonXa);
                        }
                        else
                        {
                            string path = @"XaPhuong/" + xlRange.Cells[i, 4].Value2.ToString() + "";
                            writeToFileWithUTF8(path, "," + jsonXa);
                        }



                        //Khi 1 tinh thay doi thi huyen vs xa cung doi
                        preMaTinh = xlRange.Cells[i, 2].Value2;
                        preMaHuyen = xlRange.Cells[i, 4].Value2;
                        preMaXa = xlRange.Cells[i, 6].Value2;
                    }

                } 
            }

            writeToFileWithUTF8("tinh", lastContent);
            writeToFileWithUTF8(@"QuanHuyen/" + preMaTinh + "", lastContent);
            writeToFileWithUTF8(@"XaPhuong/" + preMaHuyen + "", lastContent);

            Invoke(new MethodInvoker(() => {
                MessageBox.Show("Done!");
            }));
            
        }



        //FILE
        private void writeToFileWithUTF8(string filePath, string txt)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Append))
                {
                    using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8))
                    {
                        writer.Write(txt);
                        //writer.WriteLine(txt);
                    }
                }
            }
            catch { }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(@"F:\ThayTuong2\DBTinhThanh\JsonDB\QuanHuyen") || !Directory.Exists(@"F:\ThayTuong2\DBTinhThanh\JsonDB\XaPhuong"))
            {
                MessageBox.Show(@"Input chua co \n F:\ThayTuong2\DBTinhThanh\JsonDB\QuanHuyen");
                return;
         
            }
            else
            {
                foreach(String filePath in Directory.GetFiles(@"F:\ThayTuong2\DBTinhThanh\JsonDB\QuanHuyen"))
                {
                    string line = "";
                    System.IO.StreamReader file = new System.IO.StreamReader(filePath);
                    while ((line = file.ReadLine()) != null)
                    {
                        writeToFileWithUTF8(filePath+"_new",line);
                    }
                    file.Close();
                }
                foreach (String filePath in Directory.GetFiles(@"F:\ThayTuong2\DBTinhThanh\JsonDB\XaPhuong"))
                {
                    string line = "";
                    System.IO.StreamReader file = new System.IO.StreamReader(filePath);
                    while ((line = file.ReadLine()) != null)
                    {
                        writeToFileWithUTF8(filePath + "_new", line);
                    }
                    file.Close();
                }
                MessageBox.Show("Done!");
            }
            
        }
    }
}
