using System;
using System.Collections;
using System.Collections.Generic;
using MessagePack;
using Steamworks;
using UnityEngine;

public class SteamHelpers
{
    private static readonly Dictionary<Type, object> Callbacks = new Dictionary<Type, object>();

    public static CSteamID Me;

    /// <summary>
    /// Register callback to steam
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="func"></param>
    public static void RegisterCallback<T>(Callback<T>.DispatchDelegate func)
    {
        Callbacks.Add(typeof(T), Callback<T>.Create(func));
    }

    public static void Init()
    {
        Me = SteamUser.GetSteamID();
    }

    public static bool GetPacket<T>(out T packet, out CSteamID remoteId, PacketChannel channel)
    {
        if (SteamNetworking.IsP2PPacketAvailable(out var packetSize, (int)channel))
        {
            var packetBytes = new byte[packetSize];
            if (!SteamNetworking.ReadP2PPacket(packetBytes, packetSize, out var bytesRead, out var packetRemoteId, (int)channel) || packetRemoteId == Me)
            {
                packet = default(T);
                remoteId = packetRemoteId;
                return false;
            }
            packet = MessagePackSerializer.Deserialize<T>(packetBytes);
            remoteId = packetRemoteId;
            return true;
        }
        packet = default(T);
        remoteId = default(CSteamID);
        return false;
    }

    public enum PacketChannel
    {
    }
}
