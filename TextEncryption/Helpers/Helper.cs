using TextEncryption.Enums;
using TextEncryption.Models;

namespace TextEncryption.Helpers;

/// <summary>
/// Class for helper methods
/// </summary>
internal class Helper
{
	/// <summary>
	/// Gets label by encryption activity and encryption algorithm
	/// </summary>
	/// <param name="activity">Encryption activity</param>
	/// <param name="algorithm">Encryption algorithm</param>
	/// <returns>Object with labels for input and output text</returns>
	public static Label GetLabel(EncryptionActivity activity, EncryptionAlgorithm algorithm)
	{
		Label label = new();
		string outputTextEncrypt = "Šifrovaný text:";
		string outputTextDecrypt = "Dešifrovaný text:";

		if (activity == EncryptionActivity.Encrypt && algorithm == EncryptionAlgorithm.MorseCode)
		{
			label = new Label()
			{
				InputText = "Vložte text, který chcete šifrovat do Morseovy abecedy.<br />Pouze velká či malá písmena anglické abecedy, číslice, čárky, tečky a mezery.",
				OutputText = outputTextEncrypt,
			};
		}
		else if (activity == EncryptionActivity.Decrypt && algorithm == EncryptionAlgorithm.MorseCode)
		{
			label = new Label()
			{
				InputText = "Vložte šifrovaný text v Morseově abecedě, který chcete dešifrovat.<br />Jednotlivé znaky včetně mezer oddělujte znakem svislice: |",
				OutputText = outputTextDecrypt,
			};
		}
		else if (activity == EncryptionActivity.Encrypt && algorithm == EncryptionAlgorithm.CaesarCipher)
		{
			label = new Label()
			{
				InputText = "Vložte text, který chcete šifrovat do Caesarovy šifry.<br />Pouze malá písmena anglické abecedy, čárky, tečky a mezery.",
				OutputText = outputTextEncrypt,
			};
		}
		else if (activity == EncryptionActivity.Decrypt && algorithm == EncryptionAlgorithm.CaesarCipher)
		{
			label = new Label()
			{
				InputText = "Vložte šifrovaný text v Caesarově šifře, který chcete dešifrovat.",
				OutputText = outputTextDecrypt,
			};
		}

		return label;
	}

	/// <summary>
	/// Gets error message by error
	/// </summary>
	/// <param name="error"></param>
	/// <returns>Error message</returns>
	public static string GetErrorMessage(Error error)
	{
		string message = string.Empty;

		switch (error)
		{
			case Error.EmptyInputText: message = "Nebyl vložen text."; break;
			case Error.InvalidInputText: message = "Zadaný text obsahuje neplatné znaky."; break;
			case Error.InvalidShiftCipher: message = "Posun musí být v rozsahu 1 - 25."; break;
		}

		return message;
	}
}