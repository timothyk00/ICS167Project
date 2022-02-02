using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ElementFactory;
public class PlayerWeaponController : MonoBehaviour
{
    public List<Ability> weapons = new List<Ability>(); // index 0 = primary, index 1 = secondary
    public TextMeshProUGUI _primText;
    public TextMeshProUGUI _secText;
    public Vector3 playerPosition;
    public Vector3 playerForward;
    // Start is called before the first frame update
    void Start()
    {
        UpdateWeapons();
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = GameObject.Find("Player").transform.position;
        playerForward = GameObject.Find("Player").transform.forward;
        if (Input.GetKeyDown("e"))
            Swap();

        if (Input.GetKeyDown("space"))
            useWeapon();
    }

    private void useWeapon()
    {
        if (weapons.Count != 0)
        {
            weapons[0].useAbility(playerPosition,playerForward);
        }
    }

    private void Swap()
    {
        if (weapons.Count == 2)
            {
            weapons.Reverse();
            }
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
