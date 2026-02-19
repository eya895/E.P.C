using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E.P.C.Data;
using E.P.C.Models;
using E.P.C.Models.ViewModels;
using System.Linq;

namespace E.P.C.Controllers
{
    public class PcBuilderController : Controller
    {
        private readonly AppDbContext _context;

        public PcBuilderController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new PcBuildViewModel
            {
                CPUs = _context.Products.OfType<CPU>().ToList(),
                MotherBoards = _context.Products.OfType<MotherBoard>().ToList(),
                RAMs = _context.Products.OfType<RAM>().ToList(),
                GPUs = _context.Products.OfType<GPU>().ToList(),
                PSUs = _context.Products.OfType<PSU>().ToList(),
                Storages = _context.Products.OfType<Storage>().ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Build(PcBuildViewModel model)
        {
            var cpu = _context.Products.OfType<CPU>()
                .FirstOrDefault(x => x.Id == model.CpuId);

            var motherboard = _context.Products.OfType<MotherBoard>()
                .FirstOrDefault(x => x.Id == model.MotherboardId);

            var ram = _context.Products.OfType<RAM>()
                .FirstOrDefault(x => x.Id == model.RamId);

            var gpu = _context.Products.OfType<GPU>()
                .FirstOrDefault(x => x.Id == model.GpuId);

            var psu = _context.Products.OfType<PSU>()
                .FirstOrDefault(x => x.Id == model.PsuId);

            var storage = _context.Products.OfType<Storage>()
                .FirstOrDefault(x => x.Id == model.StorageId);

            // Compatibility Checks

            if (cpu != null && motherboard != null &&
                cpu.SocketType != motherboard.SocketType)
            {
                model.Errors.Add("CPU and Motherboard sockets do not match.");
            }

            if (ram != null && motherboard != null &&
                ram.Type != motherboard.RAMType)
            {
                model.Errors.Add("RAM type is not compatible with motherboard.");
            }

            if (gpu != null && psu != null &&
                psu.Wattage < gpu.TDP + 150)
            {
                model.Errors.Add("PSU wattage is too low for GPU.");
            }

            if (model.Errors.Any())
            {
                return View("Index", LoadLists(model));
            }

            model.TotalPrice =
                (cpu?.Price ?? 0) +
                (motherboard?.Price ?? 0) +
                (ram?.Price ?? 0) +
                (gpu?.Price ?? 0) +
                (psu?.Price ?? 0) +
                (storage?.Price ?? 0);

            return View("Summary", model);
        }

        private PcBuildViewModel LoadLists(PcBuildViewModel model)
        {
            model.CPUs = _context.Products.OfType<CPU>().ToList();
            model.MotherBoards = _context.Products.OfType<MotherBoard>().ToList();
            model.RAMs = _context.Products.OfType<RAM>().ToList();
            model.GPUs = _context.Products.OfType<GPU>().ToList();
            model.PSUs = _context.Products.OfType<PSU>().ToList();
            model.Storages = _context.Products.OfType<Storage>().ToList();
            return model;
        }
    }
}
