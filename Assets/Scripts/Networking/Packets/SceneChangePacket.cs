using System.Collections;
using System.Collections.Generic;
using MessagePack;
using UnityEngine;
using static Dungeoneer.Managers.SceneChangingManager;

namespace Dungeoneer.Netowrking.Packets
{

    [MessagePackObject]
    public struct SceneChangePacket
    {
        [Key(0)]
        public Scene Scene { get; set; }
    }
}
