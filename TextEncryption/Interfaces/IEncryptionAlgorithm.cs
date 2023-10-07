namespace TextEncryption.Interfaces;

/// <summary>
/// Encryption service provider
/// </summary>
public interface IEncryptionAlgorithm
{
	/// <summary>
	/// Service for encrypting text into morse code and decrypting text from morse code
	/// </summary>
	internal IMorseCodeService MorseCode { get; }

	/// <summary>
	/// Service for encrypting text into caesar cipher and decrypting text from caesar cipher
	/// </summary>
	internal ICaesarCipherService CaesarCipher { get; }
}