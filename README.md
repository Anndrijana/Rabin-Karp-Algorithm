# Rabin-Karp-Algoritam

Algoritam radi na principu upoređivanja hash vrednosti umesto naivnog upoređivanja
svih karaktera. Na narednoj fotografiji prikazan je primer gde se u stringu “GEEKSFORGEEKS”
pretražuje podstring “GEEK”:

![17](https://user-images.githubusercontent.com/61964257/145113514-c98e4882-61ef-4899-bcb6-4211a2a5c1a6.PNG)

Dužine stringova su predstavljene sa desne strane, respektivno. Umesto upoređivanja 
karaktera po karakter algoritam će najpre izračunati hash vrednosti podstringa “GEEK” i
onda će za njegovu dužinu(m) uzeti m prvih karaktera u tekstu i izračunati njegovu hash 
vrednost kao što je prikazano na fotografiji ispod:

![18](https://user-images.githubusercontent.com/61964257/145113519-020b088c-cb48-4c22-bc85-08f7c4527015.PNG)

Na slici iznad se vidi da su hash vrednosti oba stringa jednaka nekom broju x i kada se te 
hash vrednosti poklapaju tek onda se upoređuje slovo po slovo da bi bili sigurni. 
Moramo upoređivati slovo po slovo jer se može desiti da dva različita stringa imaju istu 
hash vrednost. Prednost Karp-Rabinovog algoritma je što se upoređivanje slova vrši tek 
kada se hash vrednosti poklope i na taj način se smanjuje broj upoređivanja. Kada se 
završi sa trenutnim vrednostima u tekstu pomera se prozor za jedan u desno, karakter 
G ispada, a karakter S se dodaje na kraj. Na ovaj način ako se implementira pomerajuće 
računanje hash vrednosti onda se kompletan hash ne mora opet izračunavati nego je 
moguće samo rehash-ovanje tj. preračunavanje.
Na slici ispod vidimo da se sledeće hash vrednosti ne poklapaju i onda se taj indeks ne pamti.

![19](https://user-images.githubusercontent.com/61964257/145113521-846878e8-180c-4657-90f9-0776c36abf0d.PNG)

Postupak se ponavlja sve dok se ne nađu sva ponavljanja datog podstringa u tekstu. Ako je 
dati podstring jos negde u tekstu za njega će nam hash funkcija opet vratiti istu vrednost i moći 
ćemo i njegov indeks da zapamtimo, kao što je dato na fotografiji ispod:

![20](https://user-images.githubusercontent.com/61964257/145113522-18a778df-19d7-4164-ac66-37b8879e4922.PNG)

## Pomerajuće računanje hash-a
Hash funkcija implementirana je relativno jednostavno. U zavisnosti od baze za svako 
slovo koje je u stringu redom množi to slovo sa odgovarajućim stepenom baze. Ukoliko imamo string “GEEKSFORGEEKS” i u njemu pretražujemo string “GEEK” onda za 
string koji se pretražuje, hash vrednost se računa na sledeći način:
1. *baza = 5*
2. *k – jako veliki prost broj*

H(“ABCD”) = (G*50 + E*51 + E*52 + K*53) mod k

Moduo se ubacuje jer za izuzetno dugačke stringove, ovakvim množenjem možemo doći do 
prekoračenja. Kako ne bi došlo do prekoračenja najbolje je za rezultat uzeti moduo nekog 
velikog prostog broja.
Nakon računanja hash vrednosti podstringa treba izračunati za prvih 4 karaktera u 
tekstu hash vrednost. U ovom slučaju to bi bila ista hash vrednost. Za sledeću iteraciju 
pomeramo prozor i proveravamo string “EEKS“. Kako već imamo hash vrednost 
prethodnog prozora ne moramo da radimo kompletno računanje nego možemo samo 
preračunavanje da odradimo:
1. Izbacimo vrednost koja je sada ispala (G*50)
2. Podelimo celu hash vrednost sa bazom
3. Ubacimo novu vrednost (karakter S)

Na ovaj način ubrzavamo računanje i hash vrednost se samo preračunava, a nikad se 
više ne računa ispočetka.
