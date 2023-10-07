namespace TextEncryption.Models;

/// <summary>
/// Label for input and output text
/// </summary>
public sealed class Label
{
	/// <summary>
	/// Gets or sets first label for input text
	/// </summary>
	public string InputText { get; set; } = string.Empty;
		

	/// <summary>
	/// Gets or sets label for output text
	/// </summary>
	public string OutputText { get; set; } = string.Empty;
}