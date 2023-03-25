namespace Nextodon.Cryptography;

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

    public string ToEthereumAddress()
    {
        var pk = this.Uncompress();

        var input = pk.Value[1..];
        var address = Cryptography.HashHelpers.Keccak(input.ToArray());
        var w = address.Skip(address.Length - 20).ToArray();

        var h = HashHelpers.ByteArrayToHexString(w).ToUpper();
        return h;
    }

    public override string ToString()
    {
        return HashHelpers.ByteArrayToHexString(Value).ToUpper();
    }
}
