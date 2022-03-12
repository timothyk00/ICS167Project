using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


// Kevin Luu + Timothy Kwon
// Used code from NavMesh Bot Hide & Seek Tutorial
public class Enemy : MonoBehaviour
{
    protected NavMeshAgent _enemy;
    protected GameObject _player;
    protected PlayerMovementController _playerMove;

    protected Slider _healthSlider;

    protected int _health;
    protected int _attack;

    // Enemy States
    protected enum ENEMY_STATE
    {
        Wander,
        Pursue,
        Attack
    }

    protected ENEMY_STATE _enemyState;

    public Enemy()
    {
        _health = 15;
        _attack = 10;
    }

    void Start()
    {
        _player = GetClosestPlayer();
        _enemy = this.GetComponent<NavMeshAgent>();
        _healthSlider = this.GetComponentInChildren<Slider>();
        _healthSlider.maxValue = _health;
    }

    // Finite State Machine
    void Update()
    {
        _player = GetClosestPlayer();
        if (_player)
        {
            _playerMove = _player.GetComponent<PlayerMovementController>();
            switch(_enemyState)
            {
                case ENEMY_STATE.Wander:
                    if (!CanSeePlayer(10))
                    {
                        Wander();
                    }
                    else if (CanSeePlayer(10))
                    {
                        _enemyState = ENEMY_STATE.Pursue;
                    }
                    break;

                case ENEMY_STATE.Pursue:
                    Pursue();
                    if (!CanSeePlayer(10))
                    {
                        _enemyState = ENEMY_STATE.Wander;
                    }
                    if (PlayerInRange())
                    {
                        _enemyState = ENEMY_STATE.Attack;
                    }
                    break;

                case ENEMY_STATE.Attack:
                    if (!PlayerInRange() || !CanSeePlayer(10))
                    {
                        _enemyState = ENEMY_STATE.Wander;
                    }
                    break;
            }
        }
    }

    protected virtual GameObject GetClosestPlayer()
    {
        GameObject[] players = GameManager.GManager.GetPlayers();
        if (players.Length == 1)
            return players[0];
        else if (players.Length == 2)
        {
            if (Vector3.Distance(this.transform.position, players[0].transform.position)
                < Vector3.Distance(this.transform.position, players[1].transform.position))
                return players[0];
            else
                return players[1];
        }
        else
            return null;

    }

    // Walk to a location on NavMesh
    void Seek(Vector3 location)
    {
        _enemy.SetDestination(location);
    }

    // Chase after a target by predicted where it will be in the future
    void Pursue()
    {
        Vector3 targetDir = _player.transform.position - this.transform.position;

        float relativeHeading = Vector3.Angle(this.transform.forward, this.transform.TransformVector(_player.transform.forward));
        float toTarget = Vector3.Angle(this.transform.forward, this.transform.TransformVector(targetDir));

        // If the enemy behind and heading in the same direction or the player has stopped then just seek.
        if ((toTarget > 90 && relativeHeading < 20) || _playerMove._moveSpeed < 0.01f)
        {
            Seek(_player.transform.position);
            return;
        }

        // Calculate how far to look ahead and add this to the seek location.
        float lookAhead = targetDir.magnitude / (_enemy.speed + _playerMove._moveSpeed);
        Seek(_player.transform.position + _player.transform.forward * lookAhead);
    }

    // Wanders around the map
    Vector3 wanderTarget = Vector3.zero;
    protected virtual void Wander()
    {
        float wanderRadius = 10;
        float wanderDistance = 10;
        float wanderJitter = 1;

        wanderTarget += new Vector3(Random.Range(-1.0f, 1.0f) * wanderJitter, 0, Random.Range(-1.0f, 1.0f) * wanderJitter);
        wanderTarget.Normalize();
        
        // Project the point out to the radius of the circle
        wanderTarget *= wanderRadius;

        // Move the circle out in front of the enemy to the wander distance
        Vector3 targetLocal = wanderTarget + new Vector3(0, 0, wanderDistance);
        
        // Work out the world location of the point on the circle.
        Vector3 targetWorld = this.gameObject.transform.InverseTransformVector(targetLocal);

        Seek(targetWorld);
    }

    // Can the enemy see the Player from its current location
    protected virtual bool CanSeePlayer(int range)
    {
        RaycastHit raycastInfo;
        Vector3 rayToTarget = _player.transform.position - this.transform.position;

        // Perform a raycast to determine if there's anything between the enemy and the player
        if (Physics.Raycast(this.transform.position, rayToTarget, out raycastInfo))
        {
            if (raycastInfo.transform.gameObject.tag == "Player" && Vector3.Distance(this.transform.position, _player.transform.position) < range)
                Debug.Log("Can See");
                return true;
        }
        return false;
    }


    // Determine how far the player is from the enemy
    protected virtual bool PlayerInRange()
    {
        if (Vector3.Distance(this.transform.position, _player.transform.position) < 5)
            return true;
        return false;
    }


    // Take Damage
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "projectile" || collision.gameObject.tag == "bolt" || collision.gameObject.tag == "wave")
        {
            _health-=10;
            _healthSlider.value = _health;

        }

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

}