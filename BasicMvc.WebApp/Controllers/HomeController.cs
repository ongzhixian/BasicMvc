using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BasicMvc.WebApp.Models;
using NLog;

namespace BasicMvc.WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _logger.LogDebug(1, "NLog injected into HomeController");
    }

    public IActionResult Index()
    {
        // Use string interpolation to add 
        _logger.LogInformation("Hello, this is the index! {Tenant} {HandlerId} {HandlerName} {QueueName}", 
            "zTENANT",
            "2f3fe3fb-d699-4a35-9ddd-2394f51b31a5",
            "FinancialInstrumentChangeHandler_3",
            "IAP.FR.FMA.FI.TSE");

        // Using Properties; 2 methods
        var logger = LogManager.GetCurrentClassLogger();
        var eventInfo = new LogEventInfo(NLog.LogLevel.Info, logger.Name, "2ndMessage");

        // Method 1: Use `Properties` indexer
        //eventInfo.Properties["CustomValue"] = "My custom string";
        //eventInfo.Properties["CustomDateTimeValue"] = new DateTime(2020, 10, 30, 11, 26, 50);
        
        // Method 2: Use `Properties.Add` method
        //eventInfo.Properties.Add("CustomNumber", 42);
        eventInfo.Properties.Add("Tenant", "someTenant");
        eventInfo.Properties.Add("HandlerId", "someHID");
        eventInfo.Properties.Add("HandlerName", "someHNAME");
        eventInfo.Properties.Add("QueueName", "someQNAME");

        // Send to Log
        logger.Log(eventInfo);

        return View();
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
