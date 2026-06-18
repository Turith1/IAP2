using UnityEngine;

public class HealthBilboard : MonoBehaviour
{

    [SerializeField] private Transform cam;

    // Update is called once per frame
    void Update()
    {
        if(cam != null)
        {
            transform.rotation = cam.rotation;
        }
    }
}
