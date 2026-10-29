
using UnityEngine;

public class ActivationQuiz : MonoBehaviour
{
    public QuizManager quizManager;
    private bool active = false;

    private void OnTriggerEnter(Collider other)
    {
        if (active || !other.CompareTag("Player"))
            return;

        active = true;
        quizManager.ActiverQuiz();
    }
}
