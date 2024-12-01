using UnityEngine;

public class ShelfTrigger : MonoBehaviour
{
    private bool showMessage = false;
    private string message = "Hold [spacebar] to search";
    public float progressSpeed = 20f; 
    private float progress = 0f; 
    private bool isComplete = false; 
    public bool inRange = false;
    public int docChance;
    public int messageTime = 0;
    public int timesSearched;

    private void Start()
    {
        timesSearched = 0;
    }
    private void Update()
    {
        if(messageTime>0)
        {
            if(messageTime == 1)
            {
                message = "Hold [spacebar] to search";
            }
            messageTime--;
        }
        if (Input.GetKey(KeyCode.Space) && !isComplete && inRange)
        {
            progress += progressSpeed * Time.deltaTime;
            progress = Mathf.Clamp(progress, 0, 100);

            if (progress >= 100)
            {
                isComplete = true;
                docChance = Rnd100() - timesSearched*2;
                timesSearched++;
                if(docChance >= 90)
                {
                    GlobalVariables.docsStollen++;
                    GlobalVariables.docsStollen++;
                    message = "Znaleziono sporo dokumentów";
                    messageTime = 1000;
                    GlobalVariables.hasStolen = true;
                }
                else if(docChance <= 90 && docChance > 60)
                {
                    GlobalVariables.docsStollen++;
                    message = "Znaleziono dokumenty";
                    messageTime = 1000;
                    GlobalVariables.hasStolen = true;
                }
                else
                {
                    message = "Nic nie znaleziono";
                    messageTime = 1000;
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            progress = 0f;
            isComplete = false;
        }
    }

    private void OnGUI()
    {
        if (Input.GetKey(KeyCode.Space) && !isComplete && inRange)
        {
            GUI.Box(new Rect(350, 250, 200, 25), "");
            GUI.Box(new Rect(350, 250, 200 * (progress / 100f), 25), "");
        }
        if (showMessage)
        {
            GUI.Label(new Rect(370, 250, 200, 50), message);
        }

    }

    void OnTriggerEnter (Collider other)
    {
        inRange = true;
        showMessage = true;
    }
    
    void OnTriggerExit (Collider other)
    {
        inRange = false;
        showMessage = false;
    }

    public int Rnd100()
    {
        System.Random random = new System.Random();
        return random.Next(1, 101); 
    }
}
