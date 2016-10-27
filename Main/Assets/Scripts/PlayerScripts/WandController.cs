using UnityEngine;
using System.Collections;

public class WandController : MonoBehaviour {

    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device device;

    public GameObject bulletPrefab;
    public Transform firePosition;
    GameObject bulletInstance;

    float maxSize = 0.0007F; //max size of fireball
    float superSize = 0.03F;

    
    void Start () {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        device = SteamVR_Controller.Input((int)trackedObject.index);

    }



    void Update () {
        Vector3 vel = device.velocity;
        //Debug.Log(vel);
        if (Input.GetKey(KeyCode.Q) && transform.localScale.magnitude < 0.2F) // 
        {
            transform.localScale += new Vector3(maxSize, maxSize, maxSize);
        }

        //Debug.Log(device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger));
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
  
        {
            SpawnFireball();
        }

        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))

        {
            ReleaseFireball();
        }
    }


    

    void SpawnFireball()
    {
        if (bulletInstance == null)
        {
            Debug.Log("Trigger Press");

            bulletInstance = Instantiate(bulletPrefab, firePosition.position, firePosition.rotation) as GameObject;
            bulletInstance.GetComponent<VRTK.VRTK_InteractableObject>().Grabbed(gameObject);
            bulletInstance.transform.parent = transform;

            if (bulletInstance.transform.localScale.magnitude < 0.2F)
            {
                Debug.Log("Expand");

                bulletInstance.transform.localScale += new Vector3(maxSize, maxSize, maxSize);
            }

        }
    }

    void ReleaseFireball()
    {
        if(bulletInstance != null)
        {
            bulletInstance.transform.parent = null;
            Vector3 vel = device.velocity;
            Debug.Log(vel);
            bulletInstance.GetComponent<Rigidbody>().AddForce(vel * 300);
            bulletInstance.GetComponent<Rigidbody>().useGravity = true;
            //bulletInstance.GetComponent<Rigidbody>().AddForce(firePosition.forward * 20);
            bulletInstance = null;
            

        }
    }
}
