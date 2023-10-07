using TextEncryption.Interfaces;

namespace TextEncryption.Services;

/// <summary>
/// Encryption service provider
/// </summary>
internal class EncryptionAlgorithm : IEncryptionAlgorithm
{
	public EncryptionAlgorithm(IMorseCodeService morseCodeService, ICaesarCipherService caesarCipherService)
	{
		MorseCode = morseCodeService;
		CaesarCipher = caesarCipherService;
	}

	/// <summary>
	/// Morse code encryption service
	/// </summary>
	public IMorseCodeService MorseCode { get; }

	/// <summary>
	/// Caesar cipher encryption service
	/// </summary>
	public ICaesarCipherService CaesarCipher { get; }
}