using E.P.C.Models;
using E.P.C.Models.ViewModels;

namespace E.P.C.Services
{
    public static class CompatibilityService
    {
        public static List<CompatibilityIssue> Check(PcBuildSession s)
        {
            var issues = new List<CompatibilityIssue>();

            // ── 1. CPU ↔ Motherboard socket ───────────────────────────────
            if (s.Cpu != null && s.Motherboard != null)
            {
                if (!string.IsNullOrEmpty(s.Cpu.SocketType) &&
                    !string.IsNullOrEmpty(s.Motherboard.SocketType) &&
                    !s.Cpu.SocketType.Equals(s.Motherboard.SocketType, StringComparison.OrdinalIgnoreCase))
                {
                    issues.Add(new CompatibilityIssue(
                        Severity.Error,
                        "CPU / Motherboard",
                        $"Socket mismatch: CPU uses {s.Cpu.SocketType} but motherboard uses {s.Motherboard.SocketType}."
                    ));
                }
            }

            // ── 2. RAM type ↔ Motherboard RAM type ────────────────────────
            if (s.Ram != null && s.Motherboard != null)
            {
                if (!string.IsNullOrEmpty(s.Ram.Type) &&
                    !string.IsNullOrEmpty(s.Motherboard.RAMType) &&
                    !s.Ram.Type.Equals(s.Motherboard.RAMType, StringComparison.OrdinalIgnoreCase))
                {
                    issues.Add(new CompatibilityIssue(
                        Severity.Error,
                        "RAM / Motherboard",
                        $"RAM type mismatch: RAM is {s.Ram.Type} but motherboard supports {s.Motherboard.RAMType}."
                    ));
                }
            }

            // ── 3. RAM capacity ↔ Motherboard max RAM ─────────────────────
            if (s.Ram != null && s.Motherboard != null)
            {
                if (s.Motherboard.MaxRAMCapacity > 0 &&
                    s.Ram.Capacity > s.Motherboard.MaxRAMCapacity)
                {
                    issues.Add(new CompatibilityIssue(
                        Severity.Error,
                        "RAM / Motherboard",
                        $"RAM capacity ({s.Ram.Capacity} GB) exceeds motherboard maximum ({s.Motherboard.MaxRAMCapacity} GB)."
                    ));
                }
            }

            // ── 4. PSU wattage vs estimated system TDP ────────────────────
            if (s.Psu != null)
            {
                int estimatedTdp = 0;
                if (s.Gpu != null) estimatedTdp += s.Gpu.TDP;
                if (s.Cpu != null) estimatedTdp += 125; // conservative CPU budget
                estimatedTdp += 50;                       // mobo + RAM + storage overhead

                int recommended = (int)(estimatedTdp * 1.25); // 25 % headroom

                if (s.Psu.Wattage > 0 && s.Psu.Wattage < recommended)
                {
                    issues.Add(new CompatibilityIssue(
                        Severity.Error,
                        "PSU",
                        $"PSU ({s.Psu.Wattage} W) may be insufficient. Estimated system draw ~{estimatedTdp} W; recommended ≥{recommended} W."
                    ));
                }
                else if (s.Psu.Wattage > 0 && s.Psu.Wattage < estimatedTdp + 100)
                {
                    issues.Add(new CompatibilityIssue(
                        Severity.Warning,
                        "PSU",
                        $"PSU ({s.Psu.Wattage} W) is tight. Consider a higher-wattage unit for better headroom."
                    ));
                }
            }

            // ── 5. GPU length ↔ Case max GPU length ───────────────────────
            if (s.Gpu != null && s.Case != null)
            {
                // GPU dimensions stored as "LxWxH mm" – parse first number
                if (TryParseFirstMm(s.Gpu.dimensions, out int gpuLen) &&
                    s.Case.MaxGPULength > 0 &&
                    gpuLen > s.Case.MaxGPULength)
                {
                    issues.Add(new CompatibilityIssue(
                        Severity.Error,
                        "GPU / Case",
                        $"GPU length ({gpuLen} mm) exceeds case maximum ({s.Case.MaxGPULength} mm)."
                    ));
                }
            }

            // ── 6. CPU cooler ↔ Case CPU cooler height ────────────────────
            if (s.CpuFan != null && s.Case != null)
            {
                if (s.CpuFan.Size > 0 &&
                    s.Case.MaxCPUCoolerHeight > 0 &&
                    s.CpuFan.Size > s.Case.MaxCPUCoolerHeight)
                {
                    issues.Add(new CompatibilityIssue(
                        Severity.Error,
                        "CPU Fan / Case",
                        $"CPU fan height ({s.CpuFan.Size} mm) exceeds case clearance ({s.Case.MaxCPUCoolerHeight} mm)."
                    ));
                }
            }

            // ── 7. CPU socket ↔ CPU fan supported sockets ─────────────────
            if (s.Cpu != null && s.CpuFan != null)
            {
                if (!string.IsNullOrEmpty(s.Cpu.SocketType) &&
                    !string.IsNullOrEmpty(s.CpuFan.SupportedSockets) &&
                    !SocketSupported(s.Cpu.SocketType, s.CpuFan.SupportedSockets))
                {
                    issues.Add(new CompatibilityIssue(
                        Severity.Error,
                        "CPU / CPU Fan",
                        $"CPU fan does not support socket {s.Cpu.SocketType}. Supported: {s.CpuFan.SupportedSockets}."
                    ));
                }
            }

            // ── 8. CPU socket ↔ AIO supported sockets ─────────────────────
            if (s.Cpu != null && s.Aio != null)
            {
                if (!string.IsNullOrEmpty(s.Cpu.SocketType) &&
                    !string.IsNullOrEmpty(s.Aio.SupportedSockets) &&
                    !SocketSupported(s.Cpu.SocketType, s.Aio.SupportedSockets))
                {
                    issues.Add(new CompatibilityIssue(
                        Severity.Error,
                        "CPU / AIO",
                        $"AIO does not support socket {s.Cpu.SocketType}. Supported: {s.Aio.SupportedSockets}."
                    ));
                }
            }

            // ── 9. Motherboard / Case form factor ─────────────────────────
            if (s.Motherboard != null && s.Case != null)
            {
                if (!string.IsNullOrEmpty(s.Motherboard.FormFactor) &&
                    !string.IsNullOrEmpty(s.Case.FormFactor) &&
                    !FormFactorFits(s.Motherboard.FormFactor, s.Case.FormFactor))
                {
                    issues.Add(new CompatibilityIssue(
                        Severity.Error,
                        "Motherboard / Case",
                        $"Motherboard form factor ({s.Motherboard.FormFactor}) does not fit in case ({s.Case.FormFactor})."
                    ));
                }
            }

            // ── 10. No CPU cooler selected (warning) ──────────────────────
            if (s.Cpu != null && s.CpuFan == null && s.Aio == null)
            {
                // Only warn if CPU doesn't have integrated graphics (fanless builds
                // are rare but valid; we just flag it as a reminder)
                issues.Add(new CompatibilityIssue(
                    Severity.Warning,
                    "CPU Cooling",
                    "No CPU cooler selected. Make sure to add a CPU fan or AIO cooler."
                ));
            }

            return issues;
        }

