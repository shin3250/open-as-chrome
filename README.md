# open-as-chrome

Google Chromeは通常、引数にインターネットショートカット（.url）を指定してもそのファイルを開くだけでその中に書いてあるURLを開いてはくれません。  
このプログラムを使うと、引数に指定したインターネットショートカットをGoogle Chromeで開いてくれます。

「デフォルトブラウザはInternetExplorer/Edge/FireFoxなどを使いたいがたまにGoogle Chromeで開きたい時がある」という場合に、インターネットショートカットの右クリックメニューに「Chromeで開く」を追加する場合などを想定しています。

## 使い方
open-as-chrome.exe <インターネットショートカット> [<Chromeオプション>] ...

Google Chromeのオプション（--new-windowなど）を付けたい場合は第2引数以降に指定してください。
