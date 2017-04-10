using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;

namespace ReadJSONResponse
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // 設定JSON的網址
            string URL = "http://opendata.epa.gov.tw/ws/Data/UV/?format=json";

            // 宣告HttpClient
            HttpClient client = new HttpClient();

            // 取得資料，傳給response
            var response = client.GetAsync(URL).Result;

            // 取得JSON的字串
            string JSON = response.Content.ReadAsStringAsync().Result.ToString();

            // 透過JsonConvert.DeserializeObject 將 JSON字串 轉成物件集合
            var UVs = JsonConvert.DeserializeObject<List<UVInfo>>(JSON);

            // 動態鏈結 DataGrid
            this.datagrid_Uvs.ItemsSource = UVs;
        }

        public class UVInfo
        {
            public string SiteName { get; set; }
            public string UVI { get; set; }
            public string PublishAgency { get; set; }
            public string County { get; set; }
            public string WGS84Lon { get; set; }
            public string WGS84Lat { get; set; }
            public string PublishTime { get; set; }
        }

    }
}
