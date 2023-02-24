using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Math;
using System.Formats.Asn1;

namespace Mastodon.Cryptography;

public static class Secp256K1 {
    public readonly static X9ECParameters Curve = ECNamedCurveTable.GetByName("secp256k1");
    public readonly static ECDomainParameters DomainParams = new ECDomainParameters(Curve.Curve, Curve.G, Curve.N, Curve.H, Curve.GetSeed());

    public static PublicKey CreatePublicKey(PrivateKey privateKey, bool compressed) {
        var bn = new BigInteger(1, privateKey.Value.ToArray());
        var q = Curve.G.Multiply(bn);
        var publicParams = new ECPublicKeyParameters(q, DomainParams);

        return new PublicKey(publicParams.Q.GetEncoded(compressed));
    }

    public static byte[] GenerateSignature(PrivateKey privateKey, byte[] message) {
        var signer = new ECDsaSigner();

        var priv = new ECPrivateKeyParameters(new BigInteger(1, privateKey.Value.ToArray()), DomainParams);
        signer.Init(true, priv);
        var rs = signer.GenerateSignature(message);

        return ToDer(rs);
    }

    private static byte[] ToDer(BigInteger[] rs) {
        var der = new AsnWriter(AsnEncodingRules.DER);
        var seq = der.PushSequence();

        der.WriteIntegerUnsigned(rs[0].ToByteArrayUnsigned());
        der.WriteIntegerUnsigned(rs[1].ToByteArrayUnsigned());

        seq.Dispose();

        return der.Encode();
    }

    private static byte[] ToBytes(BigInteger[] rs) {
        var result = new byte[64];

        rs[0].ToByteArrayUnsigned().CopyTo(result, 0);
        rs[1].ToByteArrayUnsigned().CopyTo(result, 32);

        return result;
    }

    public static byte[] GenerateSignatureCompact(PrivateKey privateKey, byte[] message) {
        var signer = new ECDsaSigner(new HMacDsaKCalculator(new Org.BouncyCastle.Crypto.Digests.Sha256Digest()));

        var priv = new ECPrivateKeyParameters(new BigInteger(1, privateKey.Value.ToArray()), DomainParams);
        signer.Init(true, priv);
        var rs = signer.GenerateSignature(message);

        rs[1] = Curve.N.Subtract(rs[1]);

        return ToBytes(rs);
    }

    public static bool VerifySignature(PublicKey publicKey, byte[] message, byte[] signature) {
        var signer = new ECDsaSigner();

        var q = Curve.Curve.DecodePoint(publicKey.Value.ToArray());
        var pub = new ECPublicKeyParameters(q, DomainParams);
        signer.Init(false, pub);

        var der = new AsnReader(signature, AsnEncodingRules.DER);
        var seq = der.ReadSequence();

        var r = seq.ReadIntegerBytes();
        var s = seq.ReadIntegerBytes();

        var rr = new BigInteger(1, r.ToArray());
        var ss = new BigInteger(1, s.ToArray());


        var result = signer.VerifySignature(message, rr, ss);
        return result;
    }

    public static bool VerifySignatureCompact(PublicKey publicKey, byte[] message, byte[] signature) {
        var signer = new ECDsaSigner(new HMacDsaKCalculator(new Org.BouncyCastle.Crypto.Digests.Sha256Digest()));

        var q = Curve.Curve.DecodePoint(publicKey.Value.ToArray());
        var pub = new ECPublicKeyParameters(q, DomainParams);
        signer.Init(false, pub);

        var rr = new BigInteger(1, signature.Take(32).ToArray());
        var ss = new BigInteger(1, signature.Skip(32).ToArray());

        ss = Curve.N.Subtract(ss);

        var result = signer.VerifySignature(message, rr, ss);
        return result;
    }
}
