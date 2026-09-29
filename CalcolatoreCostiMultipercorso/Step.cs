using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcolatoreCostiMultipercorso;

public class Step {
    public int Id;
    public int Punti;
    public int N_Risorsa1;
    public string Risorsa1;
    public int N_Risorsa2;
    public string Risorsa2;
    public int N_Risorsa3=0;
    public string Risorsa3="";
    public Step(int Id, int Punti,
        int N_Risorsa1, string Risorsa1,
        int N_Risorsa2, string Risorsa2,
        int N_Risorsa3, string Risorsa3) :this(Id, Punti,
        N_Risorsa1, Risorsa1,
        N_Risorsa2, Risorsa2) {

        this.N_Risorsa3 = N_Risorsa3;
        this.Risorsa3 = Risorsa3;
    }
    public Step(int Id, int Punti,
        int N_Risorsa1, string Risorsa1,
        int N_Risorsa2, string Risorsa2) {

        this.Id = Id;
        this.Punti = Punti;
        this.N_Risorsa1 = N_Risorsa1;
        this.Risorsa1 = Risorsa1;
        this.N_Risorsa2 = N_Risorsa2;
        this.Risorsa2 = Risorsa2;
    }
    public override string ToString() {
        return $"{Id}|{Punti}|{N_Risorsa1}|{Risorsa1}|{N_Risorsa2}|{Risorsa2}|{N_Risorsa3}|{Risorsa3}";
    }
}

