using System.Collections;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Resolvers;
using MessagePack.Unity;
using MessagePack.Unity.Extension;
using UnityEngine;

public class Startup
{
    private static bool _initialized = false;
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Initialize()
    {

        if (!_initialized)
        {
            StaticCompositeResolver.Instance.Register(
                        UnityResolver.Instance,
                        UnityBlitWithPrimitiveArrayResolver.Instance,
                        StandardResolver.Instance,
                        PacketResolver.Instance
                    );
            var options = MessagePackSerializerOptions.Standard.WithResolver(StaticCompositeResolver.Instance);
            MessagePackSerializer.DefaultOptions = options;

            var packet = MessagePack.MessagePackSerializer.Serialize(new CharacterPacket
            {
                Pos = new Vector2(2.1f, 3.5f)
            });
            var packet1 = MessagePack.MessagePackSerializer.Deserialize<CharacterPacket>(packet);
            _initialized = true;
        }

    }


#if UNITY_EDITOR


    [UnityEditor.InitializeOnLoadMethod]
    static void EditorInitialize()
    {
        Initialize();
    }

#endif
}
