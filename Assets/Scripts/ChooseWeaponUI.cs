using UnityEngine;
using UnityEngine.UI;

public class ChooseWeaponUI : MonoBehaviour
{
    public Text titleText; // Reference to the title text in the UI

    void Start()
    {
        // Set the game title 
        titleText.text = "Monster Slayer Game";
    }

    // Method to handle weapon selection
    public void SelectWeapon(string weaponType)
    {
        // Logic to select and equip weapon
        Debug.Log($"Selected weapon: {weaponType}");
        // Add scene transition or weapon equip logic here
    }
}