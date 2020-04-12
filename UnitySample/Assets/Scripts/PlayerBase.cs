using UnityEngine;

public class PlayerBase : MonoBehaviour
{
	void OnTriggerEnter()
	{
		Player player = transform.parent.gameObject.GetComponent<Player>();
		player.SetGrounded(true);
	}
}
