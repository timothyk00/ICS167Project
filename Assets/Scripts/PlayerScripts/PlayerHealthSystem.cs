using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Timothy Kwon

public class PlayerHealthSystem : MonoBehaviour
{
    public int _health = 100;
    public Slider _healthSlider;

    [SerializeField] private Canvas _deathCanvas;

    // Start is called before the first frame update
    void Start()
    {
        _deathCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_health <= 0)
        {
            if (GameManager.GManager.IsSinglePlayer())
                gameObject.SetActive(false);
            else
                StartCoroutine(DeathRoutine());
        }
    }

    private IEnumerator DeathRoutine()
    {
        _deathCanvas.enabled = true;

        if (GameManager.GManager.GetPlayers().Length > 1)
            yield return new WaitForSeconds(0.25f);

        gameObject.SetActive(false);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("collided with enemy");
            _health -= 10;   // change with enemy damage
            _healthSlider.value = _health;

        }
        if(collision.gameObject.tag == "projectile" || collision.gameObject.tag == "bolt" || collision.gameObject.tag == "wave")
        {
            _health-=10;
            _healthSlider.value = _health;
        }
        if(collision.gameObject.tag == "heal" && _health < 100)
        {
            _health+=10;
            _healthSlider.value = _health;

        }
    }
}
