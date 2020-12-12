

using Dungeoneer.Spells.Dungeoneer.Spells;
using MessagePack;
using UnityEngine;

namespace Dungeoneer.Netowrking.Packets
{
    [MessagePackObject]
    public class SpellPacket
    {
        [Key(0)]
        public Spell Spell { get; set; }
        [Key(1)]
        public Vector2 Pos { get; set; }
        [Key(2)]
        public SpellAction Action { get; set; }
    }

    public enum SpellAction
    {
        Create,
        Move,
        Shoot
    }
}
