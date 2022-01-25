namespace CATAGY_CBRadio
{
    class Bejegyzes
    {
        public int Ora { get; set; }
        public int Perc { get; set; }
        public int InditottAdas { get; set; }
        public string Nev { get; set; }
        public int AtszamolPercre => (Ora * 60) + Perc;

        public Bejegyzes(string sor)
        {
            var buffer = sor.Split(';');
            Ora = int.Parse(buffer[0]);
            Perc = int.Parse(buffer[1]);
            InditottAdas = int.Parse(buffer[2]);
            Nev = buffer[3];
        }

    }
}
