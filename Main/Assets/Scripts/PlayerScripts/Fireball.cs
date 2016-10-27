using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour
{
    public float radius = 5;
    public int damage = 1;

    void OnCollisionEnter(Collision other)
    {

        /*

            if (other.gameObject.tag == "Enemy")
            {

                /*GameController controller = GameObject.Find("GameController").GetComponent<GameController>(); //look around for an object named gamecontroller with a GameController script attached

                controller.ScoreIncrease(collision.collider.GetComponent<EnemyHealth>().scoreValue); //tell the gamecontroller to increase the score equal to the amount we've found in the "enemy" creature

                Destroy(collision.collider); //destroy the enemy gameObject
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
            */


        DealAreaDamage(gameObject.transform.position, radius, damage);

        Destroy(gameObject); //Denne linjen må alltid stå sist i denne funksjonen, fordi den fjerner ildkulen*/

        
    }

    void DealAreaDamage (Vector3 location, float radius, int damage) {
        Collider[] objectsInRange = Physics.OverlapSphere(location, radius);

        foreach(Collider col in objectsInRange)
        {

            EnemyHealth enemy = col.GetComponent<EnemyHealth>();

            if(enemy != null) {
                enemy.TakeDamage(damage);
                Debug.Log("Oooooooh, buuuuurn");
            }
            
        }
    }
}