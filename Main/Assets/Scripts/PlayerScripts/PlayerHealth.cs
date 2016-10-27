using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;

    public MeshRenderer mesh; //refers to the tower's mesh renderer
    public Color flashColor = new Vector4(255,0,0,0); //the color it changes to when it takes damage
    public float flashSpeed = 5f; //the speed the color will fade back to normal

    bool isDead;
    bool damaged;

	// Use this for initialization
	void Awake () {
        mesh = GetComponent<MeshRenderer>();
        currentHealth = startingHealth;
	}

    void Update()
    {
        if (damaged)
        {
            mesh.material.color = flashColor;
        }

        else { mesh.material.color = Color.Lerp(mesh.material.color, Color.grey, flashSpeed * Time.deltaTime); }

        damaged = false;
    }
	
	public void TakeDamage (int amount)
    {
        damaged = true;

        currentHealth -= amount;

        if (currentHealth <=0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        mesh.material.color = Color.blue;
    }
}
