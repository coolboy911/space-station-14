using Content.Shared.CCVar;

namespace Content.Server.GameTicking
{
    public sealed partial class GameTicker
    {
        [ViewVariables]
        public bool LobbyEnabled { get; private set; } = false;

        [ViewVariables]
        public bool DummyTicker { get; private set; } = false;

        [ViewVariables]
        public TimeSpan LobbyDuration { get; private set; } = TimeSpan.Zero;

        [ViewVariables]
        public bool DisallowLateJoin { get; private set; } = false;

        [ViewVariables]
        public bool StationOffset { get; private set; } = false;

        [ViewVariables]
        public bool StationRotation { get; private set; } = false;

        [ViewVariables]
        public float MaxStationOffset { get; private set; } = 0f;

        [ViewVariables]
        public string DiscordWebhook { get; private set; } = "";

        [ViewVariables]
        public string DiscordRoleId { get; private set; } = "";

#if EXCEPTION_TOLERANCE
        [ViewVariables]
        public int RoundStartFailShutdownCount { get; private set; } = 0;
#endif

        private void InitializeCVars()
        {
            _configurationManager.OnValueChanged(CCVars.GameLobbyEnabled, value => LobbyEnabled = value, true);
            _configurationManager.OnValueChanged(CCVars.GameDummyTicker, value => DummyTicker = value, true);
            _configurationManager.OnValueChanged(CCVars.GameLobbyDuration, value => LobbyDuration = TimeSpan.FromSeconds(value), true);
            _configurationManager.OnValueChanged(CCVars.GameDisallowLateJoins,
                value => { DisallowLateJoin = value; UpdateLateJoinStatus(); }, true);
            _configurationManager.OnValueChanged(CCVars.StationOffset, value => StationOffset = value, true);
            _configurationManager.OnValueChanged(CCVars.StationRotation, value => StationRotation = value, true);
            _configurationManager.OnValueChanged(CCVars.MaxStationOffset, value => MaxStationOffset = value, true);
            _configurationManager.OnValueChanged(CCVars.DiscordRoundWebhook, value => DiscordWebhook = value, true);
            _configurationManager.OnValueChanged(CCVars.DiscordRoundRoleId, value => DiscordRoleId = value, true);
#if EXCEPTION_TOLERANCE
            _configurationManager.OnValueChanged(CCVars.RoundStartFailShutdownCount, value => RoundStartFailShutdownCount = value, true);
#endif
        }
    }
}
