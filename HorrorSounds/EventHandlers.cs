// -----------------------------------------------------------------------
// <copyright file="EventHandlers.cs" company="Kognity">
// Copyright (c) Kognity. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace HorrorSounds
{
    using System.Collections.Generic;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using Exiled.Loader;
    using MEC;

    /// <summary>
    /// Handles events derived from <see cref="Exiled.Events.Handlers"/>.
    /// </summary>
    public class EventHandlers
    {
        private readonly Plugin plugin;
        private CoroutineHandle coroutineHandle;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandlers"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        /// <inheritdoc cref="Exiled.Events.Handlers.Server.OnRoundEnded(RoundEndedEventArgs)"/>
        public void OnRoundEnded(RoundEndedEventArgs ev)
        {
            if (coroutineHandle.IsRunning)
                Timing.KillCoroutines(coroutineHandle);
        }

        /// <inheritdoc cref="Exiled.Events.Handlers.Server.OnRoundStarted"/>
        public void OnRoundStarted()
        {
            coroutineHandle = Timing.RunCoroutine(RoundLoop());
        }

        /// <inheritdoc cref="Exiled.Events.Handlers.Server.OnWaitingForPlayers"/>
        public void OnWaitingForPlayers()
        {
            if (coroutineHandle.IsRunning)
                Timing.KillCoroutines(coroutineHandle);
        }

        private IEnumerator<float> RoundLoop()
        {
            while (true)
            {
                int time = Loader.Random.Next(plugin.Config.MinimumTime, plugin.Config.MaximumTime);
                yield return Timing.WaitForSeconds(time);
                Cassie.Message(plugin.Config.VoiceLines[Loader.Random.Next(plugin.Config.VoiceLines.Count)], true, false);
            }
        }
    }
}