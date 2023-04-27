using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public float followSpeed = 10;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        GameObject newTarget = GameObject.FindGameObjectWithTag("Player");
        if (newTarget != null)
        {
            target = newTarget.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            GameObject newTarget = GameObject.FindGameObjectWithTag("Player");
            if (newTarget != null)
            {
                target = newTarget.transform;
            }
            if (target.position.y > -4)
            {
                Vector3 newPos = new Vector3(target.position.x, target.position.y, -10);
                transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
            }

        }
    }
}
