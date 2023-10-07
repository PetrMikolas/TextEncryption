namespace TextEncryption.Interfaces;

/// <summary>
/// Service for encrypting text into caesar cipher and decrypting text from caesar cipher
/// </summary>
internal interface ICaesarCipherService
{
	/// <summary>
	/// Encrypts plaintext
	/// </summary>
	/// <param name="plainText">Plain text</param>
	/// <param name="shift">Shift cipher</param>
	/// <returns>Ciphertext</returns>
	string Encrypt(string? plainText, int shift);

	/// <summary>
	/// Decrypts ciphertext
	/// </summary>
	/// <param name="ciphertext">Ciphertext</param>
	/// <param name="shift">Shift cipher</param>
	/// <returns>Plain text</returns>
	string Decrypt(string? ciphertext, int shift);
}