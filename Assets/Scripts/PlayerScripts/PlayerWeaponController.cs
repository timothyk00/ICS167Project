using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ElementFactory;

//Timothy Kwon, Cleon Doan

public class PlayerWeaponController : MonoBehaviour
{
    public List<Ability> weapons = new List<Ability>(); // index 0 = primary, index 1 = secondary
    public TextMeshProUGUI _primText;
    public TextMeshProUGUI _secText;

    private string _fireButton;
    private string _swapButton;

    // Start is called before the first frame update
    void Start()
    {
        _fireButton = "Fire" + this.GetComponent<PlayerMovementController>()._playerNum;
        _swapButton = "Swap" + this.GetComponent<PlayerMovementController>()._playerNum;
        UpdateWeapons();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(_swapButton))
            Swap();

        if (Input.GetButtonDown(_fireButton))
            UseWeapon();
    }

    private void UseWeapon()
    {
        if (weapons.Count != 0)
        {
            weapons[0].useAbility(this.transform.position, this.transform.forward);
        }
    }

    private void Swap()
    {
        if (weapons.Count == 2)
            weapons.Reverse();

        UpdateWeapons();
    }

    public void UpdateWeapons()
    {
        if (weapons.Count == 0)
        {
            _primText.text = "Primary: ";
            _secText.text = "Secondary: ";
        }
        else if (weapons.Count == 1)
        {
            _primText.text = "Primary: "+ weapons[0].element;
            _secText.text = "Secondary: ";
        }
        else if (weapons.Count == 2)
        {
            _primText.text = "Primary: " + weapons[0].element;
            _secText.text = "Secondary: " + weapons[1].element;
        }
    }
}
