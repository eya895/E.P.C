using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E.P.C.Data;
using E.P.C.Models;
using E.P.C.Models.ViewModels;
using E.P.C.Helpers;

namespace E.P.C.Controllers
{
    public class PcBuilderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ShoppingCartService _cart;

        public PcBuilderController(AppDbContext context, ShoppingCartService cart)
        {
            _context = context;
            _cart = cart;
        }

        // MAIN BUILDER PAGE
        public IActionResult Index()
        {
            var session = HttpContext.Session.GetObject<PcBuildSession>("PC_BUILD")
                          ?? new PcBuildSession();

            session.Cpu = _context.Products.OfType<CPU>()
                .FirstOrDefault(x => x.Id == session.CpuId);

            session.Gpu = _context.Products.OfType<GPU>()
                .FirstOrDefault(x => x.Id == session.GpuId);

            session.Ram = _context.Products.OfType<RAM>()
                .FirstOrDefault(x => x.Id == session.RamId);

            session.Motherboard = _context.Products.OfType<MotherBoard>()
                .FirstOrDefault(x => x.Id == session.MotherboardId);

            session.Psu = _context.Products.OfType<PSU>()
                .FirstOrDefault(x => x.Id == session.PsuId);

            session.Storage = _context.Products.OfType<Storage>()
                .FirstOrDefault(x => x.Id == session.StorageId);

            session.Fan = _context.Products.OfType<Fan>()
                .FirstOrDefault(x => x.Id == session.FanId);

            session.Case = _context.Products.OfType<Case>()
                .FirstOrDefault(x => x.Id == session.CaseId);

            session.CpuFan = _context.Products.OfType<CPUFan>()
                .FirstOrDefault(x => x.Id == session.CpuFanId);

            session.Aio = _context.Products.OfType<AIO>()
                .FirstOrDefault(x => x.Id == session.AioId);

            return View(session);
        }

        // CPU SELECT
        [HttpPost]
        public IActionResult SelectCpu(int id)
        {
            var session = HttpContext.Session.GetObject<PcBuildSession>("PC_BUILD")
                          ?? new PcBuildSession();

            session.CpuId = id;
            HttpContext.Session.SetObject("PC_BUILD", session);

            return RedirectToAction("Index");
        }

        // GPU SELECT
        [HttpPost]
        public IActionResult SelectGpu(int id)
        {
            var session = HttpContext.Session.GetObject<PcBuildSession>("PC_BUILD")
                          ?? new PcBuildSession();

            session.GpuId = id;
            HttpContext.Session.SetObject("PC_BUILD", session);

            return RedirectToAction("Index");
        }

        // RAM SELECT
        [HttpPost]
        public IActionResult SelectRam(int id)
        {
            var session = HttpContext.Session.GetObject<PcBuildSession>("PC_BUILD")
                          ?? new PcBuildSession();

            session.RamId = id;
            HttpContext.Session.SetObject("PC_BUILD", session);

            return RedirectToAction("Index");
        }

        // MOTHERBOARD SELECT
        [HttpPost]
        public IActionResult SelectMotherboard(int id)
        {
            var session = HttpContext.Session.GetObject<PcBuildSession>("PC_BUILD")
                          ?? new PcBuildSession();

            session.MotherboardId = id;
            HttpContext.Session.SetObject("PC_BUILD", session);

            return RedirectToAction("Index");
        }

        // PSU SELECT
        [HttpPost]
        public IActionResult SelectPsu(int id)
        {
            var session = HttpContext.Session.GetObject<PcBuildSession>("PC_BUILD")
                          ?? new PcBuildSession();

            session.PsuId = id;
            HttpContext.Session.SetObject("PC_BUILD", session);

            return RedirectToAction("Index");
        }

        // STORAGE SELECT
        [HttpPost]
        public IActionResult SelectStorage(int id)
        {
            var session = HttpContext.Session.GetObject<PcBuildSession>("PC_BUILD")
                          ?? new PcBuildSession();

            session.StorageId = id;
            HttpContext.Session.SetObject("PC_BUILD", session);

            return RedirectToAction("Index");
        }

        // CASE SELECT
        [HttpPost]
        public IActionResult SelectCase(int id)
        {
            var session = HttpContext.Session.GetObject<PcBuildSession>("PC_BUILD")
                          ?? new PcBuildSession();

            session.CaseId = id;
            HttpContext.Session.SetObject("PC_BUILD", session);

            return RedirectToAction("Index");
        }

        // FAN SELECT
        [HttpPost]
        public IActionResult SelectFan(int id)
        {
            var session = HttpContext.Session.GetObject<PcBuildSession>("PC_BUILD")
                          ?? new PcBuildSession();

            session.FanId = id;
            HttpContext.Session.SetObject("PC_BUILD", session);

            return RedirectToAction("Index");
        }

        // CPU FAN SELECT
        [HttpPost]
        public IActionResult SelectCpuFan(int id)
        {
            var session = HttpContext.Session.GetObject<PcBuildSession>("PC_BUILD")
                          ?? new PcBuildSession();

            session.CpuFanId = id;
            session.AioId = null;

            HttpContext.Session.SetObject("PC_BUILD", session);

            return RedirectToAction("Index");
        }

        // AIO SELECT
        [HttpPost]
        public IActionResult SelectAio(int id)
        {
            var session = HttpContext.Session.GetObject<PcBuildSession>("PC_BUILD")
                          ?? new PcBuildSession();

            session.AioId = id;
            session.CpuFanId = null;

            HttpContext.Session.SetObject("PC_BUILD", session);

            return RedirectToAction("Index");
        }

        // ADD FULL BUILD TO CART (NEW)
        [HttpPost]
        public async Task<IActionResult> AddBuildToCart()
        {
            var session = HttpContext.Session.GetObject<PcBuildSession>("PC_BUILD");

            if (session == null)
                return RedirectToAction("Index");

            async Task Add(int? id)
            {
                if (id.HasValue)
                    await _cart.AddAsync(id.Value);
            }

            await Add(session.CpuId);
            await Add(session.GpuId);
            await Add(session.RamId);
            await Add(session.MotherboardId);
            await Add(session.PsuId);
            await Add(session.StorageId);
            await Add(session.CaseId);
            await Add(session.FanId);
            await Add(session.CpuFanId);
            await Add(session.AioId);

            return RedirectToAction("Index", "ShoppingCart");
        }
    }
}