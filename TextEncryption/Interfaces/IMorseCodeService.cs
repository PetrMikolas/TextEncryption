namespace TextEncryption.Interfaces;

/// <summary>
/// Service for encrypting text into morse code and decrypting text from morse code
/// </summary>
internal interface IMorseCodeService
{
    /// <summary>
    /// Encrypts plaintext
    /// </summary>
    /// <param name="plainText">Plain text</param>
    /// <returns>Ciphertext</returns>
    string Encrypt(string? plainText);

    /// <summary>
    /// Decrypts ciphertext
    /// </summary>
    /// <param name="ciphertext">Ciphertext</param>
    /// <returns>Plain text</returns>
    string Decrypt(string? ciphertext);    	
}