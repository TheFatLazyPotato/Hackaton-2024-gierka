using UnityEngine;
using UnityEngine.SceneManagement;

public class DynamicButtonsWithSceneChange : MonoBehaviour
{
    private int clickedButtonIndex = -1;
    private bool showWindow = false;

    string[] titles0 = { "Podziękowania", "Pozostało 5 dni!", "message.txt" };
    string[] titles1 = { "Podsumowanie", "Powiadomienie", "message.txt" };
    string[] titles2 = { "Podsumowanie", "Kawa"};
    string[] titles3 = { "Podsumowanie", "Już tylko 2 dni!!!"};
    string[] titles4 = { "Podsumowanie"};
    string[] titles5 = new string[2];
    public int referenceStolen = 0;
    public int papersValue = 1000;

    private void Start()
    {
        GlobalVariables.money += 5 + GlobalVariables.docsStollen * papersValue;
        referenceStolen = GlobalVariables.docsStollen;
        GlobalVariables.docsStollen = 0;
        if(GlobalVariables.money > 20000)
        {
            titles5[0] = "Podsumowanie";
            titles5[1] = "Potwierdzenie";
        }
        else
        {
            titles5[0] = "Podsumowanie";
            titles5[1] = "WEZWANIE";
        }
    }
    private void OnGUI()
    {
        if(GlobalVariables.day == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                if (GUI.Button(new Rect(10, 50 + (i * 40), 100, 30), titles0[i]))
                {
                    clickedButtonIndex = i; 
                    showWindow = true;
                }
            }
        }
        if(GlobalVariables.day == 1)
        {
            if(referenceStolen > 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (GUI.Button(new Rect(10, 50 + (i * 40), 100, 30), titles1[i]))
                    {
                        clickedButtonIndex = i; 
                        showWindow = true;
                    }
                }
            }
            else
            {
                    if (GUI.Button(new Rect(10, 50, 100, 30), titles1[0]))
                    {
                        clickedButtonIndex = 0; 
                        showWindow = true;
                    }
            }
        }
        if(GlobalVariables.day == 2)
        {
            for (int i = 0; i < 2; i++)
            {
                if (GUI.Button(new Rect(10, 50 + (i * 40), 100, 30), titles2[i]))
                {
                    clickedButtonIndex = i; 
                    showWindow = true;
                }
            }
        }
        if(GlobalVariables.day == 3)
        {
            for (int i = 0; i < 2; i++)
            {
                if (GUI.Button(new Rect(10, 50 + (i * 40), 100, 30), titles3[i]))
                {
                    clickedButtonIndex = i; 
                    showWindow = true;
                }
            }
        }
        if(GlobalVariables.day == 4)
        {
            if (GUI.Button(new Rect(10, 50, 100, 30), titles4[0]))
            {
                clickedButtonIndex = 0; 
                showWindow = true;
            }
        }
        if(GlobalVariables.day == 5)
        {
            for (int i = 0; i < 2; i++)
            {
                if (GUI.Button(new Rect(10, 50 + (i * 40), 100, 30), titles5[i]))
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
                    GUI.Label(new Rect(10, 20, 280, 200), "[redacted@sos.mmm]\nJeżeli chcesz zarobić dodatkowy grosz, wydobądź z firmy plik dokumentów o nazwie „Wykaz kosztów z października 2041”, pogrzeb trochę w szafkach pewnie znajdziesz lub zignoruj tę wiadomość.");
                        break;
                    default:
                        break;
                }
                break;
            case 1:
                if(referenceStolen > 0)
                {
                    switch(clickedButtonIndex){
                    case 0:
                    GUI.Label(new Rect(10, 20, 280, 200), "[balance@bank.sosa.mmm]\nPensja:10$ \nCzynsz: -2$ \nRachunki Codzienne: -3$ \nAnonimowa wpłata: " + referenceStolen * papersValue + "\nSaldo: " + GlobalVariables.money);
                        break;
                    case 1:
                    GUI.Label(new Rect(10, 20, 280, 200), "[management@axerro.mmm]\nDo pracowników, ostatnimi czasy doszło w naszej firmie do nadużyć, związanych z rozpowszechnianiem poufnych dokumentów. Niech wiadome będzie sprawcy, że jego czyny nie zostaną bezkarne, zostanie on złapany i ukarany adekwatnie do swych czynów.\nZ wyrazami szacunku AXERRO");
                        break;
                    case 2:
                    GUI.Label(new Rect(10, 20, 280, 200), "[redacted@sos.mmm]\nNie ma za co, jeżeli trafią do Twoich rąk inne poufne dokumenty, wiesz co z nim robić.");
                        break;
                    default:
                        break;
                    }
                }
                else
                {
                    switch(clickedButtonIndex){
                    case 0:
                        GUI.Label(new Rect(10, 20, 280, 200), "[balance@bank.sosa.mmm]\nPensja:10$ \nCzynsz: -2$ \nRachunki Codzienne: -3$ \nSaldo: " + GlobalVariables.money);
                        break;
                    default:
                        break;
                    }
                }
                break;
            case 2:
                switch(clickedButtonIndex){
                    case 0:
                        if(referenceStolen>0){
                            GUI.Label(new Rect(10, 20, 280, 200), "[balance@bank.sosa.mmm]\nPensja:10$ \nCzynsz: -2$ \nRachunki Codzienne: -3$ \nAnonimowa wpłata: " + referenceStolen * papersValue + "\nSaldo: " + GlobalVariables.money);
                        }
                        else{
                            GUI.Label(new Rect(10, 20, 280, 200), "[balance@bank.sosa.mmm]\nPensja:10$ \nCzynsz: -2$ \nRachunki Codzienne: -3$ \nSaldo: " + GlobalVariables.money);
                        }
                        break;
                    case 1:
                    GUI.Label(new Rect(10, 20, 280, 200), "[management@axerro.mmm]\nPragniemy przypomnieć że w trosce o dobro naszych pracowników, każdemu przysługuje jeden kubek dziennie na koszt firmy.\nZ wyrazami szacunku AXERRO");
                        break;
                    default:
                        break;
                }
                break;
            case 3:
                switch(clickedButtonIndex){
                    case 0:
                        if(referenceStolen>0){
                            GUI.Label(new Rect(10, 20, 280, 200), "[balance@bank.sosa.mmm]\nPensja:10$ \nCzynsz: -2$ \nRachunki Codzienne: -3$ \nAnonimowa wpłata: " + referenceStolen * papersValue + "\nSaldo: " + GlobalVariables.money);
                        }
                        else{
                            GUI.Label(new Rect(10, 20, 280, 200), "[balance@bank.sosa.mmm]\nPensja:10$ \nCzynsz: -2$ \nRachunki Codzienne: -3$ \nSaldo: " + GlobalVariables.money);
                        }
                        break;
                    case 1:
                    GUI.Label(new Rect(10, 20, 280, 200), "[Pozostały 2 dni, nie zwlekaj dłużej!\nWpłać 20000$ i ciesz się gorącym wybrzeżem Karaibów.");
                        break;
                    default:
                        break;
                }
                break;
            case 4:
                GUI.Label(new Rect(10, 20, 280, 200), "[balance@bank.sosa.mmm]\nPensja:10$ \nCzynsz: -2$ \nRachunki Codzienne: -3$ \nAnonimowa wpłata: " + referenceStolen * papersValue + "\nSaldo: " + GlobalVariables.money);
                break;
            case 5:
                if(GlobalVariables.money>=20000){
                    switch(clickedButtonIndex){
                        case 0:
                        if(referenceStolen>0){
                            GUI.Label(new Rect(10, 20, 280, 200), "[balance@bank.sosa.mmm]\nPensja:10$ \nCzynsz: -2$ \nRachunki Codzienne: -3$ \nAnonimowa wpłata: " + referenceStolen * papersValue + "\nSaldo: " + GlobalVariables.money);
                        }
                        else{
                            GUI.Label(new Rect(10, 20, 280, 200), "[balance@bank.sosa.mmm]\nPensja:10$ \nCzynsz: -2$ \nRachunki Codzienne: -3$ \nSaldo: " + GlobalVariables.money);
                        }
                        break;
                        case 1:
                        GUI.Label(new Rect(10, 20, 280, 200), "[[biuropodróży@azbest.mmm]\nDziękujemy za wpłatę 200000, życzymy udanych wakacji!");
                            break;
                        default:
                            break;
                    }
                }
                else{
                    switch(clickedButtonIndex){
                        case 0:
                        if(referenceStolen>0){
                            GUI.Label(new Rect(10, 50, 280, 200), "[balance@bank.sosa.mmm]\nPensja:10$ \nCzynsz: -2$ \nRachunki Codzienne: -3$ \nAnonimowa wpłata: " + referenceStolen * papersValue + "\nSaldo: " + GlobalVariables.money);
                        }
                        else{
                            GUI.Label(new Rect(10, 50, 280, 200), "[balance@bank.sosa.mmm]\nPensja:10$ \nCzynsz: -2$ \nRachunki Codzienne: -3$ \nSaldo: " + GlobalVariables.money);
                        }
                        break;
                        case 1:
                        GUI.Label(new Rect(10, 50, 280, 200), "[management@axerro.mmm]\nWzmywamy do NATYCHMIASTOWEGO stawienia się w biurze.");
                            break;
                        default:
                            break;
                        }
                    }
                break;

            default:
                break;
            }
        
        if (GUI.Button(new Rect(110, 200, 80, 30), "Close"))
        {
            showWindow = false;
        }
    }

    private void ChangeScene()
    {
        if(GlobalVariables.day == 5)
        {
            if(GlobalVariables.coffeeCount == 5)
            {
                SceneManager.LoadScene(9);
            }
            else if(GlobalVariables.money >= 20000)
            {
                SceneManager.LoadScene(8);
            }
            else if(GlobalVariables.hasStolen == false)
            {
                SceneManager.LoadScene(6);
            }
            else
            {
                SceneManager.LoadScene(7);
            }
        }
        SceneManager.LoadScene(3);
        GlobalVariables.day++;
    }
}
