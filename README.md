# Fjodorovs_UnityUI
Unity UI projekts ar varoņa izvēli, spēlētāja datu ievadi, skaņas vadību un ainu pārslēgšanu.

## Kas izdarīts
- Izveidota varoņu pārslēgšana ar dropdown (UIScript).
- Ieviesta spēlētāja vārda un dzimšanas gada ievade ar validāciju (CharacterInfoUI).
- Pievienota datu nodošana starp ainām (PlayerData).
- Realizēta ainas ielāde ar aizturi un drošu pāreju tikai pēc korektas ievades (SceneChangerScript).
- Ieviesta skaņas efektu atskaņošana, fona skaņas skaļuma regulēšana un mute režīms (`FXScript).

## Kas pievienots
- PlayerData (playerName, playerAge) datu glabāšanai.
- Kļūdas paziņojums nekorektam dzimšanas gadam un Start pogas bloķēšana, kamēr dati nav derīgi.
- Fona skaļuma slīdnis ar diapazonu 1–100 un teksta indikators “Volume”.
- Mute vizuālais stāvoklis (teksta pārsvītrojums un krāsa).

## Kā tas darbojas
- Lietotājs ievada vārdu un dzimšanas gadu; vecums tiek aprēķināts no pašreizējā gada.
- Ja vecums nav diapazonā 1–100 vai ievade nav skaitlis, Start poga paliek neaktīva.
- Nospiežot sākšanu, dati tiek saglabāti "PlayerData", pēc tam aina ielādējas ar 1.5 s aizturi.
- Nākamajā ainā tiek parādīts saglabātais vārds un vecums.
- UI dropdown ļauj ieslēgt tikai izvēlēto varoņa objektu.
- Skaņas sadaļā var atskaņot SFX, mainīt fona skaļumu un pārslēgt mute.