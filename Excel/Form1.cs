﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excelke = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace Excel

{
    public partial class Form1 : Form
    {
        RealEstateEntities context = new RealEstateEntities();
        List<Flat> Flats;
        Excelke.Application xlApp;
        Excelke.Workbook xlWB;
        Excelke.Worksheet xlSheet;


        public Form1()
        {
            InitializeComponent();
            LoadData();
            CreateExcel();
        }

        private void LoadData()
        {
            Flats = context.Flats.ToList();
        }

        private void CreateExcel()
        {
            try
            {
                 xlApp = new Excelke.Application();
                 xlWB = xlApp.Workbooks.Add(Missing.Value);
                 xlSheet = xlWB.ActiveSheet;
                 //CreateTable(); //később írjuk meg
                 xlApp.Visible = true;
                 xlApp.UserControl = true;
            }
            catch (Exception ex)
            {
                string errMsg = string.Format("Error: {0}\nLine: {1}", ex.Message, ex.Source);
                MessageBox.Show(errMsg, "Error");

                xlWB.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWB = null;
                xlApp = null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
