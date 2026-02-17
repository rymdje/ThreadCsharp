# ThreadCsharp

Petit projet en C# pour comprendre le fonctionnement des threads et le problème d’accès en même temps à une même ressource.

Le but était de créer plusieurs threads qui écrivent soit dans la console, soit dans un fichier, et d’éviter les erreurs quand plusieurs threads écrivent en même temps.


## Principe

Au lancement, on peut choisir :

1 : écriture dans la console  
2 : écriture dans un fichier texte  

Chaque thread affiche ou écrit son numéro plusieurs fois.

Pour éviter que les écritures se mélangent, j’utilise un **Mutex** afin qu’un seul thread puisse écrire à la fois.



## Ce que j’ai travaillé

- Création et démarrage de threads (`Thread`)
- Compréhension du problème de concurrence
- Utilisation de `Mutex` pour protéger une ressource partagée
- Attente de la fin des threads avec `Join()`
- Écriture dans un fichier avec `StreamWriter`


## Lancer le projet

Ouvrir la solution dans Visual Studio et exécuter.  
Choisir ensuite 1 ou 2 selon le test voulu.

Si on choisit 2, un fichier texte est généré avec les écritures des différents threads.
