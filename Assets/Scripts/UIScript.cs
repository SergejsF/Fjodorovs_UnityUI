using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject[] characters;
    public TMP_Dropdown linkedDropdown;
    public Dropdown linkedLegacyDropdown;
    public bool applySelectionOnEnable = true;
    public int defaultIndex;

    private void OnEnable()
    {
        if (linkedDropdown != null)
        {
            linkedDropdown.onValueChanged.RemoveListener(ChangeCharacter);
            linkedDropdown.onValueChanged.AddListener(ChangeCharacter);

            if (applySelectionOnEnable)
            {
                ChangeCharacter(linkedDropdown.value);
            }

            return;
        }

        if (linkedLegacyDropdown != null)
        {
            linkedLegacyDropdown.onValueChanged.RemoveListener(ChangeCharacter);
            linkedLegacyDropdown.onValueChanged.AddListener(ChangeCharacter);

            if (applySelectionOnEnable)
            {
                ChangeCharacter(linkedLegacyDropdown.value);
            }

            return;
        }

        if (applySelectionOnEnable)
        {
            ChangeCharacter(defaultIndex);
        }
    }

    private void OnDisable()
    {
        if (linkedDropdown != null)
        {
            linkedDropdown.onValueChanged.RemoveListener(ChangeCharacter);
        }

        if (linkedLegacyDropdown != null)
        {
            linkedLegacyDropdown.onValueChanged.RemoveListener(ChangeCharacter);
        }
    }

    public void ChangeCharacter(int val)
    {
        if (characters == null || characters.Length == 0)
        {
            return;
        }

        if (val < 0 || val >= characters.Length)
        {
            return;
        }

        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i] != null)
            {
                characters[i].SetActive(i == val);
            }
        }
    }
}
