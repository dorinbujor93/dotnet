﻿namespace _10DemoUI
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Core;

    public partial class Form1 : Form
    {
        private const string Path = "..\\..\\..\\00Data\\cars.csv";

        public Form1()
        {
            this.InitializeComponent();
        }

        private async void GetDataBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var cars = await this.ReadCarsAsync();

                foreach (var car in cars) this.AppendToContent($"{car.Name}");
                this.AppendToLog($"finish to process file. {cars.Count()} cars downloaded");
            }
            catch(Exception ex)
            {
                var error = ex;

                if (error?.InnerException != null)
                {
                    this.AppendToContent($"ERROR: {error.InnerException.Message}");
                }
            }
        }

        private Task<IList<Car>> ReadCarsAsync()
        {
            var readCarsAsync = new Task<IList<Car>>(() =>
            {
                var cars = this.ReadCarsFromFile(Path).ToList();

                return cars;
            });

            readCarsAsync.Start();
            
            return readCarsAsync;
        }

        private IEnumerable<Car> ReadCarsFromFile(string filePath)
        {
            var cars = new List<Car>(600);

            var lines = File.ReadAllLines(filePath).Skip(2);

            foreach (var line in lines) cars.Add(Car.Parse(line));

            Thread.Sleep(TimeSpan.FromSeconds(5)); // simulate some work

            return cars;
        }

        public void AppendToLog(string s)
        {
            this.logTbx.AppendText($"{DateTime.Now} - {s}{Environment.NewLine}");
        }

        public void AppendToContent(string s)
        {
            this.contentTxb.AppendText($"{s}{Environment.NewLine}");
        }
    }
}
