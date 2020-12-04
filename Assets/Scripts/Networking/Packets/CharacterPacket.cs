using MessagePack;
using UnityEngine;

[MessagePackObject]
public struct CharacterPacket
{
    [Key(0)]
    public Vector2 Pos;
}
