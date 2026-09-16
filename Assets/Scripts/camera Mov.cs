using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class cameraMov : MonoBehaviour
{
    public Transform player_transform;
    public float smooth_speed = 5f;
    private PlayerMov player;
    private void Update()
    {
        if (player == null)
        {
            Vector3 mov = new Vector3(
                player_transform.position.x,
                 player_transform.position.y,
                 transform.position.z
                 );
                               //  Vector3.Lerp(A,B,T)
            transform.position = Vector3.Lerp(transform.position, mov, smooth_speed * Time.deltaTime);
            //A = المكان الحالي (transform.position - مكان الكاميرا دلوقتي)
            // B = المكان المستهدف(mov - مكان اللاعب اللي عايزين نوصله)
            //t = رقم بين 0 و1 بيحدد "قد ايه اتحركنا من A لحد B"
        }
    }
}
