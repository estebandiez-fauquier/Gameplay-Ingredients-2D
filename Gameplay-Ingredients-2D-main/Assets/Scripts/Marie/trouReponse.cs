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
            // Appelle ici la fonction de respawn
            // de ton système de checkpoints existant.
        }
    }
}
