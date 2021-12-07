# Rabin-Karp-Algoritam

Algoritam radi na principu upoređivanja hash vrednosti umesto naivnog upoređivanja
svih karaktera. Na narednoj fotografiji prikazan je primer gde se u stringu “GEEKSFORGEEKS”
pretražuje podstring “GEEK”.

Dužine stringova su predstavljene sa desne strane, respektivno. Umesto upoređivanja 
karaktera po karakter algoritam će najpre izračunati hash vrednosti podstringa “GEEK” I
onda ce za njegovu dužinu(m) uzeti m prvih karaktera u tekstu i izračunati njegovu hash 
vrednost kao što je prikazano na fotografiji ispod: 
