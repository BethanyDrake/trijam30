using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentScript : MonoBehaviour
{
    // Start is called before the first frame update

    public bool rising;

    public int team;

    public float speed;
    public float maxHeight;

    public void Lift() {

        GetComponent<Rigidbody>().isKinematic = true;
        rising = true;

    }


    void Start()
    {
        rising = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (rising) {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed *Time.deltaTime, transform.position.z);
            if (transform.position.y >= maxHeight) {
                transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
                rising = false;
            }
        }
    }
}
