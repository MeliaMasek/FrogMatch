using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MatchBehavior : MonoBehaviour
{
    public Id idObj;
    public UnityEvent matchEvent, noMatchEvent, NoMatchDelayedEvent;

    /* Original Code 
    private IEnumerator OnTriggerEnter(Collider other)
    {
        //Debug.Log(idObj);
        //Debug.Log(other.GetComponent<IdContainerBehavior>().idObj);
        
        var tempObj = other.GetComponent<IdContainerBehavior>();
        if (tempObj == null)
            yield break;

        var otherId = tempObj.idObj;
        if (otherId == idObj)
        {
            //Debug.Log("Match");
            matchEvent.Invoke();
        }

        else
        {
            //Debug.Log("No Match");
            noMatchEvent.Invoke();
            yield return new WaitForSeconds(0.5f);
            NoMatchDelayedEvent.Invoke();
        }
    }
    */
    private IEnumerator OnMouseDown()
    {
        //Debug.Log(idObj);
        //Debug.Log(other.GetComponent<IdContainerBehavior>().idObj);
        
        var tempObj = GetComponent<IdContainerBehavior>();
        if (tempObj == null)
            yield break;

        var otherId = tempObj;
        if (otherId == idObj)
        {
            //Debug.Log("Match");
            matchEvent.Invoke();
        }

        else
        {
            //Debug.Log("No Match");
            noMatchEvent.Invoke();
            yield return new WaitForSeconds(0.5f);
            NoMatchDelayedEvent.Invoke();
        }
    }
}

