using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

//Timothy Kwon
public class Goal : MonoBehaviour
{
    [SerializeField] private SceneSwitch sceneSwitch;
    [SerializeField] private GameObject objectiveC = null;
    private GameObject[] allEnemies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (objectiveC != null)
        {
            if (allEnemies.Length == 0)
                objectiveC.GetComponent<TMP_Text>().text = "Current Objective:\n Reach the green checkpoint\n to the north!";
            else
                objectiveC.GetComponent<TMP_Text>().text = "Current Objective:\n Defeat all the enemies!\n Enemies Remaining: " + (allEnemies.Length);
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(allEnemies.Length);
        if (collision.gameObject.tag == "Player" && allEnemies.Length<=0)
            SceneManager.LoadScene("Victory"); ;
    }
    
}
