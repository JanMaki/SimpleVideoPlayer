using UdonSharp;
using UnityEngine;
using VRC.SDK3.Video.Components;
using VRC.SDKBase;

namespace SimpleVideoPlayer
{
    /// <summary>
    /// 1時間置きに再生動画を再読み込みするだけの動画プレイヤー
    /// </summary>
    public class SimpleVideoPlayer : UdonSharpBehaviour
    {
        //URL
        [SerializeField] private VRCUrl url;

        //初回読み込み時に待つ時間
        [SerializeField] private int initTimeLate = 10;

        //頻度の確認用
        private float rateCounter;

        //VRCUnityVideoPlayer
        private VRCUnityVideoPlayer videoPlayer;

        //更新頻度
        private int updateSpan;

        private void Start()
        {
            //コンポーネントを取得
            videoPlayer = (VRCUnityVideoPlayer)GetComponent(typeof(VRCUnityVideoPlayer));

            //更新頻度を変更
            updateSpan = initTimeLate;
        }

        private void Update()
        {
            //レートを追加
            rateCounter += Time.deltaTime;
            //レートを確認
            if (rateCounter <= updateSpan) return;

            //リロード
            Reload();
            
            //更新時間を1時間に変更
            updateSpan = 3600;
            //レートをリセット
            rateCounter = 0;
        }

        /// <summary>
        /// 動画の再読み込みを行う
        /// </summary>
        public void Reload()
        {
            //リロード
            videoPlayer.Stop();
            videoPlayer.PlayURL(url);
        }
    }
}