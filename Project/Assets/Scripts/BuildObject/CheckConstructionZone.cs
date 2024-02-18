using UnityEngine;

public class CheckConstructionZone : MonoBehaviour
{
    public int groundMask;
    public Material checkZoneMaterial;

    private void Update()
    {
        CheckZone();
        RotateZone();
    }

    public void RotateZone()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            transform.Rotate(Vector3.up * 4f, Space.Self);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            transform.Rotate(Vector3.down * 4f, Space.Self);
        }
    }
    public bool CheckZone()
    {
        Collider[] hits = Physics.OverlapBox(transform.position, transform.localScale/2);
        
        foreach (Collider col in hits)
        {
            if(groundMask != col.gameObject.layer)
            {
                checkZoneMaterial.color = Color.red;
                return false;
            }
        }
        checkZoneMaterial.color = Color.green;
        return true;
    }
}
