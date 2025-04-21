using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using agora_gaming_rtc;

public class AgoraInterfaceScript : MonoBehaviour
{
    static IRtcEngine mRtcEngine;
    public static string appId = "40aef3f8854141edbf90dda63f68ba65";

    // Start is called before the first frame update
    void Start()
    {
        mRtcEngine = IRtcEngine.GetEngine(appId);
        Debug.Log("Version : " + IRtcEngine.GetSdkVersion());

        mRtcEngine.OnJoinChannelSuccess += (string channelName, uint uid, int elapsed) => {
            string joinSuccessMessage = string.Format("joinChannel callback uid: {0}, channel: {1}, version: {2}", uid, channelName, IRtcEngine.GetSdkVersion());
            Debug.Log(joinSuccessMessage);
        };

        mRtcEngine.OnLeaveChannel += (RtcStats stats) => {
            string leaveChannelMessage = string.Format("onLeaveChannel callback duration {0}, tx: {1}, rx: {2}, tx kbps: {3}, rx kbps: {4}", stats.duration, stats.txBytes, stats.rxBytes, stats.txKBitRate, stats.rxKBitRate);
            Debug.Log(leaveChannelMessage);
        };

        mRtcEngine.OnUserJoined += (uint uid, int elapsed) => {
            string userJoinedMessage = string.Format("onUserJoined callback uid {0} {1}", uid, elapsed);
            Debug.Log(userJoinedMessage);
        };

        mRtcEngine.OnUserOffline += (uint uid, USER_OFFLINE_REASON reason) => {
            string userOfflineMessage = string.Format("onUserOffline callback uid {0} {1}", uid, reason);
            Debug.Log(userOfflineMessage);
        };

        mRtcEngine.OnVolumeIndication += (AudioVolumeInfo[] speakers, int speakerNumber, int totalVolume) => {
            if (speakerNumber == 0 || speakers == null)
            {
                Debug.Log(string.Format("onVolumeIndication only local {0}", totalVolume));
            }

            for (int idx = 0; idx < speakerNumber; idx++)
            {
                string volumeIndicationMessage = string.Format("{0} onVolumeIndication {1} {2}", speakerNumber, speakers[idx].uid, speakers[idx].volume);
                Debug.Log(volumeIndicationMessage);
            }
        };

        mRtcEngine.OnUserMutedAudio += (uint uid, bool muted) => {
            string userMutedMessage = string.Format("onUserMuted callback uid {0} {1}", uid, muted);
            Debug.Log(userMutedMessage);
        };

        mRtcEngine.OnWarning += (int warn, string msg) => {
            string description = IRtcEngine.GetErrorDescription(warn);
            string warningMessage = string.Format("onWarning callback {0} {1} {2}", warn, msg, description);
            Debug.Log(warningMessage);
        };

        mRtcEngine.OnError += (int error, string msg) => {
            string description = IRtcEngine.GetErrorDescription(error);
            string errorMessage = string.Format("onError callback {0} {1} {2}", error, msg, description);
            Debug.Log(errorMessage);
        };

        mRtcEngine.OnRtcStats += (RtcStats stats) => {
            string rtcStatsMessage = string.Format("onRtcStats callback duration {0}, tx: {1}, rx: {2}, tx kbps: {3}, rx kbps: {4}, tx(a) kbps: {5}, rx(a) kbps: {6} users {7}",
                stats.duration, stats.txBytes, stats.rxBytes, stats.txKBitRate, stats.rxKBitRate, stats.txAudioKBitRate, stats.rxAudioKBitRate, stats.userCount);
            Debug.Log(rtcStatsMessage);

            int lengthOfMixingFile = mRtcEngine.GetAudioMixingDuration();
            int currentTs = mRtcEngine.GetAudioMixingCurrentPosition();

            string mixingMessage = string.Format("Mixing File Meta {0}, {1}", lengthOfMixingFile, currentTs);
            Debug.Log(mixingMessage);
        };

        mRtcEngine.OnAudioRouteChanged += (AUDIO_ROUTE route) => {
            string routeMessage = string.Format("onAudioRouteChanged {0}", route);
            Debug.Log(routeMessage);
        };

        mRtcEngine.OnRequestToken += () => {
            string requestKeyMessage = string.Format("OnRequestToken");
            Debug.Log(requestKeyMessage);
        };

        mRtcEngine.OnConnectionInterrupted += () => {
            string interruptedMessage = string.Format("OnConnectionInterrupted");
            Debug.Log(interruptedMessage);
        };

        mRtcEngine.OnConnectionLost += () => {
            string lostMessage = string.Format("OnConnectionLost");
            Debug.Log(lostMessage);
        };

        mRtcEngine.SetLogFilter(LOG_FILTER.INFO);

        // mRtcEngine.setLogFile("path_to_file_unity.log");

        mRtcEngine.SetChannelProfile(CHANNEL_PROFILE.CHANNEL_PROFILE_GAME);

        // mRtcEngine.SetChannelProfile (CHANNEL_PROFILE.GAME_COMMAND_MODE);
        // mRtcEngine.SetClientRole (CLIENT_ROLE.BROADCASTER); 
    }

    // Update is called once per frame
    void Update()
    {
    }
}