        // ── helpers ──────────────────────────────────────────────────────

        private static bool SocketSupported(string socket, string supportedList) =>
            supportedList.Split(',', StringSplitOptions.RemoveEmptyEntries)
                         .Select(s => s.Trim())
                         .Any(s => s.Equals(socket, StringComparison.OrdinalIgnoreCase));

        private static bool TryParseFirstMm(string dimensions, out int mm)
        {
            mm = 0;
            if (string.IsNullOrEmpty(dimensions)) return false;
            var part = dimensions.Split(new[] { 'x', 'X', '×', ' ' },
                            StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
            return part != null && int.TryParse(
                new string(part.Where(char.IsDigit).ToArray()), out mm);
        }

        // ATX fits ATX cases; Micro-ATX fits ATX and Micro-ATX; Mini-ITX fits all
        private static readonly Dictionary<string, int> _ffRank = new(StringComparer.OrdinalIgnoreCase)
        {
            ["Mini-ITX"] = 1,
            ["Micro-ATX"] = 2,
            ["mATX"] = 2,
            ["ATX"] = 3,
            ["E-ATX"] = 4
        };

        private static bool FormFactorFits(string moboFf, string caseFf)
        {
            if (!_ffRank.TryGetValue(moboFf, out int mobo)) return true; // unknown – don't block
            if (!_ffRank.TryGetValue(caseFf, out int cas)) return true;
            return mobo <= cas; // mobo must be same size or smaller than case
        }
    }

    public enum Severity { Warning, Error }

    public class CompatibilityIssue
    {
        public Severity Severity { get; }
        public string Component { get; }
        public string Message { get; }
        public CompatibilityIssue(Severity severity, string component, string message)
        {
            Severity = severity; Component = component; Message = message;
        }
    }
}
