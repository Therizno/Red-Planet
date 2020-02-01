using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehavior : MonoBehaviour
{
    private GameManager gm;

    [SerializeField] float enterBuildingThreshold;
    [SerializeField] float leaveBuildingThreshold;


    private float defaultZ;


    // Start is called before the first frame update (use for getting other objects)
    void Start()
    {
        gm = GameManager.getInstance();

        defaultZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.getDistanceFromPlayer(gameObject) < enterBuildingThreshold)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, gm.getPlayerZ() - 5);
        }
        else if(gm.getDistanceFromPlayer(gameObject) > leaveBuildingThreshold)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, defaultZ);
        }
    }
}
