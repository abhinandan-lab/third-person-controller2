using Cinemachine;
using UnityEngine;

public class plyrScript : MonoBehaviour
{
    public Joystick js;
    Animator an;
    bool sprintT=false;
    float a,z;

    Vector2 b;
    [SerializeField] float spedd = 1;
    public CinemachineFreeLook cmfl;

    private void Start()
    {
        an = GetComponent<Animator>();
    }

    private void Update()
    {
        a = z;
        float x = js.Horizontal;
        z = js.Vertical;


        an.SetFloat("inputX", x);
        an.SetFloat("inputY", z);

        if (sprintT)
            an.SetBool("sprint", true);
        else
            an.SetBool("sprint", false);

        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch t = Input.GetTouch(i);
            if (t.position.x > Screen.width / 2)
            {
                switch (t.phase)
                {
                    case TouchPhase.Began:

                        b = t.position;
                        // print(a.y + " : a");

                        break;

                    case TouchPhase.Moved:

                        b = t.deltaPosition * spedd * Time.deltaTime;
                        //cam.transform.rotation = Quaternion.Euler(cam.transform.eulerAngles.x + b.y, cam.transform.eulerAngles.y+b.x, 0);
                        cmfl.m_XAxis.Value += b.x * 50;
                        cmfl.m_YAxis.Value += -b.y;
                        print(cmfl.m_YAxis.Value);
                        break;

                }
            }
        }
    }

    private void LateUpdate()
    {
        if (a != z)
        {
            print("different");
            sprintT = false;
        }   
    }

    public void Sprint()
    {
        sprintT = !sprintT;
    }

}
