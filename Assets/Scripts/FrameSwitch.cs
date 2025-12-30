using UnityEngine;

public class FrameSwitch : MonoBehaviour
{
    [Tooltip("Список всех локаций (фреймов)")]
    public GameObject[] frames;

    [Tooltip("Индекс локации, которая должна включаться при входе в этот триггер")]
    public int targetFrameIndex;

    private void Start()
    {
        // При старте включаем только первую локацию
        for (int i = 0; i < frames.Length; i++)
        {
            if (frames[i] != null)
                frames[i].SetActive(i == 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SwitchToFrame(targetFrameIndex);
        }
    }

    private void SwitchToFrame(int index)
    {
        for (int i = 0; i < frames.Length; i++)
        {
            if (frames[i] != null)
                frames[i].SetActive(i == index);
        }
    }
}
