using TextEncryption.Enums;

namespace TextEncryption.Models;

/// <summary>
/// Base model for encryption models 
/// </summary>
public abstract class EncryptionAlgorithmBaseModel
{
	/// <summary>
	/// Gets or sets input text
	/// </summary>
	public string? InputText { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets output text
	/// </summary>
	public string OutputText { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets encryption activity 
	/// </summary>
	public EncryptionActivity EncryptionActivity { get; set; }

	/// <summary>
	/// Gets or sets labels
	/// </summary>
	public Label Label { get; set; } = new Label();

	/// <summary>
	/// Gets or sets text of button submit
	/// </summary>
	public string? Submit { get; set; } = null;
}