
using dele;
using redacao;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Numerics;
using Aspose.Cells;


Console.WriteLine("Quantos delegados há no comitê?");
int committee = Convert.ToInt16(Console.ReadLine());
int count = 0;

List<Delegado> ccom = new();

while (count != committee)
{
    Console.WriteLine("----------------------------\nDelegado "+(count+1)+"\nNome do delegado:");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
    string name = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
    List<Article> a = new(articles());
    int c = crossover();
    float p = proactivity(a, c);
    double q = quality(a), at = attitude(), d = dpo();
#pragma warning disable CS8604 // Possible null reference argument.
    Delegado delegado = new(name, a, p, q, at, d, final(p, q, at, d));
#pragma warning restore CS8604 // Possible null reference argument.
    ccom.Add(delegado);
    count++;
}

count = 0;
Console.Clear();
Console.WriteLine("Notas dos delegados");

while (count != committee)
{
    Console.WriteLine(ccom[count].name+" - nota " + ccom[count].final);
    count++;
}

Console.ReadKey();

////////////////////////////////////////////////////////////////////////////////////////////////

List<Article> articles()
{
    bool bonus = false;
    int quantidade, artigo;
    double grade, roleplay;
    List<Article> article = new();

    Console.WriteLine("Quantos artigos o delegado escreveu?");
    quantidade = Convert.ToInt16(Console.ReadLine());

    for (int i=0; i<quantidade; i++)
    {
        Console.WriteLine("O artigo "+(i+1)+" foi escrito para um comitê? (true ou false)");
        artigo = Convert.ToInt16(Console.ReadLine());
        if (artigo == 1) {bonus= true;}
        Console.WriteLine("Qual a nota da redação do artigo "+(i+1)+" ?");
        grade = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Qual a nota da linha editorial do artigo "+(i+1)+" ?");
        roleplay = Convert.ToDouble(Console.ReadLine());

        Article artigos = new(bonus, grade, roleplay);
        article.Add(artigos);
    }

    return article;
}

int crossover()
{
    Console.WriteLine("Quantas participações o delegado teve no podcast ou telejornal?");
    return Convert.ToInt16(Console.ReadLine());
}

float proactivity(List<Article> artigos, int crossover)
{
    int a = 0, b = 0;
    float grade;

    for (int j=0; j!=artigos.Count; j++)
    {
        if (artigos[j].committee == false) { b++; }
        else { a++; }
    }

    if (artigos.Count == 0) { grade = 0; }
    else if (artigos.Count < 4) { grade = artigos.Count; }
    else if (artigos.Count == 4) { grade = 5; }
    else { grade = (8*a + b + crossover)/10; }

    return grade;
}

double quality(List<Article> articles)
{
    double g=0, r=0, q;
    for(int k = 0; k!=articles.Count; k++) { g += articles[k].grammar; }
    for (int l = 0; l != articles.Count; l++) { r += articles[l].writing; }
   
    g /= articles.Count;
    r /= articles.Count;
    
    if (g<5 && r<5)
        { 
            if (g < r) {q = g;}
            else {q = r;}
        }
    else if ((g == 5 && r <= 5) || (g <= 5 && r == 5))
        {
            q = 5;
        }
    else
        {
            q = (g + r) / 2;
        }
    
    return q;
}

double attitude()
{
    Console.WriteLine("Qual a nota para a postura do delegado durante o evento?");
    return Convert.ToDouble(Console.ReadLine());
}

double dpo()
{
    Console.WriteLine("Qual a nota para a primeira história do delegado?");
    return Convert.ToDouble(Console.ReadLine());
}

double final(float proactivity, double quality, double attitude, double dpo)
{
    return ( ( (.3*proactivity + .6*quality + .1*attitude) *.8) + .2*dpo);
}