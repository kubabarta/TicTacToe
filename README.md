# TicTacToe
Funguje to na princpipu stisknutí tlačítka uživatele. když uživatel stiskne tlačítko sám se spustí počítač
##  Button_Click
Vyhodnocuje kliknutí uživatele a spustí automaticky počítač
##  Timer_Tick (_Zkopírováno od AI_)
nastavuje delay počítače aby to vypadalo přirozeněji
##  Move
Umístí X\O záleží na boolu PlayerTurn
##  Computer
Založí list do kterého se uloží prázdné místa v boardě, projde se přes foreach, poté přes Random umístí do pole
_Bohužel se mi nepodařilo nijak zajistit aby počítač měl v sobě umělou inteligenci, zkoušel jsem to několika způsoby a nevyšlo mi to_
##  Reset
Zakládá novou boardu, aby se hra dala hrát do nekonečna
##  CheckWin
Projde všechny kombinace, aby vyhodnotil zda je hra dohraná nebo ne
## CheckDraw
Když je vše zaplněno, je remíza
