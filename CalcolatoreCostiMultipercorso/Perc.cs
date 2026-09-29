using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcolatoreCostiMultipercorso;

public struct Perc {
    public List<bool> arancio;
    public List<bool> blu;
    public List<bool> verde;

    public Perc() {
        arancio = new();
        blu = new();
        verde = new();
    }
    public Perc(List<bool> arancio, List<bool> blu, List<bool> verde) {
        if (arancio != null && arancio.Count != 8)
            throw new ArgumentOutOfRangeException("arancio.Count != 8");
        if (blu != null && blu.Count != 8)
            throw new ArgumentOutOfRangeException("blu.Count != 8");
        if (verde != null && verde.Count != 8)
            throw new ArgumentOutOfRangeException("verde.Count != 8");
        this.arancio = arancio;
        this.blu = blu;
        this.verde = verde;
    }
    public void Add(bool a, bool b, bool v) {
        arancio.Add(a);
        blu.Add(b);
        verde.Add(v);
    }

    public string ArancioToString() {
        StringBuilder ris = new();
        foreach (bool a in arancio)
            ris.Append(a ? "1" : "0");
        return ris.ToString();
    }
    public string BluToString() {
        StringBuilder ris = new();
        foreach (bool b in blu)
            ris.Append(b ? "1" : "0");
        return ris.ToString();
    }
    public string VerdeToString() {
        StringBuilder ris = new();
        foreach (bool v in verde)
            ris.Append(v ? "1" : "0");
        return ris.ToString();
    }
    public int arancioInt {
        get {
            if (arancio == null)
                return 0;
            int tmp = 0;
            for (int i = 0; i < arancio.Count; i++) {
                if (arancio[i])
                    tmp += 1 << i;
            }
            return tmp;
        }
    }
    public int bluInt {
        get {
            if (blu == null)
                return 0;
            int tmp = 0;
            for (int i = 0; i < blu.Count; i++) {
                if (blu[i])
                    tmp += 1 << i;
            }
            return tmp;
        }
    }
    public int verdeInt {
        get {
            if (verde == null)
                return 0;
            int tmp = 0;
            for (int i = 0; i < verde.Count; i++) {
                if (verde[i])
                    tmp += 1 << i;
            }
            return tmp;
        }
    }
    public int integer {
        get {
            return arancioInt + (bluInt << 8) + (verdeInt << 16);
        }
    }
    public Perc Clona() {
        Perc ris = new Perc();
        ris.arancio = new List<bool>(arancio);
        ris.blu = new List<bool>(blu);
        ris.verde = new List<bool>(verde);
        return ris;
    }
    public override string ToString() {
        return $"[{ArancioToString()}, {BluToString()}, {VerdeToString()}]";
    }
}

