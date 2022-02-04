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
    GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        UpdateWeapons();
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
            Swap();

        if (Input.GetKeyDown("space"))
            useWeapon();
    }

    private void useWeapon()
    {
        if (weapons.Count != 0)
        {
            weapons[0].useAbility(_player.transform.position, _player.transform.forward);
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
