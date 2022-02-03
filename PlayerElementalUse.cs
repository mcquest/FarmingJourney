/*
 * Charles Farris
 * Player Functionality-/Elemental Use:
 * User Input for --
 * -Jump
 * -Plant
 * -Grow
 * 
 * TODO
 * ??Destroy-fire
 * Try FixedUpdate for Jump
 */

// Statements to call access to libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

// Class object -- same name as script
public class PlayerElementalUse : MonoBehaviour
{
    // Initialize object variable to import script
    public GameManager gameManager;
    public PlayerController playerController;

    // Initialize position/location/scale object variable to use 
    //when planting (Instantiate())
    //---Set in Inspector
    public Transform appleTree;
    public Transform rBerryBush;
    public Transform sunflower;

    // Animator object initialization
    Animator movementAnim;

    // Lists to grow planted seeds in scene
    // Create list variable to hold apple trees
    public GameObject[] appleTrees;
    // Raspberry bush list
    public GameObject[] rBerryBushes;
    // List with GameObject type
    public GameObject[] sunflowers;


    Rigidbody rb; // Player physics body
    public float jumpForce = 5.0f;
    int jumps = 0;
    public int maxJumps = 1;
    public float glideSpeed = 0.0001f;

    public bool isTouchingGround;

    // Start is called before the first frame update
    void Start()
    {
        // initialize physics body 
        // -- this refers to object script is attached to
        rb = this.GetComponent<Rigidbody>();
        // initialize "this" object's amimator
        movementAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    // Try Fixed Update
    void Update()
    {
        AirJump();
        PlantAppleSeed();
        PlantRaspSeed();
        PlantSunSeed();
        RainDance();
        Glide();
    }

    // Change ground to be top of objects
    private void AirJump()
    {
        float posY = transform.GetChild(0).position.y;
        // air button

        if (Input.GetButtonDown("Jump") & jumps < maxJumps)
        {
            //jump
            {
            // Add jump force
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            // Track jumping
            jumps += 1;
            isTouchingGround = false;
            movementAnim.Rebind();
            // Play jump animation
            // MovementAnim.SetTrigger("jump");
            // MovementAnim.SetBool("onGround", false);
            }
        }

        // If not touching the ground
        if (!isTouchingGround)
        {
            movementAnim.Play("jump");
        }

    }

    private void Glide()
    {
        if (rb.velocity.y < 0 & Input.GetKeyDown(KeyCode.G))
        {
             Physics.gravity = new Vector3(0, -10F, 0);
        }
    }

    // Function to plant apple seed 
    private void PlantAppleSeed()
    {
        // Plant apple seed
        if (isTouchingGround && gameManager.CanPlantApple() && Input.GetButtonDown("Apple")) 
        {
            // Play planting animation
            // Find the player position x,y,z
            float posX = transform.GetChild(0).position.x;
            float posY = transform.GetChild(0).position.y;
            float posZ = transform.GetChild(0).position.z;
            // Where the seed will be planted
            Vector3 plantPos = new Vector3(posX, posY, posZ);
            // Instantiate - plant appleTree/seed
            Instantiate(appleTree, plantPos, transform.GetChild(0).rotation);
            // Appleseed-1s
            gameManager.AppleSeedDown();
        }

    }

    // Function to plant Raspberry seed
    private void PlantRaspSeed()
    {
        // Plant raspberry seed 
        if (isTouchingGround && gameManager.CanPlantRasp() && Input.GetButtonDown("Raspberry")) //&& isTouchingGround
        {
            // Play planting animation
            // Find the player position x,y,z
            float posX = transform.GetChild(0).position.x;
            float posY = transform.GetChild(0).position.y;
            float posZ = transform.GetChild(0).position.z;
            // Where the seed will be planted
            Vector3 plantPos = new Vector3(posX, posY, posZ);
            // Instantiate - plant bushes
            Instantiate(rBerryBush, plantPos, transform.GetChild(0).rotation);
            // Raspberry-1s
            gameManager.RaspSeedDown();
        }
    }

    // Function to plant sunflower seed
    private void PlantSunSeed()
    {
        // Plant sunflower seed 
        if (isTouchingGround & gameManager.CanPlantSun() & Input.GetButtonDown("Sunflower")) //&& isTouchingGround
        {
            // Play planting animation
            // Find the player position x,y,z
            float posX = transform.GetChild(0).position.x;
            float posY = transform.GetChild(0).position.y;
            float posZ = transform.GetChild(0).position.z;
            // Where the seed will be planted
            Vector3 plantPos = new Vector3(posX, posY, posZ);
            // Instantiate - plant appleTree/seed
            Instantiate(sunflower, plantPos, transform.GetChild(0).rotation);
            // yFSeed/sunflower seed -1s
            gameManager.SunSeedDown();
        }
    }

    private void RainDance()
    {
        // If Fire2 (R), then rain dance
        if (Input.GetButton("Rain"))
        {
            // Set appleTrees list to all appleTrees in scene
            appleTrees = GameObject.FindGameObjectsWithTag("appleTree");
            // Set rBerryBushes list to all rBerryBushes in scene
            rBerryBushes = GameObject.FindGameObjectsWithTag("rBerryBush");

            sunflowers = GameObject.FindGameObjectsWithTag("sunflower");

            // SetActive tree body object
            foreach (GameObject appleTree in appleTrees)
            {
                // Grow trees
                appleTree.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            } 
            // SetActive tree body object
            foreach(GameObject bush in rBerryBushes)
            {
                // Grow bushes
                bush.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }

            foreach(GameObject flower in sunflowers)
            {
                flower.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                flower.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }

    private void ResetJumps()
    {
        // Reset animation
        movementAnim.Rebind();
        // idle animation
        movementAnim.SetTrigger("idle");
        jumps = 0; // Reset jumps
        isTouchingGround = true;
        Physics.gravity = new Vector3(0, -60F, 0);
        // movementAnim.SetBool("onGround", true);
        //Debug.Log(isTouchingGround.ToString());
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        { 
            case "ground":
                ResetJumps();
                break;

            case "appleTree":
                ResetJumps();
                break;               
            
            case "rBerryBush":
                ResetJumps();
                break;

            case "pineTree":
                ResetJumps();
                break;
        }
    }
}
