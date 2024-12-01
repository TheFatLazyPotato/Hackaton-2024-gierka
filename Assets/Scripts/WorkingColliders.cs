using System.Collections.Generic;
using UnityEngine;

public class WorkingColliders : MonoBehaviour
{
    [SerializeField] private GameObject[] colliders;
    [HideInInspector] public List<HitboxHitAction> actions;
    private void Awake()
    {
        foreach(GameObject col in colliders)
        {
            HitboxHitAction[] components = col.GetComponents<HitboxHitAction>();
            foreach(HitboxHitAction hha in components)
            {
                if (hha == null)
                    continue;
                actions.Add(hha);
            }
        }
    }
}
