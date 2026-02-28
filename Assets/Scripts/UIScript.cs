using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject[] characters;

    public void ChangeCharacter(int val)
    {
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(i == val);
        }
    }
}
