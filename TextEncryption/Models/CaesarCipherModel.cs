namespace TextEncryption.Models;

/// <summary>
/// Model for caesar cipher
/// </summary>
public sealed class CaesarCipherModel : EncryptionAlgorithmBaseModel
{
	/// <summary>
	/// Gets or sets number of shift 
	/// </summary>	
	public int Shift { get; set; } = 1;	
}