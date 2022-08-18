using UnityEngine;

public class Saw : MonoBehaviour
{

    [SerializeField] Transform start;
    [SerializeField] Transform end;
    [SerializeField] Transform sawSprite;
    private float positionPercent;
    private int direction = 1;

    void Update()
    {
        positionPercent += Time.deltaTime * direction;
        sawSprite.position = Vector3.Lerp(start.position, end.position, positionPercent);
        if (positionPercent >= 1 && direction == 1)
        {
            direction = -1;
        }
        else if(positionPercent <=0 && direction == -1)
        {
            direction = 1;
        }
    }
}
