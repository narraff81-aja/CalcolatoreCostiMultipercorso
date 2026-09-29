using System.Diagnostics;
using System.Text;

namespace CalcolatoreCostiMultipercorso;

public partial class Form1 : Form {
    private List<StepMappa> steps_arancio;
    private List<StepMappa> steps_blu;
    private List<StepMappa> steps_verde;
    private CalcoloCasi calcoloCasi;
    public Form1() {
        InitializeComponent();
        steps_arancio = new() {
                this.stepAr1,
                this.stepAr2,
                this.stepAr3,
                this.stepAr4,
                this.stepAr5,
                this.stepAr6,
                this.stepAr7,
                this.stepAr8
            };
        steps_blu = new() {
                this.stepBlu1,
                this.stepBlu2,
                this.stepBlu3,
                this.stepBlu4,
                this.stepBlu5,
                this.stepBlu6,
                this.stepBlu7,
                this.stepBlu8
            };
        steps_verde = new() {
                this.stepVer1,
                this.stepVer2,
                this.stepVer3,
                this.stepVer4,
                this.stepVer5,
                this.stepVer6,
                this.stepVer7,
                this.stepVer8
            };
        calcoloCasi = new CalcoloCasi();
        cboMappa.SelectedIndex = 2;
    }

    private void btnCreaCSV_Click(object sender, EventArgs e) {
        //metodoLungo();
        List<bool> bArancio = new() {
                this.stepAr1.isChecked,
                this.stepAr2.isChecked,
                this.stepAr3.isChecked,
                this.stepAr4.isChecked,
                this.stepAr5.isChecked,
                this.stepAr6.isChecked,
                this.stepAr7.isChecked,
                this.stepAr8.isChecked
            };
        List<bool> bBlu = new() {
                this.stepBlu1.isChecked,
                this.stepBlu2.isChecked,
                this.stepBlu3.isChecked,
                this.stepBlu4.isChecked,
                this.stepBlu5.isChecked,
                this.stepBlu6.isChecked,
                this.stepBlu7.isChecked,
                this.stepBlu8.isChecked
            };
        List<bool> bVerde = new() {
                this.stepVer1.isChecked,
                this.stepVer2.isChecked,
                this.stepVer3.isChecked,
                this.stepVer4.isChecked,
                this.stepVer5.isChecked,
                this.stepVer6.isChecked,
                this.stepVer7.isChecked,
                this.stepVer8.isChecked
            };
        Perc attuale = new Perc(bArancio, bBlu, bVerde);
        List<Perc> casiFiltrati = CalcoloCasi.CasiFiltrati(attuale);
        Debug.WriteLine(casiFiltrati.Count);
        // per ogni caso conta le risorse mancanti
        /*List<String> listaRisorseMA_H = new() { 
          "birreria","carpentiere","contadino","fabbro",
            "bracciale","collana","statue","cappello",
            "druido","meraviglie","guardia","monete",
            "residuo","marmo","tiara","fantasma"};*/
        List<String> listaRisorse = new() {
                "birrerie","carpentieri","contadini","fabbri",
                "bracciali","collane","statue","cappelli",
                "druidi","meraviglie","guardie","monete",
                "residui","pozione","tiare","fantasmi"};
        List<String> RigheCSV = new List<string>();
        //RigheCSV.Add("#;Ar1;Ar2;Ar3;Ar4;Ar5;Ar6;Ar7;Ar8;Bl1;Bl2;Bl3;Bl4;Bl5;Bl6;Bl7;Bl8;" +
        //    "Ve1;Ve2;Ve3;Ve4;Ve5;Ve6;Ve7;Ve8;;Punti;" +
        //    "birreria;carpentiere;contadino;fabbro;bracciale;collana;statue;cappello;" +
        //    "druido;meraviglie;guardia;monete;residuo;marmo;tiara;fantasma");
        RigheCSV.Add("#;Ar1;Ar2;Ar3;Ar4;Ar5;Ar6;Ar7;Ar8;Bl1;Bl2;Bl3;Bl4;Bl5;Bl6;Bl7;Bl8;" +
            "Ve1;Ve2;Ve3;Ve4;Ve5;Ve6;Ve7;Ve8;;Punti;" +
            "birrerie;carpentieri;contadini;fabbri;bracciali;collane;statue;cappelli;" +
            "druidi;meraviglie;guardie;monete;residui;pozioni;tiare;fantasmi");
        for (int c = 0; c < casiFiltrati.Count; c++) {
            if (casiFiltrati[c].integer == attuale.integer)
                continue;// che lo aggiungo a fare il caso attuale
            int[] risorMancanti = new int[16];
            int punti = 0;
            StringBuilder rigaCSV = new StringBuilder(c + ";");

            // arancio
            int delta = 1;
            for (int i = 0; i < 8; i++) {
                rigaCSV.Append(casiFiltrati[c].arancio[i] ? "1;" : "0;");
                if (casiFiltrati[c].arancio[i] != attuale.arancio[i]) {
                    Step step = stepsMappaCorrente[i + delta];
                    punti += step.Punti;
                    int id = listaRisorse.IndexOf(step.Risorsa1);
                    risorMancanti[id] += step.N_Risorsa1;
                    risorMancanti[id] -= steps_arancio[i].Value1;
                    id = listaRisorse.IndexOf(step.Risorsa2);
                    risorMancanti[id] += step.N_Risorsa2;
                    risorMancanti[id] -= steps_arancio[i].Value2;
                    id = listaRisorse.IndexOf(step.Risorsa3);
                    risorMancanti[id] += step.N_Risorsa3;
                    risorMancanti[id] -= steps_arancio[i].Value3;
                }
            }
            // blu
            delta += 8;
            for (int i = 0; i < 8; i++) {
                rigaCSV.Append(casiFiltrati[c].blu[i] ? "1;" : "0;");
                if (casiFiltrati[c].blu[i] != attuale.blu[i]) {
                    Step step = stepsMappaCorrente[i + delta];
                    punti += step.Punti;
                    int id = listaRisorse.IndexOf(step.Risorsa1);
                    risorMancanti[id] += step.N_Risorsa1;
                    risorMancanti[id] -= steps_blu[i].Value1;
                    id = listaRisorse.IndexOf(step.Risorsa2);
                    risorMancanti[id] += step.N_Risorsa2;
                    risorMancanti[id] -= steps_blu[i].Value2;
                    id = listaRisorse.IndexOf(step.Risorsa3);
                    risorMancanti[id] += step.N_Risorsa3;
                    risorMancanti[id] -= steps_blu[i].Value3;
                }
            }
            // verde
            delta += 8;
            for (int i = 0; i < 8; i++) {
                rigaCSV.Append(casiFiltrati[c].verde[i] ? "1;" : "0;");
                if (casiFiltrati[c].verde[i] != attuale.verde[i]) {
                    Step step = stepsMappaCorrente[i + delta];
                    punti += step.Punti;
                    int id = listaRisorse.IndexOf(step.Risorsa1);
                    risorMancanti[id] += step.N_Risorsa1;
                    risorMancanti[id] -= steps_verde[i].Value1;
                    id = listaRisorse.IndexOf(step.Risorsa2);
                    risorMancanti[id] += step.N_Risorsa2;
                    risorMancanti[id] -= steps_verde[i].Value2;
                    id = listaRisorse.IndexOf(step.Risorsa3);
                    risorMancanti[id] += step.N_Risorsa3;
                    risorMancanti[id] -= steps_verde[i].Value3;
                }
            }
            // ora che ci faccio?
            rigaCSV.Append(';').Append(punti);
            for (int i = 0; i < 16; i++) {
                rigaCSV.Append(';').Append(risorMancanti[i]);
            }
            RigheCSV.Add(rigaCSV.ToString());
        }
        File.WriteAllLines("casistiche.csv", RigheCSV);
        MessageBox.Show("Finito!");
    }


