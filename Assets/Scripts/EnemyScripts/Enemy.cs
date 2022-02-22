using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


//Kevin Luu + Timothy Kwon
//NavMesh Bot Tutorial
public class Enemy : MonoBehaviour
{
    protected NavMeshAgent _enemy;
    private GameObject _player;   
    private PlayerMovementController _playerMove;

    protected int _health = 15;
    protected int _attack = 10;

    protected Slider _healthSlider;
    
    void Start()
    {
        _enemy = this.GetComponent<NavMeshAgent>();
        _healthSlider = this.GetComponentInChildren<Slider>();
        _healthSlider.maxValue = _health;
    }

    // Wander if Player out of range
    // Pursue if Player in range
    void Update()
    {
        _player = GetClosestPlayer();
        if (_player)
        {
            _playerMove = _player.GetComponent<PlayerMovementController>();

            if (!PlayerInRange())
            {
                Wander();
            }
            else
            {
                Pursue();
            }
        }
        
    }

    GameObject GetClosestPlayer()
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
        // The vector from the enemy to the player
        Vector3 targetDir = _player.transform.position - this.transform.position;

        // The angle between the forward direction of the enemy and the forward direction of the player
        float relativeHeading = Vector3.Angle(this.transform.forward, this.transform.TransformVector(_player.transform.forward));

        // The angle between the forward direction of the enemy and the position of the player
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
    void Wander()
    {
        float wanderRadius = 10;
        float wanderDistance = 10;
        float wanderJitter = 1;

        // Determine a location on a circle 
        wanderTarget += new Vector3(Random.Range(-1.0f, 1.0f) * wanderJitter,
                                        0,
                                        Random.Range(-1.0f, 1.0f) * wanderJitter);
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
    bool CanSeeTarget()
    {
        RaycastHit raycastInfo;
        // Calculate a ray to the player from the enemy
        Vector3 rayToTarget = _player.transform.position - this.transform.position;
        // Perform a raycast to determine if there's anything between the enemy and the player
        if (Physics.Raycast(this.transform.position, rayToTarget, out raycastInfo))
        {
            // Ray will hit the player if no other colliders in the way
            if (raycastInfo.transform.gameObject.tag == "Player")
                return true;
        }
        return false;
    }


    // Determine how far the player is from the enemy
    bool PlayerInRange()
    {
        if (Vector3.Distance(this.transform.position, _player.transform.position) < 10)
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