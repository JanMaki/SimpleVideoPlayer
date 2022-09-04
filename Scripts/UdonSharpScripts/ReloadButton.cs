using UdonSharp;
using UnityEngine;

namespace SimpleVideoPlayer
{
    /// <summary>
    /// 強制敵に更新するボタン
    /// </summary>
    public class ReloadButton : UdonSharpBehaviour
    {
        //更新をするプレイヤーの配列
        [SerializeField] private UdonSharpBehaviour[] videoPlayers;
        
        public override void Interact()
        {
            //全てのプレイヤーを回す
            var delay = 0;
            foreach (var videoPlayer in videoPlayers)
            {
                //カスタムイベントを流す
                videoPlayer.SendCustomEventDelayedSeconds("Reload", delay);
                //待ち時間を増やす
                delay += 6;
            }
        }
    }
}
