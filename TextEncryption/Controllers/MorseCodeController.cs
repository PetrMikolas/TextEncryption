using Microsoft.AspNetCore.Mvc;
using TextEncryption.Enums;
using TextEncryption.Helpers;
using TextEncryption.Interfaces;
using TextEncryption.Models;

namespace TextEncryption.Controllers;

public class MorseCodeController : Controller
{
	private readonly IEncryptionAlgorithm _encryptionAlgorithm;

	public MorseCodeController(IEncryptionAlgorithm encryptionAlgorithm)
	{
		_encryptionAlgorithm = encryptionAlgorithm;
	}

	public IActionResult Index()
	{
		var morseCode = new MorseCodeModel
		{			
			Label = Helper.GetLabel(EncryptionActivity.Encrypt, EncryptionAlgorithm.MorseCode)
		};

		return View(morseCode);
	}

	[HttpPost]
	public IActionResult Index(MorseCodeModel morseCode)
	{
		if (ModelState.IsValid)
		{
			morseCode.Label = Helper.GetLabel(morseCode.EncryptionActivity, EncryptionAlgorithm.MorseCode);

			if (morseCode.EncryptionActivity == EncryptionActivity.Encrypt && morseCode.Submit is not null)
			{
				morseCode.OutputText = _encryptionAlgorithm.MorseCode.Encrypt(morseCode.InputText);
			}
			else if (morseCode.EncryptionActivity == EncryptionActivity.Decrypt && morseCode.Submit is not null)
			{
				morseCode.OutputText = _encryptionAlgorithm.MorseCode.Decrypt(morseCode.InputText);
			}
		}

		return View(morseCode);
	}
}