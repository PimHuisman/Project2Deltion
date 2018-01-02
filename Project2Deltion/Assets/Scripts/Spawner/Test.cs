using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public List<GameObject> test = new List<GameObject>();
    [SerializeField] private Transform point;
	void Start ()
    {
        Instantiate(test[0], point.position, transform.rotation);
    }

}
