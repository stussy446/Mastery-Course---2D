using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] Transform start;
    [SerializeField] Transform end;
    [SerializeField] Transform sawSprite;
    [SerializeField] float sawSpeed = 3f;

    private float positionPercent;
    private int direction = 1;

    void Update()
    {
        MoveSaw();
        SwitchSawDirectionIfNeeded();
    }

    private void MoveSaw()
    {
        float distance = Vector3.Distance(start.position, end.position);
        float speedForDistance = sawSpeed / distance;

        positionPercent += Time.deltaTime * direction * speedForDistance;

        sawSprite.position = Vector3.Lerp(start.position, end.position, positionPercent);
    }

    private void SwitchSawDirectionIfNeeded()
    {
        if (positionPercent >= 1 && direction == 1)
        {
            direction = -1;
        }
        else if (positionPercent <= 0 && direction == -1)
        {
            direction = 1;
        }
    }
}
