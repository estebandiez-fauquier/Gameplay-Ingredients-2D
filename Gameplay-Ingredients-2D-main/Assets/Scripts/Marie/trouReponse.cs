using UnityEngine;

public class TrouReponse : MonoBehaviour
{
    public QuizManager quizManager;
    public int indexReponse;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        bool correct = quizManager.VerifierReponse(indexReponse);

        if (!correct)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().Respawn();
            GameObject.FindWithTag("Player").GetComponent<PlayerLife>().Hurt(1);
        }
    }
}
