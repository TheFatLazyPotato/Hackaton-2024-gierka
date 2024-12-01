using System.Collections.Generic;
using System.Collections;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;

public class HitboxHitAction : MonoBehaviour
{
    [SerializeField] public string actionName;
    [SerializeField] private AnimationClip myAnimation;
    [SerializeField] private AnimationClip myAnimationReversed;
    [HideInInspector] public bool active = false;
    [SerializeField] private string[] required;
    [SerializeField] private string[] blocking;

    //[HideInInspector] private Animation anim;
    [HideInInspector] private Animator anim;
    public AnimationEvent myEvent;
    public AnimationEvent myEventReverse;

    public int animatorLayer;

    [HideInInspector] public List<HitboxHitAction> requiredActions;
    [HideInInspector] public List<HitboxHitAction> blockingActions;
    [HideInInspector] public List<HitboxHitAction> depedentActions;

    public GameObject rootBone;
    private Vector3 deltaPos;
    private Quaternion deltaRot;

    /*
    //private Transform trStart;
    public Vector3 posStart;
    public Quaternion rotStart;
    //private Transform trAnimationEnd;
    public Vector3 posEnd;
    public Quaternion rotEnd;
    */
    private void Start()
    {
        List<HitboxHitAction> hha = gameObject.GetComponentInParent<WorkingColliders>().actions;

        // Zdobadz wszystkie zaleznosci
        foreach (string s in required)
        {
            for (int i = 0; i < hha.Count; i++)
            {
                if (s != hha[i].actionName)
                    continue;

                requiredActions.Add(hha[i]);
                break;
            }
        }
        foreach (string s in blocking)
        {
            for (int i = 0; i < hha.Count; i++)
            {
                if (s != hha[i].actionName)
                    continue;

                blockingActions.Add(hha[i]);
                break;
            }
        }
        for (int i = 0; i < hha.Count; i++)
        {
            if (actionName != hha[i].actionName)
                continue;
            if (hha[i].GetInstanceID() == GetInstanceID())
                continue;
            depedentActions.Add(hha[i]);
        }

        anim = gameObject.GetComponentInParent<Animator>();

        /*
        myEvent.functionName = "AnimationFinish";
        myEventReverse.functionName = "AnimationReverseFinish";
        myEvent.time = myAnimation.length;
        myEventReverse.time = myAnimationReversed.length;
        myEvent.intParameter = myAnimation.GetInstanceID();
        myEventReverse.intParameter = myAnimationReversed.GetInstanceID();

        myAnimation.AddEvent(myEvent);
        myAnimationReversed.AddEvent(myEventReverse);
        
        //anim = gameObject.GetComponent<Animation>();
        anim.AddClip(myAnimation, myAnimation.name);
        anim.AddClip(myAnimationReversed, myAnimationReversed.name);

        posStart = rootBone.transform.position;
        rotEnd = rootBone.transform.rotation;
        */

        deltaPos = rootBone.transform.position - gameObject.transform.position;
        deltaRot = Quaternion.Inverse(rootBone.transform.rotation) * gameObject.transform.rotation;
    }

    private void FixedUpdate()
    {
        if (rootBone != null)
        {
            gameObject.GetComponent<MeshCollider>().transform.SetPositionAndRotation(rootBone.transform.position - deltaPos, rootBone.transform.rotation * deltaRot);
            Vector3 ax = Quaternion.Angle(rootBone.transform.rotation, Vector3.Up);
            gameObject.GetComponent<MeshCollider>().transform.Translate(rootBone.transform.rotation.)
        }
    }

    void OnMouseDown()
    {
        // Czesc zamknieta
        if (active == false)
        {
            //foreach (HitboxHitAction hha in requiredActions)
            for (int i = 0; i < requiredActions.Count; i++)
            {
                if (requiredActions[i].active == false)
                {
                    Debug.Log("Nie da siê otworzyæ:");
                    return;
                }
            }
            //foreach (HitboxHitAction hha in blockingActions)
            for (int i = 0; i < blockingActions.Count; i++)
            {
                if (blockingActions[i].active == true)
                {
                    Debug.Log("Nie da siê otworzyæ");
                    return;
                }
            }

            Debug.Log("Otwarto");
            /*
            anim.clip = myAnimation;
            anim.PlayQueued(anim.clip.name, QueueMode.CompleteOthers, PlayMode.StopSameLayer);
            */
            anim.Play(myAnimation.name, animatorLayer);
            active = true;
        }
        // Czesc otwarta
        else
        {
            //foreach(HitboxHitAction hha in depedentActions)
            for (int i = 0; i < depedentActions.Count; i++)
            {
                if (depedentActions[i].active == true)
                {
                    Debug.Log("Nie da siê zamkn¹æ");
                    return;
                }
            }

            Debug.Log("Zamkniêto");
            /*
            gameObject.transform.SetPositionAndRotation(posStart, rotStart);
            anim.clip = myAnimationReversed;
            anim.PlayQueued(anim.clip.name, QueueMode.CompleteOthers, PlayMode.StopSameLayer);
            */
            anim.Play(myAnimationReversed.name, animatorLayer);
            //anim.Play("idle", animatorLayer);
            active = false;
        }

    }

    

    
}
