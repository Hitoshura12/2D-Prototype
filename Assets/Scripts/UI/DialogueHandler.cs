using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHandler : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Text characterName;
    [SerializeField]
    private UnityEngine.UI.Text textArea;

    [SerializeField]
    private CanvasGroup rootCanvas;
    [SerializeField]
    private CanvasGroup textCanvas;
    [SerializeField]
    private RectTransform LeftSpriteRect;
    [SerializeField]
    private RectTransform RightSpriteRect;
    [SerializeField]
    private Image leftSprite;
    [SerializeField]
    private Image rightSprite;


    [SerializeField]
    private string playerName = "Hitoshura";


    private Text currentText;


    private Response currentResponse;

    private DialogueObject dialogueObject;

    private void Start()
    {
        dialogueObject = new DialogueObject(DialogueProvider.LoadDialogues().dialogue);
        textCanvas.alpha = 0f;
        rootCanvas.alpha = 1f;
        //Text text = DialogueProvider.LoadDialogues().dialogue.texts[0];
        Text text = dialogueObject.GetText();

        //dialogueObject.GetText();
        StartCoroutine(HandleText(text));
        Debug.Log(dialogueObject.dialogue.portrait);
        //ChangeLeftSprite(SpriteProvider.Instance.GetSprite(dialogueObject.dialogue.portrait));
        //ChangeRightSprite(SpriteProvider.Instance.GetSprite(dialogueObject.dialogue.portrait2));


    }

    private IEnumerator HandleText(Text text)
    {
        currentText = text;

        if (text.content != null || text.content.Length != 0)
        {

            for (int i = 0; i < text.content.Length; i++)

            {
                Content content = text.content[i];
                string content2 = content.content;
                //Debug.Log(content.portrait);
                //Debug.Log(content.portrait2);
                yield return ShowText(text.name, content2, content.portrait, content.portrait2);
            }
        }
        if (currentText.finished)
        {
            textArea.text = "BINGO!";
            Debug.Log("Finished...");
        }
        else
        {
            yield return ShowResponse(text.response);
        }
       

        yield return null;
    }
    private IEnumerator ShowText(string name, string text, string portrait,string portrait2)
    {
        textCanvas.alpha = 1f;

        characterName.text = name;
        textArea.text = "";
       
        if (portrait!=null && !portrait.Equals("")) //&& !portrait.Equals("")
        {
          ChangeLeftSprite(SpriteProvider.Instance.GetSprite(portrait));


        }
        if (portrait2!=null && !portrait2.Equals("")) //&& !portrait2.Equals("")
        {
            Debug.Log(portrait2);
            ChangeRightSprite(SpriteProvider.Instance.GetSprite(portrait2));
          
        }
     
        

        char[] charArray = text.ToCharArray();
        foreach (char c in charArray)
        {
            textArea.text += c;
            yield return new WaitForSeconds(0.08f);
        }
        yield return null;
    }
    private IEnumerator HandleResponse(ResponseContent responseContent)
    {

        for (int i = 0; i < responseContent.contents.Length; i++)
        {
            Content content = responseContent.contents[i];
            string content2 = content.content;
            yield return (ShowText(playerName, content2, content.portrait,content.portrait2));

        }

            Text text = dialogueObject.GetText(responseContent.next);
            yield return HandleText(text);


        yield return null;
    }
    private IEnumerator ShowResponse(string response)
    {
        Response response2 = (currentResponse = dialogueObject.GetResponse(response));
        if (response2 != null)
        {
            for (int i = 0; i < response2.responseContent.Length; i++)
            {
                if (response2.responseContent[i].finished)
                {
                    textArea.text = "BINGO!";
                    Debug.Log("Quitting...");
                    // yield break;
                }
                else
                {
                    yield return (HandleResponse(response2.responseContent[i]));
                }

            }

        }

        yield return null;
    }

    private void ChangeLeftSprite(Sprite sprite)
    {
        leftSprite.sprite = sprite;
        //Color color = leftSprite.color;
        //color.a = 1;
        //// leftSprite.CrossFadeColor(color, 0.4f, true, true);
        //leftSprite.CrossFadeAlpha(0f, 2f, true);
    }

    private void ChangeRightSprite(Sprite sprite)
    {
        rightSprite.sprite = sprite;
      //  Color color = rightSprite.color;
      //  color.a= 1;
      ////  leftSprite.CrossFadeColor(color, 0.4f, true, true);
      //  leftSprite.CrossFadeAlpha(0f, 2f, true);

    }
}
