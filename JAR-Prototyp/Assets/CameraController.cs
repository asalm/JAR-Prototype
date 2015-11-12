using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public Camera PlayerCamera;
    public GameObject player;

    public float camDistance_x = -15f;
    public float camDistance_y = 2.4f;


    void Update()
    {
        //Holt sich die Raumkoordinate des GameObjecs player und erstellt einen neuen Vector.
        Vector3 CamPos = new Vector3(player.transform.position.x - camDistance_x, player.transform.position.y + camDistance_y, player.transform.position.z);
        //Transformiert die Kamera zu gebenenm Vector
        PlayerCamera.transform.position = CamPos;
    }
}
