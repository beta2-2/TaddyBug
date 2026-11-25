# Taddy Bug

タップでキャラクターを浮かせ、上下のブロックの隙間をくぐる Unity の 2D ゲームです。ブロックを一組通過すると1点。ブロックや地面にぶつかるとゲームオーバーです。

## 遊び方

Unity 6000.0.43f1 でプロジェクトを開き、[SampleScene](Assets/Scenes/SampleScene.unity) を再生します。ゲーム画面を左クリックしてスタート。クリックするたびに上昇し、何もしないと落下します。ゲームオーバー後は、もう一度クリックすると最初に戻ります。

## ブロックの配置と調整

シーンの `Blocks` の下に、4組のブロックを X 座標 6、10、14、18 に配置しています。プレイ中は左に流れ、画面の外に出たブロックを右側で再利用します。

| Inspector の項目 | 現在の値 | ゲーム内での働き |
| --- | --- | --- |
| Block → Min Height / Max Height | 0 / 5 | 最初の配置時と右に戻るとき、この範囲から Pivot の高さを選びます。上下のブロックは一緒に動くので、隙間の幅は一定です。 |
| Scroll Object → Speed | 3 | ブロックが左へ進む速さです。 |
| Scroll Object → End Position / Start Position | −9 / 9 | 左端を越えたブロックを右側に戻すための座標です。 |
| Taddy Bug Controller → Flap Velocity | 7 | クリック時のキャラクターの上向きの速度です。 |

高さの変化を見比べるには、再生前に `Blocks > Block (1)` を選び、Min Height と Max Height を両方 2 にします。再生すると、その一組だけが毎回同じ高さに現れます。元の設定は 0 と 5 です。

最初の一組は [Block プレハブ](Assets/Prefabs/Block.prefab) のインスタンスです。残りの三組はシーンに直接配置してあるので、全体の難しさを変えるときはそちらの値も調整します。キャラクターの上昇速度は [TaddyBug プレハブ](Assets/Prefabs/TaddyBug.prefab) に設定しています。
