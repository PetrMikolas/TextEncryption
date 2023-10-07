namespace TextEncryption.Enums;

/// <summary>
/// Encryption activity 
/// <list type="table">
/// <listheader>Options:</listheader>
/// <item>
/// <term>0</term>
/// <description>Encrypt</description>
/// </item>
/// <item>
/// <term>1</term>
/// <description>Decrypt</description>
/// </item>
/// </list>
/// </summary>
public enum EncryptionActivity
{
	/// <summary>
	/// Plain text encryption
	/// </summary>
	Encrypt,

	/// <summary>
	/// Ciphertext decryption
	/// </summary>
	Decrypt
}