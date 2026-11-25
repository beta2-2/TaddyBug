# Taddy Bug

タップでキャラクターを浮かせ、上下のブロックの隙間をくぐる Unity の 2D ミニゲームです。ブロックを一組通り抜けると1点。ブロックや地面にぶつかるとゲームオーバーです。キャラクターと背景の画像は自作です。

## 遊び方

Unity 6000.0.43f1 でプロジェクトを開き、[SampleScene](Assets/Scenes/SampleScene.unity) を再生します。Game ビューを左クリックするとスタートし、クリックするたびにキャラクターが上昇します。ゲームオーバー後は、もう一度クリックすると最初に戻ります。

## Unity エディターでの調整

シーンの `Blocks` には、4組のブロックを X 座標 6、10、14、18 に配置しています。ブロックは左へ進み、画面外に出ると右側に戻ります。最初の一組は [Block プレハブ](Assets/Prefabs/Block.prefab) のインスタンスで、残りの三組はシーン上で個別に設定しています。

| Inspector の項目 | 初期値 | 変更すると |
| --- | --- | --- |
| `Block` の `Min Height` / `Max Height` | 0 / 5 | 隙間が出る高さの範囲が変わります。隙間の幅は一定です。 |
| `Scroll Object` の `Speed` | 3 | ブロックが左へ進む速さが変わります。 |
| [TaddyBug プレハブ](Assets/Prefabs/TaddyBug.prefab)の `Flap Velocity` | 7 | クリック直後の上向きの速度が変わります。 |

再生前に `Blocks > Block (1)` の `Min Height` と `Max Height` を両方 2 にすると、その一組は右側に戻るたびに同じ高さに現れます。
