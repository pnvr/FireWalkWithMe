using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class Player : MonoBehaviour
{
    MapManager map;
    Vector2Int pos;
    Animator animator;

    [SerializeField] AudioSource stepAudioSource;
    [SerializeField] AudioSource doorOpenAudioSource;

    void Start()
    {
        map = FindAnyObjectByType<MapManager>();
        pos = map.WorldToMapCoords(transform.position);
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {

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
            if ( node.type != NodeType.Wall )
            {
                pos = tryMovePos;

                stepAudioSource.Play();
            }

            if ( node.type == NodeType.Door )
            {
                Door door = node.obj.GetComponent<Door>();
                door.OpenDoor();

                doorOpenAudioSource.Play();
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


}



