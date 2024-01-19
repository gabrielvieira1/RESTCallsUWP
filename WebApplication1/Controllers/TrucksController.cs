namespace WebApplication1.Controllers
{
  public class TruckInfo
  {
    public string ID { get; set; }
    public string Name { get; set; }
    public string Style { get; set; }
  }

  public class TrucksController
  {
    private static TruckInfo[] TruckInfos = new TruckInfo[]
    {
      new TruckInfo()
      {
        ID = "1",
        Name = "Burrito Boy",
        Style = "Mexican",
      },
      new TruckInfo()
      {
        ID = "2",
        Name = "Pasta Idol",
        Style = "Mexican",
      },
      new TruckInfo()
      {
        ID = "3",
        Name = "Cake Lady",
        Style = "Desserts",
      },
    };

    // GET: api/Trucks
    public IEnumerable<TruckInfo> Get() { return TruckInfos; }

    // GET: api/Trucks/5
    public TruckInfo Get(string id) { return TruckInfos.FirstOrDefault(t => t.ID.Equals(id)); }
  }
}
