# ドメイン駆動

- ドメイン駆動学習用

## 1.プロジェクト構成

- プロジェクトを分ける理由は、可読性を高める、保守性高める
- 新しいテクノロジーが出てきたとき、プロジェクトを変更するの載せ替えられる

  ### 1.1.Domain

  - ビジネスロジック
  - どこも参照しない。見られるだけ
  - C#プレーンなコードを書く

  ### 1.2.Infrastructure

  - アプリケーションの外側と接触するもの
  - Domain を参照する
  - SQL、ファイルアクセス、通信 外部のテクノロジーが変化したらここだけ変更する
  - 外部の事情で変わるので、変更が生じた場合はここだけを変更する
  - ユニットテストを書きやすくする
  - Application は必要か？冗長化になる、ビジネスロジック、ViewModel どちらか迷う
  - Application 層は WinForm と Infrastructure 層の間くらい
  - App 層をいれると処理が冗長化しやすい

  ### 1.3.WinForm

  - 画面
  - Domain と Infrastructure を参照
  - 時代とともに見た目は変化する ここだけ変更する
  - プロジェクトを分ける理由は新しいテクノロジがでてきたときに変更しやすい

  ### 1.4.NDDDTest.Tests

  - ユニットテスト
  - 全て参照

## 2.Domain のフォルダー構成

- Domain のフォルダー構成について

  ### 2.1.Entities

  - モデル＋ビジネスロジック
  - 一意なデータの塊、データベース１行、行の中で完結するロジックの置き場所
  - データモデルのイメージ

  ### 2.2.ValueObjects

  - データ＋ビジネスロジック
  - 値として扱うクラス
  - 数字の「3」等をそのまま扱うとビジネスロジックが散らばるため ValueObject の「3」として扱う
  - データベースの列の ValueObject 化が有効

  ### 2.3.Repositories

  - インターフェース＋（ビジネスロジック）
  - アプリケーションの外部と接触する部分は全てインターフェイスを作る
  - テストの容易性

  ### 2.4.Exceptions

  - エラー処理は基本は例外処理を行う
  - Exception を継承した例外クラスの集まり
  - 基本的に異常は例外で表す
  - 戻り値を bool にして判断しない
  - 呼び元に if を書かせない
  - 値が戻ったら正常、エラー時は catch で
  - ただしループで全て例外が発生するような箇所は考慮する

  ### 2.5.Helpers

  - 共通関数的なもの
  - static でどこにあってもいいもの
  - 害がないもの。桁を揃えるとか
  - マイクロソフトが作ってくれたら不要だったよ！的なもの
  - ビジネスロジックが無い[Logics との比較]

  ### 2.6.StaticValues

  - 共通変数的なもの
  - 値をキャッシュとして保存する場合

  ### 2.7.Logics

  - Static でビジネスロジックを含むもの
  - 分析、診断ロジックなど

## 3.Infrastructure のフォルダー構成

- 外部機器と接触するもの
- クラスは internal で作成し Factory だけ public にする
- インスタンスの生成は Factory 以外ではできなくする

  ### 3.1.なぜ外部との接触を集めるのか？

  - 外部の影響を局所化する
  - テスト容易性

  ### 3.2.フォルダー構成

  - テクノロジーごとにフォルダーを分ける
  - 外部にアクセス部分のロジックのみを記述
  - Domain 層の Repository にあるインターフェースを使う
  - SQLServer
  - Csv
  - 外部機器
  - Fake ダミーデータ
  - Factory パターン 本番コードと Fake パターンを切り替える

## 4.WinForm のフォルダー構成

- WinForm のフォルダー構成

  ### 4.1.ユーザーインターフェース層

  - 時代の変化とともに変化する部分

  ### 4.2.ビジネスロジックとの分離

  - MVVM パターンの適応
  - ドメイン層やインフラストラクチャー層の機能を選ぶ

  ### 4.3.フォルダー構成

  - ViewModels
  - Views
  - BackgroundWorkers

  ### 4.4.タイマーイベントはどこに入れる？

  - イベントはユーザーインターフェイス層でのみ発生させる
  - 理由：保守性を上げるため。修正時に追いやすいコード
  - 勝手に動いているものがあると大変

## 5.Tests のフォルダー構成

- テストコードのみを書く
- メソッド名は日本語で OK

  ### 5.1.フォルダー構成

  - 本番コードの構成
  - Domain.ValueObjects.MeasureValue クラスなら
    Domain.ValueObjects.MeasureValueTests のテストクラスを作る

  ### 5.2.ViewModel へのテスト

  - 基本的に ViewModel に対してテストを書けば OK

  ### 5.3.Infrastructure のテスト

  - 不要
  - Moq にて代用

  ### 5.4.画面のテスト

  - 不要
  - ViewModel に対してテストを書けば OK
  - 実際の画面は目で見てテストする

  ### 5.5.お勧めの支援ツール

  - ChainingAssertion
  - Moq
  - AxCover

## 6.Shared クラスを作成する

- Static な変数を一元化する
- Domain 直下に Shared クラスを作成し状態を保存する
- Fake 切り替えや状態を保存する

## 7.Factories クラスを作成する

