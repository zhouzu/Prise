﻿using System;

namespace Prise.Plugin
{
    [System.AttributeUsage(System.AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class PluginServiceAttribute : System.Attribute
    {
        Type serviceType;
        public Type ServiceType
        {
            get { return this.serviceType; }
            set { this.serviceType = value; }
        }

        ProvidedBy providedBy;
        public ProvidedBy ProvidedBy
        {
            get { return this.providedBy; }
            set { this.providedBy = value; }
        }

        Type bridgeType;
        [Obsolete("Usage of a BridgeType is obsolete, please use ProxyType instead. Existing plugins will continue to function as normal.", false)]
        public Type BridgeType
        {
            get { return this.bridgeType; }
            set { this.bridgeType = value; }
        }

        Type proxyType;
        public Type ProxyType
        {
            get { return this.proxyType; }
            set { this.proxyType = value; }
        }
    }
}