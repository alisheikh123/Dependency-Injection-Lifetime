using Dependency_Injection_Lifetime.Interface;
using Dependency_Injection_Lifetime.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dependency_Injection_Lifetime.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITransientInterface transientInterface1;
        private readonly ITransientInterface transientInterface2;
        private readonly IScopeInterface scopeInterface1;
        private readonly IScopeInterface scopeInterface2;
        private readonly ISingletonInterface singletonInterface1;
        private readonly ISingletonInterface singletonInterface2;

        public HomeController(ILogger<HomeController> logger,
            ITransientInterface _transientInterface1,
            ITransientInterface _transientInterface2,
        IScopeInterface _scopeInterface1,
        IScopeInterface _scopeInterface2,
        ISingletonInterface _singletonInterface1,
        ISingletonInterface _singletonInterface2
            
            
            )
        {

            transientInterface1 = _transientInterface1;
            transientInterface2 = _transientInterface2;

            scopeInterface1 = _scopeInterface1;
            scopeInterface2 = _scopeInterface2;

            singletonInterface1 = _singletonInterface1;
            singletonInterface2 = _singletonInterface2;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Transient1 = transientInterface1.GetOperationId().ToString();
            ViewBag.Transient2 = transientInterface2.GetOperationId().ToString();

            ViewBag.Scope1 = scopeInterface1.GetOperationId().ToString();
            ViewBag.Scope2 = scopeInterface2.GetOperationId().ToString();

            ViewBag.Singleton1 = singletonInterface1.GetOperationId().ToString();
            ViewBag.Singleton2 = singletonInterface2.GetOperationId().ToString();
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
}