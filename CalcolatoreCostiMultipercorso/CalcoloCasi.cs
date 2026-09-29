using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CalcolatoreCostiMultipercorso;

public class CalcoloCasi {
    public static readonly List<Step> StepsMappa1;
    public static readonly List<Step> StepsMappa2;
    public static readonly List<Step> StepsMappa3;
    private static readonly int[,] Punti = {
        {100, 300, 500 },
        {200, 600, 1000 },
        {300, 900, 1500 } 
    };
    private static readonly Dictionary<string, string> Risorse;
    static CalcoloCasi() {
        StepsMappa1 = new ();
        StepsMappa2 = new ();
        StepsMappa3 = new();
        Risorse = new();
        CaricaRisorse();        
        CaricaModello();
        //SalvaModello();
    }
    [Obsolete("usato per verifica", true)]
    private static void SalvaModello() {
        List<string> righe = new();
        foreach(var step in StepsMappa1)
            righe.Add(step.ToString());
        foreach (var step in StepsMappa2)
            righe.Add(step.ToString());
        foreach (var step in StepsMappa3)
            righe.Add(step.ToString());
        File.WriteAllLines("modelloi3.txt", righe);
        Debug.WriteLine("creato modelloi3.txt");
    }

    static void CaricaRisorse() {
        string percorsoTxt = "risorse.txt";
        if (!File.Exists(percorsoTxt))
            throw new FileLoadException("File risorse.txt non trovato!");
        string[] righe=File.ReadAllLines(percorsoTxt);
        foreach (var riga in righe) {
            string[] parti=riga.Split('|');
            Risorse.Add(parti[0], parti[1]);
        }
    }
    static void CaricaModello() {
        string percorsoJson = "steps.json";
        if (!File.Exists(percorsoJson))
            throw new FileLoadException("File steps.json non trovato!");
        string testo = File.ReadAllText(percorsoJson);
        using (JsonDocument jd = JsonDocument.Parse(testo)) {
            var root = jd.RootElement;
            foreach (var mappa in root.EnumerateObject()) {
                int id = int.Parse(mappa.Name) - 1;// "1"|"2"|"3" -> 0|1|2
                foreach (var perc in mappa.Value.EnumerateObject()) {
                    switch (perc.Name) {
                        case "all":
                            foreach (var stepJson in perc.Value.EnumerateObject()) {
                                int idP = int.Parse(stepJson.Name) - 1;// solo "1" -> 0
                                List< int> valori = new ();
                                List<string> risorse = new();
                                foreach (var risorsaObj in stepJson.Value.EnumerateArray()) {                                  
                                    foreach (var risorsa in risorsaObj.EnumerateObject()) {
                                        if (Risorse.ContainsKey(risorsa.Name)) {
                                            risorse.Add(Risorse[risorsa.Name]);
                                        }
                                        else {//Nome nuovo
                                            risorse.Add(risorsa.Name);
                                        }
                                        valori.Add(int.Parse(risorsa.Value.ToString()));
                                    }
                                }
                                Step step = new(idP, Punti[id, 0], valori[0], risorse[0], valori[1], risorse[1]);
                                switch (id) {
                                    case 0:
                                        StepsMappa1.Add(step);
                                        break;
                                    case 1:
                                        StepsMappa2.Add(step);
                                        break;
                                    case 2:
                                        StepsMappa3.Add(step);
                                        break;
                                    default:
                                        throw new FormatException($"Id mappa imprevisto: {(id + 1)}!");
                                }
                            }
                            break;
                        case "orange":
                        case "blue":
                        case "green":
                            foreach (var stepJson in perc.Value.EnumerateObject()) {
                                int idP = int.Parse(stepJson.Name) - 1;// da "2" a "9" -> 1 a 8
                                List<int> valori = new();
                                List<string> risorse = new();
                                foreach (var risorsaObj in stepJson.Value.EnumerateArray()) {
                                    foreach (var risorsa in risorsaObj.EnumerateObject()) {
                                        if (Risorse.ContainsKey(risorsa.Name)) {
                                            risorse.Add(Risorse[risorsa.Name]);
                                        }
                                        else {//Nome nuovo
                                            risorse.Add(risorsa.Name);
                                        }
                                        valori.Add(int.Parse(risorsa.Value.ToString()));
                                    }
                                }
                                int punti =idP switch{
                                    2 => Punti[id,1],
                                    5 => Punti[id,2],
                                    _ => Punti[id,0]
                                };
                                Step step = new(idP, punti, valori[0], risorse[0], valori[1], risorse[1], 
                                    valori[2], risorse[2]);
                                switch (id) {
                                    case 0:
                                        StepsMappa1.Add(step);
                                        break;
                                    case 1:
                                        StepsMappa2.Add(step);
                                        break;
                                    case 2:
                                        StepsMappa3.Add(step);
                                        break;
                                    default:
                                        throw new FormatException($"Id mappa imprevisto: {(id + 1)}!");
                                }
                            }
                            break;
                        default:
                            throw new FormatException($"Percorso imprevisto alla Mappa {(id+1)}!");
                    }
                }
            }
        }
    }

