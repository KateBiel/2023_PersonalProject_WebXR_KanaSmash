﻿using MessagePack;
using MessagePack.Resolvers;
using MessagePack.Unity;
using MessagePack.Unity.Extension;

namespace ShapesXr
{
    public static class Utils
    {
        public static void InitializeMessagePack()
        {
            StaticCompositeResolver.Instance.Register(
                Resolvers.GeneratedResolver.Instance,
                UnityBlitResolver.Instance,
                UnityResolver.Instance,
                NativeGuidResolver.Instance,
                StandardResolver.Instance
            );

            MessagePackSerializer.DefaultOptions = MessagePackSerializerOptions.Standard.WithResolver(StaticCompositeResolver.Instance);
        }
    }
}