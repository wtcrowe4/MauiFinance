using MauiFinance.Models;
using System.Collections.ObjectModel;
using DevExpress.Maui.Charts;
using System.Reflection;
using System.Xml.Serialization;

namespace MauiFinance.ViewModels
{
    public class ChartsViewModel : BaseViewModel
    {
        //public ChartsViewModel()
        //{
        //    Title = "Charts";
        //    Items = new ObservableCollection<Item>();
        //}

        //public ObservableCollection<Item> Items { get; private set; }

        //async public void OnAppearing()
        //{
        //    IEnumerable<Item> items = await DataStore.GetItemsAsync(true);
        //    Items.Clear();
        //    foreach (Item item in items)
        //    {
        //        Items.Add(item);
        //    }
        //}
        public StockPrices StockPrices { get; }
        public DateTimeRange VisualRange { get; }

        public ChartsViewModel()
        {
            StockPrices = StockData.GetStockPrices();
            VisualRange = new DateTimeRange()
            {
                VisualMin = new System.DateTime(2020, 04, 07),
                VisualMax = new System.DateTime(2020, 07, 07)
            };

        }
    }

    [XmlRoot(ElementName = "StockPrices")]
    public class StockPrices : List<StockPrice> { }

    

    public class StockData
    {
        public static StockPrices GetStockPrices()
        {
            StockPrices stockPrices;
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("GoogleStock"))
            {
                var serializer = new XmlSerializer(typeof(StockPrices));
                stockPrices = (StockPrices)serializer.Deserialize(stream);
            }
            return stockPrices;
        }
    }

    //Series Data
    public class XYSeriesData : IXYSeriesData
    {
        StockPrices stockPrices;
        SeriesDataType seriesDataType;

        public XYSeriesData(StockPrices stockPrices, SeriesDataType seriesDataType)
        {
            this.stockPrices = stockPrices;
            this.seriesDataType = seriesDataType;
        }

        public int GetDataCount() => stockPrices.Count;
        public SeriesDataType GetDataType() => seriesDataType;
        public DateTime GetDateTimeArgument(int index) => stockPrices[index].Date;
        public double GetValue(DevExpress.Maui.Charts.ValueType valueType, int index)
        {
            switch (valueType)
            {
                case DevExpress.Maui.Charts.ValueType.Value: return stockPrices[index].Volume;
                case DevExpress.Maui.Charts.ValueType.High: return stockPrices[index].High;
                case DevExpress.Maui.Charts.ValueType.Low: return stockPrices[index].Low;
                case DevExpress.Maui.Charts.ValueType.Open: return stockPrices[index].Open;
                case DevExpress.Maui.Charts.ValueType.Close: return stockPrices[index].Close;
            }
            return 0;
        }
        public double GetNumericArgument(int index) { return 0; }
        public string GetQualitativeArgument(int index) { return string.Empty; }
        public object GetKey(int index) => null;
    }

    public class CalculatedSeriesData : BindableObject, ICalculatedSeriesData
    {
        public CalculatedSeriesData()
        {
        }

        public Series Series
        {
            get => null;
        }
    }


}