    public static List<Perc> CasiFiltrati(Perc casoAttuale) {
        List<Perc> casi = MetodoAbbreviato();
        List<Perc> casiFiltrati = casi.Where(c => (c.integer & casoAttuale.integer) == casoAttuale.integer).ToList();
        return casiFiltrati;
    }


    public static List<Perc> MetodoAbbreviato() {
        //step 1
        List<Perc> database = new List<Perc>();
        database.Add(new Perc());
        List<Perc> casi = new List<Perc>();
        for (int v = 0; v < 2; v++) {
            for (int b = 0; b < 2; b++) {
                for (int a = 0; a < 2; a++) {
                    bool ve = v == 1;
                    bool bl = b == 1;
                    bool ar = a == 1;
                    // filtro base
                    if (!ar && !bl && !ve)
                        continue;
                    // aggiungi
                    foreach (Perc db in database) {
                        Perc tmp = db.Clona();
                        tmp.Add(ar, bl, ve);
                        casi.Add(tmp);
                    }
                }
            }
        }

        //step 2
        database = casi;
        casi = new List<Perc>();
        for (int v = 0; v < 2; v++) {
            for (int b = 0; b < 2; b++) {
                for (int a = 0; a < 2; a++) {
                    bool ve = v == 1;
                    bool bl = b == 1;
                    bool ar = a == 1;
                    // filtro base
                    if (!ar && !bl && !ve)
                        continue;
                    // aggiungi
                    foreach (Perc db in database) {
                        Perc tmp = db.Clona();
                        // filtri
                        if (ar && !tmp.arancio.Last() && !bl)
                            continue;
                        if (bl && !tmp.blu.Last() && !ar && !ve)
                            continue;
                        if (ve && !tmp.verde.Last() && !bl)
                            continue;
                        tmp.Add(ar, bl, ve);
                        casi.Add(tmp);
                    }
                }
            }
        }
        //step 3
        database = casi;
        casi = new List<Perc>();
        for (int v = 0; v < 2; v++) {
            for (int b = 0; b < 2; b++) {
                for (int a = 0; a < 2; a++) {
                    bool ve = v == 1;
                    bool bl = b == 1;
                    bool ar = a == 1;
                    // filtro base
                    if (!ar && !bl && !ve)
                        continue;
                    // aggiungi
                    foreach (Perc db in database) {
                        Perc tmp = db.Clona();
                        // filtri
                        if (ar && !tmp.arancio.Last())
                            continue;
                        if (bl && !tmp.blu.Last())
                            continue;
                        if (ve && !tmp.verde.Last())
                            continue;
                        tmp.Add(ar, bl, ve);
                        casi.Add(tmp);
                    }
                }
            }
        }
        //step 4
        database = casi;
        casi = new List<Perc>();
        for (int v = 0; v < 2; v++) {
            for (int b = 0; b < 2; b++) {
                for (int a = 0; a < 2; a++) {
                    bool ve = v == 1;
                    bool bl = b == 1;
                    bool ar = a == 1;
                    // filtro base
                    if (!ar && !bl && !ve)
                        continue;
                    // aggiungi
                    foreach (Perc db in database) {
                        Perc tmp = db.Clona();
                        // filtri
                        if (ar && !tmp.arancio.Last())
                            continue;
                        if (bl && !tmp.blu.Last())
                            continue;
                        if (ve && !tmp.verde.Last())
                            continue;
                        tmp.Add(ar, bl, ve);
                        casi.Add(tmp);
                    }
                }
            }
        }
        //step 5
        database = casi;
        casi = new List<Perc>();
        for (int v = 0; v < 2; v++) {
            for (int b = 0; b < 2; b++) {
                for (int a = 0; a < 2; a++) {
                    bool ve = v == 1;
                    bool bl = b == 1;
                    bool ar = a == 1;
                    // filtro base
                    if (!ar && !bl && !ve)
                        continue;
                    // aggiungi
                    foreach (Perc db in database) {
                        Perc tmp = db.Clona();
                        // filtri
                        if (ar && !tmp.arancio.Last() && !bl)
                            continue;
                        if (bl && !tmp.blu.Last() && !ar && !ve)
                            continue;
                        if (ve && !tmp.verde.Last() && !bl)
                            continue;
                        tmp.Add(ar, bl, ve);
                        casi.Add(tmp);
                    }
                }
            }
        }
        //step 6
        database = casi;
        casi = new List<Perc>();
        for (int v = 0; v < 2; v++) {
            for (int b = 0; b < 2; b++) {
                for (int a = 0; a < 2; a++) {
                    bool ve = v == 1;
                    bool bl = b == 1;
                    bool ar = a == 1;
                    // filtro base
                    if (!ar && !bl && !ve)
                        continue;
                    // aggiungi
                    foreach (Perc db in database) {
                        Perc tmp = db.Clona();
                        // filtri
                        if (ar && !tmp.arancio.Last())
                            continue;
                        if (bl && !tmp.blu.Last())
                            continue;
                        if (ve && !tmp.verde.Last())
                            continue;
                        tmp.Add(ar, bl, ve);
                        casi.Add(tmp);
                    }
                }
            }
        }
        //step 7
        database = casi; // 3291
        casi = new List<Perc>();
        for (int v = 0; v < 2; v++) {
            for (int b = 0; b < 2; b++) {
                for (int a = 0; a < 2; a++) {
                    bool ve = v == 1;
                    bool bl = b == 1;
                    bool ar = a == 1;
                    // filtro base
                    if (!ar && !bl && !ve)
                        continue;
                    // aggiungi
                    foreach (Perc db in database) {
                        Perc tmp = db.Clona();
                        // filtri
                        if (ar && !tmp.arancio.Last())
                            continue;
                        if (bl && !tmp.blu.Last())
                            continue;
                        if (ve && !tmp.verde.Last())
                            continue;
                        tmp.Add(ar, bl, ve);
                        casi.Add(tmp);
                    }
                }
            }
        }
        //step 8
        database = casi;//6937
        casi = new List<Perc>();//
        for (int v = 0; v < 2; v++) {
            for (int b = 0; b < 2; b++) {
                for (int a = 0; a < 2; a++) {
                    bool ve = v == 1;
                    bool bl = b == 1;
                    bool ar = a == 1;
                    // filtro base
                    if (!ar && !bl && !ve)
                        continue;
                    // aggiungi
                    foreach (Perc db in database) {
                        Perc tmp = db.Clona();
                        // filtri
                        if (ar && !tmp.arancio.Last())
                            continue;
                        if (bl && !tmp.blu.Last())
                            continue;
                        if (ve && !tmp.verde.Last())
                            continue;
                        tmp.Add(ar, bl, ve);
                        casi.Add(tmp);
                    }
                }
            }
        }/**/
        Debug.WriteLine("casi totali " + casi.Count);
        return casi;
    }

    [Obsolete("ha troppi problemi di verifica", true)]
    public static void MetodoLungo() {
        throw new NotImplementedException();
        //List<Percorso> percorsi = new List<Percorso>();
        List<string> casi;
        // cicla tutti
        for (byte a = 0; a <= byte.MaxValue; a++) {
            casi = new List<string>();
            for (byte b = 0; b <= byte.MaxValue; b++) {
                for (byte v = 0; v <= byte.MaxValue; v++) {
                    Percorso p = new Percorso(a, b, v);
                    if (p.isValido())
                        casi.Add(p.ToString());
                    //percorsi.Add(p);
                    //label2.Text=v.ToString();
                }
                //label1.Text=a.ToString() + " " + b.ToString();
            }
            String testo = String.Join("\r\n", casi);
            File.WriteAllText($"casi_{a.ToString()}.txt", testo);
        }
        //MessageBox.Show("tot: " + percorsi.Count);
        //var pp = from p in percorsi select p.ToString();
        //String testo = String.Join("\r\n", pp.ToArray<string>());
        //File.WriteAllText("casi.txt", testo);
        //MessageBox.Show("salvati! " + percorsi.Count);
    }

}

