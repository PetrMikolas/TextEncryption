using TextEncryption.Enums;
using TextEncryption.Helpers;
using TextEncryption.Interfaces;
using TextEncryption.Models;

namespace TextEncryption.Services.MorseCode;

/// <summary>
/// Service for encrypting text into morse code and decrypting text from morse code
/// </summary>
internal class MorseCodeService : IMorseCodeService
{
    private readonly char[] _textChars = { ' ', ',', '.', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

    private readonly string[] _morseCodeChars = { " ", "--..--", ".-.-.-", ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--..", "-----", ".----", "..---", "...--", "....-", ".....", "-....", "--...", "---..", "----." };
        
	/// <summary>
	/// Encrypts plaintext
	/// </summary>
	/// <param name="plainText">Plain text</param>
	/// <returns>Ciphertext</returns>
	public string Encrypt(string? plainText)
    {
        string cipherText = string.Empty;
        var validation = ValidationPlainText(plainText);
        plainText = validation.Text;

        if (!validation.IsValid)
        {
            return validation.Text;
        }

        try
        {
            for (int i = 0; i < plainText.Length; i++)
            {
                for (int j = 0; j < _textChars.Length; j++)
                {
                    if (plainText[i] == _textChars[j])
                    {
                        cipherText += _morseCodeChars[j];
                        cipherText += "|";                    // space between each character of the morse code                              
					}
                }
            }
        }
        catch (Exception ex)
        {
            cipherText = ex.Message;
        }

        return cipherText;
    }

	/// <summary>
	/// Validates that the plain text is not empty and contains only allowed characters
	/// </summary>
	/// <param name="plainText">Plain text</param>
	/// <returns>If successful, returns true and plain text. Otherwise, it returns false and an error message</returns>
	private Validation ValidationPlainText(string? plainText)
    {
        bool isValid = false;

        if (string.IsNullOrWhiteSpace(plainText))
        {
            plainText = Helper.GetErrorMessage(Error.EmptyInputText);
			return new Validation(isValid, plainText);
        }

        try
        {
            plainText = plainText.Trim().ToLower();
            isValid = plainText.All(znak => _textChars.Any(x => x.Equals(znak)));

            if (!isValid)
            {
                plainText = Helper.GetErrorMessage(Error.InvalidInputText); 
            }
        }
        catch (Exception ex)
        {
            plainText = ex.Message;
        }

        return new Validation(isValid, plainText);
    }

	/// <summary>
	/// Decrypts ciphertext
	/// </summary>
	/// <param name="ciphertext">Ciphertext</param>
	/// <returns>Plain text</returns>     
	public string Decrypt(string? ciphertext)
    {
        string plainText = string.Empty;
        var validation = ValidationCipherText(ciphertext);
        ciphertext = validation.Text;
        string[] inputMorseCodeChars;

        if (!validation.IsValid)
        {
            return validation.Text;
        }

        try
        {
            inputMorseCodeChars = ciphertext.Split('|');

            for (int i = 0; i < inputMorseCodeChars.Length; i++)
            {
                for (int j = 0; j < _morseCodeChars.Length; j++)
                {
                    if (inputMorseCodeChars[i] == _morseCodeChars[j])
                    {
                        plainText += _textChars[j];
                    }
                }
            }
        }
        catch (Exception ex)
        {
            plainText = ex.Message;
        }

        return plainText;
    }

	/// <summary>
	/// Validates that the ciphertext is not empty and contains only allowed characters
	/// </summary>
	/// <param name="ciphertext">Ciphertext</param>
	/// <returns>If successful, returns true and plain text. Otherwise, returns false and an error message</returns>
	private Validation ValidationCipherText(string? ciphertext)
    {
        bool isValid = false;

        if (string.IsNullOrWhiteSpace(ciphertext))
        {
            ciphertext = Helper.GetErrorMessage(Error.EmptyInputText);
			return new Validation(isValid, ciphertext);
        }

        try
        {
            ciphertext = ciphertext.Trim();
            var inputMorseCodeChars = ciphertext.Split('|', StringSplitOptions.RemoveEmptyEntries).ToList();
            isValid = inputMorseCodeChars.All(character => _morseCodeChars.Any(x => x.Equals(character)));

            if (!isValid)
            {
                ciphertext = Helper.GetErrorMessage(Error.InvalidInputText);
            }
        }
        catch (Exception ex)
        {
            ciphertext = ex.Message;
        }

        return new Validation(isValid, ciphertext);
    }    	
}