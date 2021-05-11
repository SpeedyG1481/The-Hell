using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
   
    public GameObject player;
    public GameObject camera;
    public Vector3 delay;
    // Update is called once per frame
    void Update()
    {
        visionCurse();

        mirrorCurses();


    }

    private void mirrorCurses()
    {
        if (CurseManager.curse == "mirrorXcurse")
        {
            camera.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            camera.transform.position = new Vector3(player.transform.position.x + delay.x, player.transform.position.y + delay.y, -1);
        }
        else if (CurseManager.curse != "mirrorYcurse")
        {
            camera.transform.position = new Vector3(player.transform.position.x + delay.x, player.transform.position.y + delay.y, -1);
            camera.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
        {
            camera.transform.position = new Vector3(player.transform.position.x + delay.x, player.transform.position.y + delay.y, 109);
            camera.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }
    public void visionCurse()
    {
        camera.transform.position = new Vector3(player.transform.position.x + delay.x, player.transform.position.y + delay.y, -1);
        if (CurseManager.curse == "visionCurse")
        {
            
            camera.GetComponent<Camera>().orthographicSize = 13f;
        }
        else
        {
            camera.GetComponent<Camera>().orthographicSize = 31f;
        }
    }
}
