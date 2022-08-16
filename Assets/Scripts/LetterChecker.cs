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
    public bool debugWin = false;

    public SetMessage msg;
    public GameObject badExplosion;
    public GameObject goodExplosion;

    public GameObject msgBox;
    // Start is called before the first frame update
    void Start()
    {
        msg.InitStart();
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
    
    IEnumerator ActivateGameObject(GameObject g)
    {
 
        yield return new WaitForSeconds(2f);
        g.SetActive(false);
    }
    
    IEnumerator RemoveFX(GameObject g)
    {
 
        yield return new WaitForSeconds(2f);
        Destroy(g);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Letter"))
        {
            GameObject o = other.gameObject;
            
            //DEBUGGING
            // msgBox.SetActive(true);
            // msg.SetText($"You got the letter {o.name[0]}!");
            // StartCoroutine(ActivateGameObject(msgBox));

            if (debugWin)
            {
                Time.timeScale = 0;

                if (timer.GetSec() < BestTime.LowestTime)
                {
                    BestTime.LowestTime = timer.GetSec();
                    BestTime.LowStrTime = timerStr.text;
                }
                Debug.Log(timer.GetSec());
                overlay.SetActive(false);
                endMenu.SetActive(true);
            }
            

            if (o.name[0] == _letters[_count])
            {
                char letter = o.name[0];
                Debug.Log("YOU GOT THE LETTER " + o.name);
                
                msgBox.SetActive(true);
                msg.SetText($"You got the \nletter {o.name[0]}! :)");
                StartCoroutine(ActivateGameObject(msgBox));
                
                o.GetComponent<Rigidbody>().isKinematic = true;
                GameObject explosion1 = Instantiate(goodExplosion, o.transform.position, o.transform.rotation);
                StartCoroutine(RemoveFX(explosion1));
                Destroy(o);

                if (letter == 'Z')
                {
                    Time.timeScale = 0;

                    if (timer.GetSec() < BestTime.LowestTime)
                    {
                        BestTime.LowestTime = timer.GetSec();
                        BestTime.LowStrTime = timerStr.text;
                    }
                    Debug.Log(timer.GetSec());
                    overlay.SetActive(false);
                    endMenu.SetActive(true);
                }
                
                
                _count++;
            }
            else
            {
                GameObject explosion2 = Instantiate(badExplosion, o.transform.position, o.transform.rotation);
                StartCoroutine(RemoveFX(explosion2));
                Destroy(other.gameObject);
                
                msgBox.SetActive(true);
                msg.SetText($"Wrong letter :(\nHint: {_letters[_count]}!");
                StartCoroutine(ActivateGameObject(msgBox));
                
                Debug.Log("That's not alphabetical! Try again");
                o.name = o.name[0].ToString();
                Vector3 normal = (Random.onUnitSphere * 10.2f - o.transform.position).normalized;
                Quaternion rotation = Quaternion.LookRotation(normal);
                Instantiate(o, Random.onUnitSphere * 10.2f, rotation);
            }
        }
    }
}
