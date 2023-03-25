using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using System.Text;

namespace Nextodon.Cryptography;

public static class HashHelpers
{
    public static byte[] Hash160(byte[] input)
    {
        var digest = new RipeMD160Digest();
        var result = new byte[digest.GetDigestSize()];
        digest.BlockUpdate(input, 0, input.Length);
        digest.DoFinal(result, 0);

        return result;
    }

    public static byte[] SHA256(byte[] input)
    {
        var digest = new Sha256Digest();
        var result = new byte[digest.GetDigestSize()];
        digest.BlockUpdate(input, 0, input.Length);
        digest.DoFinal(result, 0);

        return result;
    }

    public static byte[] Keccak(byte[] input)
    {
        var digest = new KeccakDigest(256);
        var result = new byte[digest.GetDigestSize()];
        digest.BlockUpdate(input, 0, input.Length);
        digest.DoFinal(result, 0);

        return result;
    }

    public static byte[] Process(this IDigest digest, byte[] input)
    {
        var result = new byte[digest.GetDigestSize()];
        digest.BlockUpdate(input, 0, input.Length);
        digest.DoFinal(result, 0);

        return result;
    }

    public static byte[] Keccak(string hex)
    {
        return Keccak(StringToByteArray(hex));
    }

    public static string ToChecksumAddress(string data)
    {
        var o = new char[data.Length];
        var w = Encoding.ASCII.GetBytes(data.ToLower().ToCharArray());
        var sha = ByteArrayToHexString(HashHelpers.Keccak(w));

        for (int i = 0; i < data.Length; i++)
        {
            var n = int.Parse(sha[i].ToString(), System.Globalization.NumberStyles.HexNumber);
            if (n > 8)
            {
                o[i] = char.ToUpper(data[i]);
            }
            else
            {
                o[i] = char.ToLower(data[i]);
            }
        }

        return new string(o);
    }

    public static byte[] StringToByteArray(string hex)
    {
        return Enumerable.Range(0, hex.Length)
                         .Where(x => x % 2 == 0)
                         .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                         .ToArray();
    }

    public static string ByteArrayToHexString(byte[] bytes)
    {
        Span<byte> span = bytes;
        return ByteArrayToHexString(span);
    }

    public static string ByteArrayToHexString(ReadOnlyMemory<byte> bytes)
    {
        return ByteArrayToHexString(bytes.Span);
    }

    public static string ByteArrayToHexString(ReadOnlySpan<byte> bytes)
    {
        var result = new StringBuilder(bytes.Length * 2);
        const string HexAlphabet = "0123456789ABCDEF";

        foreach (byte b in bytes)
        {
            result.Append(HexAlphabet[(int)(b >> 4)]);
            result.Append(HexAlphabet[(int)(b & 0xF)]);
        }

        return result.ToString();
    }

    public static byte[] HmacSha512Digest(byte[] input, byte[] hmacKey)
    {
        using var hmac = new System.Security.Cryptography.HMACSHA512(hmacKey);
        return hmac.ComputeHash(input);
    }

    public static byte[] Blake2b244(byte[] input)
    {
        var digest = new Blake2bDigest(28);
        var result = new byte[digest.GetDigestSize()];
        digest.BlockUpdate(input, 0, input.Length);
        digest.DoFinal(result, 0);

        return result;
    }

    public static byte[] Blake2b256(byte[] input)
    {
        var digest = new Blake2bDigest(32);
        var result = new byte[digest.GetDigestSize()];
        digest.BlockUpdate(input, 0, input.Length);
        digest.DoFinal(result, 0);

        return result;
    }

    ///public static ushort XModem(byte[] input) => CRC16.XModem(input);


    //public static byte[] EncodeEd25519(byte[] input, byte version)
    //{
    //    var payload = new byte[] { version }.Concat(input).ToArray();
    //    var crc = HashHelpers.XModem(payload);
    //    payload = payload.Concat(BitConverter.GetBytes(crc)).ToArray();
    //    return payload;
    //}

}
