using System.Collections;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueHolder : MonoBehaviour
    {
        private IEnumerator dialogueSeq;
        private bool dialogueFinished;
        public GameObject dialogueTrigger;

        private void Awake()
        {
            dialogueSeq = dialogueSequence();
            StartCoroutine(dialogueSeq);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Deactivate();
                gameObject.SetActive(false);
                StopCoroutine(dialogueSeq);
            }
        }

        private IEnumerator dialogueSequence()
        { 
            for (int i = 0; i < transform.childCount; i++)
            {
                    Deactivate();
                    transform.GetChild(i).gameObject.SetActive(true);
                    if (i == (transform.childCount - 1))
                    {
                        Debug.Log("Here");
                        gameObject.SetActive(false);
                        dialogueFinished = true;
                        dialogueTrigger.SetActive(false);
                    }
                    yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogueLine>().finished);
            }
        }

        private void Deactivate()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
