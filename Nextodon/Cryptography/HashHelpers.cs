using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Nextodon.Cryptography;

public static class HashHelpers
{
    const string salt = "signed cookie";

    public static byte[] RubyCookieSign(string secretKeyBase, byte[] cookie)
    {
        var @base = Encoding.ASCII.GetBytes(secretKeyBase);
        var saltBytes = Encoding.ASCII.GetBytes(salt);
        var signKey = PBKDF2_SHA1(@base, saltBytes, 1000, 64);

        var result = HmacSha1Digest(cookie, signKey);

        return result;
    }

    public static byte[] RubyCookieSign(string secretKeyBase, string cookie)
    {
        var @base = Encoding.ASCII.GetBytes(secretKeyBase);
        var saltBytes = Encoding.ASCII.GetBytes(salt);
        var signKey = PBKDF2_SHA1(@base, saltBytes, 1000, 64);
        var cookieBytes = Encoding.ASCII.GetBytes(cookie);

        var result = HmacSha1Digest(cookieBytes, signKey);

        return result;
    }

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

    public static byte[] PBKDF2_SHA1(byte[] password, byte[] salt, int iterations, int hashByteSize)
    {
        var pdb = new Pkcs5S2ParametersGenerator(new Sha1Digest());
        pdb.Init(password, salt, iterations);
        var key = (KeyParameter)pdb.GenerateDerivedMacParameters(hashByteSize * 8);
        return key.GetKey();
    }

    public static byte[] HmacSha1Digest(byte[] input, byte[] key)
    {
        using var hmac = new HMACSHA1(key);
        return hmac.ComputeHash(input);
    }

    public static byte[] HmacSha1(byte[] input, byte[] key)
    {
        var hmac = new HMac(new Sha1Digest());
        hmac.Init(new KeyParameter(key));
        byte[] result = new byte[hmac.GetMacSize()];

        hmac.BlockUpdate(input, 0, input.Length);
        hmac.DoFinal(result, 0);

        return result;
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
