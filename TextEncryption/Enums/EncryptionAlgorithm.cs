namespace TextEncryption.Enums;

/// <summary>
/// Encryption algorithm 
/// <list type="table">
/// <listheader>Options:</listheader>
/// <item>
/// <term>0</term>
/// <description>MorseCode</description>
/// </item>
/// <item>
/// <term>1</term>
/// <description>CaesarCipher</description>
/// </item>
/// </list>
/// </summary>
public enum EncryptionAlgorithm
{
	MorseCode = 0,
	CaesarCipher = 1
}