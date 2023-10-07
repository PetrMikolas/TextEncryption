namespace TextEncryption.Models;

/// <summary>
/// Record for validation data
/// </summary>
/// <param name="IsValid">Bolean of the validation result</param>
/// <param name="Text">Output text</param>
public record Validation(bool IsValid, string Text);