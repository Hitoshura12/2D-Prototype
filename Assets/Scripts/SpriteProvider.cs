using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteProvider : MonoBehaviour
{

    public static SpriteProvider Instance;

    public Dictionary<string, Sprite> portraits = new Dictionary<string, Sprite>();

    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
        StartCoroutine(LoadPortraits());
    }

    public Sprite GetSprite(string name)
    {
        if (portraits.TryGetValue(name,out var value))
        {
            return value;
        }

        return null;
    }

    public IEnumerator LoadPortraits()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("Textures");
        foreach (Sprite sprite in sprites)
        {
            portraits.Add(sprite.name, sprite);
        }
        yield return null;
    }
}
