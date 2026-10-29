
using UnityEngine;
using TMPro;

public class QuizManager : MonoBehaviour
{
    [System.Serializable]
    public class Question
    {
        public string question;
        public string[] reponses;
        public int bonneReponse;
    }

    public Question[] questions;
    public TMP_Text texteQuestion;
    public TMP_Text[] textesReponses;

    public int questionActuelle = 0;

    void Start()
    {
        AfficherQuestion();
    }

    public void AfficherQuestion()
    {
        if (questionActuelle >= questions.Length)
        {
            texteQuestion.text = "Quiz terminé !";
            return;
        }

        Question q = questions[questionActuelle];
        texteQuestion.text = q.question;

        for (int i = 0; i < textesReponses.Length; i++)
        {
            textesReponses[i].text =
                i < q.reponses.Length ? q.reponses[i] : "";
        }
    }

    public bool VerifierReponse(int choix)
    {
        if (questionActuelle >= questions.Length)
            return false;

        if (choix == questions[questionActuelle].bonneReponse)
        {
            questionActuelle++;
            AfficherQuestion();
            return true;
        }

        return false;
    }
}
