namespace Anno1404Warenrechner
{
    class NeedsCalculator
    {
        public static Needs CalculateNeeds(Population population)
        {
            var needs = new Needs();

            needs.Fish =
                (float)population.Beggars / 285 +
                (float)population.Peasants / 200 +
                (float)population.Citizens / 500 +
                (float)population.Patricians / 909 +
                (float)population.Noblemen / 1250;

            needs.Spices =
                (float)population.Citizens / 500 +
                (float)population.Patricians / 909 +
                (float)population.Noblemen / 1250;

            needs.Bread =
                (float)population.Patricians / 727 +
                (float)population.Noblemen / 1025;

            needs.Meat =
                (float)population.Noblemen / 1136;

            needs.Most =
                (float)population.Beggars / 500 +
                (float)population.Peasants / 340 +
                (float)population.Citizens / 340 +
                (float)population.Patricians / 652 +
                (float)population.Noblemen / 1153;

            needs.Beer =
                (population.Patricians > 510 ?
                    ((float)population.Patricians / 625) : 0) +
                (float)population.Noblemen / 1071;

            needs.Wine =
                (population.Noblemen > 1500 ?
                    ((float)population.Noblemen / 1000) : 0);

            needs.Garments =
                (float)population.Citizens / 476 +
                (float)population.Patricians / 1052 +
                (float)population.Noblemen / 2500;

            needs.Jerkins =
                (population.Patricians > 690 ?
                    ((float)population.Patricians / 1428) : 0) +
                (float)population.Noblemen / 2500;

            needs.FurCoats =
                (population.Noblemen > 950 ?
                    ((float)population.Noblemen / 1562) : 0);

            needs.Robes =
                (population.Noblemen > 4000 ?
                    ((float)population.Noblemen / 2112) : 0);

            needs.Books =
                (population.Patricians > 940 ?
                    ((float)population.Patricians / 1875) : 0) +
                (float)population.Noblemen / 3333;

            needs.CandleSticks =
                population.Noblemen > 3000 ?
                    (float)population.Patricians / 2500 +
                    (float)population.Noblemen / 3333
                    : 0;

            needs.Glasses =
                (population.Noblemen > 2200 ?
                    ((float)population.Noblemen / 1709) : 0);

            needs.Dates =
                (float)population.Nomads / 450 +
                (float)population.Envoys / 600;

            needs.Milk =
                (population.Nomads > 145 ?
                    ((float)population.Nomads / 436) : 0) +
                (float)population.Envoys / 666;

            needs.Carpets =
                (population.Nomads > 295 ?
                    ((float)population.Nomads / 909) : 0) +
                (float)population.Envoys / 1500;

            needs.Coffee =
                (float)population.Envoys / 1000;

            needs.PearNecklaces =
                (population.Envoys > 1040 ?
                    ((float)population.Envoys / 751) : 0);

            needs.Parfum =
                (population.Envoys > 2600 ?
                    ((float)population.Envoys / 1250) : 0);

            needs.Marzipan =
                (population.Envoys > 4360 ?
                    ((float)population.Envoys / 2453) : 0);

            return needs;
        }
    }
}
