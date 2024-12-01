using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class ToRepair
{
    public string action;
    [HideInInspector] public HitboxHitAction hha;
    public bool activeTask;
    //public Mesh brokenPart;
    public GameObject signal;

    public void Activate()
    {
        if (activeTask)
            return;
        if (signal != null)
            signal.SetActive(true);
        activeTask = true;
        //hha.GetComponent<SkinnedMeshRenderer>().
    }

    public void Deactivate()
    {
        if (!activeTask)
            return;
        if (signal != null)
            signal.SetActive(false);
        activeTask = false;
    }

    public bool isActivated() { return activeTask; }
}

public class RepairTaskManager : MonoBehaviour
{
    public ToRepair[] tasks;
    public int nTasks;
    public int remainingTasks;

    void Start()
    {
        List<HitboxHitAction> hha = GetComponent<WorkingColliders>().actions;
        // Zdobadz kolidery
        foreach(ToRepair tr in tasks)
        {
            for(int i = 0; i < hha.Count; i++)
            {
                if (tr.action != hha[i].actionName)
                    continue;
                tr.hha = hha[i];
                break;
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        remainingTasks = 0;
        if (tasks.Length <= nTasks)
        {
            foreach(ToRepair tr in tasks)
            {
                tr.Activate();
                remainingTasks++;
            }
            return;
        }
        uint i = 0;
        while(remainingTasks < nTasks)
        {
            if(Random.Range(0f, 1f) <= .5f && !tasks[i%tasks.Length].isActivated())
            {
                tasks[i % tasks.Length].Activate();
                remainingTasks++;
            }
            i++;
            if (i > 1000)
                break;
        }
    }

    private void OnDisable()
    {
        foreach (ToRepair tr in tasks)
        {
            tr.Deactivate();
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (ToRepair tr in tasks)
        {
            if(tr.hha.active == true && tr.activeTask == true)
            {
                tr.Deactivate();
                remainingTasks--;
            }
            if (remainingTasks == 0)
                break;
        }
    }
}
