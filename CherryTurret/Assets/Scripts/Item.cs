using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Camera cam;
    public GameObject SoundManager;

    private AudioSource sManager;
    private RaycastHit rayCastHit;

    void Start()
    {
        sManager = SoundManager.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out rayCastHit))
            {
                if(rayCastHit.collider != null)
                {
                    if (rayCastHit.collider.gameObject.CompareTag("Item"))
                    {
                        sManager.Play();
                        Destroy(rayCastHit.collider.gameObject);
                    }
                }
            }
        }
    }
}
