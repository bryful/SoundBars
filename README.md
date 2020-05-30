?# SoundBars

After Effectsでレベルメータを作る時は、Trapcode Sound keyを使うと楽なのですが、持ってないので、代わりにでっち上げたアプリです。  
  
![SOundBars](https://user-images.githubusercontent.com/50650451/83331969-b4013a80-a2d3-11ea-97cc-027732441271.png)  

オーディオスペクトラムで適当なレベルメータを描画してその画像から音のデータをjsonに変換します。

出力したjsonはスクリプト(soundBars.jsx)でキーフレームに変換します。  
![SOundBars2](https://user-images.githubusercontent.com/50650451/83331982-bc597580-a2d3-11ea-8ce9-5e6a0885d36c.png)  

# 使い方
　AepSampleフォルダの中にあるSaundBars_CS6.aepを見てください。  
横方向が強さ、縦の1ピクセル毎がレベルのチャンネルです。  
  
![soundBars_0091](https://user-images.githubusercontent.com/50650451/83330899-3e926b80-a2cd-11ea-80aa-366c18807527.png)  

上の絵のようなものをオーディオスペクトラムで作成します。  
チャンネルを増やすにはいろいろパラメータを変更してください。
  
書き出し画像は8bitx3のpngでお願いします。  
  
ファイルをアプリに読み込ませると解析します。  
  
exportでjsonに書き出しです。  
  
json2.jsxinc  
bryScriptLib.jsxinc  
soundBars.jsx  
の三つをScriptUI Panelsフォルダにコピーしてください。  

3000F位の変換は結構時間がかかります。
スクリプトで変換したら、エクスプレッションで使います。  


サンプルで入れてある楽曲は音楽：魔王魂さんのHPから落としたものです。

https://maoudamashii.jokersounds.com/list/song2.html  


# License

This software is released under the MIT License, see LICENSE. 

# Authors

bry-ful(Hiroshi Furuhashi)   
twitter:[bryful](https://twitter.com/bryful)  
bryful@gmail.com  

# References

  


