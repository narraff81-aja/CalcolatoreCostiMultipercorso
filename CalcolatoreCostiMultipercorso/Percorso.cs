using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcolatoreCostiMultipercorso;

[Obsolete("",true)]
public struct Percorso {
    public byte arancio;
    public byte blu;
    public byte verde;
    public Percorso(byte arancio, byte blu, byte verde) {
        this.arancio = arancio;
        this.blu = blu;
        this.verde = verde;
    }

    public bool isValido() {
        // per essere valido non deve avere step ambigui
        if (isBitTrue(arancio, 2) && (isBitFalse(arancio, 1) && isBitFalse(blu, 2)))
            //se A1 e B2 sono falsi A2 non può essere vero
            return false;
        if (isBitTrue(blu, 2) && (isBitFalse(blu, 1) && isBitFalse(arancio, 2) && isBitFalse(verde, 2)))
            // se B1 e A2 e V2 sono falsi B2 non può essere vero
            return false;
        if (isBitTrue(verde, 2) && (isBitFalse(verde, 1) && isBitFalse(blu, 2)))
            // se V1 e B2 sono falsi V2 non può essere vero
            return false;

        if (isBitTrue(arancio, 3) && isBitFalse(arancio, 2))
            return false;
        if (isBitTrue(blu, 3) && isBitFalse(blu, 2))
            return false;
        if (isBitTrue(verde, 3) && isBitFalse(verde, 2))
            return false;
        if (isBitTrue(arancio, 4) && isBitFalse(arancio, 3))
            return false;
        if (isBitTrue(blu, 4) && isBitFalse(blu, 3))
            return false;
        if (isBitTrue(verde, 4) && isBitFalse(verde, 3))
            return false;

        if (isBitTrue(arancio, 5) && (isBitFalse(arancio, 4) && isBitFalse(blu, 5)))
            //se A4 e B5 sono falsi A5 non può essere vero
            return false;
        if (isBitTrue(blu, 5) && (isBitFalse(blu, 4) && isBitFalse(arancio, 5) && isBitFalse(verde, 5)))
            // se B4 e A5 e V5 sono falsi B5 non può essere vero
            return false;
        if (isBitTrue(verde, 5) && (isBitFalse(verde, 4) && isBitFalse(blu, 5)))
            // se V4 e B5 sono falsi V5 non può essere vero
            return false;

        if (isBitTrue(arancio, 6) && isBitFalse(arancio, 5))
            return false;
        if (isBitTrue(blu, 6) && isBitFalse(blu, 5))
            return false;
        if (isBitTrue(verde, 6) && isBitFalse(verde, 5))
            return false;
        if (isBitTrue(arancio, 7) && isBitFalse(arancio, 6))
            return false;
        if (isBitTrue(blu, 7) && isBitFalse(blu, 6))
            return false;
        if (isBitTrue(verde, 7) && isBitFalse(verde, 6))
            return false;
        if (isBitTrue(arancio, 8) && isBitFalse(arancio, 7))
            return false;
        if (isBitTrue(blu, 8) && isBitFalse(blu, 7))
            return false;
        if (isBitTrue(verde, 8) && isBitFalse(verde, 7))
            return false;


        // e minimo 1 percorso completo            
        if (isBitFalse(arancio, 8) && isBitFalse(blu, 8) && isBitFalse(verde, 8))
            return false;

        return true;
    }

    private bool isBitTrue(byte b, int idPerc) {
        return ((int)b & 1 << (idPerc - 1)) == 1 << (idPerc - 1);
    }
    private bool isBitFalse(byte b, int idPerc) {
        return ((int)b & 1 << (idPerc - 1)) != 1 << (idPerc - 1);
    }

    public List<bool> bools(byte b) {
        List<bool> bools = new();
        for (int i = 1; i <= 8; i++) {
            bools.Add(isBitTrue(b, i));
        }
        return bools;
    }
    public String boolsString(byte b) {
        List<bool> bb = bools(b);
        string ris = "";

        for (int i = bb.Count - 1; i >= 0; i--) {
            ris += (bb[i] ? "1" : "0");
        }
        return ris;

    }

    public override String ToString() {
        return "{" + arancio + " " + blu + " " + verde + "}";
    }
}

