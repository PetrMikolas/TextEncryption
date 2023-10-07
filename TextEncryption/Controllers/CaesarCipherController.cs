using Microsoft.AspNetCore.Mvc;
using TextEncryption.Enums;
using TextEncryption.Helpers;
using TextEncryption.Interfaces;
using TextEncryption.Models;

namespace TextEncryption.Controllers;

public class CaesarCipherController : Controller
{
	private readonly IEncryptionAlgorithm _encryptionAlgorithm;

	public CaesarCipherController(IEncryptionAlgorithm encryptionAlgorithm)
	{
		_encryptionAlgorithm = encryptionAlgorithm;
	}

	public IActionResult Index()
	{
		var caesarCipher = new CaesarCipherModel()
		{
			Label = Helper.GetLabel(EncryptionActivity.Encrypt, EncryptionAlgorithm.CaesarCipher)
		};

		return View(caesarCipher);
	}

	[HttpPost]
	public IActionResult Index(CaesarCipherModel caesarCipher)
	{
		if (ModelState.IsValid)
		{
			caesarCipher.Label = Helper.GetLabel(caesarCipher.EncryptionActivity, EncryptionAlgorithm.CaesarCipher);

			if (caesarCipher.EncryptionActivity == EncryptionActivity.Encrypt && caesarCipher.Submit is not null)
			{
				caesarCipher.OutputText = _encryptionAlgorithm.CaesarCipher.Encrypt(caesarCipher.InputText, caesarCipher.Shift);
			}
			else if (caesarCipher.EncryptionActivity == EncryptionActivity.Decrypt && caesarCipher.Submit is not null)
			{
				caesarCipher.OutputText = _encryptionAlgorithm.CaesarCipher.Decrypt(caesarCipher.InputText, caesarCipher.Shift);
			}
		}

		return View(caesarCipher);
	}
}