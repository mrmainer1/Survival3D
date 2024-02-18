using UnityEngine;

public class ExitMenu : MonoBehaviour
{
    public void Exit()
    {
        Destroy(transform.parent.gameObject);
    }
}
