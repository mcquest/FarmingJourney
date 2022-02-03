using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameManager gameManager;

    // when the player touches another object
    void  OnTriggerEnter(Collider collider)
    {
        switch (collider.gameObject.tag)
        {
            case "appleSeed":
                // destroy seed object
                collider.gameObject.SetActive(false);
                gameManager.AppleSeedUp();
                break;

            case "yFlowerSeed":
                // destroy seed object
                collider.gameObject.SetActive(false);
                gameManager.SunSeedUp();
                break;

            case "raspBushSeed":
                // destroy seed object
                collider.gameObject.SetActive(false);
                gameManager.RaspSeedUp();
                break;
        }

    }
}
