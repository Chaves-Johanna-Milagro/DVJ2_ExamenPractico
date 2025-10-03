using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;

//los objetos que usen el reconocedor deben tenerlo como componente
public class VoiceRecognizer : MonoBehaviour 
{
    private KeywordRecognizer _keywordRecognizer;
    private Dictionary<string, System.Action> _keywords = new Dictionary<string, System.Action>();

    public void AddCommand(string command, System.Action action)
    {
        if (!_keywords.ContainsKey(command))
        {
            //comandos
            _keywords.Add(command, action);
        }

    }


    private void Start()
    {
        _keywordRecognizer = new KeywordRecognizer(_keywords.Keys.ToArray());

        _keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;

        _keywordRecognizer.Start();
    }


    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        // if the keyword recognized is in our dictionary, call that Action.
        if (_keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }

}
