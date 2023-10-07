using TextEncryption.Enums;
using TextEncryption.Interfaces;
using TextEncryption.Models;
using System.Text.RegularExpressions;
using TextEncryption.Helpers;

namespace TextEncryption.Services.CaesarCipher;

/// <summary>
/// Service for encrypting text into caesar cipher and decrypting text from caesar cipher
/// </summary>
internal class CaesarCipherService : ICaesarCipherService
{
	/// <summary>
	/// Encrypts plaintext
	/// </summary>
	/// <param name="plainText">Plain text</param>
	/// <param name="shift">Shift cipher</param>
	/// <returns>Ciphertext</returns>       
	public string Encrypt(string? plainText, int shift)
	{
		var validation = Validation(plainText, shift);

		if (!validation.IsValid)
		{
			return validation.Text;
		}

		return EncryptionProcessor(validation.Text, shift, EncryptionActivity.Encrypt);
	}

	/// <summary>
	/// Decrypts ciphertext
	/// </summary>
	/// <param name="ciphertext">Ciphertext</param>
	/// <param name="shift">Shift cipher</param>
	/// <returns>Plain text</returns>       
	public string Decrypt(string? ciphertext, int shift)
	{
		var validation = Validation(ciphertext, shift);

		if (!validation.IsValid)
		{
			return validation.Text;
		}

		return EncryptionProcessor(validation.Text, shift, EncryptionActivity.Decrypt);
	}

	/// <summary>
	/// Processor for encrypting the Caesar cipher
	/// </summary>
	/// <param name="text">Input text</param>
	/// <param name="shift">Shift cipher</param>
	/// <param name="activity">Encryption activity</param>
	/// <returns>If successful, it will return the encrypted or decrypted text. Otherwise it returns an error message.</returns>
	private string EncryptionProcessor(string text, int shift, EncryptionActivity activity)
	{
		char character;
		string outputText = string.Empty;

		try
		{
			for (int i = 0; i < text.Length; i++)
			{
				character = char.Parse(text.Substring(i, 1));

				if (character == 32)
				{
					character = ' ';
				}
				else if (character == 44)
				{
					character = ',';
				}
				else if (character == 46)
				{
					character = '.';
				}
				else if (activity == EncryptionActivity.Encrypt && character + shift > 122)
				{
					character = Convert.ToChar(character + shift - 26);
				}
				else if (activity == EncryptionActivity.Decrypt && character - shift < 97)
				{
					character = Convert.ToChar(character - shift + 26);
				}
				else if (activity == EncryptionActivity.Encrypt)
				{
					character = Convert.ToChar(character + shift);
				}
				else if (activity == EncryptionActivity.Decrypt)
				{
					character = Convert.ToChar(character - shift);
				}

				outputText += character;
			}
		}
		catch (Exception ex)
		{
			outputText = ex.Message;
		}

		return outputText;
	}

	/// <summary>
	/// Validates that the input text is not empty and contains only allowed characters
	/// </summary>
	/// <param name="text">Input text</param>
	/// <returns>If successful, returns true and input text. Otherwise, returns false and an error message</returns>
	private Validation ValidationText(string? text)
	{
		if (string.IsNullOrWhiteSpace(text))
		{
			text = Helper.GetErrorMessage(Error.EmptyInputText);
			return new Validation(false, text);
		}

		try
		{
			text = text.Trim();
			string pattern = @"^[a-z|\.|\,|\ ]*$";
			bool isValid = Regex.IsMatch(text, pattern);

			if (!isValid)
			{
				text = Helper.GetErrorMessage(Error.InvalidInputText);
				return new Validation(false, text);
			}
		}
		catch (Exception ex)
		{
			text = ex.Message;
		}

		return new Validation(true, text);
	}

	/// <summary>
	/// Validates that shift cipher is in the range 1 - 25
	/// </summary>
	/// <param name="shift">Shift cipher</param>
	/// <returns>If successful, returns true and string empty. Otherwise, returns false and an error message</returns>
	private Validation ValidationShiftCipher(int shift)
	{
		if (shift < 1 || shift > 25)
		{
			string errorMessage = Helper.GetErrorMessage(Error.InvalidShiftCipher);
			return new Validation(false, errorMessage);
		}

		return new Validation(true, string.Empty);
	}

	private Validation Validation(string? text, int shift)
	{
		var validationText = ValidationText(text);
		var validationShift = ValidationShiftCipher(shift);

		if (!validationText.IsValid && validationShift.IsValid)
		{
			return new Validation(false, validationText.Text);
		}
		else if (validationText.IsValid && !validationShift.IsValid)
		{
			return new Validation(false, validationShift.Text);
		}
		else if (!validationText.IsValid && !validationShift.IsValid)
		{
			string errorMessage = $"{validationText.Text} {validationShift.Text}";
			return new Validation(false, errorMessage);
		}

		return new Validation(true, validationText.Text);
	}

}