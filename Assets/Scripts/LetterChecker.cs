using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterChecker : MonoBehaviour
{
    private readonly char[] _letters = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
    private int _count = 0;

    public Text timerStr;

    public GameObject endMenu;
    public GameObject overlay;
    public SetTimer timer;

    public ScoreCheck scoreCheck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("PlanetObj"))
        {
            Debug.Log("Collision!");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Letter"))
        {
            GameObject o = other.gameObject;
            
            //DEBUGGING
            Time.timeScale = 0;

            if (timer.GetSec() < BestTime.LowestTime)
            {
                BestTime.LowestTime = timer.GetSec();
                BestTime.LowStrTime = timerStr.text;
            }
            Debug.Log(timer.GetSec());
            overlay.SetActive(false);
            endMenu.SetActive(true);
            

            if (o.name[0] == _letters[_count])
            {
                char letter = o.name[0];
                Debug.Log("YOU GOT THE LETTER " + o.name);
                o.GetComponent<Rigidbody>().isKinematic = true;
                Destroy(o);
                
                if (letter == 'Z')
                {
                    Time.timeScale = 0;

                    Debug.Log(timer.GetSec());
                    
                    BestTime.LowStrTime = timerStr.text;
                    endMenu.SetActive(true);
                }
                
                
                _count++;
            }
            else
            {
                Destroy(other.gameObject);
                Debug.Log("That's not alphabetical! Try again");
                o.name = o.name[0].ToString();
                Vector3 normal = (Random.onUnitSphere * 10.2f - o.transform.position).normalized;
                Quaternion rotation = Quaternion.LookRotation(normal);
                Instantiate(o, Random.onUnitSphere * 10.2f, rotation);
            }
        }
    }
}
