using FluentAssertions;
using TextEncryption.Enums;
using TextEncryption.Helpers;
using TextEncryption.Interfaces;
using TextEncryption.Services.CaesarCipher;

namespace TextEncryption.UnitTests.CaesarCipher;
public class CaesarCipherServiceTests
{
	private ICaesarCipherService _caesarCipherService;
	private const string PLAIN_TEXT = "abcd";
	private const string CIPHER_TEXT = "cdef";
	private const int SHIFT = 2;

	[SetUp]
	public void Setup()
	{
		_caesarCipherService = new CaesarCipherService();
	}

	[Test]
	public void Encrypt_Success()
	{
		// Arrange
		var plainText = PLAIN_TEXT;
		var shift = SHIFT;
		var expected = CIPHER_TEXT;

		// Act
		var result = _caesarCipherService.Encrypt(plainText, shift);

		// Assert
		result.Should().NotBeNull();
		result.Should().Be(expected);
	}

	[Test]
	public void Decrypt_Success()
	{
		// Arrange
		var cipherText = CIPHER_TEXT;
		var shift = SHIFT;
		var expected = PLAIN_TEXT;

		// Act
		var result = _caesarCipherService.Decrypt(cipherText, shift);

		// Assert
		result.Should().NotBeNull();
		result.Should().Be(expected);
	}

	[Test]
	public void Encrypt_InvalidPlainText()
	{
		// Arrange
		var plainText = "1";
		var shift = SHIFT;
		var expected = Helper.GetErrorMessage(Error.InvalidInputText);

		// Act
		var result = _caesarCipherService.Encrypt(plainText, shift);

		// Assert
		result.Should().NotBeNull();
		result.Should().Be(expected);
	}

	[Test]
	public void Decrypt_InvalidCipherText()
	{
		// Arrange
		var cipherText = "1";
		var shift = SHIFT;
		var expected = Helper.GetErrorMessage(Error.InvalidInputText);

		// Act
		var result = _caesarCipherService.Decrypt(cipherText, shift);

		// Assert
		result.Should().NotBeNull();
		result.Should().Be(expected);
	}

	[Test]
	public void Encrypt_InvalidShift()
	{
		// Arrange
		var plainText = PLAIN_TEXT;
		var shift = 0;
		var expected = Helper.GetErrorMessage(Error.InvalidShiftCipher);

		// Act
		var result = _caesarCipherService.Encrypt(plainText, shift);

		// Assert
		result.Should().NotBeNull();
		result.Should().Be(expected);
	}

	[Test]
	public void Decrypt_InvalidShift()
	{
		// Arrange
		var cipherText = CIPHER_TEXT;
		var shift = 26;
		var expected = Helper.GetErrorMessage(Error.InvalidShiftCipher);

		// Act
		var result = _caesarCipherService.Decrypt(cipherText, shift);

		// Assert
		result.Should().NotBeNull();
		result.Should().Be(expected);
	}

	[Test]
	public void Encrypt_InvalidPlainTextAndInvalidShift()
	{
		// Arrange
		var plainText = "*";
		var shift = 0;
		var expected = $"{Helper.GetErrorMessage(Error.InvalidInputText)} {Helper.GetErrorMessage(Error.InvalidShiftCipher)}";

		// Act
		var result = _caesarCipherService.Encrypt(plainText, shift);

		// Assert
		result.Should().NotBeNull();
		result.Should().Be(expected);
	}

	[Test]
	public void Decrypt_InvalidPlainTextAndInvalidShift()
	{
		// Arrange
		var cipherText = "*";
		var shift = 0;
		var expected = $"{Helper.GetErrorMessage(Error.InvalidInputText)} {Helper.GetErrorMessage(Error.InvalidShiftCipher)}";

		// Act
		var result = _caesarCipherService.Decrypt(cipherText, shift);

		// Assert
		result.Should().NotBeNull();
		result.Should().Be(expected);
	}
}