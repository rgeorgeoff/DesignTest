using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class DetectPathComplete : MonoBehaviour
{
    public AIDestinationSetter DestinationSetter;
    public PlayMakerFSM FSMToSendEventTo;
    public AIPath path;
    public List<Transform> Locations = new ();
    public int currentLoc;
    public float pauseDurationAfterReachDestination = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        path.OnTargetReachedActions.Add(PathCompletedSendFSMEvent);
    }

    private void PathCompletedSendFSMEvent()
    {
        StartCoroutine(GoToNextLocation());
    }

    // Update is called once per frame
    public IEnumerator GoToNextLocation()
    {
        yield return new WaitForSeconds(pauseDurationAfterReachDestination);
        currentLoc++;
        if (currentLoc >= Locations.Count)
        {
            currentLoc = 0;
        }
        //set loc
        DestinationSetter.Target = Locations[currentLoc];
    }
}
