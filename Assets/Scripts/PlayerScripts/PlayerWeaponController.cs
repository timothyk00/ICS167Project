using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ElementFactory;

//Timothy Kwon, Cleon Doan

public class PlayerWeaponController : MonoBehaviour
{
    public List<Ability> _weapons = new List<Ability>(); // index 0 = primary, index 1 = secondary

    [SerializeField] private TextMeshProUGUI _primText;
    [SerializeField] private TextMeshProUGUI _secText;

    [SerializeField] private Canvas _elementSelect;
    [SerializeField] private TMP_Dropdown _elementDrop;
    [SerializeField] private TextMeshProUGUI _descriptionText;

    private Dictionary<string, string> _descriptions = new Dictionary<string, string>()
    {
        {"Earth", "Build an earth wall that blocks projectiles" },
        {"Electric", "Shoot a long ray of electricity that damages enemies" },
        {"Fire", "Shoot a short but wide burst of fire that damages enemies" },
        {"Heal", "Heal 10 health" },
        {"Ice", "Shoot an iceball that damages enemies" }
    };

    private string _fireButton;
    private string _swapButton;


    // Start is called before the first frame update
    void Start()
    {
        _fireButton = "Fire" + this.GetComponent<PlayerMovementController>()._playerNum;
        _swapButton = "Swap" + this.GetComponent<PlayerMovementController>()._playerNum;

        if (_elementSelect.enabled == true)
            Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(_swapButton))
            Swap();

        if (Input.GetButtonDown(_fireButton))
            UseWeapon();

        if (_elementSelect.enabled)
        {
            Time.timeScale = 0;
            _descriptionText.text = _descriptions[_elementDrop.options[_elementDrop.value].text];
        }
    }

    private void UseWeapon()
    {
        if (_weapons.Count != 0)
        {
            _weapons[0].useAbility(this.transform.position, this.transform.forward);
        }
    }

    private void Swap()
    {
        if (_weapons.Count == 2)
            _weapons.Reverse();

        UpdateWeapons();
    }

    public void UpdateWeapons()
    {
        if (_weapons.Count == 0)
        {
            _primText.text = "Primary: ";
            _secText.text = "Secondary: ";
        }
        else if (_weapons.Count == 1)
        {
            _primText.text = "Primary: "+ _weapons[0].element;
            _secText.text = "Secondary: ";
        }
        else if (_weapons.Count == 2)
        {
            _primText.text = "Primary: " + _weapons[0].element;
            _secText.text = "Secondary: " + _weapons[1].element;
        }
    }

    public void DisableElementSelectCanvas()
    {
        _elementSelect.enabled = false;
        Time.timeScale = 1;

        //_weapons.Add(myFactory.GetAbility(elementType));
        UpdateWeapons();
    }
}
