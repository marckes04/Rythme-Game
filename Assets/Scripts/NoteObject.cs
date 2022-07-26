using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;

    private bool missed = false;

    public GameObject hitEffect, goodEffect, PerfectEffect, missEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);
             
                

                if (Mathf.Abs(transform.position.y) > 0.25)
                {
                    Debug.Log("Hit");
                    GameManager.instance.NormalHit();
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                    
                }
                else if (Mathf.Abs(transform.position.y) > 0.05f)
                {
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                   
                }

                else
                {
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit();
                    Instantiate(PerfectEffect, transform.position, PerfectEffect.transform.rotation);
                    
                }
            }
        }


        if(transform.position.y < -0.3)
        {
            finishedObject();
        }
    }

     private void OnTriggerEnter2D(Collider2D other)
     {
        if(other.tag== "Activator")
        {
            canBePressed = true;
        }
        
     }

    void finishedObject()
    {
        canBePressed = false;

            GameManager.instance.NoteMissed();
            Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        Destroy(gameObject);
    }


}
