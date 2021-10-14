using System;
using System.Collections.Generic;

namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public static class RequestTypes
    {
        public static readonly Dictionary<string, Type> Map = new Dictionary<string, Type>
        {
            {CommandReply, typeof(CommandReplyPayload)},
            {Environment, typeof(EnvironmentReplyPayload)},
            {Hello, typeof(HelloRequestPayload)},
            {LoginRequest, typeof(LoginRequestPayload)},
            {QuoterGroupsUpdate, typeof(QuoterGroupsUpdatePayload)},
            {QuoterSettingsUpdate, typeof(QuoterSettingsUpdatePayload)},
            {SelectUserRoleRequest, typeof(SelectUserRoleRequestPayload)},
            {SubscribeQuoterGroups, typeof(SubscribeQuoterGroupsPayload)},
            {SubscribeQuoterSettings, typeof(SubscribeQuoterSettingsPayload)},
            {ChangeQuoterSettingsRequest, typeof(ChangeQuoterSettingsRequestPayload)},
            {InstrumentsUpdate, typeof(InstrumentsUpdatePayload)},
            {SubscribeInstruments, typeof(SubscribeInstrumentsPayload)},
            {SubscribePositions, typeof(SubscribePositionsPayload)},
            {PositionSnapshot, typeof(PositionSnapshotPayload)},
            {SubscribePositionManagerSettings, typeof(SubscribePositionManagerSettingsPayload)},
            {PositionManagerSettingsUpdate, typeof(PositionManagerSettingsUpdatePayload)},
            {SubscribeOrderQuoterRules, typeof(SubscribeOrderQuoterRulesPayload)},
            {OrderQuoterRulesUpdate, typeof(OrderQuoterRulesUpdatePayload)},
            {ChangeOrderQuoterRulesRequest, typeof(ChangeOrderQuoterRulesRequestPayload)},
            {SubscribeAssets, typeof(SubscribeAssetsPayload)},
            {AssetsUpdate, typeof(AssetsUpdatePayload)},
            {ChangePositionManagerSettingRequest, typeof(ChangePositionManagerSettingRequestPayload)},
            {TagsUpdate, typeof(TagsUpdatePayload)}
        };

        public const string CommandReply = "CommandReply";
        public const string Environment = "Environment";
        public const string Hello = "Hello";
        public const string LoginRequest = "LoginRequest";
        public const string QuoterGroupsUpdate = "QuoterGroupsUpdate";
        public const string QuoterSettingsUpdate = "QuoterSettingsUpdate";
        public const string SelectUserRoleRequest = "SelectUserRoleRequest";
        public const string SubscribeQuoterGroups = "SubscribeQuoterGroups";
        public const string SubscribeQuoterSettings = "SubscribeQuoterSettings";
        public const string ChangeQuoterSettingsRequest = "ChangeQuoterSettingsRequest";
        public const string InstrumentsUpdate = "InstrumentsUpdate";
        public const string SubscribeInstruments = "SubscribeInstruments";
        public const string SubscribePositions = "SubscribePositions";
        public const string PositionSnapshot = "PositionSnapshot";
        public const string SubscribePositionManagerSettings = "SubscribePositionManagerSettings";
        public const string PositionManagerSettingsUpdate = "PositionManagerSettingsUpdate";
        public const string SubscribeOrderQuoterRules = "SubscribeOrderQuoterRules";
        public const string OrderQuoterRulesUpdate = "OrderQuoterRulesUpdate";
        public const string ChangeOrderQuoterRulesRequest = "ChangeOrderQuoterRulesRequest";
        public const string SubscribeAssets = "SubscribeAssets";
        public const string AssetsUpdate = "AssetsUpdate";
        public const string ChangePositionManagerSettingRequest = "ChangePositionManagerSettingRequest";
        public const string SubscribeTags = "SubscribeTags";
        public const string TagsUpdate = "TagsUpdate";
    }
}