using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject healthText;
    public float speed;
    public float jumpforce;
    public float damagerate;
    public float health;
    public Animator playerAnin;
    public Rigidbody playerRb;
    bool onplayerplane;
    bool death = false;

    // Start is called before the first frame update
    void Start()
    {
        healthText.GetComponent<Text>().text = "Health: " + health;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && death == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            playerAnin.SetBool("ismove", true);
        }
        else if (Input.GetKey(KeyCode.A) && death == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, -90, 0);
            playerAnin.SetBool("ismove", true);
        }
        else if (Input.GetKey(KeyCode.S) && death == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            playerAnin.SetBool("ismove", true);
        }
        else if (Input.GetKey(KeyCode.D) && death == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            playerAnin.SetBool("ismove", true);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) && death == false)
        {
            playerAnin.SetBool("ismove", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && onplayerplane == true && death == false)
        {
            playerRb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            onplayerplane = false;
            playerAnin.SetTrigger("TrigFlip");
        }
        /*
        if (health <= 0)
        {
            playerAnin.SetTrigger("Death");
            death = true;
        }
        */
        if (Input.GetKeyDown(KeyCode.K))
        {
            health -= 10;
            healthText.GetComponent<Text>().text = "Health: " + health;
            if (health <= 0)
            {
                playerAnin.SetTrigger("TrigDeath");
                death = true;
            }
        }
    }
    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {
            if (health > 0)
            {
                health -= damagerate * Time.deltaTime;
                healthText.GetComponent<Text>().text = "Health: " + health;
            }
        }
    }
    */
    private void OnCollisionEnter(Collision collision)
    {
        onplayerplane = true;
    }
}
