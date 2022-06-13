// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="Kognity">
// Copyright (c) Kognity. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace HorrorSounds
{
    using System;
    using Exiled.API.Features;

    /// <summary>
    /// The main plugin class.
    /// </summary>
    public class Plugin : Plugin<Config>
    {
        private EventHandlers eventHandlers;

        /// <inheritdoc />
        public override string Author => "Kognity";

        /// <inheritdoc />
        public override string Name => "Horror Sounds";

        /// <inheritdoc />
        public override string Prefix => "HorrorSounds";

        /// <inheritdoc />
        public override Version RequiredExiledVersion { get; } = new(5, 2, 1);

        /// <inheritdoc />
        public override Version Version { get; } = new(2, 0, 0);

        /// <inheritdoc />
        public override void OnEnabled()
        {
            eventHandlers = new EventHandlers(this);
            Exiled.Events.Handlers.Server.RoundEnded += eventHandlers.OnRoundEnded;
            Exiled.Events.Handlers.Server.RoundStarted += eventHandlers.OnRoundStarted;
            Exiled.Events.Handlers.Server.WaitingForPlayers += eventHandlers.OnWaitingForPlayers;
            base.OnEnabled();
        }

        /// <inheritdoc />
        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.RoundEnded -= eventHandlers.OnRoundEnded;
            Exiled.Events.Handlers.Server.RoundStarted -= eventHandlers.OnRoundStarted;
            Exiled.Events.Handlers.Server.WaitingForPlayers -= eventHandlers.OnWaitingForPlayers;
            eventHandlers = null;
            base.OnDisabled();
        }
    }
}