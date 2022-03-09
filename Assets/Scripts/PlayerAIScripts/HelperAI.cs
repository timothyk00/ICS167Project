using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using ElementFactory;

// Kevin Luu and Timothy Kwon
public class HelperAI : MonoBehaviour
{
    public NavMeshAgent _helperAI;
    private GameObject _player;

    private int _health; // Not referenced yet
    private Slider _healthSlider; // Not referenced yet

    private PlayerWeaponController _playerWC;

    private GameObject[] _enemies;

    private List<Ability> _AIWeapons = new List<Ability>();
    private AbilityFactory myFactory = new AbilityFactory();

    private bool _reloading = false;

    // Helper States
    private enum HELPER_STATE
    {
        Follow,
        Attack,
    }

    private HELPER_STATE _helperState;

    void Start()
    {
        // Set Navmesh to helperAI
        _helperAI = this.GetComponent<NavMeshAgent>();
        // Find player to follow in 1 Player mode
        _player = GameManager.GManager.GetPlayers()[0];
        // Find enemies
        _enemies = GetEnemies();
        // Adds weapons to list
        _AIWeapons.Add(myFactory.GetAbility("ice"));
    }

    
    void Update()
    {
        _enemies = GetEnemies();
        switch(_helperState)

        {
            case HELPER_STATE.Follow:
                Follow();
                if (InRange("Enemy", 10))
                {
                    _helperState = HELPER_STATE.Attack;
                }
                break;

            case HELPER_STATE.Attack:
                Attack();
                Debug.Log("attacking");
                if (!InRange("Player", 10))
                {
                    _helperState = HELPER_STATE.Follow;
                }
                break;
        }
    }

    // Follows Player
    void Follow()
    {
        if (_player != null)
            _helperAI.SetDestination(_player.transform.position);
    }

    private GameObject[] GetEnemies()
    {
        _enemies = GameObject.FindGameObjectsWithTag("Enemy");
        return _enemies;
    }


    bool InRange(string target, int range)
    {
        // Looks for Enemies in sight and within a certain distance
        RaycastHit raycastInfo;
        Vector3 rayToTarget = _player.transform.position - this.transform.position;

        // Perform a raycast to determine if there's anything between the AI and the enemies
        if (Physics.Raycast(this.transform.position, rayToTarget, out raycastInfo))
        {
            //WRONG I NEED TO FIX TO FIND ALL ENEMIES
            //raycastInfo.transform.gameObject.tag == target &&
            if ( Vector3.Distance(this.transform.position, ClosestEnemy().transform.position) < range)
            {
                return true;
                }
        }
        return false;
    }


    // Loops to find the closest enemy to the helperAI
    private GameObject ClosestEnemy()
    {
        
        GameObject closestEnemy = null;
        float minEnemyDistance = 10000f;

        for (int i = 0; i < _enemies.Length; i++)
        {
            float iterEnemyDistance = Vector3.Distance(this.transform.position, _enemies[i].transform.position);
            
            if (iterEnemyDistance < minEnemyDistance)
            {
                minEnemyDistance = iterEnemyDistance;
                closestEnemy = _enemies[i];
            }
        }

        return closestEnemy;
    }

    private void LookAtClosestEnemy()
    {
        _helperAI.transform.LookAt(ClosestEnemy().transform.position);
    }

    // If enemy is in range, AI attacks using element
    void Attack()
    {
        LookAtClosestEnemy();
        if (!_reloading)
        {
            _AIWeapons[0].useAbility(this.transform.position,this.transform.forward);
            _reloading = true;
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload(){
          yield return new WaitForSeconds(3);   //or however long you want the reload time to be
          _reloading = false;
    }
}
