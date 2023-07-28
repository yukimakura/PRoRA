# PRoRA
PaRameter provider Over Rest API   
環境変数をRestAPI経由で配布するためのアプリです   
dockerと組み合わせて使うことを想定しています   

## 使い方
### すべての環境変数を配布する場合(セキュリティ的にはおすすめしません)
``` bash
./PRoRA
```
これで、`http://localhost:5000/api/GetEnvVar`にGETすると環境変数一覧が取得できます
### 特定の環境変数のみを配布する場合
引数に正規表現を与えてください。   
(例) `Setting_`という文字列から始まる環境変数のみを抽出する場合
``` bash
./PRoRA -r "Setting_.*"
```
これで、`http://localhost:5000/api/GetEnvVar`にGETすると   
`Setting_`から始まる環境変数一覧が取得できます

## ポートの変更
[`appsetings.json`のkestrelを変更してください(MSのサイトに飛びます)](https://learn.microsoft.com/ja-jp/aspnet/core/fundamentals/servers/kestrel/endpoints?view=aspnetcore-7.0#configureiconfiguration)
