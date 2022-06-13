// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Kognity">
// Copyright (c) Kognity. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace HorrorSounds
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Exiled.API.Interfaces;

    /// <inheritdoc />
    public class Config : IConfig
    {
        /// <inheritdoc />
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets the minimum time between each voice line playing.
        /// </summary>
        [Description("The minimum time between each voice line playing.")]
        public int MinimumTime { get; set; } = 60;

        /// <summary>
        /// Gets or sets the maximum time between each voice line playing.
        /// </summary>
        [Description("The maximum time between each voice line playing.")]
        public int MaximumTime { get; set; } = 120;

        /// <summary>
        /// Gets or sets the available voice lines to play.
        /// </summary>
        [Description("The available voice lines to play.")]
        public List<string> VoiceLines { get; set; } = new()
        {
            "pitch_0.1 SCP pitch_0.1 6 pitch_0.1 8 pitch_0.1 2",
            "pitch_0.1 scpsubjects",
            "pitch_0.1 Camera",
            "pitch_0.1 Celsius",
            "pitch_0.1 .g7 h h",
            "pitch_0.1 ContainedSuccessfully",
            "pitch_0.1 Decontamination",
            "pitch_0.1 Intersection",
            "pitch_0.1 NineTailedFox",
            "pitch_0.1 Personnel h h a c s e",
            "pitch_0.1 HasEntered",
            "pitch_0.1 e s s",
            "pitch_0.1 c c h",
            "pitch_0.1 ChaosInsurgency",
        };
    }
}