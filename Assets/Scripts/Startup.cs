using System.Collections;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Resolvers;
using MessagePack.Unity;
using UnityEngine;

public class Startup
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
    static void Initialize()
    {

        StaticCompositeResolver.Instance.Register(
            MessagePack.Resolvers.GeneratedResolver.Instance,
            UnityResolver.Instance,
            MessagePack.Unity.Extension.UnityBlitWithPrimitiveArrayResolver.Instance,
            StandardResolver.Instance
        );
        var option = MessagePackSerializerOptions.Standard.WithResolver(StaticCompositeResolver.Instance);

        MessagePack.MessagePackSerializer.Serialize(new CharacterPacket());

    }
#if UNITY_EDITOR


    [UnityEditor.InitializeOnLoadMethod]
    static void EditorInitialize()
    {
        Initialize();
    }

#endif
}
