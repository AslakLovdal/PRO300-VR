using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 1;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;


    CapsuleCollider capsuleCollider; // the enemy's collider
    bool isDead;  //wether the enemy is dead
    bool isSinking; //wether the enemy is in the process of sinking

	
	void Awake () {
        capsuleCollider = GetComponent<CapsuleCollider>(); //make sure the script really gets the capsule collider, y'know    

        currentHealth = startingHealth; //since the whole thing is just now waking up, it's health is set to default

        Debug.Log("This mook has spawned, isSinking is " + isSinking + ", its health is " + currentHealth + ", and it's worth " + scoreValue + " points.");
    }
	
	
	void Update () {
	    if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
	}


    public void TakeDamage (int amount)
    {
        if (isDead)
        {
            return;
        }
        Debug.Log("Mook took " + amount + " damage.");
        currentHealth -= amount;

        if(currentHealth<= 0)
        {
            Death();
        }

        Debug.Log("Mook's health is " + currentHealth);
    }

    void Death()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        Debug.Log("Oh no, I died!" + isSinking);

        StartSinking();

    }

    public void StartSinking()
    {
        GetComponent<NavMeshAgent>().enabled = false;

        GetComponent<Rigidbody>().isKinematic = true;

        isSinking = true;
        Debug.Log("This mook is going down!");

        //ScoreManager.score += scoreValue;

        Destroy(gameObject, 1f);
        Debug.Log("This thing is dyin'");
    }
}
