using System.Collections;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueHolder : MonoBehaviour
    {
        private IEnumerator dialogueSeq;
        private IEnumerator dialogueSeq2;
        private bool dialogueFinished;
        public GameObject dialogueTrigger;

        private void Awake()
        {
            dialogueSeq = dialogueSequence();
            dialogueSeq2 = dialogueSequence2();
            StartCoroutine(dialogueSeq);
            StartCoroutine(dialogueSeq2);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Deactivate();
                gameObject.SetActive(false);
                StopCoroutine(dialogueSeq);
                StopCoroutine(dialogueSeq2);
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
                        gameObject.SetActive(false);
                        dialogueFinished = true;
                        dialogueTrigger.SetActive(false);
                    }
                    yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogueLine>().finished);
            }
        }

        private IEnumerator dialogueSequence2()
        {
            if (!dialogueFinished)
            {
                for (int i = 0; i < transform.childCount - 1; i++)
                {
                    Deactivate();
                    transform.GetChild(i).gameObject.SetActive(true);
                    yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogueLine>().finished);
                }
            }
            else
            {
                int index = transform.childCount - 1;
                Deactivate();
                transform.GetChild(index).gameObject.SetActive(true);
                yield return new WaitUntil(() => transform.GetChild(index).GetComponent<DialogueLine>().finished);
            }

            dialogueFinished = true;
            gameObject.SetActive(false);
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
