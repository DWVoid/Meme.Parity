using System.IO.Compression;
using System.Reflection;

if (uint.TryParse(Console.ReadLine()!, out var ul))
    Console.WriteLine((Decompress()[ul >> 3] & (1u << (int)(ul & 7u))) != 0 ? "even" : "odd");
else
    Console.WriteLine("input is not u32");

return;

static byte[] Decompress()
{
    var self = Assembly.GetExecutingAssembly();
    using var input = self.GetManifestResourceStream("Execute.LUT")!;
    var result = GC.AllocateUninitializedArray<byte>((int)(uint.MaxValue / 8) + 1);
    using var t1 = new GZipStream(input, CompressionMode.Decompress);
    using var t2 = new GZipStream(t1, CompressionMode.Decompress);
    using var t3 = new GZipStream(t2, CompressionMode.Decompress);
    using var t4 = new GZipStream(t3, CompressionMode.Decompress);
    using var output = new MemoryStream(result);
    t4.CopyTo(output);
    return result;
}