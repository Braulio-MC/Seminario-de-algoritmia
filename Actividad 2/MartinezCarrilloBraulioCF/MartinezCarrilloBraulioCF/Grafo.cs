using System;
using System.Collections.Generic;
using System.Drawing;

public class Grafo
{
	readonly List<Vertice> _lstVertices;
    readonly List<(Vertice, Vertice, float)> _lstCentros;

    public Grafo()
	{
        _lstVertices = new List<Vertice>();
        _lstCentros = new List<(Vertice, Vertice, float)>();
    }

	public void AgregaVertice(Circulo circulo)
    {
        _lstVertices.Add(new Vertice(circulo));
    }

    public void AgregaCentro((Vertice, Vertice, float) c)
    {
        _lstCentros.Add(c);
    } 
    
    public float CalculaDistancia(Point xy1, Point xy2)
    {
        return (float)Math.Sqrt(Math.Pow((xy2.X - xy1.X), 2) + Math.Pow((xy2.Y - xy1.Y), 2));
    }

    public (Vertice, Vertice, float) CalculaCentrosCercanos()
    {
        var menor = _lstCentros[0];
        for (int i = 1; i < _lstCentros.Count; i++)
        {
            if (_lstCentros[i].Item3 < menor.Item3)
            {
                menor = _lstCentros[i];
            }
        }
        return menor;
    }

    public int Count
    {
        get => _lstVertices.Count;
    }

    public void Clear()
    {
        _lstCentros.Clear();
        _lstVertices.Clear();
    }

    public Vertice this[int i]
    {
        get => _lstVertices[i];
    }
}

public class Vertice
{
    readonly List<Arista> _lstAristas;
    readonly Circulo _circulo;

    public Vertice(Circulo circulo)
    {
        _lstAristas = new List<Arista>();
        _circulo = circulo;
    } 

    public Circulo Circulo
    {
        get => _circulo;
    }

    public void AgregaArista(Vertice v_b, float peso)
    {
        _lstAristas.Add(new Arista(v_b, peso));
    }

    public bool ExisteArista(Vertice v_b)
    {
        foreach (var item in _lstAristas)
        {
            if (v_b.Equals(item.Vertice))
            {
                return true;
            }
        }
        return false;
    }

    public int Count
    {
        get => _lstAristas.Count;
    }

    public void Clear()
    {
        _lstAristas.Clear();
    }

    public override string ToString()
    {
        return _circulo.ToString();
    }
}

public class Arista
{
    readonly Vertice _v_asoc;
    readonly float _peso;

    public Arista(Vertice v_asoc, float peso)
    {
        _v_asoc = v_asoc;
        _peso = peso;
    }

    public Vertice Vertice
    {
        get => _v_asoc;
    }

    public float Peso
    {
        get => _peso;
    }

    public override string ToString()
    {
        return "V asoc: " + _v_asoc + ", peso: " + _peso;
    }
}