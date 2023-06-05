namespace beer_caps;

class BeerEncapsulator
{
    private double _avalaibleBeerVolume;
    private int _avalaibleBottles;
    private int _avalaibleCapsules;

    public double AccessBeer(int refill){
        if(refill > 0){
            _avalaibleBeerVolume = _avalaibleBeerVolume + refill;
        } else {
            Console.WriteLine("Erreur : vous ne pouvez pas soustraire");
        }
        return _avalaibleBeerVolume;
    }

    public double AccessBottles(int refill){
        if(refill > 0){
            _avalaibleBottles = _avalaibleBottles + refill;
        } else {
            Console.WriteLine("Erreur : vous ne pouvez pas soustraire");
        }
        return _avalaibleBottles;
    }

    public double AccessCaps(int refill){
        if(refill > 0){
            _avalaibleCapsules = _avalaibleCapsules + refill;
        } else {
            Console.WriteLine("Erreur : vous ne pouvez pas soustraire");
        }
        return _avalaibleCapsules;
    }

    public int ProduceEncapsulatedBeerBottles(int order){
        if(order > 0){

            if(_avalaibleBeerVolume < order * 0.33){
                Console.WriteLine("Pas assez de bière");
                return 0;
            }
            if(_avalaibleBottles < order){
                Console.WriteLine("Pas assez de bouteilles");
                return 0;
            }
            if(_avalaibleCapsules < order){
                Console.WriteLine("Pas assez de capsules");
                return 0;
            }

            _avalaibleBeerVolume = _avalaibleBeerVolume - (order * 0.33);
            _avalaibleBottles = _avalaibleBottles - order;
            _avalaibleCapsules = _avalaibleCapsules - order;

            return order;
        }
        Console.WriteLine("Vous ne pouvez pas produire en négatif");
        return 0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bonjour, ici on met de la bière en bouteille");
        Console.WriteLine("On va commencer par la matière première");

        Console.Write("Combien de litres de bière sont disponibles dans la machine ? ");
        int beerInit = Int32.Parse(Console.ReadLine());

        Console.Write("Combien de bouteilles vides sont disponibles dans la machine ? ");
        int bottlesInit = Int32.Parse(Console.ReadLine());

        Console.Write("Combien de capsules sont disponibles dans la machine ? ");
        int capsInit = Int32.Parse(Console.ReadLine());

        BeerEncapsulator monUsine = new BeerEncapsulator();
        monUsine.AccessBeer(beerInit);
        monUsine.AccessBottles(bottlesInit);
        monUsine.AccessCaps(capsInit);

        Console.WriteLine("");
        int resultat = -1;

        while(true){

            if(resultat == 0){
                Console.WriteLine("Quel ingrédient manque-t-il ?");
                Console.WriteLine("biere - bouteilles - capsules");
                string input = Console.ReadLine();

                switch(input){
                    case "biere" :
                        Console.Write("Combien de litres de bière ? ");
                        monUsine.AccessBeer(Int32.Parse(Console.ReadLine()));
                        resultat = -1;
                        break;
                    case "bouteilles" :
                        Console.Write("Combien de bouteilles ? ");
                        monUsine.AccessBottles(Int32.Parse(Console.ReadLine()));
                        resultat = -1;
                        break;
                    case "capsules" :
                        Console.Write("Combien de capsules ? ");
                        monUsine.AccessCaps(Int32.Parse(Console.ReadLine()));
                        resultat = -1;
                        break;
                    default :
                        Console.WriteLine("Saisie non reconnue");
                        break;
                }

                Console.WriteLine("");

            }

            else {

                Console.Write("Vous êtes prêts pour l'embouteillage, combien de bouteilles voulez-vous produire ? ");
                resultat = monUsine.ProduceEncapsulatedBeerBottles(Int32.Parse(Console.ReadLine()));
                if(resultat > 0){
                    Console.WriteLine("Vous avez produit " + resultat + " bouteilles avec succes");
                    Console.WriteLine("");
                }
            }
        }
    }
}
