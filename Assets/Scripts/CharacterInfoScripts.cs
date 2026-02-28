using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class CharacterInfoUI : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text ageText;
    public TMP_Text birthYearErrorText;
    public TMP_InputField nameField;
    public TMP_InputField ageField;
    public Button startGameButton;

    private void OnEnable()
    {
        if (nameField != null)
        {
            nameField.onValueChanged.AddListener(OnInputChanged);
        }

        if (ageField != null)
        {
            ageField.onValueChanged.AddListener(OnInputChanged);
        }

        ValidateAndToggleStartButton();
    }

    private void OnDisable()
    {
        if (nameField != null)
        {
            nameField.onValueChanged.RemoveListener(OnInputChanged);
        }

        if (ageField != null)
        {
            ageField.onValueChanged.RemoveListener(OnInputChanged);
        }
    }

    void Start()
    {
        ShowPlayerData();
        ValidateAndToggleStartButton();
    }

    private void OnInputChanged(string _)
    {
        ValidateAndToggleStartButton();
    }

    public bool SavePlayerDataFromInputs()
    {
        if (!TryGetValidatedData(out string validName, out int validAge))
        {
            return false;
        }

        PlayerData.playerName = validName;
        PlayerData.playerAge = validAge;
        return true;
    }

    public bool HasInputFields()
    {
        return nameField != null && ageField != null;
    }

    private bool TryGetValidatedData(out string validName, out int validAge)
    {
        validName = string.Empty;
        validAge = 0;

        if (nameField == null || ageField == null)
        {
            return false;
        }

        validName = nameField.text != null ? nameField.text.Trim() : string.Empty;
        if (string.IsNullOrEmpty(validName))
        {
            return false;
        }

        if (!int.TryParse(ageField.text, out int birthYear))
        {
            return false;
        }

        int age = DateTime.Now.Year - birthYear;
        if (age < 1 || age > 100)
        {
            return false;
        }

        validAge = age;
        return true;
    }

    public void ValidateAndToggleStartButton()
    {
        UpdateBirthYearError();

        if (startGameButton == null)
        {
            return;
        }

        startGameButton.interactable = TryGetValidatedData(out _, out _);
    }

    private void UpdateBirthYearError()
    {
        if (birthYearErrorText == null)
        {
            return;
        }

        if (ageField == null || string.IsNullOrWhiteSpace(ageField.text))
        {
            birthYearErrorText.gameObject.SetActive(false);
            return;
        }

        bool isNumber = int.TryParse(ageField.text, out int birthYear);
        if (!isNumber)
        {
            birthYearErrorText.gameObject.SetActive(true);
            birthYearErrorText.text = "Enter a valid year of birth";
            return;
        }

        int age = DateTime.Now.Year - birthYear;
        bool validAgeRange = age >= 1 && age <= 100;
        birthYearErrorText.gameObject.SetActive(!validAgeRange);

        if (!validAgeRange)
        {
            birthYearErrorText.text = "Age must be between 1 and 100 years";
        }
    }

    public void ShowPlayerData()
    {
        if (nameText != null)
        {
            nameText.text = "Name: " + PlayerData.playerName;
        }

        if (ageText != null)
        {
            ageText.text = "Age: " + PlayerData.playerAge;
        }
    }
}
