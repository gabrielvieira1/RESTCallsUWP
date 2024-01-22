using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class MainPage : Page
  {
    public MainPage()
    {
      this.InitializeComponent();
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
      var client = new HttpClient();
      //client.DefaultRequestHeaders(); 
      //var text = await client.GetStringAsync("https://g1.globo.com/");

      var response = await client.GetAsync("https://localhost:44390/items");
      var text = await response.Content.ReadAsStringAsync();

      IList<Item> result = JsonConvert.DeserializeObject<List<Item>>(text);
      var names = string.Join(", ", result.Select(t => t.Name));

      Result.Text = names;

      //var xml = XElement.Parse(text);
      //var titles = xml.Element("channel").Elements("item").Select(i => i.Element("title").Value);
      ////Result.Text = text;
      //Result.Text = string.Join("\r\n", titles);
    }
  }
  public class Rootobject
  {
    public Item[] Property1 { get; set; }
  }

  public class Item
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
  }

}
