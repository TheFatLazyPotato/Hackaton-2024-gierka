using UnityEngine;
using UnityEngine.SceneManagement;

public class DynamicButtonsWithSceneChange : MonoBehaviour
{
    private int clickedButtonIndex = -1;
    private bool showWindow = false;

    string[] titles0 = { "Podziękowania", "Pozostało 5 dni!", "message.txt" };

    private void OnGUI()
    {
        if(GlobalVariables.day == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                if (GUI.Button(new Rect(10, 10 + (i * 40), 100, 30), titles0[i]))
                {
                    clickedButtonIndex = i; 
                    showWindow = true;
                }
            }
        }

        if (showWindow)
        {
            GUI.Window(0, new Rect(120, 10, 300, 240), DrawWindow, "Message");
        }

        if (GUI.Button(new Rect(10, 10 + (6 * 40) + 10, 200, 30), "Zamknij pocztę"))
        {
            ChangeScene();
        }
    }

    private void DrawWindow(int windowID)
    {
        switch(GlobalVariables.day){
            case 0:
                switch(clickedButtonIndex){
                    case 0:
                    GUI.Label(new Rect(10, 20, 280, 200), "[management@axerro.mmm]\n Dziękujemy Ci za Twoją 10-letnią współpracę i cieszymy się, z Twojego wkładu w dobrobyt naszej firmy. Mamy przyjemność przyznać Ci premię wysokości 10$! Jesteśmy dumni z posiadania takiego pracownika i liczymy, że zostaniesz z nami dłużej.\nZ wyrazami szacunku AXERRO");
                        break;
                    case 1:
                    GUI.Label(new Rect(10, 20, 280, 200), "[biuropodróży@azbest.mmm]\nOferty wyjazdowe Karaiby od 20000$!\nNie zwlekaj dłużej, obserwowane oferty znikają w mgnieniu oka.\nOstatnie dostępne oferty Last Minute, już za 5 dni!");
                        break;
                    case 2:
                    GUI.Label(new Rect(10, 20, 280, 200), "[redacted@sos.mmm]\nWiadomość zostanie usunięta po odczytaniu.\nJeżeli chcesz zarobić dodatkowy grosz, wydobądź z firmy plik dokumentów o nazwie „Wykaz kosztów z października 2041”, pogrzeb trochę w szafkach pewnie znajdziesz lub zignoruj tę wiadomość.");
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
        // Add a Close button to the window
        if (GUI.Button(new Rect(110, 200, 80, 30), "Close"))
        {
            showWindow = false; // Hide the window
        }
    }

    private void ChangeScene()
    {
        // Change to the scene with build index 1
        SceneManager.LoadScene(1);
        GlobalVariables.day++;
    }
}
