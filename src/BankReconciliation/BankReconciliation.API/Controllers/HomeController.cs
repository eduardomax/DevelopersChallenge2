using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BankReconciliation.API.Models;
using BankReconciliation.Domain.Transactions;
using Microsoft.AspNetCore.Http;
using System.IO;
using BankReconciliation.Application.Model;
using BankReconciliation.Application.OFXs;
using BankReconciliation.Application.Transactions;

namespace BankReconciliation.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITransactionRepository _repository;
        private readonly IImportOFX _importOFX;
        private readonly IGetAllTransactions _getAllTransactions;

        public HomeController(ITransactionRepository repository, IImportOFX importOFX, IGetAllTransactions getAllTransactions)
        {
            _repository = repository;
            _importOFX = importOFX;
            _getAllTransactions = getAllTransactions;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload([FromForm] FileUploadModel files)
        {
            List<OFXFile> ofxFiles = new List<OFXFile>();
            long size = files.FormFiles.Sum(f => f.Length);

            foreach (var formFile in files.FormFiles)
            {
                if (formFile.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        formFile.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        ofxFiles.Add(new OFXFile(fileBytes));
                    }
                }
            }

            _importOFX.Import(ofxFiles);

            return RedirectToAction("AllTransactions");
        }

        public IActionResult AllTransactions()
        {
            var transactions = _getAllTransactions.GetAll();
            return View(new AllTransactionsViewModel(transactions));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
