using UnityEngine;

public class DeskTrigger : MonoBehaviour
{
    private bool showMessage = false;
    private string message = "Press [spacebar] to repair";
    public GameManager gameManager;
    public bool deskAvtive;
    public int waitTime = 0;
    [SerializeField] int deskNumber;

    void OnTriggerEnter(Collider collisionInfo)
    {
        if(collisionInfo.CompareTag("Player"))
        {
            Debug.Log("Entered Desk");
            gameManager.atDesk = deskNumber;
            if(gameManager.desksAvailable[deskNumber] == false)
            {
                showMessage = true;
            }
        }
    }
    void OnTriggerExit(Collider collisionInfo)
    {
        if(collisionInfo.CompareTag("Player"))
        {
            Debug.Log("Left Desk");
            gameManager.atDesk = 0;
            showMessage = false;
        }
    }

    void Update()
    {
        if(gameManager.desksAvailable[deskNumber] == false)
        {
            waitTime++;
            if(waitTime == 1000) //how much time between chosing and desk becoming active
            {
                Debug.Log("Desk " + deskNumber + " activated");
            }
            if(waitTime == 2000) // how much time before starts ragging
            {
                Debug.Log("Desk " + deskNumber + " ragging");
                gameManager.desksRagging[deskNumber] = true;
            }
            if(waitTime > 2000)
            {
                gameManager.rageMeter++;
            }
        }
    }

    private void OnGUI()
    {
        if (showMessage)
        {
            GUI.Label(new Rect(350, 250, 200, 50), message);
        }
    }
}
