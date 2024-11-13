# DNFtranslate
Do Not Fall - Run for Your Drink
Translation Utility
v1.1

Quick version:  put all files in your game folder.  Run DNFtranslate.  Select "Patch text\jap" and "Patch game.exe", then select Process.  You have now translated the game and Test Menu to English.

----------

translated.txt
- contains the in-game translated text.  This file was translated with Google Translate.  Delete this if you want to create a new file based on the original Japanese text.
This text will modify the text\jap\global.lxb file.

game.exe.diff.txt
- contains the translated Test Menu text.  Modify it to the language of your choice.
Each line starts with the hex offset where the text will be placed and the maximum length the text can be (also in hex.)
0065A004:0B Online
Means starting at offset 0x000065A004, 11 bytes will be cleared and replaced with "Online"
Any translation can not be longer then 11 bytes.  The 12th byte from offset will be 0x00.
You can use a Hex Editor to look at the offsets in the original file to see the original Japanese text in Shift JIS.
Non-Japanese is limted to the lower 7-bit ASCII format.

Put DNFtranslate.exe, translated.txt (if you want to translate to English) and game.exe.diff.txt in your "Do Not Fall - Run for Your Drink" folder.

The game uses the text\jap\global.lxb file to store the Japanese text.  This will be modified to your translated language.

To Translate to English - Select "Use text\eng" (This has some base traslated text.)

Select "Patch text\jap" to backup and then modify the text\jap\global.lxb file based on the translated.txt file.
Select "Patch game.exe"  to backup and then modify the Test Menu in the game.exe file based on the game.exe.diff.txt file.

Press Process and wait for it to complete.  The game should now be translated.

For other languages, delete/rename the English translated.txt file.
For now turn off Create File.
Select use translated.txt, or if you want to translate to Chinese (Traditional) select Use text\cht.  This will translate some items.
Press Process and wait for it to complete.
Text to be translated will be displayed in the program window under "Missing Text to Translate."
Translate this with your favouite translator.  I used Google.  DeepL messed up the embeded icons and would use I instead of You.
Compare the Japanese text and translation line by line.  The translator may mess up a few lines and join some together.  There should be exactly as many lines in the translated file as the original.
Save the file as translated.txt in the game directory.
Select "Patch text\jap" and press Process.  Wait for it to complete.  The game should now be translated.

Rev History
1.1 Translate Test Menu in game.exe
1.0 Translate text in text\jap\global.lxb
