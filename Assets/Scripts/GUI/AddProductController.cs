using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;

public class AddProductController : MonoBehaviour {
  public InputField productName;
  public Button okButton;
  public Button cancelButton;
  public Canvas canvas;

  void Start()
  {
    okButton.onClick.AddListener(SaveName);
    cancelButton.onClick.AddListener(Close);

    productName.onEndEdit.AddListener(ValidateText);
    productName.onValueChanged.AddListener(ValidateText);
    productName.text = PlayerPrefs.GetString(PlayerStats.PrefName);

    canvas.enabled = false;
  }

    public void ValidateText(string value)
    {
        var trimmed = Regex.Replace(value, @"[^a-zA-Z0-9 ]", "");;
        if (trimmed.Length > 15)
        {
            trimmed = trimmed.Remove(15);
        }
        productName.text = trimmed;
    }

    public void SaveName()
    {
        PlayerPrefs.SetString(PlayerStats.PrefName, productName.text);
        GameMenu.nameChanged = true;
        Close();
    }

    public void Close()
    {
        canvas.enabled = false;
    }
}