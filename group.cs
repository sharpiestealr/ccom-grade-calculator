
using delegado;
using System.Numerics;

Console.WriteLine("Quantos delegados há no comitê?");
int committee = Convert.ToInt16(Console.ReadLine());
int count = 0;

List<Delegado> ccom = new List<Delegado>();

while (count != committee)
{
    Console.WriteLine("----------------------------\nDelegado "+(count+1)+"\nNome do delegado:");
    string name = Console.ReadLine();
    int a = articles(), b = bonus(), c = crossover();
    float p = proactivity(a, b, c);
    double q = quality(a, b), at = attitude(), d = dpo();
    Delegado delegado = new Delegado(name, p, q, at, d, final(p, q, at, d));
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

int articles()
{
    Console.WriteLine("Quantos artigos o delegado escreveu para o seu comitê?");
    return Convert.ToInt16(Console.ReadLine());
}

int bonus()
{
    Console.WriteLine("Quantos artigos adicionais o delegado escreveu?");
    return Convert.ToInt16(Console.ReadLine());
}

int crossover()
{
    Console.WriteLine("Quantas participações o delegado teve no podcast ou telejornal?");
    return Convert.ToInt16(Console.ReadLine());
}

float proactivity(int articles, int bonus, int crossover)
{
    if ((articles + bonus) < 4)
    { 
        return 4;
    }
    else 
    { 
        return (7 * articles + 2 * bonus + crossover) / 10;
    }
}

double quality(int articles, int bonus)
{
    double grade = 0, roleplay = 0;
        
    for (int i=0; i<(articles+bonus); i++)
    {
        Console.WriteLine("Qual a nota da redação do artigo "+(i+1)+" ?");
        grade += Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Qual a nota da linha editorial do artigo "+(i+1)+" ?");
        roleplay += Convert.ToDouble(Console.ReadLine());
    }

    double g = grade/articles, r = roleplay/articles;
    double q = 0;
    
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
    return (Convert.ToDouble(Console.ReadLine()))/10;
}

double dpo()
{
    Console.WriteLine("Qual a nota para a primeira história do delegado?");
    return (Convert.ToDouble(Console.ReadLine()))/10;
}

double final(float proactivity, double quality, double attitude, double dpo)
{
    return ( ( (.4*proactivity + .5*quality + attitude) *.9) + dpo);
}
