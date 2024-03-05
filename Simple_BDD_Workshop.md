# Réalisation d'un BehaviorDrivenDevelopment simple (sans interface pour l'instant)

## Création du projet
- Si nous n'avons pas fait cette étape au préalable, il faut la faire en première :
    - Pour cette partie il faut d'abord installer l'extension Visual Studio pour SpecFlow, cliquez sur "extensions" => "Gérer les extensions" puis recherchez et ajoutez "SpecFlow for Visual Studio 2022".
    - Vous devrez redémarrer votre instance de Visual Studio pour que les modifications se fassent (N'oubliez pas de cliquer sur "Modify")
- Créer un projet SpecFlow dans une nouvelle solution. Choisissez MsTest comme framework de tests et la cible en .Net 6.0.
- Nommez ce projet "CalculatorSpecFlow" par exemple.
- Le but de ce projet est de réaliser un BehaviorDD pour une calculatrice simple (sans interface pour l'instant)
- Utilisez à nouveau la cible de tests MsTests pour ce projet.

## Création du fichier FeatureFile contenant les scénarios en Gherkin
- Premièrement on va supprimer le fichier sous Feature ET sous StepDefinitions automatiquement crée lors de la création du projet.
- Ajouter un NOUVEAU fichier feature CalculatorAdd.feature (rechercher feature après avoir fait ajouter un nouvel element)
- Dans ce fichier, écrivez en Gherkin un scénario d'ajout deux deux nombres avec les étapes suivantes (à reformuler correctement) :
    - Deux entrées X et Y sont envoyées par l'utilisateur (et les mettre dans les variables privées, voir suite)
    - Vérification que ces entrées sont bien des entiers
    - Ajouter ces deux entiers (et mettre le résultat dans la variable privée, voir suite)
    - Le résultat est un entier
    - Et le résultat est Z
- Scénario Gherkin proposé (adaptable)
```
Feature: CalculatorAddFeature
	Simple calculator to add two numbers

Scenario: Verify two entries and add them if they are numbers
	Given the first element is 50
	And the second element is 70
	When the two elements are integers
	And the two elements are added
	Then the addition type should be integer
	And the addition result should be equal to 120
```

## Génération et démarrage du fichier StepDefinitions
- Générez après un click droit sur votre fichier FeatureFile le fichier StepDefinitions (à placer dans le répertoire StepDefinitions du projet)
- /!\ A noter, il se peut que cette option de génération automatique ne soit pas disponible /!\
- Si c'est le cas, c'est que certains packages nuget ne sont pas installés. Installez les packages suivant : 
  - SpecFlow
  - SpecFlow.MsTest
  - SpecFlow.Tools.MsBuild.Generation
  - SpecFlow.Plus.LivingDocPlugin
- Si ça ne fonctionne toujours pas au click droit, alors, créez une classe "CalculatorAddSteps" avec le contenu à remplir suivant :
```
    [Binding]
    public class CalculatorAddSteps
    {
        private Calculator Calculator = new Calculator();

        [Given(@"...")]
        public void GivenThe...(...)
        {
            ...
        }

        [Given(@"...")]
        public void Given...(...)
        {
            ...
        }

        [When(@"...")]
        public void When...()
        {
            ...
            ...
        }

        [When(@"...")]
        public void When...()
        {
            ...
        }

        [Then(@"...")]
        public void Then...()
        {
            ...
        }

        [Then(@"...")]
        public void Then...(...)
        {
            ...
        }
    }
```
- Chaque ... est à compléter avec du code (logique)
- L'étape de vérification est complètement inutile car le paramètre est reçu en int, je l'accorde, mais c'est pour compléter un peu l'exemple. Vous pouvez utiliser Assert.IsTrue(_calculator.FirstNumber is int) par exemple, ou FirstNumber est la variable globale int privée simulée prenant la valeur donnée lors de l'étape 1 du scénario.
- Utilisez vos steps de scénarios généré en StepDefinitions pour utiliser votre future classe Calculator.
- Dans votre fichier de steps, vous pouvez avoir une propriété privée pour votre calculator : private Calculator _calculator = new Calculator(); (Il est usuellement conseillé de le mettre le context commun d'un test en readonly, peu importe pour cet exemple)
- Calculator contenant uniquement deux propriétés publiques :
    - FirstNumber
    - SecondNumber
- A noter que ces paramètres vont provenir de variables dans vos steps de scénarios
- La classe Calculator va aussi contenir une méthode publique Add(), qui retournera directement FirstNumber + SecondNumber.

**Ceci était un exemple extrêmement simple de mise en place d'un Behavior Driven Development. L'idée est de mettre en place les scénarios pour en définir les étapes et utiliser les tests pour réaliser le code de production de l'application**
