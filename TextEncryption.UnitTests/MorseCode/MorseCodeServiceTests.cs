using TextEncryption.Interfaces;
using FluentAssertions;
using TextEncryption.Services.MorseCode;
using TextEncryption.Helpers;
using TextEncryption.Enums;

namespace TextEncryption.UnitTests.MorseCode;
public class MorseCodeServiceTests
{
	private IMorseCodeService _morseCodeService;
	private const string PLAIN_TEXT = "test";
	private const string CIPHER_TEXT = "-|.|...|-|";

	[SetUp]
	public void Setup()
	{
		_morseCodeService = new MorseCodeService();
	}

	[Test]
	public void Encrypt_Success()
	{
		// Arrange
		var plainText = PLAIN_TEXT;
		var expected = CIPHER_TEXT;

		// Act
		var result = _morseCodeService.Encrypt(plainText);

		// Assert
		result.Should().NotBeNull();
		result.Should().Be(expected);
	}

	[Test]
	public void Decrypt_Success()
	{
		// Arrange
		var cipherText = CIPHER_TEXT;
		var expected = PLAIN_TEXT;

		// Act
		var result = _morseCodeService.Decrypt(cipherText);

		// Assert
		result.Should().NotBeNull();
		result.Should().Be(expected);
	}

	[Test]
	public void Encrypt_InvalidPlainText()
	{
		// Arrange
		var plainText = "*";
		var expected = Helper.GetErrorMessage(Error.InvalidInputText);

		// Act
		var result = _morseCodeService.Encrypt(plainText);

		// Assert
		result.Should().NotBeNull();
		result.Should().Be(expected);
	}

	[Test]
	public void Decrypt_InvalidCipherText()
	{
		// Arrange
		var cipherText = "+";
		var expected = Helper.GetErrorMessage(Error.InvalidInputText);

		// Act
		var result = _morseCodeService.Decrypt(cipherText);

		// Assert
		result.Should().NotBeNull();
		result.Should().Be(expected);
	}

	[Test]
	public void Encrypt_EmptyPlainText()
	{
		// Arrange
		var plainText = string.Empty;
		var expected = Helper.GetErrorMessage(Error.EmptyInputText);

		// Act
		var result = _morseCodeService.Encrypt(plainText);

		// Assert
		result.Should().NotBeNull();
		result.Should().Be(expected);
	}

	[Test]
	public void Decrypt_EmptyCipherText()
	{
		// Arrange
		var cipherText = string.Empty;
		var expected = Helper.GetErrorMessage(Error.EmptyInputText);

		// Act
		var result = _morseCodeService.Decrypt(cipherText);

		// Assert
		result.Should().NotBeNull();
		result.Should().Be(expected);
	}
}