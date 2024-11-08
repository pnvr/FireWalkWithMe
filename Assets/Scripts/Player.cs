using Unity.VisualScripting;

using UnityEngine;

public class Player : MonoBehaviour
{
    MapManager map;
    Vector2Int pos;
    Animator animator;

    [SerializeField] AudioSource stepAudioSource;
    [SerializeField] AudioSource doorOpenAudioSource;
    [SerializeField] AudioSource keyOpenAudioSource;
    [SerializeField] AudioSource extinguisherAudioSource;

    public AudioSource[] pickFireExAudioSource = new AudioSource[3];

    private bool isDead = false;

    void Start()
    {
        map = FindAnyObjectByType<MapManager>();
        pos = map.WorldToMapCoords(transform.position);
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        //if (isDead) {
        //    return;
        //}

        var tryMovePos = pos;
        if ( Input.GetKeyDown(KeyCode.UpArrow) )
        {
            tryMovePos += Vector2Int.up;
            animator.Play("Back Walking");
        }
        if ( Input.GetKeyDown(KeyCode.DownArrow) )
        {
            tryMovePos += Vector2Int.down;
            animator.Play("Forward Walking");
        }
        if ( Input.GetKeyDown(KeyCode.LeftArrow) )
        {
            tryMovePos += Vector2Int.left;
            animator.Play("Left Walking");
        }
        if ( Input.GetKeyDown(KeyCode.RightArrow) )
        {
            tryMovePos += Vector2Int.right;
            animator.Play("Right Walking");
        }

        if ( tryMovePos != pos )
        {
            var node = map.data [ tryMovePos.x ] [ tryMovePos.y ];


            if ( node.type == NodeType.Door )
            {
                Door door = node.obj.GetComponent<Door>();
                if ( !GameManager.Instance.CheckKey() )
                {
                    tryMovePos = pos;
                    
                    return;
                }
             if (door != null && door.CompareTag("DoorA") || door.CompareTag("DoorY")) 
                door.OpenDoor();
                doorOpenAudioSource.Play();
                
            }
            if ( node.type == NodeType.Key )
            {
                Key key = node.obj.GetComponent<Key>();
                key.PickupKey();
                keyOpenAudioSource.Play();
            }

            if ( node.type == NodeType.Extinguisher )
            {
                Extinguisher extinguisher = node.obj.GetComponent<Extinguisher>();

                extinguisher.PickupExtinguisher();

                int rand = Random.Range(0, 3);
                pickFireExAudioSource[rand].Play();
            }

            if ( node.type == NodeType.Fire )
            { if ( GameManager.Instance.CheckExtinguisher() )
                {
                    GameManager.Instance.UseExtinguisher();
                    extinguisherAudioSource.Play();

                    Debug.Log("Sammutinta k�ytetty");
                    node.obj.GetComponentInParent<Fire>().Reset();
                }
                else
                {

                    GameManager.Instance.UseLives();
                }
            }
            if ( node.type != NodeType.Wall )
            {
                pos = tryMovePos;

                stepAudioSource.Play();
            }

        }

        transform.position = map.MapToWorldCoords(pos);








        //if ( Input.GetKeyDown(KeyCode.UpArrow) )
        //{
        //    var node = map.data [ pos.x ] [ pos.y + 1 ];
        //    if ( node.type != NodeType.Wall )
        //    {
        //        pos.y += 1;
        //    }

        //}
        //if ( Input.GetKeyDown(KeyCode.DownArrow) )
        //{
        //    var node = map.data [ pos.x ] [ pos.y - 1 ];
        //    if ( node.type != NodeType.Wall )
        //    {
        //        pos.y -= 1;
        //    }
        //}
        //if ( Input.GetKeyDown(KeyCode.LeftArrow) )
        //{
        //    var node = map.data [ pos.x - 1 ] [ pos.y ];
        //    if ( node.type != NodeType.Wall )
        //    {
        //        pos.x -= 1;
        //    }
        //}
        //if ( Input.GetKeyDown(KeyCode.RightArrow) )
        //{
        //    var node = map.data [ pos.x + 1 ] [ pos.y ];
        //    if ( node.type != NodeType.Wall )
        //    {
        //        pos.x += 1;
        //    }
        //}


    }

    public void Die() {
        isDead = true;
        animator.Play("Burning");
        animator.SetBool("IsDead", true); //looppaa animaatiota
    }

    public void Restart() {
        isDead = false;
        animator.SetBool("IsDead", false);
        transform.position = Vector3.zero;
    }
}



