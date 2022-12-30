
Console.WriteLine("Quantos artigos o delegado escreveu para o seu comitê?");
int articles = Convert.ToInt16(Console.ReadLine());
Console.WriteLine("Quantos artigos adicionais o delegado escreveu?");
int bonus = Convert.ToInt16(Console.ReadLine());
Console.WriteLine("Quantas participações o delegado teve no podcast ou telejornal?");
int crossover = Convert.ToInt16(Console.ReadLine());

float proactivity(int articles, int bonus, int crossover)
{
    int a = 4; float c = 0;
    if (articles / 4 > 1) { a = articles; } else if (articles == 0) { a = 0; }
    if (crossover != 0) { c = crossover / 4; }
    return (a + bonus + c);
}

double quality(int articles)
{
    double grade = 0, roleplay = 0;
    for (int i = 0; i < articles; i++)
    {
        Console.WriteLine("Qual a nota da redação do artigo " + (i + 1) + " ?"); grade += Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Qual a nota da linha editorial do artigo " + (i + 1) + " ?"); roleplay += Convert.ToDouble(Console.ReadLine());
    }
    double g = grade / articles, r = roleplay / articles;
    double q = 0;
    if (g < 5 && r < 5) { if (g < r) { q = g; } else { q = r; } }
    else if ((g == 5 && r <= 5) || (g <= 5 && r == 5)) { q = 5; }
    else { q = (g + r) / 2; }
    return q;
}

float proact = proactivity(articles, bonus, crossover);
double qual = quality(articles);

Console.WriteLine("Qual a nota para a postura do delegado durante o evento?");
double attitude = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Qual a nota para a primeira história do delegado?");
double dpo = Convert.ToDouble(Console.ReadLine());

double final = (((4 * proact + 5 * qual + (attitude / 10)) * .9) + (dpo / 10));

Console.WriteLine("A nota final deste delegado é " + final);
Console.ReadKey();