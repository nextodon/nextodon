namespace ForDem.Cryptography;

public sealed class PublicKey
{
    public readonly ReadOnlyMemory<byte> Value;

    /// <summary>
    /// Encoded data must either begin with 0x02 (for even), 0x03 (for odd) or 0x04 (for uncompressed).
    /// </summary>
    /// <param name="value">Encoded data</param>
    public PublicKey(byte[] value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return HashHelpers.ByteArrayToHexString(Value).ToUpper();
    }
}