- インスタンスを生成する箇所を一元化
- Fake か SQL か切り替えがわかりやすくなる
- Debug ビルドと Relese ビルドでインスタンス生成の処理を切り替える
- Factory 以外でインスタンス生成できなくする クラスを internal にする
- Factory の呼び出しは ViewModel で行う
- 画面から呼び出したときは本番を呼び出しテストから呼び出したときは Mock が呼ばれるなど

## 8.設定の外部ファイル化

- 参照から System.Configuration を追加
- App.config の変更
- NDDD.config の追加

## 9.BaseForm を作る

- Form 共通の基底 Form
- 例外処理時のメッセージボックスも書ける
- ステータスバーとか

## 10.ValueObject について

- ValueObject は、値＋ロジック
- 何を ValueObject にするか？DB のフィールド
- モデルだと値型(int など)なので振る舞いが実装できない
- 振る舞いを実装すると、ロジックが View にあったり ViewModel にあったり散らばる
- 値にビジネスロジックがあれば ValueObject 化（クラス化）する
- 注意点
- 完全コンストラクタ型で作成する（すべての引数）
- New した時に値をセットして、以降は変更できない（get のみ実装する）
- 問題点
- ValueObject はクラスなので、値が同じでもイコールにはならない（参照型なので）
- 抽象クラスを用意して、イコールイコール問題を対処する

## 11.オブジェクト指向の自動化

- オブジェクト指向の実装をしたい
- 課題：
- 一人ひとりの認識が違い、ばらばらになる
- デザパタにしろ、アーキテクチャーにしろ、あいまい
- そこで DDD を実践する
- モデルを基準に考えて組み立てていくと７、８割オブジェクト指向になる

  ### 11.1.外部からのデータ（DB の列）をすべて ValueObject にする

  - ビジネスロジックが無ければ不要かもしれない

  ### 11.2.DB の値を運ぶ形で Entity にする（モデル）

  - Select 分相当の Entity に ValueObject に乗せる
  - ValueObject の組み合わせ
  - 複合的 ValueObject なビジネスロジックは Entity にて書く

  ### 11.3.外部接触部はリポジトリーにする

  - リポジトリー経由で値をとってくる
  - ここまでで、8 割のクラス分けができる

  ### 11.4.テストを実装する

  - テストメソッドを実装する
  - テストをするには、インターフェースで繋ぐ必要があるので、自然とオブジェクト指向的に作られる
  - わざとエラーを出す（レッド）
  - エラーが通るようにメソッドを実装する（グリーン）

## 12.Repository の具象クラス

- Infrastructure 層はシンプルに値だけをとる（SQL でごちゃごちゃ書かない）
- ごちゃごちゃ処理は C#で書いたほうが良い
- DB から取ってきた値にビジネスロジックを書く場合、ViewModel に書くとロジックが散らばる
- SQL で取ってきて加工して渡すだけなら、Repository の具族クラスに書くことも検討
- ただし複雑なロジックは置かない

## 13.例外処理

- バケツリレーはしない。C#は例外でエラーを検知
- バケツリレーは if 分が必要で、漏れたりバグが混入しやすい
- 正常な値が返ってきたら正常、エラーだったら例外
- 呼び出しもとで try、catch する

## 14.インナーエクセプション

- throw だけでは、例外が発生した Exception が呼び出しもとに渡せない
- メッセージと Exception を呼び出しもとに渡すことが必要
- 例外クラスに引数を追加

## 15.例外の欠点

- 処理コストがかかる
- ループ処理の中で 100 回のループで、100 回の例外が発生する可能性があるような場合は、例外はさせない

## 16.メッセージ区分とエラー処理の共通化

- カスタム Exception を作った場合、エラー区分を設定することにより警告メッセージの共通化が図れる
- 抽象基底クラスを作り、エラー区分を作成する
- 基底クラスに抽象メソッドを作ることにより、エラー区分の実装を強制化ができる

## 17.ログの出力

- 一般的に log4net

## 18.タイマー処理はどこに置くか？

- Event 関係は UI 層に集めておいたほうが追いやすい
- タイマーはきっかけとなる UI 層に置いたほうが良い

## 19.StaticValues(キャッシュ)

- DB から取ってきた値などを保存しておく変数
- あっちこっちに置くと見通しが悪いので一か所にまとめておく
- 変数は Shared に置いて、リストは StaticValues に置いて Lock をかけてどこからでもアクセスできるように

## 20.Logics

- 独立したロジックは Logic に置く（分析とか）
- Static な関数
- ビジネスロジックは基本的には ValueObject もしくは Entity に置く

## 21.Helpers

- 共通関数的な関数を置く

## 22.Module

- どこにも収まらないロジックを入れる

## 23.トランザクションはどこで掛けるか

- ViewModel で掛けるのが融通がきく
- Infrastructure でトランザクションを掛けると、融通が利かない
- System.Transactions を使用し using で囲む


## 24.特徴を見極める
- 値
  - static アプリに1つ
    - StaticValues DBの値やリスト
    - Shared システム情報やユーザー情報
  - Entity or ValueObject 処理の度に生成
    - Entity 一意なもの DBの行
    - ValueObject DBの列 フィールド

- ロジック
  - Helpers 共通関数的なもの
  - Logics ビジネスロジック
  - Entity or ValueObject データと一体型


  
  