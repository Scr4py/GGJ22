using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{

    public Sprite ArtSprite;
    public Sprite ProggerSprite;

    private SpriteRenderer spriteRenderer;

    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.switchWorlds += EventManager_switchWorlds;    
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void EventManager_switchWorlds(World world)
    {
        switch (world)
        {
            case World.ArtWorld:
                rigid.isKinematic = false;
                spriteRenderer.sprite = ArtSprite;
                break;
            case World.ProggerWorld:
                rigid.isKinematic = true;
                spriteRenderer.sprite = ProggerSprite;
                break;
            default:
                break;
        }
    }
}
