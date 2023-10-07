namespace TextEncryption.Enums;

/// <summary>
/// Error 
/// <list type="table">
/// <listheader>Options:</listheader>
/// <item>
/// <term>0</term>
/// <description>EmptyInputText</description>
/// </item>
/// <item>
/// <term>1</term>
/// <description>InvalidInputText</description>
/// </item>
/// <item>
/// <term>1</term>
/// <description>InvalidShiptCipher</description>
/// </item>
/// </list>
/// </summary>
public enum Error
{
	EmptyInputText = 0,
	InvalidInputText = 1,
	InvalidShiftCipher = 2
}