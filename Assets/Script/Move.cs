using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{

    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float TimeToMove = 0.2f;

    public bool currentPlayer;
    public GameObject Selected;

    public Transform FirePoint;
    public GameObject BulletPrefab;

    public BoxCollider2D BoxColldier01;
    public BoxCollider2D BoxColldier02;
    public BoxCollider2D BoxColldier03;

    public BoxCollider2D BoxColldier04;
    public BoxCollider2D BoxColldier05;
    public BoxCollider2D BoxColldier06;

    public Image Background01;
    public Text Player01;

    public Image Background02;
    public Text Player02;

    //sound 
    private AudioSource splatter;

    //mousefollow
  /*  public Camera cam;
    Vector2 mousePos;
    Vector2 movement;
    public Rigidbody2D rb; */

    void Start()
    {
        currentPlayer = false;

        splatter = GetComponent<AudioSource>();

        //Show which player is up playing 
        Background01.GetComponent<Image>().color = Color.green;
        Player01.GetComponent<Text>().color = Color.black;


        BoxColldier04.enabled = false;
        BoxColldier05.enabled = false;
        BoxColldier06.enabled = false;
    }

    void OnMouseDown()
    {
        currentPlayer = true;
        Debug.Log(currentPlayer);
        Selected.gameObject.SetActive(true);
    

        //swicthing off the box colliders so that no other object can be clicked
        BoxColldier01.enabled = false;
        BoxColldier02.enabled = false;
        BoxColldier03.enabled = false;

        BoxColldier04.enabled = false;
        BoxColldier05.enabled = false;
        BoxColldier06.enabled = false;

    }

    void Update()
    {

       // mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (currentPlayer)
        {
            if (Input.GetKey(KeyCode.W) && !isMoving)
                StartCoroutine(MovePlayer(Vector3.up));

            if (Input.GetKey(KeyCode.S) && !isMoving)
                StartCoroutine(MovePlayer(Vector3.down));

            if (Input.GetKey(KeyCode.A) && !isMoving)
                StartCoroutine(MovePlayer(Vector3.left));

            if (Input.GetKey(KeyCode.D) && !isMoving)
                StartCoroutine(MovePlayer(Vector3.right));

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }

         /*  Vector2 lookDir = mousePos - rb.position;
           float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle; */
        }

  
        
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0;
        origPos = transform.position;
        targetPos = origPos + direction;

        while (elapsedTime < TimeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / TimeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
            currentPlayer = false;
            Selected.gameObject.SetActive(false);

           

            BoxColldier04.enabled = true;
            BoxColldier05.enabled = true;
            BoxColldier06.enabled = true;

            Background01.GetComponent<Image>().color = Color.black;
            Player01.GetComponent<Text>().color = Color.white;

            Background02.GetComponent<Image>().color = Color.green;
            Player02.GetComponent<Text>().color = Color.black;


        }

        transform.position = targetPos;

        isMoving = false;

        //Play audio
        splatter.Play();


    }

    void Shoot()
    {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        currentPlayer = false;
        Selected.gameObject.SetActive(false);

        BoxColldier04.enabled = true;
        BoxColldier05.enabled = true;
        BoxColldier06.enabled = true;

        Background01.GetComponent<Image>().color = Color.black;
        Player01.GetComponent<Text>().color = Color.white;

        Background02.GetComponent<Image>().color = Color.green;
        Player02.GetComponent<Text>().color = Color.black;
    }



}