    #region "Bottoni gruppi di selezione"

    private void btnArancioT_Click(object sender, EventArgs e) {
        SetSelezArancio(1, 8, true);
    }

    private void btnArancioF_Click(object sender, EventArgs e) {
        SetSelezArancio(1, 8, false);
    }

    private void btnAr12T_Click(object sender, EventArgs e) {
        SetSelezArancio(1, 2, true);
    }

    private void btnAr12F_Click(object sender, EventArgs e) {
        SetSelezArancio(1, 2, false);
    }

    private void btnAr25T_Click(object sender, EventArgs e) {
        SetSelezArancio(2, 5, true);
    }

    private void btnAr25F_Click(object sender, EventArgs e) {
        SetSelezArancio(2, 5, false);
    }

    private void btnAr58T_Click(object sender, EventArgs e) {
        SetSelezArancio(5, 8, true);
    }

    private void btnAr58F_Click(object sender, EventArgs e) {
        SetSelezArancio(5, 8, false);
    }

    private void SetSelezArancio(int da, int a, bool value) {
        for (int i = da - 1; i < a; i++)
            steps_arancio[i].isChecked = value;
    }

    private void btnBluT_Click(object sender, EventArgs e) {
        SetSelezBlu(1, 8, true);
    }

    private void btnBluF_Click(object sender, EventArgs e) {
        SetSelezBlu(1, 8, false);
    }

