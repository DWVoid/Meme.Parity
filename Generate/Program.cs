using System.IO.Compression;

const uint limit = (uint.MaxValue / 8) + 1;
var lut = GC.AllocateUninitializedArray<byte>((int)limit);
for (var i = 0; i < limit; ++i) lut[i] = 0b01010101;
using var file = new FileStream("LUT", FileMode.Create);
using var gz1 = new GZipStream(file, CompressionLevel.SmallestSize);
using var gz2 = new GZipStream(gz1, CompressionLevel.SmallestSize);
using var gz3 = new GZipStream(gz2, CompressionLevel.SmallestSize);
using var gz4 = new GZipStream(gz3, CompressionLevel.SmallestSize);
gz4.Write(lut);
