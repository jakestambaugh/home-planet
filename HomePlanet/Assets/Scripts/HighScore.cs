using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
 
public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI textBox;
    int highScore = 0;
    // Update is called once per frame
    void Start() {
        highScore = PlayerPrefs.GetInt("highscore", 0);
        textBox.SetText("High Score: " + highScore.ToString());
        // StartCoroutine(Upload());
    }

    public void SetHighScore(int newHighScore) {
        if (highScore < newHighScore) {
            PlayerPrefs.SetInt("highscore", newHighScore);
            highScore = newHighScore;
            textBox.SetText("High Score: " + highScore.ToString());
        }
    }
 
    IEnumerator Upload() {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add( new MultipartFormDataSection("field1=foo&field2=bar") );
        formData.Add( new MultipartFormFileSection("my file data", "myfile.txt") );

        UnityWebRequest www = UnityWebRequest.Post("http://www.my-server.com/myform", formData);
        yield return www.SendWebRequest();
 
        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            Debug.Log("Form upload complete!");
        }
    }
}
