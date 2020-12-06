using System;
using System.Collections;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;
using UnityEngine;

public class PacketResolver : IFormatterResolver
{
    public static readonly PacketResolver Instance = new PacketResolver();
    public IMessagePackFormatter<T> GetFormatter<T>()
    {
        return FormatterCache<T>.Formatter;
    }

    private static class FormatterCache<T>
    {
        public static readonly IMessagePackFormatter<T> Formatter;

        static FormatterCache()
        {
            Formatter = (IMessagePackFormatter<T>)PacketResolverFormatterHelper.GetFormatter(typeof(T));
        }
    }
}

internal static class PacketResolverFormatterHelper
{
    private static readonly Dictionary<Type, object> FormatterMap = new Dictionary<Type, object>()
    {
        {typeof(CharacterPacket), new CharacterPacketFormatter()}
    };

    internal static object GetFormatter(Type t)
    {
        object formatter;
        if (FormatterMap.TryGetValue(t, out formatter))
        {
            return formatter;
        }

        return null;
    }

}

public sealed class CharacterPacketFormatter : IMessagePackFormatter<CharacterPacket>
{
    public CharacterPacket Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.IsNil)
        {
            throw new InvalidOperationException("typecode is null, struct not supported");
        }

        IFormatterResolver resolver = options.Resolver;
        var length = reader.ReadArrayHeader();

        var x = default(Vector2);
        for (int i = 0; i < length; i++)
        {
            var key = i;
            switch (key)
            {
                case 0:
                    x = resolver.GetFormatterWithVerify<Vector2>().Deserialize(ref reader, options);
                    break;
                default:
                    reader.Skip();
                    break;
            }
        }

        var result = new CharacterPacket
        {
            Pos = x
        };
        return result;
    }

    public void Serialize(ref MessagePackWriter writer, CharacterPacket value, MessagePackSerializerOptions options)
    {
        IFormatterResolver resolver = options.Resolver;
        writer.WriteArrayHeader(1);
        resolver.GetFormatterWithVerify<Vector2>().Serialize(ref writer, value.Pos, options);
    }
}

