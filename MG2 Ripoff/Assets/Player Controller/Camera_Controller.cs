using UnityEngine;
using System.Collections;
public class Camera_Controller : Player_Controller{
    public GameObject followTarget;
    private Vector3 targetPosition;
    public float peakDistance;
    public float moveSpeed;
    private bool peaking;

    private float peakX;
    private float peakY;
   

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
       /** peaking = false;
        if (peaking != true)
        {
            targetPosition = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        usePeak();*/
    }

    bool usePeak()
    {
        peakAt(ref lastMove);
        if (Input.GetAxisRaw("Fire2") > 0.5f)
        {
            transform.Translate(new Vector3());
            peaking = true;
            return true;
        }
        if (Input.GetAxisRaw("Fire2") < 0.5f)
            return false;
        return false;
    }

    void peakAt(ref Vector2 newVec)
    {
        peakX = newVec.x;
        peakY = newVec.y;
        
    }
}
