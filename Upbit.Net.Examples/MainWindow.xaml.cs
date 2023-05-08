using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

using Upbit.Net.Clients;

namespace Upbit.Net.Examples
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Gaten", "upbit_api.txt");
            var keyData = File.ReadAllLines(path);
            var accessKey = keyData[0];
            var secretKey = keyData[1];

            var client = new UpbitClient(accessKey, secretKey);
            var result = client.QuotationOrderBook.GetOrderBooksAsync(new List<string>()
            {
                "KRW-GAS",
                "KRW-BTC"
            });
            result.Wait();

            var data = result.Result;
        }
    }
}
