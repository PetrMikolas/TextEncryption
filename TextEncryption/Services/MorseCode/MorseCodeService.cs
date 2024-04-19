using TextEncryption.Enums;
using TextEncryption.Helpers;
using TextEncryption.Interfaces;
using TextEncryption.Models;

namespace TextEncryption.Services.MorseCode;

/// <summary>
/// Service for encrypting text into morse code and decrypting text from morse code
/// </summary>
internal sealed class MorseCodeService : IMorseCodeService
{
    /// <summary>
    /// Dictionary mapping characters to their Morse code representation
    /// </summary>
    private readonly Dictionary<char, string> _characterToMorseCode = new()
    {
        {' ', " "}, {',', "--..--"}, {'.', ".-.-.-"}, {'a', ".-"}, {'b', "-..."}, {'c', "-.-."},
        {'d', "-.."}, {'e', "."}, {'f', "..-."}, {'g', "--."}, {'h', "...."}, {'i', ".."}, {'j', ".---"},
        {'k', "-.-"}, {'l', ".-.."}, {'m', "--"}, {'n', "-."}, {'o', "---"}, {'p', ".--."}, {'q', "--.-"},
        {'r', ".-."}, {'s', "..."}, {'t', "-"}, {'u', "..-"}, {'v', "...-"}, {'w', ".--"}, {'x', "-..-"},
        {'y', "-.--"}, {'z', "--.."}, {'0', "-----"}, {'1', ".----"}, {'2', "..---"}, {'3', "...--"},
        {'4', "....-"}, {'5', "....."}, {'6', "-...."}, {'7', "--..."}, {'8', "---.."}, {'9', "----."}
    };

    /// <summary>
    /// Encrypts plaintext into Morse code
    /// </summary>
    /// <param name="plainText">Plain text</param>
    /// <returns>Ciphertext in Morse code</returns>
    public string Encrypt(string? plainText)
    {
        string cipherText = string.Empty;
        var validation = ValidationPlainText(plainText);

        if (!validation.IsValid)
        {
            return validation.Text;  // Return error message if plainText is invalid
        }

        try
        {
            // Convert each character of the plaintext to Morse code
            validation.Text.ToList().ForEach(character =>
            {
                if (_characterToMorseCode.TryGetValue(character, out string? morseCode))
                {
                    cipherText += morseCode + "|"; // Add Morse code representation of the character to the ciphertext, with pipe character between each Morse code sequence                                                            
                }
            });

            return cipherText;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    /// <summary>
    /// Validates that the plain text is not empty and contains only allowed characters
    /// </summary>
    /// <param name="plainText">Plain text</param>
    /// <returns>If successful, returns true and plain text. Otherwise, it returns false and an error message</returns>
    private Validation ValidationPlainText(string? plainText)
    {
        if (string.IsNullOrWhiteSpace(plainText))
        {
            var errorMessage = Helper.GetErrorMessage(Error.EmptyInputText);
            return new Validation(false, errorMessage);  // Return error message if plainText is null or empty
        }

        try
        {
            plainText = plainText.Trim().ToLower();
            var isValid = plainText.All(_characterToMorseCode.ContainsKey); // Check if all characters in the plain text are valid 

            if (!isValid)
            {
                plainText = Helper.GetErrorMessage(Error.InvalidInputText); // Return error message if plain text contains invalid characters
            }

            return new Validation(isValid, plainText);
        }
        catch (Exception ex)
        {
            return new Validation(false, ex.Message); // Handle any exceptions and return error message
        }
    }

    /// <summary>
    /// Decrypts Morse code ciphertext into plain text
    /// </summary>
    /// <param name="ciphertext">Ciphertext in Morse code</param>
    /// <returns>Decrypted plain text</returns> 
    public string Decrypt(string? ciphertext)
    {
        string plainText = string.Empty;
        var validation = ValidationCipherText(ciphertext);

        if (!validation.IsValid)
        {
            return validation.Text;  // Return error message if ciphertext is invalid
        }

        try
        {
            var inputMorseCodeChars = validation.Text.Split('|', StringSplitOptions.RemoveEmptyEntries).ToList();

            // Convert each Morse code character to its corresponding plain text character
            inputMorseCodeChars.ForEach(morseChar =>
            {
                var matchingChar = _characterToMorseCode.FirstOrDefault(x => x.Value == morseChar).Key;

                if (matchingChar != default) // Check if matching char found
                {
                    plainText += matchingChar;
                }
            });

            return plainText;
        }
        catch (Exception ex)
        {
            return ex.Message; // Handle any exceptions and return error message
        }
    }

    /// <summary>
    /// Validates that the ciphertext is not empty and contains only allowed characters
    /// </summary>
    /// <param name="ciphertext">Ciphertext in Morse code</param>
    /// <returns>If successful, returns true and plain text. Otherwise, returns false and an error message</returns>
    private Validation ValidationCipherText(string? ciphertext)
    {
        if (string.IsNullOrWhiteSpace(ciphertext))
        {
            var errorMessage = Helper.GetErrorMessage(Error.EmptyInputText);
            return new Validation(false, errorMessage);  // Return an error message if the ciphertext is null or empty
        }

        try
        {
            var inputMorseCodeChars = ciphertext.Trim().Split('|', StringSplitOptions.RemoveEmptyEntries);
            var isValid = inputMorseCodeChars.All(_characterToMorseCode.ContainsValue);  // Check if all Morse code characters are valid

            if (!isValid)
            {
                ciphertext = Helper.GetErrorMessage(Error.InvalidInputText);  // Return an error message if the ciphertext contains invalid Morse code characters
            }

            return new Validation(isValid, ciphertext);
        }
        catch (Exception ex)
        {
            return new Validation(false, ex.Message);  // Handle any exceptions and return an error message
        }
    }
}