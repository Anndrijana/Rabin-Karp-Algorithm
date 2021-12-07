<Query Kind="Program" />

//Rabin-Karp algoritam za pretrazivanje podstringova
//Ulazi su dva stringa, jedan koji se pretrazuje(t), string pretrage(s).
//Rezultat su indeksi pozicija na kojima se string s nalazi u stringu t
//ako nema stringa s u stringu t ispisati poruku o greski
//implementirati rolling hash strukturu
//stampati interakciju izmedju stringa u podstringa
void Main()
{
	Test1();
	Test2();
	Test3();
}

void Test1()
{
	Console.WriteLine("Starting test1...");
	string t = "geeksforgeeks";
	string s = "geek";
	List<int> rez = RabinKarpAlgorithm(t, s);
	
	if(rez.Count != 0)
	{
		Console.Write("Result indexes: [");
		for(int i = 0; i < rez.Count - 1; i++)
			Console.Write(rez[i] + ", ");
		Console.WriteLine(rez[rez.Count - 1] + "]");
	}
	else
	{
		Console.WriteLine("There are no string {0} in string {1}", s, t);
	}
	Console.WriteLine("Test1 finished\n\n\n");
}

void Test2()
{
	Console.WriteLine("Starting test2...");
	string t = "f32qtgwergasd5w3ertf32qtgwergasd5w3ertf32qtgwergasd5w3ertf32qtgwergasd5w3ertf32qtgwergasd5w3ertf32qtgwergasd5w3ertf32qtgwergasd5w3ert";
	string s = "5w3ert";
	List<int> rez = RabinKarpAlgorithm(t, s);
	
	if(rez.Count != 0)
	{
		Console.Write("Result indexes: [");
		for(int i = 0; i < rez.Count - 1; i++)
			Console.Write(rez[i] + ", ");
		Console.WriteLine(rez[rez.Count - 1] + "]");
	}
	else
	{
		Console.WriteLine("There are no string {0} in string {1}", s, t);
	}
	Console.WriteLine("Test2 finished\n\n\n");
}

void Test3()
{
	Console.WriteLine("Starting test3...");
	string t = "fq234fq3fqwefasdfq234fq3fqwefasdfq234fq3fqwefasdfq234fq3fqwefasdfq234fq3fqwefasdfq234fq3fqwefasd";
	string s = "234fq";
	List<int> rez = RabinKarpAlgorithm(t, s);
	
	if(rez.Count != 0)
	{
		Console.Write("Result indexes: [");
		for(int i = 0; i < rez.Count - 1; i++)
			Console.Write(rez[i] + ", ");
		Console.WriteLine(rez[rez.Count - 1] + "]");
	}
	else
	{
		Console.WriteLine("There are no string {0} in string {1}", s, t);
	}
	Console.WriteLine("Test3 finished\n\n\n");
}


List<int> RabinKarpAlgorithm(string t, string s)
{
	List<int> returnValue = new List<int>();
	int hashBase = 5; //moze biti bilo koji broj
	int kMod = 183709;
	int sHashValue = 0; //s je mali podstring (ulazna vrednost - pise u zadatku)
	int tHashValue = 0; //t je veliki string (ulazna vrednost - pise u zadatku)
	
	Console.WriteLine("String: " + t);
	Console.WriteLine("Substring: " + s + "\n"); 
	
	if(t.Length < s.Length) //string mora biti veci od podstringa
	{
		Console.WriteLine("Substring must be smaler or same size as searching string");
		return returnValue;
	}
	
	for(int i = 0; i < s.Length; i++) //racunanje hes vrednosti za podstring
	{
		sHashValue += (s[i]*(int)Math.Pow(hashBase, i)); //nema mnogo kompl. operacija za procesor - ima dobro vreme izvrsavanja
		sHashValue %= kMod; //problem - ako imamo jako dugacak string npr. 10 - to je onda neki broj na 10 (ovo je veliki broj pa dolazi do prekoracenja), a da ne bi doslo do toga radi se moduo
		//svaki put kad stepenujemo radimo moduo da ne bi doslo do prekoracenja prilikom sabiranja - moduo uzima ostatak pri deljenju 
		//moduo je neki veliki prirodni prost broj - sto veci (ako imamo prost broj, prilikom deljenja necemo imati isti ostatak nikad posto je od deljiv samo sa samim sobom i 1)
	}
	for(int i = 0; i < s.Length; i++) //racunanje hes vrednosti za string duzine podstringa
	{
		tHashValue += (t[i]*(int)Math.Pow(hashBase, i));
		tHashValue %= kMod;
	}
	
	Console.WriteLine("[Iteration 0]");
	if(sHashValue == tHashValue) //ako su hes vrednosti iste ne mora da znaci da su i stringovi isti - cim hes vrednosti nisu iste onda se ne proverava slovo po slovo
	//nulta iteriacija se posebno pise, jer se inicijalno racuna hash vrednost
	{
		Console.WriteLine("[Hash match: true]");
		bool areSame = true; //tek ako su hes vrednosti iste proveravam slovo po slovo
		for(int i = 0; i < s.Length; i++)
		{
			if(s[i] != t[i])
				{areSame = false;}
		}
		if(areSame)
		{
			Console.WriteLine("[String match: true]");
			returnValue.Add(0);
		}
		else
		{
			Console.WriteLine("[String match: false]");
		}
	}
	else
	{
		Console.WriteLine("[Hash match: false]");
		Console.WriteLine("[String match: false]");
	}
	Console.WriteLine("----------------------------");
	for(int i = 1; i < t.Length - s.Length; i++) //ne radi se ponovno hesiranje, vec radimo rehesiranje
	{
		Console.WriteLine($"[Iteration {i}]");
		tHashValue -= t[i-1];
		tHashValue /= hashBase;
		tHashValue += (t[i + s.Length - 1]*(int)Math.Pow(hashBase, s.Length - 1));
		tHashValue %= kMod;
		if(tHashValue == sHashValue)
		{
			Console.WriteLine("[Hash match: true]");
			bool areSame = true;
			for(int j = 0; j < s.Length; j++)
			{
				if(s[j] != t[j + i]) //s od 0 i t od 8, a to je G G i poklapaju se
					areSame = false;
			}
			if(areSame)
			{
				Console.WriteLine("[String match: true]");
				returnValue.Add(i);
			}
			else
			{
				Console.WriteLine("[String match: false]");
			}
		}
		else
		{
			Console.WriteLine("[Hash match: false]");
			Console.WriteLine("[String match: false]");
		}
		Console.WriteLine("----------------------------");
	}
	
	return returnValue;
}