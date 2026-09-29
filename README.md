# CalcolatoreCostiMultipercorso

Applicazione desktop per la simulazione combinatoria, l'analisi dei costi di risorse e il supporto decisionale in strutture a rete e grafi orientati con percorsi paralleli.

## 📌 Descrizione e Finalità
In contesti di coordinamento e allocazione di risorse limitate, il sistema permette di valutare la convenienza tra il completamento di specifici nodi all'interno di una mappa a percorsi multipli coordinati e l'allocazione alternativa delle risorse in cicli a rendimento continuo (es. "Pozzi/Endgame Sink").

L'applicazione genera un report analitico in formato **CSV** che evidenzia il rapporto costo/beneficio (ROI) per ciascuna combinazione di nodi e percorsi selezionati.

## ⚙️ Modello Logico e Struttura Dati
- **Modello a Grafi Orientati Ponderati:**
  - **Nodi (Waypoint):** Ogni nodo possiede un vettore di costo (combinazione pesata di risorse/distintivi) e un valore di resa (punteggio accumulato per la classifica generale).
  - **Rami Paralleli e Intersezioni:** Gestione simultanea dei percorsi alternativi e dei relativi punti di convergenza obbligatori.
- **Pruning Dinamico dello Spazio degli Stati:** Inserendo lo stato di avanzamento attuale tramite interfaccia grafica, il sistema filtra e ricalcola unicamente le combinazioni residue reali, riducendo drasticamente il carico computazionale.
- **Analisi Comparativa (Nodi vs. Pozzi):** Strumento di ausilio tattico per determinare la soglia di convenienza economica nell'allocazione delle produzioni di gruppo.

## 📊 Output
- Generazione automatica di file **CSV** strutturati per l'analisi immediata dei costi e della programmazione strategica.

## 🛠️ Tech Stack
* **Linguaggio:** C# (.NET Framework)
* **Interfaccia Grafica:** Windows Forms
* **Data Output:** CSV (Comma-Separated Values)
