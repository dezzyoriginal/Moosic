using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Vector2 dir = Vector2.zero;
    private float speed = 3f;
    private float slowedSpeed = 1f;
    Rigidbody2D rb;
    private Transform door;
    [SerializeField] private GameObject thoughtBubble;
    [SerializeField] private SpriteRenderer instrument;
    private InstrumentSpriteHolder spriteHolder;

    public bool doorCollision = false;
    private bool hasParked = false;
    private bool initiated = false;

    private SpawnerController spawnerController;
    private Animator animator;
    public SpriteRenderer sr;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initiated = false;
        door = GameObject.Find("Door").GetComponent<Transform>();
        spawnerController = GameObject.Find("Spawner Controller").GetComponent<SpawnerController>();
        spriteHolder = GetComponent<InstrumentSpriteHolder>();

        slowedSpeed = spawnerController.slowedSpeed;
        speed = spawnerController.speed;
        sr = this.GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", true);

        thoughtBubble.SetActive(false);
        rb.velocity = new Vector2(dir.x * speed * 200 * Time.deltaTime, 0);
        hasParked = false;
    }

    private void Update()
    {
        if (Mathf.Abs(transform.position.x - door.position.x) < 0.1f && !doorCollision)
        {
            //BuyerController.BuyProcess_Static();
            //thoughtBubble.SetActive(true);

            
            doorCollision = true;
        }
    }

    void FixedUpdate()
    {
        if (hasParked)
        {
            thoughtBubble.SetActive(false);
            rb.velocity = new Vector2(dir.x * speed * 200 * Time.deltaTime, 0); //traveling out
            animator.SetBool("isWalking", true);
        }
    }

    public int GetSelectedInstrument(int ID, bool updateStatus)
    {
        if (updateStatus)
        {
            instrument.sprite = spriteHolder.sprites[ID];
            StorageController.instance.ResetUpdateStatus();
            Debug.Log(ID);
            return ID;
        }else return 6;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!initiated)
        {
            if (other.name == "Spawn2")
            {
                this.GetComponent<SpriteRenderer>().flipX = true;
                dir = Vector2.left;
            }
            else if (other.name == "Spawn1")
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
                dir = Vector2.right;
            }
            initiated = true;
        }

        if (other.CompareTag("Destroy Zone")) Destroy(gameObject);
        if (other.CompareTag("Door"))
        {
            if (!doorCollision)
            {
                BuyerController.BuyProcess_Static();
                animator.SetBool("isWalking", false);
                rb.velocity = Vector2.zero;
                thoughtBubble.SetActive(true);
                StartCoroutine(Parking());
            }
            doorCollision = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Door"))
        {
            thoughtBubble.SetActive(false);
            doorCollision = false;
        }

    }

    IEnumerator Parking()
    {
        int instrumentID = StorageController.instance.selectedInstrument;
        bool updateStatus = StorageController.instance.hasUpdated;
        GetSelectedInstrument(instrumentID, updateStatus);

        yield return new WaitForSeconds(spawnerController.parkTime);
        hasParked = true;
    }
}
