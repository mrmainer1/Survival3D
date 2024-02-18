using System;
using UnityEngine;

public class Sway : MonoBehaviour
{
    public Vector3 intialSwayPosition;
    public float swayAmount;
    public float maxSwayAmount;
    public float swaySmoothing;

    private void Awake()
    {
        intialSwayPosition = transform.localPosition;
    }

    private void LateUpdate()
    {
        float mX = -Input.GetAxis("Mouse X") * swayAmount;
        float mY = -Input.GetAxis("Mouse Y") * swayAmount;

        mX = Mathf.Clamp(mX, -maxSwayAmount, maxSwayAmount);
        mY = Mathf.Clamp(mY, -maxSwayAmount, maxSwayAmount);
        Vector3 finalSwayPosition = new Vector3(mX,mY,0);

        Vector3 move = Vector3.Lerp(transform.localPosition, finalSwayPosition + intialSwayPosition,
            Time.deltaTime * swaySmoothing);
        transform.localPosition = move ;
        transform.localEulerAngles = move;
    }
}