    private void btnBlu12T_Click(object sender, EventArgs e) {
        SetSelezBlu(1, 2, true);
    }

    private void btnBlu12F_Click(object sender, EventArgs e) {
        SetSelezBlu(1, 2, false);
    }

    private void btnBlu25T_Click(object sender, EventArgs e) {
        SetSelezBlu(2, 5, true);
    }

    private void btnBlu25F_Click(object sender, EventArgs e) {
        SetSelezBlu(2, 5, false);
    }

    private void btnBlu58T_Click(object sender, EventArgs e) {
        SetSelezBlu(5, 8, true);
    }

    private void btnBlu58F_Click(object sender, EventArgs e) {
        SetSelezBlu(5, 8, false);
    }
    private void SetSelezBlu(int da, int a, bool value) {
        for (int i = da - 1; i < a; i++)
            steps_blu[i].isChecked = value;
    }
    private void btnVerdeT_Click(object sender, EventArgs e) {
        SetSelezVerde(1, 8, true);
    }

    private void btnVerdeF_Click(object sender, EventArgs e) {
        SetSelezVerde(1, 8, false);
    }

    private void btnVer12T_Click(object sender, EventArgs e) {
        SetSelezVerde(1, 2, true);
    }

    private void btnVer12F_Click(object sender, EventArgs e) {
        SetSelezVerde(1, 2, false);
    }

    private void btnVer25T_Click(object sender, EventArgs e) {
        SetSelezVerde(2, 5, true);
    }

    private void btnVer25F_Click(object sender, EventArgs e) {
        SetSelezVerde(2, 5, false);
    }

    private void btnVer58T_Click(object sender, EventArgs e) {
        SetSelezVerde(5, 8, true);
    }

    private void btnVer58F_Click(object sender, EventArgs e) {
        SetSelezVerde(5, 8, false);
    }
    private void SetSelezVerde(int da, int a, bool value) {
        for (int i = da - 1; i < a; i++)
            steps_verde[i].isChecked = value;
    }
    #endregion

    private void cboMappa_SelectedIndexChanged(object sender, EventArgs e) {
        //MessageBox.Show(cboMappa.Text + " " + cboMappa.SelectedIndex);
        LoadSteps(cboMappa.SelectedIndex);
    }
    List<Step> stepsMappaCorrente;
    private void LoadSteps(int idMappa) {
        SetSelezArancio(1, 8, false);
        SetSelezBlu(1, 8, false);
        SetSelezVerde(1, 8, false);
        switch (idMappa) {
            case 0:
                stepsMappaCorrente = CalcoloCasi.StepsMappa1;
                break;
            case 1:
                stepsMappaCorrente = CalcoloCasi.StepsMappa2;
                break;
            default:
                stepsMappaCorrente = CalcoloCasi.StepsMappa3;
                break;
        }
        int delta = 1;
        for (int i = 0; i < 8; i++) {
            steps_arancio[i].SetStep(stepsMappaCorrente[i + delta]);
        }
        delta += 8;
        for (int i = 0; i < 8; i++) {
            steps_blu[i].SetStep(stepsMappaCorrente[i + delta]);
        }
        delta += 8;
        for (int i = 0; i < 8; i++) {
            steps_verde[i].SetStep(stepsMappaCorrente[i + delta]);
        }
    }
}
