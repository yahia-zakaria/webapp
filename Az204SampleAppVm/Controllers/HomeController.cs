using Az204SampleAppVm.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Az204SampleAppVm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        private static SqlConnection GetConnection()
        {
            var server = "dbsrvr001.database.windows.net";
            var db = "demo";
            var usr = "dbadmin";
            var pass = "36RR45ey@@##";
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = server;
            builder.InitialCatalog = db;
            builder.UserID = usr;
            builder.Password = pass;
            return new SqlConnection(builder.ConnectionString);
        }
        public async Task<IActionResult> Index()
        {
            List<Product> products = new List<Product>(){
            new Product {ProductId = 1, ProductName = "Mobiles", Qnt = 100},
            new Product {ProductId = 2, ProductName = "Laptops", Qnt = 200},
            new Product {ProductId = 3, ProductName = "Tabs", Qnt = 300}
            };
           // using var sqlcon = GetConnection();
           // var sqlstr = "Select ProductId, ProductName, Qnt from Products";
           // sqlcon.Open();
           // var cmd = sqlcon.CreateCommand();
           // cmd.CommandText = sqlstr;
           // var rdr = await cmd.ExecuteReaderAsync();

           // while (rdr.Read())
            //{
               // products.Add(new Product
               // {
                   // ProductId = Convert.ToInt32(rdr["ProductId"]),
                    //ProductName = rdr["ProductName"].ToString(),
                    //Qnt = Convert.ToInt32(rdr["Qnt"])
                //});
            //}
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
