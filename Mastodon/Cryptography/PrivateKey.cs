namespace Mastodon.Cryptography;

public sealed class PrivateKey {
    public readonly ReadOnlyMemory<byte> Value;

    public PrivateKey(byte[] value) {
        Value = value;
    }

    public PrivateKey(string hex) {
        this.Value = HashHelpers.StringToByteArray(hex);
    }

    public override string ToString() {
        return HashHelpers.ByteArrayToHexString(Value).ToUpper();
    }
}
