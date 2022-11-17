namespace ForDem;

public static class BinaryReaderExtentions
{
    public static Int32 ReadInt32BE(this BinaryReader binRdr)
    {
        return BitConverter.ToInt32(binRdr.ReadBytes(sizeof(Int32)).Reverse().ToArray(), 0);
    }
}
