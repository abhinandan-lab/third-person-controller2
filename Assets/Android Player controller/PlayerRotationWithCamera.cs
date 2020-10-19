using UnityEngine;

public class PlayerRotationWithCamera : MonoBehaviour
{

    private void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0),14);
    }
}
